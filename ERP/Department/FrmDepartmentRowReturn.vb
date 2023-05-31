Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class FrmDepartmentRowReturn
    Dim hnprmid As Integer = 0

    Private Sub FrmDepartmentRowIssue_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select Distinct CI.CompanyId,Companyname from Companyinfo CI " & _
                    " JOIN Company_Authentication CA ON CA.CompanyId=CI.CompanyId And CA.UserId=" & varuserid & "  " & _
                    " Where CI.MasterCompanyId=" & VarMasterCompanyID & " Order By Companyname " & _
                    " Select ID, BranchName  " & _
                    " From BRANCHMASTER BM(nolock) " & _
                    " JOIN BranchUser BU(nolock) ON BU.BranchID = BM.ID And BU.UserID = " & varuserid & "  " & _
                    " Where BM.CompanyID = 1 And BM.MasterCompanyID = " & VarMasterCompanyID & " " & _
                    " Select Distinct a.ProcessID, PNM.PROCESS_NAME " & _
                    " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
                    " JOIN PROCESS_NAME_MASTER PNM(Nolock) ON PNM.PROCESS_NAME_ID = a.ProcessID  " & _
                    " JOIN UserRightsProcess URP(Nolock) ON URP.ProcessId = a.ProcessID And URP.Userid = " & varuserid & "   " & _
                    " Where IsNull(a.IssuePRMID, 0) > 0 And a.TYPEFLAG = 1 And a.TranType = 1 And a.MasterCompanyID = " & VarMasterCompanyID & "  " & _
                    " Order By a.ProcessID  " & _
                    " Select ConeType, ConeType From ConeMaster Order By SrNo "
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(DDcompany, ds, 0)
        If DDcompany.Items.Count > 0 Then
            DDcompany.SelectedIndex = 0
            DDcompany.Enabled = False
        End If
        NewComboFillWithDs(DDBranchName, ds, 1)
        If DDBranchName.Items.Count > 0 Then
            DDBranchName.SelectedIndex = 0
            DDBranchName.Enabled = False
        End If

        NewComboFillWithDs(DDprocess, ds, 2)
        If DDprocess.Items.Count > 0 Then DDprocess.SelectedIndex = 0

        NewComboFillWithDs(DDConeType, ds, 3)

        ''***********
        If varTagNowise = "1" Then
            lbltagno.Visible = True
            DDTagNo.Visible = True
        End If
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If
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

    End Sub
    Private Sub DDprocess_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDprocess.SelectedIndexChanged
        If DDprocess.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            hnprmid = "0"
            NewComboFill(DDDepartment, " Select Distinct a.DepartmentId, D.DepartmentName " & _
            " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
            " JOIN Department D(Nolock) ON D.DepartmentId = a.DepartmentId  " & _
            " Where IsNull(a.IssuePRMID, 0) > 0 And a.TYPEFLAG = 1 And a.TranType = 1 And a.CompanyID = " & DDcompany.SelectedValue & "" & _
            " And BranchID = " & DDBranchName.SelectedValue & " And ProcessID = " & DDprocess.SelectedValue & " And a.MasterCompanyID = " & VarMasterCompanyID & " " & _
            " Order By D.DepartmentName ")
        End If
    End Sub
    Private Sub DDDepartment_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDDepartment.SelectedIndexChanged
        hnprmid = "0"
        gvdetail.Rows.Clear()
        FillIssueNo()
    End Sub
    Protected Sub FillIssueNo()
        If DDcompany.SelectedIndex <> -1 And DDDepartment.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = ""
            str = "Select Distinct a.IssueOrderID, b.IssueNo " & _
            " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
            " JOIN ProcessIssueToDepartmentMaster b(Nolock) ON b.IssueOrderID = a.ISSUEORDERID  " & _
            " Where IsNull(a.IssuePRMID, 0) > 0 And a.TYPEFLAG = 1 And a.TranType = 1 And a.CompanyID = " & DDcompany.SelectedValue & " And a.BranchID = " & DDBranchName.SelectedValue & " And a.ProcessID = " & DDprocess.SelectedValue & " And " & _
            " a.DepartmentID = " & DDDepartment.SelectedValue & " And a.MasterCompanyID = " & VarMasterCompanyID & " " & _
            " Order By a.IssueOrderID Desc"

            NewComboFill(DDissueNo, str)
        End If
    End Sub
    Private Sub DDissueNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDissueNo.SelectedIndexChanged
        If DDcompany.SelectedIndex <> -1 And DDDepartment.SelectedIndex <> -1 And DDissueNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct PrmId, ChallanNo + ' / ' + REPLACE(CONVERT(NVARCHAR(11), Date, 106), ' ', '-') Challan " & _
            " From DEPARTMENTRAWISSUEMASTER(Nolock) " & _
            " Where TypeFlag = 1 And TranType=1 And IsNull(IssuePRMID, 0) > 0 And IssueOrderID = " & DDissueNo.SelectedValue & " And MasterCompanyId = " & VarMasterCompanyID & " " & _
            " And CompanyID = " & DDcompany.SelectedValue & " And BranchID = " & DDBranchName.SelectedValue & " " & _
            " Order By PrmId Desc "

            NewComboFill(DDReceiveNo, str)
        End If
    End Sub

    Private Sub DDReceiveNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDReceiveNo.SelectedIndexChanged
        If DDcompany.SelectedIndex <> -1 And DDDepartment.SelectedIndex <> -1 And DDissueNo.SelectedIndex <> -1 And DDReceiveNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct VF.CATEGORY_ID, VF.CATEGORY_NAME " & _
                " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
                " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID " & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = b.ITEM_FINISHED_ID " & _
                " Where a.TYPEFLAG = 1 And a.TranType = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & "" & _
                " Order By VF.CATEGORY_NAME "

            NewComboFill(ddCatagory, str)
        End If
    End Sub

    Private Sub ddCatagory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddCatagory.SelectedIndexChanged
        If ddCatagory.SelectedIndex <> -1 And DDissueNo.SelectedIndex <> -1 And DDprocess.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct VF.ITEM_ID, VF.ITEM_NAME " & _
            " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
            " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID " & _
            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = b.ITEM_FINISHED_ID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
            " Where a.TYPEFLAG = 1 And a.TranType = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & " " & _
            " Order By VF.ITEM_NAME " & _
            " SELECT [CATEGORY_PARAMETERS_ID],[CATEGORY_ID],IPM.[PARAMETER_ID],PARAMETER_NAME " & _
            " FROM [ITEM_CATEGORY_PARAMETERS] IPM(Nolock) " & _
            " inner join PARAMETER_MASTER PM(Nolock) ON PM.[PARAMETER_ID] = IPM.[PARAMETER_ID] And PM.MasterCompanyId = " & VarMasterCompanyID & " " & _
            " Where [CATEGORY_ID] = " & ddCatagory.SelectedValue & ""

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

            NewComboFillWithDs(dditemname, ds, 0)
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

                            str = " Select Distinct VF.DesignID, VF.DesignName " & _
                            " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
                            " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID  " & _
                            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = b.ITEM_FINISHED_ID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
                            " Where a.TYPEFLAG = 1 And a.TranType = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & " " & _
                            " Order By VF.DesignName"

                            NewComboFill(DDDesign, str)
                        Case 3
                            LblColor.Visible = True
                            DDColor.Visible = True

                            str = " Select Distinct VF.ColorId, VF.ColorName " & _
                            " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
                            " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID  " & _
                            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = b.ITEM_FINISHED_ID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
                            " Where a.TYPEFLAG = 1 And a.TranType = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & " " & _
                            " Order By VF.ColorName"
                            NewComboFill(DDColor, str)
                        Case 4
                            LblShape.Visible = False
                            DDShape.Visible = False
                            str = " Select Distinct VF.ShapeId, VF.ShapeName " & _
                            " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
                            " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID  " & _
                            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = b.ITEM_FINISHED_ID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
                            " Where a.TYPEFLAG = 1 And a.TranType = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & " " & _
                            " Order By VF.ShapeName"

                            NewComboFill(DDShape, str)
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
    Private Sub dditemname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dditemname.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FindFinishedID()
            Dim str As String = "SELECT U.UnitId, U.UnitName " & _
            " FROM ITEM_MASTER IM(Nolock)  " & _
            " JOIN Unit U(Nolock) ON U.UnitTypeID = IM.UnitTypeID Where IM.ITEM_ID = " & dditemname.SelectedValue & " And IM.MasterCompanyId = " & VarMasterCompanyID & " " & _
            " Select Distinct VF.QualityID, VF.QualityName " & _
            " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
            " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID  " & _
            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = b.ITEM_FINISHED_ID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ITEM_ID = " & dditemname.SelectedValue & " And VF.MasterCompanyId=" & VarMasterCompanyID & " " & _
            " Where a.TYPEFLAG = 1 And a.TranType = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & " " & _
            " Order By VF.QualityName "

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            NewComboFillWithDs(DDunit, ds, 0)
            If DDunit.Items.Count > 0 Then
                DDunit.SelectedIndex = 0
            End If

            NewComboFillWithDs(DDQuality, ds, 1)
        End If
    End Sub

    Private Sub dquality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDQuality.SelectedIndexChanged
        If DDQuality.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FindFinishedID()
            NewComboFill(DDShadeColor, "Select Distinct VF.ShadecolorId, VF.ShadeColorName " & _
                " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
                " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID  " & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = b.ITEM_FINISHED_ID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And  " & _
                " VF.ITEM_ID = " & dditemname.SelectedValue & " And VF.QualityId = " & DDQuality.SelectedValue & " And VF.MasterCompanyId = " & VarMasterCompanyID & " " & _
                " Where a.TYPEFLAG = 1 And a.TranType = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & " " & _
                " Order By VF.ShadeColorName")

        End If
    End Sub

    Private Sub DDShape_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDShape.SelectedIndexChanged
        If DDcompany.SelectedIndex <> -1 And ddCatagory.SelectedIndex <> -1 And DDissueNo.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And DDShape.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FindFinishedID()
            Dim str As String = " Select Distinct VF.SizeID, VF.SizeFt " & _
                            " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
                            " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID  " & _
                            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = b.ITEM_FINISHED_ID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
                            " VF.Item_ID = " & dditemname.SelectedValue & " And VF.ShapeID = " & DDShape.SelectedValue & " " & _
                            " Where a.TYPEFLAG = 1 And a.TranType = 1 And a.CompanyID = " & DDcompany.SelectedValue & " And a.PRMID = " & DDReceiveNo.SelectedValue & " " & _
                            " Order By VF.SizeFt"

            NewComboFill(DDDesign, str)
        End If
    End Sub

    Private Sub ddlshade_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDShadeColor.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDShadeColor.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FindFinishedID()
            Dim str As String = "Select Distinct b.LotNo, b.LotNo " & _
                " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
                " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID  " & _
                " Where a.TRANTYPE = 1 And a.TYPEFLAG = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & " And b.ITEM_FINISHED_ID = " & TxtFinishedID.Text

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

            NewComboFillWithDs(DDLotno, ds, 0)
        End If
    End Sub
    Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGodown.SelectedIndexChanged
        If DDBinNo.Visible = True Then
            FillBinNo()
        Else
            FillStockRecQty()
        End If
    End Sub

    Protected Sub FillStockRecQty()
        Dim str As String = " Select IsNull(Sum(b.Qty), 0) RecQty " & _
                    " From DEPARTMENTRAWISSUEMASTER a(Nolock)" & _
                    " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID " & _
                    " Where a.TranType = 1 And a.TypeFlag = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & " And b.ITEM_FINISHED_ID = " & TxtFinishedID.Text & " " & _
                    " And b.LotNo = '" & DDLotno.Text & "'"

        If DDTagNo.Visible = True Then
            str = str + " And b.TAGNO = '" & DDTagNo.Text & "'"
        End If

        str = str & " Select IsNull(Round(Sum(Qtyinhand), 3), 0) StockQty " & _
            " From Stock(Nolock) " & _
            " Where CompanyID = " & DDcompany.SelectedValue & " And ITEM_FINISHED_ID = " & TxtFinishedID.Text & " And Godownid = " & DDGodown.SelectedValue & " And " & _
            " LotNo = '" & DDLotno.Text & "'"

        If DDTagNo.Visible = True Then
            str = str + " And TagNo = '" & DDTagNo.Text & "'"
        End If

        If DDBinNo.Visible = True Then
            str = str + " And BinNo = '" & DDBinNo.Text & "'"
        End If

        str = str + "Select IsNull(Sum(b.Qty), 0) IssQty " & _
                    " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
                    " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID  " & _
                    " Where a.TranType = 0 And a.TypeFlag = 2 And a.IssuePRMID = " & DDReceiveNo.SelectedValue & " And b.ITEM_FINISHED_ID = " & TxtFinishedID.Text & " " & _
                    " And b.LotNo = '" + DDLotno.Text + "'"
        If DDTagNo.Visible = True Then
            str = str + " And b.TAGNO = '" & DDTagNo.Text & "'"
        End If

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        TxtRecQty.Text = ds.Tables(0).Rows(0)("RecQty").ToString()
        TxtStockQty.Text = ds.Tables(1).Rows(0)("StockQty").ToString()
        TxtPendingQty.Text = (Math.Round(Convert.ToDouble(ds.Tables(0).Rows(0)("RecQty")) - Convert.ToDouble(ds.Tables(2).Rows(0)("IssQty")), 3)).ToString()
    End Sub

    Protected Sub FindFinishedID()
        Dim VarQuality As Integer, VarDesign As Integer, VarColor As Integer, VarShape As Integer, VarSize As Integer, VarShadeColor As Integer
        Dim VarQualityFlag As Integer = 0, VarDesignFlag As Integer = 0, VarColorFlag As Integer = 0, VarShapeFlag As Integer = 0, VarSizeFlag As Integer = 0, VarShadeColorFlag As Integer = 0

        TxtFinishedID.Text = 0

        If (DDQuality.Visible = True) Then
            If (DDQuality.SelectedIndex <> -1) Then
                VarQuality = DDQuality.SelectedValue
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
        If (DDShadeColor.Visible = True) Then
            If (DDShadeColor.SelectedIndex <> -1) Then
                VarShadeColor = DDShadeColor.SelectedValue
                VarShadeColorFlag = 1
            End If
        Else
            VarShadeColorFlag = 1
        End If
        If (VarQualityFlag = 1 And VarDesignFlag = 1 And VarColorFlag = 1 And VarShapeFlag = 1 And VarSizeFlag = 1 And VarShadeColorFlag = 1) Then
            TxtFinishedID.Text = getItemFinishedId(dditemname.SelectedValue, VarQuality, VarDesign, VarColor, VarShape, VarSize, TxtProdCode.Text, VarShadeColor, 0, "", VarMasterCompanyID)
        End If
    End Sub

    Protected Sub FillBinNo()
        If dditemname.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDShadeColor.SelectedIndex <> -1 And DDGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select BinNo, BinNo BinNo1 " & _
                " From Stock(Nolock) " & _
                " Where IsNull(QtyinHand, 0) > 0 And CompanyID = " & DDcompany.SelectedValue & " And ITEM_FINISHED_ID = " & TxtFinishedID.Text & " And " & _
                " Godownid = " & DDGodown.SelectedValue & " And LotNo = '" & DDLotno.Text & "'"
            If (DDTagNo.Visible = True) Then
                str = str + " And TagNo = '" & DDTagNo.Text & "'"
            End If

            str = str + " Order By BinNo "
            NewComboFill(DDBinNo, str)
        End If
    End Sub

    Private Sub DDLotno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDLotno.SelectedIndexChanged
        If DDTagNo.Visible = True Then
            FillTagNo()
        Else
            FillGodown()
        End If
    End Sub

    Protected Sub FillGodown()
        If dditemname.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDShadeColor.SelectedIndex <> -1 And DDLotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FindFinishedID()
            Dim str As String = " Select Distinct GM.GodownID,GM.GodownName " & _
            " From DEPARTMENTRAWISSUEMASTER a(Nolock) " & _
            " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID And b.ITEM_FINISHED_ID = " & TxtFinishedID.Text & " And b.LotNo = '" & DDLotno.Text & "' " & _
            " JOIN GodownMaster GM(Nolock) ON GM.GoDownID = b.GODOWNID " & _
            " JOIN Godown_Authentication GA(Nolock) ON GM.GodownId=GA.GodownId And GA.UserId=" & varuserid & " and GA.MasterCompanyId=" & VarMasterCompanyID & " " & _
            " Where a.TRANTYPE = 1 And a.TYPEFLAG = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & " " & _
            " Order By GM.GodownName "

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            NewComboFillWithDs(DDGodown, ds, 0)
        End If
    End Sub

    Protected Sub FillTagNo()
        If dditemname.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDShadeColor.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct b.TagNo, b.TagNo " & _
            " From DEPARTMENTRAWISSUEMASTER a(Nolock)" & _
            " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) on b.PRMID = a.PRMID  " & _
            " Where a.TranType = 1 And a.TypeFlag = 1 And a.PRMID = " & DDReceiveNo.SelectedValue & " And b.ITEM_FINISHED_ID = " & TxtFinishedID.Text & "" & _
            " And b.LotNo = '" & DDLotno.Text & "'"

            NewComboFill(DDTagNo, str)
        End If
    End Sub

    Private Sub DDTagNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTagNo.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDShadeColor.SelectedIndex <> -1 And DDLotno.SelectedIndex <> -1 And DDTagNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillGodown()
        End If
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Validcombobox(DDcompany) = False Then Exit Sub
        If Validcombobox(DDprocess) = False Then Exit Sub
        If Validcombobox(DDDepartment) = False Then Exit Sub
        If Validcombobox(DDissueNo) = False Then Exit Sub
        If Validcombobox(DDReceiveNo) = False Then Exit Sub
        If Validcombobox(ddCatagory) = False Then Exit Sub
        If Validcombobox(dditemname) = False Then Exit Sub
        If Validcombobox(DDQuality) = False Then Exit Sub
        If Validcombobox(DDShadeColor) = False Then Exit Sub
        If Validcombobox(DDunit) = False Then Exit Sub
        If Validcombobox(DDGodown) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        If Validcombobox(DDLotno) = False Then Exit Sub
        If DDTagNo.Visible = True Then
            If Validcombobox(DDTagNo) = False Then Exit Sub
        End If
        If (TxtFinishedID.Text = 0) Then
            MsgBox("Please select combobox")
            Exit Sub
        End If

        If Validtxtbox(TxtStockQty) = False Then Exit Sub
        If Validtxtbox(TxtRecQty) = False Then Exit Sub
        If Validtxtbox(TxtPendingQty) = False Then Exit Sub
        If Validtxtbox(TxtReturnQty) = False Then Exit Sub

        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If
        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim param(25) As SqlParameter
            param(0) = New SqlParameter("@PRMID", SqlDbType.Int)
            param(1) = New SqlParameter("@COMPANYID", SqlDbType.Int)
            param(2) = New SqlParameter("@BRANCHID", SqlDbType.Int)
            param(3) = New SqlParameter("@PROCESSID", SqlDbType.Int)
            param(4) = New SqlParameter("@ISSUEORDERID", SqlDbType.Int)
            param(5) = New SqlParameter("@DEPARTMENTID", SqlDbType.Int)
            param(6) = New SqlParameter("@DATE", SqlDbType.SmallDateTime)
            param(7) = New SqlParameter("@CHALLANNO", SqlDbType.NVarChar, 150)
            param(8) = New SqlParameter("@TRANTYPE", SqlDbType.Int)
            param(9) = New SqlParameter("@USERID", SqlDbType.Int)
            param(10) = New SqlParameter("@MASTERCOMPANYID", SqlDbType.Int)
            param(11) = New SqlParameter("@TYPEFLAG", SqlDbType.Int)
            param(12) = New SqlParameter("@REMARK", SqlDbType.NVarChar, 200)

            param(13) = New SqlParameter("@PRTID", SqlDbType.Int)
            param(14) = New SqlParameter("@ITEM_FINISHED_ID", SqlDbType.Int)
            param(15) = New SqlParameter("@SIZEFLAG", SqlDbType.Int)
            param(16) = New SqlParameter("@UNITID", SqlDbType.Int)
            param(17) = New SqlParameter("@QTY", SqlDbType.Float)
            param(18) = New SqlParameter("@GODOWNID", SqlDbType.Int)
            param(19) = New SqlParameter("@LOTNO", SqlDbType.NVarChar, 200)
            param(20) = New SqlParameter("@TagNo", SqlDbType.NVarChar, 200)
            param(21) = New SqlParameter("@BinNo", SqlDbType.VarChar, 50)
            param(22) = New SqlParameter("@conetype", SqlDbType.VarChar, 200)
            param(23) = New SqlParameter("@Noofcone", SqlDbType.Int)
            param(24) = New SqlParameter("@Msg", SqlDbType.VarChar, 100)
            param(25) = New SqlParameter("@IssuePRMID", SqlDbType.Int)


            param(0).Value = hnprmid
            param(0).Direction = ParameterDirection.InputOutput
            param(1).Value = DDcompany.SelectedValue
            param(2).Value = DDBranchName.SelectedValue
            param(3).Value = DDprocess.SelectedValue
            param(4).Value = DDissueNo.SelectedValue
            param(5).Value = DDDepartment.SelectedValue
            param(6).Value = txtissuedate.Text
            param(7).Value = txtchallanNo.Text
            param(7).Direction = ParameterDirection.InputOutput
            param(8).Value = 0
            param(9).Value = varuserid
            param(10).Value = VarMasterCompanyID
            param(11).Value = 2
            param(12).Value = TxtRemark.Text
            param(13).Value = 0
            param(14).Value = TxtFinishedID.Text
            param(15).Value = 2                     'ChkForMtr.Checked == true ? 1 : 2;
            param(16).Value = DDunit.SelectedValue
            param(17).Value = TxtReturnQty.Text
            param(18).Value = DDGodown.SelectedValue
            param(19).Value = DDLotno.Text
            param(20).Value = IIf(DDTagNo.Visible = True, DDTagNo.Text, "")
            param(21).Value = IIf(DDBinNo.Visible = True, DDBinNo.Text, "")
            param(22).Value = DDConeType.SelectedValue
            param(23).Value = IIf(TxtNoofCone.Text = "", 0, TxtNoofCone.Text)
            param(24).Value = ""
            param(24).Direction = ParameterDirection.InputOutput
            param(25).Value = DDReceiveNo.SelectedValue

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "[PRO_SAVE_DEPARTMENT_RAW_ISSUE]", param)
            If (param(24).Value.ToString() = "Data saved successfully") Then
                Tran.Commit()
                txtchallanNo.Text = param(7).Value.ToString()
                hnprmid = param(0).Value
                fill_Data_grid()
                DDBinNo.SelectedIndex = -1
                DDGodown.SelectedIndex = -1
                If DDTagNo.Visible = True Then
                    DDTagNo.SelectedIndex = -1
                Else
                    DDLotno.SelectedIndex = -1
                End If

                TxtStockQty.Text = ""
                TxtRecQty.Text = ""
                TxtPendingQty.Text = ""
                TxtReturnQty.Text = ""
                TxtReturnQty.Focus()
                MsgBox(param(24).Value.ToString())
            Else
                Tran.Rollback()
                MsgBox(param(24).Value.ToString())
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Tran.Rollback()
        End Try
    End Sub

    Protected Sub fill_Data_grid()
        Dim i As Integer
        gvdetail.Rows.Clear()
        Dim strsql As String = " Select b.PrtId, VF.CATEGORY_NAME, VF.ITEM_NAME, VF.QualityName + Space(2) + VF.DesignName + Space(2) + VF.ColorName + Space(2) + VF.ShapeName + Space(2) + VF.SizeFt + Space(2) + VF.ShadeColorName [DESCRIPTION]," & _
            " b.Qty, GM.GodownName, b.LotNo, b.TagNo, b.BinNo " & _
            " From DEPARTMENTRAWISSUEMASTER a(Nolock)" & _
            " JOIN DEPARTMENTRAWISSUETRAN b(Nolock) ON b.PRMID = a.PRMID " & _
            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.Item_Finished_id = b.Item_Finished_id " & _
            " JOIN GodownMaster GM(Nolock) ON GM.GodownId = b.GodownId " & _
            " Where a.PrmID = " & hnprmid & " And a.MasterCompanyId = " & VarMasterCompanyID

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                gvdetail.Rows.Add()
                gvdetail.Item("Itemname", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_name")
                gvdetail.Item("Description", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("DESCRIPTION")
                gvdetail.Item("Qty", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
                gvdetail.Item("LotNo", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("LotNo")
                gvdetail.Item("TagNo", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
                gvdetail.Item("GodownName", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GodownName")
                gvdetail.Item("prtidgvdetail", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("PrtId")
            Next
            End If
    End Sub
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        txtchallanNo.Text = ""
        gvdetail.Rows.Clear()
        hnprmid = "0"
        TxtStockQty.Text = ""
    End Sub

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = " Select PM.Date, PM.ChallanNo ChalanNo, PM.trantype, PT.Qty IssueQuantity, " & _
                " PT.Lotno, GM.GodownName, D.DepartmentName EmpName, '' Address, CI.CompanyName, BM.BranchAddress CompAddr1, '' CompAddr2, " & _
                " '' CompAddr3, CI.CompTel, vf.ITEM_NAME, vf.QualityName, vf.designName, " & _
                " vf.ColorName, vf.ShadeColorName, vf.ShapeName, vf.SizeMtr, PNM.PROCESS_NAME, " & _
                " PM.IssueOrderID Prorderid, '' as empgstin, CI.GSTNo,PT.TAGNO,PT.BINNO, BM.GstNo BranchGstNo, " & _
                " 0 ReportType, PM.IssueOrderID " & _
                " From DEPARTMENTRAWISSUEMASTER PM(Nolock) " & _
                " JOIN BranchMaster BM(Nolock) ON BM.ID = PM.BranchID " & _
                " inner join DEPARTMENTRAWISSUETRAN PT(Nolock) on PM.PRMid=PT.PRMid " & _
                " inner join CompanyInfo ci(Nolock) on PM.Companyid=ci.CompanyId " & _
                " inner join V_FinishedItemDetail vf(Nolock) on PT.ITEM_FINISHED_ID=vf.ITEM_FINISHED_ID " & _
                " inner join GodownMaster GM(Nolock) on PT.Godownid=GM.GoDownID " & _
                " inner join Department D(Nolock) on D.DepartmentId = PM.DEPARTMENTID " & _
                " inner join PROCESS_NAME_MASTER PNM(Nolock) on PM.Processid=PNM.PROCESS_NAME_ID " & _
                " Where PM.TypeFlag = 2 And PM.Prmid=" & hnprmid & " and PM.Processid = " & DDprocess.SelectedValue

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptRawIssueRecDuplicateNew.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptRawIssueRecDuplicateNew.xsd")
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
            MsgBox("No records found..")
        End If
    End Sub

    Private Sub gvdetail_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvdetail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If
            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim VarPrtID As Integer = gvdetail.Item("prtidgvdetail", gvdetail.CurrentRow.Index).Value

                Dim arr As SqlParameter() = New SqlParameter(7) {}
                arr(0) = New SqlParameter("@PrtID", SqlDbType.Int)
                arr(1) = New SqlParameter("@RowCount", SqlDbType.Int)
                arr(2) = New SqlParameter("@TranType", SqlDbType.Int)
                arr(3) = New SqlParameter("@Msg", SqlDbType.VarChar, 100)
                arr(4) = New SqlParameter("@userid", varuserid)
                arr(5) = New SqlParameter("@Mastercompanyid", VarMasterCompanyID)
                arr(6) = New SqlParameter("@TypeFlag", 2)

                arr(0).Value = VarPrtID
                arr(1).Value = gvdetail.Rows.Count
                arr(2).Value = 0
                arr(3).Direction = ParameterDirection.Output

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_DELETE_DEPARTMENT_RAW_ISSUE", arr)
                If arr(3).Value.ToString() <> "" Then
                    MsgBox(arr(3).Value.ToString())
                End If
                Tran.Commit()

                fill_Data_grid()
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
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

                TxtRecQty.Text = w_Weight.ToString()

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()
    Private Sub TxtRecQty_GotFocus(sender As Object, e As System.EventArgs) Handles TxtRecQty.GotFocus
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

    Private Sub FrmDepartmentRowIssue_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub DDBinNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDBinNo.SelectedIndexChanged
        If (DDBinNo.Visible = True) Then
            FillStockRecQty()
        End If
    End Sub
End Class