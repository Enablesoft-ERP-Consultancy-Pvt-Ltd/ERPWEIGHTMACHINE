Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Imports System.Drawing.Printing

Public Class frmStockNoAttachWeight
    Private Sub frmStockNoAttachWeight_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
    End Sub
    Private Sub TxtStockNo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtStockNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            DG.Rows.Add()
            DG.Item("StockNo", DG.Rows.Count - 1).Value = TxtStockNo.Text
            TxtStockNo.Text = ""
        End If
    End Sub

    Private Sub DG_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellDoubleClick
        Dim i As Integer = DG.CurrentRow.Index
        DG.Rows.RemoveAt(i)
    End Sub

    Private Sub DG_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DG.KeyDown
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

    Private Sub txtWeight_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtWeight.KeyDown
        If e.KeyCode = Keys.Enter Then
            Save()
        End If
    End Sub
    Protected Sub Save()
        If DG.Rows.Count = 0 Then
            MsgBox("Please enter stock no", MsgBoxStyle.OkOnly)
            txtWeight.Text = ""
            TxtStockNo.Focus()
            Exit Sub
        End If
        If Validtxtbox(txtWeight) = False Then Exit Sub

        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If
        Dim StockNo As String = ""
        If (DG.Rows.Count > 0) Then
            For i = 0 To DG.Rows.Count - 1
                StockNo = DG.Item("StockNo", i).Value + "," + StockNo
            Next
        End If
        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim arr As SqlParameter() = New SqlParameter(5) {}
            arr(0) = New SqlParameter("@StockNo", StockNo)
            arr(1) = New SqlParameter("@Weight", txtWeight.Text)
            arr(2) = New SqlParameter("@Mastercompanyid", VarMasterCompanyID)
            arr(3) = New SqlParameter("@userid", varuserid)
            arr(4) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            arr(4).Direction = ParameterDirection.Output

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_SAVESTOCKNOWISEBAZARWEIGHT", arr)

            If arr(4).Value.ToString() <> "" Then
                MsgBox(arr(4).Value.ToString())
            End If

            Tran.Commit()

            If arr(4).Value.ToString() = "DATA SAVED SUCCESSFULLY." Then
                TxtStockNo.Text = ""
                txtWeight.Text = ""
                DG.Rows.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Tran.Rollback()
        End Try
    End Sub

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs)
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
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
End Class