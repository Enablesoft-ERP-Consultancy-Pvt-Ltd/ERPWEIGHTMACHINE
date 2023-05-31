Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class frmyarnopeningissue
    Dim id As Integer = 0
    Dim varfinishedid As Integer = 0
    Private Sub frmyarnopeningissue_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select CompanyId,CompanyName from companyinfo Where mastercompanyId=" & VarMasterCompanyID & " order by Companyname " & _
                           "select Distinct EI.EmpId,EI.EmpName+case when isnull(EI.empcode,'')<>'' Then ' ['+EI.empcode+']' Else '' End Empname from empinfo EI inner join Department D  on EI.departmentId=D.DepartmentId Where EI.Blacklist = 0 And D.DepartmentName='Yarn Opening'  order by EmpName " & _
                           "select Distinct ICM.CATEGORY_ID,ICM.CATEGORY_NAME from ITEM_CATEGORY_MASTER ICM inner Join CategorySeparate CS on ICM.CATEGORY_ID=CS.Categoryid and cs.id=1 order by ICM.CATEGORY_NAME " & _
                           "Select ConeType, ConeType From ConeMaster Order By SrNo"

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(DDcompany, ds, 0)
        If DDcompany.Items.Count > 0 Then
            DDcompany.SelectedValue = VarCompanyID
            DDcompany.Enabled = False
        End If

        NewComboFillWithDs(DDvendor, ds, 1)
        NewComboFillWithDs(ddCatagory, ds, 2)
        NewComboFillWithDs(DDconetype, ds, 3)

        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDbinno.Visible = True
        End If

    End Sub

    Private Sub ddCatagory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddCatagory.SelectedIndexChanged
        If ddCatagory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Item_Id,ITEM_NAME from Item_master Where CATEGORY_ID=" & ddCatagory.SelectedValue & " order by ITEM_NAME"
            If (VarMasterCompanyID = 16) Then
                str = "Select Distinct VF.Item_ID, VF.Item_NAME " & _
                "From ORDER_CONSUMPTION_DETAIL OCD(Nolock) " & _
                "JOIN OrderDetail OD(Nolock) ON OD.OrderID = OCD.OrderID And OD.OrderDetailId = OCD.ORDERDETAILID  " & _
                "JOIN Jobassigns J(Nolock) ON J.OrderId = OD.ORDERID And J.ITEM_FINISHED_ID = OD.Item_Finished_Id " & _
                "JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = OCD.IFINISHEDID  " & _
                "JOIN PROCESS_NAME_MASTER PNM(Nolock) ON PNM.PROCESS_NAME_ID = OCD.PROCESSID  " & _
                "Where OCD.OrderID = " & DDorderno.SelectedValue & " " & _
                "And OCD.ProcessID in (143, 5) And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " Order By VF.ITEM_NAME"
            End If
            NewComboFill(dditemname, str)
        End If
    End Sub

    Private Sub dditemname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dditemname.SelectedIndexChanged
        If ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct QualityId,QualityName from Quality Where Item_Id=" & dditemname.SelectedValue & " order by QualityName"
            If (VarMasterCompanyID = 16) Then
                str = "Select Distinct VF.QualityId, VF.QualityName " & _
                "From ORDER_CONSUMPTION_DETAIL OCD(Nolock) " & _
                "JOIN OrderDetail OD(Nolock) ON OD.OrderID = OCD.OrderID And OD.OrderDetailId = OCD.ORDERDETAILID " & _
                "JOIN Jobassigns J(Nolock) ON J.OrderId = OD.ORDERID And J.ITEM_FINISHED_ID = OD.Item_Finished_Id " & _
                "JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = OCD.IFINISHEDID " & _
                "JOIN PROCESS_NAME_MASTER PNM(Nolock) ON PNM.PROCESS_NAME_ID = OCD.PROCESSID " & _
                "Where OCD.OrderID = " & DDorderno.SelectedValue & " " & _
                "And OCD.ProcessID in (143, 5) And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ITEM_ID = " & dditemname.SelectedValue & "  Order By VF.QualityName"
            End If

            NewComboFill(dquality, str)
        End If
    End Sub

    Private Sub dquality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dquality.SelectedIndexChanged
        If ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select shadecolorid,shadecolorname from shadecolor   order by shadecolorname "
            If (VarMasterCompanyID = 16) Then
                str = "Select Distinct VF.ShadecolorId, VF.ShadeColorName " & _
                "From ORDER_CONSUMPTION_DETAIL OCD(Nolock) " & _
                "JOIN OrderDetail OD(Nolock) ON OD.OrderID = OCD.OrderID And OD.OrderDetailId = OCD.ORDERDETAILID " & _
                "JOIN Jobassigns J(Nolock) ON J.OrderId = OD.ORDERID And J.ITEM_FINISHED_ID = OD.Item_Finished_Id " & _
                "JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = OCD.OFINISHEDID " & _
                "JOIN PROCESS_NAME_MASTER PNM(Nolock) ON PNM.PROCESS_NAME_ID = OCD.PROCESSID " & _
                "Where OCD.OrderID = " & DDorderno.SelectedValue & " " & _
                "And OCD.ProcessID in (143, 5) And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ITEM_ID = " & dditemname.SelectedValue & " " & _
                "And VF.QualityId = " & dquality.SelectedValue & " Order By VF.ShadeColorName "
            End If

            str = str & " Select Distinct U.UnitId,U.UnitName from ITEM_MASTER IM inner Join Unit U on IM.UnitTypeID=U.UnitTypeID Where Im.Item_id=" & dditemname.SelectedValue & " order by U.UnitName " & _
                                "select GoDownID,GodownName from GodownMaster  order by GodownName"
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            NewComboFillWithDs(ddlshade, ds, 0)
            NewComboFillWithDs(ddlunit, ds, 1)
            If ddlunit.Items.Count > 0 Then ddlunit.SelectedIndex = 0
            NewComboFillWithDs(DDGodown, ds, 2)
        End If

    End Sub

    Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGodown.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            varfinishedid = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
        End If
        Filllotno()
    End Sub
    Protected Sub Filllotno()
        If DDcompany.SelectedIndex <> -1 And DDGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct Lotno,Lotno from Stock Where Item_Finished_id=" & varfinishedid & " and Godownid=" & DDGodown.SelectedValue & " and CompanyId=" & DDcompany.SelectedValue & " and Round(Qtyinhand,3)>0"
            NewComboFill(DDLotNo, str)
        End If

    End Sub

    Private Sub DDLotNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDLotNo.SelectedIndexChanged
        If DDLotNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillTagno()
        End If
    End Sub
    Protected Sub FillTagno()
        If DDcompany.SelectedIndex <> -1 And DDGodown.SelectedIndex <> -1 And DDLotNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            Dim str As String = "select Distinct TagNo,TagNo from Stock Where Item_Finished_id=" & varfinishedid & " and Godownid=" & DDGodown.SelectedValue & " and CompanyId=" & DDcompany.SelectedValue & " and Lotno='" & DDLotNo.Text & "' and Round(Qtyinhand,3)>0"
            NewComboFill(DDTagNo, str)
        End If

    End Sub

    Private Sub ddlshade_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddlshade.SelectedIndexChanged
        If DDGodown.Items.Count > 0 Then
            DDGodown.SelectedIndex = 0
            DDGodown_SelectedIndexChanged(sender, New EventArgs())
        End If
    End Sub

    Private Sub DDTagNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTagNo.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If DDbinno.Visible = True Then
                FillBinNo()
            Else
                varfinishedid = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
                txtstockqty.Text = getstockQty(DDcompany.SelectedValue, DDGodown.SelectedValue, DDLotNo.Text, varfinishedid)
            End If
        End If
    End Sub
    Protected Sub FillBinNo()
        If DDcompany.SelectedIndex <> -1 And DDGodown.SelectedIndex <> -1 And DDLotNo.SelectedIndex <> -1 And DDTagNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            Dim str As String = "select Distinct BinNo,BinNo as BinNo1 from Stock Where Item_Finished_id=" & varfinishedid & " and Godownid=" & DDGodown.SelectedValue & " and CompanyId=" & DDcompany.SelectedValue & " and Lotno='" & DDLotNo.Text & "' and TagNo='" & DDTagNo.Text & "' and Round(Qtyinhand,3)>0  order by BinNo"
            NewComboFill(DDbinno, str)
        End If

    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Validcombobox(DDcompany) = False Then Exit Sub
        If Validcombobox(DDvendor) = False Then Exit Sub
        If Validcombobox(ddCatagory) = False Then Exit Sub
        If Validcombobox(dditemname) = False Then Exit Sub
        If Validcombobox(dquality) = False Then Exit Sub
        If Validcombobox(ddlshade) = False Then Exit Sub
        If Validcombobox(ddlunit) = False Then Exit Sub
        If Validcombobox(DDGodown) = False Then Exit Sub
        If Validcombobox(DDLotNo) = False Then Exit Sub
        If Validcombobox(DDTagNo) = False Then Exit Sub
        If DDbinno.Visible = True Then
            If Validcombobox(DDbinno) = False Then Exit Sub
        End If

        If Validtxtbox(txtissqty) = False Then Exit Sub


        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try

            Dim varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID, Tran)

            Dim param(33) As SqlParameter
            param(0) = New SqlParameter("@ID", SqlDbType.Int)
            param(0).Direction = ParameterDirection.InputOutput
            param(0).Value = Val(id)
            param(1) = New SqlParameter("Detailid", SqlDbType.BigInt)
            param(1).Value = 0
            param(2) = New SqlParameter("@CompanyId", DDcompany.SelectedValue)
            param(3) = New SqlParameter("@vendorid", DDvendor.SelectedValue)
            param(4) = New SqlParameter("IssueNo", SqlDbType.VarChar, 100)
            param(4).Direction = ParameterDirection.InputOutput
            param(4).Value = txtissueno.Text
            param(5) = New SqlParameter("@IssueDate", txtissuedate.Text)
            param(6) = New SqlParameter("@TargetDate", txttargetdate.Text)
            param(7) = New SqlParameter("@Item_Finished_id", varfinishedid)
            param(8) = New SqlParameter("@GodownId", DDGodown.SelectedValue)
            param(9) = New SqlParameter("@LotNo", DDLotNo.Text)
            param(10) = New SqlParameter("@TagNo", DDTagNo.Text)
            param(11) = New SqlParameter("@IssueQty", txtissqty.Text)
            param(12) = New SqlParameter("@Rectype", DDrectype.Text)
            param(13) = New SqlParameter("@Noofcone", If(txtnoofcone.Text = "", "0", txtnoofcone.Text))
            param(14) = New SqlParameter("@ConeType", DDconetype.Text)
            param(15) = New SqlParameter("@Userid", varuserid)
            param(16) = New SqlParameter("@Unitid", ddlunit.SelectedValue)
            param(17) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            param(17).Direction = ParameterDirection.Output
            param(18) = New SqlParameter("@flagSize", 0)
            param(19) = New SqlParameter("@Rate", Val(txtrate.Text))
            param(20) = New SqlParameter("@BinNo", IIf(DDbinno.Visible = False, "", DDbinno.Text))
            param(21) = New SqlParameter("@Orderid", IIf(DDorderno.SelectedIndex <> -1, DDorderno.SelectedValue, "0"))

            param(22) = New SqlParameter("@DEPARTMENTID", 0)
            param(23) = New SqlParameter("@DEPARTMENTNAME", "")
            param(24) = New SqlParameter("@Remarks", If(TxtRemarks.Text = "", "", TxtRemarks.Text))
            param(25) = New SqlParameter("@BellWt", If(TxtBellWt.Text = "", "0", TxtBellWt.Text))

            param(26) = New SqlParameter("@PlyType", DDPlyType.Text)
            param(27) = New SqlParameter("@TransportType", DDTransportType.Text)
            param(28) = New SqlParameter("@Moisture", IIf(TxtMoisture.Visible = False, 0, If(TxtMoisture.Text = "", "0", TxtMoisture.Text)))

            param(29) = New SqlParameter("@VehicleNo", TxtVehicleNo.Text)
            param(30) = New SqlParameter("@DriverName", TxtDriverName.Text)
            param(31) = New SqlParameter("@EWayBillNo", TxtEWayBillNo.Text)
            param(32) = New SqlParameter("@GstType", IIf(ChkForGSTStateOutSide.Checked = True, 1, 0))

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "[Pro_SaveYarnOpeningIssue]", param)
            id = param(0).Value.ToString()
            txtissueno.Text = param(4).Value.ToString()
            Tran.Commit()
            If param(17).Value.ToString = "" Then
                MsgBox("Data saved successfully..")
                FillGrid()
                txtissqty.Text = ""
                txtnoofcone.Text = ""
                TxtBellWt.Text = ""
                txtissqty.Focus()
                If DDbinno.Visible = True Then
                    DDbinno_SelectedIndexChanged(sender, New EventArgs())
                Else
                    If DDTagNo.SelectedIndex <> -1 Then
                        DDTagNo_SelectedIndexChanged(sender, New EventArgs())
                    End If
                End If
            Else
                MsgBox(param(17).Value.ToString())
            End If
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub FillGrid()
        DG.Rows.Clear()
        Dim i As Integer
        Dim str As String = "select dbo.F_getItemDescription(Yt.Item_Finished_id,YT.flagsize) as ItemDescription,GM.GodownName,YT.Lotno " & _
                      ",Yt.Tagno,U.UnitName,YT.issueQty, YT.Rectype, YT.Noofcone, YT.Conetype, YM.ID, YT.Detailid, YM.issueNo " & _
                    "from YarnOpeningIssueMaster YM inner join YarnOpeningIssueTran YT on YM.ID=YT.MasterId  " & _
                    "inner join GodownMaster GM on YT.GodownId=GM.GoDownId " & _
                    "inner join Unit U on Yt.Unitid=U.UnitId " & _
                    "Where YM.Id=" & id
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            DG.Rows.Add()
            DG.Item("ItemDescription", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Itemdescription")
            DG.Item("Godown", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Godownname")
            DG.Item("Lotno", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
            DG.Item("TagNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
            DG.Item("Unit", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitname")
            DG.Item("issueqty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("issueqty")
            DG.Item("Rectype", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rectype")
            DG.Item("conetype", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("conetype")
            DG.Item("dgid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("id")
            DG.Item("Dgdetailid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Detailid")
        Next
    End Sub

    Private Sub DDvendor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDvendor.SelectedIndexChanged
        id = 0
        txtissueno.Text = ""
        If DDvendor.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDcustcode, "select customerid,case when customercode='' Then CompanyName else CustomerCode End as Customercode From customerinfo order by CustomerCode")
        End If
    End Sub
    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = "select  * from [V_yarnOpeningIssue] Where id=" & id & " " & _
            " Select ID, ITEMDESCRIPTION, HSNCode , UnitName, Sum(IssueQty) IssueQty, Sum(PurchaseAmt) PurchaseAmt, Sum(GSTType) GSTType, Sum(CGSTAmt) CGSTAmt, Sum(SGSTAmt) SGSTAmt, Sum(IGSTAmt) IGSTAmt " & _
            " From V_YARNOPENINGISSUE " & _
            " Where ID = " & id & " " & _
            " Group By ID, ITEMDESCRIPTION, HSNCode, UnitName "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptyarnopeningissue.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\rptyarnopeningissue.xsd")
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
            MsgBox("No records found...")
        End If

    End Sub

    Private Sub DG_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DG.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub

            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim masterid As String = DG.Item("dgid", DG.CurrentRow.Index).Value
                Dim Detailid As String = DG.Item("dgDetailid", DG.CurrentRow.Index).Value
                Dim param(6) As SqlParameter
                param(0) = New SqlParameter("@Id", masterid)
                param(1) = New SqlParameter("@Detailid", Detailid)
                param(2) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(2).Direction = ParameterDirection.Output
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_DeleteYarnOpeningIssue", param)
                Tran.Commit()
                MsgBox(param(2).Value.ToString())
                FillGrid()
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try

        End If
    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        DDvendor.SelectedIndex = -1
        txtrate.Text = ""
        txtissueno.Text = ""
        id = 0
        varfinishedid = 0
        txtissqty.Text = ""
        DG.Rows.Clear()
        txtissuedate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy")
        txttargetdate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy")

    End Sub
    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
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

                ''w_Weight = Convert.ToDouble(sSplitData(0).ToString().Replace(" S", ""))
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

    Private Sub txtWeaverIdNoscan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtWeaverIdNoscan.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim str As String = "select Empid From EmpInfo EI inner join Department Dp on EI.Departmentid=DP.departmentid " & _
                       "and Dp.Departmentname='Yarn Opening' Where EmpCode='" & txtWeaverIdNoscan.Text & "'"

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                DDvendor.SelectedValue = ds.Tables(0).Rows(0)("empid").ToString()
                DDvendor_SelectedIndexChanged(sender, New EventArgs())
                txtWeaverIdNoscan.Text = ""
                ddCatagory.Focus()
            Else
                MsgBox("Employee Code does not exists in this Department.")
                txtWeaverIdNoscan.Focus()
            End If
        End If
    End Sub

    Private Sub DDbinno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDbinno.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            varfinishedid = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            txtstockqty.Text = getstockQty(DDcompany.SelectedValue, DDGodown.SelectedValue, DDLotNo.Text, varfinishedid, TagNo:=DDTagNo.Text, BinNo:=DDbinno.Text)
        End If
    End Sub

    Private Sub frmyarnopeningissue_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub DDcustcode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDcustcode.SelectedIndexChanged
        If DDcompany.SelectedIndex <> -1 And DDcustcode.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDorderno, "select OM.OrderId,om.CustomerOrderNo From Ordermaster Om WHere CompanyId=" & DDcompany.SelectedValue & " and CustomerId=" & DDcustcode.SelectedValue & " and Status=0 order by CustomerorderNo")
        End If
    End Sub

    Private Sub DDorderno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDorderno.SelectedIndexChanged
        If (VarMasterCompanyID = 16 And DDorderno.SelectedIndex <> -1 And Varcombovalue <> 0) Then
            Dim str As String = "Select Distinct VF.CATEGORY_ID, VF.CATEGORY_NAME " & _
                "From ORDER_CONSUMPTION_DETAIL OCD(Nolock) " & _
                " JOIN OrderDetail OD(Nolock) ON OD.OrderID = OCD.OrderID And OD.OrderDetailId = OCD.ORDERDETAILID " & _
                " JOIN Jobassigns J(Nolock) ON J.OrderId = OD.ORDERID And J.ITEM_FINISHED_ID = OD.Item_Finished_Id " & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = OCD.IFINISHEDID " & _
                " JOIN PROCESS_NAME_MASTER PNM(Nolock) ON PNM.PROCESS_NAME_ID = OCD.PROCESSID " & _
                " Where OCD.OrderID = " & DDorderno.SelectedValue & " And OCD.ProcessID in (143, 5) Order By VF.CATEGORY_NAME "
            NewComboFill(ddCatagory, str)
        End If
    End Sub
End Class