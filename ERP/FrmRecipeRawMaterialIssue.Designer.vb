<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecipeRawMaterialIssue
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DDRecipeName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DDSlipNo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DDCompanyName = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DDBinNo = New System.Windows.Forms.ComboBox()
        Me.lblbinno = New System.Windows.Forms.Label()
        Me.DDProcessName = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbgodown = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lblprmid = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DGConsumption = New System.Windows.Forms.DataGridView()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnPreview = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Grpweight = New System.Windows.Forms.GroupBox()
        Me.lblgridindex = New System.Windows.Forms.Label()
        Me.btnweight = New System.Windows.Forms.Button()
        Me.txtweight = New System.Windows.Forms.TextBox()
        Me.txtchalanno = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.gvdetail = New System.Windows.Forms.DataGridView()
        Me.prtidgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descriptiongrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qtygrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNogrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tagnogrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GodownName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Godown = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConsmpQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Issuedqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PendQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lotno = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TagNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.stockqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.issueqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BellWt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.save = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GetWt = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Item_Finished_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGConsumption, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grpweight.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.gvdetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DDRecipeName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DDSlipNo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.DDCompanyName)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.DDBinNo)
        Me.GroupBox1.Controls.Add(Me.lblbinno)
        Me.GroupBox1.Controls.Add(Me.DDProcessName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbgodown)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(9, -5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(699, 95)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'DDRecipeName
        '
        Me.DDRecipeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDRecipeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDRecipeName.FormattingEnabled = True
        Me.DDRecipeName.Location = New System.Drawing.Point(532, 27)
        Me.DDRecipeName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDRecipeName.Name = "DDRecipeName"
        Me.DDRecipeName.Size = New System.Drawing.Size(164, 21)
        Me.DDRecipeName.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(535, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "RecipeName"
        '
        'DDSlipNo
        '
        Me.DDSlipNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDSlipNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDSlipNo.FormattingEnabled = True
        Me.DDSlipNo.Location = New System.Drawing.Point(364, 27)
        Me.DDSlipNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDSlipNo.Name = "DDSlipNo"
        Me.DDSlipNo.Size = New System.Drawing.Size(164, 21)
        Me.DDSlipNo.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(367, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Slip No"
        '
        'DDCompanyName
        '
        Me.DDCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDCompanyName.FormattingEnabled = True
        Me.DDCompanyName.Location = New System.Drawing.Point(5, 27)
        Me.DDCompanyName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDCompanyName.Name = "DDCompanyName"
        Me.DDCompanyName.Size = New System.Drawing.Size(175, 21)
        Me.DDCompanyName.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Company Name"
        '
        'DDBinNo
        '
        Me.DDBinNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDBinNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDBinNo.FormattingEnabled = True
        Me.DDBinNo.Location = New System.Drawing.Point(185, 69)
        Me.DDBinNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDBinNo.Name = "DDBinNo"
        Me.DDBinNo.Size = New System.Drawing.Size(175, 21)
        Me.DDBinNo.TabIndex = 6
        Me.DDBinNo.Visible = False
        '
        'lblbinno
        '
        Me.lblbinno.AutoSize = True
        Me.lblbinno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbinno.Location = New System.Drawing.Point(188, 53)
        Me.lblbinno.Name = "lblbinno"
        Me.lblbinno.Size = New System.Drawing.Size(49, 13)
        Me.lblbinno.TabIndex = 9
        Me.lblbinno.Text = "Bin No."
        Me.lblbinno.Visible = False
        '
        'DDProcessName
        '
        Me.DDProcessName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDProcessName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDProcessName.FormattingEnabled = True
        Me.DDProcessName.Location = New System.Drawing.Point(185, 27)
        Me.DDProcessName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDProcessName.Name = "DDProcessName"
        Me.DDProcessName.Size = New System.Drawing.Size(175, 21)
        Me.DDProcessName.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(188, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Process Name"
        '
        'cmbgodown
        '
        Me.cmbgodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbgodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbgodown.FormattingEnabled = True
        Me.cmbgodown.Location = New System.Drawing.Point(5, 69)
        Me.cmbgodown.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbgodown.Name = "cmbgodown"
        Me.cmbgodown.Size = New System.Drawing.Size(175, 21)
        Me.cmbgodown.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Godown "
        '
        'Lblprmid
        '
        Me.Lblprmid.AutoSize = True
        Me.Lblprmid.Location = New System.Drawing.Point(508, 102)
        Me.Lblprmid.Name = "Lblprmid"
        Me.Lblprmid.Size = New System.Drawing.Size(0, 13)
        Me.Lblprmid.TabIndex = 3
        Me.Lblprmid.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DGConsumption)
        Me.GroupBox3.Location = New System.Drawing.Point(1, 114)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1015, 275)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'DGConsumption
        '
        Me.DGConsumption.AllowUserToAddRows = False
        Me.DGConsumption.AllowUserToDeleteRows = False
        Me.DGConsumption.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGConsumption.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGConsumption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGConsumption.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Godown, Me.Description, Me.ConsmpQty, Me.Issuedqty, Me.PendQty, Me.lotno, Me.TagNo, Me.stockqty, Me.issueqty, Me.BellWt, Me.save, Me.GetWt, Me.Item_Finished_ID, Me.UnitID, Me.ID})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGConsumption.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGConsumption.Location = New System.Drawing.Point(4, 12)
        Me.DGConsumption.Name = "DGConsumption"
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGConsumption.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGConsumption.Size = New System.Drawing.Size(1005, 259)
        Me.DGConsumption.TabIndex = 1
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(733, 669)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(75, 23)
        Me.BtnNew.TabIndex = 7
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnPreview
        '
        Me.BtnPreview.Location = New System.Drawing.Point(814, 670)
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(75, 23)
        Me.BtnPreview.TabIndex = 8
        Me.BtnPreview.Text = "Preview"
        Me.BtnPreview.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(895, 670)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 23)
        Me.BtnClose.TabIndex = 9
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(494, 674)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Port Name"
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(566, 671)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 47
        '
        'Grpweight
        '
        Me.Grpweight.Controls.Add(Me.lblgridindex)
        Me.Grpweight.Controls.Add(Me.btnweight)
        Me.Grpweight.Controls.Add(Me.txtweight)
        Me.Grpweight.Location = New System.Drawing.Point(818, 5)
        Me.Grpweight.Name = "Grpweight"
        Me.Grpweight.Size = New System.Drawing.Size(200, 56)
        Me.Grpweight.TabIndex = 48
        Me.Grpweight.TabStop = False
        Me.Grpweight.Text = "Weight"
        Me.Grpweight.Visible = False
        '
        'lblgridindex
        '
        Me.lblgridindex.AutoSize = True
        Me.lblgridindex.Location = New System.Drawing.Point(6, 40)
        Me.lblgridindex.Name = "lblgridindex"
        Me.lblgridindex.Size = New System.Drawing.Size(52, 13)
        Me.lblgridindex.TabIndex = 50
        Me.lblgridindex.Text = "GridIndex"
        Me.lblgridindex.Visible = False
        '
        'btnweight
        '
        Me.btnweight.Location = New System.Drawing.Point(131, 17)
        Me.btnweight.Name = "btnweight"
        Me.btnweight.Size = New System.Drawing.Size(38, 23)
        Me.btnweight.TabIndex = 49
        Me.btnweight.Text = ">>>"
        Me.btnweight.UseVisualStyleBackColor = True
        '
        'txtweight
        '
        Me.txtweight.Location = New System.Drawing.Point(6, 19)
        Me.txtweight.Name = "txtweight"
        Me.txtweight.Size = New System.Drawing.Size(122, 20)
        Me.txtweight.TabIndex = 49
        '
        'txtchalanno
        '
        Me.txtchalanno.Enabled = False
        Me.txtchalanno.Location = New System.Drawing.Point(711, 23)
        Me.txtchalanno.Margin = New System.Windows.Forms.Padding(2)
        Me.txtchalanno.Name = "txtchalanno"
        Me.txtchalanno.Size = New System.Drawing.Size(102, 20)
        Me.txtchalanno.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(712, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Challan No."
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.gvdetail)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(0, 6)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(964, 217)
        Me.GroupBox5.TabIndex = 52
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Issued Details"
        '
        'gvdetail
        '
        Me.gvdetail.AllowUserToAddRows = False
        Me.gvdetail.AllowUserToDeleteRows = False
        Me.gvdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvdetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prtidgrid, Me.Item_Name, Me.Descriptiongrid, Me.Qtygrid, Me.LotNogrid, Me.Tagnogrid, Me.GodownName})
        Me.gvdetail.Location = New System.Drawing.Point(9, 12)
        Me.gvdetail.Margin = New System.Windows.Forms.Padding(2)
        Me.gvdetail.Name = "gvdetail"
        Me.gvdetail.RowTemplate.Height = 24
        Me.gvdetail.Size = New System.Drawing.Size(950, 199)
        Me.gvdetail.TabIndex = 51
        '
        'prtidgrid
        '
        Me.prtidgrid.HeaderText = "prtidgrid"
        Me.prtidgrid.Name = "prtidgrid"
        Me.prtidgrid.Visible = False
        '
        'Item_Name
        '
        Me.Item_Name.HeaderText = "Item_Name"
        Me.Item_Name.Name = "Item_Name"
        Me.Item_Name.ReadOnly = True
        '
        'Descriptiongrid
        '
        Me.Descriptiongrid.HeaderText = "Description"
        Me.Descriptiongrid.Name = "Descriptiongrid"
        Me.Descriptiongrid.ReadOnly = True
        Me.Descriptiongrid.Width = 300
        '
        'Qtygrid
        '
        Me.Qtygrid.HeaderText = "Qty"
        Me.Qtygrid.Name = "Qtygrid"
        Me.Qtygrid.ReadOnly = True
        '
        'LotNogrid
        '
        Me.LotNogrid.HeaderText = "LotNo."
        Me.LotNogrid.Name = "LotNogrid"
        Me.LotNogrid.ReadOnly = True
        '
        'Tagnogrid
        '
        Me.Tagnogrid.HeaderText = "Tag No."
        Me.Tagnogrid.Name = "Tagnogrid"
        Me.Tagnogrid.ReadOnly = True
        '
        'GodownName
        '
        Me.GodownName.HeaderText = "GodownName"
        Me.GodownName.Name = "GodownName"
        Me.GodownName.ReadOnly = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Location = New System.Drawing.Point(1, 429)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(970, 233)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(10, 665)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(258, 13)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "* Select row and press del key to delete row"
        '
        'Godown
        '
        Me.Godown.HeaderText = "Godown"
        Me.Godown.Name = "Godown"
        Me.Godown.Visible = False
        Me.Godown.Width = 53
        '
        'Description
        '
        Me.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 150
        '
        'ConsmpQty
        '
        Me.ConsmpQty.HeaderText = "Consmp Qty"
        Me.ConsmpQty.Name = "ConsmpQty"
        Me.ConsmpQty.ReadOnly = True
        Me.ConsmpQty.Width = 89
        '
        'Issuedqty
        '
        Me.Issuedqty.HeaderText = "Issued Qty"
        Me.Issuedqty.Name = "Issuedqty"
        Me.Issuedqty.ReadOnly = True
        Me.Issuedqty.Width = 82
        '
        'PendQty
        '
        Me.PendQty.HeaderText = "Pend Qty"
        Me.PendQty.Name = "PendQty"
        Me.PendQty.ReadOnly = True
        Me.PendQty.Width = 76
        '
        'lotno
        '
        Me.lotno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.lotno.HeaderText = "LotNo/BatchNo"
        Me.lotno.Name = "lotno"
        Me.lotno.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lotno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.lotno.Width = 108
        '
        'TagNo
        '
        Me.TagNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.TagNo.HeaderText = "TagNo"
        Me.TagNo.Name = "TagNo"
        Me.TagNo.Width = 129
        '
        'stockqty
        '
        Me.stockqty.HeaderText = "Stock Qty"
        Me.stockqty.Name = "stockqty"
        Me.stockqty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.stockqty.Width = 79
        '
        'issueqty
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow
        Me.issueqty.DefaultCellStyle = DataGridViewCellStyle1
        Me.issueqty.HeaderText = "Issue Qty"
        Me.issueqty.Name = "issueqty"
        Me.issueqty.ReadOnly = True
        Me.issueqty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.issueqty.Width = 76
        '
        'BellWt
        '
        Me.BellWt.HeaderText = ""
        Me.BellWt.Name = "BellWt"
        Me.BellWt.Width = 19
        '
        'save
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.save.DefaultCellStyle = DataGridViewCellStyle2
        Me.save.HeaderText = "Save"
        Me.save.Name = "save"
        Me.save.Text = "Save"
        Me.save.UseColumnTextForButtonValue = True
        Me.save.Visible = False
        Me.save.Width = 38
        '
        'GetWt
        '
        Me.GetWt.HeaderText = ""
        Me.GetWt.Name = "GetWt"
        Me.GetWt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GetWt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.GetWt.Text = "Get Wt."
        Me.GetWt.UseColumnTextForLinkValue = True
        Me.GetWt.Visible = False
        Me.GetWt.Width = 19
        '
        'Item_Finished_ID
        '
        Me.Item_Finished_ID.HeaderText = "Item_Finished_ID"
        Me.Item_Finished_ID.Name = "Item_Finished_ID"
        Me.Item_Finished_ID.Visible = False
        Me.Item_Finished_ID.Width = 114
        '
        'UnitID
        '
        Me.UnitID.HeaderText = "UnitID"
        Me.UnitID.Name = "UnitID"
        Me.UnitID.Visible = False
        Me.UnitID.Width = 62
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        Me.ID.Width = 43
        '
        'FrmRecipeRawMaterialIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1023, 609)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Lblprmid)
        Me.Controls.Add(Me.txtchalanno)
        Me.Controls.Add(Me.Grpweight)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnPreview)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmRecipeRawMaterialIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recipe Raw Material Issue"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DGConsumption, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grpweight.ResumeLayout(False)
        Me.Grpweight.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.gvdetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnPreview As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents Lblprmid As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Grpweight As System.Windows.Forms.GroupBox
    Friend WithEvents btnweight As System.Windows.Forms.Button
    Friend WithEvents txtweight As System.Windows.Forms.TextBox
    Friend WithEvents lblgridindex As System.Windows.Forms.Label
    Friend WithEvents cmbgodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtchalanno As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents gvdetail As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DDProcessName As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DDBinNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblbinno As System.Windows.Forms.Label
    Friend WithEvents prtidgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descriptiongrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qtygrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNogrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tagnogrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GodownName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DDRecipeName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DDSlipNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DDCompanyName As System.Windows.Forms.ComboBox

    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DGConsumption As System.Windows.Forms.DataGridView
    Friend WithEvents Godown As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConsmpQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Issuedqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PendQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lotno As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TagNo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents stockqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents issueqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BellWt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents save As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents GetWt As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Item_Finished_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
