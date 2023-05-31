Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class FrmGeneralGatePass
    Dim GateOut As Integer = 0
    Private Sub frmyarnopeningissue_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select Distinct CI.CompanyId,Companyname from Companyinfo CI,Company_Authentication CA Where CA.CompanyId=CI.CompanyId And CA.UserId=" & varuserid & " And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By Companyname " & _
                    " select Empid,EmpName + ' (' + EmpCode + ')' EmpName from empinfo where mastercompanyid=" & VarMasterCompanyID & " order by empname " & _
                    " select DepartmentId,DepartmentName from Department order by DepartmentName" & _
                    " Select Distinct ic.CATEGORY_ID,ic.CATEGORY_NAME FROM dbo.V_finisheditemdetail im INNER JOIN dbo.Stock s ON im.ITEM_FINISHED_ID = s.ITEM_FINISHED_ID  inner join  " & _
                    " ITEM_CATEGORY_MASTER ic On im.CATEGORY_ID=ic.CATEGORY_ID inner join CategorySeparate cs ON cs.Categoryid = ic.CATEGORY_ID Where ic.mastercompanyid=" & VarMasterCompanyID & " and cs.id = 1 order by CATEGORY_NAME" & _
                    " Select ConeType, ConeType From ConeMaster Order By SrNo "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(ddCompName, ds, 0)
        If ddCompName.Items.Count > 0 Then
            ddCompName.SelectedIndex = 0
        End If

        NewComboFillWithDs(ddempname, ds, 1)
        NewComboFillWithDs(DDDept, ds, 2)
        NewComboFillWithDs(ddCatagory, ds, 3)
        If ddCatagory.Items.Count > 0 Then
            ddCatagory.SelectedIndex = 0
        End If
        NewComboFillWithDs(DDConeType, ds, 4)

        txtdate.Text = DateTime.Now.ToString("dd-MMM-yyyy")
        GateOut = 0
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If
    End Sub

    Private Sub DDDept_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDDept.SelectedIndexChanged
        GateOut = 0
        txtchalanno.Text = ""
        If DDDept.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(ddempname, "select EmpId,EmpName + ' (' + EmpCode + ')' EmpName From Empinfo Where MasterCompanyid=" & VarMasterCompanyID & " and Departmentid=" & DDDept.SelectedValue & " order by EmpName")
        End If
    End Sub

    Private Sub ddCatagory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddCatagory.SelectedIndexChanged
        If ddCatagory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct im.ITEM_ID,im.ITEM_NAME FROM ITEM_MASTER im Inner join " & _
            " v_finisheditemdetail v On v.ITEM_ID=im.ITEM_ID Inner join " & _
            " stock s On s.ITEM_FINISHED_ID=v.ITEM_FINISHED_ID " & _
            " where v.CATEGORY_ID=" & ddCatagory.SelectedValue & " and im.MasterCompanyid=" & VarMasterCompanyID & " order by im.ITEM_NAME"
            NewComboFill(dditemname, str)
        End If
    End Sub

    Private Sub dditemname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dditemname.SelectedIndexChanged
        If ddgodown.Items.Count = 0 Then
            FillGodown()
        End If
        FillUnitItemDescription()
    End Sub
    Protected Sub FillGodown()
        If ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And ddCompName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct GM.GodownID, GM.GodownName " & _
                " From GodownMaster GM  " & _
                " JOIN Godown_Authentication GA ON GM.GodownId=GA.GodownId And GA.UserId = " & varuserid & " and GA.MasterCompanyId = " & VarMasterCompanyID & " " & _
                " JOIN Stock S ON GM.GodownID=S.GodownID  " & _
                " JOIN V_FinishedItemDetail VF ON VF.ITEM_FINISHED_ID = S.ITEM_FINISHED_ID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ITEM_ID = " & dditemname.SelectedValue & " " & _
                " Where S.CompanyId = " & ddCompName.SelectedValue & " And GM.MasterCompanyId = " & VarMasterCompanyID & " And Round(S.Qtyinhand, 3) > 0 " & _
                " Order By GM.GodownName "
            NewComboFill(ddgodown, str)
        End If
    End Sub

    Protected Sub FillUnitItemDescription()
        If ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And ddgodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct U.UnitId,U.UnitName from Unit U inner join UNIT_TYPE_MASTER UT on U.UnitTypeID=UT.UnitTypeID inner join Item_master IM on Im.UnitTypeID=UT.UnitTypeID and Im.item_id=" & dditemname.SelectedValue & " order by unitname" & _
            " Select Distinct VF.ITEM_FINISHED_ID, Replace(VF.QualityName + ' | ' + VF.DesignName + ' | ' + VF.ColorName + ' | ' + VF.ShapeName + ' | ' + VF.SizeFt + ' | ' + VF.ShadeColorName, '|  ', '') ItemDescription " & _
            " FROM V_FinishedItemDetail VF" & _
            " JOIN Stock S ON S.ITEM_FINISHED_ID = VF.ITEM_FINISHED_ID And S.Godownid = " & ddgodown.SelectedValue & " " & _
            " Where VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ITEM_ID = " & dditemname.SelectedValue & " And Round(S.Qtyinhand, 3) > 0 " & _
            " Order By Replace(VF.QualityName + ' | ' + VF.DesignName + ' | ' + VF.ColorName + ' | ' + VF.ShapeName + ' | ' + VF.SizeFt + ' | ' + VF.ShadeColorName, '|  ', '') "

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

            NewComboFillWithDs(ddlunit, ds, 0)
            If ddlunit.Items.Count > 0 Then
                ddlunit.SelectedIndex = 0
            End If

            NewComboFillWithDs(DDDescription, ds, 1)
        End If
    End Sub

    Private Sub DDDescription_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDDescription.SelectedIndexChanged
        Filllotno()
    End Sub

    Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddgodown.SelectedIndexChanged
        FillUnitItemDescription()
        Filllotno()
    End Sub
    Protected Sub Filllotno()
        If ddCompName.SelectedIndex <> -1 And ddgodown.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct Lotno,Lotno from Stock Where CompanyId=" & ddCompName.SelectedValue & " And Godownid=" & ddgodown.SelectedValue & " And Item_Finished_id=" & DDDescription.SelectedValue & " And Round(Qtyinhand,3)>0"
            NewComboFill(ddlotno, str)
            If ddlotno.Items.Count > 0 Then
                ddlotno.SelectedIndex = 0
                FillTagno()
            End If
            If DDTagNo.Items.Count > 0 Then
                DDTagNo.SelectedIndex = 0
                TagNoSelectedChanged()
            End If
            If DDBinNo.Items.Count > 0 Then
                DDBinNo.SelectedIndex = 0
                BinNoSelectedChanged()
                txtissqty.Focus()
            End If
        End If
    End Sub

    Private Sub DDLotNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddlotno.SelectedIndexChanged
        If ddlotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillTagno()
        End If
    End Sub
    Protected Sub FillTagno()
        If ddCompName.SelectedIndex <> -1 And ddgodown.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And ddlotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct TagNo,TagNo from Stock Where Item_Finished_id=" & DDDescription.SelectedValue & " and Godownid=" & ddgodown.SelectedValue & " and CompanyId=" & ddCompName.SelectedValue & " and Lotno='" & ddlotno.Text & "' and Round(Qtyinhand,3)>0"
            NewComboFill(DDTagNo, str)
        End If
    End Sub

    Private Sub DDTagNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTagNo.SelectedIndexChanged
        TagNoSelectedChanged()
    End Sub

    Private Sub TagNoSelectedChanged()
        If dditemname.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If DDBinNo.Visible = True Then
                FillBinNo()
            Else
                txtstockqty.Text = getstockQty(ddCompName.SelectedValue, ddgodown.SelectedValue, ddlotno.Text, DDDescription.SelectedValue)
            End If
        End If
    End Sub

    Protected Sub FillBinNo()
        If ddCompName.SelectedIndex <> -1 And ddgodown.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And ddlotno.SelectedIndex <> -1 And DDTagNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct BinNo,BinNo as BinNo1 from Stock Where Item_Finished_id=" & DDDescription.SelectedValue & " and Godownid=" & ddgodown.SelectedValue & " and CompanyId=" & ddCompName.SelectedValue & " and Lotno='" & ddlotno.Text & "' and TagNo='" & DDTagNo.Text & "' and Round(Qtyinhand,3)>0  order by BinNo"
            NewComboFill(DDBinNo, str)
        End If
    End Sub

    Private Sub DDbinno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDBinNo.SelectedIndexChanged
        BinNoSelectedChanged()
    End Sub

    Private Sub BinNoSelectedChanged()
        If dditemname.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            txtstockqty.Text = getstockQty(ddCompName.SelectedValue, ddgodown.SelectedValue, ddlotno.Text, DDDescription.SelectedValue, TagNo:=DDTagNo.Text, BinNo:=DDBinNo.Text)
        End If
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Validcombobox(ddCompName) = False Then Exit Sub
        If Validcombobox(DDDept) = False Then Exit Sub
        If Validcombobox(ddempname) = False Then Exit Sub
        If Validcombobox(ddCatagory) = False Then Exit Sub
        If Validcombobox(dditemname) = False Then Exit Sub
        If Validcombobox(DDDescription) = False Then Exit Sub
        If Validcombobox(ddlunit) = False Then Exit Sub
        If Validcombobox(ddgodown) = False Then Exit Sub
        If Validcombobox(ddlotno) = False Then Exit Sub
        If Validcombobox(DDTagNo) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        If Validtxtbox(txtissqty) = False Then Exit Sub


        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim param(32) As SqlParameter
            param(0) = New SqlParameter("@GATEOUTID", SqlDbType.Int)
            param(0).Direction = ParameterDirection.InputOutput
            param(0).Value = Val(GateOut)
            param(1) = New SqlParameter("ISSUENO", SqlDbType.VarChar, 50)
            param(1).Direction = ParameterDirection.InputOutput
            param(1).Value = txtchalanno.Text
            param(2) = New SqlParameter("@PARTYID", ddempname.SelectedValue)
            param(3) = New SqlParameter("@ISSUEDATE", txtdate.Text)
            param(4) = New SqlParameter("MASTERCOMPANYID", VarMasterCompanyID)

            param(5) = New SqlParameter("@GATEOUTDETAILID", txtdate.Text)
            param(5).Direction = ParameterDirection.InputOutput
            param(5).Value = 0
            param(6) = New SqlParameter("@FINISHEDID", DDDescription.SelectedValue)
            param(7) = New SqlParameter("@ISSUEQTY", txtissqty.Text)
            param(8) = New SqlParameter("@LotNo", ddlotno.Text)
            param(9) = New SqlParameter("@GODOWNID", ddgodown.SelectedValue)
            param(10) = New SqlParameter("@CategoryType", 1)
            param(11) = New SqlParameter("@Remark", txtremarks.Text)
            param(12) = New SqlParameter("@VarUserId", varuserid)
            param(13) = New SqlParameter("@CompanyID", ddCompName.SelectedValue)
            param(14) = New SqlParameter("@flagsize", 0)
            param(15) = New SqlParameter("@UnitId", ddlunit.SelectedValue)
            param(16) = New SqlParameter("@TagNo", DDTagNo.Text)
            param(17) = New SqlParameter("@Userid", varuserid)
            param(18) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            param(18).Direction = ParameterDirection.Output
            param(19) = New SqlParameter("@DeptId", DDDept.SelectedValue)
            param(20) = New SqlParameter("@BinNo", IIf(DDBinNo.Visible = False, "", DDBinNo.Text))
            param(21) = New SqlParameter("@EWayBillNo", TxtEWayBillNo.Text)
            param(22) = New SqlParameter("@BranchID", 0)
            param(23) = New SqlParameter("@GateOutType", 0)
            '1 for OrderWise 0 for GateOut form wise
            param(24) = New SqlParameter("@Rate", 0)
            param(25) = New SqlParameter("@VehicleNo", TxtVehicleNo.Text)
            param(26) = New SqlParameter("@DriverName", TxtDriverName.Text)
            param(27) = New SqlParameter("@GstType", IIf(ChkForGSTStateOutSide.Checked = True, 1, 0))
            param(28) = New SqlParameter("@OrderId", 0)
            param(29) = New SqlParameter("@ConeType", DDConeType.SelectedValue)
            param(30) = New SqlParameter("@NoofCone", IIf(TxtNoofCone.Text = "", "0", TxtNoofCone.Text))
            param(31) = New SqlParameter("@BellWeight", IIf(TxtBellWeight.Text = "", "0", TxtBellWeight.Text))

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "[PRO_GateOut]", param)
            GateOut = param(0).Value.ToString()
            Tran.Commit()
            If param(18).Value.ToString() <> "" Then
                MsgBox(param(18).Value.ToString())
            End If
            txtchalanno.Text = param(1).Value.ToString()
            txtissqty.Text = ""
            txtremarks.Text = ""
            txtstockqty.Text = ""
            TxtEWayBillNo.Text = ""
            TxtNoofCone.Text = ""
            TxtBellWeight.Text = ""
            FillGrid()
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub FillGrid()
        DG.Rows.Clear()
        Dim i As Integer
        Dim str As String = "select CATEGORY_NAME+' '+ITEM_NAME+' '+QualityName+' '+designName+' '+ColorName+' '+ShadeColorName+' '+ShapeName+' '+SizeFt +'   ' +isnull(u.unitname,'') Description," & _
        " GodownName,lotno,ISSUEQTY as qty,Remark,ITEM_FINISHED_ID, CATEGORY_ID,ITEM_ID,QualityId,ColorId,designId,SizeId,ShapeId,ShadecolorId,gd.GoDownID, " & _
        " GATEOUTDETAILID,gom.GATEOUTID ,CategoryType,Remark,ISSUENO,ISSUEDATE,ProductCode,gd.flagsize,gd.unitid,Gd.TagNo,gd.BinNo,isnull(gom.EWayBillNo,'') EWayBillNo " & _
        " From Gateoutdetail gd inner join GateOutMaster gom On gom.GATEOUTID=gd.GATEOUTID inner join V_finisheditemdetail vd On gd.FINISHEDID=vd.ITEM_FINISHED_ID " & _
        " Inner join GodownMaster gm ON gm.GoDownID=gd.GoDownID left join unit u on u.unitid=gd.unitid" & _
        " Where gom.GATEOUTID=" & GateOut & " order by GATEOUTDETAILID"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            DG.Rows.Add()
            DG.Item("description", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("description")
            DG.Item("GodownName", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GodownName")
            DG.Item("Lotno", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("lotno")
            DG.Item("TagNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
            DG.Item("qty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("qty")
            DG.Item("GATEOUTID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GATEOUTID")
            DG.Item("GATEOUTDETAILID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GATEOUTDETAILID")
        Next
        If (ds.Tables(0).Rows.Count > 0) Then
            TxtEWayBillNo.Text = ds.Tables(0).Rows(0)("EWayBillNo")
        End If
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = "Select BM.BranchName CompanyName, BM.BranchAddress CompAddr1, '' CompAddr2, '' CompAddr3, '' CompFax,BM.PhoneNo CompTel,e.EmpName,e.Address,e.PhoneNo,e.Mobile,e.Fax,gom.ISSUENO, gom.ISSUEDATE, " & _
                " Lotno, ISSUEQTY, god.Remark, god.CategoryType, gm.godownname,  " & _
                " CATEGORY_NAME+' '+ITEM_NAME+' '+QualityName+' '+designName+' '+ColorName+' '+ShadeColorName+' '+ShapeName+' '+ case When god.flagsize=0 then SizeFt else case when god.flagsize=1 then sizemtr else sizeinch end end Description, " & _
                " ITEM_FINISHED_ID, gm.GoDownID,U.unitname,god.TagNo, 1 TagNoWise,DP.DepartmentName,isnull(C.GSTNo,'') GSTIN,isnull(e.gstno,'') EMPGSTIN,isnull(gom.EWayBillNo,'') EWayBillNo, " & _
                " isnull(vd.hsncode,'') HSNCode,Isnull(VD.ItemCode,'') ItemCode, gom.VehicleNo, gom.DriverName, god.PurchaseRate, Round(god.ISSUEQTY * god.PurchaseRate, 2) PurchaseAmt, " & _
                " god.GstType, Round((god.ISSUEQTY * god.PurchaseRate) * CGST * 0.01, 2) CGstAmt, Round((god.ISSUEQTY * god.PurchaseRate) * SGST * 0.01, 2) SGstAmt, " & _
                " Round((god.ISSUEQTY * god.PurchaseRate) * IGST * 0.01, 2) IGstAmt " & _
                " FROM GateOutMaster gom(Nolock) " & _
                " JOIN BRANCHMASTER BM(Nolock) ON BM.ID = gom.BranchID " & _
                " INNER JOIN COMPANYINFO C(Nolock) ON c.CompanyId=gom.COMPANYID " & _
                " inner join empinfo e(Nolock) on e.empid=gom.partyid  " & _
                " inner join Gateoutdetail god(Nolock) On god.GATEOUTID=gom.GATEOUTID " & _
                " Inner join GodownMaster gm(Nolock) On gm.GoDownID=god.GoDownID  " & _
                " inner join V_finisheditemdetail vd(Nolock) On vd.item_finished_id=god.finishedid " & _
                " left join Unit U(Nolock) on god.unitid=u.unitid  " & _
                " left join Department DP(Nolock) on GOM.Deptid=DP.DepartmentId " & _
                " where gom.GATEOUTID = " & GateOut & " " & _
                " Select gom.GATEOUTID, VF.ITEM_NAME + ' ' + VF.QualityName + ' ' + VF.DESIGNNAME + ' ' + VF.COLORNAME + ' ' + VF.SHAPENAME + ' ' + " & _
                " CASE WHEN god.UnitID = 1 THEN VF.SIZEMTR Else Case WHEN god.unitID = 6 THEN VF.SizeInch Else VF.SIZEFT END End + ' ' + VF.ShadeColorName ITEMDESCRIPTION, " & _
                " U.UnitName, VF.HSNCode, Sum(IssueQty) IssueQty, Round(Sum(god.ISSUEQTY * god.PurchaseRate), 2) PurchaseAmt, " & _
                " god.GstType, Round(Sum((god.ISSUEQTY * god.PurchaseRate) * CGST * 0.01), 2) CGstAmt, Round(Sum((god.ISSUEQTY * god.PurchaseRate) * SGST * 0.01), 2) SGstAmt, " & _
                " Round(Sum((god.ISSUEQTY * god.PurchaseRate) * IGST * 0.01), 2) IGstAmt " & _
                " FROM GateOutMaster gom(Nolock) " & _
                " inner join Gateoutdetail god(Nolock) On god.GATEOUTID=gom.GATEOUTID " & _
                " inner join V_finisheditemdetail VF(Nolock) On VF.item_finished_id=god.finishedid " & _
                " join Unit U(Nolock) on god.unitid=u.unitid  " & _
                " where gom.GATEOUTID = " & GateOut & " " & _
                " Group By gom.GATEOUTID, VF.ITEM_NAME, VF.QualityName, VF.DESIGNNAME, VF.COLORNAME, VF.SHAPENAME, VF.SIZEMTR, VF.SizeInch, VF.SIZEFT, VF.ShadeColorName, " & _
                " god.UnitID, U.UnitName, VF.HSNCode, god.GstType"

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptGateOutTagWise.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptGateOut.xsd")
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
                param(0) = New SqlParameter("@Prtid", DG.Item("GATEOUTDETAILID", DG.CurrentRow.Index).Value)
                param(1) = New SqlParameter("@TableName", "Gateoutdetail")
                param(2) = New SqlParameter("@Count", DG.Rows.Count)
                param(3) = New SqlParameter("@FlagDeleteOrNot", SqlDbType.Int)
                param(3).Direction = ParameterDirection.Output
                param(4) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(4).Direction = ParameterDirection.Output
                param(5) = New SqlParameter("@userid", varuserid)
                param(6) = New SqlParameter("@mastercompanyid", VarMasterCompanyID)
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_UpdateStockGateOut", param)
                Tran.Commit()
                If param(4).Value.ToString() <> "" Then
                    MsgBox(param(4).Value.ToString())
                End If
                If DG.Rows.Count = 1 Then
                    GateOut = 0
                    txtchalanno.Text = ""
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
        txtchalanno.Text = ""
        GateOut = 0
        txtissqty.Text = ""
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

    Private Sub frmyarnopeningissue_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub ddempname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddempname.SelectedIndexChanged
        EmpSelectedChange()
    End Sub

    Private Sub EmpSelectedChange()
        GateOut = 0
        txtchalanno.Text = ""
        If ChKForEdit.Checked = True Then
            If ddCompName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                NewComboFill(DDGatePassNo, "Select GATEOUTID,cast(ISSUENO as varchar) +' / '+ cast(GATEOUTID as nvarchar),replace(convert(varchar(11),ISSUEDATE,106),' ','-') date " & _
                    " From GateOutMaster Where MasterCompanyID = " & VarMasterCompanyID & " And CompanyID = " & ddCompName.SelectedValue & " And deptid = " & DDDept.SelectedValue & " " & _
                    " And PARTYID = " & ddempname.SelectedValue & " order by Gateoutid")
            End If
        End If
    End Sub

    Private Sub ChKForEdit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChKForEdit.CheckedChanged
        txtchalanno.Text = ""
        txtdate.Text = DateTime.Now.ToString("dd-MMM-yyyy")
        LblGatePassNo.Visible = False
        DDGatePassNo.Visible = False
        If (ChKForEdit.Checked = True) Then
            LblGatePassNo.Visible = True
            DDGatePassNo.Visible = True
            EmpSelectedChange()
        End If
    End Sub

    Private Sub DDGatePassNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGatePassNo.SelectedIndexChanged
        TxtEWayBillNo.Text = ""
        If DDGatePassNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            GateOut = DDGatePassNo.SelectedValue
            Dim Str As String = "Select * From GateOutMaster Where MasterCompanyID = " & VarMasterCompanyID & " And GATEOUTID = " & DDGatePassNo.SelectedValue & ""
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, Str)
            If ds.Tables(0).Rows.Count > 0 Then
                txtchalanno.Text = ds.Tables(0).Rows(0)("ISSUENO")
            End If
            FillGrid()
        End If
    End Sub
End Class