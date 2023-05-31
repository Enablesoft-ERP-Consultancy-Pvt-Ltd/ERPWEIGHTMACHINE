Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class frmsamplerawissue
    Dim hnprmid As Integer = 0
    Private Sub frmsamplerawissue_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())
        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        Dim str As String = "select Distinct CI.CompanyId,CI.CompanyName from Companyinfo CI,Company_Authentication CA Where CI.CompanyId=CA.CompanyId And CA.UserId=" & varuserid & "  And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By CompanyName " & _
                           "select pnm.PROCESS_NAME_ID,pnm.process_name from PROCESS_NAME_MASTER PNM inner join UserRightsProcess UP on Pnm.PROCESS_NAME_ID=up.ProcessId and up.Userid=" & varuserid & " and pnm.ProcessType=1 order by PROCESS_NAME   " & _
                            "select Distinct ICM.CATEGORY_ID,ICM.CATEGORY_NAME from ITEM_CATEGORY_MASTER ICM inner Join CategorySeparate CS on ICM.CATEGORY_ID=CS.Categoryid and cs.id=1 order by ICM.CATEGORY_NAME " & _
                            "select GoDownID,GodownName From GodownMaster"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        NewComboFillWithDs(DDcompany, ds, 0)
        If DDcompany.Items.Count > 0 Then DDcompany.SelectedIndex = 0
        NewComboFillWithDs(DDprocess, ds, 1)
        If DDprocess.Items.Count > 0 Then DDprocess.SelectedIndex = 0
        NewComboFillWithDs(ddCatagory, ds, 2)
        NewComboFillWithDs(DDGodown, ds, 3)
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
            NewComboFill(DDvendor, "select EI.EmpId,EI.EmpName + case when isnull(ei.empcode,'')<>'' then ' ['+ei.empcode+']' else '' end as empname  From Empinfo EI inner join EmpProcess EP on EI.empid=EP.EmpId  " & _
                                   "and EP.ProcessId=" & DDprocess.SelectedValue & " and Ei.mastercompanyid=" & VarMasterCompanyID & " order by Ei.EmpName")

        End If
    End Sub
    Private Sub ddCatagory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddCatagory.SelectedIndexChanged
        If ddCatagory.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim str As String = "select Item_Id,ITEM_NAME from Item_master Where CATEGORY_ID=" & ddCatagory.SelectedValue & " order by ITEM_NAME"
            NewComboFill(dditemname, str)
        End If
    End Sub
    Private Sub dditemname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dditemname.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(dquality, "select Distinct QualityId,QualityName from Quality Where Item_Id=" & dditemname.SelectedValue & " order by QualityName")
            NewComboFill(DDunit, "select Distinct U.UnitId,U.UnitName From Item_Master IM inner join UNIT_TYPE_MASTER UT on IM.UnitTypeID=UT.UnitTypeID " & _
                         "inner join Unit u on UT.UnitTypeID=U.UnitTypeID and IM.item_id=" & dditemname.SelectedValue & " and IM.MastercompanyId=" & VarMasterCompanyID & " order by U.UnitName")
            If DDunit.Items.Count > 0 Then DDunit.SelectedIndex = 0
        End If
    End Sub

    Private Sub dquality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dquality.SelectedIndexChanged
        If dquality.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(ddlshade, "select shadecolorid,shadecolorname from shadecolor   order by shadecolorname")
        End If
    End Sub
    Protected Sub FillIssueNo()
        If DDcompany.SelectedIndex <> -1 And DDvendor.SelectedIndex <> -1 And Varcombovalue <> 0 Then

            'Dim str As String = "select Distinct IssueOrderId,IssueOrderId as Issueorderid1 From Process_Issue_master_1 Where Companyid=" & DDcompany.SelectedValue & " and Empid=" & DDvendor.SelectedValue & " " & _
            '                    "and SampleNumber<>''"

            'str = str & " and Status='Pending'"
            'str = str & " order by Issueorderid1"
            'NewComboFill(DDissueNo, str)
            Dim str As String = ""
            Select Case DDprocess.SelectedValue.ToString()
                Case "1"
                    str = "select Distinct IssueOrderId,IssueOrderId as Issueorderid1 From Process_Issue_master_" & DDprocess.SelectedValue & " Where Companyid=" & DDcompany.SelectedValue & " and Empid=" & DDvendor.SelectedValue & " " & _
                      "and SampleNumber<>''"
                Case Else
                    If VarFINISHINGNEWMODULEWISE = "1" Then
                        str = "select Distinct PIM.IssueOrderId,PIM.IssueOrderId as Issueorderid1 From Process_issue_Master_" & DDprocess.SelectedValue & " PIM inner join Employee_ProcessOrderNo EMP on PIM.IssueOrderId=EMP.IssueOrderId and EMP.ProcessId=" & DDprocess.SelectedValue & " Where PIM.CompanyId=" & DDcompany.SelectedValue & " " & _
                               "and EMP.EMPID=" & DDvendor.SelectedValue
                    Else
                        str = "select Distinct IssueOrderId,IssueOrderId as Issueorderid1 From Process_Issue_master_" & DDprocess.SelectedValue & " Where Companyid=" & DDcompany.SelectedValue & " and Empid=" & DDvendor.SelectedValue
                    End If

            End Select
            If chkcomplete.Checked = True Then

                str = str & " and Status='Complete'"
            Else

                str = str & " and Status='Pending'"
            End If

            str = str & " order by Issueorderid1"
            NewComboFill(DDissueNo, str)
        End If
    End Sub
    Private Sub DDvendor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDvendor.SelectedIndexChanged
        hnprmid = "0"
        gvdetail.Rows.Clear()
        FillIssueNo()
    End Sub
    Protected Sub FillLotno()
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And DDGodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            Dim str As String = "select Distinct Lotno,Lotno as Lotno1 From stock Where Companyid=" & DDcompany.SelectedValue & " and Godownid=" & DDGodown.SelectedValue & " and ITEM_FINISHED_ID=" & Varfinishedid & " and Round(Qtyinhand,3)>0"

            str = str & "  order by Lotno1"
            NewComboFill(DDLotno, str)
        End If
    End Sub
    Protected Sub FillTagNo()
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            Dim str As String = "select Distinct TagNo,TagNo as TagNo1 From stock Where Companyid=" & DDcompany.SelectedValue & " and Godownid=" & DDGodown.SelectedValue & " and ITEM_FINISHED_ID=" & Varfinishedid & " and Lotno='" & DDLotno.Text & "' and Round(Qtyinhand,3)>0 "
            'If DDBinNo.Visible = True Then
            '    str = str & " and BinNo='" & DDBinNo.Text & "'"
            'End If
            str = str & "  order by TagNo1"
            NewComboFill(DDTagNo, str)
        End If
    End Sub
    Private Sub DDGodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDGodown.SelectedIndexChanged
        'If DDBinNo.Visible = True Then
        '    If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
        '        Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
        '        Dim str As String = "select Distinct BInNo,BInNo as BInNo1 From stock Where Companyid=" & DDcompany.SelectedValue & " and Godownid=" & DDGodown.SelectedValue & " and ITEM_FINISHED_ID=" & Varfinishedid & " and Round(Qtyinhand,3)>0 order by BInNo1"
        '        NewComboFill(DDBinNo, str)
        '    End If

        'Else
        '    FillLotno()
        'End If
        FillLotno()
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

    Private Sub DDTagNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTagNo.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            If DDBinNo.Visible = True Then
                Dim str As String = "select Distinct BInNo,BInNo as BInNo1 From stock Where Companyid=" & DDcompany.SelectedValue & " and Godownid=" & DDGodown.SelectedValue & " and ITEM_FINISHED_ID=" & Varfinishedid & " and Round(Qtyinhand,3)>0 and LotNo='" & DDLotno.Text & "'"
                If DDTagNo.Visible = True Then
                    str = str & " and TagNo='" & DDTagNo.Text & "'"
                Else
                    str = str & " and TagNo='Without Tag No'"
                End If

                str = str & "  order by BInNo1"
                NewComboFill(DDBinNo, str)
            Else
                txtstockqty.Text = getstockQty(DDcompany.SelectedValue, DDGodown.SelectedValue, DDLotno.Text, Varfinishedid, TagNo:=IIf(DDTagNo.Visible = True, DDTagNo.Text, "Without Tag No"), BinNo:=IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))
            End If
        End If


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


        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If
        Dim Tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim arr(22) As SqlParameter
            arr(0) = New SqlParameter("@PrmId", SqlDbType.Int)
            arr(0).Direction = ParameterDirection.InputOutput
            arr(0).Value = hnprmid
            arr(1) = New SqlParameter("@CompanyId", DDcompany.SelectedValue)
            arr(2) = New SqlParameter("@Empid", DDvendor.SelectedValue)
            arr(3) = New SqlParameter("@Processid", DDprocess.SelectedValue)
            arr(4) = New SqlParameter("@Prorderid", DDissueNo.SelectedValue)
            arr(5) = New SqlParameter("@IssueDate", txtissuedate.Text)
            arr(6) = New SqlParameter("@ChalanNo", SqlDbType.VarChar, 50)
            arr(6).Value = txtchallanNo.Text
            arr(6).Direction = ParameterDirection.InputOutput
            arr(7) = New SqlParameter("@TranType", SqlDbType.Int)
            arr(7).Value = 0
            arr(8) = New SqlParameter("@userid", varuserid)
            arr(9) = New SqlParameter("@mastercompanyid", VarMasterCompanyID)
            arr(10) = New SqlParameter("@Prtid", SqlDbType.Int)
            arr(10).Value = 0
            arr(11) = New SqlParameter("@CategoryId", ddCatagory.SelectedValue)
            arr(12) = New SqlParameter("@Itemid", dditemname.SelectedValue)
            Dim varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID, Tran)
            arr(13) = New SqlParameter("@FinishedId", varfinishedid)
            arr(14) = New SqlParameter("@GodownId", DDGodown.SelectedValue)
            arr(15) = New SqlParameter("@IssueQuantity", txtissueqty.Text)
            arr(16) = New SqlParameter("@lotNo", DDLotno.Text)
            arr(17) = New SqlParameter("@UnitId", DDunit.SelectedValue)
            arr(18) = New SqlParameter("@Tagno", If(DDTagNo.Visible = True, DDTagNo.Text, "Without Tag No"))
            arr(19) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
            arr(19).Direction = ParameterDirection.Output
            arr(20) = New SqlParameter("@Duprowcheck", 0)
            arr(21) = New SqlParameter("@BInNo", IIf(DDBinNo.Visible = True, DDBinNo.Text, ""))

            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_SAMPLEPROCESS_RAW_ISSUE", arr)
            MsgBox(arr(19).Value.ToString())
            hnprmid = arr(0).Value.ToString()
            txtchallanNo.Text = arr(6).Value.ToString()
            Tran.Commit()
            fill_Data_grid()
            If DDTagNo.Visible = True Then
                DDTagNo_SelectedIndexChanged(sender, New EventArgs())
            Else
                DDLotno_SelectedIndexChanged(sender, New EventArgs())
            End If
            txtissueqty.Text = ""
            txtissueqty.Focus()
            'ddlshade.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
            Tran.Rollback()
        End Try
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
        Dim str As String = "select * From V_SamplematerialIssue where prmid=" & hnprmid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String
            sReportName = (My.Application.Info.DirectoryPath & "\Reports\rptsamplematerialissue.rpt")
            dspath = (My.Application.Info.DirectoryPath & "\ReportSchema\rptsamplematerialissue.xsd")
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
            MsgBox("No Record Found!'")
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
                Dim Prtid As Integer = gvdetail.Item("prtidgvdetail", gvdetail.CurrentRow.Index).Value
                Dim param(2) As SqlParameter
                param(0) = New SqlParameter("@prtid", Prtid)
                param(1) = New SqlParameter("@msg", SqlDbType.VarChar, 100)
                param(1).Direction = ParameterDirection.Output
                param(2) = New SqlParameter("@userid", varuserid)
                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRo_Deletesamplerawissue", param)
                MsgBox(param(1).Value.ToString())
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

    Private Sub txtWeaverIdNoscan_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtWeaverIdNoscan.KeyDown
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
    Private Sub chkcomplete_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkcomplete.CheckedChanged
        FillIssueNo()
    End Sub

    Private Sub frmsamplerawissue_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
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


End Class