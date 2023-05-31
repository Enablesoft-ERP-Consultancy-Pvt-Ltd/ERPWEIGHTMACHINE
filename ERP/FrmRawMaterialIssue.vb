Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading

Public Class FrmRawMaterialIssue
    'Public Con As New SqlClient.SqlConnection
    Dim unit As Integer
    Dim finishedid As Integer
    Dim CmbOperator1 As DataGridViewComboBoxCell
    Dim CmbOperator As DataGridViewComboBoxCell
    Dim issqty1 As Double
    Private Sub FrmRawMaterialIssue_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If

        show_Grid()
    End Sub
    Private Sub TxtFolioNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtfolioNo.TextChanged
    End Sub
    Private Sub ChkForIss_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkforCone.CheckedChanged
        show_Grid()
        '' ListBox1.Items.Add(New ListBoxItem("1", 1))
    End Sub
    Private Sub show_Grid()
        If chkforCone.Checked = True Then
            DGConsumption.Visible = False
            DGConsumptionConeType.Visible = True
            GroupBox3.Visible = False
            Call Fill_Grid_Consmption_ConeType()
        Else
            GroupBox3.Visible = True
            DGConsumption.Visible = True
            DGConsumptionConeType.Visible = False
        End If
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        txtfolioNo.Text = ""
        DGOrderdetail.Rows.Clear()
        DGConsumption.Rows.Clear()
        DGConsumptionConeType.Rows.Clear()
    End Sub
    Private Sub txtfolioNo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtfolioNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtfolioNo.Text <> "" Then
                Lblprmid.Text = "0"
                Call fill_Grid()
                If chkforCone.Checked = True Then
                    Call Fill_Grid_Consmption_ConeType()
                Else
                    Call Fill_Grid_Consmption()
                End If
            End If

        End If
    End Sub
    Private Sub fill_Grid()
        If Validtxtbox(txtfolioNo) = False Then Exit Sub
        Dim str As String = ""
        Dim ds As DataSet
        Dim i As Integer
        DGOrderdetail.Rows.Clear()
        str = "Select Issue_Detail_Id as IssueDetailId,vf.Category_Name as Category,vf.Item_Name as Articles,vf.ColorName As Color," & _
            " Length,Width,Width + 'x' + Length Size,Area,Rate,Qty,Amount,OrderId,PD.Item_Finished_Id,isnull(units,0) as units,pm.UserId,pm.Companyid " & _
            " From PROCESS_ISSUE_MASTER_1 PM,PROCESS_ISSUE_DETAIL_1 PD,V_FinishedItemDetail vf" & _
           " Where PM.IssueOrderid = PD.IssueOrderid And PD.Item_Finished_id = vf.Item_Finished_id and  PM.status<>'canceled' And PM.IssueOrderid = " & txtfolioNo.Text & " " & _
            " order By Issue_Detail_Id Desc"
        ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
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
            Next
        End If
    End Sub
    Private Sub Fill_Grid_Consmption()
        If Validtxtbox(txtfolioNo) = False Then Exit Sub
        Dim strsql As String
        Dim ds As DataSet
        Dim i As Integer
        DGConsumption.Rows.Clear()
     
        Dim Param(2) As SqlParameter
        Param(0) = New SqlParameter("@issueorderid", txtfolioNo.Text)
        Param(1) = New SqlParameter("@processid", 1)

        ds = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "Pro_RawMaterailIssueDataForANISA", Param)


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

                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("Godown"), DataGridViewComboBoxCell)
                Fill_Grid_Combo(CmbOperator, "Select Distinct GM.GodownID,GM.GodownName From GodownMaster GM,Stock S Where GM.GodownID=S.GodownID And QtyInHand>0 And CompanyId=1    Order By GodownName")
                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("lotno"), DataGridViewComboBoxCell)
                Select Case DGOrderdetail.Item("unitid", DGOrderdetail.Rows.Count - 1).Value
                    Case 1 ''Kanpur
                        Fill_Grid_Combo(CmbOperator, "select Lotno,LotNo From Stock Where CompanyId=1 and godownId=1 and Round(Qtyinhand,3)>0 And item_Finished_id=" & DGConsumption.Item("itemid", i).Value & " ")
                    Case 2 ''Biswan
                        Fill_Grid_Combo(CmbOperator, "select Lotno,LotNo From Stock Where CompanyId=1 and godownId=2 AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DGConsumption.Item("itemid", i).Value & " ")
                    Case 3  ''Laharpur
                        Fill_Grid_Combo(CmbOperator, "select Lotno,LotNo From Stock Where CompanyId=1 and godownId=3 AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DGConsumption.Item("itemid", i).Value & " ")
                    Case 4 ''Khairabad
                        Fill_Grid_Combo(CmbOperator, "select Lotno,LotNo From Stock Where CompanyId=1 and godownId=4 AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DGConsumption.Item("itemid", i).Value & " ")
                    Case 5 ''Ismailpur
                        Fill_Grid_Combo(CmbOperator, "select Lotno,LotNo From Stock Where CompanyId=1 and godownId=5 AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DGConsumption.Item("itemid", i).Value & " ")
                    Case Else
                        Fill_Grid_Combo(CmbOperator, "select Lotno,LotNo From Stock Where CompanyId=1 and godownId=1 AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DGConsumption.Item("itemid", i).Value & " ")
                End Select

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
    Private Sub Fill_Grid_Consmption_ConeType()
        If Validtxtbox(txtfolioNo) = False Then Exit Sub
        Dim str As String
        Dim ds As DataSet
        DGConsumptionConeType.Rows.Clear()
        str = "SELECT VF1.Category_Name,VF1.Item_Name,VF1.QualityName+Space(2)+VF1.DesignName+Space(2)+VF1.ColorName+Space(2)+VF1.ShapeName+Space(2)+" & _
                          "  CASE WHEN PM.UnitId=1 Then VF1.SizeMtr else VF1.SizeFt END+Space(2)+VF1.ShadeColorName Description," & _
                            " Isnull(Round(Sum(CASE WHEN PM.CalType=0 or PM.Caltype=2 THEN CASE WHEN PM.UnitId=1 Then PD.Qty*PD.Area*OCD.IQTY*1.196 else PD.Qty*PD.Area*OCD.IQTY END ELSE " & _
                            " CASE WHEN PM.UnitId=1 Then PD.Qty*OCD.IQTY else PD.Qty*OCD.IQTY END END),3),0) ConsmpQTY," & _
                            " [dbo].[Get_ProcessIssueQty] (OCD.IFINISHEDID,PM.Issueorderid) IssuedQty,Round(Isnull(Round(Sum(CASE WHEN PM.CalType=0 or PM.Caltype=2 THEN CASE WHEN " & _
                            " PM.UnitId=1 Then PD.Qty*PD.Area*OCD.IQTY*1.196 else PD.Qty*PD.Area*OCD.IQTY END ELSE CASE WHEN PM.UnitId=1 Then PD.Qty*OCD.IQTY else " & _
                            " PD.Qty*OCD.IQTY END END),3),0)-[dbo].[Get_ProcessIssueQty] (OCD.IFINISHEDID,PM.Issueorderid),3) PendQty,OCD.IFinishedid " & _
                            " FROM PROCESS_CONSUMPTION_DETAIL OCD,PROCESS_ISSUE_MASTER_1 PM,PROCESS_ISSUE_DETAIL_1 PD," & _
                            " V_FinishedItemDetail VF1 Where PM.IssueOrderid=PD.IssueOrderid And OCD.Issueorderid=PD.Issueorderid And OCD.Issue_Detail_Id=PD.Issue_Detail_Id And " & _
                             " VF1.ITEM_FINISHED_ID = OCD.IFINISHEDID And PM.Issueorderid =" + txtfolioNo.Text + " " & _
                            " Group By VF1.Category_Name,VF1.Item_Name,VF1.QualityName,VF1.DesignName,VF1.ColorName,VF1.ShapeName,PM.UnitId,VF1.SizeMtr,VF1.SizeFt," & _
                            " VF1.ShadeColorName,OCD.IFINISHEDID,PM.Issueorderid "
        ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                DGConsumptionConeType.Rows.Add()
                DGConsumptionConeType.Item("ItemName1", DGConsumptionConeType.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_Name")
                DGConsumptionConeType.Item("Description1", DGConsumptionConeType.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
                DGConsumptionConeType.Item("ConsmpQty1", DGConsumptionConeType.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ConsmpQTY")
                DGConsumptionConeType.Item("Issuedqty1", DGConsumptionConeType.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IssuedQty")
                DGConsumptionConeType.Item("PendQty1", DGConsumptionConeType.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("PendQty")
                DGConsumptionConeType.Item("FinishedId1", DGConsumptionConeType.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IFinishedid")
                CmbOperator1 = DirectCast(DGConsumptionConeType.Rows(i).Cells("Godown1"), DataGridViewComboBoxCell)
                Fill_Grid_Combo(CmbOperator1, "Select Distinct GM.GodownID,GM.GodownName From GodownMaster GM,Stock S Where GM.GodownID=S.GodownID And QtyInHand>0 And CompanyId=1    Order By GodownName")
                CmbOperator1 = DirectCast(DGConsumptionConeType.Rows(i).Cells("contype"), DataGridViewComboBoxCell)
                Fill_Grid_Combo(CmbOperator1, "select ID,ConeType+space(2)+'/'+cast(Qty as nvarchar)+'  '+'kg.' As ConeType From ConeType Where Item_FInished_id=" & DGConsumptionConeType.Item("finishedid1", i).Value & " order by ConeType")
                CmbOperator1 = DirectCast(DGConsumptionConeType.Rows(i).Cells("lotno1"), DataGridViewComboBoxCell)
                Select Case unit
                    Case 1
                        Fill_Grid_Combo(CmbOperator1, "select Lotno,LotNo From Stock Where CompanyId=1 and godownId=1 And item_Finished_id=" & DGConsumptionConeType.Item("FinishedId1", i).Value & " ")
                    Case 2
                        Fill_Grid_Combo(CmbOperator1, "select Lotno,LotNo From Stock Where CompanyId=1 and godownId=2 And item_Finished_id=" & DGConsumptionConeType.Item("FinishedId1", i).Value & " ")
                    Case 3
                        Fill_Grid_Combo(CmbOperator1, "select Lotno,LotNo From Stock Where CompanyId=1 and godownId=3 And item_Finished_id=" & DGConsumptionConeType.Item("FinishedId1", i).Value & " ")
                End Select

            Next
        End If
    End Sub
    'Private Sub DGConsumption_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGConsumption.CellContentClick
    '    Select Case DGConsumption.Columns(e.ColumnIndex).Name
    '        Case "save"
    '            If Con.State = ConnectionState.Closed Then Con.Open()
    '            Dim Tran As SqlTransaction = Con.BeginTransaction
    '            Try
    '                If Val(DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Value) = 0 Then
    '                    MsgBox("Plz select LotNo.....", MsgBoxStyle.OkOnly)
    '                    DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Selected = True
    '                    Tran.Commit()
    '                    Exit Sub
    '                End If

    '                If Val(DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Value) = 0 Then
    '                    MsgBox("Plz Enter Issue Qty.....", MsgBoxStyle.OkOnly, "Message")
    '                    DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Selected = True
    '                    Tran.Commit()
    '                    Exit Sub
    '                End If
    '                Dim godownid As Integer = 1
    '                Dim unit As Integer = Convert.ToInt32(DGOrderdetail.Item("unitid", DGOrderdetail.CurrentRow.Index).Value)
    '                Select Case Convert.ToInt32(unit)
    '                    Case 1
    '                        godownid = 1
    '                    Case 2
    '                        godownid = 2
    '                    Case 3
    '                        godownid = 3
    '                End Select
    '                Dim issqty As Double
    '                issqty = Convert.ToDouble(DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Value)
    '                Dim param(23) As SqlParameter
    '                param(0) = New SqlParameter("@PrmID", SqlDbType.Int)
    '                param(1) = New SqlParameter("@CompanyId", SqlDbType.Int)
    '                param(2) = New SqlParameter("@EmpId", SqlDbType.Int)
    '                param(3) = New SqlParameter("@ProcessId", SqlDbType.Int)
    '                param(4) = New SqlParameter("@OrderId", SqlDbType.Int)
    '                param(5) = New SqlParameter("@IssueDate", SqlDbType.SmallDateTime)
    '                param(6) = New SqlParameter("@ChalanNo", SqlDbType.NVarChar, 50)
    '                param(7) = New SqlParameter("@TranType", SqlDbType.Int)
    '                param(8) = New SqlParameter("@userid", SqlDbType.Int)
    '                param(9) = New SqlParameter("@mastercompanyid", SqlDbType.Int)
    '                param(10) = New SqlParameter("@Prtid", SqlDbType.Int)
    '                param(11) = New SqlParameter("@CategoryId", SqlDbType.Int)
    '                param(12) = New SqlParameter("@Itemid", SqlDbType.Int)
    '                param(13) = New SqlParameter("@FinishedId", SqlDbType.Int)
    '                param(14) = New SqlParameter("@GodownId", SqlDbType.Int)
    '                param(15) = New SqlParameter("@IssueQuantity", SqlDbType.Float)
    '                param(16) = New SqlParameter("@lotNo", SqlDbType.NVarChar, 50)
    '                param(17) = New SqlParameter("@UnitId", SqlDbType.Int)
    '                param(18) = New SqlParameter("@PrmIdOutPut", SqlDbType.Int)
    '                param(19) = New SqlParameter("@PrtIdOutPut", SqlDbType.Int)
    '                param(20) = New SqlParameter("@UpdateFlag", SqlDbType.Int)
    '                param(21) = New SqlParameter("@ConeTypeId", SqlDbType.Int)
    '                param(22) = New SqlParameter("@ItemRemarks", SqlDbType.VarChar, 500)

    '                If Lblprmid.Text = "" Then
    '                    Lblprmid.Text = "0"
    '                End If
    '                param(0).Value = Lblprmid.Text
    '                param(1).Value = 1 ' ddCompName.SelectedValue
    '                param(2).Value = 0 ' ddempname.SelectedValue
    '                param(3).Value = 1 ' ddProcessName.SelectedValue
    '                param(4).Value = txtfolioNo.Text ' ddOrderNo.SelectedValue
    '                param(5).Value = System.DateTime.Now.ToString("dd-MMM-yyyy")
    '                param(6).Value = "" ' txtchalanno.Text
    '                param(6).Direction = ParameterDirection.InputOutput
    '                param(7).Value = 0
    '                param(8).Value = varuserid 'Session("varuserid").ToString()
    '                param(9).Value = VarMasterCompanyID 'Session("VarMasterCompanyID").ToString()
    '                param(10).Value = 0
    '                param(11).Value = 2
    '                param(12).Value = 0
    '                param(13).Value = DGConsumption.Item("itemid", DGConsumption.CurrentRow.Index).Value  ''finished_id
    '                param(20).Value = 0
    '                param(14).Value = godownid
    '                param(15).Value = issqty
    '                param(16).Value = DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Value
    '                param(17).Value = 3 'Unit KG
    '                param(18).Direction = ParameterDirection.Output
    '                param(19).Direction = ParameterDirection.Output
    '                param(21).Value = 0 'conetypeId
    '                param(22).Value = Trim(Replace(DGConsumption.Item("Remarks", DGConsumption.CurrentRow.Index).Value, "'", "''"))
    '                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PROCESS_RAW_ISSUEForAnisha", param)
    '                'ByVal Item_Finished_Id As Integer, ByVal godownid As Integer, ByVal companyid As Integer, ByVal lotno As String, ByVal qty As Double, ByVal trandate As String, ByVal realdatetime As String, ByVal tablename As String, ByVal prtid As Integer, ByRef tran As SqlTransaction, ByVal trantype As Integer, ByVal BlnStockAddInQty As Boolean, ByVal typeid As Integer, ByVal Finish_Type As Integer
    '                Call Stock_update(Convert.ToInt16(param(13).Value), godownid, Convert.ToInt16(DGOrderdetail.Item("Comanyid", DGOrderdetail.CurrentRow.Index).Value), Val(DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Value), issqty, DateTime.Now.ToString("dd-MMM-yyyy"), DateTime.Now.ToString("dd-MMM-yyyy"), "ProcessRawTran", Convert.ToInt32(param(19).Value), Tran, 0, False, 1, 0)
    '                Tran.Commit()
    '                Lblprmid.Text = param(18).Value
    '                Call Fill_Grid_Consmption()
    '                MsgBox("Consumption Saved Successfully....")
    '            Catch ex As Exception
    '                Tran.Rollback()
    '                MsgBox(ex.Message)
    '            End Try
    '    End Select
    'End Sub
    Private Sub DGConsumption_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGConsumption.EditingControlShowing
        If DGConsumption.CurrentCell.ColumnIndex = 7 Then
            Dim cmbLotno As ComboBox = CType(e.Control, ComboBox)
            If (cmbLotno IsNot Nothing) Then
                RemoveHandler cmbLotno.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_lotno)
                AddHandler cmbLotno.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_lotno)
            End If
        End If

    End Sub

    Private Sub ComboBox_SelectionChangeCommitted_lotno(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim godownid As Integer = 1
        Dim unit As Integer = Convert.ToInt32(DGOrderdetail.Item("unitid", DGOrderdetail.CurrentRow.Index).Value)
        Select Case Convert.ToInt32(unit)
            Case 1
                godownid = 1
            Case 2
                godownid = 2
            Case 3
                godownid = 3
        End Select
        Dim cmbLotno As ComboBox = CType(sender, ComboBox)
        Dim str As String
        Dim stkqty As Double
        str = "select Round(isnull(Qtyinhand,0),3) As Stock from Stock Where godownId=" & godownid & "  and CompanyId=1 And LotNo='" & cmbLotno.SelectedValue & "'  And Item_Finished_id=" & DGConsumption.Item("Itemid", DGConsumption.CurrentRow.Index).Value & " "
        stkqty = SqlHelper.ExecuteScalar(Con, CommandType.Text, str)
        DGConsumption.Item("stockqty", DGConsumption.CurrentRow.Index).Value = stkqty
    End Sub

    'Private Sub DGConsumptionConeType_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGConsumptionConeType.CellClick
    '    Select Case DGConsumptionConeType.Columns(e.ColumnIndex).Name
    '        Case "Save1"
    '            If Con.State = 0 Then Con.Open()
    '            Dim Tran As SqlTransaction = Con.BeginTransaction
    '            Try
    '                If Val(DGConsumptionConeType.Item("lotno1", DGConsumptionConeType.CurrentRow.Index).Value) = 0 Then
    '                    MsgBox("Plz select LotNo.....", MsgBoxStyle.OkOnly)
    '                    DGConsumptionConeType.Item("lotno1", DGConsumptionConeType.CurrentRow.Index).Selected = True
    '                    Tran.Commit()
    '                    Exit Sub
    '                End If
    '                If Val(DGConsumptionConeType.Item("contype", DGConsumptionConeType.CurrentRow.Index).Value) = 0 Then
    '                    MsgBox("Plz select ConeType...", MsgBoxStyle.OkOnly)
    '                    DGConsumptionConeType.Item("contype", DGConsumptionConeType.CurrentRow.Index).Selected = True
    '                    Exit Sub
    '                    Tran.Commit()
    '                    Exit Sub
    '                End If
    '                If Val(DGConsumptionConeType.Item("noofcones", DGConsumptionConeType.CurrentRow.Index).Value) = 0 Then
    '                    MsgBox("Plz fill No. of Cones...", MsgBoxStyle.OkOnly)
    '                    DGConsumptionConeType.Item("noofcones", DGConsumptionConeType.CurrentRow.Index).Selected = True
    '                    Tran.Commit()
    '                    Exit Sub
    '                End If
    '                If Val(DGConsumptionConeType.Item("Issueqty1", DGConsumptionConeType.CurrentRow.Index).Value) = 0 Then
    '                    MsgBox("Plz fill issue Qty...", MsgBoxStyle.OkOnly)
    '                    DGConsumptionConeType.Item("issueqty1", DGConsumptionConeType.CurrentRow.Index).Selected = True
    '                    Tran.Commit()
    '                    Exit Sub
    '                End If
    '                Dim godownid As Integer = 1
    '                Dim unit As Integer = Convert.ToInt32(DGOrderdetail.Item("unitid", DGOrderdetail.CurrentRow.Index).Value)
    '                Select Case Convert.ToInt32(unit)
    '                    Case 1
    '                        godownid = 1
    '                    Case 2
    '                        godownid = 2
    '                    Case 3
    '                        godownid = 3
    '                End Select

    '                issqty1 = DGConsumptionConeType.Item("Issueqty1", DGConsumptionConeType.CurrentRow.Index).Value

    '                Dim contype As Integer
    '                Dim str As String
    '                Dim ds As DataSet
    '                Dim conqty As Double = 0
    '                Dim NoofCones As Double = DGConsumptionConeType.Item("noofcones", DGConsumptionConeType.CurrentRow.Index).Value
    '                contype = Val(DGConsumptionConeType.Item("contype", DGConsumptionConeType.CurrentRow.Index).Value)
    '                If contype > 0 Then
    '                    str = "select LotNo,Qty from Conetype Where id=" & contype & ""
    '                    ds = SqlHelper.ExecuteDataset(Tran, CommandType.Text, str)
    '                    If ds.Tables(0).Rows.Count > 0 Then
    '                        conqty = Convert.ToDouble(ds.Tables(0).Rows(0)("Qty"))
    '                        ' IssueQty = IssueQty - (ConeQty * NoofCones);
    '                        issqty1 = issqty1 - (conqty * NoofCones)
    '                    End If
    '                End If

    '                Dim param(23) As SqlParameter
    '                param(0) = New SqlParameter("@PrmID", SqlDbType.Int)
    '                param(1) = New SqlParameter("@CompanyId", SqlDbType.Int)
    '                param(2) = New SqlParameter("@EmpId", SqlDbType.Int)
    '                param(3) = New SqlParameter("@ProcessId", SqlDbType.Int)
    '                param(4) = New SqlParameter("@OrderId", SqlDbType.Int)
    '                param(5) = New SqlParameter("@IssueDate", SqlDbType.SmallDateTime)
    '                param(6) = New SqlParameter("@ChalanNo", SqlDbType.NVarChar, 50)
    '                param(7) = New SqlParameter("@TranType", SqlDbType.Int)
    '                param(8) = New SqlParameter("@userid", SqlDbType.Int)
    '                param(9) = New SqlParameter("@mastercompanyid", SqlDbType.Int)
    '                param(10) = New SqlParameter("@Prtid", SqlDbType.Int)
    '                param(11) = New SqlParameter("@CategoryId", SqlDbType.Int)
    '                param(12) = New SqlParameter("@Itemid", SqlDbType.Int)
    '                param(13) = New SqlParameter("@FinishedId", SqlDbType.Int)
    '                param(14) = New SqlParameter("@GodownId", SqlDbType.Int)
    '                param(15) = New SqlParameter("@IssueQuantity", SqlDbType.Float)
    '                param(16) = New SqlParameter("@lotNo", SqlDbType.NVarChar, 50)
    '                param(17) = New SqlParameter("@UnitId", SqlDbType.Int)
    '                param(18) = New SqlParameter("@PrmIdOutPut", SqlDbType.Int)
    '                param(19) = New SqlParameter("@PrtIdOutPut", SqlDbType.Int)
    '                param(20) = New SqlParameter("@UpdateFlag", SqlDbType.Int)
    '                param(21) = New SqlParameter("@ConeTypeId", SqlDbType.Int)
    '                param(22) = New SqlParameter("@ItemRemarks", SqlDbType.VarChar, 500)

    '                If Lblprmid.Text = "" Then
    '                    Lblprmid.Text = "0"
    '                End If
    '                param(0).Value = Lblprmid.Text
    '                param(1).Value = 1 ' ddCompName.SelectedValue
    '                param(2).Value = 0 ' ddempname.SelectedValue
    '                param(3).Value = 1 ' ddProcessName.SelectedValue
    '                param(4).Value = txtfolioNo.Text ' ddOrderNo.SelectedValue
    '                param(5).Value = System.DateTime.Now.ToString("dd-MMM-yyyy")
    '                param(6).Value = "" ' txtchalanno.Text
    '                param(6).Direction = ParameterDirection.InputOutput
    '                param(7).Value = 0
    '                param(8).Value = varuserid 'Session("varuserid").ToString()
    '                param(9).Value = VarMasterCompanyID 'Session("VarMasterCompanyID").ToString()
    '                param(10).Value = 0
    '                param(11).Value = 2
    '                param(12).Value = 0
    '                param(13).Value = DGConsumptionConeType.Item("FinishedId1", DGConsumptionConeType.CurrentRow.Index).Value  ''finished_id
    '                param(20).Value = 0
    '                param(14).Value = godownid
    '                param(15).Value = issqty1
    '                param(16).Value = Val(DGConsumptionConeType.Item("lotno1", DGConsumptionConeType.CurrentRow.Index).Value)
    '                param(17).Value = 3 'Unit KG
    '                param(18).Direction = ParameterDirection.Output
    '                param(19).Direction = ParameterDirection.Output
    '                param(21).Value = Val(DGConsumptionConeType.Item("contype", DGConsumptionConeType.CurrentRow.Index).Value) 'conetypeId
    '                param(22).Value = Trim(DGConsumptionConeType.Item("Remarks1", DGConsumptionConeType.CurrentRow.Index).Value)
    '                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PROCESS_RAW_ISSUEForAnisha", param)
    '                'ByVal Item_Finished_Id As Integer, ByVal godownid As Integer, ByVal companyid As Integer, ByVal lotno As String, ByVal qty As Double, ByVal trandate As String, ByVal realdatetime As String, ByVal tablename As String, ByVal prtid As Integer, ByRef tran As SqlTransaction, ByVal trantype As Integer, ByVal BlnStockAddInQty As Boolean, ByVal typeid As Integer, ByVal Finish_Type As Integer
    '                Call Stock_update(Convert.ToInt16(param(13).Value), godownid, Convert.ToInt16(DGOrderdetail.Item("Comanyid", DGOrderdetail.CurrentRow.Index).Value), Val(DGConsumptionConeType.Item("lotno1", DGConsumptionConeType.CurrentRow.Index).Value), issqty1, DateTime.Now.ToString("dd-MMM-yyyy"), DateTime.Now.ToString("dd-MMM-yyyy"), "ProcessRawTran", Convert.ToInt32(param(19).Value), Tran, 0, False, 1, 0)
    '                Tran.Commit()
    '                Lblprmid.Text = param(18).Value
    '                Call Fill_Grid_Consmption_ConeType()
    '                MsgBox("Consumption Saved Successfully....")
    '            Catch ex As Exception
    '                Tran.Rollback()
    '                MsgBox(ex.Message)
    '            End Try
    '    End Select
    'End Sub
    Private Sub DGConsumptionConeType_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGConsumptionConeType.EditingControlShowing
        If DGConsumptionConeType.CurrentCell.ColumnIndex = 7 Then
            Dim cmbLotno1 As ComboBox = CType(e.Control, ComboBox)
            If (cmbLotno1 IsNot Nothing) Then
                RemoveHandler cmbLotno1.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_lotno_contype)
                AddHandler cmbLotno1.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted_lotno_contype)
            End If
        End If
    End Sub
    Private Sub ComboBox_SelectionChangeCommitted_lotno_contype(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DGConsumptionConeType.CurrentCell.ColumnIndex = 7 Then
            Dim godownid As Integer = 1
            Dim unit As Integer = Convert.ToInt32(DGOrderdetail.Item("unitid", DGOrderdetail.CurrentRow.Index).Value)
            Select Case Convert.ToInt32(unit)
                Case 1
                    godownid = 1
                Case 2
                    godownid = 2
                Case 3
                    godownid = 3
            End Select
            Dim cmbLotno1 As ComboBox = CType(sender, ComboBox)
            Dim str As String
            Dim stkqty As Double
            str = "select Round(isnull(Qtyinhand,0),3) As Stock from Stock Where godownId=" & godownid & "  and CompanyId=1 And LotNo='" & cmbLotno1.SelectedValue & "'  And Item_Finished_id=" & DGConsumptionConeType.Item("FinishedId1", DGConsumptionConeType.CurrentRow.Index).Value & " "
            'select Round(isnull(Qtyinhand,0),3) As Stock from Stock Where godownId=" + godownId + " and CompanyId=1 And LotNo='" + ddllotno.SelectedItem.Text + "'  And Item_Finished_id=" + itemFinishedid + 
            stkqty = SqlHelper.ExecuteScalar(Con, CommandType.Text, str)
            DGConsumptionConeType.Item("Stockqty1", DGConsumptionConeType.CurrentRow.Index).Value = stkqty
        End If
    End Sub

    Event DGConsumptionButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
    Dim _serialPort As SerialPort
    Private Delegate Sub SetTextDeleg(text As String)
    Private Sub DGConsumption_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGConsumption.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DGConsumptionButtonClick(senderGrid, e)
            DGConsumption.Item("issueqty", lblgridindex.Tag).Value = ""
            _serialPort.Close()
            _serialPort = Nothing
        End If
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewLinkColumn AndAlso e.RowIndex >= 0 Then
            lblgridindex.Tag = e.RowIndex
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
                    DGConsumption_CellContentClick(sender, e)
                    Return
                End If
            End If
        End If
    End Sub
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

        If Con.State = ConnectionState.Closed Then Con.Open()
        Dim Tran As SqlTransaction = Con.BeginTransaction
        Try
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
            Dim issqty As Double
            issqty = Convert.ToDouble(DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Value)
            Dim param(24) As SqlParameter
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
            param(21) = New SqlParameter("@ConeTypeId", SqlDbType.Int)
            param(22) = New SqlParameter("@ItemRemarks", SqlDbType.VarChar, 500)
            param(23) = New SqlParameter("@Msg", SqlDbType.VarChar, 200)
            param(23).Direction = ParameterDirection.Output
            If Lblprmid.Text = "" Then
                Lblprmid.Text = "0"
            End If
            param(0).Value = Lblprmid.Text
            param(1).Value = 1 ' ddCompName.SelectedValue
            param(2).Value = 0 ' ddempname.SelectedValue
            param(3).Value = 1 ' ddProcessName.SelectedValue
            param(4).Value = txtfolioNo.Text ' ddOrderNo.SelectedValue
            param(5).Value = System.DateTime.Now.ToString("dd-MMM-yyyy")
            param(6).Value = "" ' txtchalanno.Text
            param(6).Direction = ParameterDirection.InputOutput
            param(7).Value = 0
            param(8).Value = varuserid 'Session("varuserid").ToString()
            param(9).Value = VarMasterCompanyID 'Session("VarMasterCompanyID").ToString()
            param(10).Value = 0
            param(11).Value = 2
            param(12).Value = 0
            param(13).Value = DGConsumption.Item("itemid", DGConsumption.CurrentRow.Index).Value  ''finished_id
            param(20).Value = 0
            param(14).Value = godownid
            param(15).Value = issqty
            param(16).Value = DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Value
            param(17).Value = 3 'Unit KG
            param(18).Direction = ParameterDirection.Output
            param(19).Direction = ParameterDirection.Output
            param(21).Value = 0 'conetypeId
            param(22).Value = Trim(Replace(DGConsumption.Item("Remarks", DGConsumption.CurrentRow.Index).Value, "'", "''"))
            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PROCESS_RAW_ISSUEForAnisha", param)
            'ByVal Item_Finished_Id As Integer, ByVal godownid As Integer, ByVal companyid As Integer, ByVal lotno As String, ByVal qty As Double, ByVal trandate As String, ByVal realdatetime As String, ByVal tablename As String, ByVal prtid As Integer, ByRef tran As SqlTransaction, ByVal trantype As Integer, ByVal BlnStockAddInQty As Boolean, ByVal typeid As Integer, ByVal Finish_Type As Integer
            If param(23).Value.ToString() = "" Then
                Call Stock_update(Convert.ToInt16(param(13).Value), godownid, Convert.ToInt16(DGOrderdetail.Item("Comanyid", DGOrderdetail.CurrentRow.Index).Value), Val(DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Value), issqty, DateTime.Now.ToString("dd-MMM-yyyy"), DateTime.Now.ToString("dd-MMM-yyyy"), "ProcessRawTran", Convert.ToInt32(param(19).Value), Tran, 0, False, 1, 0)
                Tran.Commit()
                Lblprmid.Text = param(18).Value
                Call Fill_Grid_Consmption()
                MsgBox("Consumption Saved Successfully....")
            Else
                MsgBox(param(23).Value.ToString())
                Tran.Commit()
            End If

        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    ' Event DGConsumptionButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
    Event DGConsumptionConeTypeButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
    Private Sub DGConsumptionConeType_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGConsumptionConeType.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DGConsumptionConeTypeButtonClick(senderGrid, e)
        End If
    End Sub
    Private Sub DGConsumptionConeType_ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles Me.DGConsumptionConeTypeButtonClick
        If Con.State = 0 Then Con.Open()
        Dim Tran As SqlTransaction = Con.BeginTransaction
        Try
            If Val(DGConsumptionConeType.Item("lotno1", DGConsumptionConeType.CurrentRow.Index).Value) = 0 Then
                MsgBox("Plz select LotNo.....", MsgBoxStyle.OkOnly)
                DGConsumptionConeType.Item("lotno1", DGConsumptionConeType.CurrentRow.Index).Selected = True
                Tran.Commit()
                Exit Sub
            End If
            If Val(DGConsumptionConeType.Item("contype", DGConsumptionConeType.CurrentRow.Index).Value) = 0 Then
                MsgBox("Plz select ConeType...", MsgBoxStyle.OkOnly)
                DGConsumptionConeType.Item("contype", DGConsumptionConeType.CurrentRow.Index).Selected = True
                Exit Sub
                Tran.Commit()
                Exit Sub
            End If
            If Val(DGConsumptionConeType.Item("noofcones", DGConsumptionConeType.CurrentRow.Index).Value) = 0 Then
                MsgBox("Plz fill No. of Cones...", MsgBoxStyle.OkOnly)
                DGConsumptionConeType.Item("noofcones", DGConsumptionConeType.CurrentRow.Index).Selected = True
                Tran.Commit()
                Exit Sub
            End If
            If Val(DGConsumptionConeType.Item("Issueqty1", DGConsumptionConeType.CurrentRow.Index).Value) = 0 Then
                MsgBox("Plz fill issue Qty...", MsgBoxStyle.OkOnly)
                DGConsumptionConeType.Item("issueqty1", DGConsumptionConeType.CurrentRow.Index).Selected = True
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
            End Select

            issqty1 = DGConsumptionConeType.Item("Issueqty1", DGConsumptionConeType.CurrentRow.Index).Value

            Dim contype As Integer
            Dim str As String
            Dim ds As DataSet
            Dim conqty As Double = 0
            Dim NoofCones As Double = DGConsumptionConeType.Item("noofcones", DGConsumptionConeType.CurrentRow.Index).Value
            contype = Val(DGConsumptionConeType.Item("contype", DGConsumptionConeType.CurrentRow.Index).Value)
            If contype > 0 Then
                str = "select LotNo,Qty from Conetype Where id=" & contype & ""
                ds = SqlHelper.ExecuteDataset(Tran, CommandType.Text, str)
                If ds.Tables(0).Rows.Count > 0 Then
                    conqty = Convert.ToDouble(ds.Tables(0).Rows(0)("Qty"))
                    ' IssueQty = IssueQty - (ConeQty * NoofCones);
                    issqty1 = issqty1 - (conqty * NoofCones)
                End If
            End If

            Dim param(23) As SqlParameter
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
            param(21) = New SqlParameter("@ConeTypeId", SqlDbType.Int)
            param(22) = New SqlParameter("@ItemRemarks", SqlDbType.VarChar, 500)

            If Lblprmid.Text = "" Then
                Lblprmid.Text = "0"
            End If
            param(0).Value = Lblprmid.Text
            param(1).Value = 1 ' ddCompName.SelectedValue
            param(2).Value = 0 ' ddempname.SelectedValue
            param(3).Value = 1 ' ddProcessName.SelectedValue
            param(4).Value = txtfolioNo.Text ' ddOrderNo.SelectedValue
            param(5).Value = System.DateTime.Now.ToString("dd-MMM-yyyy")
            param(6).Value = "" ' txtchalanno.Text
            param(6).Direction = ParameterDirection.InputOutput
            param(7).Value = 0
            param(8).Value = varuserid 'Session("varuserid").ToString()
            param(9).Value = VarMasterCompanyID 'Session("VarMasterCompanyID").ToString()
            param(10).Value = 0
            param(11).Value = 2
            param(12).Value = 0
            param(13).Value = DGConsumptionConeType.Item("FinishedId1", DGConsumptionConeType.CurrentRow.Index).Value  ''finished_id
            param(20).Value = 0
            param(14).Value = godownid
            param(15).Value = issqty1
            param(16).Value = Val(DGConsumptionConeType.Item("lotno1", DGConsumptionConeType.CurrentRow.Index).Value)
            param(17).Value = 3 'Unit KG
            param(18).Direction = ParameterDirection.Output
            param(19).Direction = ParameterDirection.Output
            param(21).Value = Val(DGConsumptionConeType.Item("contype", DGConsumptionConeType.CurrentRow.Index).Value) 'conetypeId
            param(22).Value = Trim(DGConsumptionConeType.Item("Remarks1", DGConsumptionConeType.CurrentRow.Index).Value)
            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PROCESS_RAW_ISSUEForAnisha", param)
            'ByVal Item_Finished_Id As Integer, ByVal godownid As Integer, ByVal companyid As Integer, ByVal lotno As String, ByVal qty As Double, ByVal trandate As String, ByVal realdatetime As String, ByVal tablename As String, ByVal prtid As Integer, ByRef tran As SqlTransaction, ByVal trantype As Integer, ByVal BlnStockAddInQty As Boolean, ByVal typeid As Integer, ByVal Finish_Type As Integer
            Call Stock_update(Convert.ToInt16(param(13).Value), godownid, Convert.ToInt16(DGOrderdetail.Item("Comanyid", DGOrderdetail.CurrentRow.Index).Value), Val(DGConsumptionConeType.Item("lotno1", DGConsumptionConeType.CurrentRow.Index).Value), issqty1, DateTime.Now.ToString("dd-MMM-yyyy"), DateTime.Now.ToString("dd-MMM-yyyy"), "ProcessRawTran", Convert.ToInt32(param(19).Value), Tran, 0, False, 1, 0)
            Tran.Commit()
            Lblprmid.Text = param(18).Value
            Call Fill_Grid_Consmption_ConeType()
            MsgBox("Consumption Saved Successfully....")
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BtnPreview_Click(sender As System.Object, e As System.EventArgs) Handles BtnPreview.Click

        Dim _array(4) As SqlParameter
        _array(0) = New SqlParameter("@IssueOrderId", SqlDbType.Int)
        _array(1) = New SqlParameter("@ProcessId", SqlDbType.Int)
        _array(2) = New SqlParameter("@Trantype", SqlDbType.Int)

        _array(0).Value = txtfolioNo.Text
        _array(1).Value = 1 'For IST Process
        _array(2).Value = 0 'For Issue

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "[Pro_OrderFolio_IssuedSlip]", _array)

        If ds.Tables(1).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptOrderFolio_Issuedslip.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptOrderFolio_Issuedslip.xsd")
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
            MsgBox("No Record Found...", MsgBoxStyle.OkOnly)
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
            _serialPort.Close()
            _serialPort = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmb_port_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmb_port.SelectedIndexChanged

    End Sub
End Class
