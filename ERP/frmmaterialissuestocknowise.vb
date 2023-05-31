Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class frmmaterialissuestocknowise
    Dim hnstockno As Long
    Dim hncompanyid As Integer
    Dim CmbOperator As DataGridViewComboBoxCell
    Dim iFinishedid As String = ""
    Dim gridindex As Integer = 0
    Dim gridcolname As String = ""
    Dim hnissueid As Integer = "0"
    Private Sub frmmaterialissuestocknowise_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Call NewComboFill(DDGodown, "select GoDownID,GodownName From GodownMaster order by GodownName")
        If DDGodown.Items.Count > 0 Then DDGodown.SelectedIndex = 0
        If VarBINNOWISE = "1" Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If

    End Sub

    Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGodown.SelectedIndexChanged
        If DDGodown.SelectedIndex <> -1 And Varcombovalue <> 0 And txtstockno.Text <> "" Then
            If VarBINNOWISE = "1" Then
                Call NewComboFill(DDBinNo, "SELECT DISTINCT BINNO,BINNO AS BINNO1 FROM STOCK S WHERE GODOWNID=" & DDGodown.SelectedValue & " AND ROUND(QTYINHAND,3)>0 and Item_finished_id in(" & iFinishedid & ") ORDER BY BINNO1")
            Else
                Call Fillgrid()
            End If

        End If
    End Sub

    Private Sub txtstockno_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtstockno.KeyDown
        If e.KeyCode = Keys.Enter Then
            Fillgrid()
        End If
    End Sub
    Protected Sub Fill_Grid_Combo(ByRef cmbbobox As DataGridViewComboBoxCell, ByVal str As String)
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        cmbbobox.DataSource = ds.Tables(0)
        cmbbobox.ValueMember = ds.Tables(0).Columns(0).ColumnName
        cmbbobox.DisplayMember = ds.Tables(0).Columns(1).ColumnName

    End Sub
    Protected Sub Fill_Grid_ComboWithds(ByRef cmbbobox As DataGridViewComboBoxCell, ByRef ds As DataSet)

        cmbbobox.DataSource = ds.Tables(0)
        cmbbobox.ValueMember = ds.Tables(0).Columns(0).ColumnName
        cmbbobox.DisplayMember = ds.Tables(0).Columns(1).ColumnName

    End Sub
    Protected Sub Fillgrid()
        hnstockno = "0"
        iFinishedid = ""
        DG.Rows.Clear()
        Dim ds1 As DataSet
        Dim param As SqlParameter() = New SqlParameter(3) {}
        param(0) = New SqlParameter("@tstockno", txtstockno.Text)
        param(1) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
        param(1).Direction = ParameterDirection.Output
        param(2) = New SqlParameter("@CompanyID", 1)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "PRO_GETSTOCKWISEMATERIALDETAILS", param)

        If param(1).Value.ToString() <> "" Then
            MsgBox(param(1).Value.ToString())
            txtstockno.Text = ""
        Else
            If ds.Tables(0).Rows.Count > 0 Then
                hncompanyid = ds.Tables(0).Rows(0)("companyid").ToString()
                hnstockno = ds.Tables(0).Rows(0)("stockno").ToString()
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    DG.Rows.Add()
                    DG.Item("ITEMDESCRIPTION", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ITEMDESCRIPTION")
                    DG.Item("Unitname", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitname")
                    DG.Item("consmpqty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("consmpqty")
                    DG.Item("issuedqty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("issuedqty")
                    DG.Item("balanceqty", DG.Rows.Count - 1).Value = Math.Round(Val(ds.Tables(0).Rows(i)("consmpqty")) - Val(ds.Tables(0).Rows(i)("issuedqty")), 3)
                    DG.Item("lblifinishedid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("iFinishedid")
                    DG.Item("lblissueorderid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("issueorderid")
                    DG.Item("lbliunitid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("iunitid")
                    DG.Item("lblisizeflag", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("iSizeflag")
                    DG.Item("lblstockno", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("stockno")
                    iFinishedid = iFinishedid & "," & ds.Tables(0).Rows(i)("iFinishedid")
                    CmbOperator = DirectCast(DG.Rows(i).Cells("lotno"), DataGridViewComboBoxCell)

                    If DDGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                        Dim str As String = "select Lotno,LotNo From Stock Where CompanyId=" & hncompanyid & " and godownId=" & DDGodown.SelectedValue & " AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DG.Item("lblifinishedid", i).Value & " "
                        If DDBinNo.Visible = True Then
                            str = str & " and BinNo='" + DDBinNo.Text + "'"
                        End If
                        ds1 = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
                        Fill_Grid_ComboWithds(CmbOperator, ds1)
                        If ds1.Tables(0).Rows.Count > 0 Then
                            CmbOperator.Value = ds1.Tables(0).Rows(0)("Lotno")
                        End If
                    End If
                    ''TAGNO
                    CmbOperator = DirectCast(DG.Rows(i).Cells("TagNo"), DataGridViewComboBoxCell)
                    If DDGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then

                        Dim str As String = "select TAGNO,TAGNO From Stock Where CompanyId=" & hncompanyid & " and godownId=" & DDGodown.SelectedValue & " AND Round(Qtyinhand,3)>0 And item_Finished_id=" & DG.Item("lblifinishedid", i).Value & " and Lotno='" & DG.Item("Lotno", i).Value & "' "
                        If DDBinNo.Visible = True Then
                            str = str & " and BinNo='" + DDBinNo.Text + "'"
                        End If
                        Fill_Grid_Combo(CmbOperator, str)
                        ds1 = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
                        Fill_Grid_ComboWithds(CmbOperator, ds1)
                        If ds1.Tables(0).Rows.Count > 0 Then
                            CmbOperator.Value = ds1.Tables(0).Rows(0)("tagno")
                        End If
                    End If
                    Dim stkqty As Double
                    stkqty = Module1.getstockQty(hncompanyid, DDGodown.SelectedValue, DG.Item("Lotno", i).Value, DG.Item("lblifinishedid", i).Value, DG.Item("Tagno", i).Value, BinNo:=IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))

                    DG.Item("stockqty", DG.Rows.Count - 1).Value = stkqty
                Next
                iFinishedid = iFinishedid.TrimStart(",")
            End If
        End If
    End Sub

    Private Sub DG_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG.EditingControlShowing
        Select Case DG.Columns(DG.CurrentCell.ColumnIndex).Name.ToUpper()
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

        godownid = DDGodown.SelectedValue
        Dim cmbLotno As ComboBox = CType(sender, ComboBox)

        Dim stkqty As Double
        stkqty = Module1.getstockQty(hncompanyid, godownid, cmbLotno.SelectedValue, DG.Item("lblifinishedid", DG.CurrentRow.Index).Value)
        'str = "select Round(isnull(Qtyinhand,0),3) As Stock from Stock Where godownId=" & godownid & "  and CompanyId=1 And LotNo='" & cmbLotno.SelectedValue & "'  And Item_Finished_id=" & DG.Item("Itemid", DG.CurrentRow.Index).Value & " "
        'stkqty = SqlHelper.ExecuteScalar(Con, CommandType.Text, str)
        DG.Item("stockqty", DG.CurrentRow.Index).Value = stkqty
    End Sub
    Private Sub ComboBox_SelectionChangeCommitted_tagno(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim godownid As Integer
        ''   Dim unit As Integer = Convert.ToInt32(DGOrderdetail.Item("unitid", DGOrderdetail.CurrentRow.Index).Value)
        Dim Lotno As String = DG.Item("lotno", DG.CurrentRow.Index).Value

        godownid = DDGodown.SelectedValue
        Dim cmbtagno As ComboBox = CType(sender, ComboBox)
        Dim str As String
        Dim stkqty As Double
        stkqty = Module1.getstockQty(hncompanyid, godownid, Lotno, DG.Item("lblifinishedid", DG.CurrentRow.Index).Value, cmbtagno.SelectedValue, BinNo:=IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))

        DG.Item("stockqty", DG.CurrentRow.Index).Value = stkqty
    End Sub

    Private Sub DDBinNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDBinNo.SelectedIndexChanged
        If DDGodown.SelectedIndex <> -1 And DDBinNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            Call Fillgrid()

        End If
    End Sub
    Dim _serialPort As SerialPort
    Private Delegate Sub SetTextDeleg(text As String)
    Private Sub DG_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEnter
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
            Case "ISSUEQTY"
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
                        'Return
                    End If
                End If
                DG.Item("Issueqty", e.RowIndex).Value = w_Weight

        End Select
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

                If gridindex >= 0 Then
                    DG.Item(gridcolname, gridindex).Value = w_Weight.ToString()
                End If

                '                DGConsumption.CurrentCell = DGConsumption((DGConsumption.Columns("Issuqty").Index), lblgridindex.Tag)

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmmaterialissuestocknowise_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If


    End Sub

    Private Sub DG_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
            Case "LBLISSQTY"
                SaveDetail()
                If DG.Rows.Count > 0 And gridindex <> -1 Then
                    DG.Item(gridcolname, gridindex).Value = ""
                End If
                If _serialPort IsNot Nothing Then
                    _serialPort.Close()
                    _serialPort = Nothing
                End If
        End Select
    End Sub

    Private Sub SaveDetail()
        If Validtxtbox(txtstockno) = False Then Exit Sub
        If Validcombobox(DDBinNo) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim dtrecords As DataTable = New DataTable()
        dtrecords.Columns.Add("ifinishedid", GetType(Integer))
        dtrecords.Columns.Add("IUnitid", GetType(Integer))
        dtrecords.Columns.Add("Isizeflag", GetType(Integer))
        dtrecords.Columns.Add("Godownid", GetType(Integer))
        dtrecords.Columns.Add("Lotno", GetType(String))
        dtrecords.Columns.Add("TagNo", GetType(String))
        dtrecords.Columns.Add("issueqty", GetType(Single))
        dtrecords.Columns.Add("Prorderid", GetType(Integer))
        dtrecords.Columns.Add("ConsmpQty", GetType(Single))
        dtrecords.Columns.Add("BinNo", GetType(String))


        Dim ifinishedid As String = DG.Item("lblifinishedid", gridindex).Value
        Dim IUnitid As String = DG.Item("lblIUnitid", gridindex).Value
        Dim Isizeflag As String = DG.Item("lblIsizeflag", gridindex).Value
        Dim Lotno As String = DG.Item("lotno", gridindex).Value
        Dim Tagno As String = DG.Item("Tagno", gridindex).Value
        Dim issueqty As String = DG.Item("issueqty", gridindex).Value
        Dim Prorderid As String = DG.Item("lblissueorderid", gridindex).Value
        Dim consmpqty As String = DG.Item("consmpqty", gridindex).Value
        'Dim BinNo As String = IIf(DG.Item("BinNo", gridindex).Value Is Nothing, "", DG.Item("BinNo", gridindex).Value)
        Dim BinNo As String = IIf(VarBINNOWISE = 1, DDBinNo.Text, "")

        If Lotno <> "" And Tagno <> "" And Val(issueqty) > 0 Then
            Dim dr As DataRow = dtrecords.NewRow()
            dr("ifinishedid") = ifinishedid
            dr("IUnitid") = IUnitid
            dr("Isizeflag") = Isizeflag
            dr("Godownid") = DDGodown.SelectedValue
            dr("Lotno") = Lotno
            dr("TagNo") = Tagno
            dr("IssueQty") = If(issueqty = "", "0", issueqty)
            dr("Prorderid") = Prorderid
            dr("consmpqty") = consmpqty
            dr("BinNo") = BinNo
            dtrecords.Rows.Add(dr)
        End If


        If dtrecords.Rows.Count > 0 Then
            Dim Tran As SqlTransaction = Con.BeginTransaction()

            Try
                Dim param As SqlParameter() = New SqlParameter(10) {}
                param(0) = New SqlParameter("@PrmId", SqlDbType.Int)
                param(0).Value = hnissueid
                param(0).Direction = ParameterDirection.InputOutput
                param(1) = New SqlParameter("@companyid", hncompanyid)
                param(2) = New SqlParameter("@Processid", SqlDbType.Int)
                param(2).Value = 1
                param(3) = New SqlParameter("@Prorderid", SqlDbType.Int)
                param(3).Value = 0
                param(4) = New SqlParameter("@issueDate", System.DateTime.Now.ToString("dd-MMM-yyyy"))
                param(5) = New SqlParameter("@userid", varuserid)
                param(6) = New SqlParameter("@Mastercompanyid", VarMasterCompanyID)
                param(7) = New SqlParameter("@dtrecords", dtrecords)
                param(8) = New SqlParameter("@TranType", SqlDbType.TinyInt)
                param(8).Value = 0
                param(9) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(9).Direction = ParameterDirection.Output
                param(10) = New SqlParameter("@Stockno", hnstockno)
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_SAVEMATERIALISSUESTOCKWISE", param)
                hnissueid = param(0).Value.ToString()
                Tran.Commit()

                If param(9).Value.ToString() <> "" Then
                    MsgBox(param(9).Value.ToString())
                Else
                    MsgBox("DATA SAVED SUCCESSFULLY.")
                    Fillgrid()
                    FillissueGrid()
                End If

            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Please select atleast one check box to save data.")
        End If

    End Sub
    Private Sub FillissueGrid()
        gvdetail.Rows.Clear()
        Dim str As String = "select dbo.F_getItemDescription(PT.Finishedid,PT.flagsize) as ItemDescription, " & _
                          "PT.Lotno,PT.TagNo,PT.IssueQuantity,PM.chalanNo,Replace(CONVERT(nvarchar(11),PM.date,106),' ','-') as IssueDate,PM.prmid,PT.Prtid,PM.prorderid,PM.processid  " & _
                    "from ProcessRawMaster PM inner join ProcessRawTran PT on PM.PRMid=PT.PRMid " & _
                    "and PM.BeamType=0 Where PM.prmid=" & hnissueid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                gvdetail.Rows.Add()
                gvdetail.Item("Itemdescriptionissued", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ItemDescription")
                gvdetail.Item("Lotnoissued", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
                gvdetail.Item("Tagnoissued", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Tagno")
                gvdetail.Item("Qty", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Issuequantity")
                gvdetail.Item("lblprmid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("prmid")
                gvdetail.Item("lblprtid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("prtid")
                gvdetail.Item("lblprorderid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("prorderid")
                gvdetail.Item("lblprocessid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("processid")
            Next
        End If
    End Sub

    Private Sub gvdetail_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvdetail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub

            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim Tran As SqlTransaction = Con.BeginTransaction()

            Try
                Dim lblprmid As String = gvdetail.Item("lblprmid", gvdetail.CurrentRow.Index).Value
                Dim lblprtid As String = gvdetail.Item("lblprtid", gvdetail.CurrentRow.Index).Value
                Dim lblprorderid As String = gvdetail.Item("lblprorderid", gvdetail.CurrentRow.Index).Value
                Dim lblprocessid As String = gvdetail.Item("lblprocessid", gvdetail.CurrentRow.Index).Value
                Dim param As SqlParameter() = New SqlParameter(4) {}
                param(0) = New SqlParameter("@prmid", lblprmid)
                param(1) = New SqlParameter("@prtid", lblprtid)
                param(2) = New SqlParameter("@prorderid", lblprorderid)
                param(3) = New SqlParameter("@Processid", lblprocessid)
                param(4) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(4).Direction = ParameterDirection.Output
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_DELETEMATERIALISSUESTOCKNOWISE", param)
                MsgBox(param(4).Value.ToString())
                Tran.Commit()
                Fillgrid()
                FillissueGrid()
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        End If
    End Sub
End Class