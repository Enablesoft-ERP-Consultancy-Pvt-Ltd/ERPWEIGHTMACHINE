Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class FrmGeneralGateIn
    Dim VarGateInID As Integer = 0

    Private Sub frmyarnopeningissue_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select Distinct CI.CompanyId,Companyname From Companyinfo CI,Company_Authentication CA Where CA.CompanyId=CI.CompanyId And CA.UserId=" & varuserid & " And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By Companyname  " & _
            " Select Empid,EmpName + ' (' + EmpCode + ')' EmpName from empinfo where mastercompanyid=" & VarMasterCompanyID & "  order by empname " & _
            " Select DepartmentId, DepartmentName From Department Order By DepartmentName" & _
            " Select GM.GodownId, GM.GodownName From GodownMaster GM JOIN Godown_Authentication GA ON GM.GodownId=GA.GodownId Where GA.UserId=" & varuserid & " And GA.MasterCompanyId=" & VarMasterCompanyID & " Order by GodownName" & _
            " Select ConeType, ConeType From ConeMaster Order By SrNo "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(ddCompName, ds, 0)
        If ddCompName.Items.Count > 0 Then
            ddCompName.SelectedIndex = 0
        End If

        NewComboFillWithDs(ddempname, ds, 1)
        NewComboFillWithDs(DDDept, ds, 2)

        txtdate.Text = DateTime.Now.ToString("dd-MMM-yyyy")
        VarGateInID = 0
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If
        NewComboFillWithDs(ddgodown, ds, 3)
        If ddgodown.Items.Count > 0 Then
            ddgodown.SelectedIndex = 0
            FillBinNO()
        End If
        NewComboFillWithDs(DDConeType, ds, 4)

    End Sub

    Private Sub DDDept_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDDept.SelectedIndexChanged
        VarGateInID = 0
        txtchallanNo.Text = ""
        If DDDept.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Str = "Select Empid, EmpName + ' (' + EmpCode + ')' EmpName  from empinfo where mastercompanyid = " & VarMasterCompanyID & " And " & _
                    " Departmentid = " & DDDept.SelectedValue & " Order By EmpName + ' (' + EmpCode + ')'"
            NewComboFill(ddempname, Str)
        End If
    End Sub

    Private Sub ddempname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddempname.SelectedIndexChanged
        If ddCompName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            EmpSelectedChange()
            FillCategory()
            ControlEnableORFalse()
        End If
    End Sub

    Private Sub EmpSelectedChange()
        VarGateInID = 0
        txtchallanNo.Text = ""
        TxtGateInNo.Text = ""
        If ddCompName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Str As String = "Select GATEOUTID,cast(ISSUENO as varchar) +' / '+ replace(convert(varchar(11),ISSUEDATE,106),' ','-') as Date " & _
            " From View_GateOutInDetail Where CompanyId=" & ddCompName.SelectedValue & " And PartyID=" & ddempname.SelectedValue & " And MasterCompanyId=" & VarMasterCompanyID & " And deptid=" & DDDept.SelectedValue & "" & _
            " Group By GATEOUTID,ISSUENO,ISSUEDATE Having Sum(IssQty)>Sum(RecQty) order by GATEOUTID "

            If ChKForEdit.Checked = True Then
                Str = Str & "Select Distinct GIM.GateInID,cast(GIM.GateInNo as varchar) +' / '+ replace(convert(varchar(11),GIM.GateInDate,106),' ','-') as GateInNo " & _
                " From GateInMaster GIM,GateInDetail GID Where GIM.GateInID=GID.GateInID And CompanyID=" & ddCompName.SelectedValue & " And MasterCompanyID=" & VarMasterCompanyID & " And " & _
                " PartyId = " & ddempname.SelectedValue & " And GIM.Deptid=" & DDDept.SelectedValue & " order by GIM.GateInID"
            End If

            Dim Ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, Str)

            NewComboFillWithDs(DDGatePassNo, Ds, 0)
            If ChKForEdit.Checked = True Then
                NewComboFillWithDs(DDGateInNo, Ds, 1)
            End If
        End If
    End Sub

    Private Sub FillCategory()
        Dim Str As String = " Select Distinct CATEGORY_ID, CATEGORY_NAME From Item_Category_Master ICM, CategorySeparate CS " & _
            " Where ICM.CATEGORY_ID=CS.CategoryID And ICM.MasterCompanyID = " & VarMasterCompanyID & " And CS.ID = 1 Order by ICM.CATEGORY_NAME"
        If DDGatePassNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Str = "Select Distinct VF.CATEGORY_ID, VF.CATEGORY_NAME " & _
            " FROM GateoutMaster GM(Nolock) " & _
            " JOIN GateOutDetail GD(Nolock) ON GD.GATEOUTID = GM.GATEOUTID  " & _
            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = GD.FINISHEDID  " & _
            " Where GM.GATEOUTID = " & DDGatePassNo.SelectedValue & " And GM.MASTERCOMPANYID = " & VarMasterCompanyID & " And GM.PARTYID = " & ddempname.SelectedValue & ""
        End If
        NewComboFill(ddCatagory, Str)
    End Sub

    Private Sub DDGatePassNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGatePassNo.SelectedIndexChanged
        If DDGatePassNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillCategory()
            ControlEnableORFalse()
            Fill_ShowData()
            If ddCatagory.Items.Count > 0 Then
                ddCatagory.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub ddCatagory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddCatagory.SelectedIndexChanged
        If ddCatagory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillItemName()
            If dditemname.Items.Count > 0 Then
                dditemname.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub FillItemName()
        If ddCatagory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct ITEM_ID, ITEM_NAME From Item_Master Where CATEGORY_ID=" & ddCatagory.SelectedValue & " And MasterCompanyid=" & VarMasterCompanyID & " Order By ITEM_NAME"
            If DDGatePassNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                str = "Select Distinct VF.ITEM_ID, VF.ITEM_NAME " & _
                " FROM GateoutMaster GM(Nolock) " & _
                " JOIN GateOutDetail GD(Nolock) ON GD.GATEOUTID = GM.GATEOUTID  " & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = GD.FINISHEDID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
                " Where GM.GATEOUTID = " & DDGatePassNo.SelectedValue & " And GM.MASTERCOMPANYID = " & VarMasterCompanyID & " " & _
                " And GM.PARTYID = " & ddempname.SelectedValue & " Order By VF.ITEM_NAME"
            End If

            NewComboFill(dditemname, str)
        End If
    End Sub

    Private Sub dditemname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dditemname.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillUnitItemDescription()
        End If
    End Sub

    Protected Sub FillUnitItemDescription()
        Dim str As String = ""
        If ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            str = "select Distinct U.UnitId,U.UnitName from Unit U inner join UNIT_TYPE_MASTER UT on U.UnitTypeID=UT.UnitTypeID inner join Item_master IM on Im.UnitTypeID=UT.UnitTypeID and Im.item_id=" & dditemname.SelectedValue & " order by unitname" & _
            " Select VF.ITEM_FINISHED_ID, Replace(VF.QualityName + ' | ' + VF.DesignName + ' | ' + VF.ColorName + ' | ' + VF.ShapeName + ' | ' + VF.SizeFt + ' | ' + VF.ShadeColorName, '|  ', '') ItemDescription " & _
                " FROM V_FinishedItemDetail VF(Nolock) " & _
                " Where VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ITEM_ID = " & dditemname.SelectedValue & " And VF.MASTERCOMPANYID = " & VarMasterCompanyID & "" & _
                " Order By Replace(VF.QualityName + ' | ' + VF.DesignName + ' | ' + VF.ColorName + ' | ' + VF.ShapeName + ' | ' + VF.SizeFt + ' | ' + VF.ShadeColorName, '|  ', '') "

            If ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And DDGatePassNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                str = "select Distinct U.UnitId,U.UnitName from Unit U inner join UNIT_TYPE_MASTER UT on U.UnitTypeID=UT.UnitTypeID inner join Item_master IM on Im.UnitTypeID=UT.UnitTypeID and Im.item_id=" & dditemname.SelectedValue & " order by unitname" & _
                " Select VF.ITEM_FINISHED_ID, Replace(VF.QualityName + ' | ' + VF.DesignName + ' | ' + VF.ColorName + ' | ' + VF.ShapeName + ' | ' + VF.SizeFt + ' | ' + VF.ShadeColorName, '|  ', '') ItemDescription " & _
                " FROM View_GateOutInDetail VGD" & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = VGD.FINISHEDID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ITEM_ID = " & dditemname.SelectedValue & "" & _
                " Where VGD.CompanyId = " & ddCompName.SelectedValue & " And VGD.MASTERCOMPANYID = " & VarMasterCompanyID & "  And VGD.PARTYID = " & ddempname.SelectedValue & " " & _
                " And VGD.GateOutID = " & DDGatePassNo.SelectedValue & " " & _
                " Group by VF.ITEM_FINISHED_ID, VF.QualityName, VF.DesignName, VF.ColorName, VF.ShapeName, VF.SizeFt, VF.ShadeColorName " & _
                " Having(Sum(VGD.IssQty) > Sum(VGD.RecQty))" & _
                " Order By Replace(VF.QualityName + ' | ' + VF.DesignName + ' | ' + VF.ColorName + ' | ' + VF.ShapeName + ' | ' + VF.SizeFt + ' | ' + VF.ShadeColorName, '|  ', '') "

            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            NewComboFillWithDs(ddlunit, ds, 0)
            If ddlunit.Items.Count > 0 Then
                ddlunit.SelectedIndex = 0
            End If

            NewComboFillWithDs(DDDescription, ds, 1)
        End If
    End Sub

    Protected Sub FillGodown()
        If ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And ddCompName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select GM.GodownId, GM.GodownName From GodownMaster GM(Nolock) JOIN Godown_Authentication GA(Nolock) ON GM.GodownId = GA.GodownId " & _
                " Where GA.UserId = " & varuserid & " And GA.MasterCompanyId = " & VarMasterCompanyID & " Order by GM.GodownName "
            NewComboFill(ddgodown, str)
        End If
    End Sub

    Private Sub DDDescription_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDDescription.SelectedIndexChanged
        'Filllotno()
    End Sub

    Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddgodown.SelectedIndexChanged
        If ddgodown.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillBinNO()
        End If
    End Sub

    Protected Sub FillBinNO()
        If VarCHECKBINCONDITION = 1 Then
            Module1.FillBinNO(DDBinNo, ddgodown.SelectedValue, DDDescription.SelectedValue, New_Edit:=0)
        Else
            NewComboFill(DDBinNo, "Select BinId, BInNo From BinMaster(Nolock) Where GODOWNID = " & ddgodown.SelectedValue & "")
        End If
    End Sub

    'Protected Sub Filllotno()
    '    If DDGatePassNo.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And Varcombovalue <> 0 Then
    '        Dim str As String = "Select Distinct GD.LotNo, GD.LotNo" & _
    '            " FROM GateoutMaster GM " & _
    '            " JOIN GateOutDetail GD ON GD.GATEOUTID = GM.GATEOUTID And GD.FINISHEDID = " & DDDescription.SelectedValue & "" & _
    '            " Where GM.GATEOUTID = " & DDGatePassNo.SelectedValue & " Order By GD.LotNo "

    '        NewComboFill(ddlotno, str)
    '        If ddlotno.Items.Count > 0 Then
    '            ddlotno.SelectedIndex = 0
    '            FillTagno()
    '        End If
    '        If DDTagNo.Items.Count > 0 Then
    '            DDTagNo.SelectedIndex = 0
    '            TagNoSelectedChanged()
    '        End If
    '    End If
    'End Sub

    Private Sub DDLotNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        'If ddlotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
        '    FillTagno()
        'End If
    End Sub
    'Protected Sub FillTagno()
    '    If DDGatePassNo.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And ddlotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
    '        Dim str As String = "Select Distinct GD.TagNo, GD.TagNo " & _
    '            " FROM GateoutMaster GM " & _
    '            " JOIN GateOutDetail GD ON GD.GATEOUTID = GM.GATEOUTID And GD.FINISHEDID = " & DDDescription.SelectedValue & " And GD.LotNo = '" & ddlotno.Text & "'" & _
    '            " Where GM.GATEOUTID = " & DDGatePassNo.SelectedValue & " Order By GD.TagNo "

    '        NewComboFill(DDTagNo, str)
    '    End If
    'End Sub

    Private Sub DDTagNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        'TagNoSelectedChanged()
    End Sub

    Private Sub TagNoSelectedChanged()
        If DDGatePassNo.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            'FillIssueQty()
        End If
    End Sub

    'Protected Sub FillIssueQty()
    '    TxtIssueQty.Text = ""
    '    If DDGatePassNo.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And ddlotno.SelectedIndex <> -1 And DDTagNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
    '        Dim str As String = "Select Sum(a.IssQty) IssQty, Sum(a.RecQty) RecQty, Sum(a.IssQty - a.RecQty) PendingQty " & _
    '            " From View_GateOutInDetail a" & _
    '            " Where a.GATEOUTID = " & DDGatePassNo.SelectedValue & " And a.FINISHEDID = " & DDDescription.SelectedValue & "  And a.LotNo = '" & ddlotno.Text & "' And a.TagNo = '" & DDTagNo.Text & "'"
    '        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            TxtIssueQty.Text = Convert.ToDouble(ds.Tables(0).Rows(0)("IssQty"))
    '        End If
    '    End If
    'End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Validcombobox(ddCompName) = False Then Exit Sub
        If Validcombobox(DDDept) = False Then Exit Sub
        If Validcombobox(ddempname) = False Then Exit Sub
        If Validcombobox(DDDescription) = False Then Exit Sub
        If Validcombobox(ddCatagory) = False Then Exit Sub
        If Validcombobox(dditemname) = False Then Exit Sub
        If Validcombobox(ddlunit) = False Then Exit Sub
        If Validcombobox(ddgodown) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        If Validtxtbox(TxtQty) = False Then Exit Sub


        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim param(28) As SqlParameter
            param(0) = New SqlParameter("@GateInID", SqlDbType.Int)
            param(0).Direction = ParameterDirection.InputOutput
            param(0).Value = Val(VarGateInID)
            param(1) = New SqlParameter("CompanyID", ddCompName.SelectedValue)
            param(2) = New SqlParameter("@PartyID", ddempname.SelectedValue)
            param(3) = New SqlParameter("@GateInNo", SqlDbType.VarChar, 50)
            param(3).Direction = ParameterDirection.InputOutput
            param(3).Value = TxtGateInNo.Text
            param(4) = New SqlParameter("GateInDate", txtdate.Text)

            param(5) = New SqlParameter("@MasterCompanyID", VarMasterCompanyID)
            param(6) = New SqlParameter("@UserID", varuserid)
            param(7) = New SqlParameter("@GateInDetailID", SqlDbType.Int)
            param(7).Direction = ParameterDirection.InputOutput
            param(7).Value = 0
            param(8) = New SqlParameter("@FinishedID", DDDescription.SelectedValue)
            param(9) = New SqlParameter("@Qty", TxtQty.Text)
            param(10) = New SqlParameter("@GodownID", ddgodown.SelectedValue)
            param(11) = New SqlParameter("@LotNo", IIf(TxtLotNo.Text = "", "Without Lot No", TxtLotNo.Text))
            param(12) = New SqlParameter("@CategoryType", 1)
            param(13) = New SqlParameter("@Remark", txtremarks.Text)
            param(14) = New SqlParameter("@GateOutID", SqlDbType.Int)
            If DDGatePassNo.SelectedIndex > -1 Then
                param(14).Value = DDGatePassNo.SelectedValue
            Else
                param(14).Value = 0
            End If
            param(15) = New SqlParameter("@Unitid", ddlunit.SelectedValue)
            param(16) = New SqlParameter("@ChallanNo", txtchallanNo.Text)
            param(17) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            param(17).Direction = ParameterDirection.Output
            param(18) = New SqlParameter("@TagNo", IIf(TxtTagNo.Text = "", "Without Tag No", TxtTagNo.Text))
            param(19) = New SqlParameter("@DeptId", DDDept.SelectedValue)
            param(20) = New SqlParameter("@BinNo", IIf(DDBinNo.Visible = False, "", DDBinNo.Text))
            param(21) = New SqlParameter("@Rate", txtRate.Text)
            param(22) = New SqlParameter("@BranchID", 0)
            param(23) = New SqlParameter("@ConeType", DDConeType.SelectedValue)
            param(24) = New SqlParameter("@NoofCone", IIf(TxtNoofCone.Text = "", "0", TxtNoofCone.Text))
            param(25) = New SqlParameter("@BellWeight", IIf(TxtBellWeight.Text = "", "0", TxtBellWeight.Text))
            param(26) = New SqlParameter("@GateInType", 0)
            param(27) = New SqlParameter("@OrderId", 0)

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "[PRO_GateIn]", param)
            VarGateInID = param(0).Value.ToString()
            Tran.Commit()
            If param(17).Value.ToString() <> "" Then
                MsgBox(param(17).Value.ToString())
            End If
            TxtQty.Text = ""
            TxtIssueQty.Text = ""
            txtremarks.Text = ""
            txtRate.Text = ""
            TxtNoofCone.Text = ""
            TxtBellWeight.Text = ""
            TxtGateInNo.Text = param(3).Value.ToString()
            'DDDescription.SelectedText = 0
            'DDBinNo.SelectedText = 0
            FillGrid()
            If (DDGatePassNo.SelectedIndex > -1) Then
                Fill_ShowData()
            End If
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub FillGrid()
        DG.Rows.Clear()
        Dim i As Integer
        Dim str As String = "Select GIM.GateInID, GateInDetailID,CATEGORY_NAME+' '+ITEM_NAME+' '+QualityName+' '+designName+' '+ColorName+' '+ShadeColorName+' '+ShapeName+' '+SizeFt as description," & _
        " GodownName,lotNo,QTY as Qty,Remark,GID.TagNo,GID.Rate " & _
        " From GateInMaster GIM,GateInDetail GID,V_finisheditemdetail VF,GodownMaster GM " & _
        " Where GIM.GateInID=GID.GateInID And GID.FINISHEDID=VF.ITEM_FINISHED_ID And GM.GoDownID=GID.GoDownID And GIM.GateInID=" & VarGateInID & ""

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            DG.Rows.Add()
            DG.Item("description", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("description")
            DG.Item("GodownName", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GodownName")
            DG.Item("Lotno", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("lotno")
            DG.Item("TagNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
            DG.Item("qty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("qty")
            DG.Item("Rate", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rate")
            DG.Item("GateInID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GateInID")
            DG.Item("GateInDetailID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GateInDetailID")
        Next
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = "SELECT c.CompanyName,BM.BranchAddress CompAddr1,'' CompAddr2,'' CompAddr3, " & _
        " c.CompFax,BM.PhoneNo CompTel,e.EmpName,e.Address,e.PhoneNo,e.Mobile,e.Fax,GIM.GateInNo,GIM.GateInDate,LotNo,Qty,GID.Remark,GM.GodownName, " & _
        " CATEGORY_NAME+' '+ITEM_NAME+' '+QualityName+' '+designName+' '+ColorName+' '+ShadeColorName+' '+ShapeName+' '+SizeFt as Description, " & _
        " ITEM_FINISHED_ID,gm.GoDownID,GIM.ChallanNo,GID.TagNo,DP.DepartmentName,BM.GSTNo GSTNO,e.GSTNO as EmpGstno,GID.Rate,isnull(NU.UserName,'') as UserName  " & _
        " FROM GateInMaster GIM(NoLock)  " & _
        " JOIN BranchMaster BM(NoLock) ON BM.ID = GIM.BranchID  " & _
        " INNER JOIN COMPANYINFO C(NoLock) ON C.CompanyId=GIM.COMPANYID  " & _
        " inner join empinfo e(NoLock) on e.empid=GIM.partyid  " & _
        " inner join GateInDetail GID(NoLock) On GIM.GateInID=GID.GateInID  " & _
        " Inner join GodownMaster GM(NoLock) On GM.GoDownID=GID.GoDownID  " & _
        " inner join V_finisheditemdetail vd(NoLock) On vd.item_finished_id=GID.finishedid  " & _
        " left join Department DP(NoLock) on GIM.DeptId=DP.DepartmentId  " & _
        " JOIN NewUserDetail NU(NoLock) ON GIM.UserID=NU.UserID " & _
        " Where GIM.GateInID=" & VarGateInID & " "

        'SELECT c.CompanyName,c.CompAddr1,c.CompAddr2,c.CompAddr3,c.CompFax,c.CompTel,e.EmpName,e.Address,e.PhoneNo,e.Mobile,e.Fax," & _
        '" GIM.GateInNo,GIM.GateInDate,LotNo,Qty,GID.Remark,GM.GodownName," & _
        '" CATEGORY_NAME+' '+ITEM_NAME+' '+QualityName+' '+designName+' '+ColorName+' '+ShadeColorName+' '+ShapeName+' '+SizeFt as Description," & _
        '" ITEM_FINISHED_ID,gm.GoDownID,GIM.ChallanNo,GID.TagNo,DP.DepartmentName,C.GSTNO,e.GSTNO as EmpGstno,GID.Rate" & _
        '" FROM COMPANYINFO C INNER JOIN GateInMaster GIM ON C.CompanyId=GIM.COMPANYID inner join empinfo e on e.empid=GIM.partyid " & _
        '" inner join GateInDetail GID On GIM.GateInID=GID.GateInID Inner join " & _
        '" GodownMaster GM On GM.GoDownID=GID.GoDownID inner join V_finisheditemdetail vd On vd.item_finished_id=GID.finishedid " & _
        '" left join Department DP on GIM.DeptId=DP.DepartmentId Where GIM.GateInID = " & VarGateInID & " "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptGateInTagNoWise.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptGateIn.xsd")
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
                Dim param(6) As SqlParameter
                param(0) = New SqlParameter("@Prtid", DG.Item("GateInDetailID", DG.CurrentRow.Index).Value)
                param(1) = New SqlParameter("@TableName", "GateInDetail")
                param(2) = New SqlParameter("@Count", DG.Rows.Count)
                param(3) = New SqlParameter("@FlagDeleteOrNot", SqlDbType.Int)
                param(3).Direction = ParameterDirection.Output
                param(4) = New SqlParameter("@Msg", SqlDbType.VarChar, 100)
                param(4).Direction = ParameterDirection.Output
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_UpdateStockAndDeleteGateIn", param)

                Tran.Commit()
                If param(4).Value.ToString() <> "" Then
                    MsgBox(param(4).Value.ToString())
                End If
                If DG.Rows.Count = 1 Then
                    VarGateInID = 0
                    txtchallanNo.Text = ""
                    TxtGateInNo.Text = ""
                    ddgodown.SelectedIndex = 0
                End If
                FillGrid()
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        End If
    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        DDDept.SelectedIndex = -1
        ddempname.SelectedIndex = -1
        txtchallanNo.Text = ""
        VarGateInID = 0
        TxtQty.Text = ""
        DG.Rows.Clear()
        txtdate.Text = System.DateTime.Now.ToString("dd-MMM-yyyy")
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

                TxtQty.Text = w_Weight.ToString()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()

    Private Sub txtissqty_GotFocus(sender As Object, e As System.EventArgs) Handles TxtQty.GotFocus
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

    Private Sub frmyarnopeningissue_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub ChKForEdit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChKForEdit.CheckedChanged
        txtchallanNo.Text = ""
        txtdate.Text = DateTime.Now.ToString("dd-MMM-yyyy")
        LblGateInNo.Visible = False
        DDGateInNo.Visible = False
        If (ChKForEdit.Checked = True) Then
            LblGateInNo.Visible = True
            DDGateInNo.Visible = True
            EmpSelectedChange()
        End If
    End Sub

    Private Sub DDGateInNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGateInNo.SelectedIndexChanged
        txtRate.Text = ""
        VarGateInID = 0
        If DDGateInNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            VarGateInID = DDGateInNo.SelectedValue
            Dim Str As String = "Select GIM.GateInID, GIM.GateInNo, GIM.ChallanNo, replace(convert(varchar(11),GIM.GateInDate,106),' ','-') GateInDate " & _
            " From GateInMaster GIM " & _
            " Where GIM.CompanyID=" & ddCompName.SelectedValue & " And MasterCompanyID=" & VarMasterCompanyID & " And " & _
            " PartyId = " & ddempname.SelectedValue & " And GIM.GateInNo =" & DDGateInNo.SelectedValue & ""

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, Str)
            If ds.Tables(0).Rows.Count > 0 Then
                VarGateInID = DDGateInNo.SelectedValue
                txtchallanNo.Text = ds.Tables(0).Rows(0)("ChallanNo")
                TxtGateInNo.Text = ds.Tables(0).Rows(0)("GateInNo")
                txtdate.Text = ds.Tables(0).Rows(0)("GateInDate")
            End If
            FillGrid()
        End If
    End Sub

    Private Sub DGShowData_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGShowData.CellDoubleClick
        Dim LotNo As String = DGShowData.Item("LotNoShow", DGShowData.CurrentRow.Index).Value
        Dim TagNo As String = DGShowData.Item("TagNoShow", DGShowData.CurrentRow.Index).Value
        Dim UnitID As String = DGShowData.Item("UnitID", DGShowData.CurrentRow.Index).Value
        Dim FinishedID As String = DGShowData.Item("FinishedID", DGShowData.CurrentRow.Index).Value

        Dim Str As String = "Select ITEM_FINISHED_ID, CATEGORY_ID, ITEM_ID " & _
                " From V_FinishedItemDetail Where ITEM_FINISHED_ID= " & FinishedID & "" & _
                " Select Sum(IssQty) - Sum(RecQty) Qty From View_GateOutInDetail Where GateOutID = " & DDGatePassNo.SelectedValue & "" & _
                " And Finishedid = " & FinishedID & " And LotNo = '" & LotNo & "' And TagNo = '" & TagNo & "' And UnitID  = " & UnitID & ""
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, Str)
        If ds.Tables(0).Rows.Count > 0 Then
            ddCatagory.SelectedValue = ds.Tables(0).Rows(0)("CATEGORY_ID")
            FillItemName()
            dditemname.SelectedValue = ds.Tables(0).Rows(0)("ITEM_ID")
            FillUnitItemDescription()
            DDDescription.SelectedValue = ds.Tables(0).Rows(0)("ITEM_FINISHED_ID")
        End If
        If ds.Tables(1).Rows.Count > 0 Then
            TxtIssueQty.Text = ds.Tables(1).Rows(0)("Qty")
        End If
        ddlunit.SelectedValue = UnitID
        TxtLotNo.Text = LotNo
        TxtTagNo.Text = TagNo
    End Sub
    Private Sub Fill_ShowData()
        'TDIssueQty.Visible = false;
        'DivDGShowData.Visible = false;
        'If (DDGatePassNo.SelectedIndex > 0) Then
        '{
        '    TDIssueQty.Visible = true;
        '    DivDGShowData.Visible = true;
        '}
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, "Select ITEM_FINISHED_ID Finishedid, ITEM_NAME+' '+QualityName+' '+designName+' '+ColorName+' '+ShapeName+' '+SizeFt+' '+ShadeColorName As DescriptionShow, Sum(IssQty) IssQty, Sum(RecQty) RecQty, VGD.Lotno LotNoShow, VGD.TagNo TagNoShow, VGD.unitid " & _
        " From View_GateOutInDetail VGD,V_FinishedItemDetail VF Where VGD.Finishedid=VF.ITEM_FINISHED_ID  And GATEOUTID=" & DDGatePassNo.SelectedValue & " Group By ITEM_FINISHED_ID,ITEM_NAME,QualityName,designName,ColorName, " & _
        " ShapeName,SizeFt,ShadeColorName,VGD.Lotno,VGD.TagNo,VGD.unitid")
        For i = 0 To ds.Tables(0).Rows.Count - 1
            DGShowData.Rows.Add()
            DGShowData.Item("descriptionShow", DGShowData.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("descriptionShow")
            DGShowData.Item("lotnoshow", DGShowData.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("lotnoshow")
            DGShowData.Item("TagNoShow", DGShowData.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNoShow")
            DGShowData.Item("IssQty", DGShowData.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IssQty")
            DGShowData.Item("RecQty", DGShowData.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RecQty")
            DGShowData.Item("Finishedid", DGShowData.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Finishedid")
            DGShowData.Item("unitid", DGShowData.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitid")
        Next
    End Sub

    Private Sub ControlEnableORFalse()
        DGShowData.Rows.Clear()
        TxtLotNo.Text = ""
        TxtTagNo.Text = ""
        TxtIssueQty.Text = ""
        If (DDGatePassNo.SelectedIndex > -1 And Varcombovalue <> -1) Then
            TxtLotNo.ReadOnly = True
            TxtTagNo.ReadOnly = True
            ddCatagory.Enabled = False
            dditemname.Enabled = False
            DDDescription.Enabled = False
        Else
            TxtLotNo.ReadOnly = False
            TxtTagNo.ReadOnly = False
            ddCatagory.Enabled = True
            dditemname.Enabled = True
            DDDescription.Enabled = True
        End If
    End Sub
End Class