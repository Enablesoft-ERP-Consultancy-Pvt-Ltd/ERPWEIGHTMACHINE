Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class FrmStockTransfer
    Dim VarTransferID As Integer = 0
    Dim VarDetailID As Integer = 0

    Private Sub FrmStockTransfer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select Distinct CI.CompanyId,Companyname from Companyinfo CI,Company_Authentication CA Where CA.CompanyId=CI.CompanyId And CA.UserId=" & varuserid & " And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By Companyname" & _
                          " Select distinct GM.GodownId,GM.GodownName From GodownMaster GM JOIN Godown_Authentication GA ON GM.GodownId=GA.GodownId  Where GA.UserId=" & varuserid & " and GA.MasterCompanyId=" & VarMasterCompanyID & " Order by GodownName" & _
                          " SELECT ICM.CATEGORY_ID, ICM.CATEGORY_NAME FROM CategorySeparate CS " & _
                          " JOIN ITEM_CATEGORY_MASTER ICM ON CS.Categoryid = ICM.CATEGORY_ID join UserRights_Category UC on UC.CategoryId=ICM.Category_Id And UC.UserId=" & varuserid & "" & _
                          " WHERE ICM.MasterCompanyId = " & VarMasterCompanyID & " And CS.id = 1 Order By ICM.CATEGORY_NAME " & _
                          " Select distinct GM.GodownId,GM.GodownName From GodownMaster GM JOIN Godown_Authentication GA ON GM.GodownId=GA.GodownId  Where GA.UserId=" & varuserid & " and GA.MasterCompanyId=" & VarMasterCompanyID & " Order by GodownName"

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(DDFCompName, ds, 0)
        If DDFCompName.Items.Count > 0 Then
            DDFCompName.SelectedIndex = 0
        End If
        NewComboFillWithDs(DDFGodown, ds, 1)
        NewComboFillWithDs(DDTGodown, ds, 3)
        NewComboFillWithDs(ddCatagory, ds, 2)
        If ddCatagory.Items.Count > 0 Then
            ddCatagory.SelectedIndex = 0
        End If

        txtdate.Text = DateTime.Now.ToString("dd-MMM-yyyy")
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDFBinNo.Visible = True
        End If
        DDFGodown.Focus()
    End Sub

    Private Sub DDFCompName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDFCompName.SelectedIndexChanged
        VarTransferID = 0
        VarDetailID = 0
        TxtChallanNo.Text = ""
        If DDFCompName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            CompanySelectedIndex()
        End If

        DDTCompName_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub CompanySelectedIndex()
        Dim str As String = "Select Distinct CI.CompanyId,Companyname from Companyinfo CI,Company_Authentication CA " & _
            " Where CA.CompanyId=CI.CompanyId And CA.UserId=" & varuserid & " And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By Companyname"
        NewComboFill(DDTCompName, str)
        If DDTCompName.Items.Count > 0 Then
            DDTCompName.SelectedIndex = 0
        End If
    End Sub

    Private Sub DDTCompName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTCompName.SelectedIndexChanged
        TxtChallanNo.Text = ""
        If DDFCompName.SelectedIndex <> -1 And DDTCompName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct Top 100 TransferId,ChallanNo+' / ' + Replace(convert(varchar(11),TransferDate,106),' ','-') As ChallanNo " & _
                " From Stock_TransferMaster Where FCompanyId=" & DDFCompName.SelectedValue & " And TCompanyId=" & DDTCompName.SelectedValue & "  Order by TransferId Desc "
            NewComboFill(DDChallanNo, str)
        End If
    End Sub

    Private Sub DDChallanNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDChallanNo.SelectedIndexChanged
        If DDChallanNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            VarTransferID = DDChallanNo.SelectedValue
            Dim str As String = "Select ChallanNo,Replace(convert(varchar(11),TransferDate,106),'  ','-') As TransferDate " & _
                " From Stock_TransferMaster Where TransferId=" & DDChallanNo.SelectedValue & ""
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

            If (ds.Tables(0).Rows.Count > 0) Then
                TxtChallanNo.Text = ds.Tables(0).Rows(0)("ChallanNo")
                txtdate.Text = ds.Tables(0).Rows(0)("TransferDate")
            Else
                TxtChallanNo.Text = ""
            End If
            FillGrid()
        End If
    End Sub


    Protected Sub FillItemName()
        If ddCatagory.SelectedIndex <> -1 And DDFGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct im.ITEM_ID, im.ITEM_NAME " & _
            " FROM ITEM_MASTER im " & _
            " Join V_FinishedItemDetail v ON v.ITEM_ID = im.ITEM_ID " & _
            " Join Stock s ON s.ITEM_FINISHED_ID = v.ITEM_FINISHED_ID And Round(s.Qtyinhand, 3) > 0 And s.GodownID = " & DDFGodown.SelectedValue & " " & _
            " Where v.CATEGORY_ID = " & ddCatagory.SelectedValue & " And im.MasterCompanyid = " & VarMasterCompanyID & " order by im.ITEM_NAME"
            NewComboFill(dditemname, str)
        End If
    End Sub

    Private Sub ddCatagory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddCatagory.SelectedIndexChanged
        FillItemName()
    End Sub

    Private Sub dditemname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dditemname.SelectedIndexChanged
        FillUnitItemDescription()
    End Sub
    'Protected Sub FillGodown()
    '    If ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And DDFCompName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
    '        Dim str As String = "Select Distinct GM.GodownID, GM.GodownName " & _
    '            " From GodownMaster GM  " & _
    '            " JOIN Godown_Authentication GA ON GM.GodownId=GA.GodownId And GA.UserId = " & varuserid & " and GA.MasterCompanyId = " & VarMasterCompanyID & " " & _
    '            " JOIN Stock S ON GM.GodownID=S.GodownID  " & _
    '            " JOIN V_FinishedItemDetail VF ON VF.ITEM_FINISHED_ID = S.ITEM_FINISHED_ID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ITEM_ID = " & dditemname.SelectedValue & " " & _
    '            " Where S.CompanyId = " & DDFCompName.SelectedValue & " And GM.MasterCompanyId = " & VarMasterCompanyID & " And Round(S.Qtyinhand, 3) > 0 " & _
    '            " Order By GM.GodownName "
    '        NewComboFill(DDFGodown, str)
    '    End If
    'End Sub

    Protected Sub FillUnitItemDescription()
        If ddCatagory.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And DDFGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct U.UnitId,U.UnitName from Unit U inner join UNIT_TYPE_MASTER UT on U.UnitTypeID=UT.UnitTypeID inner join Item_master IM on Im.UnitTypeID=UT.UnitTypeID and Im.item_id=" & dditemname.SelectedValue & " order by unitname" & _
            " Select Distinct VF.ITEM_FINISHED_ID, Replace(VF.QualityName + ' | ' + VF.DesignName + ' | ' + VF.ColorName + ' | ' + VF.ShapeName + ' | ' + VF.SizeFt + ' | ' + VF.ShadeColorName, '|  ', '') ItemDescription " & _
            " FROM V_FinishedItemDetail VF" & _
            " JOIN Stock S ON S.ITEM_FINISHED_ID = VF.ITEM_FINISHED_ID And S.Godownid = " & DDFGodown.SelectedValue & " " & _
            " Where VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ITEM_ID = " & dditemname.SelectedValue & " And Round(S.Qtyinhand, 3) > 0 " & _
            " Order By Replace(VF.QualityName + ' | ' + VF.DesignName + ' | ' + VF.ColorName + ' | ' + VF.ShapeName + ' | ' + VF.SizeFt + ' | ' + VF.ShadeColorName, '|  ', '') "

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

            NewComboFillWithDs(DDunit, ds, 0)
            If DDunit.Items.Count > 0 Then
                DDunit.SelectedIndex = 0
            End If
            NewComboFillWithDs(DDDescription, ds, 1)
        End If
    End Sub

    Private Sub DDDescription_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDDescription.SelectedIndexChanged
        If (DDDescription.SelectedIndex <> -1 And Varcombovalue <> 0) Then
            DescriptionSelectedChanged()
        End If
    End Sub

    Protected Sub DescriptionSelectedChanged()
        Dim str As String = ""
        If (VarBINNOWISE = 1) Then
            str = "select Distinct BinNo,BinNo From Stock  Where Companyid=" & DDFCompName.SelectedValue & " And Item_Finished_Id=" & DDDescription.SelectedValue & " And Godownid=" & DDFGodown.SelectedValue & " and Round(Qtyinhand,3)>0"
            NewComboFill(DDFBinNo, str)
            If (DDFBinNo.Items.Count = 1) Then
                DDFBinNo.SelectedIndex = 0
                FilllotNo()
            End If

        Else
            str = "select Distinct LotNo,LotNo From Stock  Where Companyid=" & DDFCompName.SelectedValue & " And Item_Finished_Id=" & DDDescription.SelectedValue & " And Godownid=" & DDFGodown.SelectedValue & " and Round(Qtyinhand,3)>0" & _
               " Select distinct GM.GodownId,GM.GodownName From GodownMaster GM JOIN Godown_Authentication GA ON GM.GodownId=GA.GodownId  Where GA.UserId=" & varuserid & " and GA.MasterCompanyId=" & VarMasterCompanyID & " Order by GodownName"

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            NewComboFillWithDs(ddlotno, ds, 0)
            NewComboFillWithDs(DDTGodown, ds, 1)
        End If
    End Sub

    Private Sub DDFBinNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDFBinNo.SelectedIndexChanged
        If (DDFBinNo.SelectedIndex <> -1 And Varcombovalue <> 0) Then
            FilllotNo()
        End If
    End Sub

    Protected Sub FilllotNo()
        If (DDFCompName.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And DDFGodown.SelectedIndex <> -1 And Varcombovalue <> 0) Then
            Dim str As String = "select Distinct LotNo,LotNo From Stock Where Companyid=" & DDFCompName.SelectedValue & " And Item_Finished_Id=" & DDDescription.SelectedValue & " And Godownid=" & DDFGodown.SelectedValue & " and Round(Qtyinhand,3)>0"
            If VarBINNOWISE = 1 Then
                str = str & " and BinNo = '" & DDFBinNo.Text & "'"
            End If
            NewComboFill(ddlotno, str)
            If (ddlotno.Items.Count = 1) Then
                ddlotno.SelectedIndex = 0
                FillTagno()
            End If
        End If
    End Sub
    Protected Sub FillChallan()
        Dim str As String = "select Distinct Top 100 SM.TransferId,SM.ChallanNo+' / ' + Replace(convert(varchar(11),SM.TransferDate,106),' ','-') As ChallanNo  from Stock_TransferMaster SM inner join Stock_TransferDetail SD on SM.TransferId=SD.TransferId Where SM.FCompanyId=" & DDFCompName.SelectedValue & " And SM.TCompanyId=" & DDTCompName.SelectedValue & ""
        If (DDTGodown.SelectedIndex > 0) Then
            str = str & " And SD.TGodownId = " & DDTGodown.SelectedValue
        End If
        str = str & " Order by TransferId Desc"
        NewComboFill(DDChallanNo, str)
    End Sub

    'Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDFGodown.SelectedIndexChanged
    '    FillUnitItemDescription()
    '    Filllotno()
    'End Sub

    Private Sub DDLotNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddlotno.SelectedIndexChanged
        If ddlotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillTagno()
        End If
    End Sub

    Protected Sub FillTagno()
        If DDFCompName.SelectedIndex <> -1 And DDFGodown.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And ddlotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct TagNo,TagNo as TagNo1 From Stock " & _
                " Where Companyid=" & DDFCompName.SelectedValue & " And Item_Finished_Id=" & DDDescription.SelectedValue & " And Godownid=" & DDFGodown.SelectedValue & " And " & _
                " LotNo='" & ddlotno.Text & "' and Round(Qtyinhand,3)>0 "
            If (VarBINNOWISE = 1) Then
                str = str & " And BinNo = '" + DDFBinNo.Text + "'"
            End If
            str = str & " Order By TagNo"
            NewComboFill(DDTagNo, str)
            If (DDTagNo.Items.Count = 1) Then
                DDTagNo.SelectedIndex = 0
                TagNoSelectedChanged()
            End If
        End If
    End Sub

    Private Sub DDTagNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTagNo.SelectedIndexChanged
        TagNoSelectedChanged()
    End Sub

    Private Sub TagNoSelectedChanged()
        txtstock.Text = 0
        If DDFCompName.SelectedIndex <> -1 And DDFGodown.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And ddlotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            txtstock.Text = getstockQty(DDFCompName.SelectedValue, DDFGodown.SelectedValue, ddlotno.Text, DDDescription.SelectedValue, TagNo:=DDTagNo.Text, BinNo:=DDFBinNo.Text)
        End If
    End Sub

    Protected Sub FillBinNo()
        If DDFCompName.SelectedIndex <> -1 And DDFGodown.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And ddlotno.SelectedIndex <> -1 And DDTagNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Distinct BinNo,BinNo as BinNo1 from Stock Where Item_Finished_id=" & DDDescription.SelectedValue & " and Godownid=" & DDFGodown.SelectedValue & " and CompanyId=" & DDFCompName.SelectedValue & " and Lotno='" & ddlotno.Text & "' and TagNo='" & DDTagNo.Text & "' and Round(Qtyinhand,3)>0  order by BinNo"
            NewComboFill(DDFBinNo, str)
        End If
    End Sub

    Private Sub DDbinno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDFBinNo.SelectedIndexChanged
        BinNoSelectedChanged()
    End Sub

    Private Sub BinNoSelectedChanged()
        If dditemname.SelectedIndex <> -1 And DDDescription.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            txtstock.Text = getstockQty(DDFCompName.SelectedValue, DDFGodown.SelectedValue, ddlotno.Text, DDDescription.SelectedValue, TagNo:=DDTagNo.Text, BinNo:=DDFBinNo.Text)
        End If
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Validcombobox(DDFCompName) = False Then Exit Sub
        If Validcombobox(DDTCompName) = False Then Exit Sub
        If Validcombobox(ddCatagory) = False Then Exit Sub
        If Validcombobox(dditemname) = False Then Exit Sub
        If Validcombobox(DDDescription) = False Then Exit Sub
        If Validcombobox(DDunit) = False Then Exit Sub
        If Validcombobox(DDFGodown) = False Then Exit Sub
        If Validcombobox(DDTGodown) = False Then Exit Sub
        If Validcombobox(ddlotno) = False Then Exit Sub
        If Validcombobox(DDTagNo) = False Then Exit Sub
        If DDFBinNo.Visible = True Then
            If Validcombobox(DDFBinNo) = False Then Exit Sub
            If Validcombobox(DDTBinNo) = False Then Exit Sub
        End If

        If Validtxtbox(txtissqty) = False Then Exit Sub


        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim param(22) As SqlParameter

            param(0) = New SqlParameter("@Transferid", SqlDbType.Int)
            param(0).Direction = ParameterDirection.InputOutput
            param(0).Value = Val(VarTransferID)
            param(1) = New SqlParameter("FCompanyId", DDFCompName.SelectedValue)
            param(2) = New SqlParameter("@TCompanyId", DDTCompName.SelectedValue)
            param(3) = New SqlParameter("@FGodownid", DDFGodown.SelectedValue)
            param(4) = New SqlParameter("TGodownid", DDTGodown.SelectedValue)
            param(5) = New SqlParameter("@FLotNo", ddlotno.Text)

            param(6) = New SqlParameter("@Item_Finishedid", DDDescription.SelectedValue)
            param(7) = New SqlParameter("@TransQty", txtissqty.Text)
            param(8) = New SqlParameter("@TransferDate", txtdate.Text)
            param(9) = New SqlParameter("@DetailId", SqlDbType.Int)
            param(9).Direction = ParameterDirection.Output
            param(10) = New SqlParameter("@ChallanNo", SqlDbType.VarChar, 100)
            param(10).Direction = ParameterDirection.InputOutput
            param(10).Value = TxtChallanNo.Text
            param(11) = New SqlParameter("@Msgflag", SqlDbType.NVarChar, 100)
            param(11).Direction = ParameterDirection.Output
            param(12) = New SqlParameter("@MasterCompanyId", VarMasterCompanyID)
            param(13) = New SqlParameter("@UnitId", DDunit.SelectedValue)
            param(14) = New SqlParameter("@FTagNo", DDTagNo.Text)
            param(15) = New SqlParameter("@Userid", varuserid)
            param(16) = New SqlParameter("@FBinNO", IIf(DDFBinNo.Visible = False, "", DDFBinNo.Text))
            param(17) = New SqlParameter("@TBinNo", IIf(DDTBinNo.Visible = False, "", DDTBinNo.Text))
            param(18) = New SqlParameter("@EWayBillNo", TxtEWayBillNo.Text)
            param(19) = New SqlParameter("@Remarks", TxtRemarks.Text)
            param(20) = New SqlParameter("@OrderID", 0)
            param(21) = New SqlParameter("@BellWt", IIf(TxtBellWt.Text = "", "0", TxtBellWt.Text))

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "[Pro_StockTransfer]", param)
            If param(11).Value <> "" Then
                MsgBox(param(11).Value.ToString())
                Tran.Rollback()
                Return
            End If
            VarTransferID = param(0).Value.ToString()
            VarDetailID = param(9).Value.ToString()

            TxtChallanNo.Text = param(10).Value
            Tran.Commit()
            MsgBox("Data Saved successfully....")

            txtissqty.Text = ""
            txtstock.Text = 0
            TxtBellWt.Text = 0
            DDFGodown.SelectedIndex = 0
            DDTGodown.SelectedIndex = 0
            FillGrid()
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub FillGrid()
        DG.Rows.Clear()
        Dim i As Integer
        Dim str As String = "select SM.TransferId,DetailId TransferDetailID,FGodownid,TGodownid,FLotNo,TLotNo,Item_Finishedid," & _
                        " CATEGORY_NAME,ITEM_NAME,QualityName+' '+designName+' '+ColorName+' '+ShapeName+' '+SizeFt+' '+ShadeColorName+'   '+U.unitname As DESCRIPTION," & _
                        " Qty,FGM.GodownName as FromGodown,TGM.GodownName as ToGodown,FTagNo,isnull(SD.Remarks,'') as Remarks,isnull(SM.EwayBillNo,'') as EWayBillNo " & _
                        " from  Stock_TransferMaster SM inner join Stock_TransferDetail SD on SM.TransferId=SD.TransferId" & _
                        " inner join V_FinishedItemDetail vf on vf.ITEM_FINISHED_ID=SD.Item_Finishedid" & _
                        " inner join GodownMaster FGM on FGM.GoDownID=sd.FGodownId " & _
                        " inner join GodownMaster TGM on TGM.GoDownID=sd.TGodownId" & _
                        " left join unit u on u.unitid=sd.unitid" & _
                        " Where SM.Transferid = " & VarTransferID & ""
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            DG.Rows.Add()
            DG.Item("Item_Name", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ITEM_NAME")
            DG.Item("DESCRIPTION", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("DESCRIPTION")
            DG.Item("FLotNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("FLotNo")
            DG.Item("FTagNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("FTagNo")
            DG.Item("FTagNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("FTagNo")
            DG.Item("FromGodown", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("FromGodown")
            DG.Item("ToGodown", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ToGodown")
            DG.Item("Qty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
            DG.Item("Item_Finishedid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_Finishedid")
            DG.Item("FGodownId", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("FGodownId")
            DG.Item("TGodownid", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TGodownid")
            DG.Item("FLotNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("FLotNo")
            DG.Item("TransferId", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TransferId")
            DG.Item("TransferDetailID", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TransferDetailID")
        Next
        If (ds.Tables(0).Rows.Count > 0) Then
            TxtEWayBillNo.Text = ds.Tables(0).Rows(0)("EWayBillNo")
        End If
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = "select * from V_StockTransfer Where Transferid=" & VarTransferID & " "
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\RptstockTransfernew.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\RptstockTransfer.xsd")
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
                Dim param(3) As SqlParameter
                param(0) = New SqlParameter("@DetailId", DG.Item("TransferDetailID", DG.CurrentRow.Index).Value)
                param(1) = New SqlParameter("@TransferId", DG.Item("TransferId", DG.CurrentRow.Index).Value)
                param(2) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(2).Direction = ParameterDirection.Output
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "Pro_DeleteStock_Transfer", param)
                Tran.Commit()
                If param(2).Value.ToString() <> "" Then
                    MsgBox(param(2).Value.ToString())
                Else
                    MsgBox("Data Deleted successfully......")
                End If
                FillGrid()
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        End If
    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        DDTCompName.SelectedIndex = -1
        DDChallanNo.SelectedIndex = -1
        TxtChallanNo.Text = ""
        VarTransferID = 0
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

    Private Sub frmyarnopeningissue_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs)
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub ChKForEdit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChKForEdit.CheckedChanged
        VarTransferID = 0
        If (ChKForEdit.Checked = True) Then
            TxtChallanNo.Text = ""
            FillChallan()
            DDChallanNo.Visible = True
            Label23.Visible = True
        Else
            DDChallanNo.Visible = False
            Label23.Visible = False
        End If
    End Sub


    Private Sub DDTGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTGodown.SelectedIndexChanged
        If DDTGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If VarBINNOWISE = 1 Then
                If VarCHECKBINCONDITION = "1" Then

                    Module1.FillBinNO(DDTBinNo, DDTGodown.SelectedValue, DDDescription.SelectedValue, New_Edit:=0)
                Else
                    Dim str As String = "select BINNO,BINNO From BinMaster where GODOWNID=" & DDTGodown.SelectedValue & " order by BINID"
                    NewComboFill(DDTBinNo, str)
                End If
            End If

            If (ChKForEdit.Checked = True) Then
                FillChallan()
            End If
        End If
    End Sub

    Private Sub DDFGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDFGodown.SelectedIndexChanged
        If DDFGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            FillItemName()
        End If
    End Sub
End Class