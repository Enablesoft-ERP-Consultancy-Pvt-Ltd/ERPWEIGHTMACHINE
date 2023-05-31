Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class FrmNextProcessIssue
    Dim hnid As Integer = "0"

    Private Sub frmsampleyarndyeing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "Select Distinct CI.CompanyId,CI.CompanyName from Companyinfo CI,Company_Authentication CA Where CI.CompanyId=CA.CompanyId And CA.UserId=" & varuserid & "  And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By CompanyName " & _
                            " Select ID, BranchName From BRANCHMASTER BM(nolock) JOIN BranchUser BU(nolock) ON BU.BranchID = BM.ID And BU.UserID = " & varuserid & " Where BM.MasterCompanyID = " & VarMasterCompanyID & " " & _
                            " Select U.UnitsId,U.UnitName from Units U join Units_authentication UA on U.unitsId = UA.UnitsId and UA.Userid = " & varuserid & "  order by U.unitsId " & _
                            " Select PNM.PROCESS_NAME_ID, PNM.PROCESS_NAME " & _
                            " From PROCESS_NAME_MASTER PNM(Nolock)  " & _
                            " JOIN UserRightsProcess URP(Nolock) ON URP.ProcessId = PNM.PROCESS_NAME_ID And URP.Userid = " & varuserid & " " & _
                            " Where PNM.MasterCompanyID = " & VarMasterCompanyID & " Order By PNM.PROCESS_NAME  " & _
                            " Select PNM.PROCESS_NAME_ID, PNM.PROCESS_NAME " & _
                            " From PROCESS_NAME_MASTER PNM(Nolock)  " & _
                            " JOIN UserRightsProcess URP(Nolock) ON URP.ProcessId = PNM.PROCESS_NAME_ID And URP.Userid = " & varuserid & " " & _
                            " Where PNM.MasterCompanyID = " & VarMasterCompanyID & " And PNM.PROCESS_NAME_ID in (145, 162, 190) Order By PNM.PROCESS_NAME  " & _
                            " Select Distinct Top 1 ICM.CATEGORY_ID, ICM.CATEGORY_NAME " & _
                            " From ITEM_CATEGORY_MASTER ICM " & _
                            " join CategorySeparate cs on cs.Categoryid = ICM.CATEGORY_ID And cs.id = 0 " & _
                            " Where ICM.CATEGORY_ID = 1 And ICM.MasterCompanyid = " & VarMasterCompanyID & ""

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(DDCompanyName, ds, 0)
        If DDCompanyName.Items.Count > 0 Then
            DDCompanyName.SelectedIndex = 0
            DDCompanyName.Enabled = False
        End If

        NewComboFillWithDs(DDBranchName, ds, 1)
        If DDBranchName.Items.Count > 0 Then
            DDBranchName.SelectedIndex = 0
            DDBranchName.Enabled = False
        End If
        NewComboFillWithDs(DDUnits, ds, 2)
        If DDUnits.Items.Count > 0 Then DDUnits.SelectedIndex = 0

        NewComboFillWithDs(DDFromProcess, ds, 3)
        If DDFromProcess.Items.Count > 0 Then DDFromProcess.SelectedIndex = 0

        NewComboFillWithDs(DDProcessName, ds, 4)
        If DDProcessName.Items.Count > 0 Then DDProcessName.SelectedIndex = 0

        NewComboFillWithDs(DDCategory, ds, 5)
        DDPartyName.Focus()
    End Sub

    Private Sub DDProcessName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDProcessName.SelectedIndexChanged
        If DDProcessName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDPartyName, "Select EI.EmpId, EI.EmpName + Case When isnull(Ei.empcode, '') <> '' then ' [' + ei.empcode + ']' else '' end Empname " & _
            " From EmpInfo EI join EmpProcess EP on EI.EmpId=EP.EmpId and EP.ProcessId=" & DDProcessName.SelectedValue & " Where EI.Blacklist = 0 Order By EmpName")
        End If
    End Sub

    Private Sub DDPartyName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDPartyName.SelectedIndexChanged
        If DDPartyName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDcustcode, "Select customerid, Case When CustomerCode = '' Then CompanyName else CustomerCode End Customercode " & _
                         " From customerinfo(Nolock) order by CustomerCode")
        End If
    End Sub

    Private Sub DDcustcode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDcustcode.SelectedIndexChanged
        If DDcustcode.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDorderno, " Select Distinct OM.OrderId, OM.CustomerOrderNo From CarpetNumber CN(Nolock) " & _
                    " JOIN OrderMaster OM(Nolock) ON OM.OrderId = CN.OrderId And CustomerId = " & DDcustcode.SelectedValue & " And OM.Status = 0 " & _
                    " Where CN.Pack = 0 And CN.IssRecStatus = 0 And CN.CompanyId = " & DDCompanyName.SelectedValue & " And CurrentProStatus = " & DDFromProcess.SelectedValue & " order by CustomerorderNo")
        End If
    End Sub

    Private Sub DDCategory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDCategory.SelectedIndexChanged
        If DDCategory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim stritem As String = "select distinct IM.Item_Id,IM.Item_Name " & _
                " from Item_Parameter_Master IPM " & _
                " Join Item_Master IM on IM.Item_Id=IPM.Item_Id  " & _
                " join Item_Category_Master ICM on ICM.Category_Id=IM.Category_Id  " & _
                " Where IM.Category_Id=" & DDCategory.SelectedValue & " And IM.MasterCompanyId=" & VarMasterCompanyID
            If (DDProcessName.SelectedValue <> 190) Then
                stritem = stritem + " & And IPM.Item_Id = 327 "
            End If

            stritem = stritem + " order by IM.item_name" & _
                " SELECT PARAMETER_ID FROM ITEM_CATEGORY_PARAMETERS where CATEGORY_ID=" & DDCategory.SelectedValue

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, stritem)
            Dim i As Integer
            NewComboFillWithDs(DDItem, ds, 0)
            If (ds.Tables(1).Rows.Count > 0) Then
                LblQuality.Visible = False
                DDQuality.Visible = False
                LblDesign.Visible = False
                DDDesign.Visible = False
                LblColor.Visible = False
                DDColor.Visible = False
                LblShape.Visible = False
                DDShape.Visible = False
                LblSize.Visible = False
                DDSize.Visible = False
                LblShadeColor.Visible = False
                DDShadeColor.Visible = False
                For i = 0 To ds.Tables(1).Rows.Count - 1
                    Select Case ds.Tables(1).Rows(i)("PARAMETER_ID")
                        Case 1
                            LblQuality.Visible = True
                            DDQuality.Visible = True
                        Case 2
                            LblDesign.Visible = True
                            DDDesign.Visible = True
                        Case 3
                            LblColor.Visible = True
                            DDColor.Visible = True
                        Case 4
                            LblShape.Visible = True
                            DDShape.Visible = True
                        Case 5
                            LblSize.Visible = True
                            DDSize.Visible = True
                        Case 6
                            LblShadeColor.Visible = True
                            DDShadeColor.Visible = True
                    End Select
                Next
            End If
        End If
    End Sub

    Private Sub DDItem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDItem.SelectedIndexChanged
        If DDItem.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct U.UnitId,u.UnitName from Item_master IM inner join UNIT_TYPE_MASTER UT on IM.UnitTypeID=UT.UnitTypeID inner join Unit u on U.UnitTypeID=UT.UnitTypeID and Im.ITEM_ID=" & DDItem.SelectedValue & "" & _
                " Select Distinct VF.QualityId, VF.QualityName " & _
                " From CarpetNumber CN(Nolock)" & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = CN.Item_Finished_Id " & _
                " And VF.CATEGORY_ID = " & DDCategory.SelectedValue & " And VF.ITEM_ID = " & DDItem.SelectedValue & "" & _
                " JOIN OrderMaster OM(Nolock) ON OM.OrderId = CN.OrderId And OM.Status = 0 "
            If (DDcustcode.SelectedIndex > 0) Then
                str = str & " And OM.CustomerId = " & DDcustcode.SelectedValue & ""
            End If
            str = str & " Where CN.Pack = 0 And CN.IssRecStatus = 0 And CN.CurrentProStatus = " & DDFromProcess.SelectedValue & ""
            If (DDorderno.SelectedIndex <> -1) Then
                str = str & " And OM.OrderId = " & DDorderno.SelectedValue & ""
            End If

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

            NewComboFillWithDs(DDUnit, ds, 0)
            NewComboFillWithDs(DDQuality, ds, 1)

            If DDUnit.Items.Count > 0 Then DDUnit.SelectedIndex = 1
        End If

    End Sub

    Private Sub DDQuality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDQuality.SelectedIndexChanged
        If DDQuality.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct VF.DesignID, VF.DesignName From V_FinishedItemDetail VF(Nolock) Where VF.ITEM_ID = " & DDItem.SelectedValue & " And QualityID = " & DDQuality.SelectedValue & " " & _
                " Select Distinct VF.ColorId, VF.ColorName " & _
                " From OrderDetail OD(Nolock) " & _
                " Join V_FinishedItemDetail VF(Nolock) ON VF.Item_Finished_ID = OD.Item_Finished_ID Where VF.ITEM_ID = " & DDItem.SelectedValue & " And QualityID = " & DDQuality.SelectedValue & " " & _
                " Select Distinct VF.ShapeId, VF.ShapeName From V_FinishedItemDetail VF(Nolock) Where VF.ITEM_ID = " & DDItem.SelectedValue & " And QualityID = " & DDQuality.SelectedValue & " " & _
                " Select Distinct VF.ShadecolorId, VF.ShadeColorName From V_FinishedItemDetail VF(Nolock) Where VF.ITEM_ID = " & DDItem.SelectedValue & " And QualityID = " & DDQuality.SelectedValue & ""

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If (DDDesign.Visible = True) Then
                NewComboFillWithDs(DDDesign, ds, 0)
            End If
            If (DDColor.Visible = True) Then
                NewComboFillWithDs(DDColor, ds, 1)
            End If
            If (DDShape.Visible = True) Then
                NewComboFillWithDs(DDShape, ds, 2)
            End If
            If (DDShadeColor.Visible = True) Then
                NewComboFillWithDs(DDShadeColor, ds, 3)
            End If
        End If
    End Sub

    Private Sub DDShape_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDShape.SelectedIndexChanged
        If DDShape.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = " Select Distinct VF.SizeId, Case When " & DDUnit.SelectedValue & " = 1 Then VF.SizeMtr Else Case When " & DDUnit.SelectedValue & " = 6 Then VF.SizeInch Else VF.SizeFt End End Size " & _
                         " From V_FinishedItemDetail VF Where VF.ITEM_ID = " & DDItem.SelectedValue & " And QualityID = " & DDQuality.SelectedValue & " And ShapeId = " & DDShape.SelectedValue & ""
            If (DDDesign.Visible = True And DDDesign.SelectedIndex > 0) Then
                str = str & " And VF.DesignID = " & DDDesign.SelectedValue & ""
            End If
            If (DDColor.Visible = True And DDColor.SelectedIndex > 0) Then
                str = str & " And VF.ColorID = " & DDColor.SelectedValue & ""
            End If
            NewComboFill(DDSize, str)
        End If
    End Sub
    ''Dim Varfinishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, DDShadeColor.SelectedValue, 0, "", VarMasterCompanyID)

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Validcombobox(DDCompanyName) = False Then Exit Sub
        If Validcombobox(DDBranchName) = False Then Exit Sub
        If Validcombobox(DDUnits) = False Then Exit Sub
        If Validcombobox(DDProcessName) = False Then Exit Sub
        If Validcombobox(DDPartyName) = False Then Exit Sub
        If Validcombobox(DDorderno) = False Then Exit Sub
        If Validcombobox(DDFromProcess) = False Then Exit Sub
        If Validcombobox(DDCategory) = False Then Exit Sub
        If Validcombobox(DDItem) = False Then Exit Sub
        If (DDQuality.Visible = True) Then
            If Validcombobox(DDQuality) = False Then Exit Sub
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
        If (DDShadeColor.Visible = True) Then
            If Validcombobox(DDShadeColor) = False Then Exit Sub
        End If
        If Validcombobox(DDUnit) = False Then Exit Sub
        If Validtxtbox(TxtIssueQty) = False Then Exit Sub
        If Validtxtbox(TxtWeight) = False Then Exit Sub

        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim arr As SqlParameter() = New SqlParameter(32) {}

            arr(0) = New SqlParameter("@IssueOrderID", SqlDbType.Int)
            arr(0).Direction = ParameterDirection.InputOutput
            arr(0).Value = hnid
            arr(1) = New SqlParameter("@CompanyID", DDCompanyName.SelectedValue)
            arr(2) = New SqlParameter("@BranchID", DDBranchName.SelectedValue)
            arr(3) = New SqlParameter("@Units", DDUnits.SelectedValue)
            arr(4) = New SqlParameter("@ProcessID", DDProcessName.SelectedValue)
            arr(5) = New SqlParameter("@EmpID", DDPartyName.SelectedValue)
            arr(6) = New SqlParameter("@FromProcess", DDFromProcess.SelectedValue)
            arr(7) = New SqlParameter("@IssueDate", TxtDate.Text)
            arr(8) = New SqlParameter("@ReqDate", TxtReqDate.Text)
            arr(9) = New SqlParameter("@OrderID", If(DDorderno.SelectedIndex <> -1, DDorderno.SelectedValue, "0"))

            Dim VarQualityID = 0, VarDesignID = 0, VarColorID = 0, VarShapeID = 0, VarSizeID = 0, VarShadeColorID = 0

            If (DDQuality.Visible = True) Then
                VarQualityID = DDQuality.SelectedValue
            End If

            If (DDDesign.Visible = True) Then
                VarDesignID = DDDesign.SelectedValue
            End If

            If (DDColor.Visible = True) Then
                VarColorID = DDColor.SelectedValue
            End If

            If (DDShape.Visible = True) Then
                VarShapeID = DDShape.SelectedValue
            End If

            If (DDSize.Visible = True) Then
                VarSizeID = DDSize.SelectedValue
            End If
            If (DDShadeColor.Visible = True) Then
                VarShadeColorID = DDShadeColor.SelectedValue
            End If

            Dim varfinishedid As Integer = getItemFinishedId(DDItem.SelectedValue, VarQualityID, VarDesignID, VarColorID, VarShapeID, VarSizeID, "", VarShadeColorID, 0, "", VarMasterCompanyID, Tran)

            arr(10) = New SqlParameter("@FinishedID", varfinishedid)
            arr(11) = New SqlParameter("@IssueNo", SqlDbType.VarChar, 50)
            arr(11).Direction = ParameterDirection.InputOutput
            arr(11).Value = TxtIssueNo.Text
            arr(12) = New SqlParameter("@UnitID", DDUnit.SelectedValue)
            arr(13) = New SqlParameter("@CALTYPE", 0)
            arr(14) = New SqlParameter("@IssueQty", TxtIssueQty.Text)
            arr(15) = New SqlParameter("@Weight", TxtWeight.Text)

            arr(16) = New SqlParameter("@UserID", varuserid)
            arr(17) = New SqlParameter("@MasterCompanyID", VarMasterCompanyID)
            arr(18) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            arr(18).Direction = ParameterDirection.Output
            arr(19) = New SqlParameter("@FromDate", DtpFromDate.Text)
            arr(20) = New SqlParameter("@ToDate", DtpToDate.Text)

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_SaveNextProcessIssueQtyWise", arr)
            hnid = arr(0).Value.ToString()
            TxtIssueNo.Text = arr(11).Value.ToString()
            MsgBox(arr(18).Value.ToString())
            Tran.Commit()
            Fillgrid()
            TxtIssueQty.Text = ""
            TxtWeight.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
            Tran.Rollback()
        End Try
    End Sub

    Protected Sub Fillgrid()
        DG.Rows.Clear()
        Dim str As String = "Select a.ISSUEORDERID, b.ISSUE_DETAIL_ID, VF.ITEM_NAME + ' ' + VF.QualityName + ' ' + VF.QualityName + ' ' + VF.DesignName + ' ' + VF.ColorName + ' ' + VF.ShapeName + ' ' + " & _
                " Case When a.UnitID = 1 Then VF.SizeMtr Else Case When a.UnitID = 6 Then VF.SizeInch Else VF.SizeFt End End [Description], b.AREA * b.Qty Area, b.JobIssueWeight [Weight], b.Qty, b.Rate, b.Amount " & _
                " From PROCESS_ISSUE_MASTER_" & DDProcessName.SelectedValue & " a(Nolock) " & _
                " JOIN PROCESS_ISSUE_DETAIL_" & DDProcessName.SelectedValue & " b(Nolock) ON b.ISSUEORDERID = a.ISSUEORDERID  " & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = b.ITEM_FINISHED_ID " & _
                " Where a.IssueOrderId = " & hnid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                DG.Rows.Add()
                DG.Item("SrNo", DG.Rows.Count - 1).Value = i + 1
                DG.Item("IssueOrderID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IssueOrderID")
                DG.Item("ISSUE_DETAIL_ID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ISSUE_DETAIL_ID")
                DG.Item("Description", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
                DG.Item("Area", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Area")
                DG.Item("Weight", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Weight")
                DG.Item("Rate", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rate")
                DG.Item("Qty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
                DG.Item("Amount", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Amount")
            Next
        End If
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        hnid = "0"
        DDPartyName.SelectedIndex = -1
        TxtIssueNo.Text = ""

        TxtDate.Text = System.DateTime.Now.ToShortDateString()
        TxtReqDate.Text = System.DateTime.Now.ToShortDateString()
        TxtWeight.Text = ""
        TxtIssueQty.Text = ""
    End Sub
    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click

        Dim str As String = "Select isnull(PIM.ChallanNo,'') as ChallanNo, Ci.CompanyId,BM.BranchName CompanyName, BM.BranchAddress CompAddr1, '' CompAddr2, '' CompAddr3,BM.PhoneNo CompTel,CI.CompFax,BM.GSTNo, " & _
                        " Case When EI.Empname is null Then (Select Distinct EII.EmpName + ', ' " & _
                                " From Employee_ProcessOrderNo EPO(Nolock)" & _
                                " JOIN Empinfo EII(Nolock) ON EII.EmpID = EPO.EmpID " & _
                                "        Where EPO.ProcessiD = " & DDProcessName.SelectedValue & " And EPO.IssueOrderId = " & hnid & " " & _
                                " For XML Path('')) Else EI.EmpName End EmpName, " & _
                        " EI.Address ,'' Address2,'' asAddress3,'' as Mobile,Ei.GSTNo Empgstin, PIM.issueorderid, " & _
                        " PIM.assigndate,(select PROCESS_NAME From PROCESS_NAME_MASTER Where PROCESS_NAME_ID=" & DDProcessName.SelectedValue & ") as Job," & _
                        " Vf.QualityName,Vf.designName,Vf.ColorName,Case When Vf.shapeid=1 Then '' Else Left(vf.shapename,1) End  as Shapename," & _
                        " PID.Width+' x ' +PID.Length as Size,PID.qty,PID.Qty*PID.area as Area,PIM.UnitId,PID.Rate,PID.Issue_Detail_Id," & _
                        " (Select * from [dbo].[Get_StockNoIssue_Detail_Wise](PID.Issue_Detail_Id," & DDProcessName.SelectedValue & ")) TStockNo,PIM.Instruction,PID.Item_Finished_Id," & _
                        " '' FolioNo, isnull(PID.JobIssueWeight,0) as JobIssueWeight, PID.Amount" & _
                        " From PROCESS_ISSUE_MASTER_" & DDProcessName.SelectedValue & " PIM(Nolock) " & _
                        " Join PROCESS_ISSUE_DETAIL_" & DDProcessName.SelectedValue & " PID(Nolock) on PIM.IssueOrderId=PID.IssueOrderId" & _
                        " JOIN BranchMaster BM(Nolock) ON BM.ID = PIM.BranchID " & _
                        " JOIN CompanyInfo CI(Nolock) on BM.Companyid=CI.CompanyId" & _
                        " JOIN V_FinishedItemDetail vf(Nolock) on PID.Item_finished_id=vf.ITEM_FINISHED_ID" & _
                        " LEFT JOIN Empinfo EI(Nolock) ON EI.EmpID = PIM.EmpID " & _
                        " Where PIM.issueorderid=" & hnid & " order by Issue_Detail_id"

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String

            sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptNextissueNewSummary.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptNextissueNew2.xsd")
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

                'w_Weight = Convert.ToDouble(sSplitData(0).ToString().Replace(" S", ""))
                If sSplitData(0).Contains("Kgs") = True Then
                    w_Weight = Convert.ToDouble(sSplitData(0).ToString().Replace(" S Kgs", ""))
                Else
                    w_Weight = Convert.ToDouble(sSplitData(0).ToString().Replace(" S", ""))
                End If

                TxtWeight.Text = w_Weight.ToString()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()
    Private Sub TxtWeight_GotFocus(sender As Object, e As System.EventArgs) Handles TxtWeight.GotFocus
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
    Private Sub txtWeight_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnsave.Focus()
        End If
    End Sub

    Private Sub DG_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DG.KeyDown
        If e.KeyCode = Keys.Delete Then
            'If MsgBox("Do you want to delete this row?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub
            'If Con.State = ConnectionState.Closed Then
            '    Con.Open()
            'End If
            'Dim Tran As SqlTransaction = Con.BeginTransaction()
            'Try
            '    'Dim lblDetailid As String = DG.Item("Detailid", DG.CurrentRow.Index).Value
            '    'Dim lblid As String = DG.Item("ID", DG.CurrentRow.Index).Value
            '    'Dim arr(2) As SqlParameter
            '    'arr(0) = New SqlParameter("@Detailid", lblDetailid)
            '    'arr(1) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            '    'arr(1).Direction = ParameterDirection.Output
            '    'arr(2) = New SqlParameter("@ID", lblid)
            '    'SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_DELETEMOTTELINGISSUE", arr)
            '    'MsgBox(arr(1).Value.ToString())
            '    'Tran.Commit()
            '    'Fillgrid()
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            '    Tran.Rollback()
            'End Try
        End If
    End Sub

End Class
