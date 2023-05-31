Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class FrmTasselMakingOrderRowIssueNew
    Dim hnprmid As Integer = 0
    
    Private Sub FrmTasselMakingOrderRowIssueNew_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "Select Distinct CI.CompanyId,Companyname " & _
                " From Companyinfo CI(Nolock)  " & _
                " JOIN Company_Authentication CA(Nolock) ON CA.CompanyId = CI.CompanyId And CA.UserId = " & varuserid & "   " & _
                " Where CI.MasterCompanyId = " & VarMasterCompanyID & " Order By Companyname  " & _
                " Select Distinct PNM.PROCESS_NAME_ID, PNM.PROCESS_NAME  " & _
                " From ProcessIssueToTasselMakingMaster HFMO(Nolock)  " & _
                " JOIN PROCESS_NAME_MASTER PNM (Nolock) ON PNM.PROCESS_NAME_ID = HFMO.PROCESSID  " & _
                " JOIN UserRightsProcess URP(Nolock) ON URP.ProcessId = PNM.PROCESS_NAME_ID And URP.Userid = " & varuserid & "   " & _
                " Order By PROCESS_NAME  " & _
                " Select ConeType, ConeType From ConeMaster Order By SrNo "
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        NewComboFillWithDs(DDcompany, ds, 0)
        If DDcompany.Items.Count > 0 Then DDcompany.SelectedIndex = 0
        NewComboFillWithDs(DDprocess, ds, 1)
        If DDprocess.Items.Count > 0 Then DDprocess.SelectedIndex = 0
        NewComboFillWithDs(DDConeType, ds, 2)

        ''***********
        If varTagNowise = "1" Then
            lbltagno.Visible = True
            DDTagNo.Visible = True
        End If
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If
    End Sub
    Private Sub DDprocess_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDprocess.SelectedIndexChanged
        If DDprocess.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            hnprmid = "0"
            NewComboFill(DDvendor, "Select Distinct EI.EmpID,  EI.EmpName + ' / ' + EI.EmpCode EmpName " & _
                " From ProcessIssueToTasselMakingMaster a(Nolock) " & _
                " JOIN Empinfo EI(Nolock) ON EI.EmpID = a.EmpID " & _
                " Where a.COMPANYID = " & DDcompany.SelectedValue & " And a.PROCESSID = " & DDprocess.SelectedValue & " And a.MASTERCOMPANYID = " & VarMasterCompanyID & " " & _
                " Order By EmpName ")
        End If
    End Sub
    Private Sub DDvendor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDvendor.SelectedIndexChanged
        hnprmid = "0"
        gvdetail.Rows.Clear()
        FillIssueNo()
    End Sub
    Protected Sub FillIssueNo()
        If DDcompany.SelectedIndex <> -1 And DDvendor.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = ""
            str = "Select Distinct a.ISSUEORDERID, a.IssueNo CHALLANNO " & _
            " From ProcessIssueToTasselMakingMaster a(Nolock) " & _
            " Where a.COMPANYID = " & DDcompany.SelectedValue & " And a.PROCESSID = " & DDprocess.SelectedValue & " And a.MASTERCOMPANYID = " & VarMasterCompanyID & " " & _
            " And a.EmpID = " & DDvendor.SelectedValue & " And a.STATUS = 'PENDING' " & _
            " Order By a.ISSUEORDERID Desc"
            NewComboFill(DDissueNo, str)
        End If
    End Sub
    Private Sub DDissueNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDissueNo.SelectedIndexChanged
        If DDcompany.SelectedIndex <> -1 And DDvendor.SelectedIndex <> -1 And DDissueNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct VF.CATEGORY_ID, VF.CATEGORY_NAME " & _
            " From PROCESS_TASSELMAKING_CONSUMPTION_DETAIL HCD(Nolock) " & _
            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = HCD.IFINISHEDID " & _
            " Where HCD.ISSUEORDERID = " & DDissueNo.SelectedValue & " And HCD.PROCESSID = " & DDprocess.SelectedValue & " And VF.MasterCompanyId = " & VarMasterCompanyID & ""
            NewComboFill(ddCatagory, str)
        End If
    End Sub
    Private Sub ddCatagory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddCatagory.SelectedIndexChanged
        If ddCatagory.SelectedIndex <> -1 And DDissueNo.SelectedIndex <> -1 And DDprocess.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "Select Distinct VF.ITEM_ID, VF.ITEM_NAME " & _
            " From PROCESS_TASSELMAKING_CONSUMPTION_DETAIL HCD(Nolock)  " & _
            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = HCD.IFINISHEDID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " " & _
            " Where HCD.ISSUEORDERID = " & DDissueNo.SelectedValue & " And HCD.PROCESSID = " & DDprocess.SelectedValue & " And VF.MasterCompanyId = " & VarMasterCompanyID & "" & _
            " Order By VF.ITEM_NAME "
            NewComboFill(dditemname, str)
        End If
    End Sub
    Private Sub dditemname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dditemname.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "SELECT U.UnitId, U.UnitName " & _
            " FROM ITEM_MASTER IM(Nolock)  " & _
            " JOIN Unit U(Nolock) ON U.UnitTypeID = IM.UnitTypeID Where IM.ITEM_ID = " & dditemname.SelectedValue & " And IM.MasterCompanyId = " & VarMasterCompanyID & " " & _
            " Select Distinct VF.QualityID, VF.QualityName  " & _
            " From PROCESS_TASSELMAKING_CONSUMPTION_DETAIL HCD(Nolock)  " & _
            " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = HCD.IFINISHEDID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And VF.ITEM_ID = " & dditemname.SelectedValue & " " & _
            " Where HCD.ISSUEORDERID = " & DDissueNo.SelectedValue & " And HCD.PROCESSID = " & DDprocess.SelectedValue & " And VF.MasterCompanyId=" & VarMasterCompanyID & ""
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, Str)
            NewComboFillWithDs(DDunit, ds, 0)
            NewComboFillWithDs(dquality, ds, 1)
        End If
    End Sub

    Private Sub dquality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dquality.SelectedIndexChanged
        If dquality.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(ddlshade, "Select Distinct VF.ShadeColorID, VF.ShadeColorName " & _
                " From PROCESS_TASSELMAKING_CONSUMPTION_DETAIL HCD(Nolock)  " & _
                " JOIN V_FinishedItemDetail VF(Nolock) ON VF.ITEM_FINISHED_ID = HCD.IFINISHEDID And VF.CATEGORY_ID = " & ddCatagory.SelectedValue & " And  " & _
                            " VF.ITEM_ID = " & dditemname.SelectedValue & " And VF.QualityID = " & dquality.SelectedValue & " " & _
                " Where HCD.ISSUEORDERID = " & DDissueNo.SelectedValue & " And HCD.PROCESSID = " & DDprocess.SelectedValue & " And  " & _
                " VF.MasterCompanyId = " & VarMasterCompanyID & " Order By VF.ShadeColorName")
        End If
    End Sub

    Private Sub ddlshade_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddlshade.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            Dim param As SqlParameter() = New SqlParameter(4) {}
            param(0) = New SqlParameter("@Processid", DDprocess.SelectedValue)
            param(1) = New SqlParameter("@Issueorderid", DDissueNo.SelectedValue)
            param(2) = New SqlParameter("@Mastercompanyid", VarMasterCompanyID)
            param(3) = New SqlParameter("@Item_finished_id", Varfinishedid)

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "PRO_FILLTasselMakingOrderRowIssue", param)
            If (ds.Tables(0).Rows.Count > 0) Then
                TxtPendingQty.Text = ds.Tables(0).Rows(0)("PENDQTY")
            End If

            NewComboFill(DDGodown, "Select Distinct GM.GodownID,GM.GodownName  " & _
                " From GodownMaster GM(Nolock) " & _
                " JOIN Godown_Authentication GA ON GM.GodownId=GA.GodownId and GA.UserId=" & varuserid & " and GA.MasterCompanyId=" & VarMasterCompanyID & " " & _
                " JOIN Stock S ON GM.GodownID=S.GodownID " & _
                " Where S.QtyInHand>0 And S.CompanyId=" & DDcompany.SelectedValue & " And S.item_finished_id=" & Varfinishedid & " And GM.MasterCompanyId=" & VarMasterCompanyID & " Order By GM.GodownName")
        End If
    End Sub
    Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGodown.SelectedIndexChanged
        FillLotno()
    End Sub
    Protected Sub FillLotno()
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And DDGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            Dim str As String = "Select Distinct lotno,lotno Lotno1 from stock(Nolock) Where CompanyId=" & DDcompany.SelectedValue & " And Godownid=" & DDGodown.SelectedValue & " and item_finished_id=" & Varfinishedid & " and Round(QtyInHand,3)>0"
            str = str & "  order by Lotno1"
            NewComboFill(DDLotno, str)
        End If
    End Sub

    Private Sub DDLotno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDLotno.SelectedIndexChanged
        If DDTagNo.Visible = True Then
            FillTagNo()
        Else
            If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
                txtstockqty.Text = getstockQty(DDcompany.SelectedValue, DDGodown.SelectedValue, DDLotno.Text, Varfinishedid, BinNo:=IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))
            End If
        End If
    End Sub
    Protected Sub FillTagNo()
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            Dim str As String = "Select Distinct TagNo,Tagno TagNo1 from stock(Nolock) Where CompanyId=" & DDcompany.SelectedValue & " And Godownid=" & DDGodown.SelectedValue & " and item_finished_id=" & Varfinishedid & " And LotNo='" & DDLotno.Text & "' and Round(Qtyinhand,3)>0"
            str = str & "  order by TagNo1"
            NewComboFill(DDTagNo, str)
        End If
    End Sub

    Private Sub DDTagNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTagNo.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            If DDBinNo.Visible = True Then
                Dim str As String = "Select Distinct BinNo,BinNo BInNo1 from stock Where CompanyId=" & DDcompany.SelectedValue & " And Godownid=" & DDGodown.SelectedValue & " and item_finished_id=" & Varfinishedid & " And LotNo='" & DDLotno.Text & "'"
                If DDTagNo.Visible = True Then
                    str = str & " and TagNo='" & DDTagNo.Text & "'"
                    'Else
                    '    str = str & " and TagNo='Without Tag No'"
                End If

                str = str & "  order by BInNo1"
                NewComboFill(DDBinNo, str)
            Else
                txtstockqty.Text = getstockQty(DDcompany.SelectedValue, DDGodown.SelectedValue, DDLotno.Text, Varfinishedid, TagNo:=IIf(DDTagNo.Visible = True, DDTagNo.Text, "Without Tag No"), BinNo:=IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))
            End If
        End If
    End Sub

    Private Sub DDBinNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDBinNo.SelectedIndexChanged
        If DDBinNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
                txtstockqty.Text = getstockQty(DDcompany.SelectedValue, DDGodown.SelectedValue, DDLotno.Text, Varfinishedid, TagNo:=IIf(DDTagNo.Visible = True, DDTagNo.Text, "Without Tag No"), BinNo:=IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))
            End If
        End If
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Validcombobox(DDcompany) = False Then Exit Sub
        If Validcombobox(DDprocess) = False Then Exit Sub
        If Validcombobox(DDvendor) = False Then Exit Sub
        If Validcombobox(DDissueNo) = False Then Exit Sub
        If Validcombobox(ddCatagory) = False Then Exit Sub
        If Validcombobox(dditemname) = False Then Exit Sub
        If Validcombobox(dquality) = False Then Exit Sub
        If Validcombobox(ddlshade) = False Then Exit Sub
        If Validcombobox(DDunit) = False Then Exit Sub
        If Validcombobox(DDGodown) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        If Validcombobox(DDLotno) = False Then Exit Sub
        If DDTagNo.Visible = True Then
            If Validcombobox(DDTagNo) = False Then Exit Sub
        End If
        If Validtxtbox(txtissueqty) = False Then Exit Sub
        Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If
        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try

            Dim param(37) As SqlParameter
            param(0) = New SqlParameter("@PrmID", SqlDbType.Int)
            param(1) = New SqlParameter("@CompanyId", SqlDbType.Int)
            param(2) = New SqlParameter("@EmpId", SqlDbType.Int)
            param(3) = New SqlParameter("@ProcessId", SqlDbType.Int)
            param(4) = New SqlParameter("@OrderId", SqlDbType.Int)
            param(5) = New SqlParameter("@IssueDate", SqlDbType.SmallDateTime)
            param(6) = New SqlParameter("@ChalanNo", SqlDbType.NVarChar, 50)
            param(7) = New SqlParameter("@TranType", SqlDbType.Int)
            param(8) = New SqlParameter("@userid", SqlDbType.Int)
            param(9) = New SqlParameter("@mastercompanyid", SqlDbType.Int)
            param(10) = New SqlParameter("@Prtid", SqlDbType.Int)
            param(11) = New SqlParameter("@CategoryId", SqlDbType.Int)
            param(12) = New SqlParameter("@Itemid", SqlDbType.Int)
            param(13) = New SqlParameter("@FinishedId", SqlDbType.Int)
            param(14) = New SqlParameter("@GodownId", SqlDbType.Int)
            param(15) = New SqlParameter("@IssueQuantity", SqlDbType.Float)
            param(16) = New SqlParameter("@lotNo", SqlDbType.NVarChar, 50)
            param(17) = New SqlParameter("@UnitId", SqlDbType.Int)
            param(18) = New SqlParameter("@PrmIdOutPut", SqlDbType.Int)
            param(19) = New SqlParameter("@PrtIdOutPut", SqlDbType.Int)
            param(20) = New SqlParameter("@UpdateFlag", SqlDbType.Int)
            param(21) = New SqlParameter("@BinNo", SqlDbType.VarChar, 50)
            param(22) = New SqlParameter("@TagNo", SqlDbType.NVarChar, 50)
            param(23) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            param(24) = New SqlParameter("@TanaBana", SqlDbType.VarChar, 50)
            param(25) = New SqlParameter("@TransportName", SqlDbType.VarChar, 50)
            param(26) = New SqlParameter("@BiltyNo", SqlDbType.VarChar, 50)
            param(27) = New SqlParameter("@VehicleNo", SqlDbType.VarChar, 20)
            param(28) = New SqlParameter("@EstimatedRate", SqlDbType.Float)
            param(29) = New SqlParameter("@conetype", SqlDbType.VarChar, 50)
            param(30) = New SqlParameter("@Noofcone", SqlDbType.Int)
            param(31) = New SqlParameter("@Remark", SqlDbType.VarChar, 500)
            param(32) = New SqlParameter("@FolioChallanNo", SqlDbType.VarChar, 50)
            param(33) = New SqlParameter("@BellWt", SqlDbType.Decimal)
            param(34) = New SqlParameter("@CGSTSGST", SqlDbType.Decimal)
            param(35) = New SqlParameter("@ItemDesignID", SqlDbType.Int)
            param(36) = New SqlParameter("@TypeFlag", SqlDbType.Int)

            param(0).Value = hnprmid
            param(1).Value = DDcompany.SelectedValue
            param(2).Value = DDvendor.SelectedValue
            param(3).Value = DDprocess.SelectedValue
            param(4).Value = DDissueNo.SelectedValue
            param(5).Value = txtissuedate.Text
            param(6).Value = txtchallanNo.Text
            param(6).Direction = ParameterDirection.InputOutput
            param(7).Value = 0
            param(8).Value = varuserid
            param(9).Value = VarMasterCompanyID
            param(10).Value = 0
            param(11).Value = ddCatagory.SelectedValue
            param(12).Value = dditemname.SelectedValue
            param(13).Value = Varfinishedid
            param(14).Value = DDGodown.SelectedValue
            param(15).Value = txtissueqty.Text
            param(16).Value = DDLotno.SelectedValue
            param(17).Value = DDunit.SelectedValue
            param(18).Direction = ParameterDirection.Output
            param(19).Direction = ParameterDirection.Output
            param(20).Value = 0
            param(21).Value = IIf(DDBinNo.Visible = True, DDBinNo.Text, "")
            param(22).Value = IIf(DDTagNo.Visible = True, DDTagNo.Text, "")
            param(23).Direction = ParameterDirection.Output
            param(24).Value = ""
            param(25).Value = ""
            param(26).Value = ""
            param(27).Value = ""
            param(28).Value = 0
            param(29).Value = DDConeType.SelectedValue
            param(30).Value = IIf(TxtNoofCone.Text = "", 0, TxtNoofCone.Text)
            param(31).Value = ""
            param(32).Value = ""
            param(33).Value = 0
            param(34).Value = 0
            param(35).Value = 0
            param(36).Value = 2
            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "[PRO_PROCESS_RAW_ISSUE]", param)
            MsgBox(param(23).Value.ToString())
            hnprmid = param(18).Value.ToString()
            txtchallanNo.Text = param(6).Value.ToString()
            Tran.Commit()
            fill_Data_grid()
            If DDTagNo.Visible = True Then
                DDTagNo_SelectedIndexChanged(sender, New EventArgs())
            Else
                DDLotno_SelectedIndexChanged(sender, New EventArgs())
            End If
            txtissueqty.Text = ""
            TxtPendingQty.Text = ""
            txtstockqty.Text = ""
            txtissueqty.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
            Tran.Rollback()
        End Try
    End Sub

    Protected Sub fill_Data_grid()
        Dim i As Integer
        gvdetail.Rows.Clear()
        Dim strsql As String = "Select PrtId,ITEM_NAME,QualityName+ Space(2)+DesignName+ Space(2)+ColorName+ Space(2)+ShapeName+ Space(2)+SizeFt+ Space(2)+ShadeColorName DESCRIPTION," & _
                         "IssueQuantity Qty,LotNo,GodownName,PT.TagNo,PM.ChalanNo,Replace(convert(nvarchar(11),PM.Date,106),' ','-') as IssueDate From Processrawmaster PM,ProcessRawTran PT,V_FinishedItemDetail VF,GodownMaster GM Where PM.Prmid=Pt.prmid and  PT.Finishedid=VF.Item_Finished_id And  " & _
                         "PT.GodownId=GM.GodownId And PT.PrmID=" & hnprmid & " And VF.MasterCompanyId=" & VarMasterCompanyID & ""
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                gvdetail.Rows.Add()
                gvdetail.Item("Itemname", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_name")
                gvdetail.Item("Description", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
                gvdetail.Item("Qty", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")
                gvdetail.Item("LotNo", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("LotNo")
                gvdetail.Item("TagNo", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
                gvdetail.Item("GodownName", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("GodownName")
                gvdetail.Item("prtidgvdetail", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("prtid")
            Next

        End If
    End Sub
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        txtchallanNo.Text = ""
        gvdetail.Rows.Clear()
        hnprmid = "0"
        txtissueqty.Text = ""
    End Sub

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub btnpreview_Click(sender As System.Object, e As System.EventArgs) Handles btnpreview.Click
        Dim str As String = ""
        Dim IstQueryflag As Boolean = True
        If VarMasterCompanyID = 9 Then
            IstQueryflag = True
        Else
            If DDprocess.SelectedValue = 1 Then
                IstQueryflag = True
            Else
                If VarFINISHINGNEWMODULEWISE = 1 Then
                    IstQueryflag = False
                Else
                    IstQueryflag = True
                End If
            End If
        End If
        If IstQueryflag = True Then
            str = " Select PM.Date, PM.ChalanNo, PM.trantype, PT.IssueQuantity,  " & _
                                " PT.Lotno, GM.GodownName, Case When IsNull(EI.EmpName, '') = '' Then  " & _
                                 " (Select Distinct EII.EmpName + ', '  " & _
                                  " From Employee_ProcessOrderNo EPO(Nolock)  " & _
                                  " JOIN Empinfo EII(Nolock) ON EII.EmpID = EPO.EmpID And EPO.IssueOrderId = PM.Prorderid And EPO.ProcessId = PM.Processid)  " & _
                                " Else EI.EmpName End EmpName, " & _
                        " EI.Address, BM.BranchName CompanyName, BM.BranchAddress CompAddr1, '' CompAddr2,  " & _
                        " '' CompAddr3, BM.PhoneNo CompTel, vf.ITEM_NAME, vf.QualityName, vf.designName, " & _
                        " vf.ColorName, vf.ShadeColorName, vf.ShapeName, vf.SizeMtr, PNM.PROCESS_NAME, " & _
                        " PM.Prorderid, EI.GSTNo as empgstin, CI.GSTNo,PT.TAGNO,PT.BINNO,  " & _
                        " (Select Distinct CII.CustomerCode + ', ' " & _
                            " From PROCESS_ISSUE_DETAIL_" & DDprocess.SelectedValue & " PID(Nolock)  " & _
                            " JOIN OrderMaster OM(Nolock) ON OM.OrderiD = PID.OrderiD  " & _
                                " JOIN CustomerInfo CII(Nolock) ON CII.CustomerID = OM.CustomerID  " & _
                                " Where PID.IssueOrderId = PM.Prorderid For XML Path('')) OrderNo, " & _
                        " PM.VehicleNo, PM.TransportName, PM.EWayBillNo, PT.PurchaseRate, PT.PurchaseRate * PT.IssueQuantity PurchaseAmt, " & _
                        " PT.GstType, Round(IsNull(Case When PT.GstType = 0 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 / 2 End, 0), 2) CGstAmt, " & _
                        " Round(IsNull(Case When PT.GstType = 0 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 / 2 End, 0), 2) SGstAmt, " & _
                        " Round(IsNull(Case When PT.GstType = 1 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 End, 0), 2) IGstAmt, U.UnitName, " & _
                        " VF.HSNCode, 0 ReportType " & _
                        " From ProcessRawMaster PM(Nolock) " & _
                        " join ProcessRawTran PT(Nolock) on PM.PRMid=PT.PRMid  " & _
                        " JOIN BranchMaster BM(Nolock) ON BM.ID = PM.BranchID " & _
                        " join CompanyInfo ci(Nolock) on PM.Companyid=ci.CompanyId  " & _
                        " join V_FinishedItemDetail vf(Nolock) on PT.Finishedid=vf.ITEM_FINISHED_ID  " & _
                        " join GodownMaster GM(Nolock) on PT.Godownid=GM.GoDownID  " & _
                        " LEFT join EmpInfo Ei(Nolock) on PM.Empid=ei.EmpId  " & _
                        " join PROCESS_NAME_MASTER PNM(Nolock) on PM.Processid=PNM.PROCESS_NAME_ID  " & _
                        " JOIN Unit U ON U.UnitId = PT.UnitId  " & _
                        " Where PM.Prmid=" + hnprmid + ""
        Else
            str = " select PM.Date, PM.ChalanNo, PM.trantype, PT.IssueQuantity, " & _
                        " PT.Lotno, GM.GodownName, EI.EmpName, '' Address, BM.BranchName CompanyName, BM.BranchAddress CompAddr1, '' CompAddr2, " & _
                        " '' CompAddr3, BM.PhoneNo CompTel, vf.ITEM_NAME, vf.QualityName, vf.designName, " & _
                        " vf.ColorName, vf.ShadeColorName, vf.ShapeName, vf.SizeMtr, PNM.PROCESS_NAME, " & _
                        " PM.Prorderid, '' as empgstin, CI.GSTNo, PT.TAGNO,PT.BINNO, '' OrderNo, " & _
                        " PM.VehicleNo, PM.TransportName, PM.EWayBillNo, PT.PurchaseRate, PT.PurchaseRate * PT.IssueQuantity PurchaseAmt, " & _
                        " PT.GstType, Round(Case When PT.GstType = 0 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 / 2 End, 0) CGstAmt, " & _
                        " IsNull(Case When PT.GstType = 0 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 / 2 End, 0) SGstAmt, " & _
                        " IsNull(Case When PT.GstType = 1 Then (PT.PurchaseRate * PT.IssueQuantity) * PT.CGSTSGST * 0.01 End, 0) IGstAmt, U.UnitName, " & _
                        " VF.HSNCode, 0 ReportType " & _
                        " From ProcessRawMaster PM(Nolock) " & _
                        " JOIN BRANCHMASTER BM(Nolock) ON BM.ID = PM.BranchID  " & _
                        " inner join ProcessRawTran PT(Nolock) on PM.PRMid=PT.PRMid " & _
                        " inner join CompanyInfo ci(Nolock) on PM.Companyid=ci.CompanyId " & _
                        " inner join V_FinishedItemDetail vf(Nolock) on PT.Finishedid=vf.ITEM_FINISHED_ID " & _
                        " inner join GodownMaster GM(Nolock) on PT.Godownid=GM.GoDownID " & _
                        " JOIN Empinfo Ei(Nolock) on EI.EmpID=PM.EmpID " & _
                        " inner join PROCESS_NAME_MASTER PNM(Nolock) on PM.Processid=PNM.PROCESS_NAME_ID " & _
                        " JOIN Unit U ON U.UnitId = PT.UnitId " & _
                        " Where PM.Prmid=" + hnprmid.ToString() + " and PM.Processid=" & DDprocess.SelectedValue & " "
        End If

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
                Dim arr As SqlParameter() = New SqlParameter(6) {}
                arr(0) = New SqlParameter("@PrtID", SqlDbType.Int)
                arr(1) = New SqlParameter("@RowCount", SqlDbType.Int)
                arr(2) = New SqlParameter("@TranType", SqlDbType.Int)
                arr(3) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                arr(4) = New SqlParameter("@userid", varuserid)
                arr(5) = New SqlParameter("@mastercompanyid", VarMasterCompanyID)
                arr(0).Value = VarPrtID
                arr(1).Value = gvdetail.Rows.Count
                arr(2).Value = 0
                arr(3).Direction = ParameterDirection.Output

                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PROCESS_RAW_ISSUE_RECEIVE_DELETE", arr)
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

                txtissueqty.Text = w_Weight.ToString()

            End If
        Catch ex As Exception
        End Try


    End Sub
    Private w_Weight As Double = 0
    Private dd As New List(Of Double)()
    Private Sub txtissueqty_GotFocus(sender As Object, e As System.EventArgs) Handles txtissueqty.GotFocus
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

    Private Sub txtWeaverIdNoscan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            FillProcess_Employee(sender)
        End If
    End Sub
    Protected Sub FillProcess_Employee(Optional ByVal sender As Object = Nothing)
        Dim str As String = "SELECT Top(1) EMP.ProcessId,EI.EmpId FROM EMPLOYEE_PROCESSORDERNO EMP INNER JOIN EMPINFO EI ON EMP.EMPID=EI.EMPID WHERE EI.EMPCODE='" & txtWeaverIdNoscan.Text & "'"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then

            DDprocess.SelectedValue = ds.Tables(0).Rows(0)("Processid").ToString()
            If sender IsNot Nothing Then
                DDprocess_SelectedIndexChanged(sender, New EventArgs())
            End If

            DDvendor.SelectedValue = ds.Tables(0).Rows(0)("Empid").ToString()
            If sender IsNot Nothing Then
                DDvendor_SelectedIndexChanged(sender, New EventArgs())
            End If
            DDissueNo.Focus()
        Else
            DDprocess.SelectedIndex = -1
            DDvendor.SelectedIndex = -1
            MsgBox("Please Enter correct Emp. Code or No entry from this employee")
        End If
    End Sub
    Private Sub chkcomplete_CheckedChanged(sender As System.Object, e As System.EventArgs)
        FillIssueNo()
    End Sub

    Private Sub FrmTasselMakingOrderRowIssueNew_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub
End Class