Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Imports System.Drawing.Printing

Public Class frmyarnopeningreceive
    Dim CmbOperator As DataGridViewComboBoxCell
    Dim gridindex As Integer = 0
    Dim gridcolname As String = ""
    Dim reportid As Integer = 0
    Public Printside As Integer
    Public prn As String = ""
    Private Sub frmyarnopeningreceive_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select CompanyId,CompanyName from companyinfo Where mastercompanyId=" & VarMasterCompanyID & " order by Companyname  " & _
                           "select EI.EmpId,EI.EmpName +case when isnull(EI.empcode,'')<>'' Then ' ['+EI.empcode+']' Else '' End Empname " & _
                               " From empinfo EI inner join Department D " & _
                               " on EI.departmentId=D.DepartmentId Where EI.Blacklist = 0 And D.DepartmentName='Yarn Opening'"
        If VarMasterCompanyID <> 16 And VarMasterCompanyID <> 28 Then
            str = str & "  and EI.EmpName in('Yarn Opening','YARN OPENING-2')"
        End If
        str = str & " order by EmpName"
        str = str & "  select Godownid,Godownname From Godownmaster"

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(DDcompany, ds, 0)

        If DDcompany.Items.Count > 0 Then
            DDcompany.SelectedValue = VarCompanyID
            DDcompany.Enabled = False
        End If
        NewComboFillWithDs(DDvendor, ds, 1)
        NewComboFillWithDs(DDGodown, ds, 2)
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If


    End Sub
    Private Sub DDvendor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDvendor.SelectedIndexChanged
        FillIssueno()
    End Sub

    Protected Sub FillIssueno()
        If DDvendor.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select  Distinct YM.Id,YM.Issueno+'/'+REPLACE(CONVERT(nvarchar(11),YM.Issuedate,106),' ','-') from YarnOpeningIssueMaster YM  inner join YarnOpeningIssueTran YT on YM.ID=YT.MasterId Where ym.vendorId=" & DDvendor.SelectedValue & " and ym.Status='Pending'"
            'If txtLotno.Text <> "" Then
            '    str = str & " and yt.Lotno='" + txtLotno.Text & "'"
            'End If
            str = str & " order by ym.id desc"
            str = str & " select EI.EmpId,EI.EmpName+' '+case WHen EI.EMpcode<>'' Then '['+EI.empcode+']' Else '' End as EmpName from empinfo EI inner join Department D " & _
                          " on EI.departmentId=D.DepartmentId Where D.DepartmentName='Yarn Opening' order by EmpName"
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            NewComboFillWithDs(DDIssueno, ds, 0)
            NewComboFillWithDs(DDemployee, ds, 1)
            If VarMasterCompanyID = 16 Or VarMasterCompanyID = 28 Then
                DDemployee.SelectedValue = DDvendor.SelectedValue
            End If

        End If

    End Sub
    Protected Sub FillIssueDetail()
        DG.Rows.Clear()
        Dim i As Integer
        Dim str As String = "select dbo.F_getItemDescription(YT.Item_Finished_id,YT.flagsize) as ItemDescription, " & _
                        "U.UnitName,YT.Lotno,YT.Tagno,Round(yt.IssueQty-isnull(VRT.Retqty,0),3) as IssueQty,Round(isnull(YR.ReceivedQty,0),3) As ReceivedQty, " & _
                        "YT.Item_Finished_id, YT.Unitid, YT.flagsize, YM.ID, yt.Detailid, ISNULL(Rectype,'') as RecType,Isnull(YT.ConeType,'') as Conetype, " & _
                        "isnull(Yt.Rate,0) as Rate, isnull(YM.Remarks,'') Remarks, PlyType, TransportType, YT.Moisture " & _
                        "from YarnOpeningIssueMaster YM inner join YarnOpeningIssueTran YT on YM.ID = YT.MasterId " & _
                        "inner join Unit U on YT.Unitid=U.UnitId " & _
                        "left join V_getYarnOpeningReceivedQty YR on Yt.Detailid=YR.issuemasterDetailid and YT.MasterId=YR.issuemasterid " & _
                        "left join V_getYarnOpeningReturnQty VRT on YT.MasterId=VRT.issuemasterid and YT.Detailid=VRT.Issuedetailid " & _
                        "Where YM.Id = " & DDIssueno.SelectedValue & " " & _
                        "Select ConeType, ConeType From ConeMaster Order By SrNo"

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            DG.Rows.Add()
            DG.Item("itemdescription", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("itemdescription")
            DG.Item("Unit", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitname")
            DG.Item("Lotno", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
            DG.Item("Tagno", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Tagno")
            DG.Item("Issuedqty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("issueqty")
            DG.Item("receivedqty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("receivedqty")
            DG.Item("Pqty", DG.Rows.Count - 1).Value = Math.Round(Val(ds.Tables(0).Rows(i)("issueqty")) - Val(ds.Tables(0).Rows(i)("receivedqty")), 3)
            DG.Item("lblitemfinishedid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("item_finished_id")
            DG.Item("lblunitid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitid")
            DG.Item("lblflagsize", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("flagsize")
            DG.Item("lblissuemasterid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("id")
            DG.Item("lblissuemasterDetailid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Detailid")
            DG.Item("lblrate", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rate")
            ''**********Rec Type
            CmbOperator = DirectCast(DG.Rows(i).Cells("rectype"), DataGridViewComboBoxCell)
            CmbOperator.Items.Add("")
            CmbOperator.Items.Add("Cone")
            CmbOperator.Items.Add("Hank")

            If CmbOperator.Items.Contains(ds.Tables(0).Rows(i)("rectype")) Then
                CmbOperator.Value = ds.Tables(0).Rows(i)("rectype")
            End If

            ''***********Cone Type
            CmbOperator = DirectCast(DG.Rows(i).Cells("Conetype"), DataGridViewComboBoxCell)
            For j = 0 To ds.Tables(1).Rows.Count - 1
                CmbOperator.Items.Add(ds.Tables(1).Rows(j)("Conetype"))
            Next

            'CmbOperator.Items.Add("")
            'CmbOperator.Items.Add("Plastic")
            'CmbOperator.Items.Add("Paper")
            'CmbOperator.Items.Add("Bobbin")
            'CmbOperator.Items.Add("Fatte")
            'CmbOperator.Items.Add("Nalki")
            'CmbOperator.Items.Add("Coaning")
            'CmbOperator.Items.Add("Nalki By Hand")
            'CmbOperator.Items.Add("Nalki By Machine")
            'CmbOperator.Items.Add("HANK")
            'CmbOperator.Items.Add("Fatte By Nalki-M")
            'CmbOperator.Items.Add("Macking Dori")

            If CmbOperator.Items.Contains(ds.Tables(0).Rows(i)("conetype")) Then
                CmbOperator.Value = ds.Tables(0).Rows(i)("conetype")
            End If

            CmbOperator = DirectCast(DG.Rows(i).Cells("PlyType"), DataGridViewComboBoxCell)
            CmbOperator.Items.Add("")
            CmbOperator.Items.Add("1 Ply")
            CmbOperator.Items.Add("2 Ply")
            CmbOperator.Items.Add("3 Ply")
            CmbOperator.Items.Add("4 Ply")
            CmbOperator.Items.Add("5 Ply")
            CmbOperator.Items.Add("6 Ply")
            CmbOperator.Items.Add("7 Ply")
            CmbOperator.Items.Add("8 Ply")
            CmbOperator.Items.Add("9 Ply")
            CmbOperator.Items.Add("10 Ply")
            CmbOperator.Items.Add("11 Ply")
            CmbOperator.Items.Add("12 Ply")
            CmbOperator.Items.Add("8-32 Ply")

            If CmbOperator.Items.Contains(ds.Tables(0).Rows(i)("PlyType")) Then
                CmbOperator.Value = ds.Tables(0).Rows(i)("PlyType")
            End If

            CmbOperator = DirectCast(DG.Rows(i).Cells("TransportType"), DataGridViewComboBoxCell)
            CmbOperator.Items.Add("")
            CmbOperator.Items.Add("Self")
            CmbOperator.Items.Add("Company")

            If CmbOperator.Items.Contains(ds.Tables(0).Rows(i)("TransportType")) Then
                CmbOperator.Value = ds.Tables(0).Rows(i)("TransportType")
            End If
            DG.Item("TxtMoisture", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Moisture")
        Next
        If (ds.Tables(0).Rows.Count > 0) Then
            TxtIssueRemarks.Text = ds.Tables(0).Rows(0)("Remarks")
        End If
    End Sub

    Private Sub DDIssueno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDIssueno.SelectedIndexChanged
        If DDIssueno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            reportid = 0
            FillIssueDetail()
        End If
    End Sub
    Dim _serialPort As SerialPort
    Private Delegate Sub SetTextDeleg(text As String)
    Private Sub sp_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            Thread.Sleep(500)
            Dim data As String = _serialPort.ReadExisting()
            Me.BeginInvoke(New SetTextDeleg(AddressOf si_DataReceived), New Object() {data})
        Catch ex As Exception
        End Try
    End Sub
    Private Sub si_DataReceived(data As String)
        Try
            Dim sSplitData As String() = data.Trim().Split(ControlChars.Lf)
            Dim index As Integer = sSplitData.Length / 2
            Dim vValue As String = ""

            If index > 0 Then
                vValue = sSplitData(index)
            End If
            vValue = sSplitData(0)
            sSplitData = vValue.Split("+")

            If sSplitData.Length > 0 Then
                vValue = sSplitData(1)
                sSplitData = vValue.Split(ControlChars.Cr)

                'w_Weight = Convert.ToDouble(sSplitData(0).ToString().Replace(" S", ""))
                If sSplitData(0).Contains("Kgs") = True Then
                    w_Weight = Convert.ToDouble(sSplitData(0).ToString().Replace(" S Kgs", ""))
                Else
                    w_Weight = Convert.ToDouble(sSplitData(0).ToString().Replace(" S", ""))
                End If
                If gridindex >= 0 Then
                    DG.Item(gridcolname, gridindex).Value = w_Weight.ToString()
                End If
                'txtrecqty.Text = w_Weight.ToString()

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()

    Private Sub DG_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
            ''Case "RECQTY", "LOSSQTY"
            Case "LOSSQTY"
                SaveDetail()
                If DG.Rows.Count > 0 Then
                    DG.Item(DG.Columns(e.ColumnIndex).Name, gridindex).Value = ""
                End If
                If _serialPort IsNot Nothing Then
                    _serialPort.Close()
                    _serialPort = Nothing
                End If
        End Select
    End Sub

    Private Sub DG_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEnter
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
            Case "RECQTY"
                gridindex = e.RowIndex
                gridcolname = DG.Columns(e.ColumnIndex).Name
                If cmb_port.Items.Count = 0 Then Exit Sub
                If _serialPort Is Nothing Then
                    _serialPort = New SerialPort(cmb_port.Text.Trim(), 9600, Parity.None, 8, StopBits.One)
                    _serialPort.Handshake = Handshake.None

                    AddHandler _serialPort.DataReceived, AddressOf sp_DataReceived

                    _serialPort.ReadTimeout = 500
                    _serialPort.WriteTimeout = 500
                    Try
                        _serialPort.Open()

                    Catch ex As Exception
                        MsgBox("Please check Serial Port", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Error")
                    End Try
                    Try
                        If Not _serialPort.IsOpen Then
                            _serialPort.Open()
                        End If
                        _serialPort.Write("SI" & vbCr & vbLf)
                    Catch ex As Exception
                        MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!")
                    End Try
                Else
                    If _serialPort.IsOpen Then
                        _serialPort.Close()
                        _serialPort = Nothing
                        ''Return
                    End If
                End If
                DG.Item(DG.Columns(e.ColumnIndex).Name, e.RowIndex).Value = w_Weight
        End Select
    End Sub
    Protected Sub SaveDetail()
        If Validcombobox(DDcompany) = False Then Exit Sub
        If Validcombobox(DDvendor) = False Then Exit Sub
        If Validcombobox(DDIssueno) = False Then Exit Sub
        If Validcombobox(DDemployee) = False Then Exit Sub
        If Validcombobox(DDGodown) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim dtrecords As DataTable = New DataTable()
        dtrecords.Columns.Add("Item_Finished_id", GetType(Integer))
        dtrecords.Columns.Add("Unitid", GetType(Integer))
        dtrecords.Columns.Add("flagsize", GetType(Integer))
        dtrecords.Columns.Add("Godownid", GetType(Integer))
        dtrecords.Columns.Add("Lotno", GetType(String))
        dtrecords.Columns.Add("TagNo", GetType(String))
        dtrecords.Columns.Add("RecQty", GetType(Double))
        dtrecords.Columns.Add("LossQty", GetType(Double))
        dtrecords.Columns.Add("Rectype", GetType(String))
        dtrecords.Columns.Add("Noofcone", GetType(Integer))
        dtrecords.Columns.Add("Conetype", GetType(String))
        dtrecords.Columns.Add("Issuemasterid", GetType(Integer))
        dtrecords.Columns.Add("IssuemasterDetailid", GetType(Integer))
        dtrecords.Columns.Add("Rate", GetType(Double))
        dtrecords.Columns.Add("BinNo", GetType(String))
        dtrecords.Columns.Add("PlyType", GetType(String))
        dtrecords.Columns.Add("TransportType", GetType(String))
        dtrecords.Columns.Add("Moisture", GetType(Double))
        dtrecords.Columns.Add("RecMoisture", GetType(Double))
        dtrecords.Columns.Add("PenalityRate", GetType(Double))
        dtrecords.Columns.Add("PenalityAmt", GetType(Double))
        dtrecords.Columns.Add("BellWt", GetType(Double))

        For i As Integer = 0 To DG.Rows.Count - 1
            Dim Chkboxitem As DataGridViewCheckBoxCell = DirectCast(DG.Rows(i).Cells("chk"), DataGridViewCheckBoxCell)
            Dim txtrecqty As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("Recqty"), DataGridViewTextBoxCell)
            Dim txtlossqty As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("Lossqty"), DataGridViewTextBoxCell)
            Dim txtnoofcone As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("Noofcone"), DataGridViewTextBoxCell)
            Dim DDRecType As DataGridViewComboBoxCell = DirectCast(DG.Rows(i).Cells("Rectype"), DataGridViewComboBoxCell)
            Dim DDconetype As DataGridViewComboBoxCell = DirectCast(DG.Rows(i).Cells("conetype"), DataGridViewComboBoxCell)
            Dim lblrate As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblrate"), DataGridViewTextBoxCell)

            Dim DDPlyType As DataGridViewComboBoxCell = DirectCast(DG.Rows(i).Cells("PlyType"), DataGridViewComboBoxCell)
            Dim DDTransportType As DataGridViewComboBoxCell = DirectCast(DG.Rows(i).Cells("TransportType"), DataGridViewComboBoxCell)

            Dim TxtMoisture As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("TxtMoisture"), DataGridViewTextBoxCell)

            If (Chkboxitem.Value = True And TxtMoisture.Value.ToString() = "" And (VarMasterCompanyID = 16 Or VarMasterCompanyID = 28)) Then
                MsgBox("Please fill Moisture")
                Return
            End If

            Dim TxtRecMoisture As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("TxtRecMoisture"), DataGridViewTextBoxCell)

            Dim Issuedqty As String = DG.Item("Issuedqty", i).Value
            Dim txtPenalityRate As String = DG.Item("PenalityRateKgsdg", i).Value
            Dim txtBellWt As String = DG.Item("TxtBellWt", i).Value

            Dim penalityamt As Double = 0
            penalityamt = Convert.ToDouble(Convert.ToDouble(Issuedqty) * Convert.ToDouble(If(txtPenalityRate = "", "0", txtPenalityRate)))


            If (Chkboxitem.Value = True And TxtRecMoisture.Value = "" And (VarMasterCompanyID = 16 Or VarMasterCompanyID = 28)) Then
                MsgBox("Please fill Rec Moisture")
                Return
            End If

            If Chkboxitem.Value = True And (txtrecqty.Value <> "" Or txtlossqty.Value <> "") And DDGodown.SelectedIndex <> -1 Then
                Dim dr As DataRow = dtrecords.NewRow()
                dr("Item_Finished_id") = DG.Item("lblitemfinishedid", i).Value
                dr("Unitid") = DG.Item("lblunitid", i).Value
                dr("flagsize") = DG.Item("lblflagsize", i).Value
                dr("Godownid") = DDGodown.SelectedValue
                dr("Lotno") = DG.Item("lotno", i).Value
                dr("TagNo") = DG.Item("Tagno", i).Value
                dr("RecQty") = If(txtrecqty.Value = "", "0", txtrecqty.Value)
                dr("LossQty") = If(txtlossqty.Value = "", "0", txtlossqty.Value)
                dr("Rectype") = DDRecType.Value
                dr("Noofcone") = If(txtnoofcone.Value = "", "0", txtnoofcone.Value)
                dr("Conetype") = DDconetype.Value
                dr("Issuemasterid") = DG.Item("lblissuemasterid", i).Value
                dr("IssuemasterDetailid") = DG.Item("lblissuemasterdetailid", i).Value
                dr("Rate") = DG.Item("lblrate", i).Value
                dr("BinNo") = IIf(DDBinNo.Visible = True, DDBinNo.Text, "")
                dr("PlyType") = DDPlyType.Value
                dr("TransportType") = DDTransportType.Value
                dr("Moisture") = IIf(TxtMoisture.Value.ToString() = "", "0", TxtMoisture.Value)
                dr("RecMoisture") = IIf(TxtRecMoisture.Value.ToString() = "", "0", TxtRecMoisture.Value)

                dr("PenalityRate") = Convert.ToDouble(If(txtPenalityRate = "", "0", txtPenalityRate))
                dr("PenalityAmt") = penalityamt
                dr("BellWt") = Convert.ToDouble(If(txtBellWt = "", "0", txtBellWt))

                dtrecords.Rows.Add(dr)
            End If
        Next

        If dtrecords.Rows.Count > 0 Then
            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim param As SqlParameter() = New SqlParameter(12) {}
                param(0) = New SqlParameter("@id", SqlDbType.Int)
                param(0).Direction = ParameterDirection.InputOutput
                param(0).Value = Val(reportid)
                param(1) = New SqlParameter("@dtrecords", dtrecords)
                param(2) = New SqlParameter("@companyId", DDcompany.SelectedValue)
                param(3) = New SqlParameter("@vendorid", DDvendor.SelectedValue)
                param(4) = New SqlParameter("@receiveNo", txtreceiveNo.Text)
                param(5) = New SqlParameter("@RecDate", txtRecdate.Text)
                param(6) = New SqlParameter("@Issuemasterid", DDIssueno.SelectedValue)
                param(7) = New SqlParameter("@userid", varuserid)
                param(8) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(8).Direction = ParameterDirection.Output
                param(9) = New SqlParameter("@Empid", DDemployee.SelectedValue)
                param(10) = New SqlParameter("@BinNO", IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))
                param(11) = New SqlParameter("@PartyChallanNo", TxtPartyChallanNo.Text)

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_SaveYarnReceive", param)
                reportid = param(0).Value.ToString()
                MsgBox(param(8).Value.ToString())
                Tran.Commit()
                FillIssueDetail()
                FillReceiveDetails()
            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message)

            End Try
        Else
            MsgBox("Please select atleast one check box to save data.")
        End If
    End Sub
    Protected Sub FillReceiveDetails()
        DGrecdetail.Rows.Clear()
        Dim str As String = "select YM.ReceiveNo,dbo.F_getItemDescription(YT.Item_Finished_id,YT.flagsize) as ItemDescription," & _
        "U.UnitName, Gm.GodownName, YT.Lotno, YT.Tagno, yt.ReceiveQty, Yt.LossQty, YM.ID, yt.Detailid, YT.issuemasterid, YT.issuemasterDetailid, yt.rectype, yt.noofcone, yt.Conetype " & _
        "from YarnOpeningreceiveMaster YM inner join YarnOpeningReceiveTran YT on " & _
        "YM.ID = YT.MasterId " & _
        "inner join Unit U on YT.Unitid=U.UnitId " & _
        "inner join GodownMaster GM on YT.GodownId=Gm.GoDownID Where YM.id=" & reportid

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            DGrecdetail.Rows.Add()
            DGrecdetail.Item("ReceiveNo", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ReceiveNo")
            DGrecdetail.Item("Ritemdescription", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Itemdescription")
            DGrecdetail.Item("RUnit", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Unitname")
            DGrecdetail.Item("Rgodown", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("godownname")
            DGrecdetail.Item("Rlotno", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
            DGrecdetail.Item("Rtagno", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Tagno")
            DGrecdetail.Item("RRecqty", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Receiveqty")
            DGrecdetail.Item("RLossqty", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lossqty")
            DGrecdetail.Item("lblid", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("id")
            DGrecdetail.Item("lblDetailid", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Detailid")
            DGrecdetail.Item("Rlblissuemasterid", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("issuemasterid")
            DGrecdetail.Item("Rlblissuemasterdetailid", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("issuemasterDetailid")
            DGrecdetail.Item("Rrectype", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rectype")
            DGrecdetail.Item("Rnoofcone", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Noofcone")
            DGrecdetail.Item("Rconetype", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Conetype")

        Next

    End Sub

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = "select  * from [V_yarnOpeningReceive] Where id=" & reportid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            Select Case VarMasterCompanyID
                Case "14"
                    sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptyarnopeningReceive.rpt")
                Case Else
                    sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptyarnopeningReceivewithrate.rpt")
            End Select
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\rptyarnopeningReceive.xsd")
            Objfile.Load(sReportName)
            ''Objfile.SetDatabaseLogon("sa", "eit")
            ds.WriteXmlSchema(dspath)
            ObjFolio.CR1.RefreshReport()
            Objfile.SetDataSource(ds)
            Objfile.Refresh()
            ObjFolio.CR1.ReportSource = Objfile
            Objfile.RecordSelectionFormula = VarSelectionFormula
            ObjFolio.CR1.Show()
            ObjFolio.Show()
        Else
            MsgBox("No records founds....")
        End If

    End Sub

    Private Sub DGrecdetail_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DGrecdetail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub

            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim masterid As String = DGrecdetail.Item("lblid", DGrecdetail.CurrentRow.Index).Value
                Dim Detailid As String = DGrecdetail.Item("lbldetailid", DGrecdetail.CurrentRow.Index).Value

                Dim param(5) As SqlParameter
                param(0) = New SqlParameter("@Id", masterid)
                param(1) = New SqlParameter("@Detailid", Detailid)
                param(2) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(2).Direction = ParameterDirection.Output
                param(3) = New SqlParameter("@userid", varuserid)
                param(4) = New SqlParameter("@mastercompanyid", VarMasterCompanyID)
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_DeleteYarnOpeningReceive", param)
                Tran.Commit()
                MsgBox(param(2).Value.ToString())
                FillReceiveDetails()
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        End If
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        DDvendor.SelectedIndex = -1
        DDIssueno.SelectedIndex = -1
        txtreceiveNo.Text = ""
        txtRecdate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy")
        reportid = 0
    End Sub

    Private Sub txtWeaverIdNoscan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtWeaverIdNoscan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim str As String = "select Empid From EmpInfo EI inner join Department Dp on EI.Departmentid=DP.departmentid " & _
                       "and Dp.Departmentname='Yarn Opening' Where EmpCode='" & txtWeaverIdNoscan.Text & "'"

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

            If ds.Tables(0).Rows.Count > 0 Then

                DDvendor.SelectedValue = ds.Tables(0).Rows(0)("empid").ToString()
                DDvendor_SelectedIndexChanged(sender, New EventArgs())
                DDIssueno.Focus()
                If VarMasterCompanyID = "16" Then
                    DDemployee.SelectedValue = ds.Tables(0).Rows(0)("empid").ToString()
                End If
                txtWeaverIdNoscan.Text = ""
                DDIssueno.Focus()
            Else
                MsgBox("Employee Code does not exists in this Department.")
                txtWeaverIdNoscan.Focus()
            End If
        End If
    End Sub

    Private Sub chkprintbarcode_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkprintbarcode.CheckedChanged
        If chkprintbarcode.Checked = True Then
            ''**************************************
            Dim ps As New PrinterSettings()
            varPrinterName = ps.PrinterName
            ''Fill printer
            Barcodetype = 3
            Call NewComboFill(cmbprintername, "select ID,Displayname + case when Printername<>DisplayName Then ' # ' + Printername Else '' End  From Barcodeprinter where barcodetype=" & Barcodetype & " order by id")
            Dim Index As Integer
            Index = cmbprintername.FindString(varPrinterName)
            If Index < 0 Then
                MsgBox("Default Printer is not available.Please contact Service Provider", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")
            Else
                cmbprintername.SelectedIndex = Index
                cmbprintername_SelectedIndexChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub cmbprintername_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbprintername.SelectedIndexChanged
        prn = ""
        Printside = 1
        If cmbprintername.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, "select prn,PrintSide From Barcodeprinter Where ID=" & cmbprintername.SelectedValue & "")
            If ds.Tables(0).Rows.Count > 0 Then
                prn = ds.Tables(0).Rows(0)("prn")
                Printside = ds.Tables(0).Rows(0)("printside")
            End If
        End If
    End Sub
    Protected Sub PrintBarcode()
        Dim Nextquality As String
        Dim Nextlotno As String
        Dim NextTagno As String
        Dim Nextshadeno As String
        Dim NextConeNo As String

        Dim quality As String
        Dim lotno As String
        Dim Tagno As String
        Dim shadeno As String
        Dim ConeNo As String


        Dim str As String = "SELECT VF.QUALITYNAME,VF.SHADECOLORNAME,YT.LOTNO,YT.TAGNO,YT.DETAILID,Isnull(YT.Noofcone,0) as Noofcone " & _
                            "FROM YARNOPENINGRECEIVETRAN YT INNER JOIN V_FINISHEDITEMDETAIL VF ON YT.ITEM_FINISHED_ID=VF.ITEM_FINISHED_ID " & _
                            "WHERE MASTERID=" & reportid & "  ORDER BY DETAILID"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            If prn = "" Then
                MsgBox("Prn File is not available.Please contact service Provider", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")
                Exit Sub
            End If
            '**************
            Dim chkcount As Integer = 0
            Dim i, J, rowscount As Integer
            Dim Nextrowinsert As Boolean = False

            Dim TempFileTextLine As String = ""

            If varPrinterName = "" Then
                MsgBox("Printer Name can not be blank.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")
                Exit Sub
            End If


            For k As Integer = 0 To ds.Tables(0).Rows.Count - 1

                rowscount = ds.Tables(0).Rows(k)("Noofcone")
                If rowscount = 0 Then rowscount = 1
                If Nextrowinsert = True Then rowscount = rowscount - 1
                For i = 0 To rowscount - 1
                    quality = ""
                    lotno = ""
                    Tagno = ""
                    shadeno = ""
                    ConeNo = ""

                    Nextquality = ""
                    Nextlotno = ""
                    NextTagno = ""
                    Nextshadeno = ""
                    NextConeNo = ""
                    TempFileTextLine = ""

                    J = i + 1
                    If J < rowscount Then
                        Nextquality = ds.Tables(0).Rows(k)("Qualityname")
                        Nextlotno = ds.Tables(0).Rows(k)("Lotno")
                        NextTagno = ds.Tables(0).Rows(k)("TagNo")
                        Nextshadeno = ds.Tables(0).Rows(k)("Shadecolorname")
                        NextConeNo = ds.Tables(0).Rows(k)("Detailid")
                    Else
                        If k < (ds.Tables(0).Rows.Count - 1) Then
                            Nextquality = ds.Tables(0).Rows(k + 1)("Qualityname")
                            Nextlotno = ds.Tables(0).Rows(k + 1)("Lotno")
                            NextTagno = ds.Tables(0).Rows(k + 1)("TagNo")
                            Nextshadeno = ds.Tables(0).Rows(k + 1)("Shadecolorname")
                            NextConeNo = ds.Tables(0).Rows(k + 1)("Detailid")
                            Nextrowinsert = True
                        End If

                    End If
                    quality = ds.Tables(0).Rows(k)("Qualityname")
                    lotno = ds.Tables(0).Rows(k)("Lotno")
                    Tagno = ds.Tables(0).Rows(k)("Tagno")
                    shadeno = ds.Tables(0).Rows(k)("Shadecolorname")
                    ConeNo = ds.Tables(0).Rows(k)("Detailid")

                    TempFileTextLine = String.Format(prn, "" & ConeNo & "", "" & NextConeNo & "", "" & quality & "", "" & Nextquality & "", "" & shadeno & "", "" & Nextshadeno & "", "" & lotno & "", "" & Nextlotno & "", "" & Tagno & "", "" & NextTagno & "")

                    i = i + 1
                    RawPrinterHelper.SendStringToPrinter(varPrinterName, TempFileTextLine)

                Next

            Next



        Else
            MsgBox("No records found to print")
        End If

    End Sub
    Private Sub btnprintbarcode_Click(sender As System.Object, e As System.EventArgs) Handles btnprintbarcode.Click
        PrintBarcode()
    End Sub
    Private Sub frmyarnopeningreceive_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub
    Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGodown.SelectedIndexChanged
        If DDGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If DDBinNo.Visible = True Then
                If VarCHECKBINCONDITION = 1 Then
                    Module1.FillBinNO(DDBinNo, DDGodown.SelectedValue, Item_finished_id:=0, New_Edit:=0)
                Else
                    NewComboFill(DDBinNo, "SELECT DISTINCT BINNO,BINNO AS BINNO1 FROM STOCK S WHERE GODOWNID=" & DDGodown.SelectedValue & "  ORDER BY BINNO1")
                End If

            End If
        End If
    End Sub

    Private Sub BtnComplete_Click(sender As System.Object, e As System.EventArgs) Handles BtnComplete.Click
        If Validcombobox(DDcompany) = False Then Exit Sub
        If Validcombobox(DDvendor) = False Then Exit Sub
        If Validcombobox(DDIssueno) = False Then Exit Sub

        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim param(5) As SqlParameter
            param(0) = New SqlParameter("@CompanyId", DDcompany.SelectedValue)
            param(1) = New SqlParameter("IssueNo", DDIssueno.SelectedValue)
            param(2) = New SqlParameter("@UserID", varuserid)
            param(3) = New SqlParameter("@MasterCompanyID", VarMasterCompanyID)
            param(4) = New SqlParameter("@Msg", SqlDbType.VarChar, 100)
            param(4).Direction = ParameterDirection.Output

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "[Pro_YarnOpeningStatusUpdate]", param)
            If param(4).Value.ToString = "" Then
                Tran.Commit()
                MsgBox("Data saved successfully..")
                FillIssueno()
            Else
                Tran.Rollback()
                MsgBox(param(4).Value.ToString())
            End If
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
