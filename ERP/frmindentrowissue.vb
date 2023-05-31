Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.IO.Ports
Imports System.Threading
Public Class frmindentrowissue
    Dim Prmid As Integer = 0
    Dim Prtid As Integer = 0
    Dim FinishedID As Integer = 0
    Private Sub frmindentrowissue_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmb_port.Items.AddRange(SerialPort.GetPortNames())

        If cmb_port.Items.Count > 0 Then
            cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        End If
        NewComboFill(ddCompName, "select Distinct CI.CompanyId,Companyname from Companyinfo CI,Company_Authentication CA Where CA.CompanyId=CI.CompanyId And CA.UserId=" & varuserid & " And CI.MasterCompanyId=" & VarMasterCompanyID & " Order By Companyname")
        NewComboFill(ddProcessName, "select DISTINCT PROCESS_NAME_ID,process_name from PROCESS_NAME_MASTER pm inner join IndentMaster im on pm.PROCESS_NAME_ID=im.processid And pm.MasterCompanyId=" & VarMasterCompanyID & " order by PROCESS_NAME_ID ")
        NewComboFill(ddgodown, "select godownid,godownname from godownmaster")

        If ddCompName.Items.Count > 0 Then
            ddCompName.SelectedValue = VarCompanyID
            ddCompName.Enabled = False
        End If

        If ddProcessName.Items.Count > 0 Then ddProcessName.SelectedIndex = 0
        If varTagNowise = 1 Then
            lblTagno.Visible = True
            DDTagNo.Visible = True
        End If
        If VarBINNOWISE = 1 Then
            lblbinno.Visible = True
            DDBinNo.Visible = True
        End If
        If (VarMasterCompanyID = 16 Or VarMasterCompanyID = 28 Or VarMasterCompanyID = 42) Then
            TxtMoisture.Visible = True
            LblMoisture.Visible = True
        End If
    End Sub
    Private Sub dprocess_change()
        If ddCompName.SelectedIndex <> -1 And ddProcessName.SelectedIndex <> -1 And Varcombovalue <> -1 Then
            NewComboFill(ddempname, "SELECT distinct E.EmpId,E.EmpName FROM IndentMaster IM INNER JOIN  EmpInfo E ON IM.PartyId=E.EmpId And E.Blacklist = 0 Where IM.Processid=" & ddProcessName.SelectedValue & " ANd IM.MasterCompanyId=" & VarMasterCompanyID & " And IM.CompanyId=" & ddCompName.SelectedValue & " order by E.EmpName")
        End If
    End Sub

    Private Sub ddProcessName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddProcessName.SelectedIndexChanged
        dprocess_change()
    End Sub
    Private Sub fill_emp_change()
        Dim str As String = ""

        If ddCompName.SelectedIndex <> -1 And ddProcessName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            If VarWithoutBom = "1" Then
                str = "select distinct im.IndentId, IndentNo+'/'+localorder + '/'+CustomerOrderNo as IndentNo from IndentMaster im inner join " & _
                    "Indentdetail id on id.IndentID=im.IndentID inner join ordermaster om on om.orderid=id.orderid inner join orderdetail od On om.orderid=od.orderid inner join  " & _
                    "V_FinishedItemDetail v On od.Item_Finished_Id= v.Item_Finished_Id  " & _
                    "Where  om.status=0  AND  im.Status Not in('complete','cancelled') and  im.partyid=" & ddempname.SelectedValue & " and im.processid=" & ddProcessName.SelectedValue & " And im.CompanyId=" & ddCompName.SelectedValue & " And Im.MasterCompanyId=" & VarMasterCompanyID & ""
            Else
                If VarMasterCompanyID = "9" Then
                    str = "select distinct im.IndentId, localorder +'/'+IndentNo as IndentNo from IndentMaster im inner join " & _
                     "Indentdetail id on id.IndentID=im.IndentID inner join ordermaster om on om.orderid=id.orderid " & _
                    " Where im.Approvalflag=1 and  im.partyid=" & ddempname.SelectedValue & "AND im.Status not in('complete','cancelled') and im.processid=" & ddProcessName.SelectedValue & " And im.CompanyId=" & ddCompName.SelectedValue & " And im.MasterCompanyId=" & VarMasterCompanyID & ""
                Else
                    str = "select distinct im.IndentId, IndentNo+'/'+localorder +'/'+CustomerOrderNo as IndentNo from IndentMaster im inner join " & _
                     "Indentdetail id on id.IndentID=im.IndentID inner join ordermaster om on om.orderid=id.orderid " & _
                    " Where im.Approvalflag=1 and  im.partyid=" & ddempname.SelectedValue & "AND im.Status not in('complete','cancelled') and im.processid=" & ddProcessName.SelectedValue & " And im.CompanyId=" & ddCompName.SelectedValue & " And im.MasterCompanyId=" & VarMasterCompanyID & ""
                End If
            End If

            NewComboFill(ddindentno, str)
        End If

    End Sub

    Private Sub ddempname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddempname.SelectedIndexChanged
        fill_emp_change()
    End Sub
    Private Sub fillordergrid()
        dgorder.Rows.Clear()
        If ddindentno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, "select  ITEM_NAME+' '+QualityName+' '+designName+' '+ColorName+' '+ShadeColorName+' '+ShapeName AS description,Quantity as qty from IndentMaster IM INNER JOIN INDENTDETAIL ID ON ID.INDENTID=IM.INDENTID INNER JOIN V_FinishedItemDetail VD ON VD.ITEM_FINISHED_ID=ID.OFINISHEDID where id.indentid=" & ddindentno.SelectedValue & " And VD.MasterCompanyId=" & VarMasterCompanyID & "")
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                dgorder.Rows.Add()
                dgorder.Item("orderdescription", dgorder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("description")
                dgorder.Item("Qty", dgorder.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Qty")


            Next

        End If
    End Sub

    Private Sub ddindentno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddindentno.SelectedIndexChanged
        fillordergrid()
        If ddProcessName.SelectedIndex <> -1 And ddempname.SelectedIndex <> -1 And ddindentno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(ddCatagory, "  SELECT DISTINCT icm.CATEGORY_ID , icm.CATEGORY_NAME  FROM ITEM_MASTER im INNER JOIN " & _
                  "ITEM_PARAMETER_MASTER ipm ON im.ITEM_ID = ipm.ITEM_ID And ipm.MasterCompanyId=" & VarMasterCompanyID & " INNER JOIN ITEM_CATEGORY_MASTER icm ON im.CATEGORY_ID = icm.CATEGORY_ID INNER JOIN " & _
                  "IndentDetail  id INNER JOIN   IndentMaster idm ON id.IndentId = idm.IndentID ON  ipm.ITEM_FINISHED_ID = id.IFinishedId Inner join UserRights_Category UC on icm.Category_ID=UC.CategoryId And UC.UserId=" & varuserid & " " & _
                  "Where idm.partyid=" & ddempname.SelectedValue & " and idm.processid=" & ddProcessName.SelectedValue & " and  idm.IndentId=" & ddindentno.SelectedValue & "")

            NewComboFill(ddlunit, "Select DISTINCT U.UnitId,UnitName from PP_Consumption PP,IndentDetail ID,ORDER_CONSUMPTION_DETAIL OCD,Unit U,ProcessProgram P " & _
                                  "Where(ID.PPNo = PP.PPId And OCD.OrderDetailId = PP.OrderDetailId And U.UnitId = OCD.IUnitId And P.PPID = PP.PPId And OCD.ProcessiD = P.Process_iD) " & _
                                  "And Id.IndentId=" & ddindentno.SelectedValue & " And P.MasterCompanyId=" & VarMasterCompanyID & "")
        End If
    End Sub

    Private Sub ddCatagory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddCatagory.SelectedIndexChanged
        ddlcategorycange()
    End Sub
    Protected Sub ddlcategorycange()
        If ddindentno.SelectedIndex <> -1 And ddCatagory.SelectedIndex <> -1 And Varcombovalue <> 0 Then


            NewComboFill(dditemname, "SELECT DISTINCT dbo.ITEM_MASTER.ITEM_ID, dbo.ITEM_MASTER.ITEM_NAME FROM  dbo.ITEM_PARAMETER_MASTER INNER JOIN " & _
                        "dbo.IndentDetail ON dbo.ITEM_PARAMETER_MASTER.ITEM_FINISHED_ID = dbo.IndentDetail.IFinishedId And ITEM_PARAMETER_MASTER.MasterCompanyId=" & VarMasterCompanyID & " INNER JOIN " & _
                        "dbo.ITEM_MASTER ON dbo.ITEM_PARAMETER_MASTER.ITEM_ID = dbo.ITEM_MASTER.ITEM_ID " & _
               "WHERE dbo.IndentDetail.IndentId =" & ddindentno.SelectedValue & " AND dbo.ITEM_MASTER.CATEGORY_ID =" & ddCatagory.SelectedValue & "")
        End If
    End Sub
    Private Sub ITEM_CHANGED()
        txtissqty.Text = ""
        txtpendingqty.Text = ""
        txtpreissue.Text = ""
        txtissue.Text = ""
        If ddProcessName.SelectedIndex <> -1 And ddindentno.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And Varcombovalue <> 0 Then


            NewComboFill(ddlunit, "Select distinct U.UnitId,UnitName from PP_Consumption PP inner join IndentDetail ID on ID.PPNo=PP.PPId inner Join IndentMaster IM ON IM.IndentId=Id.IndentId inner join ORDER_CONSUMPTION_DETAIL OCD on OCD.OrderDetailId=PP.OrderDetailId inner join Unit U on U.UnitId=OCD.IUnitId and OCD.Processid=" & ddProcessName.SelectedValue & " Where IM.IndentID=" & ddindentno.SelectedValue)
            If ddlunit.Items.Count > 0 Then ddlunit.SelectedIndex = 0
            dquality.Text = ""
            ddlshade.Text = ""

            NewComboFill(dquality, "SELECT DISTINCT dbo.Quality.QualityId,dbo.Quality.QualityName " & _
                    " FROM  dbo.ITEM_PARAMETER_MASTER INNER JOIN " & _
                    "  dbo.IndentDetail ON dbo.ITEM_PARAMETER_MASTER.ITEM_FINISHED_ID = dbo.IndentDetail.IFinishedId And ITEM_PARAMETER_MASTER.MasterCompanyId=" & VarMasterCompanyID & " INNER JOIN " & _
                    "  dbo.Quality ON dbo.ITEM_PARAMETER_MASTER.QUALITY_ID = dbo.Quality.QualityId " & _
                    " WHERE dbo.IndentDetail.IndentId =" & ddindentno.SelectedValue & "and quality.item_id=" & dditemname.SelectedValue & "")

        End If
    End Sub

    Private Sub dditemname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dditemname.SelectedIndexChanged
        ITEM_CHANGED()
    End Sub
    Private Sub FILL_QUALITY_CHANGE()
        If ddindentno.SelectedIndex <> -1 And dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            NewComboFill(ddlshade, "SELECT DISTINCT dbo.ShadeColor.ShadecolorId, dbo.ShadeColor.ShadeColorName FROM   dbo.ITEM_PARAMETER_MASTER INNER JOIN " & _
                          "dbo.IndentDetail ON dbo.ITEM_PARAMETER_MASTER.ITEM_FINISHED_ID = dbo.IndentDetail.IFinishedId INNER JOIN " & _
                          "dbo.ShadeColor ON dbo.ITEM_PARAMETER_MASTER.SHADECOLOR_ID = dbo.ShadeColor.ShadecolorId " & _
                          "WHERE dbo.IndentDetail.IndentId =" & ddindentno.SelectedValue & " AND dbo.ITEM_PARAMETER_MASTER.ITEM_ID=" & dditemname.SelectedValue & " AND dbo.ITEM_PARAMETER_MASTER.Quality_Id=" & dquality.SelectedValue & " And ITEM_PARAMETER_MASTER.MasterCompanyId=" & VarMasterCompanyID & "")

        End If
    End Sub

    Private Sub dquality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles dquality.SelectedIndexChanged
        FILL_QUALITY_CHANGE()
    End Sub
    Private Sub GodownSelectedChanged()
        If ddindentno.SelectedIndex <> -1 And ddgodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            FinishedID = Varfinishedid
            If Varcarpetcompany = "1" Then
                NewComboFill(ddlotno, "SELECT Distinct LotNo,LotNo FROM IndentDetail Where IndentId=" & ddindentno.SelectedValue & " and ifinishedid=" & Varfinishedid & "")
            Else
                NewComboFill(ddlotno, "SELECT Distinct LotNo,LotNo FROM IndentDetail Where IndentId=" & ddindentno.SelectedValue & "")
            End If

            Dim _array(6) As SqlParameter
            _array(0) = New SqlParameter("@Finishedid", Varfinishedid)
            _array(1) = New SqlParameter("@indentId", ddindentno.SelectedValue)
            _array(2) = New SqlParameter("@StockQty", SqlDbType.Float)
            _array(3) = New SqlParameter("@IndentQty", SqlDbType.Float)
            _array(4) = New SqlParameter("@PreIssueQty", SqlDbType.Float)
            _array(5) = New SqlParameter("@PendingQty", SqlDbType.Float)
            _array(6) = New SqlParameter("@varcompanyType", SqlDbType.Int)
            _array(2).Direction = ParameterDirection.Output
            _array(3).Direction = ParameterDirection.Output
            _array(4).Direction = ParameterDirection.Output
            _array(5).Direction = ParameterDirection.Output
            _array(6).Direction = ParameterDirection.Output
            SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, "Pro_FillIndent_Issue_Qty", _array)

            txtstock.Text = "0"
            txtissue.Text = _array(3).Value.ToString()
            txtpreissue.Text = _array(4).Value.ToString()
            txtpendingqty.Text = _array(5).Value.ToString()

            getstockQty(Varfinishedid)

        End If
    End Sub
    Protected Sub getstockQty(ByVal Varfinishedid As Integer)
        Dim qty As Double = 0
        Dim Lotno As String
        Dim TagNo As String
        Dim BinNo As String = ""
        If ddlotno.Visible = True Then
            Lotno = ddlotno.Text
        Else
            Lotno = "Without Lot No"
        End If

        If DDTagNo.Visible = True Then
            If DDTagNo.Items.Count > 0 Then
                TagNo = DDTagNo.Text
            Else
                TagNo = "Without Tag No"
            End If
        Else
            TagNo = "Without Tag No"
        End If
        If DDBinNo.Visible = True Then
            BinNo = DDBinNo.Text
        End If
        qty = Module1.getstockQty(ddCompName.SelectedValue, ddgodown.SelectedValue, Lotno, Varfinishedid, TagNo, BinNo:=BinNo)
        If qty > 0 Then
            txtstock.Text = qty.ToString()
        Else
            txtstock.Text = "0"
        End If
    End Sub

    Private Sub ddgodown_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddgodown.SelectedIndexChanged

        GodownSelectedChanged()

    End Sub
    Private Sub ddlotno_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ddlotno.SelectedIndexChanged
        If ddCompName.SelectedIndex <> -1 And ddgodown.SelectedIndex <> -1 And ddlotno.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            FinishedID = Varfinishedid
            If DDBinNo.Visible = True Then
                If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And ddgodown.SelectedIndex <> -1 And Varcombovalue <> 0 Then
                    Dim str As String = "select Distinct BinNo,BinNo as BinNo1 from Stock Where Item_Finished_id=" & Varfinishedid & " and Godownid=" & ddgodown.SelectedValue & " and CompanyId=" & ddCompName.SelectedValue & "  and Round(Qtyinhand,3)>0 AND Lotno='" + ddlotno.Text + "' order by BinNo"
                    Call NewComboFill(DDBinNo, str)
                    If DDBinNo.Items.Count > 0 Then
                        DDBinNo.SelectedIndex = 0
                    End If
                    DDBinNo_SelectedIndexChanged(sender, New EventArgs())
                End If
            Else
                FillTagNo(Varfinishedid, sender)
            End If

        End If

    End Sub

    Protected Sub FillTagNo(ByVal Varfinishedid As Integer, Optional ByVal sender As Object = Nothing)
        Dim str As String = ""
        If DDTagNo.Visible = True Then
            str = "select Distinct TagNo,TagNo From Stock  Where Companyid=" & ddCompName.SelectedValue & " and Godownid=" & ddgodown.SelectedValue & " and LotNo='" & ddlotno.Text & "' and ITEM_FINISHED_ID=" & Varfinishedid & " and Round(Qtyinhand,3)>0"
            If DDBinNo.Visible = True Then
                str = str + "  and Binno='" + DDBinNo.Text + "'"
            End If
            NewComboFill(DDTagNo, str)
            If DDTagNo.Items.Count > 0 Then
                DDTagNo.SelectedIndex = 0
            End If
            If sender IsNot Nothing Then
                DDTagNo_SelectedIndexChanged(sender, New EventArgs())
            End If
        Else
            getstockQty(Varfinishedid)
        End If
    End Sub
    Private Sub DDTagNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDTagNo.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            FinishedID = Varfinishedid
            getstockQty(Varfinishedid)

        End If
    End Sub

    Private Sub txtissqty_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtissqty.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsave.Focus()
        End If
    End Sub
    Private Sub CheckQty()
        Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
        Dim stock As Double = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, "select isnull(sum(qtyinhand),0) from stock where item_finished_id=" & Varfinishedid & "").ToString())
        If VarMasterCompanyID <> "4" Then
            Dim IssQty As Double, BellWt As Double, FinalIssQty As Double
            If (txtissqty.Text = "") Then
                IssQty = 0
            Else
                IssQty = txtissqty.Text
            End If

            If (TxtBellWt.Text = "") Then
                BellWt = 0
            Else
                BellWt = TxtBellWt.Text
            End If
            FinalIssQty = IssQty - BellWt

            Dim VarPercentQty As Double = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, "Select PercentageExecssQtyForIndent from MasterSetting"))
            Dim PendingQty As Double = Convert.ToDouble(If(txtpendingqty.Text = "", "0", txtpendingqty.Text)) + (Convert.ToDouble(If(txtpendingqty.Text = "", "0", txtpendingqty.Text)) * VarPercentQty / 100)
            If FinalIssQty > PendingQty OrElse FinalIssQty <= 0 Then
                MsgBox("Please check Qty  i.e " & PendingQty.ToString())
                txtissqty.Text = ""
                txtissqty.Focus()
            End If
        End If
    End Sub
    Private Sub txtissqty_LostFocus(sender As Object, e As System.EventArgs) Handles txtissqty.LostFocus
        
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

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        ''****************
        If Validcombobox(ddCompName) = False Then Exit Sub
        If Validcombobox(ddProcessName) = False Then Exit Sub
        If Validcombobox(ddempname) = False Then Exit Sub
        If Validcombobox(ddindentno) = False Then Exit Sub
        If Validcombobox(ddCatagory) = False Then Exit Sub
        If Validcombobox(dditemname) = False Then Exit Sub
        If Validcombobox(dquality) = False Then Exit Sub
        If Validcombobox(ddlshade) = False Then Exit Sub
        If Validcombobox(ddgodown) = False Then Exit Sub
        If DDBinNo.Visible = True Then
            If Validcombobox(DDBinNo) = False Then Exit Sub
        End If

        If Validcombobox(ddlotno) = False Then Exit Sub
        If DDTagNo.Visible = True Then
            If Validcombobox(DDTagNo) = False Then Exit Sub
        End If
        If Validcombobox(ddlunit) = False Then Exit Sub
        If Validtxtbox(txtissqty) = False Then Exit Sub
        If TxtMoisture.Visible = True Then
            If Validtxtbox(TxtMoisture) = False Then Exit Sub
        End If
        ''****************
        If Validatesave() = False Then Exit Sub
        CheckQty()
        save_detail()
    End Sub
    Private Sub refresh_form()
        Prtid = 0
        Prmid = 0
        pnl1.Enabled = True
        ddempname.SelectedIndex = -1
        ddindentno.SelectedIndex = -1
        txtchalanno.Text = ""
        ddCatagory.SelectedIndex = -1
        dditemname.SelectedIndex = -1
        ddgodown.SelectedIndex = -1
        txtissue.Text = ""
        dquality.SelectedIndex = -1
        ddlshade.SelectedIndex = -1
        txtdate.Text = DateTime.Now.ToString("dd-MMM-yyyy")
        TxtProdCode.Text = ""
        btnsave.Text = "Save"
        gvdetail.Rows.Clear()
    End Sub
    Protected Sub save_detail()
        'CHECKVALIDCONTROL()
        'If lblMessage.Text = "" Then
        '    Validated()
        'End If
        If Validtxtbox(txtissqty) = False Then Exit Sub
        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If
        Dim tran As SqlTransaction = Con.BeginTransaction()
        Try
            Dim arr(28) As SqlParameter
            arr(0) = New SqlParameter("@prmid", SqlDbType.Int)
            arr(1) = New SqlParameter("@companyid", SqlDbType.Int)
            arr(2) = New SqlParameter("@empid", SqlDbType.Int)
            arr(3) = New SqlParameter("@processid", SqlDbType.Int)
            arr(4) = New SqlParameter("@issuedate", SqlDbType.DateTime)
            arr(5) = New SqlParameter("@chalanno", SqlDbType.NVarChar, 150)
            arr(6) = New SqlParameter("@varuserid", SqlDbType.Int)
            arr(7) = New SqlParameter("@VARCOMPANYID", SqlDbType.Int)
            arr(8) = New SqlParameter("@prtid", SqlDbType.Int)
            arr(9) = New SqlParameter("@finishedId", SqlDbType.Int)
            arr(10) = New SqlParameter("@godownId", SqlDbType.Int)
            arr(11) = New SqlParameter("@issueQuantity", SqlDbType.Float)
            arr(12) = New SqlParameter("@indentid", SqlDbType.Int)
            arr(13) = New SqlParameter("@unitid", SqlDbType.Int)
            arr(14) = New SqlParameter("@lotno", SqlDbType.NVarChar, 50)
            arr(15) = New SqlParameter("@Finish_Type", SqlDbType.Int)
            arr(16) = New SqlParameter("@Remark", SqlDbType.NVarChar, 250)
            arr(17) = New SqlParameter("@Sizeflag", SqlDbType.Int)
            arr(18) = New SqlParameter("@CanQty", SqlDbType.Float)
            arr(19) = New SqlParameter("@TagNo", SqlDbType.NVarChar, 50)
            arr(20) = New SqlParameter("@BinNo", SqlDbType.VarChar, 50)
            arr(21) = New SqlParameter("@msg", SqlDbType.VarChar, 50)
            arr(22) = New SqlParameter("@BellWt", SqlDbType.Float)
            arr(23) = New SqlParameter("@Moisture", SqlDbType.Float)
            arr(24) = New SqlParameter("@VehicleNo", SqlDbType.NVarChar, 100)
            arr(25) = New SqlParameter("@DriverName", SqlDbType.NVarChar, 100)
            arr(26) = New SqlParameter("@EWayBillNo", SqlDbType.NVarChar, 100)
            arr(27) = New SqlParameter("@GstType", SqlDbType.Int)

            arr(0).Direction = ParameterDirection.InputOutput
            arr(0).Value = Prmid
            arr(1).Value = ddCompName.SelectedValue
            arr(2).Value = ddempname.SelectedValue
            arr(3).Value = ddProcessName.SelectedValue
            arr(4).Value = txtdate.Text
            arr(5).Direction = ParameterDirection.InputOutput
            arr(5).Value = txtchalanno.Text
            arr(6).Value = varuserid
            arr(7).Value = VarMasterCompanyID
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID, tran)
            arr(8).Direction = ParameterDirection.InputOutput
            arr(8).Value = Prtid
            arr(9).Value = Varfinishedid
            arr(11).Value = txtissqty.Text
            arr(12).Value = ddindentno.SelectedValue
            arr(13).Value = ddlunit.SelectedValue
            arr(15).Value = 0
            arr(16).Value = txtremarks.Text
            arr(17).Value = 0
            arr(18).Value = 0
            'If ChKForOrder.Checked = True Then
            '    arr(10).Value = ddgodown.SelectedValue
            '    arr(14).Value = "Without Lot No"
            'Else
            arr(10).Value = ddgodown.SelectedValue
            arr(14).Value = ddlotno.Text
            ' End If

            Dim TagNo As String
            If DDTagNo.Visible = True Then
                TagNo = DDTagNo.Text
            Else
                TagNo = "Without Tag No"
            End If

            arr(19).Value = TagNo
            arr(20).Value = IIf(DDBinNo.Visible = True, DDBinNo.Text, "")
            arr(21).Direction = ParameterDirection.Output
            arr(22).Value = IIf(TxtBellWt.Text = "", 0, TxtBellWt.Text)
            arr(23).Value = IIf(TxtMoisture.Visible = True, TxtMoisture.Text, "0")
            arr(24).Value = TxtVehicleNo.Text
            arr(25).Value = TxtDriverName.Text
            arr(26).Value = TxtEWayBillNo.Text
            arr(27).Value = IIf(ChkForGSTStateOutSide.Checked = True, 1, 0)

            SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "[PRO_PP_PRM]", arr)
            txtchalanno.Text = arr(5).Value.ToString()
            Prmid = arr(0).Value.ToString()
            Prtid = arr(8).Value.ToString()

            If arr(21).Value.ToString() <> "" Then
                MsgBox(arr(21).Value.ToString())
            End If

            'If btnsave.Text = "Save" Then
            '    StockStockTranTableUpdateNew(Varfinishedid, Convert.ToInt32(ddgodown.SelectedValue), Convert.ToInt32(ddCompName.SelectedValue), arr(14).Value.ToString(), Convert.ToDouble(txtissqty.Text), arr(4).Value.ToString(), DateTime.Now.ToString("dd-MMM-yyyy"), "PP_ProcessRawTran", Prtid, tran, 0, False, 1, 0, UnitId:=Convert.ToInt16(ddlunit.SelectedValue), TagNo:=TagNo)
            'End If

            Prtid = 0
            tran.Commit()
            pnl1.Enabled = False
            btnsave.Text = "Save"
            Fill_Grid()
            save_refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
            tran.Rollback()

        End Try

    End Sub
    Function Validatesave() As Boolean
        Try
            Dim Lotno As String
            Dim TagNo As String
            Dim BinNo As String = ""

            If ddlotno.Visible = True Then
                Lotno = ddlotno.Text
            Else
                Lotno = "Without Lot No"
            End If
            If DDTagNo.Visible = True Then
                TagNo = DDTagNo.Text
            Else
                TagNo = "Without Tag No"
            End If
            If DDBinNo.Visible = True Then
                BinNo = DDBinNo.Text

            End If
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            Dim strsql As String
            Dim ds As DataSet
            'strsql = "select finishedid from pp_processrawtran where finishedid=" & Varfinishedid & " and prmid =" & Prmid & " And indentid=" & ddindentno.SelectedValue & " and Lotno='" & Lotno & "'"
            'If ddlotno.Visible = True Then
            '    strsql = strsql & " And LotNo='" + ddlotno.Text & "'"
            'End If
            'If btnsave.Text = "Update" Then
            '    strsql = strsql & " And Prtid!='" & Prtid & "'"
            'End If
            'ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
            'If ds.Tables(0).Rows.Count > 0 Then
            '    MsgBox("Duplicate Entry.......")
            '    Validatesave = False
            '    Exit Function
            'End If
            If txtchalanno.Text <> "" Then
                strsql = "select ChallanNo  from PP_ProcessRawmaster Where ChallanNo='" & txtchalanno.Text & "' And PrmId<>" & Prmid & ""
                ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
                If ds.Tables(0).Rows.Count > 0 Then
                    MsgBox("ChallanNo Already Exists......")
                    Validatesave = False
                    Exit Function
                End If
            End If

            Dim qty As Double, BellQty As Double
            qty = Module1.getstockQty(ddCompName.SelectedValue, ddgodown.SelectedValue, Lotno, Varfinishedid, TagNo:=TagNo, BinNo:=BinNo)
            ''qty = Convert.ToDouble(SqlHelper.ExecuteScalar(Con, CommandType.Text, "SELECT  Isnull(SUM(qtyinhand),0) as qtyinhand FROM stock where item_finished_id=" & Varfinishedid & " and godownid=" & ddgodown.SelectedValue & " And LotNo='" & Lotno & "' And CompanyId=" & ddCompName.SelectedValue & ""))
            BellQty = If(TxtBellWt.Text = "", 0, TxtBellWt.Text)

            If Varstockapply = True Then
                If Convert.ToDouble(qty) < Convert.ToDouble(txtissqty.Text) - Convert.ToDouble(BellQty) Then
                    MsgBox("Issue Qty Can not be greater than Stock Qty...")
                    txtstock.Text = qty.ToString()
                    Validatesave = False
                    Exit Function
                End If
            End If
            Validatesave = True
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Validatesave = True
    End Function
    Private Sub save_refresh()
        txtissue.Text = ""
        TxtProdCode.Text = ""
        txtpendingqty.Text = ""
        txtpreissue.Text = ""
        txtissqty.Text = ""
        TxtBellWt.Text = "0"
        txtstock.Text = ""
        GodownSelectedChanged()
        txtremarks.Text = ""
        If ddlotno.Visible = True Then
            ddlotno.SelectedIndex = 0
        End If
        TxtMoisture.Text = ""
        ddlotno.Focus()
    End Sub
    Protected Sub Fill_Grid()

        gvdetail.Rows.Clear()
        Dim i As Integer

        Dim strsql As String = "SELECT prt.PRTid,prt.LotNo, icm.CATEGORY_NAME, im.ITEM_NAME, gm.GodownName,  " & _
                         "prt.IssueQuantity,IPM1.QDCS + Space(2)+isnull(SizeMtr,'') DESCRIPTION,prt.Finishedid as Finishedid,prt.Tagno  FROM   " & _
                         "pp_ProcessRawTran prt  INNER JOIN ITEM_PARAMETER_MASTER ipm ON prt.Finishedid = ipm.ITEM_FINISHED_ID INNER JOIN " & _
                         "GodownMaster gm ON prt.Godownid = gm.GoDownID INNER JOIN " & _
                         "item_master im on im.item_id=ipm.item_id inner join " & _
                         "iTEM_CATEGORY_MASTER icm ON im.Category_id = icm.CATEGORY_ID inner join " & _
                         "pp_ProcessRawMaster prm on  prt.prmid=prm.prmid inner Join " & _
                         "ViewFindFinishedidItemidQDCSS IPM1 on IPM.Item_Finished_Id=IPM1.Finishedid " & _
                         "where prm.prmid=" & Prmid & " And im.MasterCompanyId=" & VarMasterCompanyID & ""
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                gvdetail.Rows.Add()
                gvdetail.Item("Prtidgrid", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("prtid")
                gvdetail.Item("ItemName", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Item_name")
                gvdetail.Item("Description", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Description")
                gvdetail.Item("godownname", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("godownname")
                gvdetail.Item("Lotno", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("Lotno")
                gvdetail.Item("TagNo", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("TagNo")
                gvdetail.Item("Issuequantity", gvdetail.Rows.Count - 1).Value = ds.Tables(0).Rows(i)("IssueQuantity")
            Next
        End If

    End Sub

    Private Sub btnnew_Click(sender As System.Object, e As System.EventArgs) Handles btnnew.Click
        refresh_form()
    End Sub

    Private Sub btnpriview_Click(sender As System.Object, e As System.EventArgs) Handles btnpriview.Click
        Report()
    End Sub
    Private Sub Report()
        Dim qry As String = "SELECT EmpName,Address,PhoneNo,Mobile,CompanyName,CompanyAddress,ComPanyPhoneNo,CompanyFaxNo,TinNo,Category_Name,Item_Name,QualityName,Designname," & _
                    " colorname,shapename,shadecolorname,SizeMtr,ChallanNo,Indentid,PRMid,IssueQuantity,LotNo,GodownNAme,ShortName,ShadeColorName,unitname, " & _
                    " companyid,IndentNo,Date,flagsize,CanQty,MastercompanyId,Process_Name,Buyercode,localorder,customerorderno,Remark,Tagno,GSTIN,EmpGStno, BinNo, " & _
                    " VehicleNo, DriverName, EWayBillNo, PurchaseRate, GSTType " & _
                    " FROM V_IndentRawIssue where V_IndentRawIssue.PRMid=" & Prmid & " And CompanyId=" & ddCompName.SelectedValue & "  ORDER BY V_IndentRawIssue.Item_Name "

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, qry)

        Dim str As String = "SELECT IssQty, CATEGORY_NAME, ITEM_NAME, Quality_Id, QualityName, PRMid, unitname, HSNCode, PurchaseRate, PurchaseAmt, GSTType, CGstAmt, SGstAmt, IGstAmt, UnitName " & _
            " FROM IndentRawIssue(Nolock) Where PRMid=" & Prmid & " ORDER BY Quality_Id"

        Dim sda As SqlDataAdapter = New SqlDataAdapter(str, Con)

        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        ds.Tables.Add(dt)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim VarSelectionFormula As String = ""
            Dim ObjFolio As New FrmCrystal
            Dim Objfile As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim sReportName As String
            Dim dspath As String

            If VarMasterCompanyID = "16" Then
                sReportName = (My.Application.Info.DirectoryPath & "\Reports\IndentRawIssueNEWChampo.rpt")
            Else
                If varTagNowise = "1" Then
                    sReportName = (My.Application.Info.DirectoryPath & "\Reports\IndentRawIssueTagwiseNEW.rpt")
                Else
                    sReportName = (My.Application.Info.DirectoryPath & "\Reports\IndentRawIssueNEW.rpt")
                End If
            End If

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

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub gvdetail_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvdetail.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Do you want to delete this row?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Message") = MsgBoxResult.No Then Exit Sub
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If

            Dim tran As SqlTransaction = Con.BeginTransaction()
            Try
                Dim arr(3) As SqlParameter
                arr(0) = New SqlParameter("@Prtid", SqlDbType.Int)
                arr(1) = New SqlParameter("@TableName", SqlDbType.NVarChar, 50)
                arr(2) = New SqlParameter("@Count", SqlDbType.Int)
                arr(3) = New SqlParameter("@FlagDeleteOrNot", SqlDbType.Int)
                arr(0).Value = gvdetail.Item("prtidgrid", gvdetail.CurrentRow.Index).Value
                arr(1).Value = "PP_ProcessRawTran"
                arr(2).Value = gvdetail.Rows.Count
                arr(3).Direction = ParameterDirection.Output
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "Pro_UpdateStockIssueDelete", arr)
                tran.Commit()
                ' ddgodown.SelectedIndex = -1
                If gvdetail.Rows.Count = 1 Then
                    Prmid = 0
                    Prtid = 0
                    txtchalanno.Text = ""
                End If
                If Convert.ToInt32(arr(3).Value) = 1 Then
                    MsgBox("AllReady Received Data....")
                Else
                    Fill_Grid()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                tran.Rollback()
            End Try
        End If
    End Sub

    Private Sub frmindentrowissue_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing Then
            _serialPort.Close()
            _serialPort = Nothing
        End If
    End Sub

    Private Sub DDBinNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DDBinNo.SelectedIndexChanged
        If dditemname.SelectedIndex <> -1 And dquality.SelectedIndex <> -1 And ddlshade.SelectedIndex <> -1 And DDBinNo.SelectedIndex <> -1 And Varcombovalue <> 0 Then
            Dim Varfinishedid As Integer = getItemFinishedId(dditemname.SelectedValue, dquality.SelectedValue, 0, 0, 0, 0, TxtProdCode.Text, ddlshade.SelectedValue, 0, "", VarMasterCompanyID)
            FillTagNo(Varfinishedid, sender)
        End If
    End Sub
End Class