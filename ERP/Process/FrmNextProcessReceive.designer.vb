<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNextProcessReceive
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
        Me.DDCompanyName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DDProcessName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DDPartyName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtChallanNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDate = New System.Windows.Forms.DateTimePicker()
        Me.DDShadeColor = New System.Windows.Forms.ComboBox()
        Me.LblShadeColor = New System.Windows.Forms.Label()
        Me.DDQuality = New System.Windows.Forms.ComboBox()
        Me.LblQuality = New System.Windows.Forms.Label()
        Me.DDItem = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DDCategory = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnpreview = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.SrNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Weight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process_Rec_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process_Rec_Detail_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.DDBranchName = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.DDDesign = New System.Windows.Forms.ComboBox()
        Me.LblDesign = New System.Windows.Forms.Label()
        Me.DDColor = New System.Windows.Forms.ComboBox()
        Me.LblColor = New System.Windows.Forms.Label()
        Me.DDShape = New System.Windows.Forms.ComboBox()
        Me.LblShape = New System.Windows.Forms.Label()
        Me.DDSize = New System.Windows.Forms.ComboBox()
        Me.LblSize = New System.Windows.Forms.Label()
        Me.TxtWeight = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TxtReceiveQty = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DDIssueNo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DDCompanyName
        '
        Me.DDCompanyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDCompanyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDCompanyName.FormattingEnabled = True
        Me.DDCompanyName.Location = New System.Drawing.Point(4, 20)
        Me.DDCompanyName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDCompanyName.Name = "DDCompanyName"
        Me.DDCompanyName.Size = New System.Drawing.Size(150, 21)
        Me.DDCompanyName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 3)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Company Name"
        '
        'DDProcessName
        '
        Me.DDProcessName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDProcessName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDProcessName.FormattingEnabled = True
        Me.DDProcessName.Location = New System.Drawing.Point(312, 20)
        Me.DDProcessName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDProcessName.Name = "DDProcessName"
        Me.DDProcessName.Size = New System.Drawing.Size(150, 21)
        Me.DDProcessName.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(315, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Process Name"
        '
        'DDPartyName
        '
        Me.DDPartyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDPartyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDPartyName.FormattingEnabled = True
        Me.DDPartyName.Location = New System.Drawing.Point(466, 20)
        Me.DDPartyName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDPartyName.Name = "DDPartyName"
        Me.DDPartyName.Size = New System.Drawing.Size(150, 21)
        Me.DDPartyName.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(469, 3)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Party Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(777, 3)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Receive No."
        '
        'TxtChallanNo
        '
        Me.TxtChallanNo.Enabled = False
        Me.TxtChallanNo.Location = New System.Drawing.Point(774, 20)
        Me.TxtChallanNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtChallanNo.Name = "TxtChallanNo"
        Me.TxtChallanNo.Size = New System.Drawing.Size(107, 20)
        Me.TxtChallanNo.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 46)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Receive Date"
        '
        'TxtDate
        '
        Me.TxtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtDate.Location = New System.Drawing.Point(4, 64)
        Me.TxtDate.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(94, 20)
        Me.TxtDate.TabIndex = 6
        '
        'DDShadeColor
        '
        Me.DDShadeColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDShadeColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDShadeColor.FormattingEnabled = True
        Me.DDShadeColor.Location = New System.Drawing.Point(312, 105)
        Me.DDShadeColor.Margin = New System.Windows.Forms.Padding(2)
        Me.DDShadeColor.Name = "DDShadeColor"
        Me.DDShadeColor.Size = New System.Drawing.Size(150, 21)
        Me.DDShadeColor.TabIndex = 17
        '
        'LblShadeColor
        '
        Me.LblShadeColor.AutoSize = True
        Me.LblShadeColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShadeColor.Location = New System.Drawing.Point(315, 89)
        Me.LblShadeColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblShadeColor.Name = "LblShadeColor"
        Me.LblShadeColor.Size = New System.Drawing.Size(76, 13)
        Me.LblShadeColor.TabIndex = 43
        Me.LblShadeColor.Text = "Shade Color"
        '
        'DDQuality
        '
        Me.DDQuality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDQuality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDQuality.FormattingEnabled = True
        Me.DDQuality.Location = New System.Drawing.Point(410, 63)
        Me.DDQuality.Margin = New System.Windows.Forms.Padding(2)
        Me.DDQuality.Name = "DDQuality"
        Me.DDQuality.Size = New System.Drawing.Size(150, 21)
        Me.DDQuality.TabIndex = 11
        '
        'LblQuality
        '
        Me.LblQuality.AutoSize = True
        Me.LblQuality.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblQuality.Location = New System.Drawing.Point(413, 46)
        Me.LblQuality.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblQuality.Name = "LblQuality"
        Me.LblQuality.Size = New System.Drawing.Size(82, 13)
        Me.LblQuality.TabIndex = 41
        Me.LblQuality.Text = "Quality Name"
        '
        'DDItem
        '
        Me.DDItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDItem.FormattingEnabled = True
        Me.DDItem.Location = New System.Drawing.Point(256, 63)
        Me.DDItem.Margin = New System.Windows.Forms.Padding(2)
        Me.DDItem.Name = "DDItem"
        Me.DDItem.Size = New System.Drawing.Size(150, 21)
        Me.DDItem.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(259, 46)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Item Name"
        '
        'DDCategory
        '
        Me.DDCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDCategory.FormattingEnabled = True
        Me.DDCategory.Location = New System.Drawing.Point(102, 63)
        Me.DDCategory.Margin = New System.Windows.Forms.Padding(2)
        Me.DDCategory.Name = "DDCategory"
        Me.DDCategory.Size = New System.Drawing.Size(150, 21)
        Me.DDCategory.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(105, 46)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 13)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Category Name"
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(825, 104)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(56, 20)
        Me.btnclose.TabIndex = 101
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnpreview
        '
        Me.btnpreview.Location = New System.Drawing.Point(761, 104)
        Me.btnpreview.Margin = New System.Windows.Forms.Padding(2)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(64, 20)
        Me.btnpreview.TabIndex = 21
        Me.btnpreview.Text = "Preview"
        Me.btnpreview.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(705, 104)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(56, 20)
        Me.btnsave.TabIndex = 20
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(649, 104)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(56, 20)
        Me.btnNew.TabIndex = 100
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SrNo, Me.Description, Me.Area, Me.Weight, Me.Rate, Me.Qty, Me.Amount, Me.Process_Rec_ID, Me.Process_Rec_Detail_ID})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG.DefaultCellStyle = DataGridViewCellStyle1
        Me.DG.Location = New System.Drawing.Point(4, 130)
        Me.DG.Margin = New System.Windows.Forms.Padding(2)
        Me.DG.Name = "DG"
        Me.DG.RowTemplate.Height = 24
        Me.DG.Size = New System.Drawing.Size(887, 327)
        Me.DG.TabIndex = 67
        '
        'SrNo
        '
        Me.SrNo.HeaderText = "SrNo"
        Me.SrNo.Name = "SrNo"
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 300
        '
        'Area
        '
        Me.Area.HeaderText = "Area"
        Me.Area.Name = "Area"
        Me.Area.ReadOnly = True
        '
        'Weight
        '
        Me.Weight.HeaderText = "Weight"
        Me.Weight.Name = "Weight"
        Me.Weight.ReadOnly = True
        '
        'Rate
        '
        Me.Rate.HeaderText = "Rate"
        Me.Rate.Name = "Rate"
        Me.Rate.ReadOnly = True
        '
        'Qty
        '
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        '
        'Process_Rec_ID
        '
        Me.Process_Rec_ID.HeaderText = "Process_Rec_ID"
        Me.Process_Rec_ID.Name = "Process_Rec_ID"
        Me.Process_Rec_ID.Visible = False
        '
        'Process_Rec_Detail_ID
        '
        Me.Process_Rec_Detail_ID.HeaderText = "Process_Rec_Detail_ID"
        Me.Process_Rec_Detail_ID.Name = "Process_Rec_Detail_ID"
        Me.Process_Rec_Detail_ID.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(7, 713)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(274, 13)
        Me.Label16.TabIndex = 68
        Me.Label16.Text = "* Select row and press del key to delete record"
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(686, 713)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 70
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(614, 717)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 13)
        Me.Label29.TabIndex = 69
        Me.Label29.Text = "Port Name"
        '
        'DDBranchName
        '
        Me.DDBranchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDBranchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDBranchName.FormattingEnabled = True
        Me.DDBranchName.Location = New System.Drawing.Point(158, 20)
        Me.DDBranchName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDBranchName.Name = "DDBranchName"
        Me.DDBranchName.Size = New System.Drawing.Size(150, 21)
        Me.DDBranchName.TabIndex = 2
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(161, 3)
        Me.Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(83, 13)
        Me.Label33.TabIndex = 75
        Me.Label33.Text = "Branch Name"
        '
        'DDDesign
        '
        Me.DDDesign.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDDesign.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDDesign.FormattingEnabled = True
        Me.DDDesign.Location = New System.Drawing.Point(564, 63)
        Me.DDDesign.Margin = New System.Windows.Forms.Padding(2)
        Me.DDDesign.Name = "DDDesign"
        Me.DDDesign.Size = New System.Drawing.Size(150, 21)
        Me.DDDesign.TabIndex = 12
        '
        'LblDesign
        '
        Me.LblDesign.AutoSize = True
        Me.LblDesign.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesign.Location = New System.Drawing.Point(567, 46)
        Me.LblDesign.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDesign.Name = "LblDesign"
        Me.LblDesign.Size = New System.Drawing.Size(82, 13)
        Me.LblDesign.TabIndex = 79
        Me.LblDesign.Text = "Design Name"
        '
        'DDColor
        '
        Me.DDColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDColor.FormattingEnabled = True
        Me.DDColor.Location = New System.Drawing.Point(718, 63)
        Me.DDColor.Margin = New System.Windows.Forms.Padding(2)
        Me.DDColor.Name = "DDColor"
        Me.DDColor.Size = New System.Drawing.Size(150, 21)
        Me.DDColor.TabIndex = 13
        '
        'LblColor
        '
        Me.LblColor.AutoSize = True
        Me.LblColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblColor.Location = New System.Drawing.Point(721, 46)
        Me.LblColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblColor.Name = "LblColor"
        Me.LblColor.Size = New System.Drawing.Size(72, 13)
        Me.LblColor.TabIndex = 81
        Me.LblColor.Text = "Color Name"
        '
        'DDShape
        '
        Me.DDShape.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDShape.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDShape.FormattingEnabled = True
        Me.DDShape.Location = New System.Drawing.Point(4, 105)
        Me.DDShape.Margin = New System.Windows.Forms.Padding(2)
        Me.DDShape.Name = "DDShape"
        Me.DDShape.Size = New System.Drawing.Size(150, 21)
        Me.DDShape.TabIndex = 14
        '
        'LblShape
        '
        Me.LblShape.AutoSize = True
        Me.LblShape.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShape.Location = New System.Drawing.Point(7, 88)
        Me.LblShape.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblShape.Name = "LblShape"
        Me.LblShape.Size = New System.Drawing.Size(79, 13)
        Me.LblShape.TabIndex = 83
        Me.LblShape.Text = "Shape Name"
        '
        'DDSize
        '
        Me.DDSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDSize.FormattingEnabled = True
        Me.DDSize.Location = New System.Drawing.Point(158, 105)
        Me.DDSize.Margin = New System.Windows.Forms.Padding(2)
        Me.DDSize.Name = "DDSize"
        Me.DDSize.Size = New System.Drawing.Size(150, 21)
        Me.DDSize.TabIndex = 16
        '
        'LblSize
        '
        Me.LblSize.AutoSize = True
        Me.LblSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSize.Location = New System.Drawing.Point(161, 88)
        Me.LblSize.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblSize.Name = "LblSize"
        Me.LblSize.Size = New System.Drawing.Size(67, 13)
        Me.LblSize.TabIndex = 85
        Me.LblSize.Text = "Size Name"
        '
        'TxtWeight
        '
        Me.TxtWeight.Location = New System.Drawing.Point(536, 105)
        Me.TxtWeight.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtWeight.Name = "TxtWeight"
        Me.TxtWeight.ReadOnly = True
        Me.TxtWeight.Size = New System.Drawing.Size(76, 20)
        Me.TxtWeight.TabIndex = 19
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(540, 87)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(47, 13)
        Me.Label26.TabIndex = 94
        Me.Label26.Text = "Weight"
        '
        'TxtReceiveQty
        '
        Me.TxtReceiveQty.Location = New System.Drawing.Point(466, 105)
        Me.TxtReceiveQty.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtReceiveQty.Name = "TxtReceiveQty"
        Me.TxtReceiveQty.Size = New System.Drawing.Size(66, 20)
        Me.TxtReceiveQty.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(468, 89)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 96
        Me.Label13.Text = "Qty."
        '
        'DDIssueNo
        '
        Me.DDIssueNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDIssueNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDIssueNo.FormattingEnabled = True
        Me.DDIssueNo.Location = New System.Drawing.Point(620, 20)
        Me.DDIssueNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDIssueNo.Name = "DDIssueNo"
        Me.DDIssueNo.Size = New System.Drawing.Size(150, 21)
        Me.DDIssueNo.TabIndex = 102
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(623, 3)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Issue No"
        '
        'FrmNextProcessReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(896, 463)
        Me.Controls.Add(Me.DDIssueNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtReceiveQty)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtWeight)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.DDSize)
        Me.Controls.Add(Me.LblSize)
        Me.Controls.Add(Me.DDShape)
        Me.Controls.Add(Me.LblShape)
        Me.Controls.Add(Me.DDColor)
        Me.Controls.Add(Me.LblColor)
        Me.Controls.Add(Me.DDDesign)
        Me.Controls.Add(Me.LblDesign)
        Me.Controls.Add(Me.DDBranchName)
        Me.Controls.Add(Me.DDShadeColor)
        Me.Controls.Add(Me.LblShadeColor)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.DDQuality)
        Me.Controls.Add(Me.LblQuality)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.DDItem)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.DDCategory)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnpreview)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.TxtDate)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtChallanNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DDPartyName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DDProcessName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DDCompanyName)
        Me.Controls.Add(Me.Label2)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmNextProcessReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Next Process Receive"
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DDCompanyName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DDProcessName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DDPartyName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtChallanNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DDShadeColor As System.Windows.Forms.ComboBox
    Friend WithEvents LblShadeColor As System.Windows.Forms.Label
    Friend WithEvents DDQuality As System.Windows.Forms.ComboBox
    Friend WithEvents LblQuality As System.Windows.Forms.Label
    Friend WithEvents DDItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DDCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents DDBranchName As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents DDDesign As System.Windows.Forms.ComboBox
    Friend WithEvents LblDesign As System.Windows.Forms.Label
    Friend WithEvents DDColor As System.Windows.Forms.ComboBox
    Friend WithEvents LblColor As System.Windows.Forms.Label
    Friend WithEvents DDShape As System.Windows.Forms.ComboBox
    Friend WithEvents LblShape As System.Windows.Forms.Label
    Friend WithEvents DDSize As System.Windows.Forms.ComboBox
    Friend WithEvents LblSize As System.Windows.Forms.Label
    Friend WithEvents TxtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtReceiveQty As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DDIssueNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SrNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Weight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Process_Rec_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Process_Rec_Detail_ID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
