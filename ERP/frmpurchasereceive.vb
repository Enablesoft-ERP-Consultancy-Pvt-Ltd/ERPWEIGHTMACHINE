Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Imports System.Drawing.Printing

Public Class frmpurchasereceive
    Dim Gridstatus As Integer = 0
    Dim PurchaseReceiveId As Integer = 0
    Dim PurchaseReceiveDetailId As Integer = 0
    Dim hnprid As Integer = 0
    Dim hnqty As Double = 0
    Dim TxtReceiveNo As String = ""
    Public Printside As Integer
    Public prn As String = ""
    Private Sub frmpurchasereceive_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())

        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If

        NewComboFill(DDCompanyName, "select Distinct CI.CompanyId,Companyname from Companyinfo CI,Company_Authentication CA Where CI.CompanyId=CA.CompanyId And CA.USERID=" & varuserid & " And CI.MasterCompanyId=" & VarMasterCompanyID & " Order by CompanyId")
        If DDCompanyName.Items.Count > 0 Then
            DDCompanyName.SelectedValue = VarCompanyID
            DDCompanyName.Enabled = False
        End If
        NewComboFill(DDPartyName, "select Distinct EI.EmpId,EI.EmpName from EmpInfo EI,PurchaseIndentIssue PII Where EI.Empid=PII.Partyid And EI.MasterCompanyId=" & VarMasterCompanyID & " order by ei.empname")
        If varcanedit = "0" Then
            ChkEditOrder.Enabled = False
        End If
        If VarBINNOWISE = "1" Then
            lblbinno.Visible = True
            DDBinno.Visible = True
        End If

        If VarPurchaseReceiveAutogenLotno = "1" Then
            lblcomplotno.Visible = True
            txtcomplotno.Visible = True
            chkoldlotno.Visible = True
        End If
        If (VarMasterCompanyID = 16 Or VarMasterCompanyID = 28) Then
            TxtMoisture.Visible = True
            LblMoisture.Visible = True
        End If
    End Sub
    Protected Sub DDPartyName_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If DDCompanyName.SelectedIndex <> -1 And DDPartyName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If ChkEditOrder.Checked = False Then
                fill_order()
            Else
                Dim ChallanNo As String = String.Empty
                Select Case VarMasterCompanyID
                    Case "9"
                        ChallanNo = "BillNo"
                    Case Else
                        ChallanNo = "receiveno+' / '+BillNo"
                End Select

                NewComboFill(ddlrecchalanno, "select distinct PurchaseReceiveId," & ChallanNo & " as challanNo from PurchaseReceiveMaster  where partyid=" & DDPartyName.SelectedValue & " And CompanyId=" & DDCompanyName.SelectedValue & " And MasterCompanyId=" & VarMasterCompanyID & "")
                fill_order()
            End If
        End If
    End Sub

    Private Sub fill_order()
        Dim Postatus As String = String.Empty
        If ChkEditOrder.Checked = True Then
            Postatus = "'Complete'" & "," & "'Pending'"
        Else
            Postatus = "'Pending'"
        End If

        Dim Ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, "Select PNM.PROCESS_NAME_ID From PROCESS_NAME_MASTER PNM,Process_UserType PUT,UserType UT, " & _
            "NewUserDetail NUD Where PNM.PROCESS_NAME_ID=PUT.PRocessID And PUT.ID=UT.ID And ApprovalFlag=1 and UT.ID=NUD.UserType And PROCESS_NAME_ID=9 And PNM.MasterCompanyId=" & VarMasterCompanyID & "")
        If Ds.Tables(0).Rows.Count > 0 Then
            NewComboFill(DDChallanNo, "Select PII.PIndentIssueId,ChallanNo from PurchaseIndentIssue PII,Purchase_Approval PA " & _
                "Where PII.PIndentIssueId=PA.PIndentIssueId And PII.Status in(" & Postatus & ") And PII.PartyId=" & DDPartyName.SelectedValue & " And PII.CompanyId=" & DDCompanyName.SelectedValue & "  And PII.MasterCompanyId=" & VarMasterCompanyID & "  Order By PII.PIndentIssueId")
        Else

            Dim str As String = "Select PII.PIndentIssueId,case When isnull(OM.LocalOrder,'')='' Then PII.ChallanNo Else OM.LocalOrder +' | ' + PII.ChallanNo End from PurchaseIndentIssue PII left outer Join ordermaster OM on PII.orderid=OM.orderid " & _
                                "where PII.Status in(" & Postatus & ") And PII.PartyId=" & DDPartyName.SelectedValue & " And PII.CompanyId=" & DDCompanyName.SelectedValue & " And PII.MasterCompanyId=" & VarMasterCompanyID & "  order by  PII.PindentIssueId "
            NewComboFill(DDChallanNo, str)
        End If

        DDChallanNo.Focus()
    End Sub

    Private Sub DDChallanNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDChallanNo.SelectedIndexChanged
        If DDCompanyName.SelectedIndex <> -1 And DDPartyName.SelectedIndex <> -1 And DDChallanNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            Dim ChallanNo As String = String.Empty
            Select Case VarMasterCompanyID
                Case "9"
                    ChallanNo = "BillNo"
                Case Else
                    ChallanNo = "receiveno+' / '+BillNo"
            End Select

            NewComboFill(ddlrecchalanno, "select distinct prm.PurchaseReceiveId," & ChallanNo & " as ChallanNo from PurchaseReceiveMaster prm left outer join PurchaseReceiveDetail prd  on prd.purchasereceiveid=prm.purchasereceiveid where pindentissueid=" & DDChallanNo.SelectedValue & " and prm.CompanyId=" & DDCompanyName.SelectedValue & " and partyid=" & DDPartyName.SelectedValue & " And prm.MasterCompanyId=" & VarMasterCompanyID & "")
            fill_grid()
            NewComboFill(DDCategory, "select distinct ICM.Category_Id,ICM.Category_Name from PurchaseIndentIssueTran PIT inner join Item_Parameter_Master IPM " & _
                                     "on PIT.FinishedId=IPM.Item_Finished_Id inner join Item_Master IM on IPM.Item_Id=IM.Item_Id inner join Item_Category_Master ICM " & _
                                     "on ICM.Category_Id=IM.Category_Id inner join UserRights_Category UC on(icm.Category_Id=UC.CategoryId " & _
                                     "And UC.UserId=" & varuserid & ") where PIT.PIndentIssueId=" & DDChallanNo.SelectedValue & " And IPM.MasterCompanyId=" & VarMasterCompanyID & "")
            TextItemCode.Enabled = True
            ddlrecchalanno.Focus()
            Fill_porder()
            Dim Ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, " Select OrderID From PurchaseIndentIssueTran Where IsNull(OrderID, 0) > 0 And PindentIssueid = " & DDChallanNo.SelectedValue)
            If (Ds.Tables(0).Rows.Count > 0) Then
                DDCustomerOrderNo.Visible = True
                LblCustomerOrderNo.Visible = True
            Else
                DDCustomerOrderNo.Visible = False
                LblCustomerOrderNo.Visible = False
            End If
        End If
    End Sub
    Private Sub Fill_porder()
        Dim ds As DataSet = Nothing
        Dim i As Integer
        DGporder.Rows.Clear()
        Try
            If DDChallanNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                Dim strsql As String = "select pist.orderid,Case When IsNull(OM.LocalOrder, '') = '' Then '' Else IsNull(OM.LocalOrder, '') + ' / ' + OM.CustomerOrderNo + '  ' End + " & _
                                " Category_Name + '  ' + VF.ITEM_NAME +'  ' + QualityName + '  ' + DesignName + '  ' + ColorName + '  ' + ShadeColorName + '  ' + ShapeName + '  ' + case when flagsize = 0 then VF.SizeFt when flagsize = 1 then VF.SizeMtr else VF.SizeInch end " & _
                                " Description,sum(quantity) qty,VF.Item_Finished_Id as finishedid,Qualityid,Colorid,designid,shapeid,shadecolorid,category_id,vf.item_id,sizeid,ISNULL([dbo].F_PurchaseReceive(Finishedid,pist.Pindentissuetranid),0) AS RECQTY,pist.Lotno " & _
                                " From PurchaseIndentIssue pis " & _
                                " inner join PurchaseIndentIssueTran pist on pis.pindentissueid=pist.pindentissueid " & _
                                " inner join V_FinishedItemDetail VF ON pist.finishedid=vf.Item_Finished_Id " & _
                                " left join OrderMaster OM ON OM.OrderID = pist.OrderID " & _
                                " Where pis.pindentissueid=" & DDChallanNo.SelectedValue & "  And pis.MasterCompanyId=" & VarMasterCompanyID & " " & _
                                " Group by OM.LocalOrder, OM.CustomerOrderNo, Category_Name, VF.ITEM_NAME, QualityName, DesignName, ColorName, ShadeColorName, " & _
                                " ShapeName,vf.Item_Finished_Id,Qualityid,Colorid,designid,shapeid,shadecolorid,category_id," & _
                                " vf.item_id,sizeid,Finishedid,pist.PindentIssueid,pist.Pindentissuetranid,pist.orderid," & _
                                " UnitId,Sizemtr,Sizeft,Sizeinch,flagsize,pist.Lotno " & _
                                " Having isnull(sum(quantity),0)>ISNULL([dbo].F_PurchaseReceive(Finishedid,pist.Pindentissuetranid),0) "
                ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        DGporder.Rows.Add()
                        DGporder.Item("Description", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
                        DGporder.Item("Qty", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
                        DGporder.Item("Recqty", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Recqty")
                        DGporder.Item("Balance", DGporder.Rows.Count - 1).Value = getgiven(ds.Tables(0).Rows(i)("Qty"), ds.Tables(0).Rows(i)("Recqty"))
                        DGporder.Item("lblfinishedid", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("finishedid")
                        DGporder.Item("lblcategoryid", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("category_id")
                        DGporder.Item("lblItem_id", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("item_id")
                        DGporder.Item("lblQualityId", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qualityid")
                        DGporder.Item("lblshadecolorid", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("shadecolorid")
                        DGporder.Item("lblqty", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
                        DGporder.Item("lblrecqty", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("recqty")
                        DGporder.Item("lblorderid", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("orderid")
                        DGporder.Item("lbllotno", DGporder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")

                    Next


                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
    Protected Sub fill_grid()
        Dim ds As DataSet = Nothing
        DGPurchaseReceiveDetail.Rows.Clear()
        Dim i As Integer
        Try
            Dim strsql As String = ""
            If ChkEditOrder.Checked = True Then
                If ddlrecchalanno.SelectedIndex <> -1 And Varcombovalue <> 0 Then


                    strsql = "select PRD.PurchaseReceiveDetailId,Category_Name+'/'+Item_Name+'/'+isnull(QualityName,'')+'/'+isnull(DesignName,'')+'/'+isnull(ColorName,'')+'/'+isnull(ShadeColorName,'')+'/'+ isnull(ShapeName,'')+'/'+case when PIT.flagSize=1 then isnull(SizeMtr,'') else case When PIT.flagSize=0 Then isnull(SizeFt,'')  Else isnull(sizeinch,'') End " & _
                             "end as ItemDescription,PII.ChallanNo,GodownName,QTY,UnitName ,isnull(QualityName,'') as item,prd.lotno as lotno,ISNULL(V.ReturnQty,0) as qtyreturn,(prd.qty*prd.rate) as amount,prd.vat,prd.cst " & _
                             ",prd.NetAmount,PRD.Penalty,PRD.remark,prm.MRemark from  PurchaseReceiveMaster prm left outer join " & _
                             "PurchaseReceiveDetail PRD on prd.purchasereceiveid=prm.purchasereceiveid inner join PurchaseIndentIssue PII on PII.PIndentIssueId=PRD.PIndentIssueId Inner Join PurchaseIndentIssueTran PIT on Pii.PindentIssueId=PIT.PindentIssueId And PIT.PindentIssueTranid=PRD.PindentIssueTranId Left Outer join " & _
                             "GodownMaster GM on PRD.GodownId=GM.GodownId inner join unit on unit.UnitId=PRD.UnitId Inner join " & _
                             "V_FinishedItemDetail FID on FID.Item_Finished_Id=PRD.FinishedId LEFT OUTER JOIN V_PurchaseReturnDetail V ON prd.purchasereceiveDetailid=v.purchasereceiveDetailid " & _
                             "Where prm.PurchaseReceiveId=" & ddlrecchalanno.SelectedValue & " And prm.MasterCompanyId=" & VarMasterCompanyID & ""

                End If
            Else
                strsql = "select PurchaseReceiveDetailId,Category_Name+'/'+Item_Name+'/'+isnull(QualityName,'')+'/'+isnull(DesignName,'')+'/'+isnull(ColorName,'')+'/'+isnull(ShadeColorName,'')+'/'+ isnull(ShapeName,'')+'/'+case when PIT.flagSize=1 then isnull(SizeMtr,'') else case When PIT.FlagSize=0 Then isnull(SizeFt,'') Else isnull(sizeinch,'') end end as ItemDescription,ChallanNo,GodownName,QTY,UnitName,isnull(QualityName,'') as item,prd.lotno as lotno,prd.qtyreturn as qtyreturn ,(prd.qty*prd.rate) as amount,prd.vat,prd.cst,prd.NetAmount,PRD.Penalty,PRD.remark,prm.Mremark " & _
                         "from  PurchaseReceiveMaster prm Inner  join  PurchaseReceiveDetail PRD on prd.purchasereceiveid=prm.purchasereceiveid inner join PurchaseIndentIssue PII on " & _
                         "PII.PIndentIssueId=PRD.PIndentIssueId inner Join purchaseIndentIssueTran PIT on PII.PindentIssueId=PIT.PindentIssueId And PRD.PIndentIssueTranId=PIT.PIndentIssueTranId Left Outer join GodownMaster GM " & _
                         "on PRD.GodownId=GM.GodownId inner join unit on unit.UnitId=PRD.UnitId " & _
                         "Inner join V_FinishedItemDetail FID on FID.Item_Finished_Id=PRD.FinishedId  where PRD.PurchaseReceiveId=" & PurchaseReceiveId & " And pii.MasterCompanyId=" & VarMasterCompanyID & ""
            End If
            If strsql <> "" Then
                ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
            End If

            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    DGPurchaseReceiveDetail.Rows.Add()
                    DGPurchaseReceiveDetail.Item("gridPurchaseReceiveDetailId", DGPurchaseReceiveDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("PurchaseReceiveDetailId")
                    DGPurchaseReceiveDetail.Item("ItemDescription", DGPurchaseReceiveDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("ItemDescription")
                    DGPurchaseReceiveDetail.Item("Godownname", DGPurchaseReceiveDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Godownname")
                    DGPurchaseReceiveDetail.Item("gridqty", DGPurchaseReceiveDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("QTY")
                    DGPurchaseReceiveDetail.Item("Unitname", DGPurchaseReceiveDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Unitname")
                    DGPurchaseReceiveDetail.Item("LotNo", DGPurchaseReceiveDetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ddlcategorycange1()
        If DDChallanNo.SelectedIndex <> -1 And DDCategory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDItem, "select distinct IM.Item_Id,IM.Item_Name from PurchaseIndentIssueTran PIT inner join Item_Parameter_Master IPM  on PIT.FinishedId=IPM.Item_Finished_Id inner join Item_Master IM on IPM.Item_Id=IM.Item_Id where PIT.PIndentIssueId=" & DDChallanNo.SelectedValue & " and IM.Category_Id=" & DDCategory.SelectedValue & " And IPM.MasterCompanyId=" & VarMasterCompanyID & "")
        End If
    End Sub

    Private Sub DDCategory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDCategory.SelectedIndexChanged
        ddlcategorycange1()
    End Sub
    Private Sub item_indexchange()
        ddlitem_selectedindex()
        Fill_ChallanDetail()
    End Sub

    Private Sub DDItem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDItem.SelectedIndexChanged
        item_indexchange()
    End Sub
    Protected Sub ddlitem_selectedindex()
        If DDChallanNo.SelectedIndex <> -1 And DDItem.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            Dim st As String = "Select Distinct IPM.Quality_Id,QualityName from PurchaseIndentIssueTran PIT inner join Item_Parameter_Master IPM  on PIT.FinishedId=IPM.Item_Finished_Id inner join Item_Master IM on IPM.Item_Id=IM.Item_Id inner join Quality Q on Q.QualityId =IPM.Quality_Id where PIT.PIndentIssueId=" & DDChallanNo.SelectedValue & " and IPM.Item_Id=" & DDItem.SelectedValue & " And IPM.MasterCompanyId=" & VarMasterCompanyID & ""
            NewComboFill(DDQuality, st)
            NewComboFill(DDUnit, "Select Distinct U.Unitid,U.Unitname from PurchaseIndentIssueTran PIT inner join unit u on PIT.unitid=u.unitid inner join V_FinishedItemDetail vf on vf.item_finished_id=PIT.Finishedid where Vf.Item_Id=" & DDItem.SelectedValue & " and PIT.PIndentIssueId=" & DDChallanNo.SelectedValue & "")
            If DDUnit.Items.Count > 0 Then DDUnit.SelectedIndex = 0
            NewComboFill(DDGodown, "Select GodownId,GodownName From GodownMaster Where MasterCompanyId=" & VarMasterCompanyID & "")
            If DDGodown.Items.Count > 0 Then DDGodown.SelectedIndex = 0
        End If
    End Sub
    Private Sub Fill_CustomerOrderNo()
        If DDItem.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDColorShade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim finishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TextItemCode.Text, DDColorShade.SelectedValue, 0, "", VarMasterCompanyID)
            If finishedid > 0 Then
                If (DDCustomerOrderNo.Visible = True) Then
                    Dim Str As String = "Select OM.OrderID, OM.CustomerOrderNo " & _
                            " From PurchaseIndentIssueTran PIIT(Nolock) " & _
                            " JOIN OrderMaster OM(Nolock) ON OM.OrderID = PIIT.OrderID " & _
                            " Where PIIT.PindentIssueid = " & DDChallanNo.SelectedValue & "  AND PIIT.FINISHEDID=" & finishedid & "  Order By CustomerOrderNo"
                    NewComboFill(DDCustomerOrderNo, Str)
                End If

                If (DDCustomerOrderNo.Items.Count > 0) Then
                    DDCustomerOrderNo.SelectedIndex = 0
                End If
            End If
        End If
    End Sub
    Private Sub Fill_ChallanDetail()
        Try
            If DDItem.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDColorShade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                Dim finishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TextItemCode.Text, DDColorShade.SelectedValue, 0, "", VarMasterCompanyID)
                If finishedid > 0 Then
                    NewComboFill(DDLotNo, "Select Distinct LotNo,LotNo From PurchaseIndentIssueTran WHERE PINDENTISSUEID=" & DDChallanNo.SelectedValue & " AND FINISHEDID=" & finishedid & "")
                    If DDLotNo.Items.Count > 0 Then
                        DDLotNo.SelectedIndex = 0
                        If txtLotNo.Visible = True Then
                            txtLotNo.Text = DDLotNo.Text
                        End If
                    End If

                    Dim _array(5) As SqlParameter
                    _array(0) = New SqlParameter("@Companyid", SqlDbType.Int)
                    _array(1) = New SqlParameter("@FINISHEDID", SqlDbType.Int)
                    _array(2) = New SqlParameter("@PINDENTISSUEID", SqlDbType.Int)
                    _array(3) = New SqlParameter("@lotNo", SqlDbType.NVarChar, 250)
                    _array(4) = New SqlParameter("@MasterCompanyId", SqlDbType.Int)
                    _array(5) = New SqlParameter("@OrderID", SqlDbType.Int)

                    _array(0).Value = DDCompanyName.SelectedValue
                    _array(1).Value = finishedid
                    _array(2).Value = DDChallanNo.SelectedValue
                    _array(3).Value = DDLotNo.Text
                    _array(4).Value = VarMasterCompanyID
                    If (DDCustomerOrderNo.Visible = True) Then
                        _array(5).Value = DDCustomerOrderNo.SelectedValue
                    Else
                        _array(5).Value = 0
                    End If

                    Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "Pro_FillPurchaseOrder_PQty", _array)
                    If ds.Tables(1).Rows.Count > 0 Then
                        txtrate.Text = ds.Tables(1).Rows(0)("rate").ToString()
                        txtorderqty.Text = ds.Tables(1).Rows(0)("quantity").ToString()
                        'txtvat.Text = ds.Tables(1).Rows(0)("vat").ToString()
                        'txtcst.Text = ds.Tables(1).Rows(0)("cst").ToString()
                        txtsgst.Text = ds.Tables(1).Rows(0)("SGST").ToString()
                        txtIgst.Text = ds.Tables(1).Rows(0)("IGST").ToString()
                    Else
                        txtorderqty.Text = "0"
                        txtsgst.Text = ""
                        txtIgst.Text = ""
                    End If
                    TxtPQty.Text = ds.Tables(0).Rows(0)(0).ToString()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DDQuality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDQuality.SelectedIndexChanged
        If DDItem.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDChallanNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDColorShade, "Select Distinct IPM.ShadeColor_Id,ShadeColorName from PurchaseIndentIssueTran PIT inner join Item_Parameter_Master IPM  " & _
                                       "on PIT.FinishedId=IPM.Item_Finished_Id inner join Item_Master IM on IPM.Item_Id=IM.Item_Id left outer join Quality Q " & _
                                       "on Q.QualityId =IPM.Quality_Id left outer join Design D on D.DesignId=IPM.Design_Id " & _
                                       "left outer join Color C on C.ColorId=IPM.Color_Id left outer join  ShadeColor SC on " & _
                                       "SC.ShadeColorId=IPM.ShadeColor_Id left outer join Shape SH on SH.ShapeId=IPM.Shape_Id " & _
                                       "where PIT.PIndentIssueId=" & DDChallanNo.SelectedValue & " and IPM.Quality_Id=" & DDQuality.SelectedValue & " and " & _
                                       "IPM.Item_Id=" & DDItem.SelectedValue & " And IPM.MasterCompanyId=" & VarMasterCompanyID & "")
        End If
        Fill_ChallanDetail()
    End Sub

    Private Sub DDColorShade_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDColorShade.SelectedIndexChanged
        Fill_CustomerOrderNo()
        Fill_ChallanDetail()
    End Sub

    Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGodown.SelectedIndexChanged
        If DDGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If DDBinno.Visible = True Then
                FillBinno()
            End If
        End If
        Fill_ChallanDetail()
    End Sub
    Protected Sub FillBinno()
        DDBinno.SelectedIndex = -1
        If DDItem.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDColorShade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim finishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TextItemCode.Text, DDColorShade.SelectedValue, 0, "", VarMasterCompanyID)
            If VarCHECKBINCONDITION = "1" Then
                Module1.FillBinNO(DDBinno, Convert.ToInt32(DDGodown.SelectedValue), finishedid, New_Edit:=0)
            Else
                NewComboFill(DDBinno, "select BinNo,BinNO From BinMaster where GODOWNID=" & DDGodown.SelectedValue & " order by BINID")
            End If
            If DDBinno.Items.Count > 0 Then DDBinno.SelectedIndex = 0
        End If
    End Sub
    Private Sub LotNoSelectedIndexChange()
        If DDItem.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDColorShade.SelectedIndex <> -1 And DDLotNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim finishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TextItemCode.Text, DDColorShade.SelectedValue, 0, "", VarMasterCompanyID)
            If finishedid > 0 Then
                txtorderqty.Text = "0"
                Dim strsql As String = "Select Round(ISNULL(SUM(QUANTITY-Isnull(CanQty,0)),0)-[dbo].[Get_PURCHASEPENDINGQTY](FINISHEDID,PINDENTISSUEID,LotNo, OrderID),3) Qty from PurchaseIndentIssueTran wHERE PINDENTISSUEID=" & DDChallanNo.SelectedValue & " AND FINISHEDID=" & finishedid & " And lotNo='" & DDLotNo.Text & "' "
                If (DDCustomerOrderNo.Visible = True And Varcombovalue <> 0) Then
                    strsql = strsql & " And OrderID = " & DDCustomerOrderNo.SelectedValue & ""
                End If
                strsql = strsql & " GROUP BY FINISHEDID,PINDENTISSUEID,LotNo, OrderID"

                strsql = strsql & " Select rate,quantity-isnull(CanQty,0) quantity from PurchaseIndentIssueTran where FinishedId=" & finishedid & "  and PIndentIssueId=" & DDChallanNo.SelectedValue & " And lotNo='" & DDLotNo.Text & "'"
                If (DDCustomerOrderNo.Visible = True And Varcombovalue <> 0) Then
                    strsql = strsql & " And OrderID = " & DDCustomerOrderNo.SelectedValue & ""
                End If

                Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
                TxtPQty.Text = "0"

                If ds.Tables(0).Rows.Count > 0 Then
                    TxtPQty.Text = ds.Tables(0).Rows(0)("Qty").ToString()
                End If

                If ds.Tables(1).Rows.Count > 0 Then
                    txtrate.Text = ds.Tables(1).Rows(0)("rate").ToString()
                    txtorderqty.Text = ds.Tables(1).Rows(0)("quantity").ToString()
                End If
            End If
        End If
    End Sub

    Private Sub DDLotNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDLotNo.SelectedIndexChanged
        LotNoSelectedIndexChange()
    End Sub
    Private Sub qtychange()
        Dim RecQty As Double = 0
        If TxtQty.Text <> "" AndAlso txtrate.Text <> "" Then
            Dim ds As DataSet = New DataSet()
            ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, "select VarCompanyNo,PercentageExecssQty From Mastersetting ")

            Dim Percentage As Double = Convert.ToDouble(ds.Tables(0).Rows(0)("PercentageExecssQty"))
            RecQty = Math.Round(Convert.ToDouble(TxtPQty.Text) + (Convert.ToDouble(txtorderqty.Text) * Percentage / 100), 3)
            If ChkEditOrder.Checked = True Then
                hnqty = "0"
            End If

            If Convert.ToDouble(TxtQty.Text) > RecQty Then
                MsgBox("Qty Can not be greater than " & Math.Round(RecQty, 3) & "'")
                TxtQty.Text = ""
                Return
            Else
                TxtAmount.Text = Convert.ToString(Convert.ToDouble(txtrate.Text) * Convert.ToDouble(TxtQty.Text))
                fillAmount()
            End If

        End If
    End Sub
    Private Sub fillAmount()
        Dim amount As Double = 0
        Dim Qty As Double = 0
        Qty = Convert.ToDouble(If(TxtQty.Text = "", "0", TxtQty.Text))
        Qty = Qty - Val(txtbellwt.Text)
        'Qty = Qty - (Qty * 0)
        amount = Qty * Convert.ToDouble(If(txtrate.Text = "", "0", txtrate.Text))
        TxtAmount.Text = amount
        Dim vat As Double = 0, cst As Double = 0
        'vat = amount * Convert.ToDouble(If(txtvat.Text = "", "0", txtvat.Text)) / 100
        'cst = amount * Convert.ToDouble(If(txtcst.Text = "", "0", txtcst.Text)) / 100
        Dim SGST As Double = 0.0, IGST = 0.0
        SGST = amount * Val(txtsgst.Text) / 100
        IGST = amount * Val(txtIgst.Text) / 100
        amount = amount + vat + cst + SGST + IGST
        amount = amount - Convert.ToDouble(If(TxtPenalty.Text = "", "0", TxtPenalty.Text))
        Txtnetamount.Text = amount.ToString()
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

                TxtQty.Text = w_Weight.ToString()

            End If
        Catch ex As Exception
        End Try


    End Sub
    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()
    Private Sub TxtQty_GotFocus(sender As Object, e As System.EventArgs) Handles TxtQty.GotFocus
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

    Private Sub TxtQty_LostFocus(sender As Object, e As System.EventArgs) Handles TxtQty.LostFocus
        qtychange()
    End Sub
    Public Function getgiven(ByVal strval As String, ByVal strval1 As String) As String
        Dim val As String = ""
        val = Convert.ToString(Math.Round(Convert.ToDouble(strval) - Convert.ToDouble(strval1), 3, MidpointRounding.AwayFromZero))
        Return val
    End Function

    Protected Function CheckDuplicate_GateIn_ChallanNo() As Boolean
        Dim val As Boolean = True
        Try

            Dim ds As DataSet
            Dim str As String
            str = "select BillNo From PurchaseReceiveMaster Where PartyId=" & DDPartyName.SelectedValue & "  And BillNo='" & TxtBillNo.Text & "' And PurchaseReceiveId<>" & PurchaseReceiveId & " And MasterCompanyId=" & VarMasterCompanyID & ""
            ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
            If ds.Tables(0).Rows.Count > 0 Then
                MsgBox("Challan No Already exists.....")
                val = False
                Return val

            End If
            If TxtGateInNo.Text <> "" Then
                str = "select GateInNo From PurchaseReceiveMaster Where  GateInNo='" & TxtGateInNo.Text & "' And PurchaseReceiveId<>" & PurchaseReceiveId & " And MasterCompanyId=  " & VarMasterCompanyID & ""
                ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
                If ds.Tables(0).Rows.Count > 0 Then
                    MsgBox("GateIn No. Already Exists.....")
                    val = False
                    Return val

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return val
    End Function
    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Validcombobox(DDCompanyName) = False Then Exit Sub
        If Validcombobox(DDPartyName) = False Then Exit Sub
        If Validcombobox(DDChallanNo) = False Then Exit Sub
        If ddlrecchalanno.Visible = True Then
            If Validcombobox(ddlrecchalanno) = False Then Exit Sub
        End If
        If Validtxtbox(TxtBillNo) = False Then Exit Sub
        If Validcombobox(DDCategory) = False Then Exit Sub
        If Validcombobox(DDItem) = False Then Exit Sub
        If Validcombobox(DDQuality) = False Then Exit Sub
        If Validcombobox(DDColorShade) = False Then Exit Sub
        If DDCustomerOrderNo.Visible = True Then
            If Validcombobox(DDCustomerOrderNo) = False Then Exit Sub
        End If
        If Validcombobox(DDGodown) = False Then Exit Sub
        If DDBinno.Visible = True Then
            If Validcombobox(DDBinno) = False Then Exit Sub
        End If
        If Validcombobox(DDLotNo) = False Then Exit Sub
        If Validcombobox(DDUnit) = False Then Exit Sub
        If Validtxtbox(TxtQty) = False Then Exit Sub


        'If TxtMoisture.Visible = True Then
        '    If Validtxtbox(TxtMoisture) = False Then Exit Sub
        'End If

        ''**************************
        If CheckDuplicate_GateIn_ChallanNo() = False Then Exit Sub
        qtychange()
        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If
        Dim Tran = Con.BeginTransaction()
        Try
            Dim LotNo As String = ""
            Dim Str As String
            Dim finishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TextItemCode.Text, DDColorShade.SelectedValue, 0, "", VarMasterCompanyID, Tran)
            Dim ReceiveNo As String = Val(TxtReceiveNo)
            Dim hnpid As String = Val(hnprid)

            If (txtLotNo.Visible = True) Then
                LotNo = txtLotNo.Text
            Else
                LotNo = DDLotNo.Text
            End If
            'Str = "select isnull(FinishedId,0) from PurchaseReceiveDetail PRD inner join  PurchaseReceiveMaster PRM  on PRM.PurchaseReceiveId=PRD.PurchaseReceiveId where PRD.PIndentIssueId=" & DDChallanNo.SelectedValue & " and  FinishedId=" & finishedid & " and ReceiveNo=" + ReceiveNo + " and prd.lotno='" + LotNo + "' and purchasereceivedetailid <>" & hnpid & " and BaleNo='" & txtbaleno.Text & "' And prm.MasterCompanyId=" & VarMasterCompanyID & ""
            'Dim n As Integer = Convert.ToInt16(SqlHelper.ExecuteScalar(Tran, CommandType.Text, Str))
            Dim n As Integer = 0
            If ChkEditOrder.Checked = True Then
                Dim qry As String = "select PRD.PurchaseReceiveDetailId,QTY,ISNULL(V.ReturnQty,0) as RreturnQty " & _
                                    "from  PurchaseReceiveMaster prm left outer join " & _
                                    "PurchaseReceiveDetail PRD on prd.purchasereceiveid=prm.purchasereceiveid inner join " & _
                                    "PurchaseIndentIssue PII on PII.PIndentIssueId=PRD.PIndentIssueId " & _
                                    "LEFT OUTER JOIN V_PurchaseReturnDetail V ON prd.purchasereceiveDetailid=v.purchasereceiveDetailid " & _
                                    "where prd.purchasereceiveDetailid=" & hnprid & " And prm.MasterCompanyId=" & VarMasterCompanyID & ""
                Dim Ds As DataSet = SqlHelper.ExecuteDataset(Tran, CommandType.Text, qry)
                If Ds.Tables(0).Rows.Count > 0 Then
                    Txtreturnqty.Text = Ds.Tables(0).Rows(0)("RreturnQty").ToString()
                End If
                Dim b As String = Val(Txtreturnqty.Text)
                Dim a As String = Val(TxtPQty.Text)
                If a = "" Then
                    a = "0"
                Else
                    a = TxtPQty.Text
                End If
                TxtPQty.Text = Convert.ToString(Math.Round(Convert.ToDouble(a.ToString()) + Convert.ToDouble(TxtQty.Text) + Convert.ToDouble(Txtreturnqty.Text), 3, MidpointRounding.AwayFromZero))
                If Val(Txtreturnqty.Text) > 0 Then
                    If Val(TxtQty.Text) < Val(Txtreturnqty.Text) Then
                        MsgBox("ReceiveQty can not be less than returnqty !")
                    End If

                End If
            End If
            PurchaseReceiveId = 0
            PurchaseReceiveDetailId = 0
            If n = 0 Then

                Dim _arrpara(47) As SqlParameter
                _arrpara(0) = New SqlParameter("@PurchaseReceiveId", SqlDbType.Int)
                _arrpara(1) = New SqlParameter("@CompanyId", SqlDbType.Int)
                _arrpara(2) = New SqlParameter("@PartyId", SqlDbType.Int)
                _arrpara(3) = New SqlParameter("@ReceiveNo", SqlDbType.NVarChar, 50)
                _arrpara(4) = New SqlParameter("@ReceiveDate", SqlDbType.DateTime)
                _arrpara(5) = New SqlParameter("@UserId", SqlDbType.Int)
                _arrpara(6) = New SqlParameter("@MasterCompanyId", SqlDbType.Int)
                _arrpara(7) = New SqlParameter("@PurchaseReceiveDetailId", SqlDbType.Int)
                _arrpara(8) = New SqlParameter("@FinishedId", SqlDbType.Int)
                _arrpara(9) = New SqlParameter("@GodownId", SqlDbType.Int)
                _arrpara(10) = New SqlParameter("@UnitId", SqlDbType.Int)
                _arrpara(11) = New SqlParameter("@Qty", SqlDbType.Float)
                _arrpara(12) = New SqlParameter("@PIndentIssueId", SqlDbType.Int)
                _arrpara(13) = New SqlParameter("@GateInNo", SqlDbType.NVarChar, 50)
                _arrpara(14) = New SqlParameter("@BillNo", SqlDbType.NVarChar, 50)
                _arrpara(15) = New SqlParameter("@LotNo", SqlDbType.NVarChar, 50)
                _arrpara(16) = New SqlParameter("@Finished_Type_Id", SqlDbType.Int)
                _arrpara(17) = New SqlParameter("@BillNo1", SqlDbType.NVarChar, 50)
                _arrpara(18) = New SqlParameter("@Qtyreturn", SqlDbType.Float)
                _arrpara(19) = New SqlParameter("@rate", SqlDbType.Float)
                _arrpara(20) = New SqlParameter("@challan_status", SqlDbType.Int)
                _arrpara(21) = New SqlParameter("@vat", SqlDbType.Float)
                _arrpara(22) = New SqlParameter("@Cst", SqlDbType.Float)
                _arrpara(23) = New SqlParameter("@NetAmount", SqlDbType.Float)
                _arrpara(24) = New SqlParameter("@Remark", SqlDbType.NVarChar, 250)
                _arrpara(25) = New SqlParameter("@Penalty", SqlDbType.Float)
                _arrpara(26) = New SqlParameter("@MRemark", SqlDbType.NVarChar, 250)
                _arrpara(27) = New SqlParameter("@retdate", SqlDbType.SmallDateTime)
                _arrpara(28) = New SqlParameter("@TransportName", SqlDbType.VarChar, 250)
                _arrpara(29) = New SqlParameter("@TransPortAdd", SqlDbType.VarChar, 300)
                _arrpara(30) = New SqlParameter("@DriverName", SqlDbType.VarChar, 100)
                _arrpara(31) = New SqlParameter("@VehicleNo", SqlDbType.VarChar, 15)
                _arrpara(32) = New SqlParameter("@BiltyNo", SqlDbType.VarChar, 20)
                _arrpara(33) = New SqlParameter("@Biltydate", SqlDbType.SmallDateTime)
                _arrpara(34) = New SqlParameter("@IssLotNo", SqlDbType.VarChar, 50)
                _arrpara(35) = New SqlParameter("@LShort", SqlDbType.Float)
                _arrpara(36) = New SqlParameter("@Freight", SqlDbType.Float)
                _arrpara(37) = New SqlParameter("@BaleNo", SqlDbType.VarChar, 50)
                _arrpara(38) = New SqlParameter("@BellWt", SqlDbType.Float)
                _arrpara(39) = New SqlParameter("@SGST", SqlDbType.Float)
                _arrpara(40) = New SqlParameter("@IGST", SqlDbType.Float)
                _arrpara(41) = New SqlParameter("@BinNo", SqlDbType.VarChar, 50)
                _arrpara(42) = New SqlParameter("@CompanyLotNo", SqlDbType.VarChar, 50)
                _arrpara(43) = New SqlParameter("@OldLotNoWise", SqlDbType.Int)
                _arrpara(44) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                _arrpara(45) = New SqlParameter("@Moisture", SqlDbType.Float)
                _arrpara(46) = New SqlParameter("@OrderID", SqlDbType.Int)

                _arrpara(0).Direction = ParameterDirection.InputOutput
                _arrpara(0).Value = PurchaseReceiveId
                _arrpara(1).Value = DDCompanyName.SelectedValue
                _arrpara(2).Value = DDPartyName.SelectedValue
                _arrpara(3).Direction = ParameterDirection.InputOutput
                _arrpara(3).Value = Val(TxtReceiveNo)
                _arrpara(4).Value = TxtReceiveDate.Text
                _arrpara(5).Value = varuserid
                _arrpara(6).Value = VarMasterCompanyID
                _arrpara(7).Direction = ParameterDirection.InputOutput
                If ChkEditOrder.Checked = True Then
                    _arrpara(7).Value = hnprid
                Else
                    _arrpara(7).Value = PurchaseReceiveDetailId
                End If

                _arrpara(8).Value = finishedid
                _arrpara(9).Value = DDGodown.SelectedValue
                _arrpara(10).Value = DDUnit.SelectedValue
                _arrpara(11).Value = TxtQty.Text
                _arrpara(12).Value = DDChallanNo.SelectedValue
                _arrpara(13).Direction = ParameterDirection.InputOutput
                _arrpara(13).Value = TxtGateInNo.Text.ToUpper()
                _arrpara(14).Value = TxtBillNo.Text.ToUpper()
                _arrpara(15).Value = LotNo
                Dim VarFinish_Type As Integer = 0
                _arrpara(16).Value = VarFinish_Type
                _arrpara(17).Value = txtbillno1.Text
                _arrpara(18).Value = Val(Txtreturnqty.Text)
                _arrpara(19).Value = Val(txtrate.Text)
                _arrpara(20).Value = 0
                _arrpara(21).Value = 0
                _arrpara(22).Value = 0
                _arrpara(23).Value = Val(Txtnetamount.Text)
                _arrpara(24).Value = txtremarks.Text
                _arrpara(25).Value = Val(TxtPenalty.Text)
                _arrpara(26).Value = txtmastremark.Text
                _arrpara(27).Value = txtretdate.Text
                _arrpara(28).Value = ""
                _arrpara(29).Value = ""
                _arrpara(30).Value = ""
                _arrpara(31).Value = ""
                _arrpara(32).Value = ""
                _arrpara(33).Value = DBNull.Value
                _arrpara(34).Value = DDLotNo.Text
                _arrpara(35).Value = 0
                _arrpara(36).Value = Val(txtfreight.Text)
                _arrpara(37).Value = txtbaleno.Text
                _arrpara(38).Value = Val(txtbellwt.Text)
                _arrpara(39).Value = Val(txtsgst.Text)
                _arrpara(40).Value = Val(txtIgst.Text)
                Dim Binno As String = IIf(DDBinno.Visible = True, DDBinno.Text, "")
                _arrpara(41).Value = Binno
                _arrpara(42).Direction = ParameterDirection.InputOutput
                _arrpara(42).Value = IIf(txtcomplotno.Visible = True, txtcomplotno.Text, "")
                _arrpara(43).Value = IIf(chkoldlotno.Visible = True, IIf(chkoldlotno.Checked = True, 1, 0), 0)
                _arrpara(44).Direction = ParameterDirection.Output
                _arrpara(45).Value = IIf(TxtMoisture.Visible = True, IIf(TxtMoisture.Text = "", "0", TxtMoisture.Text), "0")
                _arrpara(46).Value = IIf(DDCustomerOrderNo.Visible = True, DDCustomerOrderNo.SelectedValue, "0")

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PurchaseReceive", _arrpara)

                PurchaseReceiveId = _arrpara(0).Value
                TxtReceiveNo = _arrpara(3).Value.ToString()
                TxtGateInNo.Text = _arrpara(13).Value.ToString()
                ''Stock Qty 
                _arrpara(11).Value = Val(_arrpara(11).Value) - Val(txtbellwt.Text)
                ''**************
                Dim CompanyLotno As String = ""
                CompanyLotno = _arrpara(42).Value
                txtcomplotno.Text = _arrpara(42).Value

                If _arrpara(44).Value.ToString <> "" Then
                    MsgBox(_arrpara(44).Value)
                    Tran.Rollback()
                    Exit Sub
                Else
                    Dim Ds As DataSet = SqlHelper.ExecuteDataset(Tran, CommandType.Text, "Select StockUpdateFlag From MasterSetting(Nolock) ")
                    If Ds.Tables(0).Rows.Count > 0 Then
                        If (Ds.Tables(0).Rows(0)("StockUpdateFlag").ToString() = 1) Then
                            StockStockTranTableUpdateNew(Convert.ToInt32(_arrpara(8).Value), Convert.ToInt32(_arrpara(9).Value), Convert.ToInt32(_arrpara(1).Value), IIf(VarPurchaseReceiveAutogenLotno = 1, CompanyLotno, Convert.ToString(_arrpara(15).Value)), Convert.ToDouble(_arrpara(11).Value), _arrpara(4).Value.ToString(), DateTime.Now.ToString("dd-MMM-yyyy"), "PurchaseReceiveDetail", Convert.ToInt32(_arrpara(7).Value), Tran, 1, True, 1, VarFinish_Type, Convert.ToInt16(DDUnit.SelectedValue), BinNo:=Binno)
                        End If
                    End If
                    Tran.Commit()

                    lblsrno.Text = "Sr No. is generated " & PurchaseReceiveId & "."
                    MsgBox("Data Saved Successfully..............")
                    Fill_porder()
                    fill_grid()
                    RefreshControl()
                    DDLotNo_SelectedIndexChanged(sender, New EventArgs())
                End If

            Else
                MsgBox("Duplicate entry.....")
            End If

        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try

        ''***********Print Barcode
        If chkprintbarcode.Checked = True Then
            PrintBarcode()
        End If
        ''************

        ''**************************
    End Sub
    Protected Sub PrintBarcode()
        Dim str As String
        str = "Select top(1) vf.QualityName,vf.ShadeColorName,PRD.LotNo,isnull(prd.Baleno,'') as BaleNo,prd.QTY as Qty,EI.EMpname, " & _
            " Replace(convert(nvarchar(11),PRM.receivedate,106),' ','-') as ReceiveDate,  " & _
            " isnull(PRM.MRemark,'') as Remark,Prd.PurchaseReceiveDetailId,VendorLotNo, U.UnitName, IsNull(CI.CustomerCode, '') CustomerCode, " & _
            " IsNull(OM.CustomerOrderNo, '') CustomerOrderNo " & _
            " From Purchasereceivemaster PRM(Nolock)  " & _
            " join PurchaseReceiveDetail PRD(Nolock) ON PRM.PurchaseReceiveId=PRD.PurchaseReceiveId  " & _
            " join EmpInfo EI(Nolock) on PRM.PartyId=EI.empid  " & _
            " join V_FinishedItemDetail vf(Nolock) on PRD.FinishedId=vf.ITEM_FINISHED_ID  " & _
            " JOIN Unit U(Nolock) ON U.UnitId = PRD.UnitId " & _
            " LEFT join OrderMaster OM ON OM.OrderID = PRD.OrderID " & _
            " LEFT JOIN Customerinfo CI ON CI.CustomerId = OM.CustomerId  " & _
            " Where PRM.Purchasereceiveid = " & PurchaseReceiveId & " order by PRD.PurchaseReceiveDetailId desc"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            If prn = "" Then
                MsgBox("Prn File is not available.Please contact service Provider", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")
                Exit Sub
            End If
            '**************
            Dim chkcount As Integer = 0
            Dim i As Integer = 0

            Dim TempFileTextLine As String = ""
            If varPrinterName = "" Then
                MsgBox("Printer Name can not be blank.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")
                Exit Sub
            End If

            TempFileTextLine = ""
            'TempFileTextLine = String.Format(prn, "" & ds.Tables(0).Rows(0)("QualityName") & "", "" & ds.Tables(0).Rows(0)("ShadeColorName") & "", "" & ds.Tables(0).Rows(0)("LotNo") & "", "" & ds.Tables(0).Rows(0)("Qty") & "", "" & ds.Tables(0).Rows(0)("Receivedate") & "", "" & ds.Tables(0).Rows(0)("EmpName") & "", "" & ds.Tables(0).Rows(0)("Remark") & "", "" & ds.Tables(0).Rows(0)("PurchaseReceiveDetailId") & "")
            If (VarMasterCompanyID = 16) Then
                'TempFileTextLine = String.Format(prn, "" & ds.Tables(0).Rows(0)("PurchaseReceiveDetailId") & "", "" & ds.Tables(0).Rows(0)("QualityName") & "", "" & ds.Tables(0).Rows(0)("ShadeColorName") & "", "" & ds.Tables(0).Rows(0)("Lotno") & "/" & ds.Tables(0).Rows(0)("VendorLotNo") & "", "" & ds.Tables(0).Rows(0)("BaleNo") & "", "" & ds.Tables(0).Rows(0)("Qty") & "", "" & ds.Tables(0).Rows(0)("Receivedate") & "", "" & ds.Tables(0).Rows(0)("EmpName") & "", "" & ds.Tables(0).Rows(0)("CustomerCode") & "", "" & ds.Tables(0).Rows(0)("CustomerOrderNo") & "", "" & ds.Tables(0).Rows(0)("Remark") & "", "" & ds.Tables(0).Rows(0)("UnitName") & "")
                TempFileTextLine = String.Format(prn, "" & ds.Tables(0).Rows(0)("PurchaseReceiveDetailId") & "", "" & ds.Tables(0).Rows(0)("QualityName") & "", "" & ds.Tables(0).Rows(0)("ShadeColorName") & "", "" & ds.Tables(0).Rows(0)("Lotno") & "", "" & ds.Tables(0).Rows(0)("BaleNo") & "", "" & ds.Tables(0).Rows(0)("Qty") & "", "" & ds.Tables(0).Rows(0)("Receivedate") & "", "" & ds.Tables(0).Rows(0)("EmpName") & "", "" & ds.Tables(0).Rows(0)("CustomerCode") & "", "" & ds.Tables(0).Rows(0)("CustomerOrderNo") & "", "" & ds.Tables(0).Rows(0)("Remark") & "", "" & ds.Tables(0).Rows(0)("UnitName") & "")
                'Label29.Text = ds.Tables(0).Rows(0)("Lotno").ToString()
                'Label30.Text = ds.Tables(0).Rows(0)("VendorLotNo").ToString()
            ElseIf (VarMasterCompanyID = 45) Then
                TempFileTextLine = String.Format(prn, "" & ds.Tables(0).Rows(0)("PurchaseReceiveDetailId") & "", "" & ds.Tables(0).Rows(0)("QualityName") & "", "" & ds.Tables(0).Rows(0)("ShadeColorName") & "", "" & ds.Tables(0).Rows(0)("Lotno") & "", "" & ds.Tables(0).Rows(0)("BaleNo") & "", "" & ds.Tables(0).Rows(0)("Qty") & "", "" & ds.Tables(0).Rows(0)("Receivedate") & "", "" & ds.Tables(0).Rows(0)("EmpName") & "", "" & ds.Tables(0).Rows(0)("CustomerOrderNo") & "", "" & ds.Tables(0).Rows(0)("CustomerCode") & "", "" & ds.Tables(0).Rows(0)("Remark") & "")
            Else
                TempFileTextLine = String.Format(prn, "" & ds.Tables(0).Rows(0)("PurchaseReceiveDetailId") & "", "" & ds.Tables(0).Rows(0)("QualityName") & "", "" & ds.Tables(0).Rows(0)("ShadeColorName") & "", "" & ds.Tables(0).Rows(0)("Lotno") & "", "" & ds.Tables(0).Rows(0)("Qty") & "", "" & ds.Tables(0).Rows(0)("Receivedate") & "", "" & ds.Tables(0).Rows(0)("EmpName") & "", "" & ds.Tables(0).Rows(0)("Remark") & "", "" & ds.Tables(0).Rows(0)("BaleNo") & "", "" & ds.Tables(0).Rows(0)("VendorLotno") & "", "" & ds.Tables(0).Rows(0)("UnitName") & "")
            End If
            RawPrinterHelper.SendStringToPrinter(varPrinterName, TempFileTextLine)
        End If
    End Sub
    Protected Sub RefreshControl()
        TxtPQty.Text = ""
        txtorderqty.Text = "0"
        '' txtrate.Text = ""
        TxtQty.Text = ""
        TextItemCode.Text = ""
        TextItemCode.Focus()
        ''DDItem.SelectedIndex = -1
        '' DDColorShade.SelectedIndex = -1
        ''txtLotNo.Text = ""
        ''txtmastremark.Text = ""
        TxtAmount.Text = ""
        Txtnetamount.Text = ""
        ''txtremarks.Text = ""
        DDCompanyName.Enabled = False
        DDPartyName.Enabled = False
        DDChallanNo.Enabled = True
        TxtReceiveDate.Enabled = False
        TxtBillNo.Enabled = False
        txtretdate.Enabled = False
        Txtreturnqty.Text = "0"
        PurchaseReceiveDetailId = 0
        txtbellwt.Text = ""
        TxtMoisture.Text = ""
        ''txtbaleno.Text = ""
    End Sub

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        DDCompanyName.Enabled = True
        DDPartyName.Enabled = True
        DDChallanNo.SelectedIndex = -1
        PurchaseReceiveId = 0
        PurchaseReceiveDetailId = 0
        hnprid = 0
        TxtReceiveNo = "0"
        TxtPQty.Text = ""
        txtorderqty.Text = "0"
        txtsgst.Text = ""
        txtIgst.Text = ""
        txtrate.Text = ""
        TxtQty.Text = ""
        txtbellwt.Text = ""
        TextItemCode.Text = ""
        TextItemCode.Focus()
        DDItem.SelectedIndex = -1
        DDColorShade.SelectedIndex = -1
        txtLotNo.Text = ""
        txtmastremark.Text = ""
        TxtAmount.Text = ""
        Txtnetamount.Text = ""
        txtremarks.Text = ""
        DDChallanNo.Enabled = True
        TxtReceiveDate.Enabled = True
        TxtBillNo.Enabled = True
        txtretdate.Enabled = True
        Txtreturnqty.Text = "0"
        PurchaseReceiveDetailId = 0
        txtbaleno.Text = ""
        DGPurchaseReceiveDetail.Rows.Clear()
        DGporder.Rows.Clear()
        TxtBillNo.Text = ""
        txtbillno1.Text = ""
        txtcomplotno.Text = ""
        TxtGateInNo.Text = ""
    End Sub

    Private Sub DDPartyName_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles DDPartyName.SelectedIndexChanged
        If DDPartyName.SelectedIndex <> -1 And DDCompanyName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If ChkEditOrder.Checked = False Then
                fill_order()
            Else
                Dim ChallanNo As String = String.Empty
                Select Case VarMasterCompanyID
                    Case "9"
                        ChallanNo = "BillNo"
                    Case Else
                        ChallanNo = "receiveno+' / '+BillNo"
                End Select

                NewComboFill(ddlrecchalanno, "select distinct PurchaseReceiveId," & ChallanNo & " as challanNo from PurchaseReceiveMaster  where partyid=" & DDPartyName.SelectedValue & " And CompanyId=" & DDCompanyName.SelectedValue & " And MasterCompanyId=" & VarMasterCompanyID & "")
                fill_order()
            End If
        End If
    End Sub

    Private Sub DGporder_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGporder.CellDoubleClick
        Dim category As String = DGporder.Item("lblcategoryid", DGporder.CurrentRow.Index).Value
        Dim Item As String = DGporder.Item("lblitem_id", DGporder.CurrentRow.Index).Value
        Dim Quality As String = DGporder.Item("lblqualityid", DGporder.CurrentRow.Index).Value
        'Dim Color As String = (CType(DGporder.Rows(r).FindControl("lblColorid"), Label)).Text
        'Dim design As String = (CType(DGporder.Rows(r).FindControl("lbldesignid"), Label)).Text
        'Dim shape As String = (CType(DGporder.Rows(r).FindControl("lblshapeid"), Label)).Text
        Dim shadecolor As String = DGporder.Item("lblshadecolorid", DGporder.CurrentRow.Index).Value
        'Dim size As String = (CType(DGporder.Rows(r).FindControl("lblsizeid"), Label)).Text
        Dim Qty As String = DGporder.Item("lblqty", DGporder.CurrentRow.Index).Value
        Dim recQty As String = DGporder.Item("lblrecqty", DGporder.CurrentRow.Index).Value
        Dim orderid As String = DGporder.Item("lblorderid", DGporder.CurrentRow.Index).Value
        Dim finishedid As String = DGporder.Item("lblfinishedid", DGporder.CurrentRow.Index).Value
        Dim Lotno As String = DGporder.Item("lbllotno", DGporder.CurrentRow.Index).Value
        DDCategory.SelectedValue = category
        ddlcategorycange1()
        DDItem.SelectedValue = Item
        item_indexchange()
        DDQuality.SelectedValue = Quality
        DDColorShade.SelectedValue = shadecolor

        ''TxtQty.Text = Convert.ToString(Math.Round(Convert.ToDouble(Qty) - Convert.ToDouble(recQty), 3, MidpointRounding.AwayFromZero))
        'If Convert.ToDouble(TxtQty.Text) < 0 Then TxtQty.Text = "0"
        'If TxtQty.Text <> "" And Also txtrate.Text <> "" Then
        '    TxtAmount.Text = Convert.ToString(Convert.ToDouble(txtrate.Text) * Convert.ToDouble(TxtQty.Text))
        '    fillAmount()
        'End If
        If (DDCustomerOrderNo.Visible = True) Then
            DDCustomerOrderNo.SelectedValue = orderid
        End If
        If DDGodown.Items.Count > 0 Then
            DDGodown.SelectedIndex = 0
        End If
        If DDBinno.Visible = True Then
            FillBinno()
        End If

        DDLotNo.SelectedValue = Lotno
        LotNoSelectedIndexChange()
        If txtLotNo.Visible = True Then
            txtLotNo.Text = DDLotNo.Text
        End If

        TxtGateInNo.Focus()
        hnprid = "0"
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim qry As String = ""
        Dim dsfilename As String = ""
        Dim ds As DataSet = New DataSet()
        Dim array(6) As SqlParameter
        array(0) = New SqlParameter("@ReceiveNo", PurchaseReceiveId)
        array(1) = New SqlParameter("@UserName", "")
        array(2) = New SqlParameter("@MasterCompanyId", VarMasterCompanyID)
        array(3) = New SqlParameter("@UserId", varuserid)
        array(4) = New SqlParameter("@msg", SqlDbType.VarChar, 500)
        array(4).Direction = ParameterDirection.Output
        array(5) = New SqlParameter("@ReportName", "REPORTS/PURCHASERECEIVENEW.RPT")
        array(6) = New SqlParameter("@DSFileName", SqlDbType.VarChar, 100)
        array(6).Direction = ParameterDirection.Output
        ds = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "Pro_GetPurchaseReceiveNEW", array)
        dsfilename = array(6).Value.ToString().Trim("~")

        'qry = "SELECT VCI.CompanyName,VCI.CompanyAddress,VCI.CompanyPhoneNo,VCI.CompanyFaxNo,VCI.TinNo,VEI.EmpName,VEI.EmpAddress,VEI.EmpPhoneNo,VEI.EmpMobile," & _
        '"VPRR.ReceiveNo, VPRR.Qty, VPRR.ItemDescription, VPRR.ReceiveDate, VPRR.UnitName, VPRR.GodownName, VPRR.GateInNo, VPRR.billno, FT.FINISHED_TYPE_NAME, " & _
        '"IPM.ProductCode, VPRR.amt, VPRR.vat, VPRR.cst, VPRR.localorder, VPRR.customerorderno, VPRR.CHALLANN0, VPRR.purchaseorder, VPRR.QtyReturn, VPRR.Remark, VPRR.returndate, LOTNO, Rate " & _
        '"," & VarMasterCompanyID & " as MastercompanyId,VEI.EmpAddress2,VEI.EmpAddress3,VCI.CompAddr2,VCI.CompAddr3,VPRR.Freight,VPRR.Purchasereceiveid FROM V_Companyinfo VCI INNER JOIN V_PurchaseReceiveReport VPRR ON VCI.CompanyId=VPRR.CompanyId INNER JOIN V_EmployeeInfo VEI ON " & _
        '"VPRR.PartyId=VEI.EmpId LEFT OUTER JOIN FINISHED_TYPE FT ON VPRR.Finished_Type_Id=FT.ID INNER JOIN ITEM_PARAMETER_MASTER IPM ON " & _
        '"VPRR.Finishedid=IPM.ITEM_FINISHED_ID Where VPRR.ReceiveNo ='" & PurchaseReceiveId & "' And VPRR.MasterCompanyId=" & VarMasterCompanyID & ""
        ''Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, qry)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            If ChkLotwisesummary.Checked = True Then
                sReportName = (My.Application.Info.DirectoryPath & "\Reports\PurchaseReceiveNewSummary.rpt")
            Else
                sReportName = (My.Application.Info.DirectoryPath & "\Reports\PurchaseReceiveNEW.rpt")
            End If
            dspath = (My.Application.Info.DirectoryPath & dsfilename)
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
    Private Sub TxtQty_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsave.Focus()
        End If
    End Sub
    Private Sub txtbellwt_TextChanged(sender As Object, e As System.EventArgs) Handles txtbellwt.TextChanged
        fillAmount()
    End Sub

    Private Sub txtsgst_TextChanged(sender As Object, e As System.EventArgs) Handles txtsgst.TextChanged
        fillAmount()
    End Sub

    Private Sub txtIgst_TextChanged(sender As Object, e As System.EventArgs) Handles txtIgst.TextChanged
        fillAmount()
    End Sub

    Private Sub cmbprintername_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbprintername.SelectedIndexChanged
        prn = ""
        Printside = 1
        If cmbprintername.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, "select prn,PrintSide From Barcodeprinter Where ID=" & cmbprintername.SelectedValue & "")
            If ds.Tables(0).Rows.Count > 0 Then
                prn = ds.Tables(0).Rows(0)("prn")
                Printside = ds.Tables(0).Rows(0)("printside")
            End If
        End If
    End Sub

    Private Sub chkprintbarcode_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkprintbarcode.CheckedChanged
        If chkprintbarcode.Checked = True Then
            ''**************************************
            Dim ps As New PrinterSettings()
            varPrinterName = ps.PrinterName
            ''Fill printer
            Barcodetype = 1
            Call NewComboFill(cmbprintername, "select ID,Displayname + case when Printername<>DisplayName Then ' # ' + Printername Else '' End  From Barcodeprinter where barcodetype=" & Barcodetype & " order by id")
            Dim Index As Integer
            Index = cmbprintername.FindString(varPrinterName)
            If Index < 0 Then
                MsgBox("Default Printer is not available.Please contact Service Provider", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")
            Else
                cmbprintername.SelectedIndex = Index
                cmbprintername_SelectedIndexChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub frmpurchasereceive_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub chkoldlotno_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkoldlotno.CheckedChanged
        txtcomplotno.Text = ""
    End Sub

    Private Sub DDCustomerOrderNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDCustomerOrderNo.SelectedIndexChanged
        Fill_ChallanDetail()
    End Sub

    Private Sub BtnComplete_Click(sender As System.Object, e As System.EventArgs) Handles BtnComplete.Click
        If Validcombobox(DDChallanNo) = False Then Exit Sub
        SqlHelper.ExecuteNonQuery(Con, CommandType.Text, "Update PurchaseIndentIssue Set Status = 'COMPLETE' Where PindentIssueid = " & DDChallanNo.SelectedValue & "")
        MsgBox("Status updated successfully", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")
    End Sub
End Class