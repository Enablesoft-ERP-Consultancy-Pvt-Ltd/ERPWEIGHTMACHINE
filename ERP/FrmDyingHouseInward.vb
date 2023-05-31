Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class FrmDyingHouseInward
    Dim InwardID As Integer = 0
    Dim InwardDetailID As Integer = 0

    Private Sub FrmDyingHouseInward_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())

        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select Distinct CI.CompanyId,Companyname From Companyinfo CI(nolock),Company_Authentication CA(nolock) Where CA.CompanyId=CI.CompanyId And CA.UserId=" & varuserid & " And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By Companyname  " & _
            " Select ID, BranchName " & _
            " From BRANCHMASTER BM(nolock) " & _
            " JOIN BranchUser BU(nolock) ON BU.BranchID = BM.ID And BU.UserID = " & varuserid & " " & _
            " Where BM.CompanyID = " & VarCompanyID & " And BM.MasterCompanyID = " & VarMasterCompanyID & "" & _
            " Select Empid,EmpName + ' (' + EmpCode + ')' EmpName from empinfo(nolock) where mastercompanyid=" & VarMasterCompanyID & "  order by empname " & _
            " Select GM.GodownId, GM.GodownName From GodownMaster GM(nolock) JOIN Godown_Authentication GA(nolock) ON GM.GodownId=GA.GodownId Where GA.UserId=" & varuserid & " And GA.MasterCompanyId=" & VarMasterCompanyID & " Order by GodownName " & _
            " Select ID, ConeType From ConeMaster(Nolock) Order By SrNo "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(ddCompName, ds, 0)
        If ddCompName.Items.Count > 0 Then
            ddCompName.SelectedValue = VarCompanyID
            ddCompName.Enabled = False
        End If
        NewComboFillWithDs(DDBranchName, ds, 1)

        If DDBranchName.Items.Count > 0 Then
            DDBranchName.SelectedIndex = 0
            DDBranchName.Enabled = False
        End If
        NewComboFillWithDs(ddempname, ds, 2)

        If varTagNowise = 1 Then
            Label4.Visible = True
            TxtTagNo.Visible = True
        End If
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If
        NewComboFillWithDs(ddgodown, ds, 3)
        NewComboFillWithDs(DDConeType, ds, 4)
        TxtMoisture.Visible = True
        LblMoisture.Visible = True
    End Sub

    Private Sub ddempname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddempname.SelectedIndexChanged
        fill_emp_change()
    End Sub

    Private Sub fill_emp_change()
        Dim str As String = ""
        If ddCompName.SelectedIndex <> -1 And DDBranchName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            str = "Select Distinct IndentID, IndentNo From IndentMaster(Nolock) " & _
                " Where CompanyId = " & ddCompName.SelectedValue & " And BranchID = " & DDBranchName.SelectedValue & " And MasterCompanyId = " & VarMasterCompanyID & " And Status = 'Pending' Order By IndentID desc "
            NewComboFill(DDIndentNo, str)
        End If
    End Sub

    Private Sub DDIndentNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDIndentNo.SelectedIndexChanged
        FillIssueNo()
    End Sub

    Private Sub FillIssueNo()
        Dim str As String = ""
        If ddCompName.SelectedIndex <> -1 And DDBranchName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And DDIndentNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            str = "Select Distinct PRM.PRMid, PRM.ChallanNo " & _
                " From PP_ProcessRawMaster PRM(Nolock)" & _
                " JOIN PP_ProcessRawTran PRT(Nolock) ON PRT.PRMid = PRM.PRMid " & _
                " Where PRM.CompanyId = " & ddCompName.SelectedValue & " And PRM.BranchID = " & DDBranchName.SelectedValue & " And PRM.MasterCompanyId = " & VarMasterCompanyID & " " & _
                " And PRT.Indentid = " & DDIndentNo.SelectedValue & " " & _
                " Order By PRM.PRMid"
            NewComboFill(DDIssueNo, str)
        End If
    End Sub

    Private Sub DDIssueNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDIssueNo.SelectedIndexChanged
        Fill_Category()
    End Sub

    Private Sub Fill_Category()
        Dim str As String = ""
        If ddCompName.SelectedIndex <> -1 And DDBranchName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And DDIndentNo.SelectedIndex <> -1 And DDIssueNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            str = "Select Distinct VF.CATEGORY_ID, VF.CATEGORY_NAME " & _
                " From PP_ProcessRawMaster PRM(Nolock) " & _
                " JOIN PP_ProcessRawTran PRT(Nolock) ON PRT.PRMid = PRM.PRMid " & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = PRT.Finishedid " & _
                " Where PRM.Companyid = " & ddCompName.SelectedValue & " And PRM.BranchID = " & DDBranchName.SelectedValue & " " & _
                " And PRT.Indentid = " & DDIndentNo.SelectedValue & "  And PRM.PRMid = " & DDIssueNo.SelectedValue & " " & _
                " Order By VF.CATEGORY_NAME "
            NewComboFill(ddCatagory, str)
        End If
    End Sub

    Private Sub ddCatagory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddCatagory.SelectedIndexChanged
        ddlcategorycange()
    End Sub

    Protected Sub ddlcategorycange()
        Dim str As String = ""
        If ddCompName.SelectedIndex <> -1 And DDBranchName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And DDIndentNo.SelectedIndex <> -1 And DDIssueNo.SelectedIndex <> -1 And ddCatagory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            str = "Select Distinct VF.ITEM_ID, VF.ITEM_NAME " & _
                " From PP_ProcessRawMaster PRM(Nolock) " & _
                " JOIN PP_ProcessRawTran PRT(Nolock) ON PRT.PRMid = PRM.PRMid " & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = PRT.Finishedid " & _
                " Where PRM.Companyid = " & ddCompName.SelectedValue & " And PRM.BranchID = " & DDBranchName.SelectedValue & " " & _
                " And PRT.Indentid = " & DDIndentNo.SelectedValue & "  And PRM.PRMid = " & DDIssueNo.SelectedValue & " " & _
                " And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
                " Order By VF.ITEM_NAME " & _
                " SELECT [CATEGORY_PARAMETERS_ID],[CATEGORY_ID],IPM.[PARAMETER_ID],PARAMETER_NAME " & _
                " FROM [ITEM_CATEGORY_PARAMETERS] IPM(Nolock) " & _
                " inner join PARAMETER_MASTER PM(Nolock) ON PM.[PARAMETER_ID] = IPM.[PARAMETER_ID] And PM.MasterCompanyId = " & VarMasterCompanyID & " " & _
                " Where [CATEGORY_ID] = " & ddCatagory.SelectedValue & ""

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

            NewComboFillWithDs(dditemname, ds, 0)

            If (ds.Tables(1).Rows.Count > 0) Then
                Label10.Visible = False
                dquality.Visible = False
                LblDesign.Visible = False
                DDDesign.Visible = False
                LblColor.Visible = False
                DDColor.Visible = False
                LblShape.Visible = False
                DDShape.Visible = False
                LblSize.Visible = False
                DDSize.Visible = False
                Label11.Visible = False
                ddlshade.Visible = False

                For i = 0 To ds.Tables(1).Rows.Count - 1
                    Select Case ds.Tables(1).Rows(i)("PARAMETER_ID")
                        Case 1
                            Label10.Visible = True
                            dquality.Visible = True
                        Case 2
                            LblDesign.Visible = True
                            DDDesign.Visible = True

                            str = "Select Distinct VF.DesignID, VF.DesignName " & _
                                " From PP_ProcessRawMaster PRM(Nolock) " & _
                                " JOIN PP_ProcessRawTran PRT(Nolock) ON PRT.PRMid = PRM.PRMid " & _
                                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = PRT.Finishedid " & _
                                " Where PRM.Companyid = " & ddCompName.SelectedValue & " And PRM.BranchID = " & DDBranchName.SelectedValue & " " & _
                                " And PRT.Indentid = " & DDIndentNo.SelectedValue & "  And PRM.PRMid = " & DDIssueNo.SelectedValue & " " & _
                                " And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
                                " Order By VF.DesignName "
                            NewComboFill(DDDesign, str)
                        Case 3
                            LblColor.Visible = True
                            DDColor.Visible = True

                            str = "Select Distinct VF.ColorID, VF.ColorName " & _
                                " From PP_ProcessRawMaster PRM(Nolock) " & _
                                " JOIN PP_ProcessRawTran PRT(Nolock) ON PRT.PRMid = PRM.PRMid " & _
                                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = PRT.Finishedid " & _
                                " Where PRM.Companyid = " & ddCompName.SelectedValue & " And PRM.BranchID = " & DDBranchName.SelectedValue & " " & _
                                " And PRT.Indentid = " & DDIndentNo.SelectedValue & "  And PRM.PRMid = " & DDIssueNo.SelectedValue & " " & _
                                " And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
                                " Order By VF.ColorName "
                            NewComboFill(DDColor, str)
                        Case 4
                            LblShape.Visible = False
                            DDShape.Visible = False

                            str = "Select Distinct VF.ShapeId, VF.ShapeName " & _
                                " From PP_ProcessRawMaster PRM(Nolock) " & _
                                " JOIN PP_ProcessRawTran PRT(Nolock) ON PRT.PRMid = PRM.PRMid " & _
                                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = PRT.Finishedid " & _
                                " Where PRM.Companyid = " & ddCompName.SelectedValue & " And PRM.BranchID = " & DDBranchName.SelectedValue & " " & _
                                " And PRT.Indentid = " & DDIndentNo.SelectedValue & "  And PRM.PRMid = " & DDIssueNo.SelectedValue & " " & _
                                " And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
                                " Order By VF.ShapeName "
                            NewComboFill(DDShape, str)
                        Case 5
                            LblSize.Visible = True
                            DDSize.Visible = True
                        Case 6
                            Label11.Visible = True
                            ddlshade.Visible = True
                    End Select
                Next
            End If
        End If
    End Sub

    Private Sub DDShape_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDShape.SelectedIndexChanged
        If ddCompName.SelectedIndex <> -1 And DDBranchName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And DDIndentNo.SelectedIndex <> -1 And DDIssueNo.SelectedIndex <> -1 And ddCatagory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct VF.SizeID, VF.SizeFt " & _
                    " From PP_ProcessRawMaster PRM(Nolock) " & _
                    " JOIN PP_ProcessRawTran PRT(Nolock) ON PRT.PRMid = PRM.PRMid " & _
                    " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = PRT.Finishedid " & _
                    " Where PRM.Companyid = " & ddCompName.SelectedValue & " And PRM.BranchID = " & DDBranchName.SelectedValue & " " & _
                    " And PRT.Indentid = " & DDIndentNo.SelectedValue & "  And PRM.PRMid = " & DDIssueNo.SelectedValue & " " & _
                    " And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ShapeID = " & DDShape.SelectedValue & " " & _
                    " Order By VF.SizeFt "
            NewComboFill(DDSize, str)
        End If
    End Sub

    Private Sub dditemname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dditemname.SelectedIndexChanged
        ItemChanged()
    End Sub

    Private Sub ItemChanged()
        txtissqty.Text = ""
        Dim str As String = ""
        If ddCompName.SelectedIndex <> -1 And DDBranchName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And DDIndentNo.SelectedIndex <> -1 And DDIssueNo.SelectedIndex <> -1 And ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            str = "Select Distinct U.UnitID, U.UnitName " & _
                    " From PP_ProcessRawTran PRT(Nolock)  " & _
                    " JOIN Unit U(Nolock) ON U.UnitId = PRT.UnitID  " & _
                    " Where PRT.Indentid = " & DDIndentNo.SelectedValue & " And PRT.Prmid = " & DDIssueNo.SelectedValue & " " & _
                    " Order By U.UnitName " & _
                    " Select Distinct VF.QualityID, VF.QualityName " & _
                    " From PP_ProcessRawMaster PRM(Nolock) " & _
                    " JOIN PP_ProcessRawTran PRT(Nolock) ON PRT.PRMid = PRM.PRMid " & _
                    " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = PRT.Finishedid " & _
                    " Where PRM.Companyid = " & ddCompName.SelectedValue & " And PRM.BranchID = " & DDBranchName.SelectedValue & " " & _
                    " And PRT.Indentid = " & DDIndentNo.SelectedValue & " And PRM.PRMid = " & DDIssueNo.SelectedValue & " " & _
                    " And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.Item_ID = " & dditemname.SelectedValue & " " & _
                    " Order By VF.QualityName "
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

            NewComboFillWithDs(ddlunit, ds, 0)
            If ddCompName.Items.Count > 0 Then
                ddlunit.SelectedIndex = 0
            End If
            NewComboFillWithDs(dquality, ds, 1)
        End If
    End Sub

    Private Sub dquality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dquality.SelectedIndexChanged
        FillQualityChange()
    End Sub

    Private Sub FillQualityChange()
        If ddCompName.SelectedIndex <> -1 And DDBranchName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And DDIndentNo.SelectedIndex <> -1 And DDIssueNo.SelectedIndex <> -1 And ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Str As String = "Select Distinct VF.ShadeColorID, VF.ShadeColorName " & _
                                " From PP_ProcessRawMaster PRM(Nolock) " & _
                                " JOIN PP_ProcessRawTran PRT(Nolock) ON PRT.PRMid = PRM.PRMid " & _
                                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = PRT.Finishedid " & _
                                " Where PRM.Companyid = " & ddCompName.SelectedValue & " And PRM.BranchID = " & DDBranchName.SelectedValue & " " & _
                                " And PRT.Indentid = " & DDIndentNo.SelectedValue & "  And PRM.PRMid = " & DDIssueNo.SelectedValue & " " & _
                                " And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
                                " Order By VF.ShadeColorName "
            NewComboFill(ddlshade, Str)
        End If
    End Sub

    Private Sub ddgodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddgodown.SelectedIndexChanged
        If ddgodown.SelectedIndex <> -1 And ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillBinNO()
        End If
    End Sub

    Protected Sub FillBinNO()
        If VarCHECKBINCONDITION = 1 Then
            FindFinishedID()
            Module1.FillBinNO(DDBinNo, ddgodown.SelectedValue, TxtFinishedID.Text, New_Edit:=0)
        Else
            NewComboFill(DDBinNo, "Select BinId, BInNo From BinMaster(Nolock) Where GODOWNID = " & ddgodown.SelectedValue & "")
        End If
    End Sub

    Protected Sub FindFinishedID()
        Dim VarQuality As Integer, VarDesign As Integer, VarColor As Integer, VarShape As Integer, VarSize As Integer, VarShadeColor As Integer
        Dim VarQualityFlag As Integer = 0, VarDesignFlag As Integer = 0, VarColorFlag As Integer = 0, VarShapeFlag As Integer = 0, VarSizeFlag As Integer = 0, VarShadeColorFlag As Integer = 0

        TxtFinishedID.Text = 0

        If (dquality.Visible = True) Then
            If (dquality.SelectedIndex <> -1) Then
                VarQuality = dquality.SelectedValue
                VarQualityFlag = 1
            End If
        Else
            VarQualityFlag = 1
        End If
        If (DDDesign.Visible = True) Then
            If (DDDesign.SelectedIndex <> -1) Then
                VarDesign = DDDesign.SelectedValue
                VarDesignFlag = 1
            End If
        Else
            VarDesignFlag = 1
        End If
        If (DDColor.Visible = True) Then
            If (DDColor.SelectedIndex <> -1) Then
                VarColor = DDColor.SelectedValue
                VarColorFlag = 1
            End If
        Else
            VarColorFlag = 1
        End If
        If (DDShape.Visible = True) Then
            If (DDShape.SelectedIndex <> -1) Then
                VarShape = DDShape.SelectedValue
                VarShapeFlag = 1
            End If
        Else
            VarShapeFlag = 1
        End If
        If (DDSize.Visible = True) Then
            If (DDSize.SelectedIndex <> -1) Then
                VarSize = DDSize.SelectedValue
                VarSizeFlag = 1
            End If
        Else
            VarSizeFlag = 1
        End If
        If (ddlshade.Visible = True) Then
            If (ddlshade.SelectedIndex <> -1) Then
                VarShadeColor = ddlshade.SelectedValue
                VarShadeColorFlag = 1
            End If
        Else
            VarShadeColorFlag = 1
        End If
        If (VarQualityFlag = 1 And VarDesignFlag = 1 And VarColorFlag = 1 And VarShapeFlag = 1 And VarSizeFlag = 1 And VarShadeColorFlag = 1) Then
            TxtFinishedID.Text = getItemFinishedId(dditemname.SelectedValue, VarQuality, VarDesign, VarColor, VarShape, VarSize, TxtProdCode.Text, VarShadeColor, 0, "", VarMasterCompanyID)
        End If
    End Sub

    Private Sub txtissqty_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtissqty.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsave.Focus()
        End If
    End Sub

    Private Sub txtissqty_LostFocus(sender As Object, e As System.EventArgs) Handles txtissqty.LostFocus

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

                txtissqty.Text = w_Weight.ToString()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()
    Private Sub txtissqty_GotFocus(sender As Object, e As System.EventArgs) Handles txtissqty.GotFocus
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
        If Validcombobox(ddCompName) = False Then Exit Sub
        If Validcombobox(DDBranchName) = False Then Exit Sub
        If Validcombobox(ddempname) = False Then Exit Sub
        If Validcombobox(DDIndentNo) = False Then Exit Sub
        If Validcombobox(DDIssueNo) = False Then Exit Sub
        If Validcombobox(ddCatagory) = False Then Exit Sub
        If Validcombobox(dditemname) = False Then Exit Sub
        If (dquality.Visible = True) Then
            If Validcombobox(dquality) = False Then Exit Sub
        End If
        If (DDDesign.Visible = True) Then
            If Validcombobox(DDDesign) = False Then Exit Sub
        End If
        If (DDColor.Visible = True) Then
            If Validcombobox(DDColor) = False Then Exit Sub
        End If
        If (DDShape.Visible = True) Then
            If Validcombobox(DDShape) = False Then Exit Sub
        End If
        If (DDSize.Visible = True) Then
            If Validcombobox(DDSize) = False Then Exit Sub
        End If
        If (ddlshade.Visible = True) Then
            If Validcombobox(ddlshade) = False Then Exit Sub
        End If
        If Validcombobox(ddlunit) = False Then Exit Sub
        If Validcombobox(ddgodown) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        If Validtxtbox(txtissqty) = False Then Exit Sub
        If TxtMoisture.Visible = True Then
            If Validtxtbox(TxtMoisture) = False Then Exit Sub
        End If

        save_detail()
    End Sub
    
    Protected Sub save_detail()
        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If
        Dim tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim arr(28) As SqlParameter
            arr(0) = New SqlParameter("@InwardID", SqlDbType.Int)
            arr(1) = New SqlParameter("@CompanyID", SqlDbType.Int)
            arr(2) = New SqlParameter("@BranchID", SqlDbType.Int)
            arr(3) = New SqlParameter("@PartyID", SqlDbType.Int)
            arr(4) = New SqlParameter("@IndentID", SqlDbType.Int)
            arr(5) = New SqlParameter("@PrmID", SqlDbType.Int)
            arr(6) = New SqlParameter("@InwardNo", SqlDbType.NVarChar, 150)
            arr(7) = New SqlParameter("@InwardDate", SqlDbType.DateTime)
            arr(8) = New SqlParameter("@UserID", SqlDbType.Int)
            arr(9) = New SqlParameter("@MasterCompanyID", SqlDbType.Int)
            arr(10) = New SqlParameter("@InwardDetailID", SqlDbType.Int)
            arr(11) = New SqlParameter("@FinishedID", SqlDbType.Int)
            arr(12) = New SqlParameter("@UnitID", SqlDbType.Int)
            arr(13) = New SqlParameter("@GodownID", SqlDbType.Int)
            arr(14) = New SqlParameter("@BinNo", SqlDbType.VarChar, 50)
            arr(15) = New SqlParameter("@LotNo", SqlDbType.NVarChar, 100)
            arr(16) = New SqlParameter("@TagNo", SqlDbType.NVarChar, 100)
            arr(17) = New SqlParameter("@ConeTypeID", SqlDbType.Int)
            arr(18) = New SqlParameter("@NoofCone", SqlDbType.Int)
            arr(19) = New SqlParameter("@Qty", SqlDbType.Float)
            arr(20) = New SqlParameter("@BellWeight", SqlDbType.Float)
            arr(21) = New SqlParameter("@Moisture", SqlDbType.Float)
            arr(22) = New SqlParameter("@Msg", SqlDbType.VarChar, 100)

            arr(0).Direction = ParameterDirection.InputOutput
            arr(0).Value = InwardID
            arr(1).Value = ddCompName.SelectedValue
            arr(2).Value = DDBranchName.SelectedValue
            arr(3).Value = ddempname.SelectedValue
            arr(4).Value = DDIndentNo.SelectedValue
            arr(5).Value = DDIssueNo.SelectedValue
            arr(6).Direction = ParameterDirection.InputOutput
            arr(6).Value = txtchalanno.Text
            arr(7).Value = txtdate.Text
            arr(8).Value = varuserid
            arr(9).Value = VarMasterCompanyID
            arr(10).Direction = ParameterDirection.InputOutput
            arr(10).Value = InwardDetailID
            arr(11).Value = TxtFinishedID.Text
            arr(12).Value = ddlunit.SelectedValue
            arr(13).Value = ddgodown.SelectedValue
            arr(14).Value = IIf(DDBinNo.Visible = True, DDBinNo.Text, "")
            arr(15).Value = IIf(TxtLotNo.Text = "", "Without Lot No", TxtLotNo.Text)
            arr(16).Value = IIf(TxtTagNo.Text = "", "Without Tag No", TxtTagNo.Text)
            arr(17).Value = DDConeType.SelectedValue
            arr(18).Value = IIf(TxtNoofCone.Text = "", "0", TxtNoofCone.Text)
            arr(19).Value = txtissqty.Text
            arr(20).Value = IIf(TxtBellWt.Text = "", 0, TxtBellWt.Text)
            arr(21).Value = IIf(TxtMoisture.Visible = True, TxtMoisture.Text, "0")
            arr(22).Direction = ParameterDirection.InputOutput

            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[Pro_SaveInwardDetail]", arr)
            txtchalanno.Text = arr(6).Value.ToString()
            InwardID = arr(0).Value.ToString()
            InwardDetailID = arr(10).Value.ToString()

            If arr(22).Value.ToString() <> "" Then
                MsgBox(arr(22).Value.ToString())
            End If

            InwardDetailID = 0
            tran.Commit()
            pnl1.Enabled = False
            btnsave.Text = "Save"
            Fill_Grid()
            dditemname.SelectedIndex = -1
            dquality.SelectedIndex = -1
            ddlshade.SelectedIndex = -1
            ddgodown.SelectedIndex = -1
            DDBinNo.SelectedIndex = -1
            DDConeType.SelectedIndex = -1
            TxtLotNo.Text = ""
            TxtTagNo.Text = ""
            TxtNoofCone.Text = ""
            txtissqty.Text = ""
            TxtBellWt.Text = ""
            TxtMoisture.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
            tran.Rollback()
        End Try
    End Sub

    Private Sub refresh_form()
        InwardID = 0
        InwardDetailID = 0
        pnl1.Enabled = True
        ddempname.SelectedIndex = -1
        DDIndentNo.Items.Clear()
        DDIndentNo.Items.Clear()
        txtchalanno.Text = ""
        ddCatagory.Items.Clear()
        dditemname.Items.Clear()
        ddgodown.Items.Clear()
        DDConeType.Items.Clear()
        txtissqty.Text = ""
        TxtNoofCone.Text = ""
        dquality.Items.Clear()
        ddlshade.Items.Clear()
        txtdate.Text = DateTime.Now.ToString("dd-MMM-yyyy")
        TxtProdCode.Text = ""
        btnsave.Text = "Save"
        gvdetail.Rows.Clear()
    End Sub

    Protected Sub Fill_Grid()
        gvdetail.Rows.Clear()
        Dim i As Integer
        Dim strsql As String = "Select ID.InwardDetailID DGInwardDetailID, ID.FinishedID, IM.InwardID DGInwardID, VF.ITEM_NAME ItemName, " & _
            " Replace(VF.QualityName + ', ' + VF.ShadeColorName + ', ' + VF.DesignName + ', ' + VF.ColorName + ', ' + VF.ShapeName + ', ' + VF.SizeFt, ', , , , ', '') [Description], " & _
            " GM.GodownName, ID.LotNo, ID.TagNo, ID.BinNo, ID.Qty " & _
            " From InwardMaster IM(Nolock) " & _
            " JOIN InwardDetail ID(Nolock) ON ID.InwardID = IM.InwardID " & _
            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = ID.FinishedID " & _
            " JOIN GodownMaster GM(Nolock) ON GM.GoDownID = ID.GodownID " & _
            " Where IM.InwardID = " & InwardID & " And IM.MasterCompanyID = " & VarMasterCompanyID & ""

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                gvdetail.Rows.Add()
                gvdetail.Item("DGInwardDetailID", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("DGInwardDetailID")
                gvdetail.Item("FinishedID", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("FinishedID")
                gvdetail.Item("DGInwardID", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("DGInwardID")
                gvdetail.Item("ItemName", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ItemName")
                gvdetail.Item("Description", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
                gvdetail.Item("GodownName", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GodownName")
                gvdetail.Item("LotNo", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("LotNo")
                gvdetail.Item("TagNo", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
                gvdetail.Item("BinNo", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("BinNo")
                gvdetail.Item("Qty", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
            Next
        End If

    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        refresh_form()
    End Sub

    Private Sub btnpriview_Click(sender As System.Object, e As System.EventArgs) Handles btnpriview.Click
        Report()
    End Sub
    Private Sub Report()
        Dim qry As String = "Select BM.BranchName CompanyName, BM.BranchAddress CompanyAddress, BM.PhoneNo CompanyPhoneNo, BM.GSTNo, EI.EmpCode, EI.EmpName, " & _
                " IM.IndentNo, PRM.ChallanNo, a.InwardNo, a.InwardDate,  " & _
                " VF.ITEM_NAME, VF.QualityName, Replace(VF.ShadeColorName + ', ' + VF.DesignName + ', ' + VF.ColorName + ', ' + VF.ShapeName + ', ' + VF.SizeFt, ', , , , ', '') [Description],  " & _
                " U.UnitName, CM.ConeType, b.LotNo, b.TagNo, b.BinNo, b.NoofCone, b.Qty, b.BellWeight, b.Moisture " & _
                " From InwardMaster a(Nolock) " & _
                " JOIN CompanyInfo CI(Nolock) on CI.CompanyId = a.CompanyID  " & _
                " JOIN BRANCHMASTER BM(Nolock) on BM.ID = a.BranchID  " & _
                " JOIN Empinfo EI(Nolock) on EI.EmpID = a.PartyID  " & _
                " JOIN IndentMaster IM(Nolock) ON IM.IndentID = a.IndentID  " & _
                " JOIN PP_ProcessRawMaster PRM(Nolock) ON PRM.PRMid = a.PrmID  " & _
                " JOIN InwardDetail b(Nolock) on b.InwardID = a.InwardID  " & _
                " JOIN V_FinishedItemDetail VF ON VF.ITEM_FINISHED_ID = b.FinishedID  " & _
                " JOIN Unit U ON U.UnitID = b.UnitID  " & _
                " JOIN GodownMaster GM ON GM.GoDownID = b.GodownID  " & _
                " JOIN ConeMaster CM ON CM.ID = b.ConeTypeID  " & _
                " Where a.InwardID = 2 Order By b.InwardDetailID "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, qry)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String

            sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptDyingHouseInward.rpt")

            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptDyingHouseInward.xsd")
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
            MsgBox("No Record Found!")
        End If
    End Sub

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub gvdetail_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvdetail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim arr(3) As SqlParameter
                arr(0) = New SqlParameter("@Prtid", SqlDbType.Int)
                arr(1) = New SqlParameter("@TableName", SqlDbType.NVarChar, 50)
                arr(2) = New SqlParameter("@Count", SqlDbType.Int)
                arr(3) = New SqlParameter("@FlagDeleteOrNot", SqlDbType.Int)
                arr(0).Value = gvdetail.Item("prtidgrid", gvdetail.CurrentRow.Index).Value
                arr(1).Value = "PP_ProcessRawTran"
                arr(2).Value = gvdetail.Rows.Count
                arr(3).Direction = ParameterDirection.Output
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "Pro_UpdateStockIssueDelete", arr)
                tran.Commit()
                ' ddgodown.SelectedIndex = -1
                If gvdetail.Rows.Count = 1 Then
                   
                    txtchalanno.Text = ""
                End If
                If Convert.ToInt32(arr(3).Value) = 1 Then
                    MsgBox("AllReady Received Data....")
                Else
                    Fill_Grid()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                tran.Rollback()
            End Try
        End If
    End Sub

    Private Sub FrmDyingHouseInward_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub gvdetail_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvdetail.CellContentClick

    End Sub
End Class