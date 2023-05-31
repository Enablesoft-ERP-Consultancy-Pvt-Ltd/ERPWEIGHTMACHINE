<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpurchasereceive
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ChkEditOrder = New System.Windows.Forms.CheckBox()
        Me.DDCompanyName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DDPartyName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DDChallanNo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ddlrecchalanno = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtReceiveDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtGateInNo = New System.Windows.Forms.TextBox()
        Me.TxtBillNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtbillno1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtretdate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtfreight = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextItemCode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DDCustomerOrderNo = New System.Windows.Forms.ComboBox()
        Me.LblCustomerOrderNo = New System.Windows.Forms.Label()
        Me.chkoldlotno = New System.Windows.Forms.CheckBox()
        Me.txtcomplotno = New System.Windows.Forms.TextBox()
        Me.lblcomplotno = New System.Windows.Forms.Label()
        Me.DDBinno = New System.Windows.Forms.ComboBox()
        Me.lblbinno = New System.Windows.Forms.Label()
        Me.DDUnit = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtbaleno = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DDLotNo = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DDGodown = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DDColorShade = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DDQuality = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DDItem = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DDCategory = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtMoisture = New System.Windows.Forms.TextBox()
        Me.LblMoisture = New System.Windows.Forms.Label()
        Me.txtIgst = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtsgst = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtbellwt = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Txtnetamount = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TxtPenalty = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TxtAmount = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtrate = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Txtreturnqty = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtPQty = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtorderqty = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtmastremark = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnpreview = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.DGporder = New System.Windows.Forms.DataGridView()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblfinishedid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblcategoryid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblitem_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblQualityid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblshadecolorid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblrecqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblorderid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbllotno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGPurchaseReceiveDetail = New System.Windows.Forms.DataGridView()
        Me.gridPurchaseReceiveDetailId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GodownName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LOTNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblsrno = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.ChkLotwisesummary = New System.Windows.Forms.CheckBox()
        Me.chkprintbarcode = New System.Windows.Forms.CheckBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmbprintername = New System.Windows.Forms.ComboBox()
        Me.BtnComplete = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGporder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGPurchaseReceiveDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChkEditOrder
        '
        Me.ChkEditOrder.AutoSize = True
        Me.ChkEditOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkEditOrder.Location = New System.Drawing.Point(3, 2)
        Me.ChkEditOrder.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkEditOrder.Name = "ChkEditOrder"
        Me.ChkEditOrder.Size = New System.Drawing.Size(103, 17)
        Me.ChkEditOrder.TabIndex = 0
        Me.ChkEditOrder.Text = "EDIT ORDER"
        Me.ChkEditOrder.UseVisualStyleBackColor = True
        Me.ChkEditOrder.Visible = False
        '
        'DDCompanyName
        '
        Me.DDCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDCompanyName.FormattingEnabled = True
        Me.DDCompanyName.Location = New System.Drawing.Point(2, 39)
        Me.DDCompanyName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDCompanyName.Name = "DDCompanyName"
        Me.DDCompanyName.Size = New System.Drawing.Size(191, 21)
        Me.DDCompanyName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Company Name"
        '
        'DDPartyName
        '
        Me.DDPartyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDPartyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDPartyName.FormattingEnabled = True
        Me.DDPartyName.Location = New System.Drawing.Point(196, 39)
        Me.DDPartyName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDPartyName.Name = "DDPartyName"
        Me.DDPartyName.Size = New System.Drawing.Size(221, 21)
        Me.DDPartyName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(194, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Vendor Name"
        '
        'DDChallanNo
        '
        Me.DDChallanNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDChallanNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDChallanNo.FormattingEnabled = True
        Me.DDChallanNo.Location = New System.Drawing.Point(420, 39)
        Me.DDChallanNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDChallanNo.Name = "DDChallanNo"
        Me.DDChallanNo.Size = New System.Drawing.Size(156, 21)
        Me.DDChallanNo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(418, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Order No."
        '
        'ddlrecchalanno
        '
        Me.ddlrecchalanno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddlrecchalanno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddlrecchalanno.FormattingEnabled = True
        Me.ddlrecchalanno.Location = New System.Drawing.Point(580, 39)
        Me.ddlrecchalanno.Margin = New System.Windows.Forms.Padding(2)
        Me.ddlrecchalanno.Name = "ddlrecchalanno"
        Me.ddlrecchalanno.Size = New System.Drawing.Size(141, 21)
        Me.ddlrecchalanno.TabIndex = 3
        Me.ddlrecchalanno.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(578, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Challan No."
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1, 66)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Receive Date"
        '
        'TxtReceiveDate
        '
        Me.TxtReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtReceiveDate.Location = New System.Drawing.Point(3, 82)
        Me.TxtReceiveDate.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtReceiveDate.Name = "TxtReceiveDate"
        Me.TxtReceiveDate.Size = New System.Drawing.Size(102, 20)
        Me.TxtReceiveDate.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(106, 66)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Gate In No."
        '
        'TxtGateInNo
        '
        Me.TxtGateInNo.Location = New System.Drawing.Point(108, 83)
        Me.TxtGateInNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtGateInNo.Name = "TxtGateInNo"
        Me.TxtGateInNo.Size = New System.Drawing.Size(104, 20)
        Me.TxtGateInNo.TabIndex = 5
        '
        'TxtBillNo
        '
        Me.TxtBillNo.Location = New System.Drawing.Point(216, 84)
        Me.TxtBillNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtBillNo.Name = "TxtBillNo"
        Me.TxtBillNo.Size = New System.Drawing.Size(104, 20)
        Me.TxtBillNo.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(214, 67)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Challan No."
        '
        'txtbillno1
        '
        Me.txtbillno1.Location = New System.Drawing.Point(324, 84)
        Me.txtbillno1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtbillno1.Name = "txtbillno1"
        Me.txtbillno1.Size = New System.Drawing.Size(104, 20)
        Me.txtbillno1.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(322, 67)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Bill No."
        '
        'txtretdate
        '
        Me.txtretdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtretdate.Location = New System.Drawing.Point(432, 84)
        Me.txtretdate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtretdate.Name = "txtretdate"
        Me.txtretdate.Size = New System.Drawing.Size(102, 20)
        Me.txtretdate.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(430, 67)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Return Qty Date"
        '
        'txtfreight
        '
        Me.txtfreight.Location = New System.Drawing.Point(537, 84)
        Me.txtfreight.Margin = New System.Windows.Forms.Padding(2)
        Me.txtfreight.Name = "txtfreight"
        Me.txtfreight.Size = New System.Drawing.Size(104, 20)
        Me.txtfreight.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(535, 67)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Freight Charges"
        '
        'TextItemCode
        '
        Me.TextItemCode.Location = New System.Drawing.Point(645, 83)
        Me.TextItemCode.Margin = New System.Windows.Forms.Padding(2)
        Me.TextItemCode.Name = "TextItemCode"
        Me.TextItemCode.Size = New System.Drawing.Size(104, 20)
        Me.TextItemCode.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(643, 66)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Item Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DDCustomerOrderNo)
        Me.GroupBox1.Controls.Add(Me.LblCustomerOrderNo)
        Me.GroupBox1.Controls.Add(Me.chkoldlotno)
        Me.GroupBox1.Controls.Add(Me.txtcomplotno)
        Me.GroupBox1.Controls.Add(Me.lblcomplotno)
        Me.GroupBox1.Controls.Add(Me.DDBinno)
        Me.GroupBox1.Controls.Add(Me.lblbinno)
        Me.GroupBox1.Controls.Add(Me.DDUnit)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtbaleno)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtLotNo)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.DDLotNo)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.DDGodown)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.DDColorShade)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.DDQuality)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.DDItem)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.DDCategory)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 106)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(966, 106)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item Detail"
        '
        'DDCustomerOrderNo
        '
        Me.DDCustomerOrderNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDCustomerOrderNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDCustomerOrderNo.FormattingEnabled = True
        Me.DDCustomerOrderNo.Location = New System.Drawing.Point(645, 32)
        Me.DDCustomerOrderNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDCustomerOrderNo.Name = "DDCustomerOrderNo"
        Me.DDCustomerOrderNo.Size = New System.Drawing.Size(156, 21)
        Me.DDCustomerOrderNo.TabIndex = 61
        '
        'LblCustomerOrderNo
        '
        Me.LblCustomerOrderNo.AutoSize = True
        Me.LblCustomerOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCustomerOrderNo.Location = New System.Drawing.Point(648, 15)
        Me.LblCustomerOrderNo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblCustomerOrderNo.Name = "LblCustomerOrderNo"
        Me.LblCustomerOrderNo.Size = New System.Drawing.Size(58, 13)
        Me.LblCustomerOrderNo.TabIndex = 62
        Me.LblCustomerOrderNo.Text = "Order No"
        '
        'chkoldlotno
        '
        Me.chkoldlotno.AutoSize = True
        Me.chkoldlotno.Location = New System.Drawing.Point(804, 37)
        Me.chkoldlotno.Margin = New System.Windows.Forms.Padding(2)
        Me.chkoldlotno.Name = "chkoldlotno"
        Me.chkoldlotno.Size = New System.Drawing.Size(113, 17)
        Me.chkoldlotno.TabIndex = 60
        Me.chkoldlotno.Text = "For Old Lot No."
        Me.chkoldlotno.UseVisualStyleBackColor = True
        Me.chkoldlotno.Visible = False
        '
        'txtcomplotno
        '
        Me.txtcomplotno.Enabled = False
        Me.txtcomplotno.Location = New System.Drawing.Point(806, 74)
        Me.txtcomplotno.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcomplotno.Name = "txtcomplotno"
        Me.txtcomplotno.Size = New System.Drawing.Size(104, 19)
        Me.txtcomplotno.TabIndex = 59
        Me.txtcomplotno.Visible = False
        '
        'lblcomplotno
        '
        Me.lblcomplotno.AutoSize = True
        Me.lblcomplotno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcomplotno.Location = New System.Drawing.Point(802, 57)
        Me.lblcomplotno.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblcomplotno.Name = "lblcomplotno"
        Me.lblcomplotno.Size = New System.Drawing.Size(104, 13)
        Me.lblcomplotno.TabIndex = 58
        Me.lblcomplotno.Text = "Company Lot No."
        Me.lblcomplotno.Visible = False
        '
        'DDBinno
        '
        Me.DDBinno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDBinno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDBinno.FormattingEnabled = True
        Me.DDBinno.Location = New System.Drawing.Point(166, 72)
        Me.DDBinno.Margin = New System.Windows.Forms.Padding(2)
        Me.DDBinno.Name = "DDBinno"
        Me.DDBinno.Size = New System.Drawing.Size(156, 21)
        Me.DDBinno.TabIndex = 57
        Me.DDBinno.Visible = False
        '
        'lblbinno
        '
        Me.lblbinno.AutoSize = True
        Me.lblbinno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbinno.Location = New System.Drawing.Point(166, 57)
        Me.lblbinno.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblbinno.Name = "lblbinno"
        Me.lblbinno.Size = New System.Drawing.Size(49, 13)
        Me.lblbinno.TabIndex = 56
        Me.lblbinno.Text = "Bin No."
        Me.lblbinno.Visible = False
        '
        'DDUnit
        '
        Me.DDUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDUnit.FormattingEnabled = True
        Me.DDUnit.Location = New System.Drawing.Point(702, 72)
        Me.DDUnit.Margin = New System.Windows.Forms.Padding(2)
        Me.DDUnit.Name = "DDUnit"
        Me.DDUnit.Size = New System.Drawing.Size(100, 21)
        Me.DDUnit.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(700, 56)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 13)
        Me.Label20.TabIndex = 55
        Me.Label20.Text = "Unit"
        '
        'txtbaleno
        '
        Me.txtbaleno.Location = New System.Drawing.Point(594, 74)
        Me.txtbaleno.Margin = New System.Windows.Forms.Padding(2)
        Me.txtbaleno.Name = "txtbaleno"
        Me.txtbaleno.Size = New System.Drawing.Size(104, 19)
        Me.txtbaleno.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(592, 57)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 13)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "Bale No."
        '
        'txtLotNo
        '
        Me.txtLotNo.Location = New System.Drawing.Point(486, 74)
        Me.txtLotNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(104, 19)
        Me.txtLotNo.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(484, 57)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 13)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "Rec. Lot No."
        '
        'DDLotNo
        '
        Me.DDLotNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDLotNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDLotNo.FormattingEnabled = True
        Me.DDLotNo.Location = New System.Drawing.Point(326, 72)
        Me.DDLotNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDLotNo.Name = "DDLotNo"
        Me.DDLotNo.Size = New System.Drawing.Size(156, 21)
        Me.DDLotNo.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(324, 56)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 13)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "Iss Lot No."
        '
        'DDGodown
        '
        Me.DDGodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDGodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDGodown.FormattingEnabled = True
        Me.DDGodown.Location = New System.Drawing.Point(6, 72)
        Me.DDGodown.Margin = New System.Windows.Forms.Padding(2)
        Me.DDGodown.Name = "DDGodown"
        Me.DDGodown.Size = New System.Drawing.Size(156, 21)
        Me.DDGodown.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(4, 56)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 13)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Godown Name"
        '
        'DDColorShade
        '
        Me.DDColorShade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDColorShade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDColorShade.FormattingEnabled = True
        Me.DDColorShade.Location = New System.Drawing.Point(485, 32)
        Me.DDColorShade.Margin = New System.Windows.Forms.Padding(2)
        Me.DDColorShade.Name = "DDColorShade"
        Me.DDColorShade.Size = New System.Drawing.Size(156, 21)
        Me.DDColorShade.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(483, 15)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Color Name"
        '
        'DDQuality
        '
        Me.DDQuality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDQuality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDQuality.FormattingEnabled = True
        Me.DDQuality.Location = New System.Drawing.Point(326, 32)
        Me.DDQuality.Margin = New System.Windows.Forms.Padding(2)
        Me.DDQuality.Name = "DDQuality"
        Me.DDQuality.Size = New System.Drawing.Size(156, 21)
        Me.DDQuality.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(323, 15)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 13)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Quality Name"
        '
        'DDItem
        '
        Me.DDItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDItem.FormattingEnabled = True
        Me.DDItem.Location = New System.Drawing.Point(166, 32)
        Me.DDItem.Margin = New System.Windows.Forms.Padding(2)
        Me.DDItem.Name = "DDItem"
        Me.DDItem.Size = New System.Drawing.Size(156, 21)
        Me.DDItem.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(164, 15)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Item Name"
        '
        'DDCategory
        '
        Me.DDCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDCategory.FormattingEnabled = True
        Me.DDCategory.Location = New System.Drawing.Point(6, 32)
        Me.DDCategory.Margin = New System.Windows.Forms.Padding(2)
        Me.DDCategory.Name = "DDCategory"
        Me.DDCategory.Size = New System.Drawing.Size(156, 21)
        Me.DDCategory.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 15)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Category "
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtMoisture)
        Me.Panel1.Controls.Add(Me.LblMoisture)
        Me.Panel1.Controls.Add(Me.txtIgst)
        Me.Panel1.Controls.Add(Me.Label34)
        Me.Panel1.Controls.Add(Me.txtsgst)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.txtbellwt)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.Txtnetamount)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.TxtPenalty)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.TxtAmount)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.txtrate)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Txtreturnqty)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.TxtQty)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.TxtPQty)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.txtorderqty)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Location = New System.Drawing.Point(3, 217)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(967, 50)
        Me.Panel1.TabIndex = 40
        '
        'TxtMoisture
        '
        Me.TxtMoisture.Location = New System.Drawing.Point(491, 20)
        Me.TxtMoisture.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMoisture.Name = "TxtMoisture"
        Me.TxtMoisture.Size = New System.Drawing.Size(66, 20)
        Me.TxtMoisture.TabIndex = 87
        Me.TxtMoisture.Visible = False
        '
        'LblMoisture
        '
        Me.LblMoisture.AutoSize = True
        Me.LblMoisture.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMoisture.Location = New System.Drawing.Point(494, 3)
        Me.LblMoisture.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblMoisture.Name = "LblMoisture"
        Me.LblMoisture.Size = New System.Drawing.Size(55, 13)
        Me.LblMoisture.TabIndex = 88
        Me.LblMoisture.Text = "Moisture"
        Me.LblMoisture.Visible = False
        '
        'txtIgst
        '
        Me.txtIgst.Location = New System.Drawing.Point(728, 20)
        Me.txtIgst.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIgst.Name = "txtIgst"
        Me.txtIgst.Size = New System.Drawing.Size(62, 20)
        Me.txtIgst.TabIndex = 5
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Enabled = False
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(728, 4)
        Me.Label34.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(53, 13)
        Me.Label34.TabIndex = 72
        Me.Label34.Text = "IGST(%)"
        '
        'txtsgst
        '
        Me.txtsgst.Location = New System.Drawing.Point(660, 20)
        Me.txtsgst.Margin = New System.Windows.Forms.Padding(2)
        Me.txtsgst.Name = "txtsgst"
        Me.txtsgst.Size = New System.Drawing.Size(66, 20)
        Me.txtsgst.TabIndex = 4
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Enabled = False
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(659, 4)
        Me.Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(57, 13)
        Me.Label33.TabIndex = 70
        Me.Label33.Text = "SGST(%)"
        '
        'txtbellwt
        '
        Me.txtbellwt.Location = New System.Drawing.Point(363, 20)
        Me.txtbellwt.Margin = New System.Windows.Forms.Padding(2)
        Me.txtbellwt.Name = "txtbellwt"
        Me.txtbellwt.Size = New System.Drawing.Size(58, 20)
        Me.txtbellwt.TabIndex = 1
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(360, 4)
        Me.Label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(52, 13)
        Me.Label32.TabIndex = 69
        Me.Label32.Text = "Bell Wt."
        '
        'Txtnetamount
        '
        Me.Txtnetamount.Location = New System.Drawing.Point(870, 20)
        Me.Txtnetamount.Margin = New System.Windows.Forms.Padding(2)
        Me.Txtnetamount.Name = "Txtnetamount"
        Me.Txtnetamount.Size = New System.Drawing.Size(91, 20)
        Me.Txtnetamount.TabIndex = 7
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Enabled = False
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(867, 3)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(81, 13)
        Me.Label28.TabIndex = 68
        Me.Label28.Text = "Nett. Amount"
        '
        'TxtPenalty
        '
        Me.TxtPenalty.Location = New System.Drawing.Point(793, 20)
        Me.TxtPenalty.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtPenalty.Name = "TxtPenalty"
        Me.TxtPenalty.Size = New System.Drawing.Size(75, 20)
        Me.TxtPenalty.TabIndex = 6
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Enabled = False
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(791, 3)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(52, 13)
        Me.Label27.TabIndex = 66
        Me.Label27.Text = "Penality"
        '
        'TxtAmount
        '
        Me.TxtAmount.Location = New System.Drawing.Point(561, 20)
        Me.TxtAmount.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Size = New System.Drawing.Size(96, 20)
        Me.TxtAmount.TabIndex = 3
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Enabled = False
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(559, 3)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(49, 13)
        Me.Label26.TabIndex = 64
        Me.Label26.Text = "Amount"
        '
        'txtrate
        '
        Me.txtrate.Location = New System.Drawing.Point(423, 20)
        Me.txtrate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(64, 20)
        Me.txtrate.TabIndex = 2
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(420, 3)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(34, 13)
        Me.Label25.TabIndex = 62
        Me.Label25.Text = "Rate"
        '
        'Txtreturnqty
        '
        Me.Txtreturnqty.Enabled = False
        Me.Txtreturnqty.Location = New System.Drawing.Point(289, 20)
        Me.Txtreturnqty.Margin = New System.Windows.Forms.Padding(2)
        Me.Txtreturnqty.Name = "Txtreturnqty"
        Me.Txtreturnqty.Size = New System.Drawing.Size(70, 20)
        Me.Txtreturnqty.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(286, 3)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 13)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "Return Qty."
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(199, 20)
        Me.TxtQty.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(88, 20)
        Me.TxtQty.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(196, 3)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(81, 13)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Receive Qty."
        '
        'TxtPQty
        '
        Me.TxtPQty.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TxtPQty.Enabled = False
        Me.TxtPQty.ForeColor = System.Drawing.SystemColors.MenuText
        Me.TxtPQty.Location = New System.Drawing.Point(100, 20)
        Me.TxtPQty.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtPQty.Name = "TxtPQty"
        Me.TxtPQty.Size = New System.Drawing.Size(95, 20)
        Me.TxtPQty.TabIndex = 8
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(98, 3)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 13)
        Me.Label22.TabIndex = 58
        Me.Label22.Text = "Pending Qty."
        '
        'txtorderqty
        '
        Me.txtorderqty.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtorderqty.Enabled = False
        Me.txtorderqty.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtorderqty.Location = New System.Drawing.Point(2, 20)
        Me.txtorderqty.Margin = New System.Windows.Forms.Padding(2)
        Me.txtorderqty.Name = "txtorderqty"
        Me.txtorderqty.Size = New System.Drawing.Size(95, 20)
        Me.txtorderqty.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(0, 3)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 56
        Me.Label21.Text = "Order Qty."
        '
        'txtremarks
        '
        Me.txtremarks.Location = New System.Drawing.Point(3, 290)
        Me.txtremarks.Margin = New System.Windows.Forms.Padding(2)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(398, 67)
        Me.txtremarks.TabIndex = 71
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(1, 273)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(78, 13)
        Me.Label29.TabIndex = 70
        Me.Label29.Text = "Item Remark"
        '
        'txtmastremark
        '
        Me.txtmastremark.Location = New System.Drawing.Point(409, 290)
        Me.txtmastremark.Margin = New System.Windows.Forms.Padding(2)
        Me.txtmastremark.Multiline = True
        Me.txtmastremark.Name = "txtmastremark"
        Me.txtmastremark.Size = New System.Drawing.Size(500, 67)
        Me.txtmastremark.TabIndex = 73
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(406, 273)
        Me.Label30.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 13)
        Me.Label30.TabIndex = 72
        Me.Label30.Text = "MRemark"
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(850, 362)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(56, 19)
        Me.btnclose.TabIndex = 14
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnpreview
        '
        Me.btnpreview.Location = New System.Drawing.Point(789, 362)
        Me.btnpreview.Margin = New System.Windows.Forms.Padding(2)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(56, 19)
        Me.btnpreview.TabIndex = 13
        Me.btnpreview.Text = "Preview"
        Me.btnpreview.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(728, 362)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(56, 19)
        Me.btnsave.TabIndex = 11
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(665, 362)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(56, 19)
        Me.btnNew.TabIndex = 12
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'DGporder
        '
        Me.DGporder.AllowUserToAddRows = False
        Me.DGporder.AllowUserToDeleteRows = False
        Me.DGporder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGporder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGporder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Description, Me.Qty, Me.Recqty, Me.Balance, Me.lblfinishedid, Me.lblcategoryid, Me.lblitem_id, Me.lblQualityid, Me.lblshadecolorid, Me.lblqty, Me.lblrecqty, Me.lblorderid, Me.lbllotno})
        Me.DGporder.Location = New System.Drawing.Point(460, 397)
        Me.DGporder.Margin = New System.Windows.Forms.Padding(2)
        Me.DGporder.Name = "DGporder"
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGporder.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGporder.RowTemplate.Height = 30
        Me.DGporder.Size = New System.Drawing.Size(508, 239)
        Me.DGporder.TabIndex = 78
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 300
        '
        'Qty
        '
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 50
        '
        'Recqty
        '
        Me.Recqty.HeaderText = "Rec Qty"
        Me.Recqty.Name = "Recqty"
        Me.Recqty.ReadOnly = True
        Me.Recqty.Width = 50
        '
        'Balance
        '
        Me.Balance.HeaderText = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.ReadOnly = True
        Me.Balance.Width = 60
        '
        'lblfinishedid
        '
        Me.lblfinishedid.HeaderText = "lblfinishedid"
        Me.lblfinishedid.Name = "lblfinishedid"
        Me.lblfinishedid.Visible = False
        '
        'lblcategoryid
        '
        Me.lblcategoryid.HeaderText = "lblcategoryid"
        Me.lblcategoryid.Name = "lblcategoryid"
        Me.lblcategoryid.Visible = False
        '
        'lblitem_id
        '
        Me.lblitem_id.HeaderText = "lblitem_id"
        Me.lblitem_id.Name = "lblitem_id"
        Me.lblitem_id.Visible = False
        '
        'lblQualityid
        '
        Me.lblQualityid.HeaderText = "lblQualityid"
        Me.lblQualityid.Name = "lblQualityid"
        Me.lblQualityid.Visible = False
        '
        'lblshadecolorid
        '
        Me.lblshadecolorid.HeaderText = "lblshadecolorid"
        Me.lblshadecolorid.Name = "lblshadecolorid"
        Me.lblshadecolorid.Visible = False
        '
        'lblqty
        '
        Me.lblqty.HeaderText = "lblqty"
        Me.lblqty.Name = "lblqty"
        Me.lblqty.Visible = False
        '
        'lblrecqty
        '
        Me.lblrecqty.HeaderText = "lblrecqty"
        Me.lblrecqty.Name = "lblrecqty"
        Me.lblrecqty.Visible = False
        '
        'lblorderid
        '
        Me.lblorderid.HeaderText = "lblorderid"
        Me.lblorderid.Name = "lblorderid"
        Me.lblorderid.Visible = False
        '
        'lbllotno
        '
        Me.lbllotno.HeaderText = "lbllotno"
        Me.lbllotno.Name = "lbllotno"
        Me.lbllotno.Visible = False
        '
        'DGPurchaseReceiveDetail
        '
        Me.DGPurchaseReceiveDetail.AllowUserToAddRows = False
        Me.DGPurchaseReceiveDetail.AllowUserToDeleteRows = False
        Me.DGPurchaseReceiveDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGPurchaseReceiveDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGPurchaseReceiveDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gridPurchaseReceiveDetailId, Me.ItemDescription, Me.GodownName, Me.gridQty, Me.UnitName, Me.LOTNO})
        Me.DGPurchaseReceiveDetail.Location = New System.Drawing.Point(2, 397)
        Me.DGPurchaseReceiveDetail.Margin = New System.Windows.Forms.Padding(2)
        Me.DGPurchaseReceiveDetail.Name = "DGPurchaseReceiveDetail"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPurchaseReceiveDetail.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGPurchaseReceiveDetail.RowTemplate.Height = 30
        Me.DGPurchaseReceiveDetail.Size = New System.Drawing.Size(454, 239)
        Me.DGPurchaseReceiveDetail.TabIndex = 79
        '
        'gridPurchaseReceiveDetailId
        '
        Me.gridPurchaseReceiveDetailId.HeaderText = "PurchaseReceiveDetailId"
        Me.gridPurchaseReceiveDetailId.Name = "gridPurchaseReceiveDetailId"
        Me.gridPurchaseReceiveDetailId.Visible = False
        '
        'ItemDescription
        '
        Me.ItemDescription.HeaderText = "Item Description"
        Me.ItemDescription.Name = "ItemDescription"
        Me.ItemDescription.ReadOnly = True
        Me.ItemDescription.Width = 120
        '
        'GodownName
        '
        Me.GodownName.HeaderText = "GodownName"
        Me.GodownName.Name = "GodownName"
        Me.GodownName.ReadOnly = True
        '
        'gridQty
        '
        Me.gridQty.HeaderText = "Qty"
        Me.gridQty.Name = "gridQty"
        Me.gridQty.ReadOnly = True
        Me.gridQty.Width = 70
        '
        'UnitName
        '
        Me.UnitName.HeaderText = "UnitName"
        Me.UnitName.Name = "UnitName"
        Me.UnitName.ReadOnly = True
        Me.UnitName.Width = 70
        '
        'LOTNO
        '
        Me.LOTNO.HeaderText = "LOTNO"
        Me.LOTNO.Name = "LOTNO"
        Me.LOTNO.ReadOnly = True
        Me.LOTNO.Width = 90
        '
        'lblsrno
        '
        Me.lblsrno.AutoSize = True
        Me.lblsrno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.ForeColor = System.Drawing.Color.Red
        Me.lblsrno.Location = New System.Drawing.Point(106, 3)
        Me.lblsrno.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblsrno.Name = "lblsrno"
        Me.lblsrno.Size = New System.Drawing.Size(115, 13)
        Me.lblsrno.TabIndex = 80
        Me.lblsrno.Text = "SR No. Generated."
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(784, 642)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 82
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(712, 645)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 13)
        Me.Label31.TabIndex = 81
        Me.Label31.Text = "Port Name"
        '
        'ChkLotwisesummary
        '
        Me.ChkLotwisesummary.AutoSize = True
        Me.ChkLotwisesummary.Location = New System.Drawing.Point(550, 363)
        Me.ChkLotwisesummary.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkLotwisesummary.Name = "ChkLotwisesummary"
        Me.ChkLotwisesummary.Size = New System.Drawing.Size(114, 17)
        Me.ChkLotwisesummary.TabIndex = 83
        Me.ChkLotwisesummary.Text = "Lot Wise Summary"
        Me.ChkLotwisesummary.UseVisualStyleBackColor = True
        '
        'chkprintbarcode
        '
        Me.chkprintbarcode.AutoSize = True
        Me.chkprintbarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkprintbarcode.Location = New System.Drawing.Point(457, 644)
        Me.chkprintbarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.chkprintbarcode.Name = "chkprintbarcode"
        Me.chkprintbarcode.Size = New System.Drawing.Size(108, 17)
        Me.chkprintbarcode.TabIndex = 84
        Me.chkprintbarcode.Text = "Print Bar Code"
        Me.chkprintbarcode.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(1, 648)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(100, 13)
        Me.Label35.TabIndex = 86
        Me.Label35.Text = "Bar Code Printer"
        '
        'cmbprintername
        '
        Me.cmbprintername.FormattingEnabled = True
        Me.cmbprintername.Location = New System.Drawing.Point(104, 645)
        Me.cmbprintername.Name = "cmbprintername"
        Me.cmbprintername.Size = New System.Drawing.Size(302, 21)
        Me.cmbprintername.TabIndex = 85
        '
        'BtnComplete
        '
        Me.BtnComplete.Location = New System.Drawing.Point(910, 362)
        Me.BtnComplete.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnComplete.Name = "BtnComplete"
        Me.BtnComplete.Size = New System.Drawing.Size(59, 19)
        Me.BtnComplete.TabIndex = 87
        Me.BtnComplete.Text = "Complete"
        Me.BtnComplete.UseVisualStyleBackColor = True
        '
        'frmpurchasereceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(974, 669)
        Me.Controls.Add(Me.BtnComplete)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.cmbprintername)
        Me.Controls.Add(Me.chkprintbarcode)
        Me.Controls.Add(Me.ChkLotwisesummary)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.lblsrno)
        Me.Controls.Add(Me.DGPurchaseReceiveDetail)
        Me.Controls.Add(Me.DGporder)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btnpreview)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.txtmastremark)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtremarks)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextItemCode)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtfreight)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtretdate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtbillno1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtBillNo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtGateInNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtReceiveDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ddlrecchalanno)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DDChallanNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DDPartyName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DDCompanyName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ChkEditOrder)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmpurchasereceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Receive"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGporder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGPurchaseReceiveDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChkEditOrder As System.Windows.Forms.CheckBox
    Friend WithEvents DDCompanyName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DDPartyName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DDChallanNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ddlrecchalanno As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtReceiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtGateInNo As System.Windows.Forms.TextBox
    Friend WithEvents TxtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtbillno1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtretdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtfreight As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DDUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtbaleno As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents DDLotNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DDGodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DDColorShade As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DDQuality As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DDItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DDCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Txtnetamount As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TxtPenalty As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Txtreturnqty As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtPQty As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtorderqty As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtmastremark As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents DGporder As System.Windows.Forms.DataGridView
    Friend WithEvents DGPurchaseReceiveDetail As System.Windows.Forms.DataGridView
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents gridPurchaseReceiveDetailId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GodownName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gridQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOTNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtbellwt As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtIgst As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtsgst As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents ChkLotwisesummary As System.Windows.Forms.CheckBox
    Friend WithEvents chkprintbarcode As System.Windows.Forms.CheckBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cmbprintername As System.Windows.Forms.ComboBox
    Friend WithEvents DDBinno As System.Windows.Forms.ComboBox
    Friend WithEvents lblbinno As System.Windows.Forms.Label
    Friend WithEvents txtcomplotno As System.Windows.Forms.TextBox
    Friend WithEvents lblcomplotno As System.Windows.Forms.Label
    Friend WithEvents chkoldlotno As System.Windows.Forms.CheckBox
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Recqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblfinishedid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblcategoryid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblitem_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblQualityid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblshadecolorid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblrecqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblorderid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbllotno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtMoisture As System.Windows.Forms.TextBox
    Friend WithEvents LblMoisture As System.Windows.Forms.Label
    Friend WithEvents DDCustomerOrderNo As System.Windows.Forms.ComboBox
    Friend WithEvents LblCustomerOrderNo As System.Windows.Forms.Label
    Friend WithEvents BtnComplete As System.Windows.Forms.Button
End Class
