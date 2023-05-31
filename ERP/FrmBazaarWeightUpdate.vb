Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading

Public Class FrmBazaarWeightUpdate
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
        Call NewComboFill(DDCompanyName, "Select Distinct CI.CompanyId,CI.CompanyName from Companyinfo CI,Company_Authentication CA " & _
                          " Where CI.CompanyId=CA.CompanyId And CA.UserId=" & varuserid & "  And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By CompanyName")
        If DDCompanyName.Items.Count > 0 Then
            DDCompanyName.SelectedValue = 1
        End If
        TxtReceiveDate.Text = DateTime.Now.ToString("dd-MMM-yyyy")

    End Sub

    Private Sub BtnShowData_Click(sender As System.Object, e As System.EventArgs) Handles BtnShowData.Click
        Fill_Grid_New()
    End Sub

    Private Sub DDCompanyName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDCompanyName.SelectedIndexChanged
        If DDCompanyName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            CompanyId = DDCompanyName.SelectedValue
        End If
    End Sub

    Private Sub Fill_Grid_New()
        If Validcombobox(DDCompanyName) = False Then Exit Sub

        Dim ds As DataSet
        Dim i As Integer
        DG.Rows.Clear()

        Dim Param(2) As SqlParameter
        Param(0) = New SqlParameter("@ReceiveDate", TxtReceiveDate.Text)
        Param(1) = New SqlParameter("@MasterCompanyId", VarMasterCompanyID)

        ds = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "[PRO_PRODUCTIONRECEIVEDETAIL_FORWEIGHTUPDATE]", Param)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                DG.Rows.Add()
                DG.Item("ReceiveChallanNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ChallanNo")
                DG.Item("EmpName", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("EmpName")
                DG.Item("ReceiveDate", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ReceiveDate")
                DG.Item("QualityName", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("QualityName")
                DG.Item("TotalRecQty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RecQty")
                DG.Item("TxtTotalWeight", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TotalWeight")
                DG.Item("txtChkPcs", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("CheckPcs")
                DG.Item("txtChkWeight", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("CheckWeight")
                DG.Item("txtDryWeight", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("DryWeight")
                DG.Item("PROCESS_REC_ID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Process_Rec_ID")
                DG.Item("QualityId", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("QualityID")
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
                DG.Item("issueqty", lblgridindex.Tag).Value = w_Weight.ToString()
                '                DGConsumption.CurrentCell = DGConsumption((DGConsumption.Columns("Issuqty").Index), lblgridindex.Tag)

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnweight_Click(sender As System.Object, e As System.EventArgs) Handles btnweight.Click
        If DG.Rows.Count = 0 Then Exit Sub
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

    Private Sub DG_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
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
                Dim totalQty As Double = DG.Item("ConsmpQty", e.RowIndex).Value

                VarExcessQty = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, "Select PercentageExecssQtyForProcessIss From MasterSetting"))

                totalQty = (totalQty * (100.0 + VarExcessQty) / 100)
                Dim Qty As Double = Val(DG.Item("issueqty", e.RowIndex).Value) - Val(DG.Item("BellWt", e.RowIndex).Value)
                Dim PreQty As Double = Math.Round(totalQty - Val(DG.Item("PendQty", e.RowIndex).Value), 3)
                Dim stockqty As Double = Val(DG.Item("stockqty", e.RowIndex).Value)
                If Qty + PreQty > totalQty Or Qty > stockqty Then
                    DG.Item("BellWt", e.RowIndex).Value = ""
                    MsgBox("Pls Enter Correct Qty OR BellWt ")
                    If _serialPort IsNot Nothing Then
                        _serialPort.Close()
                        _serialPort = Nothing
                    End If
                    Return
                End If
                RaiseEvent DGConsumptionButtonClick(senderGrid, e)
                DG.Item("BellWt", lblgridindex.Tag).Value = ""
                If _serialPort IsNot Nothing Then
                    _serialPort.Close()
                    _serialPort = Nothing
                End If
        End Select
    End Sub

    Private Sub gvdetail_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub DG_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEnter
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
            Case "TXTTOTALWEIGHT"
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
                DG.Item("TxtTotalWeight", e.RowIndex).Value = w_Weight

            Case "TXTCHKWEIGHT"
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
                DG.Item("txtChkWeight", e.RowIndex).Value = w_Weight

            Case "TXTDRYWEIGHT"
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
                DG.Item("txtDryWeight", e.RowIndex).Value = w_Weight
        End Select
    End Sub

    Private Sub txtWeaverIdNoscan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            'FillProcess_Employee(sender)
        End If
    End Sub


    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        Lblprmid.Text = "0"
        'txtchalanno.Text = ""
        DG.Rows.Clear()
        'DGConsumptionConeType.Rows.Clear()
    End Sub

    Private Sub BtnClose_Click(sender As System.Object, e As System.EventArgs) Handles BtnClose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        SaveDetail()
    End Sub
    Protected Sub SaveDetail()
        Dim DetailData As String = ""
        If Validcombobox(DDCompanyName) = False Then Exit Sub

        For i As Integer = 0 To DG.Rows.Count - 1
            Dim Chkboxitem As DataGridViewCheckBoxCell = DirectCast(DG.Rows(i).Cells("Chkboxitem"), DataGridViewCheckBoxCell)
            Dim txtTotalWeight As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("TxtTotalWeight"), DataGridViewTextBoxCell)
            Dim txtChkPcs As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("txtChkPcs"), DataGridViewTextBoxCell)
            Dim txtChkWeight As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("txtChkWeight"), DataGridViewTextBoxCell)
            Dim txtDryWeight As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("txtDryWeight"), DataGridViewTextBoxCell)
            Dim PROCESS_REC_ID As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("PROCESS_REC_ID"), DataGridViewTextBoxCell)
            Dim QualityId As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("QualityId"), DataGridViewTextBoxCell)

            Dim NoofChkPcs As Integer = If(txtChkPcs.Value.ToString() = "", "0", txtChkPcs.Value)
            Dim NoofChkPcsWeight As Decimal = If(txtChkWeight.Value.ToString() = "", "0", txtChkWeight.Value)
            Dim NoofChkPcsDryWeight As Decimal = If(txtDryWeight.Value.ToString() = "", "0", txtDryWeight.Value)

            If Chkboxitem.Value = True And (txtTotalWeight.Value.ToString() <> "" Or txtChkPcs.Value.ToString() <> "" Or txtChkWeight.Value.ToString() <> "" Or txtDryWeight.Value.ToString() <> "") Then
                If DetailData = "" Then
                    DetailData = PROCESS_REC_ID.Value.ToString() + "|" + txtTotalWeight.Value.ToString() + "|" + NoofChkPcs.ToString() + "|" + NoofChkPcsWeight.ToString() + "|" + NoofChkPcsDryWeight.ToString() + "|" + QualityId.Value.ToString() + "~"
                Else
                    DetailData = DetailData + PROCESS_REC_ID.Value.ToString() + "|" + txtTotalWeight.Value.ToString() + "|" + NoofChkPcs.ToString() + "|" + NoofChkPcsWeight.ToString() + "|" + NoofChkPcsDryWeight.ToString() + "|" + QualityId.Value.ToString() + "~"
                End If
            End If
        Next

        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If
        If (DetailData <> "") Then
            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim param As SqlParameter() = New SqlParameter(12) {}


                param(0) = New SqlParameter("@Companyid", DDCompanyName.SelectedValue)
                param(1) = New SqlParameter("@ReceiveDate", TxtReceiveDate.Text)
                param(2) = New SqlParameter("@DetailData", DetailData)
                param(3) = New SqlParameter("@userid", varuserid)
                param(4) = New SqlParameter("@Mastercompanyid", VarMasterCompanyID)
                param(5) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(5).Direction = ParameterDirection.Output

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_SaveBazaarReceiveCheckWeight", param)
                If (param(5).Value.ToString() <> "") Then
                    MsgBox(param(5).Value.ToString())
                Else
                    MsgBox("DATA SAVED SUCCESSFULLY.")
                End If
                Tran.Commit()
            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Please select atleast one check box to save data.")
        End If

    End Sub

End Class
