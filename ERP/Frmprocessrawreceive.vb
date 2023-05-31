Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading

Public Class Frmprocessrawreceive
    'Public Con As New SqlClient.SqlConnection
    Dim unit As Integer
    Dim CompanyId, Empid As Integer
    Dim finishedid As Integer
    Dim CmbOperator1 As DataGridViewComboBoxCell
    Dim CmbOperator As DataGridViewComboBoxCell
    Dim issqty1 As Double
    Dim cb As ComboBox
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
            DGConsumption.Columns("BinNo").Visible = True
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
            Dim str As String = "select top(1) Processid From View_process_issue_master Where CompanyID = " & VarCompanyID & " And ChallanNo='" & Val(txtfolioNo.Text) & "' order by PROCESSID "
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
            str = "select Issue_Detail_Id as IssueDetailId,vf.Category_Name as Category,vf.Item_Name as Articles,vf.ColorName As Color, Length,Width,Width + 'x' + Length Size,Area," & _
                    "Rate,Qty,Amount,OrderId,PD.Item_Finished_Id,isnull(units,0) as units,pm.UserId,pm.Companyid ,isnull(PM.empid,0) as empid,isnull(Ei.empname,'') as Empname  From PROCESS_ISSUE_MASTER_" & DDProcessName.SelectedValue & " PM  " & _
                    "inner join PROCESS_ISSUE_DETAIL_" & DDProcessName.SelectedValue & " PD on PM.IssueOrderId=PD.IssueOrderId and PM.Status<>'canceled' " & _
                    "inner join V_FinishedItemDetail vf on PD.Item_Finished_Id=vf.ITEM_FINISHED_ID Left join EmpInfo EI on PM.Empid=Ei.EmpId where Pm.issueorderid='" & DDfoliono.SelectedValue & "' "
        Else
            str = "select Issue_Detail_Id as IssueDetailId,vf.Category_Name as Category,vf.Item_Name as Articles,vf.ColorName As Color, Length,Width,Width + 'x' + Length Size,Area," & _
                  "Rate,Qty,Amount,OrderId,PD.Item_Finished_Id,isnull(units,0) as units,pm.UserId,pm.Companyid ,PM.empid,Ei.empname  From PROCESS_ISSUE_MASTER_" & DDProcessName.SelectedValue & " PM  " & _
                  "inner join PROCESS_ISSUE_DETAIL_" & DDProcessName.SelectedValue & " PD on PM.IssueOrderId=PD.IssueOrderId and PM.Status<>'canceled' " & _
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
                ''CompanyId = ds.Tables(0).Rows(i)("Companyid")
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

        Dim str As String = "SELECT VF.ITEM_NAME,VF.QUALITYNAME+'   '+VF.SHADECOLORNAME AS DESCRIPTION,SUM(CASE WHEN PM.TRANTYPE=0 THEN PT.ISSUEQUANTITY ELSE 0 END) AS ISSUEDQTY, " & _
                    "ISNULL(SUM(CASE WHEN PM.TRANTYPE=1 THEN PT.ISSUEQUANTITY ELSE 0 END),0) AS RECEIVEDQTY,Pt.Lotno,pt.TagNo,VF.ITEM_FINISHED_ID AS IFINISHEDID,VF.ITEM_ID,VF.CATEGORY_ID, " & _
                    "PT.UNITID FROM PROCESSRAWMASTER PM INNER JOIN PROCESSRAWTRAN PT ON PM.PRMID=PT.PRMID " & _
                    "INNER JOIN V_FINISHEDITEMDETAIL VF ON PT.FINISHEDID=VF.ITEM_FINISHED_ID " & _
                    "Where pm.prorderid =" & DDfoliono.SelectedValue & " And pm.processid =" & DDProcessName.SelectedValue & " " & _
                    "GROUP BY VF.ITEM_NAME,VF.QUALITYNAME,VF.SHADECOLORNAME,VF.ITEM_FINISHED_ID,VF.ITEM_ID,VF.CATEGORY_ID,PT.UNITID,Pt.Lotno,pt.TagNo"

        ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)


        'ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1

                DGConsumption.Rows.Add()
                DGConsumption.Item("ItemName", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_Name")
                DGConsumption.Item("Description", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
                DGConsumption.Item("Issuedqty", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IssuedQty")
                DGConsumption.Item("Receivedqty", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Receivedqty")
                DGConsumption.Item("PendQty", DGConsumption.Rows.Count - 1).Value = Val(ds.Tables(0).Rows(i)("IssuedQty")) - Val(ds.Tables(0).Rows(i)("Receivedqty"))
                'FinishedId = ds.Tables(0).Rows(i)("IFinishedid")
                DGConsumption.Item("itemid", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IFinishedid")
                DGConsumption.Item("item_id", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_id")
                DGConsumption.Item("CategoryId", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Category_id")
                DGConsumption.Item("Lotno", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
                DGConsumption.Item("Tagno", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNO")
                DGConsumption.Item("unitidgrid", DGConsumption.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Unitid")

                ''****************
                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("Godown"), DataGridViewComboBoxCell)
                'If VarMasterCompanyID = 16 Then
                '    str = "SELECT DISTINCT GM.GODOWNID,GM.GODOWNNAME " & _
                '    " FROM STOCK S INNER JOIN GODOWNMASTER GM ON S.GODOWNID=GM.GODOWNID " & _
                '    " WHERE LOTNO='" & DGConsumption.Item("Lotno", DGConsumption.Rows.Count - 1).Value & "' " & _
                '    " AND TAGNO='" & DGConsumption.Item("TagNo", DGConsumption.Rows.Count - 1).Value & "' " & _
                '    " AND  ITEM_FINISHED_ID=" & DGConsumption.Item("itemid", DGConsumption.Rows.Count - 1).Value & " " & _
                '    " AND ROUND(QTYINHAND,3)>0 " & _
                '    " UNION  " & _
                '    " SELECT GODOWNID,GODOWNNAME FROM GODOWNMASTER WHERE GODOWNNAME='ASSORTED YARN GODOWN' ORDER BY GODOWNNAME"
                '    Fill_Grid_Combo(CmbOperator, str)

                'Else
                str = "SELECT GODOWNID,GODOWNNAME FROM GODOWNMASTER  ORDER BY GODOWNNAME"
                Fill_Grid_Combo(CmbOperator, str)

                CmbOperator = DirectCast(DGConsumption.Rows(i).Cells("ConeType"), DataGridViewComboBoxCell)
                Fill_Grid_Combo(CmbOperator, str)
                ''End If
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
        cb = TryCast(e.Control, ComboBox)
        If cb IsNot Nothing Then
            RemoveHandler cb.SelectedIndexChanged, AddressOf godownSelectionChanged
            RemoveHandler cb.SelectedIndexChanged, AddressOf BinNoSelectionChanged
        End If
        Select Case UCase(DGConsumption.Columns(DGConsumption.CurrentCell.ColumnIndex).Name)
            Case "GODOWN"
                '' Dim godown As ComboBox = CType(e.Control, ComboBox)
                If (cb IsNot Nothing) Then
                    AddHandler cb.SelectedIndexChanged, AddressOf godownSelectionChanged
                End If
            Case "BINNO"
                If (cb IsNot Nothing) Then
                    AddHandler cb.SelectedIndexChanged, AddressOf BinNoSelectionChanged
                End If
            Case Else
        End Select
    End Sub
    Private Sub BinNoSelectionChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub godownSelectionChanged(sender As Object, e As EventArgs)
        Dim godownid As Integer
        If Not cb.SelectedValue Is Nothing Then
            Dim godown As ComboBox = CType(sender, ComboBox)
            godownid = godown.SelectedValue
            CmbOperator = DirectCast(DGConsumption.Rows(DGConsumption.CurrentRow.Index).Cells("BinNo"), DataGridViewComboBoxCell)
            DGConsumption.Rows(DGConsumption.CurrentRow.Index).Cells("BinNo").Value = Nothing
            If VarBINNOWISE = 1 Then
                If VarCHECKBINCONDITION = "1" Then
                    Dim Item_finished_id As Integer = DGConsumption.Rows(DGConsumption.CurrentRow.Index).Cells("Itemid").Value

                    Module1.FillBinNo_Grid_Combo(CmbOperator, godownid, Item_finished_id, New_Edit:=0)
                Else
                    Fill_Grid_Combo(CmbOperator, "select BINNO,BINNO From BinMaster where GODOWNID=" & godownid & " order by BINID")
                End If
            End If
            RemoveHandler cb.SelectedIndexChanged, AddressOf godownSelectionChanged
        End If
    End Sub
    Private Sub ComboBox_SelectionChangeCommitted_godown(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim godownid As Integer

        Dim godown As ComboBox = CType(sender, ComboBox)
        godownid = godown.SelectedValue
        CmbOperator = DirectCast(DGConsumption.Rows(DGConsumption.CurrentRow.Index).Cells("BinNo"), DataGridViewComboBoxCell)
        If VarBINNOWISE = 1 Then
            If VarCHECKBINCONDITION = "1" Then
                If VarMasterCompanyID = 16 Then
                    If godownid = 17 Then
                        Module1.FillBinNo_Grid_Combo(CmbOperator, godownid, Item_finished_id:=0, New_Edit:=0)
                    Else

                        Dim Str As String = "SELECT DISTINCT S.BinNo,S.BinNo " & _
                            " FROM STOCK S INNER JOIN GODOWNMASTER GM ON S.GODOWNID=GM.GODOWNID " & _
                            " WHERE LOTNO='" & DGConsumption.Item("Lotno", DGConsumption.CurrentRow.Index).Value & "' AND TAGNO='" & DGConsumption.Item("TagNo", DGConsumption.CurrentRow.Index).Value & "' AND  ITEM_FINISHED_ID=" & DGConsumption.Item("itemid", DGConsumption.CurrentRow.Index).Value & " " & _
                            " AND S.Godownid=" & godownid & " AND ROUND(QTYINHAND,3)>0 And CompanyID = " & VarCompanyID & ""

                        Fill_Grid_Combo(CmbOperator, Str)
                    End If
                Else
                    Module1.FillBinNo_Grid_Combo(CmbOperator, godownid, Item_finished_id:=0, New_Edit:=0)
                End If
            Else
                Fill_Grid_Combo(CmbOperator, "select BINNO,BINNO From BinMaster where GODOWNID=" & godownid & " order by BINID")
                '' NewComboFill(CmbOperator, "select BINNO,BINNO From BinMaster where GODOWNID=" & godownid & " order by BINID")
            End If
        End If
    End Sub

    Private Sub ComboBox_SelectionChangeCommitted_lotno(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim godownid As Integer
        godownid = cmbgodown.SelectedValue
        Dim cmbLotno As ComboBox = CType(sender, ComboBox)

        Dim stkqty As Double
        stkqty = Module1.getstockQty(VarCompanyID, godownid, cmbLotno.SelectedValue, DGConsumption.Item("Itemid", DGConsumption.CurrentRow.Index).Value)
        DGConsumption.Item("stockqty", DGConsumption.CurrentRow.Index).Value = stkqty
    End Sub
    Private Sub ComboBox_SelectionChangeCommitted_tagno(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim godownid As Integer
        Dim Lotno As String = DGConsumption.Item("lotno", DGConsumption.CurrentRow.Index).Value
        godownid = cmbgodown.SelectedValue
        Dim cmbtagno As ComboBox = CType(sender, ComboBox)
        Dim stkqty As Double
        stkqty = Module1.getstockQty(VarCompanyID, godownid, Lotno, DGConsumption.Item("Itemid", DGConsumption.CurrentRow.Index).Value, cmbtagno.SelectedValue, BinNo:=IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))
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
                'DGConsumption.CurrentCell = DGConsumption((DGConsumption.Columns("Issuqty").Index), lblgridindex.Tag)

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DGConsumption_ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles Me.DGConsumptionButtonClick
        If Validcombobox(DDfoliono) = False Then Exit Sub

        If Con.State = ConnectionState.Closed Then Con.Open()
        Dim Tran As SqlTransaction = Con.BeginTransaction
        Try
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
            If DGConsumption.Item("TagNo", DGConsumption.CurrentRow.Index).Value = "" Then
                MsgBox("Plz select TagNo.....", MsgBoxStyle.OkOnly)
                DGConsumption.Item("TagNo", DGConsumption.CurrentRow.Index).Selected = True
                Tran.Commit()
                Exit Sub
            End If
            If Val(DGConsumption.Item("Godown", DGConsumption.CurrentRow.Index).Value) = 0 Then
                MsgBox("Plz select Godown.....", MsgBoxStyle.OkOnly)
                DGConsumption.Item("Godown", DGConsumption.CurrentRow.Index).Selected = True
                Tran.Commit()
                Exit Sub
            End If
            If DGConsumption.Columns("BinNo").Visible = True Then
                If DGConsumption.Item("BinNo", DGConsumption.CurrentRow.Index).Value = "" Then
                    MsgBox("Plz select Bin No.....", MsgBoxStyle.OkOnly)
                    DGConsumption.Item("BinNo", DGConsumption.CurrentRow.Index).Selected = True
                    Tran.Commit()
                    Exit Sub
                End If
            End If


            If Val(DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Value) = 0 Then
                MsgBox("Plz Enter Qty.....", MsgBoxStyle.OkOnly, "Message")
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
            godownid = Val(DGConsumption.Item("Godown", DGConsumption.CurrentRow.Index).Value)
            Dim issqty As Double
            Dim BellWt As Double
            BellWt = 0
            issqty = Convert.ToDouble(DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Value)

            issqty = Convert.ToDouble(DGConsumption.Item("issueqty", DGConsumption.CurrentRow.Index).Value)

            If (DGConsumption.Item("BellWt", DGConsumption.CurrentRow.Index).Value <> "") Then
                BellWt = Val(DGConsumption.Item("BellWt", DGConsumption.CurrentRow.Index).Value)
            End If

            Dim param(27) As SqlParameter
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
            param(24) = New SqlParameter("@BellWt", SqlDbType.Float)
            param(25) = New SqlParameter("@conetype", SqlDbType.VarChar, 50)
            param(26) = New SqlParameter("@Noofcone", SqlDbType.Int)

            If Lblprmid.Text = "" Then
                Lblprmid.Text = "0"
            End If
            param(0).Value = Lblprmid.Text
            param(1).Value = CompanyId ' ddCompName.SelectedValue
            param(2).Value = Empid ' ddempname.SelectedValue
            param(3).Value = DDProcessName.SelectedValue ' ddProcessName.SelectedValue
            param(4).Value = DDfoliono.SelectedValue ' ddOrderNo.SelectedValue
            param(5).Value = System.DateTime.Now.ToString("dd-MMM-yyyy")
            param(6).Value = txtchalanno.Text
            param(6).Direction = ParameterDirection.InputOutput
            param(7).Value = 1
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
            param(21).Value = IIf(DGConsumption.Columns("BinNo").Visible = True, DGConsumption.Item("BInNo", DGConsumption.CurrentRow.Index).Value, "")
            param(22).Value = DGConsumption.Item("Tagno", DGConsumption.CurrentRow.Index).Value
            param(23).Direction = ParameterDirection.Output
            param(24).Value = BellWt
            param(25).Value = DGConsumption.Item("ConeType", DGConsumption.CurrentRow.Index).Value
            param(26).Value = Val(DGConsumption.Item("Noofcone", DGConsumption.CurrentRow.Index).Value)


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

    ' Event DGConsumptionButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
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
            'str = " select PM.Date, PM.ChalanNo, PM.trantype, PT.IssueQuantity, " & _
            '               "PT.Lotno, GM.GodownName, isnull(EI.EmpName,dbo.F_getFolioEmployeeNew(PM.prorderid,PM.Processid)) as EmpName, EI.Address, CI.CompanyName, CI.CompAddr1, CI.CompAddr2, " & _
            '               "CI.CompAddr3, CI.CompTel, vf.ITEM_NAME, vf.QualityName, vf.designName, " & _
            '               "vf.ColorName, vf.ShadeColorName, vf.ShapeName, vf.SizeMtr, PNM.PROCESS_NAME, " & _
            '               "PM.Prorderid, EI.GSTNo as empgstin, CI.GSTNo,pt.TagNo,PT.BinNo From ProcessRawMaster PM inner join ProcessRawTran PT on PM.PRMid=PT.PRMid " & _
            '               "inner join CompanyInfo ci on PM.Companyid=ci.CompanyId " & _
            '               "inner join V_FinishedItemDetail vf on PT.Finishedid=vf.ITEM_FINISHED_ID " & _
            '               "inner join GodownMaster GM on PT.Godownid=GM.GoDownID " & _
            '               "Left join EmpInfo Ei on PM.Empid=ei.EmpId " & _
            '               "inner join PROCESS_NAME_MASTER PNM on PM.Processid=PNM.PROCESS_NAME_ID Where PM.Prmid=" + Lblprmid.Text + ""
            str = " Select PM.Date, PM.ChalanNo, PM.trantype, PT.IssueQuantity, " & _
                                " PT.Lotno, GM.GodownName, Case When IsNull(EI.EmpName, '') = '' Then  " & _
                                 " (Select Distinct EII.EmpName + ', '  " & _
                                  " From Employee_ProcessOrderNo EPO(Nolock)  " & _
                                  " JOIN Empinfo EII(Nolock) ON EII.EmpID = EPO.EmpID And EPO.IssueOrderId = PM.Prorderid And EPO.ProcessId = PM.Processid For XML Path(''))  " & _
                                " Else EI.EmpName End EmpName,  " & _
                                " Case When IsNull(EI.Address, '') = '' Then  " & _
                                 " (Select Distinct EII.Address + ', '  " & _
                                  " From Employee_ProcessOrderNo EPO(Nolock)  " & _
                                  " JOIN Empinfo EII(Nolock) ON EII.EmpID = EPO.EmpID And EPO.IssueOrderId = PM.Prorderid And EPO.ProcessId = PM.Processid For XML Path(''))  " & _
                                " Else EI.Address End Address, " & _
                                " CI.CompanyName, BM.BranchAddress CompAddr1, '' CompAddr2,  " & _
                                " '' CompAddr3, CI.CompTel, vf.ITEM_NAME, vf.QualityName, vf.designName,  " & _
                                " vf.ColorName, vf.ShadeColorName, vf.ShapeName, vf.SizeMtr, PNM.PROCESS_NAME,  " & _
                                " (Select Distinct Cast(Prorderid As Nvarchar) + ', '  " & _
                                " From ProcessRawMaster PMS(Nolock) Where PMS.TranType = PM.TranType And PMS.chalanno = PM.chalanno For XML Path('')) Prorderid,  " & _
                                " Case When IsNull(EI.GSTNo, '') = '' Then  " & _
                                 " (Select Distinct EII.GSTNo + ', '  " & _
                                  " From Employee_ProcessOrderNo EPO(Nolock)  " & _
                                  " JOIN Empinfo EII(Nolock) ON EII.EmpID = EPO.EmpID And EPO.IssueOrderId = PM.Prorderid And EPO.ProcessId = PM.Processid For XML Path(''))  " & _
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
                           "PT.Lotno, GM.GodownName, EI.EmpName, '' Address, CI.CompanyName, CI.CompAddr1, CI.CompAddr2, " & _
                           "CI.CompAddr3, CI.CompTel, vf.ITEM_NAME, vf.QualityName, vf.designName, " & _
                           "vf.ColorName, vf.ShadeColorName, vf.ShapeName, vf.SizeMtr, PNM.PROCESS_NAME, " & _
                           "PM.Prorderid, '' as empgstin, CI.GSTNo,pt.TagNo,PT.BinNo From ProcessRawMaster PM inner join ProcessRawTran PT on PM.PRMid=PT.PRMid " & _
                           "inner join CompanyInfo ci on PM.Companyid=ci.CompanyId " & _
                           "inner join V_FinishedItemDetail vf on PT.Finishedid=vf.ITEM_FINISHED_ID " & _
                           "inner join GodownMaster GM on PT.Godownid=GM.GoDownID " & _
                           "inner join V_GetCommaSeparateEmployee Ei on PM.Prorderid=ei.Issueorderid and ei.Processid=" & DDProcessName.SelectedValue & " " & _
                           "inner join PROCESS_NAME_MASTER PNM on PM.Processid=PNM.PROCESS_NAME_ID Where PM.Prmid=" + Lblprmid.Text + " and PM.Processid=" & DDProcessName.SelectedValue & " "
        End If

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
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
                If VarCHECKBINCONDITION = "1" Then
                    Module1.FillBinNO(DDBinNo, Convert.ToInt32(cmbgodown.SelectedValue), Item_finished_id:=0, New_Edit:=0)
                Else
                    NewComboFill(DDBinNo, "select BINNO,BINNO From BinMaster where GODOWNID=" & cmbgodown.SelectedValue & " order by BINID")
                End If
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
            Case "BELLWT"
                Dim senderGrid = DirectCast(sender, DataGridView)
                Dim Qty As Double = Val(DGConsumption.Item("issueqty", e.RowIndex).Value)
                Dim PQty As Double = Val(DGConsumption.Item("Pendqty", e.RowIndex).Value)
                Dim BellWt As Double = 0
                If (DGConsumption.Item("BellWt", e.RowIndex).Value <> "") Then
                    BellWt = Val(DGConsumption.Item("BellWt", e.RowIndex).Value)
                End If

                If ((Qty - BellWt) > PQty) Then
                    DGConsumption.Item("Issueqty", e.RowIndex).Value = ""
                    DGConsumption.Item("BellWt", e.RowIndex).Value = ""
                    MsgBox("Pls Enter Correct Qty ")
                    If _serialPort IsNot Nothing Then
                        _serialPort.Close()
                        _serialPort = Nothing
                    End If
                    Return
                End If
                RaiseEvent DGConsumptionButtonClick(senderGrid, e)
                DGConsumption.Item("issueqty", lblgridindex.Tag).Value = ""
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
                             "IssueQuantity Qty,LotNo,PT.TagNo,GodownName From ProcessRawTran PT,V_FinishedItemDetail VF,GodownMaster GM Where PT.Finishedid=VF.Item_Finished_id And " & _
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
                arr(2).Value = 1
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
        If txtStockNoScan.Text <> "" Then
            str = "SELECT Top(1) LS.IssueOrderId, PIM.ChallanNo as Issueorderid1 " & _
            " FROM Process_Issue_Master_" & DDProcessName.SelectedValue & " PIM(Nolock)  " & _
            " Join  EMPLOYEE_PROCESSORDERNO EMP(Nolock) ON EMP.IssueOrderID = PIM.IssueOrderID " & _
            " INNER JOIN EMPINFO EI ON EMP.EMPID=EI.EMPID " & _
            " INNER JOIN LOOMSTOCKNO LS ON EMP.IssueOrderId=LS.Issueorderid and EMP.IssueDetailId=LS.IssueDetailid " & _
            " WHERE LS.CompanyID  = " & VarCompanyID & " And LS.TStockNo='" & txtStockNoScan.Text & "'"
            If txtWeaverIdNoscan.Text <> "" Then
                str = str & " and EI.EMpcode='" & txtWeaverIdNoscan.Text & "'"
            End If
            If txtfolioNo.Text <> "" Then
                str = str & " and PIM.ChallanNo='" & txtfolioNo.Text & "'"
            End If
            str = str & " order by Issueorderid1"
        Else
            str = "SELECT PRORDERID,ISSUEORDERID FROM " & _
             "(SELECT DISTINCT PM.PRORDERID,PIM.ChallanNo AS ISSUEORDERID " & _
             " FROM PROCESSRAWMASTER PM" & _
             " JOIN Process_Issue_Master_" & DDProcessName.SelectedValue & " PIM ON PIM.IssueOrderID = PM.PRORDERID  " & _
             " INNER JOIN EMPLOYEE_PROCESSORDERNO EMP ON PM.PRORDERID=EMP.ISSUEORDERID AND PM.PROCESSID=EMP.PROCESSID " & _
             " inner join empinfo ei on EMp.empid=ei.empid " & _
             " Where PM.CompanyID  = " & VarCompanyID & " And PM.Processid = " & DDProcessName.SelectedValue & " "
            If txtWeaverIdNoscan.Text <> "" Then
                str = str & " and EI.EMpcode='" & txtWeaverIdNoscan.Text & "'"
            End If
            If txtfolioNo.Text <> "" Then
                str = str & " and PIM.ChallanNo='" & txtfolioNo.Text & "'"
            End If
            str = str & " UNION "
            str = str & " SELECT DISTINCT PM.PRORDERID,PIM.ChallanNo AS ISSUEORDERID " & _
                " FROM PROCESSRAWMASTER PM INNER JOIN PROCESS_ISSUE_MASTER_" & DDProcessName.SelectedValue & " PIM ON PM.PRORDERID=PIM.ISSUEORDERID " & _
                " inner join empinfo ei on Pim.empid=ei.empid " & _
                " Where PM.CompanyID  = " & VarCompanyID & " And PM.Processid=" & DDProcessName.SelectedValue & ""
            If txtWeaverIdNoscan.Text <> "" Then
                str = str & " and EI.EMpcode='" & txtWeaverIdNoscan.Text & "'"
            End If
            If txtfolioNo.Text <> "" Then
                str = str & " and PIM.ChallanNo='" & txtfolioNo.Text & "'"
            End If
            str = str & " ) A  ORDER BY ISSUEORDERID desc"
        End If

        Call NewComboFill(DDfoliono, str)
        If DDfoliono.Items.Count > 0 Then DDfoliono.SelectedIndex = 0

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
            Call fill_Grid()
            If chkforCone.Checked = True Then
                'Call Fill_Grid_Consmption_ConeType()
            Else
                Call Fill_Grid_Consmption()
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

    Private Sub txtstockno_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtStockNoScan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim str As String = "SELECT Top(1) EMP.ProcessId,EI.EmpId,LS.IssueOrderId FROM EMPLOYEE_PROCESSORDERNO EMP INNER JOIN EMPINFO EI ON EMP.EMPID=EI.EMPID " & _
                       " INNER JOIN LOOMSTOCKNO LS ON EMP.IssueOrderId=LS.Issueorderid and EMP.IssueDetailId=LS.IssueDetailid " & _
                       " WHERE LS.CompanyID = " & VarCompanyID & " And LS.TStockNo='" & txtStockNoScan.Text & "'"

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                DDProcessName.SelectedValue = ds.Tables(0).Rows(0)("Processid")
                DDProcessName_SelectedIndexChanged(sender, New EventArgs())
            End If

        End If
    End Sub
End Class
