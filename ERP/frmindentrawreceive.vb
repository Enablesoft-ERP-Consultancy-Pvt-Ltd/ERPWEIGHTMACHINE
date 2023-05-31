Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class frmindentrawreceive
    Dim HPRMID As Integer = 0
    Dim Item_finished_id As Integer = 0
    Dim hnfinishedid As Integer = 0
    Dim Flag As Integer = 0
    Dim DetailID As Integer = 0
    Dim masterID As Integer = 0
    Private Sub frmindentrawreceive_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())

        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If

        Dim Qry As String = "select Distinct CI.CompanyId,Companyname from Companyinfo CI,Company_Authentication CA Where CA.CompanyId=CI.CompanyId And CA.UserId=" & varuserid & " And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By Companyname " & _
                         "Select Distinct PROCESS_NAME_ID,process_name from PROCESS_NAME_MASTER pm inner join IndentMaster im on pm.PROCESS_NAME_ID=im.processid And pm.MasterCompanyId=" & VarMasterCompanyID & " order by process_name " & _
                         "Select godownid,godownname from godownmaster Where MasterCompanyId=" & VarMasterCompanyID & " order by godownname"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, Qry)

        ConditionalComboFillWithDS(ddCompName, ds, 0, True, "")
        If ddCompName.Items.Count > 0 Then
            ddCompName.SelectedValue = VarCompanyID
            ddCompName.Enabled = False
        End If

        ConditionalComboFillWithDS(ddProcessName, ds, 1, True, "")
        ConditionalComboFillWithDS(ddgodown, ds, 2, True, "")
        If ddgodown.Items.Count > 0 Then ddgodown.SelectedIndex = 0
        If varTagNowise = "1" Then
            lblTagNo.Visible = True
            DDTagNo.Visible = True
            lblmanualtagno.Visible = True
            txttagNo.Visible = True
            chkchangeTagno.Visible = True
        End If
        If varcanedit = "1" Then
            ChkEdit.Visible = True
            chkcomplete.Visible = True
        End If
        If VarBINNOWISE = "1" Then
            lblbinno.Visible = True
            ddbinno.Visible = True
        End If
        If (VarMasterCompanyID = 16 Or VarMasterCompanyID = 28 Or VarMasterCompanyID = 42) Then
            TxtMoisture.Visible = True
            Label30.Visible = True
        End If
    End Sub
    Private Sub ProcessSelectedChange()
        NewComboFill(ddempname, "SELECT distinct E.EmpId,E.EmpName FROM IndentMaster IM INNER JOIN  EmpInfo E ON IM.PartyId=E.EmpId And CompanyId=" & ddCompName.SelectedValue & " And IM.Processid=" & ddProcessName.SelectedValue & " order by e.EmpName")
        HPRMID = "0"
    End Sub

    Private Sub ddProcessName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddProcessName.SelectedIndexChanged
        If ddProcessName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            ProcessSelectedChange()
        End If
    End Sub
    Private Sub EmpolyeeSelectedChange()
        Dim str, status As String
        If chkcomplete.Checked = True Then
            status = "Complete"
        Else
            status = "Pending"
        End If
        ''****************
        If ChkEdit.Checked = True Then
            str = "Select distinct IM.IndentId,case When " & VarMasterCompanyID & " =9 Then om.localOrder+' / '+IndentNo else IndentNo+'-'+CI.CustomerCode+'/'+om.CustomerOrderNo End  from IndentMaster IM inner join PP_ProcessRawtran PRT  on PRT.IndentId=IM.IndentId " & _
               "inner join PP_ProcessRawMaster PRM ON PRM.PRMID=PRT.PRMID inner join indentdetail id on id.IndentId=im.IndentId left outer join ordermaster om on  " & _
               " om.orderid=id.orderid  Inner join Customerinfo CI On CI.CustomerId=om.CustomerId  Where PRM.Companyid=" & ddCompName.SelectedValue & " And PRM.ProcessId=" & ddProcessName.SelectedValue & " And " & _
             " PRM.EMPID = " & ddempname.SelectedValue & ""
        Else
            str = "Select distinct IM.IndentId,case when " & VarMasterCompanyID & "=9 Then LocalOrder+' / '+ IndentNo else IndentNo+'-'+CI.CustomerCode+'/'+om.CustomerOrderNo End  from " & _
                    "IndentMaster IM Inner join IndentDetail Id on Im.IndentId=ID.IndentId and im.Status<>'Cancelled' and Im.status='" & status & "'  left outer join ordermaster om on " & _
                    "om.orderid=id.orderid  Inner join Customerinfo CI On CI.CustomerId=om.CustomerId  Where " & _
                    "IM.Companyid = " & ddCompName.SelectedValue & " And ProcessId = " & ddProcessName.SelectedValue & " And PartyId = " & ddempname.SelectedValue & ""
        End If
        NewComboFill(ddindent, str)
        HPRMID = "0"

    End Sub
    Private Sub ddempname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddempname.SelectedIndexChanged
        If ddCompName.SelectedIndex <> -1 And ddProcessName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            EmpolyeeSelectedChange()
        End If
    End Sub
    Private Sub IndentSelectedChange()
        If ddCompName.SelectedIndex <> -1 And ddProcessName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And ddindent.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(ddChallanNo, "Select Distinct PPM.PrmId,PPM.ChallanNo from PP_ProcessRawMaster PPM,PP_ProcessRawTran PPT Where  " & _
            "PPM.PrmId=PPT.PrmId And PPM.CompanyID=" & ddCompName.SelectedValue & " And PPM.ProcessID=" & ddProcessName.SelectedValue & " And PPm.EmpId=" & ddempname.SelectedValue & " And PPT.IndentID=" & ddindent.SelectedValue & "")
        End If
    End Sub
    Private Sub ddindent_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddindent.SelectedIndexChanged
        gvdetail.Rows.Clear()
        dGORDER.Rows.Clear()
        IndentSelectedChange()
    End Sub
    Private Sub ChallanNoSelectedChange()

        If ddCompName.SelectedIndex <> -1 And ddProcessName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And ddindent.SelectedIndex <> -1 And ddChallanNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If ChkEdit.Checked = True Then
                Dim str As String = "Select Distinct PM.PrmId,ChallanNo From PP_ProcessRecMaster PM,PP_ProcessRecTran PT Where PM.PrmId=PT.Prmid And PM.CompanyId=" & ddCompName.SelectedValue & " And " & _
                "PM.Processid = " & ddProcessName.SelectedValue & " And PM.Empid = " & ddempname.SelectedValue & " And IndentId = " & ddindent.SelectedValue & " And " & _
                "IssPrmId = " & ddChallanNo.SelectedValue & ""
                NewComboFill(ddPartyChallanNo, str)
            End If

            dditemname.SelectedIndex = -1
            fillorderdetail()
            ReceiveIssItemCheckedChanged()
        End If
    End Sub
    Private Sub EditCheckedChanged()
        txtidnt.Text = ""
        If ddProcessName.Items.Count > 0 Then
            ddProcessName.SelectedIndex = 0
        End If

        If ddempname.Items.Count > 0 Then
            ddempname.SelectedIndex = 0
        End If

        txtidnt.Focus()
        If ChkEdit.Checked = True Then
            lblpartychallanNo.Visible = True
            ddPartyChallanNo.Visible = True
        Else
            lblpartychallanNo.Visible = False
            ddPartyChallanNo.Visible = False
        End If
    End Sub

    Private Sub fillorderdetail()
        dGORDER.Rows.Clear()
        Dim i As Integer
        Dim sql As String = "SELECT Category_Name+'  '+V.ITEM_NAME+'  '+QualityName+'  '+DesignName+'  '+ColorName+'  '+ShadeColorName+'  '+ShapeName " & _
            "+'  '+isnull(id.Dyingmatch,'')+'   '+isnull(id.dyeingType,'')+'   '+isnull(id.dyeing,'') as Description,SUM(Quantity) AS QTY,IM.INDENTID as indentid " & _
            ",v.item_finished_id as finishedid,CATEGORY_ID,ITEM_ID,QualityId,ColorId, designId, SizeId, ShapeId, ShadecolorId, unitid, ID.TagNO, ID.Lotno " & _
            "FROM INDENTMASTER IM INNER JOIN  INDENTDETAIL ID ON IM.INDENTID=ID.INDENTID INNER JOIN V_FinishedItemDetail V ON " & _
            "V.ITEM_FINISHED_ID = ID.OFinishedId  Inner Join V_PPFinishedid VP on ID.OFinishedId=VP.FinishedId and ID.PPNo=VP.PPID " & _
            "inner join (select  Distinct Prt.Finishedid,PRt.lotno from PP_ProcessRawMaster PRM inner join PP_ProcessRawTran PRT  on PRM.PRMid=PRT.PRMid and PRM.PRMid=" & ddChallanNo.SelectedValue & ") As IssDetail on ID.lotno=IssDetail.Lotno and vp.IFinishedid=IssDetail.Finishedid " & _
            "WHERE IM.INDENTID=" & ddindent.SelectedValue & " And IM.MasterCompanyId=" & VarMasterCompanyID & " " & _
            "GROUP BY Category_Name ,V.ITEM_NAME ,QualityName,DesignName,ColorName,   " & _
            "ShadeColorName,ShapeName,CATEGORY_ID,ITEM_ID,QualityId,ColorId,designId, " & _
            "SizeId,ShapeId,ShadecolorId,v.item_finished_id,IM.INDENTID,id.Dyingmatch," & _
            "id.dyeingType,id.dyeing,unitid,ID.TagNO,ID.Lotno"

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, sql)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                dGORDER.Rows.Add()
                dGORDER.Item("ITEMDESCRIPTION", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
                dGORDER.Item("LotNo", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("LotNo")
                dGORDER.Item("TagNo", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
                dGORDER.Item("Qty", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
                dGORDER.Item("BalQty", dGORDER.Rows.Count - 1).Value = getgiven(ds.Tables(0).Rows(i)("finishedid"), ds.Tables(0).Rows(i)("Indentid"), ds.Tables(0).Rows(i)("Qty"), ds.Tables(0).Rows(i)("LotNo"), ds.Tables(0).Rows(i)("TagNo"))
                dGORDER.Item("lblcategoryid", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("CATEGORY_ID")
                dGORDER.Item("lblItem_id", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_id")
                dGORDER.Item("lblQualityId", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("QualityId")
                dGORDER.Item("lblcolorid", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("colorid")
                dGORDER.Item("lbldesignid", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("designid")
                dGORDER.Item("lblsizeid", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("sizeid")
                dGORDER.Item("lblshapeid", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("shapeid")
                dGORDER.Item("lblshadecolorid", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("shadecolorid")
                dGORDER.Item("lblqty", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
                dGORDER.Item("lblfinished", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("finishedid")
                dGORDER.Item("lblindent", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("indentid")
                dGORDER.Item("lblunitid", dGORDER.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("unitid")
            Next
        End If
    End Sub
    Public Function getgiven(ByVal strval As String, ByVal strval1 As String, ByVal strval2 As String, ByVal Lotno As String, ByVal Tagno As String) As String
        Dim val As String = ""
        Dim dt As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, "select isnull(Sum(recqty),0) as recqty From V_IndentRecWithIssrecItemflag Where IndentId=" & strval1 & " and Finishedid=" & strval & " and Lotno='" & Lotno & "' and TagNo='" + Tagno & "'")
        val = Convert.ToString(Math.Round(Convert.ToDouble(strval2) - Convert.ToDouble(dt.Tables(0).Rows(0)(0).ToString()), 3))
        Return val
    End Function

    Private Sub ddChallanNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddChallanNo.SelectedIndexChanged
        gvdetail.Rows.Clear()
        ChallanNoSelectedChange()
    End Sub

    Private Sub ReceiveIssItemCheckedChanged()
        If ddempname.SelectedIndex <> -1 And ddProcessName.SelectedIndex <> -1 And ddindent.SelectedIndex <> -1 And Varcombovalue <> 0 Then


            If ChkForReceiveIssItem.Checked = True Then
                Dim str As String = "select DISTINCT VF.CATEGORY_ID,VF.CATEGORY_NAME from PP_ProcessRawMaster PM inner join PP_ProcessRawTran PT " & _
                               "on PM.PRMid=PT.PRMid inner join IndentMaster IM on IM.IndentID=pt.Indentid  " & _
                               "inner join V_FinishedItemDetail vf on Pt.Finishedid=vf.ITEM_FINISHED_ID     " & _
                               "inner join UserRights_Category UC on(UC.CategoryId=VF.Category_ID           " & _
                               "And UC.UserId=" & varuserid & ")                                 " & _
                               "Where  IM.PartyId=" & ddempname.SelectedValue & " And IM.ProcessID=" & ddProcessName.SelectedValue & " And IM.IndentId=" & ddindent.SelectedValue & " And IM.MasterCompanyId=" & VarMasterCompanyID & ""
                NewComboFill(ddCatagory, str)
            Else
                NewComboFill(ddCatagory, "SELECT DISTINCT VF.CATEGORY_ID,VF.CATEGORY_NAME From IndentMaster IM,IndentDetail ID,V_FinishedItemDetail VF inner join UserRights_Category UC on(UC.CategoryId=VF.Category_ID And UC.UserId=" & varuserid & ") " & _
                "Where IM.IndentID=ID.IndentID And ID.OFinishedId=VF.ITEM_FINISHED_ID And IM.PartyId=" & ddempname.SelectedValue & " And IM.ProcessID=" & ddProcessName.SelectedValue & " And IM.IndentId=" & ddindent.SelectedValue & " And IM.MasterCompanyId=" & VarMasterCompanyID & "")
            End If
            ddlcategorycange()

        End If
    End Sub
    Private Sub ddlcategorycange()

        Dim str As String = ""
        If ddindent.SelectedIndex <> -1 And ddCatagory.SelectedIndex <> -1 And Varcombovalue <> 0 Then


            If ChkForReceiveIssItem.Checked = True Then
                str = "select DISTINCT VF.ITEM_ID,VF.ITEM_NAME from PP_ProcessRawMaster PM inner join PP_ProcessRawTran PT " & _
                       "on PM.PRMid=PT.PRMid inner join IndentMaster IM on IM.IndentID=pt.Indentid " & _
                       "inner join V_FinishedItemDetail vf on Pt.Finishedid=vf.ITEM_FINISHED_ID " & _
                       "Where IM.IndentId=" & ddindent.SelectedValue & " and vf.CATEGORY_ID=" & ddCatagory.SelectedValue & " And IM.MasterCompanyId=" & VarMasterCompanyID & " "
                NewComboFill(dditemname, str)
            Else
                NewComboFill(dditemname, "SELECT DISTINCT VF.ITEM_ID,VF.ITEM_NAME From IndentDetail ID,V_FinishedItemDetail VF " & _
               " Where ID.OFinishedId=VF.ITEM_FINISHED_ID And ID.IndentId=" & ddindent.SelectedValue & " And VF.CATEGORY_ID=" & ddCatagory.SelectedValue & " And VF.MasterCompanyId=" & VarMasterCompanyID & "")
            End If

        End If
    End Sub

    Private Sub ChkEdit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkEdit.CheckedChanged
        EditCheckedChanged()
    End Sub

    Private Sub PartyChallanNoSelectedChenge()
        HPRMID = ddPartyChallanNo.SelectedValue
        Dim Str As String = "Select Distinct replace(convert(varchar(11),isnull(Date,''),106), ' ','-') Date,GateInNo,NoOfHank,ChallanNo,isnull(checkedby,'') as Checkedby,isnull(approvedby,'') as approvedby From PP_ProcessRecMaster PM,PP_ProcessRecTran PT Where PM.PrmId=" & HPRMID & ""
        Dim Ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, Str)
        If Ds.Tables(0).Rows.Count > 0 Then
            txtdate.Text = Ds.Tables(0).Rows(0)("Date").ToString()
            TxtGateInNo.Text = Ds.Tables(0).Rows(0)("GateInNo").ToString()
            TxtNoOFHank.Text = Ds.Tables(0).Rows(0)("NoOfHank").ToString()
            TxtPartyChallanNo.Text = Ds.Tables(0).Rows(0)("ChallanNo").ToString()
            txtcheckedby.Text = Ds.Tables(0).Rows(0)("checkedby").ToString()
            txtapprovedby.Text = Ds.Tables(0).Rows(0)("approvedby").ToString()
            Fill_Grid()
        End If
    End Sub
    Private Sub ddPartyChallanNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddPartyChallanNo.SelectedIndexChanged
        If ddPartyChallanNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            PartyChallanNoSelectedChenge()
            Flag = "1"
        End If
    End Sub
    Private Sub Fill_Grid()
        gvdetail.Rows.Clear()
        Dim i As Integer
        Dim strsql As String = "SELECT VF.CATEGORY_NAME,VF.ITEM_NAME,QualityName +'  '+ designName +'  '+ ColorName +'  '+ ShadeColorName +'  '+ ShapeName +'  '+ SizeMtr Description," & _
                            " GM.GodownName,LotNo,PPT.RecQuantity,PPT.PRTid,PPT.TagNo,Ppt.Lossqty,PPT.Rate FROM PP_ProcessRecTran PPT,V_FinishedItemDetail VF,GodownMaster GM " & _
                            " Where PPT.Finishedid=VF.ITEM_FINISHED_ID And GM.GoDownID=PPT.Godownid And PPT.PRMID=" & HPRMID & " And VF.MasterCompanyId=" & VarMasterCompanyID & ""
        If ChkEdit.Checked = True Then
            If ddindent.SelectedIndex <> -1 Then
                strsql = strsql & " and PPT.Indentid=" & ddindent.SelectedValue & ""
            End If
            If ddChallanNo.SelectedIndex <> -1 Then
                strsql = strsql & " and PPT.IssPrmID=" & ddChallanNo.SelectedValue & ""
            End If
        End If
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                gvdetail.Rows.Add()
                gvdetail.Item("prtid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Prtid")
                gvdetail.Item("ItemName", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_Name")
                gvdetail.Item("Description", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
                gvdetail.Item("gvdetaillotno", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("lotno")
                gvdetail.Item("gvdetailTagno", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
                gvdetail.Item("gvdetailgodown", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GodownName")
                gvdetail.Item("gvdetailqty", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RecQuantity")
                gvdetail.Item("gvdetailLossqty", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lossqty")
                gvdetail.Item("gvdetailRate", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rate")
            Next
        End If
    End Sub

    Private Sub ddCatagory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddCatagory.SelectedIndexChanged
        ddlcategorycange()
    End Sub
    Private Sub FILL_ITEM_CHANGED()
        txtcode.Text = ""
        Dim str As String = ""
        If dditemname.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            NewComboFill(ddlunit, "SELECT u.UnitId,u.UnitName  FROM ITEM_MASTER i INNER JOIN  Unit u ON i.UnitTypeID = u.UnitTypeID where item_id=" & dditemname.SelectedValue & " And i.MasterCompanyId=" & VarMasterCompanyID & "")
            If ddlunit.Items.Count > 0 Then
                ddlunit.SelectedIndex = 0
            End If

            If ChkForReceiveIssItem.Checked = True Then
                str = "select DISTINCT VF.QualityId,VF.QualityName from PP_ProcessRawMaster PM inner join PP_ProcessRawTran PT " & _
                  "on PM.PRMid=PT.PRMid inner join IndentMaster IM on IM.IndentID=pt.Indentid " & _
                  "inner join V_FinishedItemDetail vf on Pt.Finishedid=vf.ITEM_FINISHED_ID " & _
                  "Where IM.IndentId=" & ddindent.SelectedValue & " and Vf.Item_Id=" & dditemname.SelectedValue & " And Vf.MasterCompanyId=" & VarMasterCompanyID & ""

                NewComboFill(dquality, str)

            Else
                NewComboFill(dquality, "SELECT DISTINCT VF.QualityId,VF.QualityName From IndentDetail ID,V_FinishedItemDetail VF " & _
                "Where ID.OFinishedId=VF.ITEM_FINISHED_ID And ID.IndentId=" & ddindent.SelectedValue & " And VF.ITEM_ID=" & dditemname.SelectedValue & " And VF.MasterCompanyId=" & VarMasterCompanyID & "")
            End If

        End If

    End Sub

    Private Sub dditemname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dditemname.SelectedIndexChanged
        FILL_ITEM_CHANGED()
    End Sub

    Private Sub FILL_QUANTITYCHANGE()
        If ChkForReceiveIssItem.Checked = True Then
            If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddindent.SelectedIndex <> -1 And Varcombovalue <> 0 Then


                NewComboFill(ddlshade, "SELECT DISTINCT dbo.ShadeColor.ShadecolorId, dbo.ShadeColor.ShadeColorName FROM   dbo.ITEM_PARAMETER_MASTER INNER JOIN " & _
                    "dbo.IndentDetail ON dbo.ITEM_PARAMETER_MASTER.ITEM_FINISHED_ID = dbo.IndentDetail.IFinishedId INNER JOIN  dbo.ShadeColor ON dbo.ITEM_PARAMETER_MASTER.SHADECOLOR_ID = dbo.ShadeColor.ShadecolorId " & _
                    "WHERE dbo.IndentDetail.IndentId =" & ddindent.SelectedValue & " and dbo.ITEM_PARAMETER_MASTER.Item_Id=" & dditemname.SelectedValue & " and dbo.ITEM_PARAMETER_MASTER.Quality_Id=" & dquality.SelectedValue & " And ITEM_PARAMETER_MASTER.MasterCompanyId=" & VarMasterCompanyID & "")

            End If
            'ElseIf ChkForReceiveAnyColor.Checked = True Then
            '    UtilityModule.ConditionalComboFill(ddlshade, "SELECT DISTINCT ShadecolorId,ShadeColorName FROM ShadeColor Where MasterCompanyId=" & Session("VarMasterCompanyID") & " Order By ShadeColorName", True, "Select ShadeColor")
        Else
            If ddindent.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddChallanNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then


                NewComboFill(ddlshade, " select Distinct Vf.ShadecolorId,Vf.ShadeColorName From Indentdetail ID inner Join V_FinishedItemDetail vf on ID.OFinishedId=vf.ITEM_FINISHED_ID " & _
                                                         "where ID.IndentId=" & ddindent.SelectedValue & " and Vf.QualityId=" & dquality.SelectedValue & " and LotNo in( " & _
                                                         "select PRT.LotNo From PP_ProcessRawMaster PRM inner join PP_ProcessRawTran PRT on PRM.PRMid=PRT.PRMid Where PRM.PRMid=" & ddChallanNo.SelectedValue & ")")


            End If


        End If


    End Sub

    Private Sub dquality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dquality.SelectedIndexChanged
        FILL_QUANTITYCHANGE()
    End Sub
    Private Sub fill_qty()
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, txtcode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            Item_finished_id = Varfinishedid
            hnfinishedid = Varfinishedid
            FillLotNo(Item_finished_id)
            If DDLotNo.Items.Count > 0 Then
                DDLotNo.SelectedIndex = 0
                If DDTagNo.Visible = True Then
                    FillTagNo(Item_finished_id)
                    If DDTagNo.Items.Count > 0 Then
                        DDTagNo.SelectedIndex = 0
                        txttagNo.Text = DDTagNo.Text
                    End If
                End If
            End If
            If DDOrderNo.Items.Count > 0 Then
                DDOrderNo.SelectedIndex = 0
                fill_Order_qty()
            End If

        End If

    End Sub

    Protected Sub FillLotNo(ByVal Varfinishedid As Integer)
        If ChkForReceiveIssItem.Checked = True Then
            NewComboFill(DDOrderNo, "Select Distinct ID.OrderId,LocalOrder+' / '+Customerorderno as OrderNo " & _
                    "From IndentDetail ID,OrderMaster OM Where OM.OrderId=ID.OrderId And IndentId=" & ddindent.SelectedValue & "")

            NewComboFill(DDLotNo, "Select Distinct PRT.LotNo,PRT.LotNo From IndentDetail ID,PP_ProcessRawtran PRT  " & _
               " Where ID.IndentId=PRT.IndentId And PRT.IndentId=" & ddindent.SelectedValue & " And PRMid=" & ddChallanNo.SelectedValue & " and PRT.finishedid=" & Varfinishedid & "")

        Else

            NewComboFill(DDOrderNo, "Select distinct PPC.OrderId,LocalOrder+' / '+customerorderno as OrderNo From PP_Consumption PPC inner join " & _
                "IndentDetail ID on ID.PPNO=PPC.PPID inner join IndentMaster IM on IM.IndentId=ID.IndentId inner join OrderMaster OM on OM.OrderId=PPC.OrderId inner join  " & _
                "PP_ProcessRawtran PRT on ID.IndentId=PRT.IndentId where PPC.FinishedId=" & Varfinishedid & " and PRT.IndentId=" & ddindent.SelectedValue & " And IM.MasterCompanyId=" & VarMasterCompanyID & "")


            NewComboFill(DDLotNo, "Select Distinct ID.LotNo,ID.LotNo From IndentDetail ID,PP_ProcessRawtran PRT " & _
                "Where ID.IndentId=PRT.IndentId And PRT.IndentId=" & ddindent.SelectedValue & " And PRMid=" & ddChallanNo.SelectedValue & " And  " & _
                "ID.OFinishedid=" & Varfinishedid & "")
        End If

    End Sub

    Protected Sub FillTagNo(ByVal Varfinishedid As Integer)
        If ddindent.SelectedIndex <> -1 And ddChallanNo.SelectedIndex <> -1 And DDLotNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If ChkForReceiveIssItem.Checked = True Then
                If Varcarpetcompany = 1 Then
                    NewComboFill(DDTagNo, "Select Distinct PRT.TagNo,PRT.TagNo From IndentDetail ID,PP_ProcessRawtran PRT " & _
                 "Where ID.IndentId=PRT.IndentId And PRT.IndentId=" & ddindent.SelectedValue & " And PRMid=" & ddChallanNo.SelectedValue & " and PRT.LotNo='" + DDLotNo.Text & "' and ID.Lotno='" & DDLotNo.Text & "' and PRT.Finishedid=" & Varfinishedid & "")
                Else
                    NewComboFill(DDTagNo, "Select Distinct ID.TagNo,ID.TagNo From IndentDetail ID,PP_ProcessRawtran PRT " & _
                                     "Where ID.IndentId=PRT.IndentId And PRT.IndentId=" & ddindent.SelectedValue & " And PRMid=" & ddChallanNo.SelectedValue & " and PRT.LotNo='" + DDLotNo.Text & "' and ID.Lotno='" & DDLotNo.Text & "'")
                End If


            Else
                NewComboFill(DDTagNo, "Select Distinct ID.TagNo,ID.TagNo From IndentDetail ID,PP_ProcessRawtran PRT " & _
                    "Where ID.IndentId=PRT.IndentId And PRT.IndentId=" & ddindent.SelectedValue & " And PRMid=" & ddChallanNo.SelectedValue & " And ID.OFinishedid=" & Varfinishedid & " and ID.Lotno='" & DDLotNo.Text & "'")
            End If
        End If

    End Sub

    Private Sub fill_Order_qty()
        TxtIndentQty.Text = "0"
        TxtIssueQty.Text = "0"
        txtprerec.Text = "0"
        txtrec.Text = ""

        If DDOrderNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, txtcode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            hnfinishedid = Varfinishedid
            Dim arr(13) As SqlParameter
            arr(0) = New SqlParameter("@IndentID", SqlDbType.Int)
            arr(1) = New SqlParameter("@PRMID", SqlDbType.Int)
            arr(2) = New SqlParameter("@FinishedID", SqlDbType.Int)
            arr(3) = New SqlParameter("@IndentQty", SqlDbType.Float)
            arr(4) = New SqlParameter("@IssueQty", SqlDbType.Float)
            arr(5) = New SqlParameter("@RecQty", SqlDbType.Float)
            arr(6) = New SqlParameter("@LotNo", SqlDbType.NVarChar, 50)
            arr(7) = New SqlParameter("@VarReceiveIssItemFlag", SqlDbType.Int)
            arr(8) = New SqlParameter("@RetQty", SqlDbType.Float)
            arr(9) = New SqlParameter("@TagNo", SqlDbType.VarChar, 50)
            arr(10) = New SqlParameter("@challanwiserec", SqlDbType.Float)
            arr(10).Direction = ParameterDirection.Output
            arr(11) = New SqlParameter("@OFInishedid", SqlDbType.Int)
            arr(12) = New SqlParameter("@Moisture", SqlDbType.Int)
            arr(12).Direction = ParameterDirection.Output

            arr(0).Value = ddindent.SelectedValue
            arr(1).Value = ddChallanNo.SelectedValue
            arr(2).Value = Varfinishedid
            arr(3).Direction = ParameterDirection.Output
            arr(4).Direction = ParameterDirection.Output
            arr(5).Direction = ParameterDirection.Output
            arr(8).Direction = ParameterDirection.Output
            arr(6).Value = IIf(DDLotNo.Visible = True, DDLotNo.SelectedValue, "Without Lot No")
            If ChkForReceiveIssItem.Checked = True Then
                arr(7).Value = 1
                'ElseIf ChkForReceiveAnyColor.Checked = True Then
                '    arr(7).Value = 2
            Else
                arr(7).Value = 0
            End If

            arr(9).Value = IIf(DDTagNo.Visible = True And DDTagNo.Items.Count > 0, DDTagNo.Text, "Without Tag No")
            Dim oFinishedid As Integer = 0
            If DDRECSHADE.Visible = True And ChkForReceiveIssItem.Checked = True Then
                oFinishedid = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, txtcode.Text, DDRECSHADE.SelectedValue, 0, "", VarMasterCompanyID)
            End If
            arr(11).Value = oFinishedid
            SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, "PRO_PP_Indent_Iss_Rec_Qty", arr)
            TxtIndentQty.Text = arr(3).Value.ToString()
            TxtIssueQty.Text = arr(4).Value.ToString()
            txtprerec.Text = arr(5).Value.ToString()
            txtprerec.Text = arr(5).Value.ToString()
            TxtMoisture.Text = arr(12).Value.ToString()


            Dim challanwiserec As Double = CType(arr(10).Value, Double)
            If ChkForReceiveIssItem.Checked = True Then
                txtpending.Text = Math.Round((Convert.ToDouble(TxtIssueQty.Text) - Convert.ToDouble(txtprerec.Text)), 2).ToString()
            Else
                txtpending.Text = Math.Round((Convert.ToDouble(TxtIndentQty.Text) - Convert.ToDouble(txtprerec.Text)), 2).ToString()
            End If

            txtrec.Focus()
            ''  txtretrn.Text = arr(8).Value.ToString()
        Else

            txtrec.Text = ""
            txtprerec.Text = ""
        End If

    End Sub

    Private Sub DDOrderNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDOrderNo.SelectedIndexChanged
        fill_Order_qty()
    End Sub

    Protected Sub Check_Qty()
        Dim LotNo, TagNo As String
        LotNo = IIf(DDLotNo.Visible = True And DDLotNo.Items.Count > 0, DDLotNo.Text, "Without Lot No")
        TagNo = IIf(DDTagNo.Visible = True And DDTagNo.Items.Count > 0, DDTagNo.Text, "Without Tag No")
        Dim varpendingqtytorec As Double = 0
        Dim VarRecQty As Double = If(txtrec.Text = "", 0, Convert.ToDouble(txtrec.Text)) - If(TxtBellWeight.Text = "", 0, Convert.ToDouble(TxtBellWeight.Text))
        Dim VarIndentQty As Double = If(TxtIndentQty.Text = "", 0, Convert.ToDouble(TxtIndentQty.Text))
        Dim VarReturnQty As Double = 0
        Dim VarPendingQty As Double = If(txtpending.Text = "", 0, Convert.ToDouble(txtpending.Text))
        Dim PercentageExecssQtyForIndentRawRec As Double = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, "Select PercentageExecssQtyForIndentRawRec From MasterSetting"))

        If ChkForReceiveIssItem.Checked = False Then
            Dim param(9) As SqlParameter
            param(0) = New SqlParameter("@indentid", ddindent.SelectedValue)
            param(1) = New SqlParameter("@ofinishedid", hnfinishedid)
            param(2) = New SqlParameter("@Lotno", LotNo)
            param(3) = New SqlParameter("@Tagno", TagNo)
            param(4) = New SqlParameter("@issprmid", ddChallanNo.SelectedValue)
            param(5) = New SqlParameter("@pendingqty", SqlDbType.Decimal)
            param(5).Direction = ParameterDirection.Output
            param(5).Scale = 3
            param(5).Precision = 18
            param(6) = New SqlParameter("@Receiveqty", SqlDbType.Decimal)
            param(6).Direction = ParameterDirection.Output
            param(6).Scale = 3
            param(6).Precision = 18
            SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, "Pro_getPendingIssqtytoRec", param)
            VarRecQty = VarRecQty + Convert.ToDouble(param(6).Value)
            varpendingqtytorec = Convert.ToDouble(param(5).Value)
            varpendingqtytorec = varpendingqtytorec + (varpendingqtytorec * PercentageExecssQtyForIndentRawRec / 100)

            If varpendingqtytorec < If(txtrec.Text = "", 0, Convert.ToDouble(txtrec.Text)) - If(TxtBellWeight.Text = "", 0, Convert.ToDouble(TxtBellWeight.Text)) Then
                MsgBox("Recieve qty must be less than or equal to issue qty")
                txtrec.Text = ""
                'txtrec.Focus()
                Return
            Else
                VarRecQty = If(txtrec.Text = "", 0, Convert.ToDouble(txtrec.Text)) - If(TxtBellWeight.Text = "", 0, Convert.ToDouble(TxtBellWeight.Text))
                VarIndentQty = If(TxtIndentQty.Text = "", 0, Convert.ToDouble(TxtIndentQty.Text))
                VarPendingQty = If(txtpending.Text = "", 0, Convert.ToDouble(txtpending.Text))
                VarIndentQty = Math.Round(VarIndentQty * PercentageExecssQtyForIndentRawRec / 100, 3)
                If VarRecQty > VarPendingQty + VarIndentQty Then
                    MsgBox("Recieve qty must be less than or equal to Pqty")
                    txtrec.Text = ""
                    'txtrec.Focus()
                    Return
                End If
            End If
        Else
            VarIndentQty = Math.Round(VarIndentQty * PercentageExecssQtyForIndentRawRec / 100, 3)
            If VarRecQty > VarPendingQty + VarIndentQty Then
                MsgBox("Recieve qty must be less than or equal to issue qty")
                txtrec.Text = ""
                'txtrec.Focus()
                Return
            End If
        End If
        If varDyingautoloss = "1" Then
            FillLossQty()
        End If
    End Sub

    Protected Sub FillLossQty()
        Dim VarRecQty As Double = If(txtrec.Text = "", 0, Convert.ToDouble(txtrec.Text)) - If(TxtBellWeight.Text = "", 0, Convert.ToDouble(TxtBellWeight.Text))

        Dim VarRetQty As Double = 0
        VarRecQty = VarRecQty - VarRetQty
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            Try
                Dim ItemFinishedId As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, txtcode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
                Dim str As String = "Select LossPercent From IndentDetail where IndentId=" & ddindent.SelectedValue
                'If ChkForReceiveAnyColor.Checked <> True Then
                '    str = str & " And OFinishedid=" + ItemFinishedId
                'End If
                str = str & " And OFinishedid=" & ItemFinishedId

                Dim LossPercent As Double = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, str))
                If LossPercent > 0 Then
                    TxtLoss.Text = Math.Round(LossPercent / 100 * VarRecQty, 3).ToString()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Private Sub ChkForReceiveIssItem_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkForReceiveIssItem.CheckedChanged
        If varTagNowise = 1 Then
            chkchangeTagno.Visible = True
        End If
        chkchangeTagno.Checked = False
        ReceiveIssItemCheckedChanged()

        If ChkForReceiveIssItem.Checked = True Then
            LblColorShade.Text = "UNDYED COLOR"
            lblrecshade.Visible = True
            DDRECSHADE.Visible = True
            chkchangeTagno.Visible = False
        Else
            LblColorShade.Text = "SHADE_COLOR"
            lblrecshade.Visible = False
            DDRECSHADE.Visible = False
        End If

    End Sub

    Private Sub dGORDER_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGORDER.CellContentClick
        Dim category As String = dGORDER.Item("lblcategoryid", dGORDER.CurrentRow.Index).Value
        Dim Item As String = dGORDER.Item("lblitem_id", dGORDER.CurrentRow.Index).Value
        Dim Quality As String = dGORDER.Item("lblQualityid", dGORDER.CurrentRow.Index).Value
        Dim Color As String = dGORDER.Item("lblColorid", dGORDER.CurrentRow.Index).Value
        Dim design As String = dGORDER.Item("lbldesignid", dGORDER.CurrentRow.Index).Value
        Dim shape As String = dGORDER.Item("lblshapeid", dGORDER.CurrentRow.Index).Value
        Dim shadecolor As String = dGORDER.Item("lblshadecolorid", dGORDER.CurrentRow.Index).Value
        Dim size As String = dGORDER.Item("lblsizeid", dGORDER.CurrentRow.Index).Value
        Dim Qty As String = dGORDER.Item("lblqty", dGORDER.CurrentRow.Index).Value
        Dim RecQty As String = dGORDER.Item("balqty", dGORDER.CurrentRow.Index).Value
        Dim unitid As String = dGORDER.Item("lblunitid", dGORDER.CurrentRow.Index).Value
        Dim lbllotno As String = dGORDER.Item("lotno", dGORDER.CurrentRow.Index).Value
        Dim lbltagno As String = dGORDER.Item("tagno", dGORDER.CurrentRow.Index).Value
        Dim lblfinishedid As String = dGORDER.Item("lblfinished", dGORDER.CurrentRow.Index).Value
        If ddCatagory.Visible = True Then
            ddCatagory.SelectedValue = category
            ddlcategorycange()
        End If

        If dditemname.Visible = True Then
            dditemname.SelectedValue = Item
            FILL_ITEM_CHANGED()
        End If

        If dquality.Visible = True Then
            dquality.SelectedValue = Quality
            FILL_QUANTITYCHANGE()
        End If

        If ddlshade.Visible = True Then
            ddlshade.SelectedValue = shadecolor
        End If
        ddlunit.SelectedValue = unitid
        FillLotNo(Convert.ToInt32(lblfinishedid))

        If DDOrderNo.Items.Count > 0 Then
            DDOrderNo.SelectedIndex = 0
        End If


        DDLotNo.SelectedValue = lbllotno
        DDLotNo_SelectedIndexChanged(sender, e)


        If DDTagNo.Visible = True Then

            DDTagNo.SelectedValue = lbltagno
            txttagNo.Text = DDTagNo.Text
            DDTagNo_SelectedIndexChanged(sender, e)

        End If

        If DDLotNo.Visible = False Then
            fill_Order_qty()
        End If

    End Sub

    Private Sub DDLotNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDLotNo.SelectedIndexChanged
        If DDTagNo.Visible = True Then

            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, txtcode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            hnfinishedid = Varfinishedid
            FillTagNo(Varfinishedid)
            If DDTagNo.Items.Count > 0 Then
                DDTagNo.SelectedIndex = 0
                txttagNo.Text = DDTagNo.Text
            End If
        End If
        If DDTagNo.Visible = False Then
            fill_Order_qty()
        End If
    End Sub

    Private Sub DDTagNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTagNo.SelectedIndexChanged
        fill_Order_qty()
    End Sub

    Private Sub txtidnt_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtidnt.KeyDown

        If txtidnt.Text <> "" And e.KeyCode = Keys.Enter Then
            Try
                Dim str As String = "Select Distinct IM.IndentID,IM.CompanyId,IM.PartyId,IM.ProcessID From IndentMaster IM,PP_ProcessRawTran PPT Where IM.IndentID=PPT.IndentID And IM.IndentNo='" & txtidnt.Text & "' ANd IM.MasterCompanyId=" & VarMasterCompanyID & ""
                If chkcomplete.Checked = True Then
                    str = str & " and Im.status='Complete'"
                Else
                    str = str & " and Im.status='Pending'"
                End If

                Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

                If ds.Tables(0).Rows.Count > 0 Then
                    ddCompName.SelectedValue = ds.Tables(0).Rows(0)("CompanyId").ToString()
                    ddProcessName.SelectedValue = ds.Tables(0).Rows(0)("ProcessID").ToString()
                    ProcessSelectedChange()
                    ddempname.SelectedValue = ds.Tables(0).Rows(0)("PartyId").ToString()
                    EmpolyeeSelectedChange()
                    ddindent.SelectedValue = ds.Tables(0).Rows(0)("IndentID").ToString()
                    IndentSelectedChange()
                    If ddChallanNo.Items.Count > 0 Then
                        ddChallanNo.SelectedIndex = 0
                        ChallanNoSelectedChange()
                        If ChkEdit.Checked = True Then
                            If ddPartyChallanNo.Items.Count > 0 Then
                                ddPartyChallanNo.SelectedIndex = 0
                                PartyChallanNoSelectedChenge()
                            End If
                        End If

                        If ddCatagory.Items.Count > 0 Then
                            ddCatagory.SelectedIndex = 0
                            ddlcategorycange()
                        End If
                    End If
                Else
                    MsgBox("IndentNo does not exists or Indent is complete...........")

                    If ddChallanNo.SelectedIndex > 0 Then
                        ddChallanNo.SelectedIndex = -1
                        ddChallanNo_SelectedIndexChanged(ddChallanNo, e)
                    End If

                    txtidnt.Text = ""
                    txtidnt.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub
    Public Function validate1() As Boolean
        Dim str As String = Nothing
        Dim validate As Boolean = True
        Try
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, txtcode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            Dim VarLotNo As String = If(DDLotNo.Visible = True, DDLotNo.SelectedValue, "Without Lot No")
            Dim TagNo As String = If(DDTagNo.Visible = True, IIf(txttagNo.Text = "", "Without Tag No", txttagNo.Text), "Without Tag No")
            Dim VarReceiveIssItem As Integer = If(ChkForReceiveIssItem.Checked = True, 1, 0)

            If VarBINNOWISE = "1" And VarCHECKBINCONDITION = "1" Then
                Dim arr(10) As SqlParameter
                arr(0) = New SqlParameter("@BinNo", ddbinno.Text)
                arr(1) = New SqlParameter("@godownid", ddgodown.SelectedValue)
                arr(2) = New SqlParameter("@ItemFinishedid", Varfinishedid)
                arr(3) = New SqlParameter("@QTY", Val(txtrec.Text) - IIf(TxtBellWeight.Text = "", "0", TxtBellWeight.Text))
                arr(4) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                arr(4).Direction = ParameterDirection.Output
                arr(5) = New SqlParameter("@TagNo", TagNo)
                arr(6) = New SqlParameter("@LotNo", VarLotNo)
                SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, "PRO_BINNOVALIDATE", arr)
                If arr(4).Value.ToString() <> "" Then
                    MsgBox(arr(4).Value.ToString())
                    validate = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return validate
    End Function

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        ''*************
        If Validcombobox(ddCompName) = False Then Exit Sub
        If Validcombobox(ddProcessName) = False Then Exit Sub
        If Validcombobox(ddempname) = False Then Exit Sub
        If Validcombobox(ddindent) = False Then Exit Sub
        If Validcombobox(ddChallanNo) = False Then Exit Sub
        If ddPartyChallanNo.Visible = True Then
            If Validcombobox(ddPartyChallanNo) = False Then Exit Sub
        End If
        If Validcombobox(ddCatagory) = False Then Exit Sub
        If Validcombobox(dditemname) = False Then Exit Sub
        If Validcombobox(dquality) = False Then Exit Sub
        If Validcombobox(ddlshade) = False Then Exit Sub
        If DDRECSHADE.Visible = True Then
            If Validcombobox(DDRECSHADE) = False Then Exit Sub
        End If
        If Validcombobox(DDOrderNo) = False Then Exit Sub
        If Validcombobox(ddgodown) = False Then Exit Sub
        If Validcombobox(ddlunit) = False Then Exit Sub

        If ddbinno.Visible = True Then
            If Validcombobox(ddbinno) = False Then Exit Sub
        End If

        If DDLotNo.Visible = True Then
            If Validcombobox(DDLotNo) = False Then Exit Sub
        End If
        If DDTagNo.Visible = True Then
            If Validcombobox(DDTagNo) = False Then Exit Sub
        End If
        If Val(txtrec.Text) = 0 And Val(TxtLoss.Text) = 0 Then
            If Validtxtbox(txtrec) = False Then Exit Sub
        End If
        If TxtMoisture.Visible = True Then
            If Validtxtbox(TxtMoisture) = False Then Exit Sub
        End If

        ''************
        If validate1() = False Then Exit Sub
        If ChkForReceiveIssItem.Checked = True Then
            CheckIssRecPendingqty()
        Else
            Check_Qty()
        End If
        If TxtBellWeight.Text = "" Then
            TxtBellWeight.Text = "0"
        End If

        save_detail(sender)
    End Sub

    Protected Sub save_detail(ByRef sender)
        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If
        Dim tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim arr(51) As SqlParameter
            arr(0) = New SqlParameter("@prmid", SqlDbType.Int)
            arr(1) = New SqlParameter("@companyid", SqlDbType.Int)
            arr(2) = New SqlParameter("@empid", SqlDbType.Int)
            arr(3) = New SqlParameter("@processid", SqlDbType.Int)
            arr(4) = New SqlParameter("@issuedate", SqlDbType.DateTime)
            arr(5) = New SqlParameter("@prtid", SqlDbType.Int)
            arr(6) = New SqlParameter("@finishedId", SqlDbType.Int)
            arr(7) = New SqlParameter("@godownId", SqlDbType.Int)
            arr(8) = New SqlParameter("@RecQuantity", SqlDbType.Float)
            arr(9) = New SqlParameter("@indentid", SqlDbType.Int)
            arr(10) = New SqlParameter("@UnitId", SqlDbType.Int)
            arr(11) = New SqlParameter("@IssPrmID", SqlDbType.Int)
            arr(12) = New SqlParameter("@IssPrtID", SqlDbType.Int)
            arr(13) = New SqlParameter("@ID", SqlDbType.Int)
            arr(14) = New SqlParameter("@GatePass", SqlDbType.NVarChar, 50)
            arr(15) = New SqlParameter("@lotno", SqlDbType.NVarChar, 50)
            arr(16) = New SqlParameter("@challanno", SqlDbType.NVarChar, 50)
            arr(17) = New SqlParameter("@retqty", SqlDbType.Int)
            arr(18) = New SqlParameter("@OrderId", SqlDbType.Int)
            arr(19) = New SqlParameter("@Finish_Type_Id", SqlDbType.Int)
            arr(20) = New SqlParameter("@LossQty", SqlDbType.Float)
            arr(21) = New SqlParameter("@GateInNo", SqlDbType.NVarChar, 50)
            arr(22) = New SqlParameter("@NoOFHank", SqlDbType.Int)
            arr(23) = New SqlParameter("@varuserid", SqlDbType.Int)
            arr(24) = New SqlParameter("@VarReceiveIssItem", SqlDbType.Int)
            arr(25) = New SqlParameter("@PenaltyDebitNote", SqlDbType.Float)
            arr(26) = New SqlParameter("@Remark", SqlDbType.NVarChar, 250)
            arr(27) = New SqlParameter("@Sizeflag", SqlDbType.Int)
            arr(28) = New SqlParameter("@Rate", SqlDbType.Float)
            arr(29) = New SqlParameter("@RateFlag", SqlDbType.Int)
            arr(30) = New SqlParameter("@DyingMatch", SqlDbType.VarChar, 20)
            arr(31) = New SqlParameter("@DyeingType", SqlDbType.VarChar, 20)
            arr(32) = New SqlParameter("@Dyeing", SqlDbType.VarChar, 20)
            arr(33) = New SqlParameter("@LShort", SqlDbType.Float)
            arr(34) = New SqlParameter("@Shrinkage", SqlDbType.Float)
            arr(35) = New SqlParameter("@TagNo", SqlDbType.VarChar, 50)
            arr(36) = New SqlParameter("@Rec_ofinishedid", SqlDbType.Int)

            arr(37) = New SqlParameter("@RecWithoutTag", SqlDbType.Int)
            arr(38) = New SqlParameter("@CheckedBy", SqlDbType.VarChar, 50)
            arr(39) = New SqlParameter("@Approvedby", SqlDbType.VarChar, 50)
            arr(40) = New SqlParameter("@BinNo", SqlDbType.VarChar, 50)
            arr(41) = New SqlParameter("@MANUALTAGENTRY", SqlDbType.Int)
            arr(42) = New SqlParameter("@MANUALTAGNo", SqlDbType.VarChar, 50)

            arr(43) = New SqlParameter("@BillNo", SqlDbType.VarChar, 50)
            arr(44) = New SqlParameter("@ReDyeingStatus", SqlDbType.Int)
            arr(45) = New SqlParameter("@Legalvendorid", SqlDbType.Int)
            arr(46) = New SqlParameter("@Msg", SqlDbType.VarChar, 100)
            arr(47) = New SqlParameter("@TagRemark", SqlDbType.VarChar, 200)
            arr(48) = New SqlParameter("@CustomerOrderId", SqlDbType.Int)
            arr(49) = New SqlParameter("@Moisture", SqlDbType.Float)
            arr(50) = New SqlParameter("@BellWeight", SqlDbType.Float)

            arr(0).Direction = ParameterDirection.InputOutput
            arr(0).Value = HPRMID
            arr(1).Value = ddCompName.SelectedValue
            arr(2).Value = ddempname.SelectedValue
            arr(3).Value = ddProcessName.SelectedValue
            arr(4).Value = txtdate.Text
            arr(5).Direction = ParameterDirection.InputOutput
            arr(5).Value = 0
            Dim ItemFinishedId As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, txtcode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID, tran)
            arr(6).Value = ItemFinishedId
            arr(7).Value = Convert.ToInt32(ddgodown.SelectedValue)
            arr(8).Value = IIf(txtrec.Text = "", 0, Convert.ToDouble(txtrec.Text)) - IIf(TxtBellWeight.Text = "", 0, Convert.ToDouble(TxtBellWeight.Text))
            arr(9).Value = ddindent.SelectedValue
            arr(10).Value = ddlunit.SelectedValue
            arr(11).Value = ddChallanNo.SelectedValue
            arr(12).Value = 0
            arr(13).Direction = ParameterDirection.Output
            arr(14).Direction = ParameterDirection.Output
            arr(15).Value = IIf(DDLotNo.Visible = True, DDLotNo.SelectedValue, "Without Lot No")
            arr(16).Direction = ParameterDirection.InputOutput
            arr(16).Value = TxtPartyChallanNo.Text.ToUpper()
            arr(17).Value = 0
            arr(18).Value = DDOrderNo.SelectedValue
            arr(19).Value = 0
            arr(20).Value = IIf(TxtLoss.Text = "", "0", TxtLoss.Text)
            arr(21).Value = TxtGateInNo.Text
            arr(21).Direction = ParameterDirection.InputOutput
            arr(22).Value = IIf(TxtNoOFHank.Text = "", "0", TxtNoOFHank.Text)
            arr(23).Value = varuserid
            arr(24).Value = If(ChkForReceiveIssItem.Checked = True, 1, 0)
            arr(25).Value = If(TxtPenalty.Text = "", "0", TxtPenalty.Text)
            arr(26).Value = txtremarks.Text
            arr(27).Value = 0
            arr(28).Value = If(TxtRate.Visible = True And TxtRate.Text = "", "0", If(TxtRate.Text = "", "0", TxtRate.Text))
            arr(29).Value = If(ChkForWithoutRate.Checked = True, 1, 0)
            arr(30).Value = ""
            arr(31).Value = ""
            arr(32).Value = ""
            arr(33).Value = 0
            arr(34).Value = 0
            Dim TagNo As String = ""
            TagNo = If(DDTagNo.Visible = True, DDTagNo.Text, "Without Tag No")
            arr(35).Value = TagNo
            arr(36).Value = IIf(DDRECSHADE.Visible = True, DDRECSHADE.SelectedValue, "0")
            arr(37).Value = 0
            arr(38).Value = txtcheckedby.Text
            arr(39).Value = txtapprovedby.Text
            arr(40).Value = IIf(ddbinno.Visible = True, ddbinno.Text, "")
            arr(41).Value = IIf(chkchangeTagno.Checked = True, 1, 0)
            arr(42).Value = IIf(txttagNo.Text = "", "Without Tag No", txttagNo.Text)

            arr(43).Value = ""
            arr(44).Value = 0
            arr(45).Value = 0
            arr(46).Direction = ParameterDirection.Output
            arr(47).Value = ""
            arr(48).Value = 0
            arr(49).Value = IIf(TxtMoisture.Visible = True, TxtMoisture.Text, "0")
            arr(50).Value = IIf(TxtBellWeight.Text = "", "0", TxtBellWeight.Text)

            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[PRO_PP_PRM_recieve]", arr)

            If (Convert.ToInt32(arr(5).Value) = 0) Then
                tran.Rollback()
                Return
            End If

            HPRMID = arr(0).Value.ToString()
            TxtPartyChallanNo.Text = arr(16).Value.ToString()
            TxtGateInNo.Text = arr(21).Value.ToString()
            lblsrno.Text = "Sr No. Generated. " & arr(0).Value.ToString()
            Dim RecQty As Double = 0, Lshort As Double = 0, Shrinkage As Double = 0
            RecQty = If(txtrec.Text = "", 0, Convert.ToDouble(txtrec.Text)) - If(TxtBellWeight.Text = "", 0, Convert.ToDouble(TxtBellWeight.Text))

            RecQty = RecQty - (Lshort + Shrinkage)

            If chkchangeTagno.Checked = True Then
                TagNo = txttagNo.Text
            End If

            If btnsave.Text = "Update" Then
                ' UtilityModule.StockStockTranTableUpdate2(ItemFinishedId, Convert.ToInt32(ddgodown.SelectedValue), Convert.ToInt32(ddCompName.SelectedValue), arr(15).Value.ToString(), Convert.ToDouble(If(txtrec.Text = "", "0", txtrec.Text)), txtdate.Text.ToString(), txtdate.Text.ToString(), "pp_processrectran", Convert.ToInt32(arr(5).Value), tran, 1, True, 1, True, Convert.ToDouble(Session("issueqty")), 0, unitid:=Convert.ToInt16(ddlunit.SelectedValue))
            Else
                StockStockTranTableUpdate(ItemFinishedId, Convert.ToInt32(ddgodown.SelectedValue), Convert.ToInt32(ddCompName.SelectedValue), arr(15).Value.ToString(), RecQty, txtdate.Text.ToString(), DateTime.Now.ToString("dd-MMM-yyyy"), "pp_processrectran", Convert.ToInt32(arr(5).Value), tran, 1, True, 1, 0, unitid:=Convert.ToInt16(ddlunit.SelectedValue), TagNo:=TagNo, BinNo:=IIf(ddbinno.Visible = True, ddbinno.Text, ""))
            End If

            DetailID = arr(5).Value
            masterID = arr(0).Value
            ' QCSAVE(tran, Convert.ToInt32(arr(0).Value), Convert.ToInt32(arr(5).Value))
            tran.Commit()
            txtcode.Text = ""
            txtremarks.Text = ""
            'txtprerec.Text = ""
            'txtpending.Text = ""
            txtrec.Text = ""
            TxtLoss.Text = ""
            TxtPenalty.Text = ""
            DDLotNo_SelectedIndexChanged(sender, New EventArgs())
            TxtBellWeight.Text = ""
            'txtLShort.Text = ""
            'txtshrinkage.Text = ""
            'DDDyingType.SelectedItem.Text = ""
            'DDDyeingMatch.SelectedItem.Text = ""
            'DDDyeing.SelectedItem.Text = ""
            'If DDLotNo.Visible = True Then
            '    DDLotNo.SelectedIndex = 0
            'End If

            'If dsn.Visible = True Then
            '    dddesign.SelectedIndex = 0
            'End If

            'If clr.Visible = True Then
            '    ddcolor.SelectedIndex = 0
            'End If

            'If shp.Visible = True Then
            '    ddshape.SelectedIndex = 0
            'End If

            'If sz.Visible = True Then
            '    ddsize.SelectedIndex = 0
            'End If

            'If shd.Visible = True Then
            '    ddlshade.SelectedIndex = 0
            'End If

            'If DDTagNo.Visible = True Then
            '    DDTagNo.SelectedIndex = -1
            'End If

            btnsave.Text = "Save"
            txtidnt.Enabled = False
            Fill_Grid()
            fillorderdetail()
            'For i As Integer = 0 To grdqualitychk.Rows.Count - 1
            '    Dim chk As CheckBox = CType(grdqualitychk.Rows(i).FindControl("CheckBox1"), CheckBox)
            '    chk.Checked = False
            'Next
        Catch ex As Exception
            tran.Rollback()
            MsgBox(ex.Message)

        End Try
    End Sub

    Protected Sub CheckIssRecPendingqty()
        Dim LotNo, TagNo As String
        LotNo = If(DDTagNo.Visible = True AndAlso DDLotNo.Items.Count > 0, DDLotNo.Text, "Without Lot No")
        TagNo = If(DDTagNo.Visible = True AndAlso DDTagNo.Items.Count > 0, DDTagNo.Text, "Without Tag No")
        Dim varpendingqtytorec As Double = 0
        Dim PercentageExecssQtyForIndentRawRec As Double = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, "Select PercentageExecssQtyForIndentRawRec From MasterSetting"))
        Dim param(9) As SqlParameter
        param(0) = New SqlParameter("@indentid", ddindent.SelectedValue)
        param(1) = New SqlParameter("@ofinishedid", 0)
        param(2) = New SqlParameter("@Lotno", LotNo)
        param(3) = New SqlParameter("@Tagno", TagNo)
        param(4) = New SqlParameter("@issprmid", ddChallanNo.SelectedValue)
        param(5) = New SqlParameter("@pendingqty", SqlDbType.Decimal)
        param(5).Direction = ParameterDirection.Output
        param(5).Scale = 3
        param(5).Precision = 18
        param(6) = New SqlParameter("@Receiveqty", SqlDbType.Decimal)
        param(6).Direction = ParameterDirection.Output
        param(6).Scale = 3
        param(6).Precision = 18
        param(7) = New SqlParameter("@ifinishedid", hnfinishedid)
        SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, "Pro_getPendingIssqtytoRec", param)
        varpendingqtytorec = Convert.ToDouble(param(5).Value)
        varpendingqtytorec = varpendingqtytorec + (varpendingqtytorec * PercentageExecssQtyForIndentRawRec / 100)
        If varpendingqtytorec < If(txtrec.Text = "", 0, Convert.ToDouble(txtrec.Text)) - If(TxtBellWeight.Text = "", 0, Convert.ToDouble(TxtBellWeight.Text)) Then
            MsgBox("Recieve qty must be less than or equal to issue qty")
            txtrec.Text = ""
            txtrec.Focus()
            Return
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

                txtrec.Text = w_Weight.ToString()

            End If
        Catch ex As Exception
        End Try


    End Sub
    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()
    Private Sub txtrec_GotFocus(sender As Object, e As System.EventArgs) Handles txtrec.GotFocus

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

    Private Sub txtrec_LostFocus(sender As Object, e As System.EventArgs) Handles txtrec.LostFocus
        TxtLoss.Text = "0"
        If ChkForReceiveIssItem.Checked = False Then
            Check_Qty()
        ElseIf ChkForReceiveIssItem.Checked = True Then
            CheckIssRecPendingqty()
        End If
    End Sub

    Private Sub ddlshade_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddlshade.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            fill_qty()
            If DDRECSHADE.Visible = True Then
                NewComboFill(DDRECSHADE, " select Distinct ID.ofinishedid,Vf.ShadeColorName From Indentdetail ID inner Join V_FinishedItemDetail vf on ID.OFinishedId=vf.ITEM_FINISHED_ID " & _
                                                            " where ID.IndentId=" & ddindent.SelectedValue & " and Vf.QualityId=" & dquality.SelectedValue & " and LotNo in( " & _
                                                            " select PRT.LotNo From PP_ProcessRawMaster PRM inner join PP_ProcessRawTran PRT on PRM.PRMid=PRT.PRMid Where PRM.PRMid=" & ddChallanNo.SelectedValue & ")")
            End If
        End If


    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        If ChkEdit.Visible = True Then
            ChkEdit.Checked = False
        End If
        ddempname.SelectedIndex = -1
        ddindent.SelectedIndex = -1
        dGORDER.Rows.Clear()
        gvdetail.Rows.Clear()
        HPRMID = 0
        TxtGateInNo.Text = ""
        TxtPartyChallanNo.Text = ""
        txtcheckedby.Text = ""
        txtapprovedby.Text = ""
        txtrec.Text = System.DateTime.Now.ToString("dd-MMM-yyyy")
    End Sub

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim qry As String = "SELECT v.CATEGORY_NAME,v.ITEM_NAME,v.QualityName,v.DESCRIPTION,v.GodownName,v.RecQuantity,isnull(VR.RetQty,0) As RetQty,v.lotno,v.EmpName,v.CompanyName,v.gatepassno,v.indentno,v.EmpAddress," & _
        "v.EmpPhoneNo, v.EmpMobile, v.CompanyAddress, v.CompanyPhoneNo, v.CompanyFaxNo, v.TinNo, v.PRMid, v.Date, v.challanno, MastercompanyId, DyingMatch, DyeingType, Dyeing, V.LocalOrder, V.CustomerOrderNo, V.Buyercode, PROCESS_NAME, Rec_Iss_ItemFlag, RRRemark, Lshort, Shrinkage, V.TagNo, V.GateInNo, GSTIN, EMPGSTIN,Checkedby,Approvedby,od.customercode,od.OrderNo,od.Localorder,OD.Merchantname " & _
        "FROM   V_IndentRawRec  v left outer join V_IndentRawReturnQty VR On v.PRMid=VR.PRMid AND v.PRTid=VR.PRTid " & _
        " cross apply (select * From dbo.F_GetPPNo_OrderNo(v.PPNo)) OD   " & _
        "where v.PRMid = " & HPRMID & ""

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, qry)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\IndentRawRecNew.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\IndentRawRecNew.xsd")
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

    Private Sub gvdetail_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvdetail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then Exit Sub

            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim Tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim VarProcess_Issue_Detail_Id As Integer = gvdetail.Item("prtid", gvdetail.CurrentRow.Index).Value
                Dim _arrPara As SqlParameter() = New SqlParameter(4) {}
                _arrPara(0) = New SqlParameter("@PRTID", SqlDbType.Int)
                _arrPara(1) = New SqlParameter("@COUNT", SqlDbType.Int)
                _arrPara(2) = New SqlParameter("@Msg", SqlDbType.NVarChar, 250)
                _arrPara(3) = New SqlParameter("@Userid", SqlDbType.Int)
                _arrPara(4) = New SqlParameter("@Mastercompanyid", SqlDbType.Int)
                _arrPara(0).Value = VarProcess_Issue_Detail_Id
                If gvdetail.Rows.Count = 1 Then
                    _arrPara(1).Value = 1
                End If

                _arrPara(2).Direction = ParameterDirection.Output
                _arrPara(3).Value = varuserid
                _arrPara(4).Value = VarMasterCompanyID
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PP_PRM_RECEIVE_DELETE", _arrPara)
                Tran.Commit()
                Fill_Grid()
                MsgBox(_arrPara(2).Value.ToString())
            Catch ex As Exception
                Tran.Rollback()
                MsgBox(ex.Message)

            End Try
        End If
    End Sub
    Private Sub gvdetail_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvdetail.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            subformopen = 1
            If fnCheckTodayUpdateDelete() = True Then Exit Sub
            Updatedetails(gvdetail.CurrentRow.Index)
        End If
    End Sub
    Protected Sub Updatedetails(ByVal rowindex As Integer)
        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim VarProcess_Issue_Detail_Id As Integer = gvdetail.Item("prtid", rowindex).Value

            Dim _arrPara As SqlParameter() = New SqlParameter(6) {}
            _arrPara(0) = New SqlParameter("@PRTID", VarProcess_Issue_Detail_Id)
            _arrPara(1) = New SqlParameter("@Msg", SqlDbType.VarChar, 100)
            _arrPara(1).Direction = ParameterDirection.Output
            _arrPara(2) = New SqlParameter("@Userid", varuserid)
            _arrPara(3) = New SqlParameter("@Mastercompanyid", VarMasterCompanyID)
            _arrPara(4) = New SqlParameter("@Rate", Val(gvdetail.Item("gvdetailrate", rowindex).Value))
            _arrPara(5) = New SqlParameter("@Lossqty", Val(gvdetail.Item("gvdetaillossqty", rowindex).Value))
            _arrPara(6) = New SqlParameter("@Indentid", ddindent.SelectedValue)
            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PP_PRM_RECEIVE_UPDATE", _arrPara)
            Tran.Commit()

            Fill_Grid()
            MsgBox(_arrPara(1).Value.ToString())
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub txtrec_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtrec.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsave.Focus()
        End If
    End Sub
    Private Sub ddgodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddgodown.SelectedIndexChanged
        If ddgodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If ChkForReceiveIssItem.Checked = True Then
                Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, txtcode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
                If VarCHECKBINCONDITION = 1 Then
                    Module1.FillBinNO(ddbinno, ddgodown.SelectedValue, Varfinishedid, New_Edit:=0)
                Else
                    NewComboFill(ddbinno, "Select Distinct PRT.BInNo,PRT.BinNo From IndentDetail ID,PP_ProcessRawtran PRT  " & _
                   " Where ID.IndentId=PRT.IndentId And PRT.IndentId=" & ddindent.SelectedValue & " And PRMid=" & ddChallanNo.SelectedValue & " and PRT.finishedid=" & Varfinishedid & "")
                End If

                '' NewComboFill(ddbinno, "select BInId,BInNo From Binmaster Where GODOWNID=" & ddgodown.SelectedValue & "")
            Else
                If VarCHECKBINCONDITION = 1 Then
                    Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, txtcode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
                    Module1.FillBinNO(ddbinno, ddgodown.SelectedValue, Varfinishedid, New_Edit:=0)
                Else
                    NewComboFill(ddbinno, "select BInId,BInNo From Binmaster Where GODOWNID=" & ddgodown.SelectedValue & "")
                End If


            End If

        End If
    End Sub


    Private Sub frmindentrawreceive_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub chkchangeTagno_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkchangeTagno.CheckedChanged
        txttagNo.Enabled = False
        If chkchangeTagno.Checked = True Then
            txttagNo.Enabled = True
        End If

    End Sub

    Private Sub BtnComplete_Click(sender As System.Object, e As System.EventArgs) Handles BtnComplete.Click
        If Validcombobox(ddCompName) = False Then Exit Sub
        If Validcombobox(ddProcessName) = False Then Exit Sub
        If Validcombobox(ddempname) = False Then Exit Sub
        If Validcombobox(ddindent) = False Then Exit Sub
        SqlHelper.ExecuteNonQuery(Con, CommandType.Text, "Update IndentMaster Set Status = 'Complete' Where IndentID = " & ddindent.SelectedValue & "")
        MsgBox("Status update successfully")
        EmpolyeeSelectedChange()
    End Sub
End Class