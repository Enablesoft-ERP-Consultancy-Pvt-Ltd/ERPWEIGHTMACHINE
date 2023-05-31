Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading

Public Class FrmRecipeRawMaterialIssue
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
        Call NewComboFill(DDCompanyName, "Select Distinct CI.CompanyId, CI.CompanyName " & _
                          " From Companyinfo CI(Nolock) " & _
                          " Where CI.MasterCompanyId = " & VarMasterCompanyID & " Order By CI.CompanyName ")
        If DDCompanyName.Items.Count > 0 Then DDCompanyName.SelectedValue = 1

        Call NewComboFill(DDProcessName, "Select Distinct a.ProcessID, PNM.PROCESS_NAME " & _
                    " From RecipeSlipGenerationMaster a(Nolock)  " & _
                    " JOIN PROCESS_NAME_MASTER PNM(Nolock) ON PNM.PROCESS_NAME_ID = a.ProcessID  " & _
                    " Where a.MasterCompanyID = " & VarMasterCompanyID & " And a.CompanyID = " & DDCompanyName.SelectedValue & "")
        If DDProcessName.Items.Count > 0 Then
            DDProcessName.SelectedValue = 29
            ProcessSelectedChanged()
            DDSlipNo.Focus()
        End If

        Call NewComboFill(cmbgodown, "select GoDownID, GodownName From GodownMaster Order By GodownName")
        If cmbgodown.Items.Count > 0 Then cmbgodown.SelectedValue = 15
        If VarBINNOWISE = "1" Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If
    End Sub

    Private Sub DDCompanyName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDCompanyName.SelectedIndexChanged
        If DDCompanyName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            CompanyId = DDCompanyName.SelectedValue
        End If
    End Sub

    Private Sub DDProcessName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDProcessName.SelectedIndexChanged
        ProcessSelectedChanged()
    End Sub
    Private Sub ProcessSelectedChanged()
        If DDProcessName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Call NewComboFill(DDSlipNo, "Select Distinct a.SlipNo, a.SlipNo SlipNo1 " & _
                    " From RecipeSlipGenerationMaster a(Nolock)  " & _
                    " Where a.MasterCompanyID = " & VarMasterCompanyID & " And a.CompanyID = " & DDCompanyName.SelectedValue & " And " & _
                    " a.ProcessID = " & DDProcessName.SelectedValue & " Order By a.SlipNo")
        End If
    End Sub

    Private Sub DDSlipNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDSlipNo.SelectedIndexChanged
        If DDSlipNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Call NewComboFill(DDRecipeName, "Select a.ID, RM.Name " & _
                    " From RecipeSlipGenerationMaster a(Nolock) " & _
                    " JOIN RecipeMaster RM(Nolock) ON RM.ID = a.RecipeMasterID " & _
                    " Where a.MasterCompanyID = " & VarMasterCompanyID & " And a.CompanyID = " & DDCompanyName.SelectedValue & " And " & _
                    " a.ProcessID = " & DDProcessName.SelectedValue & " And a.SlipNo = " & DDSlipNo.SelectedValue & " " & _
                    " Order By RM.Name")
        End If
    End Sub

    Private Sub DDRecipeName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDRecipeName.SelectedIndexChanged
        If DDRecipeName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Fill_Grid_New()
        End If
    End Sub
    Private Sub Fill_Grid_New()
        If Validcombobox(DDSlipNo) = False Then Exit Sub
        If Validcombobox(DDRecipeName) = False Then Exit Sub

        Dim ds As DataSet
        Dim i As Integer
        DGConsumption.Rows.Clear()

        Dim Param(2) As SqlParameter
        Param(0) = New SqlParameter("@SlipNo", DDSlipNo.SelectedValue)
        Param(1) = New SqlParameter("@RecipeMasterID", DDRecipeName.SelectedValue)

        ds = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "[Pro_Get_RecipeRawMaterialIssueDetail]", Param)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                DGConsumption.Rows.Add()
                DGConsumption.Item("Description", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ItemDescription")
                DGConsumption.Item("ConsmpQty", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ConsmpQty")
                DGConsumption.Item("Issuedqty", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IssuedQty")
                DGConsumption.Item("PendQty", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("BalanceQty")
                'FinishedId = ds.Tables(0).Rows(i)("IFinishedid")
                DGConsumption.Item("Item_Finished_ID", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_Finished_ID")
                DGConsumption.Item("UnitID", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("UnitID")
                DGConsumption.Item("ID", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ID")

                'CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("Godown"), DataGridViewComboBoxCell)

                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("lotno"), DataGridViewComboBoxCell)

                If cmbgodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                    Dim str As String = "select Lotno,LotNo From Stock Where CompanyId=" & CompanyId & " and godownId=" & cmbgodown.SelectedValue & " AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DGConsumption.Item("Item_Finished_ID", i).Value & " "
                    If DDBinNo.Visible = True Then
                        str = str & " and BinNo='" + DDBinNo.Text + "'"
                    End If

                    Fill_Grid_Combo(CmbOperator, str)
                End If
                ''TAGNO
                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("TagNo"), DataGridViewComboBoxCell)

                If cmbgodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                    Dim str As String = "select TAGNO,TAGNO From Stock Where CompanyId=" & CompanyId & " and godownId=" & cmbgodown.SelectedValue & " AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DGConsumption.Item("Item_Finished_ID", i).Value & " "
                    If DDBinNo.Visible = True Then
                        str = str & " and BinNo='" + DDBinNo.Text + "'"
                    End If

                    Fill_Grid_Combo(CmbOperator, str)
                End If
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
        stkqty = Module1.getstockQty(CompanyId.ToString(), godownid, cmbLotno.SelectedValue, DGConsumption.Item("Item_Finished_ID", DGConsumption.CurrentRow.Index).Value)
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
        stkqty = Module1.getstockQty(CompanyId.ToString(), godownid, Lotno, DGConsumption.Item("Item_Finished_ID", DGConsumption.CurrentRow.Index).Value, TagNo, BinNo:=IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))
        DGConsumption.Item("stockqty", DGConsumption.CurrentRow.Index).Value = stkqty
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
        If Validcombobox(cmbgodown) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

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
            Dim unit As Integer = Convert.ToInt32(DGConsumption.Item("unitid", DGConsumption.CurrentRow.Index).Value)
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
            Dim Str As String = ""
            issqty = Convert.ToDouble(DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Value)

            Str = Str & DGConsumption.Item("Item_Finished_ID", DGConsumption.CurrentRow.Index).Value & "|" & DGConsumption.Item("unitid", DGConsumption.CurrentRow.Index).Value & "|" & cmbgodown.SelectedValue & "|" & DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Value & "|" & DGConsumption.Item("TagNo", DGConsumption.CurrentRow.Index).Value & "|" & issqty & "|" & DGConsumption.Item("ConsmpQty", DGConsumption.CurrentRow.Index).Value & "|" & DDBinNo.Text & "~"

            Dim param(27) As SqlParameter
            param(0) = New SqlParameter("@PrmId", SqlDbType.Int)
            param(1) = New SqlParameter("@CompanyID", SqlDbType.Int)
            param(2) = New SqlParameter("@ProcessID", SqlDbType.Int)
            param(3) = New SqlParameter("@SlipID", SqlDbType.Int)
            param(4) = New SqlParameter("@RecipeMasterID", SqlDbType.Int)
            param(5) = New SqlParameter("@IssueNo", SqlDbType.Int)
            param(6) = New SqlParameter("@IssueDate", SqlDbType.SmallDateTime)
            param(7) = New SqlParameter("@EWayBillNo", SqlDbType.NVarChar, 15)
            param(8) = New SqlParameter("@TranType", SqlDbType.Int)
            param(9) = New SqlParameter("@DetailData", SqlDbType.NVarChar, 4000)
            param(10) = New SqlParameter("@UserID", SqlDbType.Int)
            param(11) = New SqlParameter("@MasterCompanyID", SqlDbType.Int)
            param(12) = New SqlParameter("@msg", SqlDbType.VarChar, 100)

            If Lblprmid.Text = "" Then
                Lblprmid.Text = "0"
            End If
            param(0).Value = Lblprmid.Text
            param(0).Direction = ParameterDirection.Output
            param(1).Value = DDCompanyName.SelectedValue
            param(2).Value = DDProcessName.SelectedValue
            param(3).Value = DDSlipNo.SelectedValue
            param(4).Value = DDRecipeName.SelectedValue
            param(5).Value = IIf(txtchalanno.Text = "", 0, txtchalanno.Text)
            param(6).Value = System.DateTime.Now.ToString("dd-MMM-yyyy")
            param(7).Value = ""
            param(8).Value = 0
            param(9).Value = Str
            param(10).Value = varuserid 'Session("varuserid").ToString()
            param(11).Value = VarMasterCompanyID 'Session("VarMasterCompanyID").ToString()
            param(12).Direction = ParameterDirection.Output

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "[PRO_SaveRecipeSlipGenerationRawMaterialIssue]", param)

            Tran.Commit()
            txtchalanno.Text = param(0).Value
            Lblprmid.Text = param(0).Value
            If (param(12).Value.ToString() <> "") Then
                MsgBox(param(12).Value.ToString())
            Else
                MsgBox("DATA SAVED SUCCESSFULLY.")
                Fill_GridSave()
            End If

        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    ' Event DGConsumptionButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
    Event DGConsumptionConeTypeButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)

    Private Sub DGConsumptionConeType_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DGConsumptionConeTypeButtonClick(senderGrid, e)
        End If
    End Sub

    Private Sub BtnPreview_Click(sender As System.Object, e As System.EventArgs) Handles BtnPreview.Click

        Dim Param(2) As SqlParameter
        Param(0) = New SqlParameter("@processid", DDProcessName.SelectedValue)
        Param(1) = New SqlParameter("@Prmid", Lblprmid.Text)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "[PRO_RECIPE_RAWMATERIAL_ISSUE]", Param)
        If ds.Tables(0).Rows.Count > 0 Then

            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptRecipeRawMaterialIssue.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptRecipeRawMaterialIssue.xsd")
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
        If cmbgodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If VarBINNOWISE = "1" Then
                Dim Str As String
                Str = "Select Distinct S.BinNo, S.BinNo " & _
                    " From Stock S(Nolock) " & _
                    " JOIN RecipeSlipGenerationConsumption RSC(Nolock) ON RSC.Item_Finished_ID = S.ITEM_FINISHED_ID"

                If (DDRecipeName.Items.Count > 0 And DDRecipeName.SelectedIndex <> -1) Then
                    Str = Str & " And RSC.ID = " & DDRecipeName.SelectedValue & " "
                End If

                Str = Str & " Where S.Companyid = " & DDCompanyName.SelectedValue & " And S.Godownid = " & cmbgodown.SelectedValue & " " & _
                    " And S.Qtyinhand > 0 "
                Call NewComboFill(DDBinNo, Str)
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

                VarExcessQty = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, "Select PercentageExecssQtyForProcessIss From MasterSetting"))

                totalQty = (totalQty * (100.0 + VarExcessQty) / 100)
                Dim Qty As Double = Val(DGConsumption.Item("issueqty", e.RowIndex).Value) - Val(DGConsumption.Item("BellWt", e.RowIndex).Value)
                Dim PreQty As Double = Math.Round(totalQty - Val(DGConsumption.Item("PendQty", e.RowIndex).Value), 3)
                Dim stockqty As Double = Val(DGConsumption.Item("stockqty", e.RowIndex).Value)
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
                " IssueQuantity Qty,LotNo,TagNo,GodownName " & _
                " From ProcessRawMaster PM " & _
                " join ProcessRawTran PT on PM.PRMid=PT.PRMid " & _
                " join V_FinishedItemDetail VF on PT.Finishedid = VF.Item_Finished_id " & _
                " join GodownMaster GM on PT.GodownId=GM.GodownId " & _
                " Where PM.TypeFlag = 0 And PM.BeamType=0 And PT.PrmID=" & Lblprmid.Text & ""

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
        'If e.KeyCode = Keys.Delete Then
        '    If MsgBox("Do you want to delete this row?", MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub
        '    If Con.State = ConnectionState.Closed Then
        '        Con.Open()
        '    End If
        '    Dim Tran As SqlTransaction = Con.BeginTransaction()
        '    Try
        '        Dim VarPrtID As Integer = gvdetail.Item("prtidgrid", gvdetail.CurrentRow.Index).Value
        '        Lblprmid.Text = SqlHelper.ExecuteScalar(Tran, CommandType.Text, "Select PrmId from ProcessRawTran Where PrtId=" & VarPrtID)
        '        Dim arr As SqlParameter() = New SqlParameter(6) {}
        '        arr(0) = New SqlParameter("@PrtID", SqlDbType.Int)
        '        arr(1) = New SqlParameter("@RowCount", SqlDbType.Int)
        '        arr(2) = New SqlParameter("@TranType", SqlDbType.Int)
        '        arr(3) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
        '        arr(4) = New SqlParameter("@userid", varuserid)
        '        arr(5) = New SqlParameter("@mastercompanyid", VarMasterCompanyID)
        '        arr(0).Value = VarPrtID
        '        arr(1).Value = gvdetail.Rows.Count
        '        arr(2).Value = 0
        '        arr(3).Direction = ParameterDirection.Output

        '        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PROCESS_RAW_ISSUE_RECEIVE_DELETE", arr)
        '        If arr(3).Value.ToString() <> "" Then
        '            MsgBox(arr(3).Value.ToString())
        '        End If

        '        Tran.Commit()
        '    Catch ex As Exception
        '        Tran.Rollback()
        '        MsgBox(ex.Message)
        '    End Try
        '    Fill_GridSave()
        'End If

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

    Private Sub txtWeaverIdNoscan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            'FillProcess_Employee(sender)
        End If
    End Sub

    Private Sub DDBinNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDBinNo.SelectedIndexChanged
        If cmbgodown.SelectedIndex <> -1 And DDBinNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Call Fill_Grid_New()
        End If
    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        Lblprmid.Text = "0"
        txtchalanno.Text = ""
        DGConsumption.Rows.Clear()
        'DGConsumptionConeType.Rows.Clear()
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub
End Class
