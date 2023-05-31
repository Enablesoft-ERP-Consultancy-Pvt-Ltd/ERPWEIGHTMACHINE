Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class frmmottelingreceive
    Dim hnid As Integer = 0
    Dim gridindex As Integer = 0
    Dim gridcolname As String = ""
    Dim CmbOperator As DataGridViewComboBoxCell
    Private Sub frmsampledyeingmaterialreceive_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select Distinct CI.CompanyId,CI.CompanyName from Companyinfo CI,Company_Authentication CA Where CI.CompanyId=CA.CompanyId And CA.UserId=" & varuserid & "  And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By CompanyName " & _
                           "select PROCESS_NAME_ID,Process_name From process_name_master  where Processtype=0 and Process_name in('Motteling','YARN OPENING+MOTTELING', 'HANK MAKING') and mastercompanyid=" & VarMasterCompanyID & " order by PROCESS_NAME " & _
                           "select Godownid,Godownname From Godownmaster order by Godownname"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        NewComboFillWithDs(DDCompanyName, ds, 0)
        If DDCompanyName.Items.Count > 0 Then
            DDCompanyName.SelectedValue = VarCompanyID
            DDCompanyName.Enabled = False
        End If
        NewComboFillWithDs(DDProcessName, ds, 1)
        If DDProcessName.Items.Count > 0 Then DDProcessName.SelectedIndex = 0
        NewComboFillWithDs(DDgodown, ds, 2)
        If DDgodown.Items.Count > 0 Then DDgodown.SelectedIndex = 0
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If

    End Sub
    Private Sub DDProcessName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDProcessName.SelectedIndexChanged
        If DDProcessName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            hnid = "0"
            txtchallanNo.Text = ""
            NewComboFill(DDPartyName, "Select EI.EmpId,EI.EmpName + case when isnull(Ei.empcode,'')<>'' Then ' ['+EI.empcode+']' else '' end  as empname  From EmpInfo EI inner join EmpProcess EP on EI.EmpId=EP.EmpId and EP.ProcessId=" & DDProcessName.SelectedValue & " order by empname")

        End If
    End Sub

    Private Sub DDPartyName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDPartyName.SelectedIndexChanged
        If DDCompanyName.SelectedIndex <> -1 And DDProcessName.SelectedIndex <> -1 And DDPartyName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            hnid = "0"
            txtgateinno.Text = ""
            txtchallanNo.Text = ""
            FillIndentNo()
            DGrecdetail.Rows.Clear()
        End If
    End Sub
    Protected Sub FillIndentNo()
        Dim str As String = "select ID,IssueNo from Mottelingissuemaster Where companyid=" & DDCompanyName.SelectedValue & " and processid=" & DDProcessName.SelectedValue & " and empid=" & DDPartyName.SelectedValue
        'If chkcomplete.Checked = True Then
        '    str = str & " and Status='Complete'"
        'Else
        '    str = str & " and Status='Pending'"
        'End If
        str = str & " and Status='Pending'"
        str = str & " order by ID desc"
        NewComboFill(DDissueno, str)
    End Sub

    Protected Sub FillGridReceive()
        DG.Rows.Clear()

        If DDissueno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim i As Integer
            Dim str As String = "Select dbo.F_getItemDescription(MD.Rfinishedid,MD.Rflagsize) as RItemdescription," & _
                        " MD.unitid,dbo.F_GETMOTTELINGRECLOTNO(MM.id,MD.Rfinishedid,MD.unitid) as Lotno," & _
                        " dbo.F_GETMOTTELINGRECTAGNO(MM.id,MD.Rfinishedid,MD.unitid) as TAGNO,isnull(SUM(MD.issueqty-isnull(vr.retqty,0)),0) as Issuedqty," & _
                        " isnull(DBO.F_GETMOTTELINGRECDQTY(MM.ID,MD.RFINISHEDID,MD.Unitid, " & DDProcessName.SelectedValue & ", MD.CONETYPE, MD.PlyType, MD.TransportType, MD.Moisture),0) as Receivedqty,MD.Rate,MM.ID as Issueid," & _
                        " 0 as IssueDetailid,MD.Rfinishedid,MD.Rflagsize,md.Conetype,vf.item_id,vf.qualityid,vf.shadecolorid, MM.Remark, MD.PlyType, MD.TransportType, MD.Moisture " & _
                        " From Mottelingissuemaster MM " & _
                        " inner join MOTTELINGISSUEDETAIL MD on MM.ID=MD.masterid " & _
                        " LEFT JOIN V_GETMOTTELINGRETURNQTY VR ON MD.DETAILID=VR.ISSUEDETAILID" & _
                        " inner join V_finisheditemdetail vf on MD.Rfinishedid=vf.item_finished_id " & _
                        " Where MM.ID = " & DDissueno.SelectedValue & " " & _
                        " group by MM.ID,MD.Rfinishedid,MD.Rflagsize, md.Conetype,MD.unitid,MD.Rate,vf.item_id,vf.qualityid,vf.shadecolorid, MM.Remark, MD.PlyType, MD.TransportType, MD.Moisture" & _
                        " Select ConeType, ConeType From ConeMaster Order By SrNo"

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    DG.Rows.Add()
                    DG.Item("Rdescriptiondg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Ritemdescription")
                    DG.Item("Reclotnodg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
                    DG.Item("Rectagnodg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Tagno")
                    DG.Item("issdqtydg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Issuedqty")
                    DG.Item("Recdqtydg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Receivedqty")
                    DG.Item("Ratedg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("rate")
                    DG.Item("lblissueiddg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Issueid")
                    DG.Item("lblissuedetailiddg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Issuedetailid")
                    DG.Item("lblrfinishediddg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rfinishedid")
                    DG.Item("lblrflagsizedg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rflagsize")
                    DG.Item("lblunitiddg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitid")
                    DG.Item("lblritemid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_id")
                    DG.Item("lblrqualityid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qualityid")
                    DG.Item("lblrshadecolorid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Shadecolorid")
                    DG.Item("Balqty", DG.Rows.Count - 1).Value = Math.Round(Val(ds.Tables(0).Rows(i)("Issuedqty")) - Val(ds.Tables(0).Rows(i)("Receivedqty")), 3)

                    CmbOperator = DirectCast(DG.Rows(i).Cells("cmbconetype"), DataGridViewComboBoxCell)
                    Varcombovalue = 0
                    CmbOperator.DataSource = ds.Tables(1)
                    CmbOperator.ValueMember = ds.Tables(1).Columns(0).ColumnName
                    CmbOperator.DisplayMember = ds.Tables(1).Columns(1).ColumnName
                    Varcombovalue = 1
                    CmbOperator.Value = ds.Tables(0).Rows(i)("conetype")

                    CmbOperator = DirectCast(DG.Rows(i).Cells("CmbPlyType"), DataGridViewComboBoxCell)
                    CmbOperator.Value = ds.Tables(0).Rows(i)("PlyType")

                    CmbOperator = DirectCast(DG.Rows(i).Cells("CmbTransportType"), DataGridViewComboBoxCell)
                    CmbOperator.Value = ds.Tables(0).Rows(i)("TransportType")
                    DG.Item("TxtMoisture", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Moisture")
                Next
            End If
            If ds.Tables(0).Rows.Count > 0 Then
                TxtIssueRemarks.Text = ds.Tables(0).Rows(0)("Remark")
            End If
        End If
    End Sub

    Private Sub DDindentNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDissueno.SelectedIndexChanged
        hnid = 0
        FillGridReceive()
    End Sub
    Protected Sub SaveDetail()
        If Validcombobox(DDCompanyName) = False Then Exit Sub
        If Validcombobox(DDProcessName) = False Then Exit Sub
        If Validcombobox(DDPartyName) = False Then Exit Sub
        If Validcombobox(DDissueno) = False Then Exit Sub
        If Validtxtbox(txtchallanNo) = False Then Exit Sub
        If Validcombobox(DDgodown) = False Then Exit Sub

        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        Dim dtrecord As DataTable = New DataTable()
        dtrecord.Columns.Add("Rfinishedid", GetType(Integer))
        dtrecord.Columns.Add("godownid", GetType(Integer))
        dtrecord.Columns.Add("lotno", GetType(String))
        dtrecord.Columns.Add("Tagno", GetType(String))
        dtrecord.Columns.Add("Rate", GetType(Single))
        dtrecord.Columns.Add("Recqty", GetType(Single))
        dtrecord.Columns.Add("Lossqty", GetType(Single))
        dtrecord.Columns.Add("issuedetailid", GetType(Integer))
        dtrecord.Columns.Add("unitid", GetType(Integer))
        dtrecord.Columns.Add("Rflagsize", GetType(Integer))
        dtrecord.Columns.Add("Undyedqty", GetType(Single))
        dtrecord.Columns.Add("Ifinishedid", GetType(Integer))
        dtrecord.Columns.Add("Conetype", GetType(String))
        dtrecord.Columns.Add("Noofcone", GetType(Integer))
        dtrecord.Columns.Add("Penalityamt", GetType(Decimal))
        dtrecord.Columns.Add("Penalityrate", GetType(Decimal))
        dtrecord.Columns.Add("PlyType", GetType(String))
        dtrecord.Columns.Add("TransportType", GetType(String))
        dtrecord.Columns.Add("Moisture", GetType(String))
        dtrecord.Columns.Add("RecMoisture", GetType(String))
        dtrecord.Columns.Add("BellWt", GetType(Decimal))

        For i As Integer = 0 To DG.Rows.Count - 1
            Dim lblrfinishedid As String = DG.Item("lblrfinishediddg", i).Value
            Dim lblrlotno As String = DG.Item("reclotnodg", i).Value
            Dim lblrtagno As String = DG.Item("rectagnodg", i).Value
            Dim lblrate As String = DG.Item("Ratedg", i).Value
            Dim txtrecqty As String = DG.Item("recqtydg", i).Value
            Dim txtlossqty As String = DG.Item("lossqtydg", i).Value
            Dim lblissuedetailid As String = DG.Item("lblissuedetailiddg", i).Value
            Dim lblunitid As String = DG.Item("lblunitiddg", i).Value
            Dim lblrflagsize As String = DG.Item("lblrflagsizedg", i).Value
            Dim Conetype As String = DG.Item("cmbconetype", i).Value
            Dim Noofcone As Integer = Val(DG.Item("Noofcone", i).Value)
            Dim lblissqty As String = DG.Item("Issdqtydg", i).Value
            Dim txtPenalityRate As String = DG.Item("PenalityRateKgsdg", i).Value

            Dim PlyType As String = DG.Item("CmbPlyType", i).Value
            Dim TransportType As String = DG.Item("CmbTransportType", i).Value

            Dim penalityamt As Double = 0
            penalityamt = Convert.ToDouble(Convert.ToDouble(lblissqty) * Convert.ToDouble(If(txtPenalityRate = "", "0", txtPenalityRate)))

            Dim TxtMoisture As String = DG.Item("TxtMoisture", i).Value
            Dim TxtRecMoisture As String = DG.Item("TxtRecMoisture", i).Value

            Dim Moisture As Double = Convert.ToDouble(If(TxtMoisture = "", "0", TxtMoisture))
            Dim RecMoisture As Double = Convert.ToDouble(If(TxtRecMoisture = "", "0", TxtRecMoisture))

            Dim TxtBellWt As String = DG.Item("TxtBellWt", i).Value
            Dim BellWt As Double = Convert.ToDouble(If(TxtBellWt = "", "0", TxtBellWt))

            If DDgodown.SelectedIndex >= 0 AndAlso (Convert.ToDouble(If(txtrecqty = "", "0", txtrecqty)) > 0 OrElse Convert.ToDouble(If(txtlossqty = "", "0", txtlossqty)) > 0) Then
                Dim dr As DataRow = dtrecord.NewRow()
                dr("Rfinishedid") = lblrfinishedid
                dr("godownid") = DDgodown.SelectedValue
                dr("Lotno") = lblrlotno
                dr("TagNo") = lblrtagno
                dr("Rate") = If(lblrate = "", "0", lblrate)
                dr("Recqty") = If(txtrecqty = "", "0", txtrecqty)
                dr("Lossqty") = If(txtlossqty = "", "0", txtlossqty)
                dr("issuedetailid") = lblissuedetailid
                dr("unitid") = lblunitid
                dr("Rflagsize") = lblrflagsize
                dr("undyedqty") = 0
                dr("Ifinishedid") = 0
                dr("ConeType") = Conetype
                dr("Noofcone") = Noofcone
                dr("Penalityamt") = penalityamt
                dr("Penalityrate") = Convert.ToDouble(If(txtPenalityRate = "", "0", txtPenalityRate))
                dr("PlyType") = PlyType
                dr("TransportType") = TransportType
                dr("Moisture") = Moisture
                dr("RecMoisture") = RecMoisture
                dr("BellWt") = BellWt

                dtrecord.Rows.Add(dr)
            End If

        Next

        If dtrecord.Rows.Count > 0 Then

            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim arr As SqlParameter() = New SqlParameter(14) {}
                arr(0) = New SqlParameter("@ID", SqlDbType.Int)
                arr(0).Direction = ParameterDirection.InputOutput
                arr(0).Value = hnid
                arr(1) = New SqlParameter("@companyid", DDCompanyName.SelectedValue)
                arr(2) = New SqlParameter("@Processid", DDProcessName.SelectedValue)
                arr(3) = New SqlParameter("@empid", DDPartyName.SelectedValue)
                arr(4) = New SqlParameter("@Indentid", DDissueno.SelectedValue)
                arr(5) = New SqlParameter("@ChallanNo", SqlDbType.VarChar, 50)
                arr(5).Direction = ParameterDirection.InputOutput
                arr(5).Value = txtchallanNo.Text
                arr(6) = New SqlParameter("@RecDate", txtrecdate.Text)
                arr(7) = New SqlParameter("@userid", varuserid)
                arr(8) = New SqlParameter("@mastercompanyid", VarMasterCompanyID)
                arr(9) = New SqlParameter("@dtrecord", dtrecord)
                arr(10) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                arr(10).Direction = ParameterDirection.Output
                arr(11) = New SqlParameter("@GateinNo", SqlDbType.VarChar, 100)
                arr(11).Direction = ParameterDirection.InputOutput
                arr(11).Value = txtgateinno.Text
                arr(12) = New SqlParameter("@CheckedBy", txtcheckedby.Text)
                arr(13) = New SqlParameter("@Approvedby", txtapprovedby.Text)
                arr(14) = New SqlParameter("@BinNo", If(DDBinNo.Visible = True, DDBinNo.Text, ""))
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_MOTTELINGRECEIVE", arr)
                hnid = arr(0).Value.ToString()
                txtchallanNo.Text = arr(5).Value.ToString()
                txtgateinno.Text = arr(11).Value.ToString()
                If arr(10).Value.ToString() <> "" Then
                    MsgBox(arr(10).Value.ToString())
                    Tran.Rollback()
                Else
                    Tran.Commit()
                    'DDissueno.SelectedIndex = -1
                    'DG.Rows.Clear()
                    FillGridReceive()
                    MsgBox("Data saved successfully.")
                    fillgrid()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        Else
            MsgBox("Please select Godown or Enter (Recqty or Loss qty) to save data.")
        End If

    End Sub
    Protected Sub fillgrid()
        Dim i As Integer
        DGrecdetail.Rows.Clear()
        Dim str As String = "select SRM.ID,SRD.Detailid,dbo.F_getItemDescription(srd.Rfinishedid,SRD.Rflagsize) as RItemdescription," & _
                        "gm.GodownName,SRD.LotNo,SRD.TagNo,SRD.Recqty,SRD.Lossqty,SRD.Rate,isnull(SRM.GateinNo,'') as GateinNo,SRM.challanNo,SRM.receiveDate,srd.Undyedqty," & _
                        "isnull(Srm.Checkedby,'') as Checkedby,isnull(Srm.Approvedby,'') as Approvedby " & _
                        "From MOTTELINGRECEIVEMASTER SRM inner join MOTTELINGRECEIVEDETAIL SRD on SRM.ID=SRD.Masterid " & _
                        "inner join GodownMaster gm on SRD.godownid=gm.GoDownID Where SRM.id=" & hnid

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                DGrecdetail.Rows.Add()
                DGrecdetail.Item("ReceiveDescription", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Ritemdescription")
                DGrecdetail.Item("godown", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("godownname")
                DGrecdetail.Item("Lotno", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
                DGrecdetail.Item("TagNo", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
                DGrecdetail.Item("Recqty", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Recqty")
                DGrecdetail.Item("Lossqty", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lossqty")
                DGrecdetail.Item("Rate", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("rate")
                DGrecdetail.Item("Undyedqty", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Undyedqty")
                DGrecdetail.Item("Id", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Id")
                DGrecdetail.Item("Detailid", DGrecdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Detailid")
            Next
        End If
    End Sub
    Private Sub DG_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEnter
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
            Case "RECQTYDG", "UNDYEDQTYDG"
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

    Private Sub DG_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
            ''Case "RECQTYDG", "UNDYEDQTYDG", "LOSSQTYDG"
            Case "UNDYEDQTYDG", "LOSSQTYDG"
                SaveDetail()
                If DG.Rows.Count > 0 Then
                    DG.Item(gridcolname, gridindex).Value = ""
                End If
                If _serialPort IsNot Nothing Then
                    _serialPort.Close()
                    _serialPort = Nothing
                End If
        End Select
    End Sub
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        hnid = "0"
        txtgateinno.Text = ""
        txtchallanNo.Text = ""
        txtcheckedby.Text = ""
        txtapprovedby.Text = ""
        txtrecdate.Text = System.DateTime.Now.ToShortDateString()
        DG.Rows.Clear()
        DGrecdetail.Rows.Clear()
    End Sub

    Private Sub DGrecdetail_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DGrecdetail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub

            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim lblDetailid As String = DGrecdetail.Item("Detailid", DGrecdetail.CurrentRow.Index).Value
                Dim lblid As String = DGrecdetail.Item("id", DGrecdetail.CurrentRow.Index).Value
                Dim arr As SqlParameter() = New SqlParameter(4) {}
                arr(0) = New SqlParameter("@Detailid", lblDetailid)
                arr(1) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                arr(1).Direction = ParameterDirection.Output
                arr(2) = New SqlParameter("@ID", lblid)
                arr(3) = New SqlParameter("@userid", varuserid)
                arr(4) = New SqlParameter("@mastercompanyid", VarMasterCompanyID)
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_DELETEMOTTELINGRECEIVE", arr)
                MsgBox(arr(1).Value.ToString())
                Tran.Commit()
                fillgrid()
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()

            End Try
        End If
    End Sub
    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = "select * from V_MOTTELINGRECEIVE where id=" & hnid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptMottelingreceive.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\rptMottelingreceive.xsd")
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
            MsgBox("No records found!!!")
        End If
    End Sub
    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub frmsampledyeingmaterialreceive_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub DDgodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDgodown.SelectedIndexChanged
        If DDgodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If DDBinNo.Visible = True Then
                If VarCHECKBINCONDITION = 1 Then
                    Module1.FillBinNO(DDBinNo, DDgodown.SelectedValue, Item_finished_id:=0, New_Edit:=0)
                Else
                    ''NewComboFill(DDBinNo, "SELECT DISTINCT BINNO,BINNO AS BINNO1 FROM STOCK S WHERE GODOWNID=" & DDgodown.SelectedValue & "  ORDER BY BINNO1")
                    NewComboFill(DDBinNo, "Select DISTINCT BINNO,BINNO AS BINNO1 From BINMASTER(nolock) Where GODOWNID = " & DDgodown.SelectedValue & "  ORDER BY BINNO1")
                End If
            End If
        End If
    End Sub
    Private Sub txtWeaverIdNoscan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtWeaverIdNoscan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim str As String = "select empid From Empinfo Where empcode='" & txtWeaverIdNoscan.Text & "'"
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                DDPartyName.SelectedValue = ds.Tables(0).Rows(0)("empid").ToString()
                DDPartyName_SelectedIndexChanged(sender, New EventArgs())
            End If
        End If
    End Sub
    Private Sub DG_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        If UCase(DG.Columns(DG.CurrentCell.ColumnIndex).Name) = "CMBCONETYPE" Then
            Dim cmbconetype As ComboBox = CType(e.Control, ComboBox)
            If cmbconetype IsNot Nothing Then
                RemoveHandler cmbconetype.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_Conetype)
                AddHandler cmbconetype.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_Conetype)
            End If
        End If
        If UCase(DG.Columns(DG.CurrentCell.ColumnIndex).Name) = "CMBPLYTYPE" Then
            Dim CmbPlyType As ComboBox = CType(e.Control, ComboBox)
            If CmbPlyType IsNot Nothing Then
                RemoveHandler CmbPlyType.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_Conetype)
                AddHandler CmbPlyType.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_Conetype)
            End If
        End If
        If UCase(DG.Columns(DG.CurrentCell.ColumnIndex).Name) = "CMBTRANSPORTTYPE" Then
            Dim CmbTransportType As ComboBox = CType(e.Control, ComboBox)
            If CmbPlyType IsNot Nothing Then
                RemoveHandler CmbTransportType.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_Conetype)
                AddHandler CmbTransportType.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_Conetype)
            End If
        End If
    End Sub
    Private Sub ComboBox_SelectionChangeCommitted_Conetype(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cmbconetype As ComboBox = CType(sender, ComboBox)
        Dim CmbPlyType As ComboBox = CType(sender, ComboBox)
        Dim CmbTransportType As ComboBox = CType(sender, ComboBox)

        Dim rate As String = Module1.Getmottelingrate(DG.Item("lblritemid", DG.CurrentRow.Index).Value, DG.Item("lblrQualityid", DG.CurrentRow.Index).Value, DDProcessName.SelectedValue, DDPartyName.SelectedValue, txtrecdate.Text, shadecolorid:=DG.Item("lblrshadecolorid", DG.CurrentRow.Index).Value, Conetype:=cmbconetype.Text, PlyType:=CmbPlyType.Text, TransportType:=CmbTransportType.Text).ToString()
        DG.Item("Ratedg", DG.CurrentRow.Index).Value = Val(rate)
    End Sub

    Private Sub BtnComplete_Click(sender As System.Object, e As System.EventArgs) Handles BtnComplete.Click
        If Validcombobox(DDissueno) = False Then Exit Sub
        SqlHelper.ExecuteNonQuery(Con, CommandType.Text, "Update MOTTELINGISSUEMASTER Set Status = 'COMPLETE' Where ID = " & DDissueno.SelectedValue & "")
        MsgBox("Status updated successfully", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")
    End Sub
End Class