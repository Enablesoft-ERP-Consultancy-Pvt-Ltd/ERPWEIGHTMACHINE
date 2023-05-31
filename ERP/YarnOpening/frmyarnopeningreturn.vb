Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class frmyarnopeningreturn
    Dim gridindex As Integer = 0
    Dim gridcolname As String = ""
    Dim reportid As Integer = "0"
    Private Sub frmyarnopeningreturn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If

        Dim str As String = "select CompanyId,CompanyName from companyinfo Where mastercompanyId=" & VarMasterCompanyID & " order by Companyname " & _
                            "select EI.EmpId,EI.EmpName+case when isnull(EI.empcode,'')<>'' Then ' ['+EI.empcode+']' Else '' End Empname from empinfo EI inner join Department D " & _
                            "on EI.departmentId=D.DepartmentId Where D.DepartmentName='Yarn Opening'"
        If VarMasterCompanyID = "14" Then
            str = str & " and EI.EmpName in('Yarn Opening','YARN OPENING-2')"
        End If
        str = str & "  order by EmpName"
        str = str + " select Godownid,Godownname From GodownMaster"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        NewComboFillWithDs(DDcompany, ds, 0)
        If DDcompany.Items.Count > 0 Then
            DDcompany.SelectedValue = VarCompanyID
            DDcompany.Enabled = False
        End If

        NewComboFillWithDs(DDvendor, ds, 1)
        NewComboFillWithDs(DDGodown, ds, 2)
        If DDGodown.Items.Count > 0 Then DDGodown.SelectedIndex = 0
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If
        DDGodown_SelectedIndexChanged(sender, New EventArgs())


    End Sub

    Private Sub DDvendor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDvendor.SelectedIndexChanged
        reportid = "0"
        FillIssueno()
    End Sub

    Protected Sub FillIssueno()
        If DDvendor.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            Dim str As String = "select  Distinct YM.Id,YM.Issueno+'/'+REPLACE(CONVERT(nvarchar(11),YM.Issuedate,106),' ','-') from YarnOpeningIssueMaster YM  inner join YarnOpeningIssueTran YT on YM.ID=YT.MasterId Where Ym.companyId=" & DDcompany.SelectedValue & " and ym.vendorId=" & DDvendor.SelectedValue & " and ym.Status='Pending'"
            If txtLotno.Text <> "" Then
                str = str & " and yt.Lotno='" & txtLotno.Text & "'"
            End If

            str = str & " order by ym.id desc"
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            NewComboFill(DDIssueno, str)
        End If

    End Sub

    Private Sub txtLotno_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLotno.KeyDown
        If e.KeyCode = Keys.Enter Then
            FillIssueno()
        End If
    End Sub

    Private Sub txtWeaverIdNoscan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtWeaverIdNoscan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim str As String = "select Empid From EmpInfo EI inner join Department Dp on EI.Departmentid=DP.departmentid " & _
                       "and Dp.Departmentname='Yarn Opening' Where EmpCode='" & txtWeaverIdNoscan.Text & "'"

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                DDvendor.SelectedValue = ds.Tables(0).Rows(0)("empid").ToString()
                DDvendor_SelectedIndexChanged(sender, New EventArgs())
                txtWeaverIdNoscan.Text = ""

            Else
                MsgBox("Employee Code does not exists in this Department.")
                txtWeaverIdNoscan.Focus()
            End If
        End If
    End Sub
    Protected Sub FillIssueDetail()
        DG.Rows.Clear()
        If DDIssueno.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            Dim str As String = "select dbo.F_getItemDescription(YT.Item_Finished_id,YT.flagsize) as ItemDescription," & _
                            "U.UnitName,YT.Lotno,YT.Tagno,Round(yt.IssueQty-isnull(YRQ.retqty,0),3) as IssueQty,Round(isnull(YR.ReceivedQty,0),3) As ReceivedQty,YT.Item_Finished_id,YT.Unitid,YT.flagsize,YM.ID,yt.Detailid " & _
                            "from YarnOpeningIssueMaster YM inner join YarnOpeningIssueTran YT on  " & _
                            "YM.ID = YT.MasterId " & _
                            "inner join Unit U on YT.Unitid=U.UnitId " & _
                            "left join V_getYarnOpeningReceivedQty YR on Yt.Detailid=YR.issuemasterDetailid and YT.MasterId=YR.issuemasterid " & _
                            "left join V_getYarnOpeningReturnQty YRQ on YT.Detailid=YRQ.Issuedetailid and YT.MasterId=YRQ.issuemasterid Where YM.Id=" & DDIssueno.SelectedValue

            Dim ds1 As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            ds1.Tables(0).DefaultView.RowFilter = "(Issueqty-ReceivedQty)>0"
            Dim dv As DataView = ds1.Tables(0).DefaultView
            Dim ds As DataSet = New DataSet()
            ds.Tables.Add(dv.ToTable())
            Dim Pqty As Decimal
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    DG.Rows.Add()
                    DG.Item("itemdescription", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Itemdescription")
                    DG.Item("Unit", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Unitname")
                    DG.Item("Lotno", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
                    DG.Item("TagNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Tagno")
                    DG.Item("issuedqty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("issueqty")
                    DG.Item("Receivedqty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Receivedqty")
                    Pqty = Convert.ToDecimal(ds.Tables(0).Rows(i)("issueqty")) - Convert.ToDecimal(ds.Tables(0).Rows(i)("Receivedqty"))
                    DG.Item("Pqty", DG.Rows.Count - 1).Value = Pqty
                    DG.Item("lblissuemasterid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ID")
                    DG.Item("lblitemfinishedid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_Finished_id")
                    DG.Item("lblunitid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitid")
                    DG.Item("lblflagsize", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("flagsize")
                    DG.Item("lblissuemasterdetailid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Detailid")


                Next

            End If

        End If

    End Sub

    Private Sub DDIssueno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDIssueno.SelectedIndexChanged

        FillIssueDetail()
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
            Case "RETQTYENTER"
                SaveDetail()

                If _serialPort IsNot Nothing Then
                    _serialPort.Close()
                    _serialPort = Nothing
                End If
        End Select
    End Sub
    Private Sub SaveDetail(Optional ByVal sender As Object = Nothing)
        If Validcombobox(DDcompany) = False Then Exit Sub
        If Validcombobox(DDvendor) = False Then Exit Sub
        If Validcombobox(DDIssueno) = False Then Exit Sub
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
        dtrecords.Columns.Add("RetQty", GetType(Double))
        dtrecords.Columns.Add("Issuemasterid", GetType(Integer))
        dtrecords.Columns.Add("IssuemasterDetailid", GetType(Integer))

        For i As Integer = 0 To DG.Rows.Count - 1
            Dim txtretqty As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("Retqty"), DataGridViewTextBoxCell)
            If txtretqty.Value <> "" Then
                Dim lblitemfinishedid As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblitemfinishedid"), DataGridViewTextBoxCell)
                Dim lblunitid As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblunitid"), DataGridViewTextBoxCell)
                Dim lblflagsize As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblflagsize"), DataGridViewTextBoxCell)
                Dim lblLotno As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("Lotno"), DataGridViewTextBoxCell)
                Dim lblTagno As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("Tagno"), DataGridViewTextBoxCell)
                Dim lblissuemasterid As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblissuemasterid"), DataGridViewTextBoxCell)
                Dim lblissuemasterdetailid As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblissuemasterdetailid"), DataGridViewTextBoxCell)
                Dim dr As DataRow = dtrecords.NewRow()
                dr("Item_Finished_id") = lblitemfinishedid.Value
                dr("Unitid") = lblunitid.Value
                dr("flagsize") = lblflagsize.Value
                dr("Godownid") = DDGodown.SelectedValue
                dr("Lotno") = lblLotno.Value
                dr("TagNo") = lblTagno.Value
                dr("RetQty") = If(txtretqty.Value = "", "0", txtretqty.Value)
                dr("Issuemasterid") = lblissuemasterid.Value
                dr("IssuemasterDetailid") = lblissuemasterdetailid.Value
                dtrecords.Rows.Add(dr)
            End If
        Next

        If dtrecords.Rows.Count > 0 Then
            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim param As SqlParameter() = New SqlParameter(11) {}
                param(0) = New SqlParameter("@id", SqlDbType.Int)
                param(0).Direction = ParameterDirection.InputOutput
                param(0).Value = reportid
                param(1) = New SqlParameter("@dtrecords", dtrecords)
                param(2) = New SqlParameter("@companyId", DDcompany.SelectedValue)
                param(3) = New SqlParameter("@vendorid", DDvendor.SelectedValue)
                param(4) = New SqlParameter("@returnNo", SqlDbType.VarChar, 100)
                param(4).Direction = ParameterDirection.Output
                param(5) = New SqlParameter("@RetDate", txtretdate.Text)
                param(6) = New SqlParameter("@userid", varuserid)
                param(7) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(7).Direction = ParameterDirection.Output
                param(8) = New SqlParameter("@mastercompanyid", VarMasterCompanyID)
                param(9) = New SqlParameter("@issuemasterid", DDIssueno.SelectedValue)
                param(10) = New SqlParameter("@BinNo", IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_yarnopeningReturn", param)
                reportid = param(0).Value.ToString()
                MsgBox(param(7).Value.ToString())
                txtretNo.Text = param(4).Value.ToString()
                Tran.Commit()
                FillIssueDetail()
                FillReturnDetails()
            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message)

            End Try
        Else
            MsgBox("Please select atleast one check box to save data.")
        End If
    End Sub

    Private Sub DG_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEnter
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
            Case "RETQTY"
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

    Protected Sub FillReturnDetails()
        DGReturnedDetail.Rows.Clear()
        Dim str As String = "select YM.ReturnNo,dbo.F_getItemDescription(YT.Item_Finished_id,YT.flagsize) as ItemDescription," & _
                        "U.UnitName,Gm.GodownName,YT.Lotno,YT.Tagno,yt.Retqty as Returnqty,YT.Masterid,YT.Detailid " & _
                        "from YarnOpeningReturnMaster YM inner join YarnOpeningReturnDetail YT on " & _
                        "YM.ID = YT.MasterId " & _
                        "inner join Unit U on YT.Unitid=U.UnitId " & _
                        "inner join GodownMaster GM on YT.GodownId=Gm.GoDownID Where YM.id=" & reportid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DGReturnedDetail.Rows.Add()
                DGReturnedDetail.Item("Returnno", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ReturnNo")
                DGReturnedDetail.Item("ItemdescriptionR", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ItemDescription")
                DGReturnedDetail.Item("UnitR", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Unitname")
                DGReturnedDetail.Item("GodownR", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Godownname")
                DGReturnedDetail.Item("LotnoR", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
                DGReturnedDetail.Item("TagnoR", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Tagno")
                DGReturnedDetail.Item("RetqtyR", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ReturnQty")
                DGReturnedDetail.Item("Masterid", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Masterid")
                DGReturnedDetail.Item("Detailid", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Detailid")

            Next

        End If

    End Sub

    Private Sub DDcompany_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDcompany.SelectedIndexChanged
        reportid = 0
    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        reportid = 0
        DDvendor.SelectedIndex = -1
        DDIssueno.SelectedIndex = -1
        txtretNo.Text = ""
        txtretdate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy")
        DG.Rows.Clear()
        DGReturnedDetail.Rows.Clear()
    End Sub

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub
    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = "select  * from [V_yarnopeningReturn] Where id=" & reportid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String

            sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptyarnopeningReturn.rpt")

            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\rptyarnopeningReturn.xsd")
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

    Private Sub DGReturnedDetail_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DGReturnedDetail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do You want to delete this row?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If
            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim arr(5) As SqlParameter
                arr(0) = New SqlParameter("@Masterid", DGReturnedDetail("Masterid", DGReturnedDetail.CurrentRow.Index).Value)
                arr(1) = New SqlParameter("@Detailid", DGReturnedDetail("Detailid", DGReturnedDetail.CurrentRow.Index).Value)
                arr(2) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                arr(2).Direction = ParameterDirection.Output
                arr(3) = New SqlParameter("@userid", varuserid)
                arr(4) = New SqlParameter("@MastercompanyId", VarMasterCompanyID)

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_DELETEYARNOPENINGRETURN", arr)
                Tran.Commit()
                MsgBox(arr(2).Value.ToString())
                FillReturnDetails()
            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub frmyarnopeningreturn_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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
End Class