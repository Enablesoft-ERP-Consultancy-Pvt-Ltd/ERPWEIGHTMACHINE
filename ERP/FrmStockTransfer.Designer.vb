<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStockTransfer
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ChKForEdit = New System.Windows.Forms.CheckBox()
        Me.DDChallanNo = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtProdCode = New System.Windows.Forms.TextBox()
        Me.txtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtChallanNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DDTCompName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DDFCompName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DDDescription = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dditemname = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ddCatagory = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DDFGodown = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ddlotno = New System.Windows.Forms.ComboBox()
        Me.DDunit = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DDTagNo = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtstock = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtissqty = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnpreview = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FLotNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FTagNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FromGodown = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToGodown = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_Finishedid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FGodownId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TGodownid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransferId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransferDetailID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblbinno = New System.Windows.Forms.Label()
        Me.DDFBinNo = New System.Windows.Forms.ComboBox()
        Me.TxtRemarks = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtEWayBillNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DDTGodown = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DDTBinNo = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtBellWt = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChKForEdit
        '
        Me.ChKForEdit.AutoSize = True
        Me.ChKForEdit.Location = New System.Drawing.Point(246, 3)
        Me.ChKForEdit.Name = "ChKForEdit"
        Me.ChKForEdit.Size = New System.Drawing.Size(62, 17)
        Me.ChKForEdit.TabIndex = 76
        Me.ChKForEdit.Text = "For Edit"
        Me.ChKForEdit.UseVisualStyleBackColor = True
        '
        'DDChallanNo
        '
        Me.DDChallanNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDChallanNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDChallanNo.FormattingEnabled = True
        Me.DDChallanNo.Location = New System.Drawing.Point(313, 23)
        Me.DDChallanNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDChallanNo.Name = "DDChallanNo"
        Me.DDChallanNo.Size = New System.Drawing.Size(150, 21)
        Me.DDChallanNo.TabIndex = 3
        Me.DDChallanNo.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(316, 7)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(69, 13)
        Me.Label23.TabIndex = 73
        Me.Label23.Text = "Challan No"
        Me.Label23.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(696, 7)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(66, 13)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Prod Code"
        Me.Label20.Visible = False
        '
        'TxtProdCode
        '
        Me.TxtProdCode.Location = New System.Drawing.Point(693, 23)
        Me.TxtProdCode.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtProdCode.Name = "TxtProdCode"
        Me.TxtProdCode.Size = New System.Drawing.Size(157, 20)
        Me.TxtProdCode.TabIndex = 9
        Me.TxtProdCode.Visible = False
        '
        'txtdate
        '
        Me.txtdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtdate.Location = New System.Drawing.Point(467, 23)
        Me.txtdate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtdate.Name = "txtdate"
        Me.txtdate.Size = New System.Drawing.Size(109, 20)
        Me.txtdate.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(470, 6)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Issue Date"
        '
        'TxtChallanNo
        '
        Me.TxtChallanNo.Location = New System.Drawing.Point(580, 23)
        Me.TxtChallanNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtChallanNo.Name = "TxtChallanNo"
        Me.TxtChallanNo.Size = New System.Drawing.Size(109, 20)
        Me.TxtChallanNo.TabIndex = 4
        Me.TxtChallanNo.Tag = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(583, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = " Issue No."
        '
        'DDTCompName
        '
        Me.DDTCompName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDTCompName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDTCompName.FormattingEnabled = True
        Me.DDTCompName.Location = New System.Drawing.Point(159, 23)
        Me.DDTCompName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDTCompName.Name = "DDTCompName"
        Me.DDTCompName.Size = New System.Drawing.Size(150, 21)
        Me.DDTCompName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(162, 7)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To Company"
        '
        'DDFCompName
        '
        Me.DDFCompName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDFCompName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDFCompName.FormattingEnabled = True
        Me.DDFCompName.Location = New System.Drawing.Point(5, 23)
        Me.DDFCompName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDFCompName.Name = "DDFCompName"
        Me.DDFCompName.Size = New System.Drawing.Size(150, 21)
        Me.DDFCompName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From Company"
        '
        'DDDescription
        '
        Me.DDDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDDescription.FormattingEnabled = True
        Me.DDDescription.Location = New System.Drawing.Point(517, 64)
        Me.DDDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.DDDescription.Name = "DDDescription"
        Me.DDDescription.Size = New System.Drawing.Size(333, 21)
        Me.DDDescription.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(520, 48)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Item Description"
        '
        'dditemname
        '
        Me.dditemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.dditemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.dditemname.FormattingEnabled = True
        Me.dditemname.Location = New System.Drawing.Point(338, 64)
        Me.dditemname.Margin = New System.Windows.Forms.Padding(2)
        Me.dditemname.Name = "dditemname"
        Me.dditemname.Size = New System.Drawing.Size(175, 21)
        Me.dditemname.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(341, 48)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Item Name"
        '
        'ddCatagory
        '
        Me.ddCatagory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddCatagory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddCatagory.FormattingEnabled = True
        Me.ddCatagory.Location = New System.Drawing.Point(159, 64)
        Me.ddCatagory.Margin = New System.Windows.Forms.Padding(2)
        Me.ddCatagory.Name = "ddCatagory"
        Me.ddCatagory.Size = New System.Drawing.Size(175, 21)
        Me.ddCatagory.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(162, 48)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Category Name"
        '
        'DDFGodown
        '
        Me.DDFGodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDFGodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDFGodown.FormattingEnabled = True
        Me.DDFGodown.Location = New System.Drawing.Point(5, 64)
        Me.DDFGodown.Margin = New System.Windows.Forms.Padding(2)
        Me.DDFGodown.Name = "DDFGodown"
        Me.DDFGodown.Size = New System.Drawing.Size(150, 21)
        Me.DDFGodown.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(9, 48)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "From Godown"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(162, 89)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Lot No."
        '
        'ddlotno
        '
        Me.ddlotno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddlotno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddlotno.FormattingEnabled = True
        Me.ddlotno.Location = New System.Drawing.Point(159, 105)
        Me.ddlotno.Margin = New System.Windows.Forms.Padding(2)
        Me.ddlotno.Name = "ddlotno"
        Me.ddlotno.Size = New System.Drawing.Size(150, 21)
        Me.ddlotno.TabIndex = 10
        '
        'DDunit
        '
        Me.DDunit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDunit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDunit.FormattingEnabled = True
        Me.DDunit.Location = New System.Drawing.Point(467, 105)
        Me.DDunit.Margin = New System.Windows.Forms.Padding(2)
        Me.DDunit.Name = "DDunit"
        Me.DDunit.Size = New System.Drawing.Size(75, 21)
        Me.DDunit.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(470, 89)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Unit"
        '
        'DDTagNo
        '
        Me.DDTagNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDTagNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDTagNo.FormattingEnabled = True
        Me.DDTagNo.Location = New System.Drawing.Point(313, 105)
        Me.DDTagNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDTagNo.Name = "DDTagNo"
        Me.DDTagNo.Size = New System.Drawing.Size(150, 21)
        Me.DDTagNo.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(316, 89)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Tag No."
        '
        'txtstock
        '
        Me.txtstock.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtstock.Enabled = False
        Me.txtstock.Location = New System.Drawing.Point(5, 147)
        Me.txtstock.Margin = New System.Windows.Forms.Padding(2)
        Me.txtstock.Name = "txtstock"
        Me.txtstock.Size = New System.Drawing.Size(100, 20)
        Me.txtstock.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(8, 130)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Stock Qty."
        '
        'txtissqty
        '
        Me.txtissqty.Location = New System.Drawing.Point(109, 147)
        Me.txtissqty.Margin = New System.Windows.Forms.Padding(2)
        Me.txtissqty.Name = "txtissqty"
        Me.txtissqty.ReadOnly = True
        Me.txtissqty.Size = New System.Drawing.Size(100, 20)
        Me.txtissqty.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(112, 130)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Issue Qty."
        '
        'btnnew
        '
        Me.btnnew.Location = New System.Drawing.Point(612, 171)
        Me.btnnew.Margin = New System.Windows.Forms.Padding(2)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(56, 20)
        Me.btnnew.TabIndex = 31
        Me.btnnew.Text = "New"
        Me.btnnew.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(672, 171)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(56, 20)
        Me.btnsave.TabIndex = 18
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnpreview
        '
        Me.btnpreview.Location = New System.Drawing.Point(733, 171)
        Me.btnpreview.Margin = New System.Windows.Forms.Padding(2)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(56, 20)
        Me.btnpreview.TabIndex = 33
        Me.btnpreview.Text = "Preview"
        Me.btnpreview.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(794, 171)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(56, 20)
        Me.btnclose.TabIndex = 34
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item_Name, Me.DESCRIPTION, Me.FLotNo, Me.FTagNo, Me.FromGodown, Me.ToGodown, Me.Qty, Me.Item_Finishedid, Me.FGodownId, Me.TGodownid, Me.TransferId, Me.TransferDetailID})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.DefaultCellStyle = DataGridViewCellStyle2
        Me.DG.Location = New System.Drawing.Point(5, 195)
        Me.DG.Margin = New System.Windows.Forms.Padding(2)
        Me.DG.Name = "DG"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.DG.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DG.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.RowTemplate.Height = 24
        Me.DG.Size = New System.Drawing.Size(845, 261)
        Me.DG.TabIndex = 35
        '
        'Item_Name
        '
        Me.Item_Name.HeaderText = "Item Name"
        Me.Item_Name.Name = "Item_Name"
        Me.Item_Name.Width = 83
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.HeaderText = "Description"
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.Width = 85
        '
        'FLotNo
        '
        Me.FLotNo.HeaderText = "Lot No"
        Me.FLotNo.Name = "FLotNo"
        Me.FLotNo.Width = 64
        '
        'FTagNo
        '
        Me.FTagNo.HeaderText = "Tag No"
        Me.FTagNo.Name = "FTagNo"
        Me.FTagNo.Width = 68
        '
        'FromGodown
        '
        Me.FromGodown.HeaderText = "FGodownName"
        Me.FromGodown.Name = "FromGodown"
        Me.FromGodown.Width = 106
        '
        'ToGodown
        '
        Me.ToGodown.HeaderText = "TGodownName"
        Me.ToGodown.Name = "ToGodown"
        Me.ToGodown.Width = 107
        '
        'Qty
        '
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Width = 48
        '
        'Item_Finishedid
        '
        Me.Item_Finishedid.HeaderText = "Finishedid"
        Me.Item_Finishedid.Name = "Item_Finishedid"
        Me.Item_Finishedid.Visible = False
        Me.Item_Finishedid.Width = 79
        '
        'FGodownId
        '
        Me.FGodownId.HeaderText = "FGodownId"
        Me.FGodownId.Name = "FGodownId"
        Me.FGodownId.Visible = False
        Me.FGodownId.Width = 87
        '
        'TGodownid
        '
        Me.TGodownid.HeaderText = "TGodownid"
        Me.TGodownid.Name = "TGodownid"
        Me.TGodownid.Visible = False
        Me.TGodownid.Width = 87
        '
        'TransferId
        '
        Me.TransferId.HeaderText = "TransferId"
        Me.TransferId.Name = "TransferId"
        Me.TransferId.Visible = False
        Me.TransferId.Width = 80
        '
        'TransferDetailID
        '
        Me.TransferDetailID.HeaderText = "TransferDetailID"
        Me.TransferDetailID.Name = "TransferDetailID"
        Me.TransferDetailID.Visible = False
        Me.TransferDetailID.Width = 109
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(28, 472)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(274, 13)
        Me.Label19.TabIndex = 70
        Me.Label19.Text = "* Select row and press del key to delete record"
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(694, 464)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 86
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(622, 467)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 13)
        Me.Label31.TabIndex = 85
        Me.Label31.Text = "Port Name"
        '
        'lblbinno
        '
        Me.lblbinno.AutoSize = True
        Me.lblbinno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbinno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblbinno.Location = New System.Drawing.Point(8, 89)
        Me.lblbinno.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblbinno.Name = "lblbinno"
        Me.lblbinno.Size = New System.Drawing.Size(76, 13)
        Me.lblbinno.TabIndex = 88
        Me.lblbinno.Text = "From Bin No"
        '
        'DDFBinNo
        '
        Me.DDFBinNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDFBinNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDFBinNo.FormattingEnabled = True
        Me.DDFBinNo.Location = New System.Drawing.Point(5, 105)
        Me.DDFBinNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDFBinNo.Name = "DDFBinNo"
        Me.DDFBinNo.Size = New System.Drawing.Size(150, 21)
        Me.DDFBinNo.TabIndex = 9
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(507, 147)
        Me.TxtRemarks.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(343, 20)
        Me.TxtRemarks.TabIndex = 17
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(509, 130)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 13)
        Me.Label24.TabIndex = 90
        Me.Label24.Text = " Remarks"
        '
        'TxtEWayBillNo
        '
        Me.TxtEWayBillNo.Location = New System.Drawing.Point(314, 147)
        Me.TxtEWayBillNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtEWayBillNo.Name = "TxtEWayBillNo"
        Me.TxtEWayBillNo.Size = New System.Drawing.Size(189, 20)
        Me.TxtEWayBillNo.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(317, 130)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "EWay BillNo"
        '
        'DDTGodown
        '
        Me.DDTGodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDTGodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDTGodown.FormattingEnabled = True
        Me.DDTGodown.Location = New System.Drawing.Point(546, 105)
        Me.DDTGodown.Margin = New System.Windows.Forms.Padding(2)
        Me.DDTGodown.Name = "DDTGodown"
        Me.DDTGodown.Size = New System.Drawing.Size(150, 21)
        Me.DDTGodown.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(549, 89)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "To Godown"
        '
        'DDTBinNo
        '
        Me.DDTBinNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDTBinNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDTBinNo.FormattingEnabled = True
        Me.DDTBinNo.Location = New System.Drawing.Point(700, 105)
        Me.DDTBinNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDTBinNo.Name = "DDTBinNo"
        Me.DDTBinNo.Size = New System.Drawing.Size(150, 21)
        Me.DDTBinNo.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(703, 89)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 13)
        Me.Label16.TabIndex = 96
        Me.Label16.Text = "To Bin No"
        '
        'TxtBellWt
        '
        Me.TxtBellWt.Location = New System.Drawing.Point(213, 147)
        Me.TxtBellWt.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtBellWt.Name = "TxtBellWt"
        Me.TxtBellWt.Size = New System.Drawing.Size(97, 20)
        Me.TxtBellWt.TabIndex = 98
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(216, 130)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 97
        Me.Label17.Text = "Bell Wt"
        '
        'FrmStockTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(857, 492)
        Me.Controls.Add(Me.TxtBellWt)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.DDTBinNo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DDTGodown)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DDDescription)
        Me.Controls.Add(Me.ChKForEdit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dditemname)
        Me.Controls.Add(Me.DDChallanNo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtEWayBillNo)
        Me.Controls.Add(Me.ddCatagory)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DDunit)
        Me.Controls.Add(Me.DDFBinNo)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lblbinno)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DDFGodown)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtProdCode)
        Me.Controls.Add(Me.TxtRemarks)
        Me.Controls.Add(Me.txtdate)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtChallanNo)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ddlotno)
        Me.Controls.Add(Me.DDTCompName)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.DDFCompName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btnpreview)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btnnew)
        Me.Controls.Add(Me.txtissqty)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtstock)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.DDTagNo)
        Me.Controls.Add(Me.Label13)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmStockTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Transfer"
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtChallanNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DDTCompName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DDFCompName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DDunit As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DDDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dditemname As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ddCatagory As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DDFGodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ddlotno As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DDTagNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtstock As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtissqty As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtProdCode As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblbinno As System.Windows.Forms.Label
    Friend WithEvents DDFBinNo As System.Windows.Forms.ComboBox
    Friend WithEvents DDChallanNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ChKForEdit As System.Windows.Forms.CheckBox
    Friend WithEvents TxtEWayBillNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DDTGodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DDTBinNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FLotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTagNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FromGodown As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToGodown As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Finishedid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FGodownId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TGodownid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransferId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransferDetailID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtBellWt As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
