Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class FrmIndentRawReturn
    Dim gridindex As Integer = 0
    Dim gridcolname As String = ""
    Dim reportid As Integer = "0"
    Private Sub frmyarnopeningreturn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If

        Dim str As String = "Select CI.CompanyId,CompanyName From CompanyInfo CI,Company_Authentication CA " & _
            " Where CI.CompanyId=CA.CompanyId And CA.UserId=" & varuserid & " And CI. MasterCompanyId=" & VarMasterCompanyID & " Order By CompanyName"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        NewComboFillWithDs(DDcompany, ds, 0)
        If DDcompany.Items.Count > 0 Then
            DDcompany.SelectedValue = VarCompanyID
            DDcompany.Enabled = False
            DDcompany_SelectedIndexChanged(sender, New EventArgs())
        End If
    End Sub

    Private Sub DDcompany_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDcompany.SelectedIndexChanged
        If DDcompany.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            reportid = 0
            Dim str As String = "Select  DISTINCT PROCESS_NAME_ID,PROCESS_NAME From Process_Name_Master  PNM, PP_ProcessRECMaster PRM WHERE PNM.PROCESS_NAME_ID= PRM.Processid " & _
                " And PRM.COMPANYID= " & DDcompany.SelectedValue & " Order By PROCESS_NAME"

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            NewComboFillWithDs(ddProcessName, ds, 0)
            If ddProcessName.Items.Count > 0 Then ddProcessName.SelectedIndex = 0
        End If
    End Sub

    Private Sub ddProcessName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddProcessName.SelectedIndexChanged
        If ddProcessName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct E.EMpId, E.Empname + '/' + Address EmpName From Empinfo E, PP_ProcessRECMaster PRM " & _
                    " Where PRM.EmpId=E.EmpId And PRM.CompanyID = " & DDcompany.SelectedValue & " And E.MasterCompanyid= " & VarMasterCompanyID & " AND PRM.PROCESSID = " & ddProcessName.SelectedValue & " Order By E.Empname + '/' + Address"
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            NewComboFillWithDs(DDPartyName, ds, 0)
        End If
    End Sub

    Private Sub ChkForEdit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkForEdit.CheckedChanged
        If ChkForEdit.Checked = True Then
            DDGatePass.Visible = True
            LblDDGatePassNo.Visible = True
        Else
            DDGatePass.Visible = False
            LblDDGatePassNo.Visible = False
        End If

    End Sub
    Private Sub DDPartyName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDPartyName.SelectedIndexChanged
        If DDPartyName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct PM.PRMID, GatePassNo + ' | ' + ChallanNo + ' | ' + REPLACE(CONVERT(NVARCHAR(11), Date, 106), ' ', '-') ChallanNo " & _
                    " From PP_ProcessRecMaster PM JOIN PP_ProcessRecTran PT ON PM.prmid=Pt.Prmid " & _
                    " Where PM.CompanyId = " & DDcompany.SelectedValue & " And PM.EmpID = " & DDPartyName.SelectedValue & "" & _
                    " And PM.PrmId Not in(select Distinct ProcessRec_PrmId from RawMaterialPreprationHissab RMH,RawMaterialPreprationHissabDetail RHD " & _
                    " Where RMH.HissabId = RHD.HissabId And RMH.Hissabtype = 0 And CompanyId = " & DDcompany.SelectedValue & " And " & _
                    " Processid=" & ddProcessName.SelectedValue & " And PartyId = " & DDPartyName.SelectedValue & ") Order by PM.PRMID Desc "
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            NewComboFillWithDs(DDChallanNo, ds, 0)
        End If
    End Sub

    Private Sub DDChallanNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDChallanNo.SelectedIndexChanged
        If (ChkForEdit.Checked = True) Then
            If DDChallanNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                Dim str As String = "Select Distinct a.ID, a.GatePassNo GatePass " & _
                        " From IndentRawReturnMaster a " & _
                        " JOIN IndentRawReturnDetail b ON b.ID = a.ID And b.PRMID = " & DDChallanNo.SelectedValue & " Order By GatePassNo"
                Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
                NewComboFillWithDs(DDGatePass, ds, 0)
            End If
        Else
            FillIssueDetail()
        End If
    End Sub

    Private Sub DDIssueno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        FillIssueDetail()
    End Sub

    Protected Sub FillIssueDetail()
        DG.Rows.Clear()
        Dim str As String = ""
        If DDChallanNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If ChkForEdit.Checked = True Then
                str = "Select 0 as ID,0 As DetailID, Item_Name, QualityName+' '+designName+' '+ColorName+' '+ShadeColorName+' '+ShapeName+' '+SizeFt As ItemDescription," & _
                " GodownName,LotNo,RecQuantity,RecQuantity-[dbo].[Get_RawReceiveBalQty] (PD.PRTID,PD.Finishedid,0,0)  As BalQty,0 As ReturnQty, Isnull(INDENTID,0) IndentID,PM.PrmID,PrtID,Finishedid,GM.GodownId,EmpID,'' As Remark,PD.Unitid,PD.TagNo" & _
                " from PP_ProcessRECMaster PM,PP_ProcessRECTran PD,GodownMaster GM,V_FinishedItemDetail V Where PM.PRMID=PD.PRMID And PD.Godownid=GM.GodownId " & _
                " And PD.FinishedId=V.ITEM_FINISHED_ID And PD.PRTID Not  IN (select Distinct PRTID from IndentRawReturnDetail)" & _
                " And PM.prmid= " & DDChallanNo.SelectedValue & " And PM.Companyid=" & DDcompany.SelectedValue & " And EmpID=" & DDPartyName.SelectedValue & " AND ProcessID=" & ddProcessName.SelectedValue & " " & _
                " UNION " & _
                " Select Distinct  1 as ID,1 As DetailID, Item_Name,QualityName+' '+designName+' '+ColorName+' '+ShadeColorName+' '+ShapeName+' '+SizeFt As ItemDescription," & _
                " GodownName,PD.LotNo,PRD.RecQuantity,PRD.RecQuantity -[dbo].[Get_RawReceiveBalQty] (PD.PRTID,PD.Finishedid,0,0)  As BalQty, [dbo].[Get_IndentRawReturnQty] (PD.DetailID,PD.Finishedid,0," & DDGatePass.SelectedValue & ") As ReturnQty,Isnull(PD.Indentid,0) Indentid," & _
                " PD.PRMID,PD.PRTID,PD.Finishedid,GM.GodownId,PM.PartyId,PD.Remarks As Remark,PD.Unitid,PD.TagNo" & _
                " from IndentRawReturnMaster PM,IndentRawReturnDetail PD,GodownMaster GM,V_FinishedItemDetail V ,PP_ProcessRECTran PRD" & _
                " Where PM.ID=PD.ID and PRD.PRTID=PD.PRTID" & _
                " And PD.Godownid=GM.GodownId And PD.FinishedId=V.ITEM_FINISHED_ID And PM.ChallanNo= '" & DDChallanNo.SelectedItem.Text.Trim() & "' And PM.Companyid=" & DDcompany.SelectedValue & " And PartyId=" & DDPartyName.SelectedValue & "" & _
                " Order By Item_Name"
            Else
                str = "Select Item_Name,0 As DetailID, QualityName+' '+designName+' '+ColorName+' '+ShadeColorName+' '+ShapeName+' '+SizeFt As ItemDescription," & _
                    " GodownName,LotNo,RecQuantity,RecQuantity-[dbo].[Get_RawReceiveBalQty] (PD.PRTID,PD.Finishedid,0,0) As BalQty,0 As ReturnQty, " & _
                    " Isnull(PD.INDENTID,0) IndentID,PM.PrmID,PrtID,Finishedid,GM.GodownId,EmpID,'' As Remark,PD.Unitid,PD.TagNo" & _
                    " from PP_ProcessRECMaster PM,PP_ProcessRECTran PD,GodownMaster GM,V_FinishedItemDetail V Where PM.PRMID=PD.PRMID And PD.Godownid=GM.GodownId " & _
                    " And PD.FinishedId=V.ITEM_FINISHED_ID And PM.prmid=" & DDChallanNo.SelectedValue & " And PM.Companyid=" & DDcompany.SelectedValue & " And EmpID=" & DDPartyName.SelectedValue & " AND ProcessID=" & ddProcessName.SelectedValue & "  Order By Item_Name"
            End If

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    DG.Rows.Add()
                    DG.Item("Item_Name", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_Name")
                    DG.Item("ItemDescription", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Itemdescription")
                    DG.Item("GodownName", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GodownName")
                    DG.Item("LotNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("LotNo")
                    DG.Item("RecQuantity", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RecQuantity")
                    DG.Item("BalQty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("BalQty")
                    DG.Item("IndentID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IndentID")
                    DG.Item("PRMID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("PrmID")
                    DG.Item("PRTID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("PrtID")
                    DG.Item("Finishedid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Finishedid")
                    DG.Item("Godownid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GodownId")
                    DG.Item("EmpId", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("EmpID")
                    DG.Item("Unitid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Unitid")
                    DG.Item("TagNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
                Next
            End If
        End If
    End Sub

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
        If Validcombobox(ddProcessName) = False Then Exit Sub
        If Validcombobox(DDPartyName) = False Then Exit Sub
        If Validcombobox(DDChallanNo) = False Then Exit Sub

        If DG.Item("ReturnQty", DG.CurrentRow.Index).Value = "" Then
            MsgBox("Please enter return qty weight")
            Exit Sub
        End If

        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim param As SqlParameter() = New SqlParameter(23) {}
            param(0) = New SqlParameter("@PartyID", DDPartyName.SelectedValue)
            param(1) = New SqlParameter("@CompanyID", DDcompany.SelectedValue)
            param(2) = New SqlParameter("@UserID", varuserid)
            param(3) = New SqlParameter("@MasterCompanyID", VarMasterCompanyID)
            param(4) = New SqlParameter("@GatePassNo", SqlDbType.VarChar, 50)
            param(4).Direction = ParameterDirection.InputOutput
            param(4).Value = txtretNo.Text
            param(5) = New SqlParameter("@ChallanNo", DDChallanNo.SelectedValue)
            param(6) = New SqlParameter("@Date", txtretdate.Text)
            param(7) = New SqlParameter("@PrmID", Val(DG.Item("PrmID", DG.CurrentRow.Index).Value))
            param(8) = New SqlParameter("@PrtID", Val(DG.Item("PrtID", DG.CurrentRow.Index).Value))
            param(9) = New SqlParameter("@FinishedID", Val(DG.Item("FinishedID", DG.CurrentRow.Index).Value))
            param(10) = New SqlParameter("@Mode", If(ChkForEdit.Checked = True, 1, 0))
            param(11) = New SqlParameter("@GodownID", Val(DG.Item("GodownID", DG.CurrentRow.Index).Value))
            param(12) = New SqlParameter("@LotNo", Val(DG.Item("LotNo", DG.CurrentRow.Index).Value))
            param(13) = New SqlParameter("@Qty", Val(DG.Item("ReturnQty", DG.CurrentRow.Index).Value))
            param(14) = New SqlParameter("@IndentID", Val(DG.Item("IndentID", DG.CurrentRow.Index).Value))
            param(15) = New SqlParameter("@Remarks", "")
            param(16) = New SqlParameter("@ID", reportid)
            param(16).Direction = ParameterDirection.InputOutput
            param(17) = New SqlParameter("@DetailID", 0)
            param(17).Direction = ParameterDirection.Output
            param(18) = New SqlParameter("@ProcessID", ddProcessName.SelectedValue)
            param(19) = New SqlParameter("@Message", SqlDbType.VarChar, 250)
            param(19).Direction = ParameterDirection.Output
            param(20) = New SqlParameter("@Unitid", Val(DG.Item("UnitID", DG.CurrentRow.Index).Value))
            param(21) = New SqlParameter("@TagNo", Val(DG.Item("TagNo", DG.CurrentRow.Index).Value))

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_RawReturn_Save", param)
            reportid = param(16).Value.ToString()
            MsgBox(param(19).Value.ToString())
            txtretNo.Text = param(4).Value.ToString()
            Tran.Commit()
            FillIssueDetail()
            FillReturnDetails()
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub DG_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEnter
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
            Case "RETURNQTY"
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

    Protected Sub FillReturnDetails()
        DGReturnedDetail.Rows.Clear()
        Dim str As String = "select a.GatePassNo, a.ChallanNo ReturnNo, dbo.F_getItemDescription(b.FinishedID, 0) ItemDescription," & _
                "U.UnitName, GM.GodownName, b.Lotno, b.Tagno, b.Qty Returnqty, a.ID Masterid, b.DetailID " & _
                "From IndentRawReturnMaster a inner join IndentRawReturnDetail b ON b.ID = a.ID " & _
                "inner join Unit U on b.Unitid=U.UnitId " & _
                "inner join GodownMaster GM on b.GodownId=GM.GoDownID Where a.id = " & reportid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            txtretNo.Text = ds.Tables(0).Rows(0)("GatePassNo")
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

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        reportid = 0
        DDPartyName.SelectedIndex = -1
        DDChallanNo.SelectedIndex = -1
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
        Dim str As String = "Select Distinct PM.ID,PD.DetailID, Item_Name,QualityName+' '+designName+' '+ColorName+' '+ShadeColorName+' '+ShapeName+' '+SizeFt As ItemDescription," & _
                    " GodownName,PD.LotNo,PRD.RecQuantity,PRD.RecQuantity -  [dbo].[Get_RawReceiveBalQty] (PD.PRTID,PD.Finishedid,0,0) As BalQty,PD.QTY As ReturnQty,PD.Remarks As Remark ," & _
                    " e.EmpName,C.CompanyName,C.CompAddr1+ ' '+ C.CompAddr2+ ' '+ C.CompAddr2 As CompAdd, C.TINNO,C.Email,C.CompTel,C.CompFax,PM.GatePassNo,Pm.ChallanNo,PM.Date," & _
                    " PNM.PROCESS_NAME, om.LocalOrder, om.CustomerOrderNo, vi.IndentNo, CI.customercode" & _
                    " From IndentRawReturnMAster PM,IndentRawReturnDetail PD,GodownMaster GM,V_FinishedItemDetail V ,PP_ProcessRectran PRD," & _
                    " EmpInfo E, CompanyInfo C,PROCESS_NAME_MASTER PNM,PP_ProcessRecMaster PRM,V_Indent_OredrId VI," & _
                    " OrderMaster OM,customerinfo CI " & _
                    " Where PM.ID = PD.ID And PRD.PRTID = PD.PRTID And e.EmpID = PM.PartyID And C.Companyid = PM.Companyid " & _
                    " And C.MasterCompanyid=PM.MasterCompanyid" & _
                    " And PD.Godownid=GM.GodownId And PD.FinishedId=V.ITEM_FINISHED_ID " & _
                    " and PRM.PRMid=PRD.PRMid and PNM.PROCESS_NAME_ID=PRM.Processid" & _
                    " and Vi.IndentId=Pd.INDENTID" & _
                    " and OM.OrderId=VI.Orderid and om.customerid=CI.customerid And PM.id = " & reportid

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String

            sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptIndentRawReturnDuplicate.rpt")

            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptIndentRawReturn.xsd")
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
            'If MsgBox("Do You want to delete this row?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub
            'If Con.State = ConnectionState.Closed Then
            '    Con.Open()
            'End If
            'Dim Tran As SqlTransaction = Con.BeginTransaction()
            'Try
            '    Dim arr(5) As SqlParameter
            '    arr(0) = New SqlParameter("@Masterid", DGReturnedDetail("Masterid", DGReturnedDetail.CurrentRow.Index).Value)
            '    arr(1) = New SqlParameter("@Detailid", DGReturnedDetail("Detailid", DGReturnedDetail.CurrentRow.Index).Value)
            '    arr(2) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            '    arr(2).Direction = ParameterDirection.Output
            '    arr(3) = New SqlParameter("@userid", varuserid)
            '    arr(4) = New SqlParameter("@MastercompanyId", VarMasterCompanyID)

            '    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_DELETEYARNOPENINGRETURN", arr)
            '    Tran.Commit()
            '    MsgBox(arr(2).Value.ToString())
            '    FillReturnDetails()
            'Catch ex As Exception
            '    Tran.Rollback()
            '    MsgBox(ex.Message)
            'End Try
        End If
    End Sub

    Private Sub frmyarnopeningreturn_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub DDGatePass_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGatePass.SelectedIndexChanged
        If DDGatePass.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            reportid = DDGatePass.SelectedValue
            FillReturnDetails()
        End If
    End Sub
End Class