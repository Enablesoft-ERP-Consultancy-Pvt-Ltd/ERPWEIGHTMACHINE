Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Imports System.Drawing.Printing

Public Class FrmFirstProcessReceive
    Dim VarProcess_Rec_ID As Integer
    Dim VarRejectedGatePassNo As Integer
    Dim Var100_IssueOrderID As Integer
    Dim Var100_Process_Rec_ID As Integer

    Private Sub FrmFirstProcessReceive_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select Ei.EmpId,EI.EmpName From Empinfo EI(Nolock) " & _
            " join Department D on EI.Departmentid=D.DepartmentId And D.DepartmentName = 'QC Department' order by Ei.EmpName" & _
            " Select ID, TypeName From StockType(Nolock) "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(DDQAName, ds, 0)
        NewComboFillWithDs(DDStockQuality, ds, 1)
        If DDStockQuality.Items.Count > 0 Then
            DDStockQuality.SelectedIndex = 0
        End If
        VarProcess_Rec_ID = 0
        VarRejectedGatePassNo = 0
        Var100_IssueOrderID = 0
        Var100_Process_Rec_ID = 0

    End Sub
    Private Sub TxtStockNo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtStockNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtEmployeeName.Text = ""
            Dim param(1) As SqlParameter
            param(0) = New SqlParameter("@TstockNo", TxtStockNo.Text)

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "PRO_GETLOOMSTOCKDETAIL", param)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    TxtFolioNo.Text = ds.Tables(0).Rows(0)("IssueOrderID")
                    TxtItemName.Text = ds.Tables(0).Rows(0)("Item_Name")
                    TxtQuality.Text = ds.Tables(0).Rows(0)("QualityName")
                    TxtDesign.Text = ds.Tables(0).Rows(0)("DesignName")
                    TxtColor.Text = ds.Tables(0).Rows(0)("ColorName")
                    TxtShape.Text = ds.Tables(0).Rows(0)("ShapeName")
                    TxtSize.Text = ds.Tables(0).Rows(0)("Size")
                    TxtWidth.Text = ds.Tables(0).Rows(0)("Width")
                    TxtLength.Text = ds.Tables(0).Rows(0)("Length")
                    TxtArea.Text = ds.Tables(0).Rows(0)("Area")
                    TxtConsumption.Text = ds.Tables(0).Rows(0)("Consumption")
                    TxtPcsType.Text = ds.Tables(0).Rows(0)("Pcstype")
                    TxtComm.Text = ds.Tables(0).Rows(0)("Comm")
                Next
                If ds.Tables(1).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(1).Rows.Count - 1
                        TxtEmployeeName.Text = TxtEmployeeName.Text & ", " & ds.Tables(1).Rows(0)("EmpName")
                    Next
                End If
                TxtActualWidth.Focus()
            Else
                MsgBox("Stock No. does not exists or Pending.")
                TxtStockNo.Text = ""
                TxtStockNo.Focus()
            End If
        End If
    End Sub

    Private Sub DG_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Dim i As Integer = DG.CurrentRow.Index
        'DG.Rows.RemoveAt(i)
    End Sub

    Private Sub DG_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then Exit Sub

            'If Con.State = ConnectionState.Closed Then
            '    Con.Open()
            'End If

            'Dim Tran As SqlTransaction = Con.BeginTransaction()
            'Try
            '    Dim VarProcess_Issue_Detail_Id As Integer = gvdetail.Item("prtid", gvdetail.CurrentRow.Index).Value
            '    Dim _arrPara As SqlParameter() = New SqlParameter(4) {}
            '    _arrPara(0) = New SqlParameter("@PRTID", SqlDbType.Int)
            '    _arrPara(1) = New SqlParameter("@COUNT", SqlDbType.Int)
            '    _arrPara(2) = New SqlParameter("@Msg", SqlDbType.NVarChar, 250)
            '    _arrPara(3) = New SqlParameter("@Userid", SqlDbType.Int)
            '    _arrPara(4) = New SqlParameter("@Mastercompanyid", SqlDbType.Int)
            '    _arrPara(0).Value = VarProcess_Issue_Detail_Id
            '    If gvdetail.Rows.Count = 1 Then
            '        _arrPara(1).Value = 1
            '    End If

            '    _arrPara(2).Direction = ParameterDirection.Output
            '    _arrPara(3).Value = varuserid
            '    _arrPara(4).Value = VarMasterCompanyID
            '    SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PP_PRM_RECEIVE_DELETE", _arrPara)
            '    Tran.Commit()
            '    Fill_Grid()
            '    MsgBox(_arrPara(2).Value.ToString())
            'Catch ex As Exception
            '    Tran.Rollback()
            '    MsgBox(ex.Message)

            'End Try
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

                txtWeight.Text = w_Weight.ToString()

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()
    Private Sub txtWeight_GotFocus(sender As Object, e As System.EventArgs) Handles txtWeight.GotFocus
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
                Return
            End If
        End If
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Validtxtbox(TxtFolioNo) = False Then Exit Sub
        If Validtxtbox(TxtStockNo) = False Then Exit Sub
        If Validtxtbox(TxtActualWidth) = False Then Exit Sub
        If Validtxtbox(TxtActualLength) = False Then Exit Sub
        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim param(28) As SqlParameter
            param(0) = New SqlParameter("@Process_Rec_id", SqlDbType.Int)
            param(0).Direction = ParameterDirection.InputOutput
            param(0).Value = Val(VarProcess_Rec_ID)
            param(1) = New SqlParameter("TStockNo", TxtStockNo.Text)
            param(2) = New SqlParameter("@ActualWidth", TxtActualWidth.Text)
            param(3) = New SqlParameter("@ActualLength", TxtActualLength.Text)
            param(4) = New SqlParameter("@Weight", txtWeight.Text)
            param(5) = New SqlParameter("@PenalityAmt", TxtPenalityAmt.Text)
            param(6) = New SqlParameter("@PenalityRemark", TxtPenalityRemark.Text)
            param(7) = New SqlParameter("@QUALITYTYPE", DDStockQuality.SelectedValue)
            param(8) = New SqlParameter("@QAPERSONNAME", DDQAName.SelectedValue)
            param(9) = New SqlParameter("@ReceiveNo", SqlDbType.VarChar, 50)
            param(9).Direction = ParameterDirection.InputOutput
            param(9).Value = TxtReceiveNo.Text
            param(10) = New SqlParameter("@ReceiveDate", txtdate.Text)
            param(11) = New SqlParameter("@PartyChallanNo", TxtPartyChallanNo.Text)
            param(12) = New SqlParameter("@MasterCompanyID", VarMasterCompanyID)
            param(13) = New SqlParameter("@UserID", varuserid)
            param(14) = New SqlParameter("@msg", SqlDbType.VarChar, 500)
            param(14).Direction = ParameterDirection.InputOutput
            param(15) = New SqlParameter("@MaxRejectedGatePassNo", SqlDbType.Int)
            param(15).Direction = ParameterDirection.InputOutput
            param(15).Value = VarRejectedGatePassNo
            param(16) = New SqlParameter("@100_ISSUEORDERID", SqlDbType.Int)
            param(16).Direction = ParameterDirection.InputOutput
            param(16).Value = Var100_IssueOrderID
            param(17) = New SqlParameter("@100_PROCESS_REC_ID", SqlDbType.Int)
            param(17).Direction = ParameterDirection.InputOutput
            param(17).Value = Var100_Process_Rec_ID
            param(18) = New SqlParameter("@CommRate", TxtComm.Text)

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "[PRO_PRODUCTIONLOOMRECEIVESTOCKNOWISE_WEIGHTMACHINE]", param)
            VarProcess_Rec_ID = param(0).Value.ToString()
            TxtReceiveNo.Text = param(9).Value.ToString()
            VarRejectedGatePassNo = param(15).Value.ToString()
            Var100_IssueOrderID = param(16).Value.ToString()
            Var100_Process_Rec_ID = param(17).Value.ToString()

            Tran.Commit()
            Clear()
            If param(14).Value.ToString() <> "" Then
                MsgBox(param(14).Value.ToString())
            Else
                MsgBox("Data successfully saved")
            End If
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    'SqlParameter[] array = new SqlParameter[1];
    '    array[0] = new SqlParameter("@Process_Rec_Id", hnprocessrecid.Value);

    '    DataSet ds = SqlHelper.ExecuteDataset(ErpGlobal.DBCONNECTIONSTRING, CommandType.StoredProcedure, "Pro_ForProductionReceiveReport_Loom", array);
    '    DGRecDetail.DataSource = ds.Tables[0];
    '    DGRecDetail.DataBind();

    Private Sub BtnShowData_Click(sender As System.Object, e As System.EventArgs) Handles BtnShowData.Click
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@Process_Rec_Id", VarProcess_Rec_ID)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "Pro_ForProductionReceiveReport_Loom", param)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                DG.Rows.Add()
                DG.Item("SrNo", DG.Rows.Count - 1).Value = i + 1
                DG.Item("TStockNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("StockNo")
                DG.Item("Description", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ItemDescription")
                DG.Item("ActualWidth", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ActualWidth")
                DG.Item("ActualLength", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ActualLength")
                DG.Item("Area", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Area")
                DG.Item("Weight", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Weight")
                DG.Item("Comm", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Comm")
                DG.Item("Rate", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rate")
                DG.Item("Qty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RecQty")
                DG.Item("Penality", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Penality")
                DG.Item("IssueOrderID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IssueOrderID")
                DG.Item("Process_Rec_ID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Process_Rec_ID")
                DG.Item("Process_Rec_Detail_ID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Process_Rec_Detail_ID")
            Next
        End If
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@Process_Rec_Id", VarProcess_Rec_ID)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "PRO_FORPRODUCTIONRECEIVEREPORT_LOOMREPORT", param)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String

            sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptProductionreceivedetailchampo.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\rptProductionreceivedetail.xsd")
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
    Protected Sub Clear()
        TxtFolioNo.Text = ""
        TxtItemName.Text = ""
        TxtQuality.Text = ""
        TxtDesign.Text = ""
        TxtColor.Text = ""
        TxtShape.Text = ""
        TxtSize.Text = ""
        TxtWidth.Text = ""
        TxtLength.Text = ""
        TxtArea.Text = ""
        TxtConsumption.Text = ""
        TxtPcsType.Text = ""
        TxtComm.Text = ""
        TxtStockNo.Text = ""
        TxtActualLength.Text = ""
        TxtActualWidth.Text = ""
        TxtPenalityAmt.Text = ""
        TxtPenalityRemark.Text = ""
        txtWeight.Text = ""
        TxtEmployeeName.Text = ""
        TxtStockNo.Focus()
    End Sub
    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        Clear()
        TxtReceiveNo.Text = ""
        TxtPartyChallanNo.Text = ""
        VarProcess_Rec_ID = 0
        VarRejectedGatePassNo = 0
        Var100_IssueOrderID = 0
        Var100_Process_Rec_ID = 0
    End Sub
End Class