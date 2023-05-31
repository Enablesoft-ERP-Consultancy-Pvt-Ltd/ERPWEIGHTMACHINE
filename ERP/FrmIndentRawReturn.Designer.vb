<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIndentRawReturn
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GpMasterdetails = New System.Windows.Forms.GroupBox()
        Me.ChkForEdit = New System.Windows.Forms.CheckBox()
        Me.DDGatePass = New System.Windows.Forms.ComboBox()
        Me.LblDDGatePassNo = New System.Windows.Forms.Label()
        Me.ddProcessName = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtretdate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtretNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DDChallanNo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DDPartyName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DDcompany = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DGReturnedDetail = New System.Windows.Forms.DataGridView()
        Me.ReturnNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemdescriptionR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GodownR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotnoR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagnoR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RetqtyR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Masterid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detailid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.btnpreview = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GodownName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReturnQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RetQtyEnter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IndentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRMID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRTID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Finishedid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Godownid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unitid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GpMasterdetails.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGReturnedDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GpMasterdetails
        '
        Me.GpMasterdetails.Controls.Add(Me.ChkForEdit)
        Me.GpMasterdetails.Controls.Add(Me.DDGatePass)
        Me.GpMasterdetails.Controls.Add(Me.LblDDGatePassNo)
        Me.GpMasterdetails.Controls.Add(Me.ddProcessName)
        Me.GpMasterdetails.Controls.Add(Me.Label7)
        Me.GpMasterdetails.Controls.Add(Me.txtretdate)
        Me.GpMasterdetails.Controls.Add(Me.Label5)
        Me.GpMasterdetails.Controls.Add(Me.txtretNo)
        Me.GpMasterdetails.Controls.Add(Me.Label4)
        Me.GpMasterdetails.Controls.Add(Me.DDChallanNo)
        Me.GpMasterdetails.Controls.Add(Me.Label3)
        Me.GpMasterdetails.Controls.Add(Me.DDPartyName)
        Me.GpMasterdetails.Controls.Add(Me.Label2)
        Me.GpMasterdetails.Controls.Add(Me.DDcompany)
        Me.GpMasterdetails.Controls.Add(Me.Label1)
        Me.GpMasterdetails.ForeColor = System.Drawing.Color.Red
        Me.GpMasterdetails.Location = New System.Drawing.Point(4, 0)
        Me.GpMasterdetails.Margin = New System.Windows.Forms.Padding(2)
        Me.GpMasterdetails.Name = "GpMasterdetails"
        Me.GpMasterdetails.Padding = New System.Windows.Forms.Padding(2)
        Me.GpMasterdetails.Size = New System.Drawing.Size(1000, 57)
        Me.GpMasterdetails.TabIndex = 1
        Me.GpMasterdetails.TabStop = False
        Me.GpMasterdetails.Text = "Master Details"
        '
        'ChkForEdit
        '
        Me.ChkForEdit.AutoSize = True
        Me.ChkForEdit.Location = New System.Drawing.Point(418, 11)
        Me.ChkForEdit.Name = "ChkForEdit"
        Me.ChkForEdit.Size = New System.Drawing.Size(44, 17)
        Me.ChkForEdit.TabIndex = 90
        Me.ChkForEdit.Text = "Edit"
        Me.ChkForEdit.UseVisualStyleBackColor = True
        '
        'DDGatePass
        '
        Me.DDGatePass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDGatePass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDGatePass.FormattingEnabled = True
        Me.DDGatePass.Location = New System.Drawing.Point(624, 31)
        Me.DDGatePass.Margin = New System.Windows.Forms.Padding(2)
        Me.DDGatePass.Name = "DDGatePass"
        Me.DDGatePass.Size = New System.Drawing.Size(150, 21)
        Me.DDGatePass.TabIndex = 88
        Me.DDGatePass.Visible = False
        '
        'LblDDGatePassNo
        '
        Me.LblDDGatePassNo.AutoSize = True
        Me.LblDDGatePassNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDDGatePassNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblDDGatePassNo.Location = New System.Drawing.Point(627, 15)
        Me.LblDDGatePassNo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDDGatePassNo.Name = "LblDDGatePassNo"
        Me.LblDDGatePassNo.Size = New System.Drawing.Size(81, 13)
        Me.LblDDGatePassNo.TabIndex = 89
        Me.LblDDGatePassNo.Text = "GatePass No"
        Me.LblDDGatePassNo.Visible = False
        '
        'ddProcessName
        '
        Me.ddProcessName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddProcessName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddProcessName.FormattingEnabled = True
        Me.ddProcessName.Location = New System.Drawing.Point(162, 31)
        Me.ddProcessName.Margin = New System.Windows.Forms.Padding(2)
        Me.ddProcessName.Name = "ddProcessName"
        Me.ddProcessName.Size = New System.Drawing.Size(150, 21)
        Me.ddProcessName.TabIndex = 86
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(165, 15)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Process Name"
        '
        'txtretdate
        '
        Me.txtretdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtretdate.Location = New System.Drawing.Point(887, 31)
        Me.txtretdate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtretdate.Name = "txtretdate"
        Me.txtretdate.Size = New System.Drawing.Size(105, 20)
        Me.txtretdate.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(884, 15)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Return Date"
        '
        'txtretNo
        '
        Me.txtretNo.Enabled = False
        Me.txtretNo.Location = New System.Drawing.Point(778, 31)
        Me.txtretNo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtretNo.Name = "txtretNo"
        Me.txtretNo.Size = New System.Drawing.Size(104, 20)
        Me.txtretNo.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(781, 15)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "GatePass No"
        '
        'DDChallanNo
        '
        Me.DDChallanNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDChallanNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDChallanNo.FormattingEnabled = True
        Me.DDChallanNo.Location = New System.Drawing.Point(470, 31)
        Me.DDChallanNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDChallanNo.Name = "DDChallanNo"
        Me.DDChallanNo.Size = New System.Drawing.Size(150, 21)
        Me.DDChallanNo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(473, 15)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Challan No"
        '
        'DDPartyName
        '
        Me.DDPartyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDPartyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDPartyName.FormattingEnabled = True
        Me.DDPartyName.Location = New System.Drawing.Point(316, 31)
        Me.DDPartyName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDPartyName.Name = "DDPartyName"
        Me.DDPartyName.Size = New System.Drawing.Size(150, 21)
        Me.DDPartyName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(319, 15)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Party Name"
        '
        'DDcompany
        '
        Me.DDcompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDcompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDcompany.FormattingEnabled = True
        Me.DDcompany.Location = New System.Drawing.Point(8, 31)
        Me.DDcompany.Margin = New System.Windows.Forms.Padding(2)
        Me.DDcompany.Name = "DDcompany"
        Me.DDcompany.Size = New System.Drawing.Size(150, 21)
        Me.DDcompany.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Company Name"
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item_Name, Me.ItemDescription, Me.GodownName, Me.LotNo, Me.RecQuantity, Me.BalQty, Me.ReturnQty, Me.RetQtyEnter, Me.IndentID, Me.PRMID, Me.PRTID, Me.Finishedid, Me.Godownid, Me.EmpId, Me.Unitid, Me.TagNo})
        Me.DG.Location = New System.Drawing.Point(9, 64)
        Me.DG.Margin = New System.Windows.Forms.Padding(2)
        Me.DG.Name = "DG"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DG.RowTemplate.Height = 24
        Me.DG.Size = New System.Drawing.Size(993, 273)
        Me.DG.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DGReturnedDetail)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 338)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(995, 215)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Return Details"
        '
        'DGReturnedDetail
        '
        Me.DGReturnedDetail.AllowUserToAddRows = False
        Me.DGReturnedDetail.AllowUserToDeleteRows = False
        Me.DGReturnedDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGReturnedDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGReturnedDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGReturnedDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReturnNo, Me.ItemdescriptionR, Me.UnitR, Me.GodownR, Me.LotnoR, Me.TagnoR, Me.RetqtyR, Me.Masterid, Me.Detailid})
        Me.DGReturnedDetail.Location = New System.Drawing.Point(4, 17)
        Me.DGReturnedDetail.Margin = New System.Windows.Forms.Padding(2)
        Me.DGReturnedDetail.Name = "DGReturnedDetail"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGReturnedDetail.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGReturnedDetail.RowTemplate.Height = 24
        Me.DGReturnedDetail.Size = New System.Drawing.Size(989, 191)
        Me.DGReturnedDetail.TabIndex = 0
        '
        'ReturnNo
        '
        Me.ReturnNo.HeaderText = "Return  No."
        Me.ReturnNo.Name = "ReturnNo"
        Me.ReturnNo.ReadOnly = True
        Me.ReturnNo.Width = 65
        '
        'ItemdescriptionR
        '
        Me.ItemdescriptionR.HeaderText = "Item Description"
        Me.ItemdescriptionR.Name = "ItemdescriptionR"
        Me.ItemdescriptionR.ReadOnly = True
        Me.ItemdescriptionR.Width = 99
        '
        'UnitR
        '
        Me.UnitR.HeaderText = "Unit"
        Me.UnitR.Name = "UnitR"
        Me.UnitR.ReadOnly = True
        Me.UnitR.Width = 51
        '
        'GodownR
        '
        Me.GodownR.HeaderText = "Godown"
        Me.GodownR.Name = "GodownR"
        Me.GodownR.ReadOnly = True
        Me.GodownR.Width = 72
        '
        'LotnoR
        '
        Me.LotnoR.HeaderText = "Lot No."
        Me.LotnoR.Name = "LotnoR"
        Me.LotnoR.ReadOnly = True
        Me.LotnoR.Width = 62
        '
        'TagnoR
        '
        Me.TagnoR.HeaderText = "Tag No."
        Me.TagnoR.Name = "TagnoR"
        Me.TagnoR.ReadOnly = True
        Me.TagnoR.Width = 51
        '
        'RetqtyR
        '
        Me.RetqtyR.HeaderText = "Ret. Qty"
        Me.RetqtyR.Name = "RetqtyR"
        Me.RetqtyR.ReadOnly = True
        Me.RetqtyR.Width = 66
        '
        'Masterid
        '
        Me.Masterid.HeaderText = "Masterid"
        Me.Masterid.Name = "Masterid"
        Me.Masterid.Visible = False
        Me.Masterid.Width = 87
        '
        'Detailid
        '
        Me.Detailid.HeaderText = "Detailid"
        Me.Detailid.Name = "Detailid"
        Me.Detailid.Visible = False
        Me.Detailid.Width = 80
        '
        'btnnew
        '
        Me.btnnew.Location = New System.Drawing.Point(785, 560)
        Me.btnnew.Margin = New System.Windows.Forms.Padding(2)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(56, 19)
        Me.btnnew.TabIndex = 21
        Me.btnnew.Text = "New"
        Me.btnnew.UseVisualStyleBackColor = True
        '
        'btnpreview
        '
        Me.btnpreview.Location = New System.Drawing.Point(846, 560)
        Me.btnpreview.Margin = New System.Windows.Forms.Padding(2)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(56, 19)
        Me.btnpreview.TabIndex = 22
        Me.btnpreview.Text = "Preview"
        Me.btnpreview.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(907, 560)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(56, 19)
        Me.btnclose.TabIndex = 23
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(645, 560)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 82
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(579, 563)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 13)
        Me.Label29.TabIndex = 81
        Me.Label29.Text = "Port Name"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(7, 560)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(349, 17)
        Me.Label28.TabIndex = 83
        Me.Label28.Text = "* Select row and press del key to delete record"
        '
        'Item_Name
        '
        Me.Item_Name.FillWeight = 150.0!
        Me.Item_Name.HeaderText = "Item"
        Me.Item_Name.Name = "Item_Name"
        Me.Item_Name.ReadOnly = True
        Me.Item_Name.Width = 52
        '
        'ItemDescription
        '
        Me.ItemDescription.HeaderText = "Description"
        Me.ItemDescription.Name = "ItemDescription"
        Me.ItemDescription.ReadOnly = True
        Me.ItemDescription.Width = 85
        '
        'GodownName
        '
        Me.GodownName.HeaderText = "Godown"
        Me.GodownName.Name = "GodownName"
        Me.GodownName.ReadOnly = True
        Me.GodownName.Width = 72
        '
        'LotNo
        '
        Me.LotNo.HeaderText = "Lot No"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        Me.LotNo.Width = 64
        '
        'RecQuantity
        '
        Me.RecQuantity.HeaderText = "RecQty"
        Me.RecQuantity.Name = "RecQuantity"
        Me.RecQuantity.ReadOnly = True
        Me.RecQuantity.Width = 68
        '
        'BalQty
        '
        Me.BalQty.HeaderText = "Bal Qty"
        Me.BalQty.Name = "BalQty"
        Me.BalQty.ReadOnly = True
        Me.BalQty.Width = 66
        '
        'ReturnQty
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ReturnQty.DefaultCellStyle = DataGridViewCellStyle1
        Me.ReturnQty.HeaderText = "Ret. Qty Wt"
        Me.ReturnQty.Name = "ReturnQty"
        Me.ReturnQty.Width = 88
        '
        'RetQtyEnter
        '
        Me.RetQtyEnter.HeaderText = "Ret Qty"
        Me.RetQtyEnter.Name = "RetQtyEnter"
        Me.RetQtyEnter.Width = 68
        '
        'IndentID
        '
        Me.IndentID.HeaderText = "IndentID"
        Me.IndentID.Name = "IndentID"
        Me.IndentID.Visible = False
        Me.IndentID.Width = 73
        '
        'PRMID
        '
        Me.PRMID.HeaderText = "PRMID"
        Me.PRMID.Name = "PRMID"
        Me.PRMID.Visible = False
        Me.PRMID.Width = 67
        '
        'PRTID
        '
        Me.PRTID.HeaderText = "PRTID"
        Me.PRTID.Name = "PRTID"
        Me.PRTID.Visible = False
        Me.PRTID.Width = 65
        '
        'Finishedid
        '
        Me.Finishedid.HeaderText = "Finishedid"
        Me.Finishedid.Name = "Finishedid"
        Me.Finishedid.Visible = False
        Me.Finishedid.Width = 79
        '
        'Godownid
        '
        Me.Godownid.HeaderText = "Godownid"
        Me.Godownid.Name = "Godownid"
        Me.Godownid.Visible = False
        Me.Godownid.Width = 80
        '
        'EmpId
        '
        Me.EmpId.HeaderText = "EmpId"
        Me.EmpId.Name = "EmpId"
        Me.EmpId.Visible = False
        Me.EmpId.Width = 62
        '
        'Unitid
        '
        Me.Unitid.HeaderText = "Unitid"
        Me.Unitid.Name = "Unitid"
        Me.Unitid.Visible = False
        Me.Unitid.Width = 59
        '
        'TagNo
        '
        Me.TagNo.HeaderText = "TagNo"
        Me.TagNo.Name = "TagNo"
        Me.TagNo.Visible = False
        Me.TagNo.Width = 65
        '
        'FrmIndentRawReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1008, 586)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btnpreview)
        Me.Controls.Add(Me.btnnew)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.GpMasterdetails)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmIndentRawReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indent Raw Return"
        Me.GpMasterdetails.ResumeLayout(False)
        Me.GpMasterdetails.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DGReturnedDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GpMasterdetails As System.Windows.Forms.GroupBox
    Friend WithEvents DDPartyName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DDcompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtretdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtretNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DDChallanNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DGReturnedDetail As System.Windows.Forms.DataGridView
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ReturnNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemdescriptionR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GodownR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotnoR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagnoR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RetqtyR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Masterid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detailid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ddProcessName As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DDGatePass As System.Windows.Forms.ComboBox
    Friend WithEvents LblDDGatePassNo As System.Windows.Forms.Label
    Friend WithEvents ChkForEdit As System.Windows.Forms.CheckBox
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GodownName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RetQtyEnter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IndentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRMID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRTID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Finishedid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Godownid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unitid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagNo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
