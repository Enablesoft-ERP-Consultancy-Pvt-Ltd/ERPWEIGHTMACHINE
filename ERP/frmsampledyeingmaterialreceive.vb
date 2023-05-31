Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class frmsampledyeingmaterialreceive
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
                           "select PROCESS_NAME_ID,Process_name From process_name_master  where Processtype=0 and mastercompanyid=" & VarMasterCompanyID & " order by PROCESS_NAME " & _
                           "select Godownid,Godownname From Godownmaster order by Godownname"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        NewComboFillWithDs(DDCompanyName, ds, 0)
        If DDCompanyName.Items.Count > 0 Then DDCompanyName.SelectedIndex = 0
        NewComboFillWithDs(DDProcessName, ds, 1)
        If DDProcessName.Items.Count > 0 Then DDProcessName.SelectedIndex = 0
        NewComboFillWithDs(DDgodown, ds, 2)
        If DDgodown.Items.Count > 0 Then DDgodown.SelectedIndex = 0
        'If VarBINNOWISE = 1 Then
        '    lblbinno.Visible = True
        '    DDBinNo.Visible = True
        'End If

    End Sub
    Private Sub DDProcessName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDProcessName.SelectedIndexChanged
        If DDProcessName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            hnid = "0"
            txtchallanNo.Text = ""
            NewComboFill(DDPartyName, "Select EI.EmpId,EI.EmpName From EmpInfo EI inner join EmpProcess EP on EI.EmpId=EP.EmpId and EP.ProcessId=" & DDProcessName.SelectedValue & " order by EI.empname")

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
        Dim str As String = "select ID,indentNo from sampledyeingmaster Where companyid=" & DDCompanyName.SelectedValue & " and processid=" & DDProcessName.SelectedValue & " and empid=" & DDPartyName.SelectedValue
        'If chkcomplete.Checked = True Then
        '    str = str & " and Status='Complete'"
        'Else
        '    str = str & " and Status='Pending'"
        'End If
        str = str & " and Status='Pending'"
        str = str & " order by ID desc"
        NewComboFill(DDindentNo, str)
    End Sub
    Protected Sub FillGridReceive()
        DG.Rows.Clear()
        If VarBINNOWISE = 0 Then
            DG.Columns("BinNo").Visible = False
        End If

        If DDindentNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim i As Integer
            Dim str As String = "select SM.id as Issueid,SD.Detailid as IssueDetailid,dbo.F_getItemDescription(SD.Ifinishedid,SD.iflagsize) as Iitemdescription," & _
                        "dbo.F_getItemDescription(SD.Rfinishedid,SD.Rflagsize) as Ritemdescription,SD.RecLotNo,case when " & VarMasterCompanyID & "=16 Then '' Else SD.RecTagno End as RecTagNo,SD.issueqty as Issuedqty,dbo.F_getsamplereceiveqty(SD.Detailid) as Receivedqty, " & _
                        "SD.Rate, sd.Rfinishedid, SD.unitid, SD.Rflagsize, SD.ifinishedid " & _
                        "From SampleDyeingMaster SM inner join SampleDyeingDetail SD on SM.ID=SD.masterid " & _
                         "Where SM.ID = " & DDindentNo.SelectedValue & ""
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    DG.Rows.Add()
                    DG.Item("Idescriptiondg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Iitemdescription")
                    DG.Item("Rdescriptiondg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Ritemdescription")
                    DG.Item("Reclotnodg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RecLotNo")
                    DG.Item("Rectagnodg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RecTagno")
                    DG.Item("issdqtydg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Issuedqty")
                    DG.Item("Recdqtydg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Receivedqty")
                    DG.Item("Ratedg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("rate")
                    DG.Item("lblissueiddg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Issueid")
                    DG.Item("lblissuedetailiddg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Issuedetailid")
                    DG.Item("lblrfinishediddg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rfinishedid")
                    DG.Item("lblifinishediddg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ifinishedid")
                    DG.Item("lblrflagsizedg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rflagsize")
                    DG.Item("lblunitiddg", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitid")
                    If VarBINNOWISE = 1 Then
                        CmbOperator = DirectCast(DG.Rows(i).Cells("BinNo"), DataGridViewComboBoxCell)
                        If VarCHECKBINCONDITION = 1 Then
                            Module1.FillBinNO_GRIDVIEW(CmbOperator, DDgodown.SelectedValue, DG.Item("lblrfinishediddg", DG.Rows.Count - 1).Value, New_Edit:=0)
                        Else
                            Fill_Grid_Combo(CmbOperator, "select BINNO,BINNO From BinMaster Where Godownid=" & DDgodown.SelectedValue & " order by BINID")
                        End If

                    End If
                Next
            End If
        End If
    End Sub

    Private Sub DDindentNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDindentNo.SelectedIndexChanged
        FillGridReceive()
    End Sub
    Protected Sub SaveDetail()
        Dim saveflag As Boolean = False
        If Validcombobox(DDCompanyName) = False Then Exit Sub
        If Validcombobox(DDProcessName) = False Then Exit Sub
        If Validcombobox(DDPartyName) = False Then Exit Sub
        If Validcombobox(DDindentNo) = False Then Exit Sub
        If Validtxtbox(txtchallanNo) = False Then Exit Sub
        If Validcombobox(DDgodown) = False Then Exit Sub

        'If DDBinNo.Visible = True Then
        '    If Validcombobox(DDBinNo) = False Then Exit Sub
        'End If
        Dim dtrecord As DataTable = New DataTable()
        dtrecord.Columns.Add("Rfinishedid", GetType(Integer))
        dtrecord.Columns.Add("godownid", GetType(Integer))
        dtrecord.Columns.Add("lotno", GetType(String))
        dtrecord.Columns.Add("Tagno", GetType(String))
        dtrecord.Columns.Add("Rate", GetType(Double))
        dtrecord.Columns.Add("Recqty", GetType(Double))
        dtrecord.Columns.Add("Lossqty", GetType(Double))
        dtrecord.Columns.Add("issuedetailid", GetType(Integer))
        dtrecord.Columns.Add("unitid", GetType(Integer))
        dtrecord.Columns.Add("Rflagsize", GetType(Integer))
        dtrecord.Columns.Add("Undyedqty", GetType(Double))
        dtrecord.Columns.Add("Ifinishedid", GetType(Integer))
        dtrecord.Columns.Add("BinNo", GetType(String))
        dtrecord.Columns.Add("BELLWT", GetType(Double))

        ''*******************
        Dim lblrfinishedid As String = DG.Item("lblrfinishediddg", gridindex).Value
        'Dim DDgodown As DropDownList = CType(DG.Rows(i).FindControl("DDgodown"), DropDownList)
        Dim lblrlotno As String = DG.Item("reclotnodg", gridindex).Value
        Dim txtrtagno As String = DG.Item("rectagnodg", gridindex).Value
        Dim lblrate As String = DG.Item("Ratedg", gridindex).Value
        Dim txtrecqty As String = DG.Item("recqtydg", gridindex).Value
        Dim txtlossqty As String = DG.Item("lossqtydg", gridindex).Value
        Dim lblissuedetailid As String = DG.Item("lblissuedetailiddg", gridindex).Value
        Dim lblunitid As String = DG.Item("lblunitiddg", gridindex).Value
        Dim lblrflagsize As String = DG.Item("lblrflagsizedg", gridindex).Value
        Dim txtundyedqty As String = DG.Item("undyedqtydg", gridindex).Value
        Dim lblifinishedid As String = DG.Item("lblifinishediddg", gridindex).Value

        Dim txtBellWeight As String = DG.Item("BellWeight", gridindex).Value

        Dim BinNo As String = IIf(DG.Item("BinNo", gridindex).Value Is Nothing, "", DG.Item("BinNo", gridindex).Value)
        '********************
        If VarBINNOWISE = 1 Then
            If (Val(txtrecqty) > 0 Or Val(txtlossqty) > 0 Or Val(txtundyedqty) > 0) And BinNo <> "" Then
                saveflag = True
            End If
        Else
            If Val(txtrecqty) > 0 Or Val(txtlossqty) > 0 Or Val(txtundyedqty) > 0 Then
                saveflag = True
            End If
        End If

        If saveflag = True Then
            Dim dr As DataRow = dtrecord.NewRow()
            dr("Rfinishedid") = lblrfinishedid
            dr("godownid") = DDgodown.SelectedValue
            dr("Lotno") = lblrlotno
            dr("TagNo") = txtrtagno
            dr("Rate") = If(lblrate = "", "0", lblrate)
            dr("Recqty") = If(txtrecqty = "", "0", txtrecqty) - If(txtBellWeight = "", "0", txtBellWeight)
            dr("Lossqty") = If(txtlossqty = "", "0", txtlossqty)
            dr("issuedetailid") = lblissuedetailid
            dr("unitid") = lblunitid
            dr("Rflagsize") = lblrflagsize
            dr("undyedqty") = If(txtundyedqty = "", "0", txtundyedqty)
            dr("Ifinishedid") = lblifinishedid
            dr("BinNo") = BinNo
            dr("BELLWT") = If(txtBellWeight = "", "0", txtBellWeight)
            dtrecord.Rows.Add(dr)
        End If

        If dtrecord.Rows.Count > 0 Then

            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim arr(14) As SqlParameter
                arr(0) = New SqlParameter("@ID", SqlDbType.Int)
                arr(0).Direction = ParameterDirection.InputOutput
                arr(0).Value = hnid
                arr(1) = New SqlParameter("@companyid", DDCompanyName.SelectedValue)
                arr(2) = New SqlParameter("@Processid", DDProcessName.SelectedValue)
                arr(3) = New SqlParameter("@empid", DDPartyName.SelectedValue)
                arr(4) = New SqlParameter("@Indentid", DDindentNo.SelectedValue)
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
                arr(12) = New SqlParameter("@Checkedby", txtcheckedby.Text)
                arr(13) = New SqlParameter("@approvedby", txtapprovedby.Text)
                arr(14) = New SqlParameter("@BinNo", "")
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_SavesampleDyeingReceive", arr)
                hnid = arr(0).Value.ToString()
                txtchallanNo.Text = arr(5).Value.ToString()
                txtgateinno.Text = arr(11).Value.ToString()
                If arr(10).Value.ToString() <> "" Then
                    MsgBox(arr(10).Value.ToString())
                    Tran.Rollback()
                Else
                    Tran.Commit()
                    ' DDindentNo.SelectedIndex = -1
                    'DG.Rows.Clear()
                    MsgBox("Data saved successfully.")
                    FillGridReceive()
                    fillgrid()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()

            End Try
        Else
            If VarBINNOWISE = 1 Then
                MsgBox("Please select Godown or Bin No. or Enter (Recqty or Loss qty or Undyed qty) to save data.")
            Else
                MsgBox("Please select Godown or Enter (Recqty or Loss qty or Undyed qty) to save data.")
            End If
            gridindex = -1
        End If
    End Sub
    Protected Sub fillgrid()
        Dim i As Integer
        DGrecdetail.Rows.Clear()
        Dim str As String = "select SRM.ID,SRD.Detailid,dbo.F_getItemDescription(srd.Rfinishedid,SRD.Rflagsize) as RItemdescription," & _
                        "gm.GodownName, SRD.LotNo, SRD.TagNo, SRD.Recqty, SRD.Lossqty, SRD.Rate, SRM.GateinNo, SRM.challanNo, SRM.receiveDate, srd.Undyedqty " & _
                        "From SampleDyeingReceivemaster SRM inner join SampleDyeingReceiveDetail SRD on SRM.ID=SRD.Masterid " & _
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
            Case "RECQTYDG", "UNDYEDQTYDG", "LOSSQTYDG"
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
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_DeletesampledyeingReceive", arr)
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
        Dim str As String = "select * from v_sampledyeingreceive where id=" & hnid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptsampledyeingreceive.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\rptsampledyeingreceive.xsd")
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
            FillGridReceive()
        End If
    End Sub
    Protected Sub Fill_Grid_Combo(ByRef cmbbobox As DataGridViewComboBoxCell, ByVal str As String)
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        cmbbobox.DataSource = ds.Tables(0)
        cmbbobox.ValueMember = ds.Tables(0).Columns(0).ColumnName
        cmbbobox.DisplayMember = ds.Tables(0).Columns(1).ColumnName

    End Sub
End Class