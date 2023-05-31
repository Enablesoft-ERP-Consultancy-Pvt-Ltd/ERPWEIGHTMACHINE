Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class frmmottelingissue
    Dim hnid As Integer = "0"

    Private Sub frmsampleyarndyeing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select Distinct CI.CompanyId,CI.CompanyName from Companyinfo CI,Company_Authentication CA Where CI.CompanyId=CA.CompanyId And CA.UserId=" & varuserid & "  And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By CompanyName " & _
                           "select PROCESS_NAME_ID,Process_name From process_name_master  where Processtype=0 and Process_name in('Motteling','YARN OPENING+MOTTELING', 'HANK MAKING') and mastercompanyid=" & VarMasterCompanyID & " order by PROCESS_NAME " & _
                           "select Distinct ICM.CATEGORY_ID,ICM.CATEGORY_NAME from ITEM_CATEGORY_MASTER ICM inner join CategorySeparate cs on ICM.CATEGORY_ID=cs.Categoryid and cs.id=1 and ICM.MasterCompanyid=" & VarMasterCompanyID & " " & _
                           "select GoDownID,GodownName from GodownMaster where MasterCompanyid=" & VarMasterCompanyID & " order by GodownName " & _
                           "Select ConeType, ConeType From ConeMaster Order By SrNo "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(DDCompanyName, ds, 0)
        If DDCompanyName.Items.Count > 0 Then
            DDCompanyName.SelectedValue = VarCompanyID
            DDCompanyName.Enabled = False
        End If
        NewComboFillWithDs(DDProcessName, ds, 1)
        If DDProcessName.Items.Count > 0 Then DDProcessName.SelectedIndex = 0
        NewComboFillWithDs(DDCategory, ds, 2)
        NewComboFillWithDs(DDRcategory, ds, 2)
        NewComboFillWithDs(DDgodown, ds, 3)
        NewComboFillWithDs(DDconetype, ds, 4)

        If varTagNowise = "1" Then
            lbltagno.Visible = True
            DDTagNo.Visible = True
            lblrectagno.Visible = True
            txtrectagno.Visible = True
        End If
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If

        chkfillsame.Checked = True

    End Sub

    Private Sub DDProcessName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDProcessName.SelectedIndexChanged
        If DDProcessName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Select Case DDProcessName.Text.ToUpper()
                Case "YARN OPENING+MOTTELING"
                    lblconetype.Visible = True
                    DDconetype.Visible = True
                Case Else
                    lblconetype.Visible = False
                    DDconetype.Visible = False
                    DDconetype.SelectedIndex = -1
            End Select
            NewComboFill(DDPartyName, "Select EI.EmpId,EI.EmpName+case when isnull(Ei.empcode,'')<>'' then ' ['+ei.empcode+']' else '' end as Empname From EmpInfo EI inner join EmpProcess EP on EI.EmpId=EP.EmpId and EP.ProcessId=" & DDProcessName.SelectedValue & " Where EI.Blacklist = 0 order by empname")
        End If
    End Sub

    Private Sub DDCategory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDCategory.SelectedIndexChanged
        If DDCategory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim stritem As String = "select distinct IM.Item_Id,IM.Item_Name from  Item_Parameter_Master IPM  inner Join Item_Master IM on IM.Item_Id=IPM.Item_Id inner join Item_Category_Master ICM on ICM.Category_Id=IM.Category_Id where  IM.Category_Id=" & DDCategory.SelectedValue & " And IM.MasterCompanyId=" & VarMasterCompanyID & " order by IM.item_name"
            NewComboFill(DDItem, stritem)
            If chkfillsame.Checked = True Then
                DDRcategory.SelectedValue = DDCategory.SelectedValue
                DDRcategory_SelectedIndexChanged(sender, New EventArgs())
            End If

        End If
    End Sub

    Private Sub DDRcategory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDRcategory.SelectedIndexChanged
        If DDRcategory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim stritem As String = "select distinct IM.Item_Id,IM.Item_Name from  Item_Parameter_Master IPM  inner Join Item_Master IM on IM.Item_Id=IPM.Item_Id inner join Item_Category_Master ICM on ICM.Category_Id=IM.Category_Id where  IM.Category_Id=" & DDRcategory.SelectedValue & " And IM.MasterCompanyId=" & VarMasterCompanyID & " order by IM.item_name"
            NewComboFill(DDRitemName, stritem)
        End If
    End Sub

    Private Sub DDItem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDItem.SelectedIndexChanged
        If DDItem.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(ddUnit, "select Distinct U.UnitId,u.UnitName from Item_master IM inner join UNIT_TYPE_MASTER UT on IM.UnitTypeID=UT.UnitTypeID inner join Unit u on U.UnitTypeID=UT.UnitTypeID and Im.ITEM_ID=" & DDItem.SelectedValue & "")
            If ddUnit.Items.Count > 0 Then ddUnit.SelectedIndex = 0
            QDCSDDFill(DDQuality, DDColorShade, DDItem.SelectedValue)
            If chkfillsame.Checked = True Then
                DDRitemName.SelectedValue = DDItem.SelectedValue
                DDRitemName_SelectedIndexChanged(sender, New EventArgs())
            End If

        End If

    End Sub

    Private Sub QDCSDDFill(ByVal Quality As ComboBox, ByVal Shade As ComboBox, ByVal Itemid As Integer)
        Dim Str As String = "SELECT QUALITYID,QUALITYNAME FROM QUALITY WHERE ITEM_ID=" & Itemid & " And MasterCompanyId=" & VarMasterCompanyID & " Order By QUALITYNAME "
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, Str)
        NewComboFillWithDs(Quality, ds, 0)
        'NewComboFillWithDs(Shade, ds, 1)
    End Sub

    Private Sub DDRitemName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDRitemName.SelectedIndexChanged
        If DDRitemName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            QDCSDDFill(DDRquality, DDRShadecolor, DDRitemName.SelectedValue)
        End If

    End Sub

    Private Sub DDQuality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDQuality.SelectedIndexChanged
        If DDQuality.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDColorShade, "SELECT SHADECOLORID,SHADECOLORNAME FROM SHADECOLOR Where  MasterCompanyId=" & VarMasterCompanyID & " Order By SHADECOLORNAME ")
            If chkfillsame.Checked = True Then
                DDRquality.SelectedValue = DDQuality.SelectedValue
            End If
        End If
    End Sub

    Protected Sub FillLotno(ByVal varfinishedid As Integer)
        DDLotno.SelectedIndex = -1
        Dim str As String = ""
        str = "select Distinct LotNo,LotNo as LotNo1 From Stock Where ITEM_FINISHED_ID=" & varfinishedid & " and Companyid=" & DDCompanyName.SelectedValue & " and Godownid=" & DDgodown.SelectedValue & " And Round(Qtyinhand,3)>0 "
        'If DDBinNo.Visible = True Then
        '    str = str & " and BinNo='" & DDBinNo.Text & "'"
        'End If
        str = str & " order by LotNo1"
        NewComboFill(DDLotno, str)
        If DDLotno.Items.Count > 0 Then
            DDLotno.SelectedIndex = 0
            DDLotno_SelectedIndexChanged(DDLotno, New EventArgs())
        End If
    End Sub

    Private Sub DDLotno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDLotno.SelectedIndexChanged
        If DDItem.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDColorShade.SelectedIndex <> -1 And DDLotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, DDColorShade.SelectedValue, 0, "", VarMasterCompanyID)
            If DDTagNo.Visible = True Then
                FillTagno(Varfinishedid)
            Else
                FillstockQty(Varfinishedid)
            End If

            If chkfillsame.Checked = True Then
                txtreclotno.Text = DDLotno.Text
            End If

        End If
    End Sub

    Protected Sub FillstockQty(ByVal varfinishedid As Integer)
        Dim Lotno As String, TagNo As String = "", BinNo As String = ""
        Lotno = DDLotno.Text
        If DDTagNo.Visible = True Then
            TagNo = DDTagNo.Text
        Else
            TagNo = "Without Tag No"
        End If
        If DDBinNo.Visible = True Then
            BinNo = DDBinNo.Text
        End If

        lblstockqty.Text = Convert.ToString(getstockQty(DDCompanyName.SelectedValue, DDgodown.SelectedValue, Lotno, varfinishedid, TagNo, BinNo:=BinNo))
    End Sub

    Protected Sub FillTagno(ByVal varfinishedid As Integer)
        If DDCompanyName.SelectedIndex <> -1 And DDgodown.SelectedIndex <> -1 And DDLotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            DDTagNo.SelectedIndex = -1
            Dim str As String = ""

            str = "select Distinct Tagno,Tagno as Tagno1 From Stock Where ITEM_FINISHED_ID=" & varfinishedid & " and Companyid=" & DDCompanyName.SelectedValue & " and Godownid=" & DDgodown.SelectedValue & " And LotNo='" & DDLotno.Text & "' And Round(Qtyinhand,3)>0 "
            'If DDBinNo.Visible = True Then
            '    str = str & " and BinNo='" & DDBinNo.Text & "'"
            'End If
            str = str & " order by Tagno1"
            NewComboFill(DDTagNo, str)
            If DDTagNo.Items.Count > 0 Then
                DDTagNo.SelectedIndex = 0
                DDTagNo_SelectedIndexChanged(DDTagNo, New EventArgs())
            End If

        End If

    End Sub
    Private Sub DDTagNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTagNo.SelectedIndexChanged
        If DDItem.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDColorShade.SelectedIndex <> -1 And DDTagNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, DDColorShade.SelectedValue, 0, "", VarMasterCompanyID)
            If DDBinNo.Visible = True Then
                Dim str As String = "select Distinct BInNo,BinNo as BinNo1 From Stock Where ITEM_FINISHED_ID=" & Varfinishedid & " and Companyid=" & DDCompanyName.SelectedValue & " and Godownid=" & DDgodown.SelectedValue & " And Round(Qtyinhand,3)>0 and Lotno='" & DDLotno.Text & "'"
                If DDTagNo.Visible = True Then
                    str = str & " and TagNo='" & DDTagNo.Text & "'"
                Else
                    str = str & " and TagNo='Without Tag No'"
                End If
                str = str & "  order by BinNo1"
                Call NewComboFill(DDBinNo, str)
                If DDBinNo.Items.Count > 0 Then
                    DDBinNo.SelectedIndex = 0
                    DDBinNo_SelectedIndexChanged(sender, New EventArgs())
                End If

            Else
                FillstockQty(Varfinishedid)
            End If


            If chkfillsame.Checked = True Then
                txtrectagno.Text = DDTagNo.Text
            End If
        End If
    End Sub
    Private Sub DDgodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDgodown.SelectedIndexChanged
        If DDItem.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDColorShade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, DDColorShade.SelectedValue, 0, "", VarMasterCompanyID)
            'If DDBinNo.Visible = True Then
            '    Dim str As String = "select Distinct BInNo,BinNo as BinNo1 From Stock Where ITEM_FINISHED_ID=" & Varfinishedid & " and Companyid=" & DDCompanyName.SelectedValue & " and Godownid=" & DDgodown.SelectedValue & " And Round(Qtyinhand,3)>0 order by BinNo1"
            '    Call NewComboFill(DDBinNo, str)
            'Else
            '    FillLotno(Varfinishedid)
            'End If
            FillLotno(Varfinishedid)
        End If
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Validcombobox(DDCompanyName) = False Then Exit Sub
        If Validcombobox(DDProcessName) = False Then Exit Sub
        If Validcombobox(DDPartyName) = False Then Exit Sub
        If Validcombobox(DDCategory) = False Then Exit Sub
        If Validcombobox(DDItem) = False Then Exit Sub
        If Validcombobox(DDQuality) = False Then Exit Sub
        If Validcombobox(DDColorShade) = False Then Exit Sub
        If Validcombobox(ddUnit) = False Then Exit Sub
        If Validcombobox(DDgodown) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        If Validcombobox(DDLotno) = False Then Exit Sub
        If DDTagNo.Visible = True Then
            If Validcombobox(DDTagNo) = False Then Exit Sub
        End If
        If Validcombobox(DDRcategory) = False Then Exit Sub
        If Validcombobox(DDRitemName) = False Then Exit Sub
        If Validcombobox(DDRquality) = False Then Exit Sub
        If Validcombobox(DDRShadecolor) = False Then Exit Sub
        If DDconetype.Visible = True Then
            If Validcombobox(DDconetype) = False Then Exit Sub
        End If

        If Validtxtbox(txtrecqty) = False Then Exit Sub
        If Validtxtbox(txtrate) = False Then Exit Sub


        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim arr As SqlParameter() = New SqlParameter(36) {}

            arr(0) = New SqlParameter("@ID", SqlDbType.Int)
            arr(0).Direction = ParameterDirection.InputOutput
            arr(0).Value = hnid
            arr(1) = New SqlParameter("@companyId", DDCompanyName.SelectedValue)
            arr(2) = New SqlParameter("@Processid", DDProcessName.SelectedValue)
            arr(3) = New SqlParameter("@empid", DDPartyName.SelectedValue)
            arr(4) = New SqlParameter("@IndentNo", SqlDbType.VarChar, 50)
            arr(4).Direction = ParameterDirection.InputOutput
            arr(4).Value = TxtIndentNo.Text
            arr(5) = New SqlParameter("@IssueDate", TxtDate.Text)
            arr(6) = New SqlParameter("@ReqDate", TxtReqDate.Text)
            arr(7) = New SqlParameter("@Mastercompanyid", VarMasterCompanyID)
            arr(8) = New SqlParameter("@DetailId", SqlDbType.Int)
            arr(8).Value = 0
            Dim varfinishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, DDColorShade.SelectedValue, 0, "", VarMasterCompanyID, Tran)
            arr(9) = New SqlParameter("@Ifinishedid", varfinishedid)
            arr(10) = New SqlParameter("@Iflagsize", 0)
            arr(11) = New SqlParameter("@unitid", ddUnit.SelectedValue)
            arr(12) = New SqlParameter("@godownid", DDgodown.SelectedValue)
            arr(13) = New SqlParameter("@LotNo", DDLotno.Text)
            arr(14) = New SqlParameter("@TagNo", If(DDTagNo.Visible = False, "Without Tag No", DDTagNo.Text))
            Dim varRfinishedid As Integer = getItemFinishedId(DDRitemName.SelectedValue, DDRquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, DDRShadecolor.SelectedValue, 0, "", VarMasterCompanyID, Tran)
            arr(15) = New SqlParameter("@Rfinishedid", varRfinishedid)
            arr(16) = New SqlParameter("@Rflagsize", 0)
            arr(17) = New SqlParameter("@RecLotNo", If(txtreclotno.Text = "", "Without Lot No", txtreclotno.Text))
            arr(18) = New SqlParameter("@RecTagNo", If(DDTagNo.Visible = False, "Without Tag No", (If(txtrectagno.Text = "", "Without Tag No", txtrectagno.Text))))
            arr(19) = New SqlParameter("@issueqty", If(txtrecqty.Text = "", "0", txtrecqty.Text))
            arr(20) = New SqlParameter("@Rate", If(txtrate.Text = "", "0", txtrate.Text))
            arr(21) = New SqlParameter("@userid", varuserid)
            arr(22) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            arr(22).Direction = ParameterDirection.Output
            arr(23) = New SqlParameter("@Remark", (txtremark.Text).Trim())
            arr(24) = New SqlParameter("@BinNo", If(DDBinNo.Visible = True, DDBinNo.Text, ""))
            arr(25) = New SqlParameter("@Customerid", If(DDcustcode.SelectedIndex <> -1, DDcustcode.SelectedValue, "0"))
            arr(26) = New SqlParameter("@Orderid", If(DDorderno.SelectedIndex <> -1, DDorderno.SelectedValue, "0"))
            arr(27) = New SqlParameter("@Conetype", If(DDconetype.Visible = False, "", DDconetype.Text))
            arr(28) = New SqlParameter("@BellWt", If(TxtBellWt.Text = "", "0", TxtBellWt.Text))
            arr(29) = New SqlParameter("@PlyType", If(DDPlyType.Visible = False, "", DDPlyType.Text))
            arr(30) = New SqlParameter("@TransportType", If(DDTransportType.Visible = False, "", DDTransportType.Text))
            arr(31) = New SqlParameter("@Moisture", IIf(TxtMoisture.Visible = False, 0, If(TxtMoisture.Text = "", "0", TxtMoisture.Text)))
            arr(32) = New SqlParameter("@VEHICLENO", TxtVehicleNo.Text)
            arr(33) = New SqlParameter("@DriverName", TxtDriverName.Text)
            arr(34) = New SqlParameter("@EWayBillNo", TxtEWayBillNo.Text)
            arr(35) = New SqlParameter("@GstType", IIf(ChkForGSTStateOutSide.Checked = True, 1, 0))

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_SAVEMOTTELINGISSUE", arr)
            hnid = arr(0).Value.ToString()
            TxtIndentNo.Text = arr(4).Value.ToString()
            MsgBox(arr(22).Value.ToString())
            Tran.Commit()
            DDRShadecolor.SelectedIndex = -1
            txtrecqty.Text = ""
            TxtBellWt.Text = ""
            FillstockQty(varfinishedid)
            Fillgrid()
            If DDRShadecolor.Visible = True Then
                DDRShadecolor.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Tran.Rollback()

        End Try
    End Sub

    Protected Sub Fillgrid()
        DG.Rows.Clear()
        Dim str As String = "select Sm.ID,Sd.Detailid,dbo.F_getItemDescription(Sd.Ifinishedid,sd.iflagsize) as IItemdescription, " & _
                           " dbo.F_getItemDescription(Sd.Rfinishedid,sd.Rflagsize) as RItemdescription,SD.RecLotNo,SD.RectagNo,SD.issueqty,SD.Rate,SM.Issueno as indentNo,Sm.gatepassNo,Sm.issueDate,Sm.Reqdate,Sm.remark  " & _
                           " From MOTTELINGISSUEMASTER Sm inner join MOTTELINGISSUEDETAIL SD on Sm.ID=SD.masterid Where Sm.id=" & hnid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                DG.Rows.Add()
                DG.Item("srno", DG.Rows.Count - 1).Value = i + 1
                DG.Item("Id", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Id")
                DG.Item("DetailId", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Detailid")
                DG.Item("IDescription", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IItemdescription")
                DG.Item("RDescription", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RItemdescription")
                DG.Item("RecLotno", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RecLotno")
                DG.Item("RecTagNo", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("RecTagNo")
                DG.Item("Qty", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IssueQty")
                DG.Item("Rate", DG.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Rate")
            Next
        End If
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        hnid = "0"
        DDPartyName.SelectedIndex = -1
        TxtIndentNo.Text = ""

        TxtDate.Text = System.DateTime.Now.ToShortDateString()
        TxtReqDate.Text = System.DateTime.Now.ToShortDateString()
        txtrecqty.Text = ""
        txtrate.Text = ""
    End Sub
    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = "select * from V_MOTTELINGISSUEREPORT where id=" & hnid & "" & _
            " Select ID, IITEMDESCRIPTION, ISHADECOLOR, HSNCode , UnitName, Sum(IssueQty) IssueQty, Sum(PurchaseAmt) PurchaseAmt, Sum(GSTType) GSTType, Sum(CGSTAmt) CGSTAmt, Sum(SGSTAmt) SGSTAmt, Sum(IGSTAmt) IGSTAmt " & _
            " From V_MOTTELINGISSUEREPORT " & _
            " Where ID = " & hnid & "" & _
            " Group By ID, IITEMDESCRIPTION, ISHADECOLOR, HSNCode , UnitName "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, Str)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            If (VarMasterCompanyID = 42) Then
                sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptmottelingissueVikarmCarpet.rpt")
            Else
                sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptmottelingissue.rpt")
            End If

            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\rptmottelingissue.xsd")
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

                txtrecqty.Text = w_Weight.ToString()

            End If
        Catch ex As Exception
        End Try


    End Sub
    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()
    Private Sub txtrecqty_GotFocus(sender As Object, e As System.EventArgs) Handles txtrecqty.GotFocus
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

    Private Sub txtrecqty_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtrecqty.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsave.Focus()
        End If
    End Sub

    Private Sub DDColorShade_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDColorShade.SelectedIndexChanged
        If DDRquality.SelectedIndex <> -1 And DDColorShade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDRShadecolor, "SELECT SHADECOLORID,SHADECOLORNAME FROM SHADECOLOR Where  MasterCompanyId=" & VarMasterCompanyID & " Order By SHADECOLORNAME ")
        End If
    End Sub

    Private Sub txtrate_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtrate.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsave.Focus()
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
                Dim lblDetailid As String = DG.Item("Detailid", DG.CurrentRow.Index).Value
                Dim lblid As String = DG.Item("ID", DG.CurrentRow.Index).Value
                Dim arr(2) As SqlParameter
                arr(0) = New SqlParameter("@Detailid", lblDetailid)
                arr(1) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                arr(1).Direction = ParameterDirection.Output
                arr(2) = New SqlParameter("@ID", lblid)
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_DELETEMOTTELINGISSUE", arr)
                MsgBox(arr(1).Value.ToString())
                Tran.Commit()
                Fillgrid()
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        End If
    End Sub

    Private Sub DDRShadecolor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDRShadecolor.SelectedIndexChanged
        If DDRitemName.SelectedIndex <> -1 And DDRquality.SelectedIndex <> -1 And DDProcessName.SelectedIndex <> -1 And DDPartyName.SelectedIndex <> -1 And DDRShadecolor.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            txtrate.Text = Module1.Getmottelingrate(DDRitemName.SelectedValue, DDRquality.SelectedValue, DDProcessName.SelectedValue, DDPartyName.SelectedValue, TxtDate.Text, shadecolorid:=DDRShadecolor.SelectedValue, Conetype:=DDconetype.Text).ToString()
            txtrecqty.Focus()
        End If
    End Sub

    Private Sub frmsampleyarndyeing_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub DDBinNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDBinNo.SelectedIndexChanged
        If DDItem.SelectedIndex <> -1 And DDQuality.SelectedIndex <> -1 And DDColorShade.SelectedIndex <> -1 And DDBinNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(DDItem.SelectedValue, DDQuality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, DDColorShade.SelectedValue, 0, "", VarMasterCompanyID)
            FillstockQty(Varfinishedid)
        End If
    End Sub


    Private Sub DDPartyName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDPartyName.SelectedIndexChanged
        If DDPartyName.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDcustcode, "select customerid,case when customercode='' Then CompanyName else CustomerCode End as Customercode From customerinfo order by CustomerCode")
        End If


    End Sub

    Private Sub DDcustcode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDcustcode.SelectedIndexChanged
        If DDcustcode.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(DDorderno, "select OM.OrderId,om.CustomerOrderNo From Ordermaster Om WHere CompanyId=" & DDCompanyName.SelectedValue & " and CustomerId=" & DDcustcode.SelectedValue & " and Status=0 order by CustomerorderNo")
        End If

    End Sub

    Private Sub DDRquality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDRquality.SelectedIndexChanged
        If DDRitemName.SelectedIndex <> -1 And DDRquality.SelectedIndex <> -1 And DDProcessName.SelectedIndex <> -1 And DDPartyName.SelectedValue And Varcombovalue <> 0 Then
            txtrate.Text = Module1.Getmottelingrate(DDRitemName.SelectedValue, DDRquality.SelectedValue, DDProcessName.SelectedValue, DDPartyName.SelectedValue, TxtDate.Text).ToString()
        End If


    End Sub

    Private Sub DDconetype_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDconetype.SelectedIndexChanged
        If DDRitemName.SelectedIndex <> -1 And DDRquality.SelectedIndex <> -1 And DDProcessName.SelectedIndex <> -1 And DDPartyName.SelectedIndex <> -1 And DDRShadecolor.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            txtrate.Text = Module1.Getmottelingrate(DDRitemName.SelectedValue, DDRquality.SelectedValue, DDProcessName.SelectedValue, DDPartyName.SelectedValue, TxtDate.Text, shadecolorid:=DDRShadecolor.SelectedValue, Conetype:=DDconetype.Text, PlyType:=DDPlyType.Text, TransportType:=DDTransportType.Text).ToString()
            txtrecqty.Focus()
        End If
    End Sub

    Private Sub DDPlyType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDPlyType.SelectedIndexChanged
        If DDRitemName.SelectedIndex <> -1 And DDRquality.SelectedIndex <> -1 And DDProcessName.SelectedIndex <> -1 And DDPartyName.SelectedIndex <> -1 And DDRShadecolor.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            txtrate.Text = Module1.Getmottelingrate(DDRitemName.SelectedValue, DDRquality.SelectedValue, DDProcessName.SelectedValue, DDPartyName.SelectedValue, TxtDate.Text, shadecolorid:=DDRShadecolor.SelectedValue, Conetype:=DDconetype.Text, PlyType:=DDPlyType.Text, TransportType:=DDTransportType.Text).ToString()
            txtrecqty.Focus()
        End If
    End Sub

    Private Sub DDTransportType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTransportType.SelectedIndexChanged
        If DDRitemName.SelectedIndex <> -1 And DDRquality.SelectedIndex <> -1 And DDProcessName.SelectedIndex <> -1 And DDPartyName.SelectedIndex <> -1 And DDRShadecolor.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            txtrate.Text = Module1.Getmottelingrate(DDRitemName.SelectedValue, DDRquality.SelectedValue, DDProcessName.SelectedValue, DDPartyName.SelectedValue, TxtDate.Text, shadecolorid:=DDRShadecolor.SelectedValue, Conetype:=DDconetype.Text, PlyType:=DDPlyType.Text, TransportType:=DDTransportType.Text).ToString()
            txtrecqty.Focus()
        End If
    End Sub
End Class