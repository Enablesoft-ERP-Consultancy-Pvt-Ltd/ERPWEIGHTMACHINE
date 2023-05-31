Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Imports System.Web.UI.WebControls

Public Class FrmRawMaterialIssueforOthers
    'Public Con As New SqlClient.SqlConnection
    Dim unit As Integer
    Dim CompanyId, Empid As Integer
    Dim finishedid As Integer
    Dim CmbOperator1 As DataGridViewComboBoxCell
    Dim CmbOperator As DataGridViewComboBoxCell
    Dim issqty1 As Double
    Private Sub FrmRawMaterialIssue_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If

        CompanyId = VarCompanyID

        Call NewComboFill(DDProcessName, "select PROCESS_NAME_ID,PROCESS_NAME From PROCESS_NAME_MASTER(nolock) Where ProcessType=1 order by PROCESS_NAME ")
        Call NewComboFill(cmbgodown, "select GoDownID,GodownName From GodownMaster(nolock) order by GodownName")
        If cmbgodown.Items.Count > 0 Then cmbgodown.SelectedIndex = 0
        If VarBINNOWISE = "1" Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If

        show_Grid()
    End Sub

    Private Sub ChkForIss_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkforCone.CheckedChanged
        show_Grid()
        '' ListBox1.Items.Add(New ListBoxItem("1", 1))
    End Sub
    Private Sub show_Grid()
        If chkforCone.Checked = True Then
            DGConsumption.Visible = False

            GroupBox3.Visible = False
            'Call Fill_Grid_Consmption_ConeType()
        Else
            GroupBox3.Visible = True
            DGConsumption.Visible = True

        End If
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        txtfolioNo.Text = ""
        Lblprmid.Text = "0"
        txtchalanno.Text = ""
        DGOrderdetail.Rows.Clear()
        DGConsumption.Rows.Clear()
        'DGConsumptionConeType.Rows.Clear()
    End Sub
    Private Sub txtfolioNo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtfolioNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            ''*****GET PROCESSID
            Dim str As String = "select top(1) Processid " &
                " From View_process_issue_master Where CompanyID = " & VarCompanyID & " And ChallanNo='" & txtfolioNo.Text & "'"

            If DDProcessName.SelectedIndex <> -1 Then
                str = str + " And ProcessID = " & DDProcessName.SelectedValue & ""
            End If
            str = str + "  order by PROCESSID "

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                DDProcessName.SelectedValue = ds.Tables(0).Rows(0)("processid")
            End If
            If Validcombobox(DDProcessName) = False Then Exit Sub
            DDProcessName_SelectedIndexChanged(sender, New EventArgs())
        End If
    End Sub
    Private Sub fill_Grid()
        If Validcombobox(DDfoliono) = False Then Exit Sub

        Dim str As String = ""
        Dim ds As DataSet
        Dim i As Integer
        DGOrderdetail.Rows.Clear()
        Dim IstQueryflag As Boolean = True
        If VarMasterCompanyID = 9 Then
            IstQueryflag = True
        Else
            If DDProcessName.SelectedValue = 1 Then
                IstQueryflag = True
            Else
                If VarFINISHINGNEWMODULEWISE = 1 Then
                    IstQueryflag = False
                Else
                    IstQueryflag = True
                End If
            End If
        End If
        If IstQueryflag = True Then
            str = "select Issue_Detail_Id as IssueDetailId,vf.Category_Name as Category,vf.Item_Name as Articles,vf.ColorName As Color, Length,Width,Width + 'x' + Length Size,Area," &
                    "Rate,Qty,Amount,OrderId,PD.Item_Finished_Id,isnull(units,0) as units,pm.UserId,pm.Companyid ,isnull(PM.empid,0) as empid,isnull(Ei.empname,'') as Empname  From PROCESS_ISSUE_MASTER_" & DDProcessName.SelectedValue & " PM  " &
                    "inner join PROCESS_ISSUE_DETAIL_" & DDProcessName.SelectedValue & " PD on PM.IssueOrderId=PD.IssueOrderId and PM.Status<>'canceled' " &
                    "inner join V_FinishedItemDetail vf on PD.Item_Finished_Id=vf.ITEM_FINISHED_ID Left join EmpInfo EI on PM.Empid=Ei.EmpId where Pm.issueorderid='" & DDfoliono.SelectedValue & "' "
        Else
            str = "select Issue_Detail_Id as IssueDetailId,vf.Category_Name as Category,vf.Item_Name as Articles,vf.ColorName As Color, Length,Width,Width + 'x' + Length Size,Area," &
                  "Rate,Qty,Amount,OrderId,PD.Item_Finished_Id,isnull(units,0) as units,pm.UserId,pm.Companyid ,PM.empid,Ei.empname  From PROCESS_ISSUE_MASTER_" & DDProcessName.SelectedValue & " PM  " &
                  "inner join PROCESS_ISSUE_DETAIL_" & DDProcessName.SelectedValue & " PD on PM.IssueOrderId=PD.IssueOrderId and PM.Status<>'canceled' " &
                  "inner join V_FinishedItemDetail vf on PD.Item_Finished_Id=vf.ITEM_FINISHED_ID inner join V_GetCommaSeparateEmployee EI on PM.Issueorderid=Ei.Issueorderid and EI.processid=" & DDProcessName.SelectedValue & " where Pm.issueorderid='" & DDfoliono.SelectedValue & "' "
        End If

        ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            txtfolioNo.Text = DDfoliono.Text
            DGOrderdetail.Rows.Add()
            For i = 0 To ds.Tables(0).Rows.Count - 1
                DGOrderdetail.Item("Article", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Articles")
                DGOrderdetail.Item("Color", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Color")
                DGOrderdetail.Item("size", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Size")
                DGOrderdetail.Item("Qty", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
                DGOrderdetail.Item("unitid", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("units")
                DGOrderdetail.Item("ItemFinishedId", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_Finished_Id")
                DGOrderdetail.Item("Length", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Length")
                DGOrderdetail.Item("width", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("width")
                DGOrderdetail.Item("area", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("area")
                DGOrderdetail.Item("rate", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("rate")
                DGOrderdetail.Item("amount", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("amount")
                DGOrderdetail.Item("orderid", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("orderid")
                unit = Convert.ToInt32(DGOrderdetail.Item("unitid", DGOrderdetail.Rows.Count - 1).Value)
                DGOrderdetail.Item("userid", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("userid")
                DGOrderdetail.Item("Comanyid", DGOrderdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Companyid")
                'CompanyId = ds.Tables(0).Rows(i)("Companyid")
                Empid = ds.Tables(0).Rows(i)("EMpid")
                lblweaver.Text = ds.Tables(0).Rows(i)("empname")
            Next
        End If
    End Sub
    Private Sub Fill_Grid_Consmption()
        If Validcombobox(DDfoliono) = False Then Exit Sub

        Dim ds As DataSet
        Dim i As Integer
        DGConsumption.Rows.Clear()

        Dim Param(2) As SqlParameter
        Param(0) = New SqlParameter("@issueorderid", DDfoliono.SelectedValue)
        Param(1) = New SqlParameter("@processid", DDProcessName.SelectedValue)
        Param(2) = New SqlParameter("@MastercompanyId", VarMasterCompanyID)

        ds = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "[Pro_RawMaterailIssueDataForOthers]", Param)


        'ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                DGConsumption.Rows.Add()
                DGConsumption.Item("ItemName", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_Name")
                DGConsumption.Item("Description", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
                DGConsumption.Item("ConsmpQty", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ConsmpQTY")
                DGConsumption.Item("Issuedqty", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IssuedQty")
                DGConsumption.Item("PendQty", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("PendQty")
                'FinishedId = ds.Tables(0).Rows(i)("IFinishedid")
                DGConsumption.Item("itemid", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IFinishedid")
                DGConsumption.Item("item_id", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_id")
                DGConsumption.Item("CategoryId", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Category_id")
                DGConsumption.Item("BellWt", DGConsumption.Rows.Count - 1).Value = 0

                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("Godown"), DataGridViewComboBoxCell)
                Fill_Grid_Combo(CmbOperator, "Select Distinct GM.GodownID,GM.GodownName From GodownMaster GM,Stock S Where GM.GodownID=S.GodownID And QtyInHand>0 And CompanyId=1    Order By GodownName")

                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("lotno"), DataGridViewComboBoxCell)

                If cmbgodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                    Dim str As String = "select Lotno,LotNo From Stock Where CompanyId=" & CompanyId & " and godownId=" & cmbgodown.SelectedValue & " AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DGConsumption.Item("itemid", i).Value & " "
                    If DDBinNo.Visible = True Then
                        str = str & " and BinNo='" + DDBinNo.Text + "'"
                    End If

                    Fill_Grid_Combo(CmbOperator, str)
                End If
                ''TAGNO
                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("TagNo"), DataGridViewComboBoxCell)

                If cmbgodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                    Dim str As String = "select TAGNO,TAGNO From Stock Where CompanyId=" & CompanyId & " and godownId=" & cmbgodown.SelectedValue & " AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DGConsumption.Item("itemid", i).Value & " "
                    If DDBinNo.Visible = True Then
                        str = str & " and BinNo='" + DDBinNo.Text + "'"
                    End If

                    Fill_Grid_Combo(CmbOperator, str)
                End If
                ''
                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("Unitidgrid"), DataGridViewComboBoxCell)
                Fill_Grid_Combo(CmbOperator, "select Distinct U.UnitId,U.unitname From ITEM_MASTER IM inner join UNIT_TYPE_MASTER UT on IM.UnitTypeID=UT.UnitTypeID " &
                                             "inner join Unit u on Ut.UnitTypeID=U.UnitTypeID WHere IM.Item_id=" & DGConsumption.Item("item_id", i).Value & " ")
                'If VarMasterCompanyID = 16 Or VarMasterCompanyID = 28 Then
                '    CmbOperator.Value = 3
                'End If
                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("Conetype"), DataGridViewComboBoxCell)
                Fill_Grid_Combo(CmbOperator, "Select ConeType, ConeType From ConeMaster Order By SrNo")

            Next
        End If
    End Sub
    Protected Sub Fill_Grid_Combo(ByRef cmbbobox As DataGridViewComboBoxCell, ByVal str As String)
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        cmbbobox.DataSource = ds.Tables(0)
        cmbbobox.ValueMember = ds.Tables(0).Columns(0).ColumnName
        cmbbobox.DisplayMember = ds.Tables(0).Columns(1).ColumnName
    End Sub
    Private Sub DGConsumption_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGConsumption.EditingControlShowing
        Select Case DGConsumption.Columns(DGConsumption.CurrentCell.ColumnIndex).Name.ToUpper()
            Case "LOTNO"
                Dim cmbLotno As ComboBox = CType(e.Control, ComboBox)
                If (cmbLotno IsNot Nothing) Then
                    RemoveHandler cmbLotno.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_lotno)
                    AddHandler cmbLotno.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_lotno)

                End If
            Case "TAGNO"
                Dim cmbtagno As ComboBox = CType(e.Control, ComboBox)
                If (cmbtagno IsNot Nothing) Then
                    RemoveHandler cmbtagno.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_tagno)
                    AddHandler cmbtagno.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_tagno)

                End If

        End Select

    End Sub

    Private Sub ComboBox_SelectionChangeCommitted_lotno(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim godownid As Integer
        godownid = cmbgodown.SelectedValue
        Dim cmbLotno As ComboBox = CType(sender, ComboBox)

        Dim stkqty As Double
        stkqty = Module1.getstockQty(CompanyId.ToString(), godownid, cmbLotno.SelectedValue, DGConsumption.Item("Itemid", DGConsumption.CurrentRow.Index).Value)
        DGConsumption.Item("stockqty", DGConsumption.CurrentRow.Index).Value = stkqty
    End Sub
    Private Sub ComboBox_SelectionChangeCommitted_tagno(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim godownid As Integer
        Dim Lotno As String = DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Value
        Dim TagNo As String = DGConsumption.Item("Tagno", DGConsumption.CurrentRow.Index).Value
        godownid = cmbgodown.SelectedValue
        Dim cmbtagno As ComboBox = CType(sender, ComboBox)
        If TagNo = Nothing Then
            TagNo = cmbtagno.SelectedValue
        End If

        Dim str As String
        Dim stkqty As Double
        stkqty = Module1.getstockQty(CompanyId.ToString(), godownid, Lotno, DGConsumption.Item("Itemid", DGConsumption.CurrentRow.Index).Value, TagNo, BinNo:=IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))
        DGConsumption.Item("stockqty", DGConsumption.CurrentRow.Index).Value = stkqty
    End Sub

    Private Sub ComboBox_SelectionChangeCommitted_lotno_contype(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Event DGConsumptionButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
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
    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()

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

                txtweight.Text = w_Weight.ToString()
                DGConsumption.Item("issueqty", lblgridindex.Tag).Value = w_Weight.ToString()
                '                DGConsumption.CurrentCell = DGConsumption((DGConsumption.Columns("Issuqty").Index), lblgridindex.Tag)

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DGConsumption_ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles Me.DGConsumptionButtonClick
        If (DDItemDesignName.Visible = True) Then
            If Validcombobox(DDItemDesignName) = False Then Exit Sub
        End If

        If Validcombobox(cmbgodown) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        If Con.State = ConnectionState.Closed Then Con.Open()
        Dim Tran As SqlTransaction = Con.BeginTransaction
        Dim remark As String = String.Empty
        Try
            For i As Integer = 0 To DGConsumption.Rows.Count - 1
                Dim rowremarks As String = String.Empty
                Dim row As DataGridViewRow = DGConsumption.Rows(i)
                rowremarks = DGConsumption.Item("Remarks", row.Index).Value
                If Not String.IsNullOrEmpty(rowremarks) Then

                    remark = rowremarks

                End If



            Next

            If Val(DGConsumption.Item("Unitidgrid", DGConsumption.CurrentRow.Index).Value) = 0 Then
                MsgBox("Plz select Unit.....", MsgBoxStyle.OkOnly)
                DGConsumption.Item("Unitidgrid", DGConsumption.CurrentRow.Index).Selected = True
                Tran.Commit()
                Exit Sub
            End If
            If DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Value = "" Then
                MsgBox("Plz select LotNo.....", MsgBoxStyle.OkOnly)
                DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Selected = True
                Tran.Commit()
                Exit Sub
            End If

            If Val(DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Value) = 0 Then
                MsgBox("Plz Enter Issue Qty.....", MsgBoxStyle.OkOnly, "Message")
                DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Selected = True
                Tran.Commit()
                Exit Sub
            End If
            Dim godownid As Integer = 1
            Dim unit As Integer = Convert.ToInt32(DGOrderdetail.Item("unitid", DGOrderdetail.CurrentRow.Index).Value)
            Select Case Convert.ToInt32(unit)
                Case 1
                    godownid = 1
                Case 2
                    godownid = 2
                Case 3
                    godownid = 3
                Case 4
                    godownid = 4
                Case 5
                    godownid = 5
            End Select
            godownid = cmbgodown.SelectedValue
            Dim issqty As Double
            issqty = Convert.ToDouble(DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Value)

            Dim param(34) As SqlParameter
            param(0) = New SqlParameter("@PrmID", SqlDbType.Int)
            param(1) = New SqlParameter("@CompanyId", SqlDbType.Int)
            param(2) = New SqlParameter("@EmpId", SqlDbType.Int)
            param(3) = New SqlParameter("@ProcessId", SqlDbType.Int)
            param(4) = New SqlParameter("@OrderId", SqlDbType.Int)
            param(5) = New SqlParameter("@IssueDate", SqlDbType.SmallDateTime)
            param(6) = New SqlParameter("@ChalanNo", SqlDbType.NVarChar, 50)
            param(7) = New SqlParameter("@TranType", SqlDbType.Int)
            param(8) = New SqlParameter("@userid", SqlDbType.Int)
            param(9) = New SqlParameter("@mastercompanyid", SqlDbType.Int)
            param(10) = New SqlParameter("@Prtid", SqlDbType.Int)
            param(11) = New SqlParameter("@CategoryId", SqlDbType.Int)
            param(12) = New SqlParameter("@Itemid", SqlDbType.Int)
            param(13) = New SqlParameter("@FinishedId", SqlDbType.Int)
            param(14) = New SqlParameter("@GodownId", SqlDbType.Int)
            param(15) = New SqlParameter("@IssueQuantity", SqlDbType.Float)
            param(16) = New SqlParameter("@lotNo", SqlDbType.NVarChar, 50)
            param(17) = New SqlParameter("@UnitId", SqlDbType.Int)
            param(18) = New SqlParameter("@PrmIdOutPut", SqlDbType.Int)
            param(19) = New SqlParameter("@PrtIdOutPut", SqlDbType.Int)
            param(20) = New SqlParameter("@UpdateFlag", SqlDbType.Int)
            param(21) = New SqlParameter("@BinNo", SqlDbType.VarChar, 50)
            param(22) = New SqlParameter("@TagNo", SqlDbType.NVarChar, 50)
            param(23) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            param(24) = New SqlParameter("@conetype", SqlDbType.VarChar, 50)
            param(25) = New SqlParameter("@Noofcone", SqlDbType.Int)
            param(26) = New SqlParameter("@BellWt", SqlDbType.Decimal)
            param(27) = New SqlParameter("@ItemDesignID", SqlDbType.Int)
            param(28) = New SqlParameter("@VEHICLENO", SqlDbType.NVarChar, 100)
            param(29) = New SqlParameter("@TRANSPORTNAME", SqlDbType.NVarChar, 100)
            param(30) = New SqlParameter("@EWayBillNo", SqlDbType.NVarChar, 100)
            param(31) = New SqlParameter("@GstType", SqlDbType.Int)
            param(32) = New SqlParameter("@remark", SqlDbType.NVarChar, 100)
            param(33) = New SqlParameter("@FolioChallanNo", SqlDbType.NVarChar, 100)

            If Lblprmid.Text = "" Then
                Lblprmid.Text = "0"
            End If
            param(0).Value = Lblprmid.Text
            param(1).Value = CompanyId ' ddCompName.SelectedValue
            param(2).Value = Empid ' ddempname.SelectedValue
            param(3).Value = DDProcessName.SelectedValue ' ddProcessName.SelectedValue
            param(4).Value = DDfoliono.SelectedValue ' ddOrderNo.SelectedValue
            param(5).Value = txtdate.Text
            param(6).Value = txtchalanno.Text
            param(6).Direction = ParameterDirection.InputOutput
            param(7).Value = 0
            param(8).Value = varuserid 'Session("varuserid").ToString()
            param(9).Value = VarMasterCompanyID 'Session("VarMasterCompanyID").ToString()
            param(10).Value = 0
            param(11).Value = DGConsumption.Item("Categoryid", DGConsumption.CurrentRow.Index).Value
            param(12).Value = DGConsumption.Item("item_id", DGConsumption.CurrentRow.Index).Value  ''
            param(13).Value = DGConsumption.Item("itemid", DGConsumption.CurrentRow.Index).Value  ''finished_id
            param(14).Value = godownid
            param(15).Value = issqty
            param(16).Value = DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Value
            param(17).Value = DGConsumption.Item("Unitidgrid", DGConsumption.CurrentRow.Index).Value 'Unit KG
            param(18).Direction = ParameterDirection.Output
            param(19).Direction = ParameterDirection.Output
            param(20).Value = 0
            param(21).Value = IIf(DDBinNo.Visible = True, DDBinNo.Text, "")
            param(22).Value = DGConsumption.Item("Tagno", DGConsumption.CurrentRow.Index).Value
            param(23).Direction = ParameterDirection.Output
            param(24).Value = DGConsumption.Item("conetype", DGConsumption.CurrentRow.Index).Value
            param(25).Value = Val(DGConsumption.Item("Noofcone", DGConsumption.CurrentRow.Index).Value)
            param(26).Value = Val(DGConsumption.Item("BellWt", DGConsumption.CurrentRow.Index).Value)
            param(27).Value = DDItemDesignName.SelectedValue
            param(28).Value = TxtVehicleNo.Text
            param(29).Value = TxtDriverName.Text
            param(30).Value = TxtEWayBillNo.Text
            param(31).Value = IIf(ChkForGSTStateOutSide.Checked = True, 1, 0)
            param(32).Value = remark
            param(33).Value = DDfoliono.Text

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "[PRO_PROCESS_RAW_ISSUE]", param)
            Tran.Commit()
            txtchalanno.Text = param(6).Value
            Lblprmid.Text = param(18).Value
            MsgBox(param(23).Value.ToString())
            Fill_Grid_Consmption()
            Fill_GridSave()
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Event DGConsumptionConeTypeButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
    Private Sub DGConsumptionConeType_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DGConsumptionConeTypeButtonClick(senderGrid, e)
        End If
    End Sub
    Private Sub BtnPreview_Click(sender As System.Object, e As System.EventArgs) Handles BtnPreview.Click
        Dim str As String = ""
        Dim IstQueryflag As Boolean = True
        If VarMasterCompanyID = 9 Then
            IstQueryflag = True
        Else
            If DDProcessName.SelectedValue = 1 Then
                IstQueryflag = True
            Else
                If VarFINISHINGNEWMODULEWISE = 1 Then
                    IstQueryflag = False
                Else
                    IstQueryflag = True
                End If
            End If
        End If
        If IstQueryflag = True Then
            'str = " Select PM.Date, PM.ChalanNo, PM.trantype, PT.IssueQuantity,  " & _
            '                    " PT.Lotno, GM.GodownName, Case When IsNull(EI.EmpName, '') = '' Then  " & _
            '                     " (Select Distinct EII.EmpName + ', '  " & _
            '                      " From Employee_ProcessOrderNo EPO(Nolock)  " & _
            '                      " JOIN Empinfo EII(Nolock) ON EII.EmpID = EPO.EmpID And EPO.IssueOrderId = PM.Prorderid And EPO.ProcessId = PM.Processid)  " & _
            '                    " Else EI.EmpName End EmpName, " & _
            '            " EI.Address, BM.BranchName CompanyName, BM.BranchAddress CompAddr1, '' CompAddr2,  " & _
            '            " '' CompAddr3, BM.PhoneNo CompTel, vf.ITEM_NAME, vf.QualityName, vf.designName, " & _
            '            " vf.ColorName, vf.ShadeColorName, vf.ShapeName, vf.SizeMtr, PNM.PROCESS_NAME, " & _
            '            " PM.Prorderid, EI.GSTNo as empgstin, CI.GSTNo,PT.TAGNO,PT.BINNO,  " & _
            '            " (Select Distinct CII.CustomerCode + ', ' " & _
            '                " From PROCESS_ISSUE_DETAIL_" & DDProcessName.SelectedValue & " PID(Nolock)  " & _
            '                " JOIN OrderMaster OM(Nolock) ON OM.OrderiD = PID.OrderiD  " & _
            '                    " JOIN CustomerInfo CII(Nolock) ON CII.CustomerID = OM.CustomerID  " & _
            '                    " Where PID.IssueOrderId = PM.Prorderid For XML Path('')) OrderNo, " & _
            '            " PM.VehicleNo, PM.TransportName, PM.EWayBillNo, PT.PurchaseRate, PT.PurchaseRate * PT.IssueQuantity PurchaseAmt, " & _
            '            " PT.GstType, Round(IsNull(Case When PT.GstType = 0 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 / 2 End, 0), 2) CGstAmt, " & _
            '            " Round(IsNull(Case When PT.GstType = 0 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 / 2 End, 0), 2) SGstAmt, " & _
            '            " Round(IsNull(Case When PT.GstType = 1 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 End, 0), 2) IGstAmt, U.UnitName, " & _
            '            " VF.HSNCode " & _
            '            " From ProcessRawMaster PM(Nolock) " & _
            '            " join ProcessRawTran PT(Nolock) on PM.PRMid=PT.PRMid  " & _
            '            " JOIN BranchMaster BM(Nolock) ON BM.ID = PM.BranchID " & _
            '            " join CompanyInfo ci(Nolock) on PM.Companyid=ci.CompanyId  " & _
            '            " join V_FinishedItemDetail vf(Nolock) on PT.Finishedid=vf.ITEM_FINISHED_ID  " & _
            '            " join GodownMaster GM(Nolock) on PT.Godownid=GM.GoDownID  " & _
            '            " LEFT join EmpInfo Ei(Nolock) on PM.Empid=ei.EmpId  " & _
            '            " join PROCESS_NAME_MASTER PNM(Nolock) on PM.Processid=PNM.PROCESS_NAME_ID  " & _
            '            " JOIN Unit U ON U.UnitId = PT.UnitId  " & _
            '            " Where PM.Prmid=" + Lblprmid.Text + ""
            str = " Select PM.Date, PM.ChalanNo, PM.trantype, PT.IssueQuantity, " & _
                                " PT.Lotno, GM.GodownName, Case When IsNull(EI.EmpName, '') = '' Then  " & _
                                 " (Select Distinct EII.EmpName + ', '  " & _
                                  " From Employee_ProcessOrderNo EPO(Nolock)  " & _
                                  " JOIN Empinfo EII(Nolock) ON EII.EmpID = EPO.EmpID And EPO.IssueOrderId = PM.Prorderid And EPO.ProcessId = PM.Processid)  " & _
                                " Else EI.EmpName End EmpName,  " & _
                                " Case When IsNull(EI.Address, '') = '' Then  " & _
                                 " (Select Distinct EII.Address + ', '  " & _
                                  " From Employee_ProcessOrderNo EPO(Nolock)  " & _
                                  " JOIN Empinfo EII(Nolock) ON EII.EmpID = EPO.EmpID And EPO.IssueOrderId = PM.Prorderid And EPO.ProcessId = PM.Processid)  " & _
                                " Else EI.Address End Address, " & _
                                " CI.CompanyName, BM.BranchAddress CompAddr1, '' CompAddr2,  " & _
                                " '' CompAddr3, CI.CompTel, vf.ITEM_NAME, vf.QualityName, vf.designName,  " & _
                                " vf.ColorName, vf.ShadeColorName, vf.ShapeName, vf.SizeMtr, PNM.PROCESS_NAME,  " & _
                                " (Select Distinct Cast(Prorderid As Nvarchar) + ', '  " & _
                                " From ProcessRawMaster PMS(Nolock) Where PMS.TranType = PM.TranType And PMS.chalanno = PM.chalanno For XML Path('')) Prorderid,  " & _
                                " Case When IsNull(EI.GSTNo, '') = '' Then  " & _
                                 " (Select Distinct EII.GSTNo + ', '  " & _
                                  " From Employee_ProcessOrderNo EPO(Nolock)  " & _
                                  " JOIN Empinfo EII(Nolock) ON EII.EmpID = EPO.EmpID And EPO.IssueOrderId = PM.Prorderid And EPO.ProcessId = PM.Processid)  " & _
                                " Else EI.GSTNo End empgstin, " & _
                                " CI.GSTNo,PT.TAGNO,PT.BINNO,  " & _
                                " (Select Distinct CII.CustomerCode + ', ' " & _
                                  " From PROCESS_ISSUE_DETAIL_" & DDProcessName.SelectedValue & " PID(Nolock)  " & _
                                  " JOIN OrderMaster OM(Nolock) ON OM.OrderiD = PID.OrderiD  " & _
                                        " JOIN CustomerInfo CII(Nolock) ON CII.CustomerID = OM.CustomerID  " & _
                                        " Where PID.IssueOrderId = PM.Prorderid For XML Path('')) OrderNo, BM.GstNo BranchGstNo,  " & _
                                " 0 ReportType, PM.Prorderid IssueOrderID  " & _
                                " From ProcessRawMaster PM  " & _
                                " join ProcessRawTran PT on PM.PRMid=PT.PRMid  " & _
                                " JOIN BranchMaster BM ON BM.ID = PM.BranchID  " & _
                                " join CompanyInfo ci on PM.Companyid=ci.CompanyId  " & _
                                " join V_FinishedItemDetail vf on PT.Finishedid=vf.ITEM_FINISHED_ID  " & _
                                " join GodownMaster GM on PT.Godownid=GM.GoDownID  " & _
                                " LEFT join EmpInfo Ei on PM.Empid=ei.EmpId  " & _
                                " join PROCESS_NAME_MASTER PNM on PM.Processid=PNM.PROCESS_NAME_ID " & _
                                " Where PM.TypeFlag = 0 And PM.Prmid=" + Lblprmid.Text + " And PM.Processid=" & DDProcessName.SelectedValue & ""
        Else
            str = " select PM.Date, PM.ChalanNo, PM.trantype, PT.IssueQuantity, " & _
                        " PT.Lotno, GM.GodownName, EI.EmpName, '' Address, BM.BranchName CompanyName, BM.BranchAddress CompAddr1, '' CompAddr2, " & _
                        " '' CompAddr3, BM.PhoneNo CompTel, vf.ITEM_NAME, vf.QualityName, vf.designName, " & _
                        " vf.ColorName, vf.ShadeColorName, vf.ShapeName, vf.SizeMtr, PNM.PROCESS_NAME, " & _
                        " PM.Prorderid, '' as empgstin, CI.GSTNo, PT.TAGNO,PT.BINNO, '' OrderNo, " & _
                        " PM.VehicleNo, PM.TransportName, PM.EWayBillNo, PT.PurchaseRate, PT.PurchaseRate * PT.IssueQuantity PurchaseAmt, " & _
                        " PT.GstType, Round(Case When PT.GstType = 0 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 / 2 End, 0) CGstAmt, " & _
                        " IsNull(Case When PT.GstType = 0 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 / 2 End, 0) SGstAmt, " & _
                        " IsNull(Case When PT.GstType = 1 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 End, 0) IGstAmt, U.UnitName, " & _
                        " VF.HSNCode " & _
                        " From ProcessRawMaster PM(Nolock) " & _
                        " inner join ProcessRawTran PT(Nolock) on PM.PRMid=PT.PRMid " & _
                        " inner join CompanyInfo ci(Nolock) on PM.Companyid=ci.CompanyId " & _
                        " inner join V_FinishedItemDetail vf(Nolock) on PT.Finishedid=vf.ITEM_FINISHED_ID " & _
                        " inner join GodownMaster GM(Nolock) on PT.Godownid=GM.GoDownID " & _
                        " inner join V_GetCommaSeparateEmployee Ei(Nolock) on PM.Prorderid=ei.Issueorderid and ei.Processid=" & DDProcessName.SelectedValue & " " & _
                        " inner join PROCESS_NAME_MASTER PNM(Nolock) on PM.Processid=PNM.PROCESS_NAME_ID " & _
                        " JOIN Unit U ON U.UnitId = PT.UnitId  " & _
                        " Where PM.Prmid=" + Lblprmid.Text + " and PM.Processid=" & DDProcessName.SelectedValue & " "
        End If

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            If (VarMasterCompanyID = 42) Then
                sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptRawIssueRecDuplicateVikramMirzapur.rpt")

                dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptRawIssueRecDuplicateNew.xsd")
                Objfile.Load(sReportName)
                ''Objfile.SetDatabaseLogon("sa", "eit")
                ds.WriteXmlSchema(dspath)

                ObjFolio.CR1.RefreshReport()
                '' Objfile.SetDataSource(ds)

                Label6.Text = VarSQLUserName
                lblfoliono.Text = VarSQLPassword
                Label3.Text = VarSQLServer
                Label8.Text = VarDatabaseName 

                Objfile.SetDatabaseLogon(VarSQLUserName, VarSQLPassword, VarSQLServer, VarDatabaseName)
                Objfile.Refresh()
                ObjFolio.CR1.ReportSource = Objfile
                VarSelectionFormula = "{ProcessRawMaster.PrmId}=" & Lblprmid.Text & ""

                ObjFolio.CR1.SelectionFormula = VarSelectionFormula
                '' ObjFolio.RecordSelectionFormula = VarSelectionFormula
                ObjFolio.CR1.Show()
                ObjFolio.Show()
            Else
                sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptRawIssueRecDuplicateNew.rpt")

                dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptRawIssueRecDuplicateNew.xsd")
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
            End If
        Else
            MsgBox("No records found..")
        End If
    End Sub
    Private Sub btnweight_Click(sender As System.Object, e As System.EventArgs) Handles btnweight.Click
        If DGConsumption.Rows.Count = 0 Then Exit Sub
        ' DGConsumption.Item("issueqty", lblgridindex.Tag).Value = Val(txtweight.Text)
        txtweight.Text = ""
        _serialPort.Close()
        _serialPort = Nothing
    End Sub

    Private Sub FrmRawMaterialIssue_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If _serialPort IsNot Nothing Then
                _serialPort.Close()
                _serialPort = Nothing
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmb_port_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmb_port.SelectedIndexChanged

    End Sub
    Private Sub cmbgodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbgodown.SelectedIndexChanged
        If cmbgodown.SelectedIndex <> -1 And Varcombovalue <> 0 And txtfolioNo.Text <> "" Then
            If VarBINNOWISE = "1" Then
                Call NewComboFill(DDBinNo, "Select DISTINCT BINNO,BINNO AS BINNO1 " & _
                    " From Stock S(Nolock) " & _
                    " JOIN PROCESS_CONSUMPTION_DETAIL PCD(Nolock) ON PCD.IFINISHEDID = S.ITEM_FINISHED_ID And PCD.ISSUEORDERID = " & txtfolioNo.Text & "" & _
                    " Where S.Qtyinhand > 0 And S.Godownid = " & cmbgodown.SelectedValue & "")
            Else
                If chkforCone.Checked = True Then
                    ' Call Fill_Grid_Consmption_ConeType()
                Else
                    Call Fill_Grid_Consmption()
                End If
            End If

        End If
    End Sub

    Private Sub DGConsumption_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGConsumption.CellEndEdit
        Select Case UCase(DGConsumption.Columns(e.ColumnIndex).Name)
            'Case "ISSUEQTY"
            '    Dim senderGrid = DirectCast(sender, DataGridView)
            '    Dim VarExcessQty As Double = 0
            '    Dim totalQty As Double = DGConsumption.Item("ConsmpQty", e.RowIndex).Value

            '    VarExcessQty = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, "Select PercentageExecssQtyForProcessIss From MasterSetting"))

            '    totalQty = (totalQty * (100.0 + VarExcessQty) / 100)
            '    Dim Qty As Double = Val(DGConsumption.Item("issueqty", e.RowIndex).Value) - Val(DGConsumption.Item("BellWt", e.RowIndex).Value)
            '    Dim PreQty As Double = Math.Round(totalQty - Val(DGConsumption.Item("PendQty", e.RowIndex).Value), 3)
            '    Dim stockqty As Double = Val(DGConsumption.Item("stockqty", e.RowIndex).Value)
            '    If Qty + PreQty > totalQty Or Qty > stockqty Then
            '        DGConsumption.Item("issueqty", e.RowIndex).Value = ""
            '        MsgBox("Pls Enter Correct Qty ")
            '        If _serialPort IsNot Nothing Then
            '            _serialPort.Close()
            '            _serialPort = Nothing
            '        End If
            '        Return
            '    End If
            '    RaiseEvent DGConsumptionButtonClick(senderGrid, e)
            '    DGConsumption.Item("issueqty", lblgridindex.Tag).Value = ""
            '    If _serialPort IsNot Nothing Then
            '        _serialPort.Close()
            '        _serialPort = Nothing
            '    End If
            Case "BELLWT"
                Dim senderGrid = DirectCast(sender, DataGridView)
                Dim VarExcessQty As Double = 0
                Dim totalQty As Double = DGConsumption.Item("ConsmpQty", e.RowIndex).Value
                Dim VarCONEWEIGHT As Double = 0
                Dim VarTotalConeWeight As Double = 0
                Dim PreQty As Double = Math.Round(totalQty - Val(DGConsumption.Item("PendQty", e.RowIndex).Value), 3)

                Dim stockqty As Double = Val(DGConsumption.Item("stockqty", e.RowIndex).Value)

                VarExcessQty = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, "Select PercentageExecssQtyForProcessIss From MasterSetting"))
                totalQty = (totalQty * (100.0 + VarExcessQty) / 100)

                VarCONEWEIGHT = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, "Select CONEWEIGHT FROM CONEMASTER WHERE CONETYPE = '" & DGConsumption.Item("conetype", e.RowIndex).Value & "'"))
                VarTotalConeWeight = (VarCONEWEIGHT * Val(DGConsumption.Item("Noofcone", e.RowIndex).Value))

                Dim Qty As Double = Val(DGConsumption.Item("issueqty", e.RowIndex).Value) - Val(DGConsumption.Item("BellWt", e.RowIndex).Value) - VarTotalConeWeight

                If Qty + PreQty > totalQty Or Qty > stockqty Then
                    DGConsumption.Item("BellWt", e.RowIndex).Value = ""
                    MsgBox("Pls Enter Correct Qty OR BellWt ")
                    If _serialPort IsNot Nothing Then
                        _serialPort.Close()
                        _serialPort = Nothing
                    End If
                    Return
                End If
                RaiseEvent DGConsumptionButtonClick(senderGrid, e)
                DGConsumption.Item("BellWt", lblgridindex.Tag).Value = ""
                If _serialPort IsNot Nothing Then
                    _serialPort.Close()
                    _serialPort = Nothing
                End If
        End Select
    End Sub
    Private Sub Fill_GridSave()
        gvdetail.Rows.Clear()
        Dim ds As DataSet = Nothing
        Dim i As Integer
        Dim strsql As String = "Select PrtId,CATEGORY_NAME,ITEM_NAME,QualityName+ Space(2)+DesignName+ Space(2)+ColorName+ Space(2)+ShapeName+ Space(2)+SizeFt+ Space(2)+ShadeColorName DESCRIPTION," & _
                             "IssueQuantity Qty,LotNo,TagNo,GodownName From ProcessRawTran PT,V_FinishedItemDetail VF,GodownMaster GM Where PT.Finishedid=VF.Item_Finished_id And " & _
                             "PT.GodownId=GM.GodownId And PT.PrmID=" & Lblprmid.Text & " And VF.MasterCompanyId=" & VarMasterCompanyID & ""
        ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            gvdetail.Rows.Add()
            gvdetail.Item("prtidgrid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("prtid")
            gvdetail.Item("Item_name", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_name")
            gvdetail.Item("descriptiongrid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
            gvdetail.Item("qtygrid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
            gvdetail.Item("Lotnogrid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("LotNo")
            gvdetail.Item("Tagnogrid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
            gvdetail.Item("godownname", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("godownname")
        Next

    End Sub

    Private Sub gvdetail_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvdetail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row?", MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If
            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim VarPrtID As Integer = gvdetail.Item("prtidgrid", gvdetail.CurrentRow.Index).Value
                Lblprmid.Text = SqlHelper.ExecuteScalar(Tran, CommandType.Text, "Select PrmId from ProcessRawTran Where PrtId=" & VarPrtID)
                Dim arr As SqlParameter() = New SqlParameter(6) {}
                arr(0) = New SqlParameter("@PrtID", SqlDbType.Int)
                arr(1) = New SqlParameter("@RowCount", SqlDbType.Int)
                arr(2) = New SqlParameter("@TranType", SqlDbType.Int)
                arr(3) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                arr(4) = New SqlParameter("@userid", varuserid)
                arr(5) = New SqlParameter("@mastercompanyid", VarMasterCompanyID)
                arr(0).Value = VarPrtID
                arr(1).Value = gvdetail.Rows.Count
                arr(2).Value = 0
                arr(3).Direction = ParameterDirection.Output

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PROCESS_RAW_ISSUE_RECEIVE_DELETE", arr)
                If arr(3).Value.ToString() <> "" Then
                    MsgBox(arr(3).Value.ToString())
                End If

                Tran.Commit()
            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message)
            End Try
            Fill_GridSave()
        End If

    End Sub
    Private Sub DGConsumption_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGConsumption.CellEnter
        Select Case UCase(DGConsumption.Columns(e.ColumnIndex).Name)
            Case "ISSUEQTY"
                lblgridindex.Tag = e.RowIndex
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
                        'Return
                    End If
                End If
                DGConsumption.Item("Issueqty", e.RowIndex).Value = w_Weight
        End Select
    End Sub
    Protected Sub FillProcess_Employee(Optional ByVal sender As Object = Nothing)
        Dim str As String = "SELECT Top(1) EMP.ProcessId,EI.EmpId FROM EMPLOYEE_PROCESSORDERNO EMP INNER JOIN EMPINFO EI ON EMP.EMPID=EI.EMPID WHERE EI.EMPCODE='" & txtWeaverIdNoscan.Text & "'"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            DDProcessName.SelectedValue = ds.Tables(0).Rows(0)("Processid").ToString()
            DDProcessName_SelectedIndexChanged(sender, New EventArgs())
            Empid = ds.Tables(0).Rows(0)("empid")
        Else
            DDProcessName.SelectedIndex = -1
            MsgBox("Please Enter correct Emp. Code or No entry from this employee")
        End If
    End Sub

    Protected Sub FillIssueNo()
        Dim str As String = ""
        Select Case DDProcessName.SelectedValue.ToString()
            Case "1"
                str = "select Distinct PIM.IssueOrderId,PIM.ChallanNo as Issueorderid1 From Process_Issue_master_" & DDProcessName.SelectedValue & " PIM Left Join Employee_ProcessOrderNo EMP on PIM.issueorderid=EMP.issueorderid and EMP.Processid=" & DDProcessName.SelectedValue & " " & _
                     " left join empinfo ei on EMP.empid=Ei.empid " & _
                     "  Where PIM.status<>'canceled' And PIM.CompanyID = " & VarCompanyID
            Case Else
                If VarFINISHINGNEWMODULEWISE = "1" Then
                    str = "select Distinct PIM.IssueOrderId,PIM.ChallanNo as Issueorderid1 From Process_issue_Master_" & DDProcessName.SelectedValue & " PIM inner join Employee_ProcessOrderNo EMP on PIM.IssueOrderId=EMP.IssueOrderId and EMP.ProcessId=" & DDProcessName.SelectedValue & " " & _
                          "inner join empinfo ei on emp.empid=ei.empid " & _
                          " Where PIM.Status<>'canceled' And PIM.CompanyID = " & VarCompanyID
                Else
                    str = "select Distinct PIM.IssueOrderId,PIM.ChallanNo as Issueorderid1 From Process_Issue_master_" & DDProcessName.SelectedValue & " PIM Left Join Employee_ProcessOrderNo EMP on PIM.issueorderid=EMP.issueorderid and EMP.Processid=" & DDProcessName.SelectedValue & " " & _
                   " left join empinfo ei on EMP.empid=Ei.empid " & _
                   "  Where PIM.status<>'canceled' And PIM.CompanyID = " & VarCompanyID
                End If

        End Select
        If txtWeaverIdNoscan.Text <> "" Then
            str = str & " and EI.EMpcode='" & txtWeaverIdNoscan.Text & "'"
        End If

        If txtfolioNo.Text <> "" Then
            str = str & " and PIM.ChallanNo='" & txtfolioNo.Text & "'"
        End If
        If (VarMasterCompanyID = 16 Or VarMasterCompanyID = 28) Then
            str = str & " and PIM.Status <> 'Complete'"
        End If
        str = str & " order by Issueorderid Desc "
        Call NewComboFill(DDfoliono, str)
        'If DDfoliono.Items.Count > 0 Then DDfoliono.SelectedIndex = 0
    End Sub

    Private Sub DDProcessName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDProcessName.SelectedIndexChanged
        If DDProcessName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillIssueNo()
        End If

    End Sub

    Private Sub DDfoliono_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDfoliono.SelectedIndexChanged
        If DDfoliono.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If Validcombobox(DDProcessName) = False Then Exit Sub
            If Validcombobox(DDfoliono) = False Then Exit Sub
            Lblprmid.Text = "0"
            txtchalanno.Text = ""

            If (VarMasterCompanyID = "16" Or VarMasterCompanyID = "28") Then
                LblItemDesignName.Visible = True
                DDItemDesignName.Visible = True

                Call NewComboFill(DDItemDesignName, "Select Distinct VF.DesignID, VF.DesignName " & _
                " From PROCESS_ISSUE_DETAIL_" & DDProcessName.SelectedValue & " PID(Nolock) " & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = PID.Item_Finished_Id " & _
                " Where PID.IssueOrderId = " & DDfoliono.SelectedValue & " Order BY VF.DesignName ")
            End If

            Call fill_Grid()
            If chkforCone.Checked = True Then
                'Call Fill_Grid_Consmption_ConeType()
            Else
                Call Fill_Grid_Consmption()
            End If
        End If
    End Sub

    Private Sub DDItemDesignName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDItemDesignName.SelectedIndexChanged
        If DDItemDesignName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim param(4) As SqlParameter
            param(0) = New SqlParameter("@ISSUEORDERID", SqlDbType.Int)
            param(1) = New SqlParameter("@FLAGSTOCKAVGORNOT", SqlDbType.Int)
            param(2) = New SqlParameter("@ITEMDESCRIPTION", SqlDbType.NVarChar, 4000)
            param(3) = New SqlParameter("@DesignID", SqlDbType.Int)

            param(0).Value = DDfoliono.SelectedValue
            param(1).Direction = ParameterDirection.Output
            param(2).Direction = ParameterDirection.Output
            param(3).Value = DDItemDesignName.SelectedValue

            SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, "[PRO_CHECKFOLIOSTOCKCONSMPQTY]", param)

            If (param(1).Value = 1) Then
                Dim str As String = ""
                str = "50% Stock Not available" + param(2).Value
                MsgBox(str)
                DDItemDesignName.SelectedIndex = -1
                Return
            End If
        End If
    End Sub
    Private Sub txtWeaverIdNoscan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtWeaverIdNoscan.KeyDown
        If e.KeyCode = Keys.Enter Then
            FillProcess_Employee(sender)
        End If
    End Sub
    Private Sub DDBinNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDBinNo.SelectedIndexChanged
        If cmbgodown.SelectedIndex <> -1 And DDBinNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If chkforCone.Checked = True Then
                ' Call Fill_Grid_Consmption_ConeType()
            Else
                Call Fill_Grid_Consmption()
            End If
        End If
    End Sub
End Class
