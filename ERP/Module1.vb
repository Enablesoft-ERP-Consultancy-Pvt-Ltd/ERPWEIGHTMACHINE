Option Explicit On
Option Strict Off

Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient



Module Module1
    Public Con As New SqlClient.SqlConnection
    Public varPassOK As Boolean
    Public varPrinterName As String = ""
    Public Barcodetype As Integer = "1"
    Public varAdmPass As String = "Admin007"
    Public varAdmPassDyeing As String = "diya"
    Public subformopen As Integer
    Public Varcombovalue As Integer
    Public VarMasterCompanyID As Integer = -999
    Public varuserid As Integer
    Public VarSQLServer As String = ""
    Public VarSQLUserName As String = ""
    Public VarSQLPassword As String = ""
    Public VarDatabaseName As String = ""
    Public varTagNowise As String = "0"
    Public varcanedit As String = "0"
    Public varDyingautoloss = "0"
    Public VarWithoutBom = "0"
    Public Varcarpetcompany As String = "1 "
    Public Varstockapply As String = "0"
    Public VarBINNOWISE As String = "0"
    Public VarCHECKBINCONDITION As String = "0"
    Public VarFINISHINGNEWMODULEWISE As String = "0"
    Public VarPurchaseReceiveAutogenLotno As String = "0"
    Public VarCompanyID As Integer = -999

    Public Sub VariableSetting()
        'Variable Setting *********************
        Dim Strs As String = ""
        Dim Ds As New Data.DataSet
        Try
            Strs = "select distinct CompanyId,UserID,canedit from newuserdetail Where UserID = " & varuserid
            If Con.State = ConnectionState.Closed Then Con.Open()
            Ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, Strs)
            If Ds.Tables(0).Rows.Count > 0 Then
                VarMasterCompanyID = Ds.Tables(0).Rows(0)("CompanyId")
                varuserid = Ds.Tables(0).Rows(0)("UserID")
                varcanedit = Ds.Tables(0).Rows(0)("canedit")
            End If

            Strs = "select TagNowise,DyingAutoloss,DYEINGEDITPWD,Withoutbom,carpetcompany,stockapply,BINNOWISE,CHECKBINCONDITION,FINISHINGNEWMODULEWISE,PURCHASERECEIVEAUTOGENLOTNO From Mastersetting"
            Ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, Strs)
            If Ds.Tables(0).Rows.Count > 0 Then
                varTagNowise = Ds.Tables(0).Rows(0)("TagNowise")
                varDyingautoloss = Ds.Tables(0).Rows(0)("DyingAutoloss")
                varAdmPassDyeing = Ds.Tables(0).Rows(0)("DYEINGEDITPWD")
                VarWithoutBom = Ds.Tables(0).Rows(0)("Withoutbom")
                Varcarpetcompany = Ds.Tables(0).Rows(0)("carpetcompany")
                Varstockapply = Ds.Tables(0).Rows(0)("stockapply")
                VarBINNOWISE = Ds.Tables(0).Rows(0)("BINNOWISE")
                VarCHECKBINCONDITION = Ds.Tables(0).Rows(0)("CHECKBINCONDITION")
                VarFINISHINGNEWMODULEWISE = Ds.Tables(0).Rows(0)("FINISHINGNEWMODULEWISE")
                VarPurchaseReceiveAutogenLotno = Ds.Tables(0).Rows(0)("PURCHASERECEIVEAUTOGENLOTNO")
            End If
            Ds.Clear()
        Catch ex As Exception

        End Try
    End Sub
    Function Validtxtbox(ByRef txtbox As TextBox) As Boolean
        If Trim(txtbox.Text) = "" Then
            'MsgBox(" One or more Mandatory fields are empty " & txtbox.Tag), vbExclamation
            MsgBox("One or More mandatory Fields are Empty", MsgBoxStyle.OkOnly)
            Validtxtbox = False
            txtbox.Focus()
            Exit Function
        Else
            Validtxtbox = True
        End If
    End Function
    Function Validcombobox(ByRef cmbbox As ComboBox) As Boolean
        If Not (cmbbox.SelectedIndex) <> -1 Then
            MsgBox(" One or more Mandatory fields are Empty " & cmbbox.Tag, MsgBoxStyle.Exclamation)
            Validcombobox = False
            If cmbbox.Enabled = True Then cmbbox.Focus()
            Exit Function
        Else
            Validcombobox = True
        End If
    End Function

    ' Dim SqlHelper As Object

    Sub NewComboFillWithDs(ByRef comboname As ComboBox, ByRef ds As DataSet, ByVal i As Integer)

        Varcombovalue = 0
        ' da.Fill(ds)
        comboname.DataSource = ds.Tables(i)
        comboname.ValueMember = ds.Tables(i).Columns(0).ColumnName
        comboname.DisplayMember = ds.Tables(i).Columns(1).ColumnName
        comboname.SelectedIndex = -1
        Varcombovalue = 1

    End Sub
    Sub NewComboFill(ByRef comboname As ComboBox, ByVal strsql As String)

        Varcombovalue = 0

        Dim ds As New DataSet()
        ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
        ' da.Fill(ds)
        comboname.DataSource = ds.Tables(0)
        comboname.ValueMember = ds.Tables(0).Columns(0).ColumnName
        comboname.DisplayMember = ds.Tables(0).Columns(1).ColumnName
        comboname.SelectedIndex = -1
        Varcombovalue = 1

    End Sub
    Public Sub Stock_update(ByVal Item_Finished_Id As Integer, ByVal godownid As Integer, ByVal companyid As Integer, ByVal lotno As String, ByVal qty As Double, ByVal trandate As String, ByVal realdatetime As String, ByVal tablename As String, ByVal prtid As Integer, ByRef tran As SqlTransaction, ByVal trantype As Integer, ByVal BlnStockAddInQty As Boolean, ByVal typeid As Integer, ByVal Finish_Type As Integer, Optional ByVal TagNo As String = "Without Tag No")
        Dim StrSql As String
        Dim StockId As Integer
        If lotno = "" Then
            lotno = "Without Lot No"
        End If
        StrSql = "Select StockID From Stock Where Item_Finished_id=" & Item_Finished_Id & " And Godownid=" & godownid & " And Companyid=" & companyid & "and lotno='" & lotno & "' and TagNo='" & TagNo & "' And FINISHED_TYPE_ID=" & Finish_Type & ""
        StockId = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, CommandType.Text, StrSql))
        StrSql = ""
        If StockId > 0 Then
            If BlnStockAddInQty = True Then
                StrSql = "Update Stock Set QtyInHand=  QtyInHand  + " & qty & " Where StockId=" & StockId & " and Godownid=" & godownid & "  and CompanyID=" & companyid & " "
            Else
                StrSql = "Update Stock Set QtyInHand=QtyInHand - " & qty & " Where StockId=" & StockId & " and Godownid=" & godownid & "  and CompanyID=" & companyid & " "
            End If
        Else
            StockId = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, CommandType.Text, "Select IsNull(Max(StockId),0)&1 From Stock"))
            If BlnStockAddInQty = True Then
                StrSql = "Insert Into Stock (StockID,Item_Finished_id,QtyinHand,QtyAssigned,OpenStock,GodownId,Companyid,Price,LotNo,TypeId,Finished_Type_Id,TagNo) Values (" & StockId & "," & Item_Finished_Id & "," & qty & ",0,0," & godownid & "," & companyid & ",0,'" & lotno & "'," & typeid & "," & Finish_Type & ",'" & TagNo & "')"
            Else
                StrSql = "Insert Into Stock (StockID,Item_Finished_id,QtyinHand,QtyAssigned,OpenStock,GodownId,Companyid,Price,LotNo,TypeId,Finished_Type_Id,TagNo) Values (" & StockId & "," & Item_Finished_Id & ", 0 -" & qty & ",0,0," & godownid & "," & companyid & ",0,'" & lotno & "'," & typeid & "," & Finish_Type & ",'" & TagNo & "')"
            End If
        End If
        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, StrSql)
        StrSql = ""
        Dim TranId As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(tran, CommandType.Text, "Select IsNull(Max(StockTranId),0)+1 From StockTran"))
        StrSql = "Insert Into StockTran(Stockid,StockTranId,TranType,Quantity,TranDate,Userid,RealDate,TableName,PRTId) Values (" & StockId & "," & TranId & ",'" & trantype & "'," & qty & ",'" & Convert.ToDateTime(trandate) & "',0,'" & Convert.ToDateTime(realdatetime) & "','" & tablename & "'," & prtid & ")"
        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, StrSql)
    End Sub
    Sub ConditionalComboFillWithDS(ByRef comboname As ComboBox, ByVal ds As DataSet, ByVal i As Integer, ByVal isSelectText As Boolean, ByVal selecttext As String)
        Try
            Varcombovalue = 0
            comboname.Items.Clear()
            comboname.Text = ""
            If ds.Tables(i).Rows.Count > 0 Then
                comboname.DataSource = ds.Tables(i)
                comboname.DisplayMember = ds.Tables(i).Columns(1).ToString()
                comboname.ValueMember = ds.Tables(i).Columns(0).ToString()
                comboname.SelectedIndex = -1
                Varcombovalue = 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function getItemFinishedId(ByVal ddItemName As Integer, ByVal ddQuality As Integer, ByVal ddDesign As Integer, ByVal ddColor As Integer, ByVal ddShape As Integer, ByVal ddSize As Integer, ByVal ProdCode As String, ByVal ddShadeColor As Integer, ByVal ProdType As Integer, ByVal VarOurCode As String, ByVal MasterCompanyId As Integer) As Integer
        Dim itemfinishedid As Integer = 0
        Try
            Dim VarProdCode As String = ProdCode
            If ProdType = 0 Then
                VarProdCode = ""
            End If

            Dim _arrPara(11) As SqlParameter
            _arrPara(0) = New SqlParameter("@ITEM_FINISHED_ID", SqlDbType.Int)
            _arrPara(1) = New SqlParameter("@QUALITY_ID", SqlDbType.Int)
            _arrPara(2) = New SqlParameter("@DESIGN_ID", SqlDbType.Int)
            _arrPara(3) = New SqlParameter("@COLOR_ID", SqlDbType.Int)
            _arrPara(4) = New SqlParameter("@SHAPE_ID", SqlDbType.Int)
            _arrPara(5) = New SqlParameter("@SIZE_ID", SqlDbType.Int)
            _arrPara(6) = New SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 100)
            _arrPara(7) = New SqlParameter("@ITEM_ID", SqlDbType.Int)
            _arrPara(8) = New SqlParameter("@ProCode", SqlDbType.NVarChar)
            _arrPara(9) = New SqlParameter("@SHADECOLOR_ID", SqlDbType.Int)
            _arrPara(10) = New SqlParameter("@VarOurCode", SqlDbType.VarChar, 100)
            _arrPara(11) = New SqlParameter("@MasterCompanyId", SqlDbType.Int)
            _arrPara(0).Direction = ParameterDirection.Output
            _arrPara(1).Value = ddQuality
            _arrPara(2).Value = ddDesign
            _arrPara(3).Value = ddColor
            _arrPara(4).Value = ddShape
            _arrPara(5).Value = ddSize
            _arrPara(6).Value = ""
            _arrPara(7).Value = ddItemName
            _arrPara(8).Value = VarProdCode
            _arrPara(9).Value = ddShadeColor
            _arrPara(10).Value = VarOurCode
            _arrPara(11).Value = MasterCompanyId
            SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, "PRO_GET_ITEM_FINISHED_ID", _arrPara)
            itemfinishedid = Convert.ToInt32(_arrPara(0).Value)
        Catch ex As Exception


        End Try

        Return itemfinishedid
    End Function
    Public Function getItemFinishedId(ByVal ddItemName As Integer, ByVal ddQuality As Integer, ByVal ddDesign As Integer, ByVal ddColor As Integer, ByVal ddShape As Integer, ByVal ddSize As Integer, ByVal ProdCode As String, ByVal ddShadeColor As Integer, ByVal ProdType As Integer, ByVal VarOurCode As String, ByVal MasterCompanyId As Integer, ByRef Tran As SqlTransaction) As Integer
        Dim itemfinishedid As Integer = 0
        Try
            Dim VarProdCode As String = ProdCode
            If ProdType = 0 Then
                VarProdCode = ""
            End If

            Dim _arrPara(11) As SqlParameter
            _arrPara(0) = New SqlParameter("@ITEM_FINISHED_ID", SqlDbType.Int)
            _arrPara(1) = New SqlParameter("@QUALITY_ID", SqlDbType.Int)
            _arrPara(2) = New SqlParameter("@DESIGN_ID", SqlDbType.Int)
            _arrPara(3) = New SqlParameter("@COLOR_ID", SqlDbType.Int)
            _arrPara(4) = New SqlParameter("@SHAPE_ID", SqlDbType.Int)
            _arrPara(5) = New SqlParameter("@SIZE_ID", SqlDbType.Int)
            _arrPara(6) = New SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 100)
            _arrPara(7) = New SqlParameter("@ITEM_ID", SqlDbType.Int)
            _arrPara(8) = New SqlParameter("@ProCode", SqlDbType.NVarChar)
            _arrPara(9) = New SqlParameter("@SHADECOLOR_ID", SqlDbType.Int)
            _arrPara(10) = New SqlParameter("@VarOurCode", SqlDbType.VarChar, 100)
            _arrPara(11) = New SqlParameter("@MasterCompanyId", SqlDbType.Int)
            _arrPara(0).Direction = ParameterDirection.Output
            _arrPara(1).Value = ddQuality
            _arrPara(2).Value = ddDesign
            _arrPara(3).Value = ddColor
            _arrPara(4).Value = ddShape
            _arrPara(5).Value = ddSize
            _arrPara(6).Value = ""
            _arrPara(7).Value = ddItemName
            _arrPara(8).Value = VarProdCode
            _arrPara(9).Value = ddShadeColor
            _arrPara(10).Value = VarOurCode
            _arrPara(11).Value = MasterCompanyId
            SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "PRO_GET_ITEM_FINISHED_ID", _arrPara)
            itemfinishedid = Convert.ToInt32(_arrPara(0).Value)
        Catch ex As Exception

            Tran.Rollback()
            MsgBox(ex.Message)
        End Try

        Return itemfinishedid
    End Function
    Public Sub StockStockTranTableUpdate(ByVal Item_Finished_Id As Integer, ByVal Godownid As Integer, ByVal Companyid As Integer, ByVal LotNo As String, ByVal Qty As Double, ByVal TranDate As String, ByVal RealDateTime As String, ByVal TableName As String, ByVal PRTId As Integer, ByVal Tran As SqlTransaction, ByVal TranType As Integer, ByVal BlnStockAddInQty As Boolean, ByVal TypeId As Integer, ByVal Finish_Type As Integer, Optional ByVal unitid As Integer = 0, Optional ByVal TagNo As String = "Without Tag No", Optional ByVal BinNo As String = "")
        Dim StrSql As String
        Dim StockId As Integer
        If LotNo = "" Then
            LotNo = "Without Lot No"
        End If

        StrSql = "Select StockID From Stock Where Item_Finished_id=" & Item_Finished_Id & " And Godownid=" & Godownid & " And Companyid=" & Companyid & "and lotno='" & LotNo & "' And FINISHED_TYPE_ID=" & Finish_Type & "  and TagNo='" & TagNo & "' And BinNo='" & BinNo & "'"
        StockId = Convert.ToInt32(SqlHelper.ExecuteScalar(Tran, CommandType.Text, StrSql))
        StrSql = ""
        If StockId > 0 Then
            If BlnStockAddInQty = True Then
                StrSql = "Update Stock Set QtyInHand=  QtyInHand + " & Qty & " Where StockId=" & StockId & " and Godownid=" & Godownid & "  and CompanyID=" & Companyid
            Else
                StrSql = "Update Stock Set QtyInHand=QtyInHand - " & Qty & " Where StockId=" & StockId & " and Godownid=" & Godownid & "  and CompanyID=" & Companyid
            End If
        Else
            StockId = Convert.ToInt32(SqlHelper.ExecuteScalar(Tran, CommandType.Text, "Select IsNull(Max(StockId),0)+1 From Stock"))
            If BlnStockAddInQty = True Then
                StrSql = "Insert Into Stock (StockID,Item_Finished_id,QtyinHand,QtyAssigned,OpenStock,GodownId,Companyid,Price,LotNo,TypeId,Finished_Type_Id,TagNo,BinNo) Values (" & StockId & "," & Item_Finished_Id & "," & Qty & ",0,0," & Godownid & "," & Companyid & ",0,'" & LotNo & "'," & TypeId & "," & Finish_Type & ",'" & TagNo & "','" & BinNo & "')"
            Else
                StrSql = "Insert Into Stock (StockID,Item_Finished_id,QtyinHand,QtyAssigned,OpenStock,GodownId,Companyid,Price,LotNo,TypeId,Finished_Type_Id,TagNo,BinNo) Values (" & StockId & "," & Item_Finished_Id & ", 0 -" & Qty & ",0,0," & Godownid & "," & Companyid & ",0,'" & LotNo & "'," & TypeId & "," & Finish_Type & ",'" & TagNo & "','" & BinNo & "')"
            End If
        End If

        SqlHelper.ExecuteNonQuery(Tran, CommandType.Text, StrSql)
        StrSql = ""
        Dim TranId As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(Tran, CommandType.Text, "Select IsNull(Max(StockTranId),0)+1 From StockTran"))
        StrSql = "Insert Into StockTran(Stockid,StockTranId,TranType,Quantity,TranDate,Userid,RealDate,TableName,PRTId,unitid) Values (" & StockId & "," & TranId & ",'" & TranType & "'," & Qty & ",'" & Convert.ToDateTime(TranDate) & "'," & varuserid & ",'" + Convert.ToDateTime(RealDateTime) & "','" & TableName & "'," & PRTId & "," & unitid & ")"
        SqlHelper.ExecuteNonQuery(Tran, CommandType.Text, StrSql)
    End Sub
    Public Function fnCheckTodayUpdateDelete() As Boolean

        Dim Ds As New Data.DataSet

        fnCheckTodayUpdateDelete = False

        frmUserAuth.ShowDialog()
        If varPassOK = False Then
            fnCheckTodayUpdateDelete = True
            Exit Function
        End If
        fnCheckTodayUpdateDelete = False
        varPassOK = False
        Return (fnCheckTodayUpdateDelete)
    End Function

    Public Function getstockQty(ByVal companyid As String, ByVal Godownid As String, ByVal Lotno As String, ByVal Item_finished_id As Integer, Optional ByVal TagNo As String = "Without Tag No", Optional ByVal BinNo As String = "") As Double
        Dim stockqTY As Double = 0
        Dim str As String = "select Round(isnull(sum(Qtyinhand),0),3) as Qtyinhand from Stock Where companyId= " & companyid & " and godownId=" & Godownid & " and Lotno='" & Lotno & "' and Item_finished_id=" & Item_finished_id & " and TagNo='" & TagNo & "' and BinNo='" & BinNo & "'"
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            stockqTY = Convert.ToDouble(ds.Tables(0).Rows(0)("Qtyinhand"))
        End If
        Return stockqTY
    End Function
    Public Sub StockStockTranTableUpdateNew(ByVal Item_Finished_Id As Integer, ByVal Godownid As Integer, ByVal Companyid As Integer, ByVal LotNo As String, ByVal Qty As Double, ByVal TranDate As String, ByVal RealDateTime As String, ByVal TableName As String, ByVal PRTId As Integer, ByVal Tran As SqlTransaction, ByVal TranType As Integer, ByVal BlnStockAddInQty As Boolean, ByVal TypeId As Integer, ByVal Finish_Type As Integer, Optional ByVal UnitId As Integer = 0, Optional ByVal TagNo As String = "Without Tag No", Optional ByVal BinNo As String = "")
        Dim param As SqlParameter() = New SqlParameter(17) {}
        param(0) = New SqlParameter("@item_Finished_id", Item_Finished_Id)
        param(1) = New SqlParameter("@Godownid", Godownid)
        param(2) = New SqlParameter("@Companyid", Companyid)
        param(3) = New SqlParameter("@Lotno", LotNo)
        param(4) = New SqlParameter("@Qty", Qty)
        param(5) = New SqlParameter("@Trandate", TranDate)
        param(6) = New SqlParameter("@RealDateTime", RealDateTime)
        param(7) = New SqlParameter("@TableName", TableName)
        param(8) = New SqlParameter("@Prtid", PRTId)
        param(9) = New SqlParameter("@TranType", TranType)
        param(10) = New SqlParameter("@BlnStockAddInQty", BlnStockAddInQty)
        param(11) = New SqlParameter("@Type_Id", TypeId)
        param(12) = New SqlParameter("@FInish_Type", Finish_Type)
        param(13) = New SqlParameter("@unitid", UnitId)
        param(14) = New SqlParameter("@TagNo", TagNo)
        param(15) = New SqlParameter("@Userid", varuserid)
        param(16) = New SqlParameter("@BinNo", BinNo)
        SqlHelper.ExecuteNonQuery(Tran, CommandType.StoredProcedure, "pro_savestockqty", param)
    End Sub

    Public Function Getmottelingrate(ByVal Itemid As String, ByVal Qualityid As String, ByVal Jobid As String, ByVal empid As String, ByVal effectivedate As String, Optional ByVal shadecolorid As String = "0", Optional ByVal Conetype As String = "", Optional ByVal PlyType As String = "", Optional ByVal TransportType As String = "") As Double
        Dim Rate As Double = 0
        Dim param As SqlParameter() = New SqlParameter(10) {}
        param(0) = New SqlParameter("@EMPID", empid)
        param(1) = New SqlParameter("@ITEMID", Itemid)
        param(2) = New SqlParameter("@QUALITYID", Qualityid)
        param(3) = New SqlParameter("@PROCESSID", Jobid)
        param(4) = New SqlParameter("@Effectivedate", effectivedate)
        param(5) = New SqlParameter("@Rate", SqlDbType.Float)
        param(5).Direction = ParameterDirection.Output
        param(6) = New SqlParameter("@shadecolorid", shadecolorid)
        param(7) = New SqlParameter("@Conetype", Conetype)
        param(8) = New SqlParameter("@PlyType", PlyType)
        param(9) = New SqlParameter("@TransportType", TransportType)
        SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, "PRO_GETMOTTELINGRATE", param)
        Rate = Convert.ToDouble(param(5).Value)
        Return Rate
    End Function

    Public Function GetHandSpinningRate(ByVal Itemid As String, ByVal Qualityid As String, ByVal Jobid As String, ByVal empid As String, ByVal effectivedate As String, Optional ByVal shadecolorid As String = "0") As Double
        Dim Rate As Double = 0
        Dim param As SqlParameter() = New SqlParameter(6) {}
        param(0) = New SqlParameter("@EMPID", empid)
        param(1) = New SqlParameter("@ITEMID", Itemid)
        param(2) = New SqlParameter("@QUALITYID", Qualityid)
        param(3) = New SqlParameter("@PROCESSID", Jobid)
        param(4) = New SqlParameter("@Effectivedate", effectivedate)
        param(5) = New SqlParameter("@Rate", SqlDbType.Float)
        param(5).Direction = ParameterDirection.Output
        param(6) = New SqlParameter("@shadecolorid", shadecolorid)
        SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, "PRO_GETHANDSPINNINGRATE", param)
        Rate = Convert.ToDouble(param(5).Value)
        Return Rate
    End Function
    Public Sub FillBinNO(Optional ByVal DDBinNo As ComboBox = Nothing, Optional ByVal godownid As Integer = 0, Optional ByVal Item_finished_id As Integer = 0, Optional ByVal New_Edit As Integer = 0, Optional ByVal Tran As SqlTransaction = Nothing)
        Dim param As SqlParameter() = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Godownid", godownid)
        param(1) = New SqlParameter("@Item_finished_id", Item_finished_id)
        param(2) = New SqlParameter("@New_Edit", New_Edit)
        Dim ds As DataSet
        If Tran Is Nothing Then
            ds = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "FILL_BINNO", param)
        Else
            ds = SqlHelper.ExecuteDataset(Tran, CommandType.StoredProcedure, "FILL_BINNO", param)
        End If

        NewComboFillWithDs(DDBinNo, ds, 0)

    End Sub
    Public Sub FillBinNo_Grid_Combo(ByRef cmbbobox As DataGridViewComboBoxCell, Optional ByVal godownid As Integer = 0, Optional ByVal Item_finished_id As Integer = 0, Optional ByVal New_Edit As Integer = 0, Optional ByVal Tran As SqlTransaction = Nothing)
        Dim param As SqlParameter() = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Godownid", godownid)
        param(1) = New SqlParameter("@Item_finished_id", Item_finished_id)
        param(2) = New SqlParameter("@New_Edit", New_Edit)
        Dim ds As DataSet
        If Tran Is Nothing Then
            ds = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "FILL_BINNO", param)
        Else
            ds = SqlHelper.ExecuteDataset(Tran, CommandType.StoredProcedure, "FILL_BINNO", param)
        End If
        cmbbobox.DataSource = ds.Tables(0)
        cmbbobox.ValueMember = ds.Tables(0).Columns(0).ColumnName
        cmbbobox.DisplayMember = ds.Tables(0).Columns(1).ColumnName

    End Sub
    Public Sub FillBinNO_GRIDVIEW(Optional ByVal DDBinNo As DataGridViewComboBoxCell = Nothing, Optional ByVal godownid As Integer = 0, Optional ByVal Item_finished_id As Integer = 0, Optional ByVal New_Edit As Integer = 0, Optional ByVal Tran As SqlTransaction = Nothing)
        Dim param As SqlParameter() = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Godownid", godownid)
        param(1) = New SqlParameter("@Item_finished_id", Item_finished_id)
        param(2) = New SqlParameter("@New_Edit", New_Edit)
        Dim ds As DataSet
        If Tran Is Nothing Then
            ds = SqlHelper.ExecuteDataset(Con, CommandType.StoredProcedure, "FILL_BINNO", param)
        Else
            ds = SqlHelper.ExecuteDataset(Tran, CommandType.StoredProcedure, "FILL_BINNO", param)
        End If

        DDBinNo.DataSource = ds.Tables(0)
        DDBinNo.ValueMember = ds.Tables(0).Columns(0).ColumnName
        DDBinNo.DisplayMember = ds.Tables(0).Columns(1).ColumnName

    End Sub
End Module
