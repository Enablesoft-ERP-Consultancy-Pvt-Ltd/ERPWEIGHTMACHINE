Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading

Public Class frmHandspinningreturn
    Dim gridindex As Integer = 0
    Dim gridcolname As String = ""
    Dim reportid As String = "0"
    Private Sub frmmottelingreturn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select Distinct CI.CompanyId,CI.CompanyName from Companyinfo CI,Company_Authentication CA Where CI.CompanyId=CA.CompanyId And CA.UserId=" & varuserid & "  And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By CompanyName " & _
                           "select PROCESS_NAME_ID,Process_name From process_name_master  where Processtype=0 and Process_name='Hand Spinning' and mastercompanyid=" & VarMasterCompanyID & " order by PROCESS_NAME " & _
                           "select GoDownID,GodownName from GodownMaster where MasterCompanyid=" & VarMasterCompanyID & " order by GodownName "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(DDCompanyName, ds, 0)
        If DDCompanyName.Items.Count > 0 Then
            DDCompanyName.SelectedIndex = 0
        End If
        NewComboFillWithDs(DDProcessName, ds, 1)
        NewComboFillWithDs(DDGodown, ds, 2)
        If DDProcessName.Items.Count > 0 Then
            DDProcessName.SelectedIndex = 0
            DDProcessName_SelectedIndexChanged(sender, e)
        End If

        txtretdate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy")
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If
        ds.Dispose()
    End Sub

    Private Sub DDProcessName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDProcessName.SelectedIndexChanged
        If DDProcessName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            reportid = "0"
            NewComboFill(DDPartyName, "Select EI.EmpId,EI.EmpName+case when isnull(Ei.Empcode,'')='' Then '' Else '['+EI.Empcode+']' End as Empname From EmpInfo EI inner join EmpProcess EP on EI.EmpId=EP.EmpId and EP.ProcessId=" & DDProcessName.SelectedValue & " order by empname")
        End If
    End Sub

    Private Sub DDPartyName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDPartyName.SelectedIndexChanged
        reportid = "0"
        If DDCompanyName.SelectedIndex <> -1 And DDProcessName.SelectedIndex <> -1 And DDPartyName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select ID,IssueNo + ' # ' +REPLACE(CONVERT(nvarchar(11),IssueDate,106),' ','-') as IssueNo From HandspinningIssuemaster Where Companyid=" & DDCompanyName.SelectedValue & " and processid=" & DDProcessName.SelectedValue & " and empid=" & DDPartyName.SelectedValue

            str = str & " and status='Pending'"

            str = str & "  order by id desc"
            NewComboFill(DDissueno, str)
        End If
    End Sub

    Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGodown.SelectedIndexChanged
        If DDGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            If VarCHECKBINCONDITION = 1 Then
                Module1.FillBinNO(DDBinNo, DDGodown.SelectedValue, Item_finished_id:=0, New_Edit:=0)
            Else
                NewComboFill(DDBinNo, "SELECT DISTINCT BINNO,BINNO AS BINNO1 FROM STOCK S WHERE GODOWNID=" & DDGodown.SelectedValue & "  ORDER BY BINNO1")
            End If
        End If
    End Sub
    Protected Sub FillIssueDetail()
        DG.Rows.Clear()
        Dim Pqty As Decimal
        If DDissueno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select dbo.F_getItemDescription(YT.iFinishedid,YT.iflagsize) as ItemDescription," & _
                       "U.UnitName,YT.Lotno,YT.Tagno,Round(yt.IssueQty,3) as IssueQty, isnull(YRQ.retqty,0) as Returnedqty,YT.ifinishedid,YT.Unitid,YT.iflagsize as flagsize,YM.ID,yt.Detailid, YT.Rfinishedid " & _
                       "from HandspinningIssuemaster YM inner join HandspinningIssueDetail YT on YM.ID = YT.MasterId " & _
                       "inner join Unit U on YT.Unitid=U.UnitId " & _
                       "left join V_getMottelingReturnQty YRQ on YT.Detailid=YRQ.Issuedetailid and YT.MasterId=YRQ.issuemasterid " & _
                       " Where YM.Id = " & DDissueno.SelectedValue & ""

            str = str & " select isnull(dbo.[F_GETHANDSPINNINGRECDQTY_ISSUENO](" & DDissueno.SelectedValue & "),0) as Recdqty"

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    DG.Rows.Add()
                    DG.Item("ItemDescription", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Itemdescription")
                    DG.Item("unitname", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitname")
                    DG.Item("Lotno", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
                    DG.Item("Tagno", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Tagno")
                    DG.Item("issuedqty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("issueqty")
                    DG.Item("Returnedqty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Returnedqty")
                    Pqty = Val(ds.Tables(0).Rows(i)("issueqty")) - Val(ds.Tables(0).Rows(i)("Returnedqty"))
                    DG.Item("Pqty", DG.Rows.Count - 1).Value = Pqty
                    DG.Item("lblitemfinishedid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ifinishedid")
                    DG.Item("lblunitid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitid")
                    DG.Item("lblflagsize", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("flagsize")
                    DG.Item("lblissuemasterid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("id")
                    DG.Item("lblissuemasterdetailid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Detailid")
                    DG.Item("lblRFinishedID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RFinishedID")
                Next
            End If
            lbltotalrec.Text = "Total Received Qty : 0"
            If ds.Tables(1).Rows.Count > 0 Then
                lbltotalrec.Text = "Total Received Qty : " & ds.Tables(1).Rows(0)("Recdqty")
            End If
        End If
    End Sub

    Private Sub DDissueno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDissueno.SelectedIndexChanged
        FillIssueDetail()
    End Sub
    Protected Sub SaveDetails()

        If Validcombobox(DDCompanyName) = False Then Exit Sub
        If Validcombobox(DDProcessName) = False Then Exit Sub
        If Validcombobox(DDPartyName) = False Then Exit Sub
        If Validcombobox(DDissueno) = False Then Exit Sub
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
        dtrecords.Columns.Add("RFinishedID", GetType(Integer))

        For i As Integer = 0 To DG.Rows.Count - 1
            ''DirectCast(DG.Rows(i).Cells("Retqty"), DataGridViewTextBoxCell)
            Dim txtretqty As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("Retqty"), DataGridViewTextBoxCell)
            If txtretqty.Value <> "" AndAlso DDGodown.SelectedIndex <> -1 Then
                Dim lblitemfinishedid As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblitemfinishedid"), DataGridViewTextBoxCell)
                Dim lblunitid As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblunitid"), DataGridViewTextBoxCell)
                Dim lblflagsize As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblflagsize"), DataGridViewTextBoxCell)
                Dim lblLotno As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("Lotno"), DataGridViewTextBoxCell)
                Dim lblTagno As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("Tagno"), DataGridViewTextBoxCell)
                Dim lblissuemasterid As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblissuemasterid"), DataGridViewTextBoxCell)
                Dim lblissuemasterdetailid As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblissuemasterdetailid"), DataGridViewTextBoxCell)
                Dim lblRFinishedID As DataGridViewTextBoxCell = DirectCast(DG.Rows(i).Cells("lblRFinishedID"), DataGridViewTextBoxCell)
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
                dr("RFinishedID") = lblRFinishedID.Value
                dtrecords.Rows.Add(dr)
            End If
        Next

        If dtrecords.Rows.Count > 0 Then
            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim param As SqlParameter() = New SqlParameter(11) {}
                param(0) = New SqlParameter("@id", SqlDbType.Int)
                param(0).Direction = ParameterDirection.InputOutput
                param(0).Value = 0
                param(1) = New SqlParameter("@dtrecords", dtrecords)
                param(2) = New SqlParameter("@companyId", DDCompanyName.SelectedValue)
                param(3) = New SqlParameter("@vendorid", DDPartyName.SelectedValue)
                param(4) = New SqlParameter("@returnNo", SqlDbType.VarChar, 100)
                param(4).Direction = ParameterDirection.Output
                param(5) = New SqlParameter("@RetDate", txtretdate.Text)
                param(6) = New SqlParameter("@userid", varuserid)
                param(7) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(7).Direction = ParameterDirection.Output
                param(8) = New SqlParameter("@mastercompanyid", VarMasterCompanyID)
                param(9) = New SqlParameter("@issuemasterid", DDissueno.SelectedValue)
                param(10) = New SqlParameter("@BinNo", If(DDBinNo.Visible = True, DDBinNo.Text, ""))
                param(11) = New SqlParameter("@Processid", DDProcessName.SelectedValue)
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_HandSpinningReturn", param)
                reportid = param(0).Value.ToString()
                txtretNo.Text = param(4).Value.ToString()
                If param(7).Value.ToString() <> "" Then
                    MsgBox(param(7).Value.ToString())
                    Tran.Commit()
                Else
                    MsgBox("Data Saved Successfully.")
                    Tran.Commit()
                    FillIssueDetail()
                    FillReturnDetails()
                End If
            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message)

            End Try
        Else
            MsgBox("Please Fill atleast one Ret Qty to save data.")
        End If
    End Sub
    Private Sub FillReturnDetails()
        DGReturnedDetail.Rows.Clear()
        Dim str As String = "select Ym.id,Yt.detailid,YM.ReturnNo,dbo.F_getItemDescription(YT.Item_Finished_id,YT.flagsize) as ItemDescription," & _
                        "U.UnitName,Gm.GodownName,YT.Lotno,YT.Tagno,yt.Retqty as Returnqty,Replace(convert(nvarchar(11),Ym.ReturnDate,106),' ','-') as ReturnDate " & _
                        "from Handspinningreturnmaster YM inner join HandspinningreturnDetail YT on YM.ID = YT.MasterId " & _
                        "inner join Unit U on YT.Unitid=U.UnitId " & _
                        "inner join GodownMaster GM on YT.GodownId=Gm.GoDownID Where YM.id=" & reportid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            txtretNo.Text = ds.Tables(0).Rows(0)("ReturnNo").ToString()
            txtretdate.Text = ds.Tables(0).Rows(0)("returndate").ToString()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                DGReturnedDetail.Rows.Add()
                DGReturnedDetail.Item("lblid", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("id")
                DGReturnedDetail.Item("lbldetailid", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Detailid")
                DGReturnedDetail.Item("ReturnNo", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ReturnNo")
                DGReturnedDetail.Item("Ritemdescription", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Itemdescription")
                DGReturnedDetail.Item("Runitname", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Unitname")
                DGReturnedDetail.Item("Godownname", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Godownname")
                DGReturnedDetail.Item("Rlotno", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
                DGReturnedDetail.Item("RTagno", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Tagno")
                DGReturnedDetail.Item("RRetqty", DGReturnedDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Returnqty")

            Next
        End If
    End Sub

    Private Sub DGReturnedDetail_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DGReturnedDetail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub


            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim lblDetailid As DataGridViewTextBoxCell = DirectCast(DGReturnedDetail.Rows(DGReturnedDetail.CurrentRow.Index).Cells("lblDetailid"), DataGridViewTextBoxCell)
                Dim lblid As DataGridViewTextBoxCell = CType(DGReturnedDetail.Rows(DGReturnedDetail.CurrentRow.Index).Cells("lblid"), DataGridViewTextBoxCell)
                Dim arr As SqlParameter() = New SqlParameter(2) {}
                arr(0) = New SqlParameter("@Detailid", lblDetailid.Value)
                arr(1) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                arr(1).Direction = ParameterDirection.Output
                arr(2) = New SqlParameter("@ID", lblid.Value)
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_DELETEHandSpinningRETURN", arr)
                MsgBox(arr(1).Value.ToString())
                Tran.Commit()
                FillReturnDetails()
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        End If
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = "select  * from [V_HandSpinningReturn] Where id=" & reportid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String

            sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptHandspinningreturn.rpt")

            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\rptHandspinningreturn.xsd")
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
    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub frmmottelingreturn_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub DG_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellEndEdit
        Select Case UCase(DG.Columns(e.ColumnIndex).Name)
            Case "RETQTY"
                SaveDetails()
                If _serialPort IsNot Nothing Then
                    _serialPort.Close()
                    _serialPort = Nothing
                End If
        End Select
    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        DDPartyName.SelectedIndex = -1
        DDissueno.SelectedIndex = -1
        DG.Rows.Clear()
        DGReturnedDetail.Rows.Clear()
        reportid = "0"

    End Sub
    Private Sub txtWeaverIdNoscan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtWeaverIdNoscan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim str As String = "select empid From Empinfo Where empcode='" & txtWeaverIdNoscan.Text & "'"
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                DDPartyName.SelectedValue = ds.Tables(0).Rows(0)("empid")
                DDPartyName_SelectedIndexChanged(sender, New EventArgs())
                txtWeaverIdNoscan.Text = ""
            Else
                MsgBox("Employee Code does not exists in this Department.")
                txtWeaverIdNoscan.Focus()
            End If
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
End Class