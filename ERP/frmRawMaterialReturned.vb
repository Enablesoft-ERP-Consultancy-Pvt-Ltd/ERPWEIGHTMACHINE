Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO.Ports
Imports System.Threading

Public Class frmRawMaterialReturned
    Private Sub frmRawMaterialReturned_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'cmb_port.Items.AddRange(SerialPort.GetPortNames())
        'If cmb_port.Items.Count > 0 Then
        '    cmb_port.SelectedIndex = cmb_port.Items.Count - 1
        'End If
    End Sub
    Private Sub fill_grid()
        Dim str As String
        Dim ds As SqlClient.SqlDataReader

        DGDetail.Rows.Clear()
        ' Dim i As Integer
        str = "Select PM.CompanyId,CATEGORY_NAME,ITEM_NAME,QualityName+ Space(2)+DesignName+ Space(2)+ColorName+ Space(2)+ShapeName+" & _
  " Space(2)+SizeMtr+ Space(2)+ShadeColorName DESCRIPTION,Sum(case When Trantype=0 Then IssueQuantity Else 0 End)" & _
  " As IssuedQty,Sum(case When TranType=1 Then IssueQuantity Else 0 End) as ReceivedQty,LotNo,Godownid,Prorderid" & _
   " As IssueOrderId,PT.Finishedid,PT.UnitId,PT.CategoryId From ProcessRawMaster PM,ProcessRawTran PT," & _
   " V_FinishedItemDetail VF Where PM.PrmId=PT.PrmId and  PT.Finishedid=VF.Item_Finished_id  And" & _
   " PM.PrOrderid='" & txtFolioNo.Text & "' Group by PM.CompanyId,Category_name,Item_name,QualityName,DesignName,Colorname,ShapeName," & _
        " Sizemtr, ShadeColorname, LotNo, godownid, prorderid, PT.Finishedid, PT.UnitId, PT.CategoryId"
        ds = SqlHelper.ExecuteReader(Con, CommandType.Text, str)
        While ds.Read()
            DGDetail.Rows.Add()
            DGDetail.Item("CompanyId", DGDetail.Rows.Count - 1).Value = ds("companyid")
            DGDetail.Item("Catagory", DGDetail.Rows.Count - 1).Value = ds("CATEGORY_NAME")
            DGDetail.Item("itemname", DGDetail.Rows.Count - 1).Value = ds("ITEM_NAME")
            DGDetail.Item("DESCRIPTION", DGDetail.Rows.Count - 1).Value = ds("DESCRIPTION")
            DGDetail.Item("issuedqty", DGDetail.Rows.Count - 1).Value = ds("issuedqty")
            DGDetail.Item("ReceivedQty", DGDetail.Rows.Count - 1).Value = ds("receivedqty")
            DGDetail.Item("lotno", DGDetail.Rows.Count - 1).Value = ds("lotno")
            DGDetail.Item("godown", DGDetail.Rows.Count - 1).Value = ds("godownid")
            DGDetail.Item("IssueOrderid", DGDetail.Rows.Count - 1).Value = ds("IssueOrderId")
            DGDetail.Item("FinishedId", DGDetail.Rows.Count - 1).Value = ds("Finishedid")
            DGDetail.Item("UnitId", DGDetail.Rows.Count - 1).Value = ds("unitid")
            DGDetail.Item("CategoryId", DGDetail.Rows.Count - 1).Value = ds("CategoryId")
            DGDetail.Item("save", DGDetail.Rows.Count - 1).Value = "Save"
            'DG1.Item("returnqty", DG1.Rows.Count - 1).Value = ""
        End While
        ds.Close()
    End Sub
    Private Sub TxtFolioNo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFolioNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtFolioNo.Text <> "" Then
                lblprid.Text = "0"
                Call fill_grid()
            Else
                MsgBox("No Record Found.....", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub
    'Private Sub DGDetail_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetail.CellClick
    '    If Validtxtbox(txtFolioNo) = False Then Exit Sub
    '    Select Case DGDetail.Columns(e.ColumnIndex).Name
    '        Case "save"
    '            If Con.State = ConnectionState.Closed Then Con.Open()
    '            Dim Tran As SqlTransaction = Con.BeginTransaction
    '            Try
    '                If Val(DGDetail.Item("ReturnQty", DGDetail.CurrentRow.Index).Value) = 0 Then
    '                    MsgBox("Plz Enter Return Qty.....", MsgBoxStyle.OkOnly, "Message")
    '                    DGDetail.Item("returnQty", DGDetail.CurrentRow.Index).Selected = True
    '                    Tran.Commit()
    '                    Exit Sub
    '                End If
    '                If Val(DGDetail.Item("ReturnQty", DGDetail.CurrentRow.Index).Value) + Val(DGDetail.Item("ReceivedQty", DGDetail.CurrentRow.Index).Value) > Val(DGDetail.Item("IssuedQty", DGDetail.CurrentRow.Index).Value) Then
    '                    MsgBox("Return Qty Can not be greater than Issued Qty..", MsgBoxStyle.OkOnly)
    '                    DGDetail.Item("returnQty", DGDetail.CurrentRow.Index).Selected = True
    '                    Tran.Commit()
    '                    Exit Sub
    '                End If
    '                Dim param(23) As SqlParameter
    '                param(0) = New SqlParameter("@PrmID", SqlDbType.Int)
    '                param(1) = New SqlParameter("@CompanyId", SqlDbType.Int)
    '                param(2) = New SqlParameter("@EmpId", SqlDbType.Int)
    '                param(3) = New SqlParameter("@ProcessId", SqlDbType.Int)
    '                param(4) = New SqlParameter("@OrderId", SqlDbType.Int)
    '                param(5) = New SqlParameter("@IssueDate", SqlDbType.SmallDateTime)
    '                param(6) = New SqlParameter("@ChalanNo", SqlDbType.NVarChar, 50)
    '                param(7) = New SqlParameter("@TranType", SqlDbType.Int)
    '                param(8) = New SqlParameter("@userid", SqlDbType.Int)
    '                param(9) = New SqlParameter("@mastercompanyid", SqlDbType.Int)
    '                param(10) = New SqlParameter("@Prtid", SqlDbType.Int)
    '                param(11) = New SqlParameter("@CategoryId", SqlDbType.Int)
    '                param(12) = New SqlParameter("@Itemid", SqlDbType.Int)
    '                param(13) = New SqlParameter("@FinishedId", SqlDbType.Int)
    '                param(14) = New SqlParameter("@GodownId", SqlDbType.Int)
    '                param(15) = New SqlParameter("@IssueQuantity", SqlDbType.Float)
    '                param(16) = New SqlParameter("@lotNo", SqlDbType.NVarChar, 50)
    '                param(17) = New SqlParameter("@UnitId", SqlDbType.Int)
    '                param(18) = New SqlParameter("@PrmIdOutPut", SqlDbType.Int)
    '                param(19) = New SqlParameter("@PrtIdOutPut", SqlDbType.Int)
    '                param(20) = New SqlParameter("@UpdateFlag", SqlDbType.Int)
    '                param(21) = New SqlParameter("@ConeTypeId", SqlDbType.Int)
    '                param(22) = New SqlParameter("@ItemRemarks", SqlDbType.VarChar, 500)
    '                If lblprid.Text = "" Then
    '                    lblprid.Text = "0"
    '                End If
    '                param(0).Value = lblprid.Text
    '                param(1).Value = DGDetail.Item("companyid", DGDetail.CurrentRow.Index).Value ' ddCompName.SelectedValue
    '                param(2).Value = 0 ' ddempname.SelectedValue
    '                param(3).Value = 1 ' ddProcessName.SelectedValue
    '                param(4).Value = DGDetail.Item("IssueOrderid", DGDetail.CurrentRow.Index).Value ' ddOrderNo.SelectedValue
    '                param(5).Value = System.DateTime.Now.ToString("dd-MMM-yyyy")
    '                param(6).Value = "" ' txtchalanno.Text
    '                param(6).Direction = ParameterDirection.InputOutput
    '                param(7).Value = 1
    '                param(8).Value = varuserid    'userid
    '                param(9).Value = VarMasterCompanyID 'companyid
    '                param(10).Value = 0
    '                param(11).Value = DGDetail.Item("CategoryId", DGDetail.CurrentRow.Index).Value
    '                param(12).Value = 0
    '                param(20).Value = 0
    '                param(13).Value = DGDetail.Item("finishedid", DGDetail.CurrentRow.Index).Value
    '                param(14).Value = DGDetail.Item("godown", DGDetail.CurrentRow.Index).Value
    '                param(15).Value = DGDetail.Item("returnQty", DGDetail.CurrentRow.Index).Value
    '                param(16).Value = Val(DGDetail.Item("lotno", DGDetail.CurrentRow.Index).Value)
    '                param(17).Value = Val(DGDetail.Item("unitid", DGDetail.CurrentRow.Index).Value) 'Unit KG
    '                param(18).Direction = ParameterDirection.Output
    '                param(19).Direction = ParameterDirection.Output
    '                param(21).Value = 0 'conetypeId
    '                param(22).Value = ""
    '                SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PROCESS_RAW_ISSUEForAnisha", param)
    '                Call Stock_update(Convert.ToInt16(param(13).Value), Convert.ToInt16(DGDetail.Item("godown", DGDetail.CurrentRow.Index).Value), Convert.ToInt16(DGDetail.Item("companyid", DGDetail.CurrentRow.Index).Value), Val(DGDetail.Item("lotno", DGDetail.CurrentRow.Index).Value), Convert.ToDouble(DGDetail.Item("returnQty", DGDetail.CurrentRow.Index).Value), DateTime.Now.ToString("dd-MMM-yyyy"), DateTime.Now.ToString("dd-MMM-yyyy"), "ProcessRawTran", Convert.ToInt32(param(19).Value), Tran, 1, True, 1, 0)
    '                Tran.Commit()
    '                lblprid.Text = param(18).Value
    '                DGDetail.Rows.Clear()
    '                Call fill_grid()
    '                MsgBox("Data Saved Successfully....")
    '            Catch ex As Exception
    '                Tran.Rollback()
    '            End Try
    '    End Select
    'End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        txtFolioNo.Text = ""
        DGDetail.Rows.Clear()
    End Sub
    Event DGDetailbuttonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
    Private Sub DGDetail_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetail.CellContentClick
        Dim sendergrid = DirectCast(sender, DataGridView)
        If TypeOf sendergrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent DGDetailbuttonClick(sendergrid, e)
        End If
    End Sub
    Private Sub DGDetail_ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles Me.DGDetailbuttonClick
        If Con.State = ConnectionState.Closed Then Con.Open()
        Dim Tran As SqlTransaction = Con.BeginTransaction
        Try
            If Val(DGDetail.Item("ReturnQty", DGDetail.CurrentRow.Index).Value) = 0 Then
                MsgBox("Plz Enter Return Qty.....", MsgBoxStyle.OkOnly, "Message")
                DGDetail.Item("returnQty", DGDetail.CurrentRow.Index).Selected = True
                Tran.Commit()
                Exit Sub
            End If
            If Val(DGDetail.Item("ReturnQty", DGDetail.CurrentRow.Index).Value) + Val(DGDetail.Item("ReceivedQty", DGDetail.CurrentRow.Index).Value) > Val(DGDetail.Item("IssuedQty", DGDetail.CurrentRow.Index).Value) Then
                MsgBox("Return Qty Can not be greater than Issued Qty..", MsgBoxStyle.OkOnly)
                DGDetail.Item("returnQty", DGDetail.CurrentRow.Index).Selected = True
                Tran.Commit()
                Exit Sub
            End If
            Dim param(23) As SqlParameter
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
            param(21) = New SqlParameter("@ConeTypeId", SqlDbType.Int)
            param(22) = New SqlParameter("@ItemRemarks", SqlDbType.VarChar, 500)
            If lblprid.Text = "" Then
                lblprid.Text = "0"
            End If
            param(0).Value = lblprid.Text
            param(1).Value = DGDetail.Item("companyid", DGDetail.CurrentRow.Index).Value ' ddCompName.SelectedValue
            param(2).Value = 0 ' ddempname.SelectedValue
            param(3).Value = 1 ' ddProcessName.SelectedValue
            param(4).Value = DGDetail.Item("IssueOrderid", DGDetail.CurrentRow.Index).Value ' ddOrderNo.SelectedValue
            param(5).Value = System.DateTime.Now.ToString("dd-MMM-yyyy")
            param(6).Value = "" ' txtchalanno.Text
            param(6).Direction = ParameterDirection.InputOutput
            param(7).Value = 1
            param(8).Value = varuserid    'userid
            param(9).Value = VarMasterCompanyID 'companyid
            param(10).Value = 0
            param(11).Value = DGDetail.Item("CategoryId", DGDetail.CurrentRow.Index).Value
            param(12).Value = 0
            param(20).Value = 0
            param(13).Value = DGDetail.Item("finishedid", DGDetail.CurrentRow.Index).Value
            param(14).Value = DGDetail.Item("godown", DGDetail.CurrentRow.Index).Value
            param(15).Value = DGDetail.Item("returnQty", DGDetail.CurrentRow.Index).Value
            param(16).Value = Val(DGDetail.Item("lotno", DGDetail.CurrentRow.Index).Value)
            param(17).Value = Val(DGDetail.Item("unitid", DGDetail.CurrentRow.Index).Value) 'Unit KG
            param(18).Direction = ParameterDirection.Output
            param(19).Direction = ParameterDirection.Output
            param(21).Value = 0 'conetypeId
            param(22).Value = ""
            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_PROCESS_RAW_ISSUEForAnisha", param)
            Call Stock_update(Convert.ToInt16(param(13).Value), Convert.ToInt16(DGDetail.Item("godown", DGDetail.CurrentRow.Index).Value), Convert.ToInt16(DGDetail.Item("companyid", DGDetail.CurrentRow.Index).Value), Val(DGDetail.Item("lotno", DGDetail.CurrentRow.Index).Value), Convert.ToDouble(DGDetail.Item("returnQty", DGDetail.CurrentRow.Index).Value), DateTime.Now.ToString("dd-MMM-yyyy"), DateTime.Now.ToString("dd-MMM-yyyy"), "ProcessRawTran", Convert.ToInt32(param(19).Value), Tran, 1, True, 1, 0)
            Tran.Commit()
            lblprid.Text = param(18).Value
            DGDetail.Rows.Clear()
            Call fill_grid()
            MsgBox("Data Saved Successfully....")
        Catch ex As Exception
            Tran.Rollback()
        End Try
    End Sub
End Class