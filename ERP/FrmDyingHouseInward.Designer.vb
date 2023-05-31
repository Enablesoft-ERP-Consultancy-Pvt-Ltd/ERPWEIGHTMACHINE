<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDyingHouseInward
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
        Me.pnl1 = New System.Windows.Forms.Panel()
        Me.DDBranchName = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DDIssueNo = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DDIndentNo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtchalanno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ddempname = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ddCompName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtProdCode = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtNoofCone = New System.Windows.Forms.TextBox()
        Me.DDConeType = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtBellWt = New System.Windows.Forms.TextBox()
        Me.TxtTagNo = New System.Windows.Forms.TextBox()
        Me.txtissqty = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ddlunit = New System.Windows.Forms.ComboBox()
        Me.TxtMoisture = New System.Windows.Forms.TextBox()
        Me.LblMoisture = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtLotNo = New System.Windows.Forms.TextBox()
        Me.ddgodown = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblShape = New System.Windows.Forms.Label()
        Me.DDShape = New System.Windows.Forms.ComboBox()
        Me.DDSize = New System.Windows.Forms.ComboBox()
        Me.DDBinNo = New System.Windows.Forms.ComboBox()
        Me.LblSize = New System.Windows.Forms.Label()
        Me.lblbinno = New System.Windows.Forms.Label()
        Me.DDColor = New System.Windows.Forms.ComboBox()
        Me.LblColor = New System.Windows.Forms.Label()
        Me.DDDesign = New System.Windows.Forms.ComboBox()
        Me.LblDesign = New System.Windows.Forms.Label()
        Me.ddlshade = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dquality = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dditemname = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ddCatagory = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnpriview = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.gvdetail = New System.Windows.Forms.DataGridView()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TxtFinishedID = New System.Windows.Forms.TextBox()
        Me.DGInwardDetailID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinishedID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGInwardID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GodownName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BinNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnl1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gvdetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl1
        '
        Me.pnl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl1.Controls.Add(Me.DDBranchName)
        Me.pnl1.Controls.Add(Me.Label7)
        Me.pnl1.Controls.Add(Me.DDIssueNo)
        Me.pnl1.Controls.Add(Me.Label15)
        Me.pnl1.Controls.Add(Me.DDIndentNo)
        Me.pnl1.Controls.Add(Me.Label14)
        Me.pnl1.Controls.Add(Me.txtchalanno)
        Me.pnl1.Controls.Add(Me.Label6)
        Me.pnl1.Controls.Add(Me.txtdate)
        Me.pnl1.Controls.Add(Me.Label5)
        Me.pnl1.Controls.Add(Me.ddempname)
        Me.pnl1.Controls.Add(Me.Label3)
        Me.pnl1.Controls.Add(Me.ddCompName)
        Me.pnl1.Controls.Add(Me.Label1)
        Me.pnl1.Location = New System.Drawing.Point(2, 2)
        Me.pnl1.Margin = New System.Windows.Forms.Padding(2)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(1101, 48)
        Me.pnl1.TabIndex = 0
        '
        'DDBranchName
        '
        Me.DDBranchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDBranchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDBranchName.FormattingEnabled = True
        Me.DDBranchName.Location = New System.Drawing.Point(185, 20)
        Me.DDBranchName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDBranchName.Name = "DDBranchName"
        Me.DDBranchName.Size = New System.Drawing.Size(175, 21)
        Me.DDBranchName.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(188, 4)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Branch Name"
        '
        'DDIssueNo
        '
        Me.DDIssueNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDIssueNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDIssueNo.FormattingEnabled = True
        Me.DDIssueNo.Location = New System.Drawing.Point(722, 20)
        Me.DDIssueNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDIssueNo.Name = "DDIssueNo"
        Me.DDIssueNo.Size = New System.Drawing.Size(175, 21)
        Me.DDIssueNo.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(725, 4)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Issue No"
        '
        'DDIndentNo
        '
        Me.DDIndentNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDIndentNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDIndentNo.FormattingEnabled = True
        Me.DDIndentNo.Location = New System.Drawing.Point(543, 20)
        Me.DDIndentNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDIndentNo.Name = "DDIndentNo"
        Me.DDIndentNo.Size = New System.Drawing.Size(175, 21)
        Me.DDIndentNo.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(546, 4)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Indent No"
        '
        'txtchalanno
        '
        Me.txtchalanno.Location = New System.Drawing.Point(901, 20)
        Me.txtchalanno.Margin = New System.Windows.Forms.Padding(2)
        Me.txtchalanno.Name = "txtchalanno"
        Me.txtchalanno.Size = New System.Drawing.Size(90, 20)
        Me.txtchalanno.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(904, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Challan No."
        '
        'txtdate
        '
        Me.txtdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtdate.Location = New System.Drawing.Point(995, 21)
        Me.txtdate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtdate.Name = "txtdate"
        Me.txtdate.Size = New System.Drawing.Size(95, 20)
        Me.txtdate.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(993, 3)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Issue Date"
        '
        'ddempname
        '
        Me.ddempname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddempname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddempname.FormattingEnabled = True
        Me.ddempname.Location = New System.Drawing.Point(364, 20)
        Me.ddempname.Margin = New System.Windows.Forms.Padding(2)
        Me.ddempname.Name = "ddempname"
        Me.ddempname.Size = New System.Drawing.Size(175, 21)
        Me.ddempname.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(367, 4)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Party Name"
        '
        'ddCompName
        '
        Me.ddCompName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddCompName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddCompName.FormattingEnabled = True
        Me.ddCompName.Location = New System.Drawing.Point(6, 20)
        Me.ddCompName.Margin = New System.Windows.Forms.Padding(2)
        Me.ddCompName.Name = "ddCompName"
        Me.ddCompName.Size = New System.Drawing.Size(175, 21)
        Me.ddCompName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Company Name"
        '
        'TxtProdCode
        '
        Me.TxtProdCode.Location = New System.Drawing.Point(9, 158)
        Me.TxtProdCode.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtProdCode.Name = "TxtProdCode"
        Me.TxtProdCode.Size = New System.Drawing.Size(13, 20)
        Me.TxtProdCode.TabIndex = 6
        Me.TxtProdCode.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.TxtNoofCone)
        Me.Panel2.Controls.Add(Me.DDConeType)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TxtBellWt)
        Me.Panel2.Controls.Add(Me.TxtTagNo)
        Me.Panel2.Controls.Add(Me.txtissqty)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.ddlunit)
        Me.Panel2.Controls.Add(Me.TxtMoisture)
        Me.Panel2.Controls.Add(Me.LblMoisture)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TxtLotNo)
        Me.Panel2.Controls.Add(Me.ddgodown)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.LblShape)
        Me.Panel2.Controls.Add(Me.DDShape)
        Me.Panel2.Controls.Add(Me.DDSize)
        Me.Panel2.Controls.Add(Me.DDBinNo)
        Me.Panel2.Controls.Add(Me.LblSize)
        Me.Panel2.Controls.Add(Me.lblbinno)
        Me.Panel2.Controls.Add(Me.DDColor)
        Me.Panel2.Controls.Add(Me.LblColor)
        Me.Panel2.Controls.Add(Me.DDDesign)
        Me.Panel2.Controls.Add(Me.LblDesign)
        Me.Panel2.Controls.Add(Me.ddlshade)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.dquality)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.dditemname)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.ddCatagory)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(3, 59)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1100, 97)
        Me.Panel2.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(805, 45)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 124
        Me.Label16.Text = "No of Cone"
        '
        'TxtNoofCone
        '
        Me.TxtNoofCone.Location = New System.Drawing.Point(802, 61)
        Me.TxtNoofCone.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtNoofCone.Name = "TxtNoofCone"
        Me.TxtNoofCone.Size = New System.Drawing.Size(80, 20)
        Me.TxtNoofCone.TabIndex = 17
        '
        'DDConeType
        '
        Me.DDConeType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDConeType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDConeType.FormattingEnabled = True
        Me.DDConeType.Location = New System.Drawing.Point(703, 61)
        Me.DDConeType.Margin = New System.Windows.Forms.Padding(2)
        Me.DDConeType.Name = "DDConeType"
        Me.DDConeType.Size = New System.Drawing.Size(95, 21)
        Me.DDConeType.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(706, 45)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 13)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "Cone Type"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(953, 46)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 13)
        Me.Label21.TabIndex = 26
        Me.Label21.Text = "Bell Wt."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(552, 45)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "Tag No"
        '
        'TxtBellWt
        '
        Me.TxtBellWt.Location = New System.Drawing.Point(950, 62)
        Me.TxtBellWt.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtBellWt.Name = "TxtBellWt"
        Me.TxtBellWt.Size = New System.Drawing.Size(60, 20)
        Me.TxtBellWt.TabIndex = 19
        '
        'TxtTagNo
        '
        Me.TxtTagNo.Location = New System.Drawing.Point(549, 61)
        Me.TxtTagNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtTagNo.Name = "TxtTagNo"
        Me.TxtTagNo.Size = New System.Drawing.Size(150, 20)
        Me.TxtTagNo.TabIndex = 15
        '
        'txtissqty
        '
        Me.txtissqty.Location = New System.Drawing.Point(886, 61)
        Me.txtissqty.Margin = New System.Windows.Forms.Padding(2)
        Me.txtissqty.Name = "txtissqty"
        Me.txtissqty.Size = New System.Drawing.Size(60, 20)
        Me.txtissqty.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(889, 46)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(26, 13)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Qty"
        '
        'ddlunit
        '
        Me.ddlunit.FormattingEnabled = True
        Me.ddlunit.Location = New System.Drawing.Point(5, 61)
        Me.ddlunit.Margin = New System.Windows.Forms.Padding(2)
        Me.ddlunit.Name = "ddlunit"
        Me.ddlunit.Size = New System.Drawing.Size(78, 21)
        Me.ddlunit.TabIndex = 9
        '
        'TxtMoisture
        '
        Me.TxtMoisture.Location = New System.Drawing.Point(1014, 61)
        Me.TxtMoisture.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMoisture.Name = "TxtMoisture"
        Me.TxtMoisture.Size = New System.Drawing.Size(60, 20)
        Me.TxtMoisture.TabIndex = 20
        Me.TxtMoisture.Visible = False
        '
        'LblMoisture
        '
        Me.LblMoisture.AutoSize = True
        Me.LblMoisture.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMoisture.Location = New System.Drawing.Point(1017, 45)
        Me.LblMoisture.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblMoisture.Name = "LblMoisture"
        Me.LblMoisture.Size = New System.Drawing.Size(55, 13)
        Me.LblMoisture.TabIndex = 90
        Me.LblMoisture.Text = "Moisture"
        Me.LblMoisture.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(15, 45)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 13)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Unit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(399, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Lot No"
        '
        'TxtLotNo
        '
        Me.TxtLotNo.Location = New System.Drawing.Point(395, 61)
        Me.TxtLotNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtLotNo.Name = "TxtLotNo"
        Me.TxtLotNo.Size = New System.Drawing.Size(150, 20)
        Me.TxtLotNo.TabIndex = 14
        '
        'ddgodown
        '
        Me.ddgodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddgodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddgodown.FormattingEnabled = True
        Me.ddgodown.Location = New System.Drawing.Point(87, 61)
        Me.ddgodown.Margin = New System.Windows.Forms.Padding(2)
        Me.ddgodown.Name = "ddgodown"
        Me.ddgodown.Size = New System.Drawing.Size(150, 21)
        Me.ddgodown.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(90, 45)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Godown Name"
        '
        'LblShape
        '
        Me.LblShape.AutoSize = True
        Me.LblShape.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShape.Location = New System.Drawing.Point(913, 3)
        Me.LblShape.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblShape.Name = "LblShape"
        Me.LblShape.Size = New System.Drawing.Size(43, 13)
        Me.LblShape.TabIndex = 109
        Me.LblShape.Text = "Shape"
        '
        'DDShape
        '
        Me.DDShape.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDShape.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDShape.FormattingEnabled = True
        Me.DDShape.Location = New System.Drawing.Point(910, 20)
        Me.DDShape.Margin = New System.Windows.Forms.Padding(2)
        Me.DDShape.Name = "DDShape"
        Me.DDShape.Size = New System.Drawing.Size(90, 21)
        Me.DDShape.TabIndex = 112
        '
        'DDSize
        '
        Me.DDSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDSize.FormattingEnabled = True
        Me.DDSize.Location = New System.Drawing.Point(1004, 20)
        Me.DDSize.Margin = New System.Windows.Forms.Padding(2)
        Me.DDSize.Name = "DDSize"
        Me.DDSize.Size = New System.Drawing.Size(85, 21)
        Me.DDSize.TabIndex = 113
        '
        'DDBinNo
        '
        Me.DDBinNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDBinNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDBinNo.FormattingEnabled = True
        Me.DDBinNo.Location = New System.Drawing.Point(241, 61)
        Me.DDBinNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDBinNo.Name = "DDBinNo"
        Me.DDBinNo.Size = New System.Drawing.Size(150, 21)
        Me.DDBinNo.TabIndex = 13
        Me.DDBinNo.Visible = False
        '
        'LblSize
        '
        Me.LblSize.AutoSize = True
        Me.LblSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSize.Location = New System.Drawing.Point(1007, 3)
        Me.LblSize.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblSize.Name = "LblSize"
        Me.LblSize.Size = New System.Drawing.Size(31, 13)
        Me.LblSize.TabIndex = 108
        Me.LblSize.Text = "Size"
        '
        'lblbinno
        '
        Me.lblbinno.AutoSize = True
        Me.lblbinno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbinno.Location = New System.Drawing.Point(245, 45)
        Me.lblbinno.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblbinno.Name = "lblbinno"
        Me.lblbinno.Size = New System.Drawing.Size(49, 13)
        Me.lblbinno.TabIndex = 19
        Me.lblbinno.Text = "Bin No."
        Me.lblbinno.Visible = False
        '
        'DDColor
        '
        Me.DDColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDColor.FormattingEnabled = True
        Me.DDColor.Location = New System.Drawing.Point(816, 20)
        Me.DDColor.Margin = New System.Windows.Forms.Padding(2)
        Me.DDColor.Name = "DDColor"
        Me.DDColor.Size = New System.Drawing.Size(90, 21)
        Me.DDColor.TabIndex = 111
        '
        'LblColor
        '
        Me.LblColor.AutoSize = True
        Me.LblColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblColor.Location = New System.Drawing.Point(819, 4)
        Me.LblColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblColor.Name = "LblColor"
        Me.LblColor.Size = New System.Drawing.Size(72, 13)
        Me.LblColor.TabIndex = 107
        Me.LblColor.Text = "Color Name"
        '
        'DDDesign
        '
        Me.DDDesign.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDDesign.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDDesign.FormattingEnabled = True
        Me.DDDesign.Location = New System.Drawing.Point(722, 20)
        Me.DDDesign.Margin = New System.Windows.Forms.Padding(2)
        Me.DDDesign.Name = "DDDesign"
        Me.DDDesign.Size = New System.Drawing.Size(90, 21)
        Me.DDDesign.TabIndex = 110
        '
        'LblDesign
        '
        Me.LblDesign.AutoSize = True
        Me.LblDesign.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesign.Location = New System.Drawing.Point(725, 4)
        Me.LblDesign.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDesign.Name = "LblDesign"
        Me.LblDesign.Size = New System.Drawing.Size(82, 13)
        Me.LblDesign.TabIndex = 106
        Me.LblDesign.Text = "Design Name"
        '
        'ddlshade
        '
        Me.ddlshade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddlshade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddlshade.FormattingEnabled = True
        Me.ddlshade.Location = New System.Drawing.Point(543, 20)
        Me.ddlshade.Margin = New System.Windows.Forms.Padding(2)
        Me.ddlshade.Name = "ddlshade"
        Me.ddlshade.Size = New System.Drawing.Size(175, 21)
        Me.ddlshade.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(546, 4)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Shadecolor"
        '
        'dquality
        '
        Me.dquality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.dquality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.dquality.FormattingEnabled = True
        Me.dquality.Location = New System.Drawing.Point(364, 20)
        Me.dquality.Margin = New System.Windows.Forms.Padding(2)
        Me.dquality.Name = "dquality"
        Me.dquality.Size = New System.Drawing.Size(175, 21)
        Me.dquality.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(368, 4)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Quality Name"
        '
        'dditemname
        '
        Me.dditemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.dditemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.dditemname.FormattingEnabled = True
        Me.dditemname.Location = New System.Drawing.Point(185, 20)
        Me.dditemname.Margin = New System.Windows.Forms.Padding(2)
        Me.dditemname.Name = "dditemname"
        Me.dditemname.Size = New System.Drawing.Size(175, 21)
        Me.dditemname.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(202, 4)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Item Name"
        '
        'ddCatagory
        '
        Me.ddCatagory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddCatagory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddCatagory.FormattingEnabled = True
        Me.ddCatagory.Location = New System.Drawing.Point(6, 20)
        Me.ddCatagory.Margin = New System.Windows.Forms.Padding(2)
        Me.ddCatagory.Name = "ddCatagory"
        Me.ddCatagory.Size = New System.Drawing.Size(175, 21)
        Me.ddCatagory.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 4)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Cateogry Name"
        '
        'btnnew
        '
        Me.btnnew.Location = New System.Drawing.Point(862, 160)
        Me.btnnew.Margin = New System.Windows.Forms.Padding(2)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(56, 19)
        Me.btnnew.TabIndex = 6
        Me.btnnew.Text = "New"
        Me.btnnew.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(924, 160)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(56, 19)
        Me.btnsave.TabIndex = 21
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnpriview
        '
        Me.btnpriview.Location = New System.Drawing.Point(987, 160)
        Me.btnpriview.Margin = New System.Windows.Forms.Padding(2)
        Me.btnpriview.Name = "btnpriview"
        Me.btnpriview.Size = New System.Drawing.Size(56, 19)
        Me.btnpriview.TabIndex = 4
        Me.btnpriview.Text = "Preview"
        Me.btnpriview.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(1047, 160)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(56, 19)
        Me.btnclose.TabIndex = 5
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'gvdetail
        '
        Me.gvdetail.AllowUserToAddRows = False
        Me.gvdetail.AllowUserToDeleteRows = False
        Me.gvdetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gvdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvdetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGInwardDetailID, Me.FinishedID, Me.DGInwardID, Me.ItemName, Me.Description, Me.GodownName, Me.LotNo, Me.TagNo, Me.BinNo, Me.Qty})
        Me.gvdetail.Location = New System.Drawing.Point(2, 183)
        Me.gvdetail.Margin = New System.Windows.Forms.Padding(2)
        Me.gvdetail.Name = "gvdetail"
        Me.gvdetail.RowTemplate.Height = 24
        Me.gvdetail.Size = New System.Drawing.Size(1101, 273)
        Me.gvdetail.TabIndex = 33
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(7, 466)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(272, 13)
        Me.Label26.TabIndex = 49
        Me.Label26.Text = "* select row and press del key to delete record"
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(399, 463)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 52
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(327, 467)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(66, 13)
        Me.Label27.TabIndex = 51
        Me.Label27.Text = "Port Name"
        '
        'TxtFinishedID
        '
        Me.TxtFinishedID.Location = New System.Drawing.Point(36, 158)
        Me.TxtFinishedID.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtFinishedID.Name = "TxtFinishedID"
        Me.TxtFinishedID.Size = New System.Drawing.Size(13, 20)
        Me.TxtFinishedID.TabIndex = 53
        Me.TxtFinishedID.Visible = False
        '
        'DGInwardDetailID
        '
        Me.DGInwardDetailID.HeaderText = "InwardDetailID"
        Me.DGInwardDetailID.Name = "DGInwardDetailID"
        Me.DGInwardDetailID.Visible = False
        '
        'FinishedID
        '
        Me.FinishedID.HeaderText = "FinishedID"
        Me.FinishedID.Name = "FinishedID"
        Me.FinishedID.Visible = False
        '
        'DGInwardID
        '
        Me.DGInwardID.HeaderText = "InwardID"
        Me.DGInwardID.Name = "DGInwardID"
        Me.DGInwardID.Visible = False
        '
        'ItemName
        '
        Me.ItemName.HeaderText = "Item Name"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'GodownName
        '
        Me.GodownName.HeaderText = "GodownName"
        Me.GodownName.Name = "GodownName"
        Me.GodownName.ReadOnly = True
        '
        'LotNo
        '
        Me.LotNo.HeaderText = "LotNo"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        '
        'TagNo
        '
        Me.TagNo.HeaderText = "TagNo"
        Me.TagNo.Name = "TagNo"
        Me.TagNo.ReadOnly = True
        '
        'BinNo
        '
        Me.BinNo.HeaderText = "BinNo"
        Me.BinNo.Name = "BinNo"
        '
        'Qty
        '
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        '
        'FrmDyingHouseInward
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1110, 488)
        Me.Controls.Add(Me.TxtFinishedID)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.gvdetail)
        Me.Controls.Add(Me.TxtProdCode)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btnpriview)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btnnew)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnl1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmDyingHouseInward"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dying House Inward"
        Me.pnl1.ResumeLayout(False)
        Me.pnl1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gvdetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtProdCode As System.Windows.Forms.TextBox
    Friend WithEvents txtchalanno As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ddempname As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ddCompName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ddgodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ddlshade As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dquality As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dditemname As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ddCatagory As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ddlunit As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtissqty As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnpriview As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents gvdetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents DDBinNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblbinno As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtBellWt As System.Windows.Forms.TextBox
    Friend WithEvents TxtMoisture As System.Windows.Forms.TextBox
    Friend WithEvents LblMoisture As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTagNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents LblShape As System.Windows.Forms.Label
    Friend WithEvents DDShape As System.Windows.Forms.ComboBox
    Friend WithEvents DDSize As System.Windows.Forms.ComboBox
    Friend WithEvents LblSize As System.Windows.Forms.Label
    Friend WithEvents DDColor As System.Windows.Forms.ComboBox
    Friend WithEvents LblColor As System.Windows.Forms.Label
    Friend WithEvents DDDesign As System.Windows.Forms.ComboBox
    Friend WithEvents LblDesign As System.Windows.Forms.Label
    Friend WithEvents DDConeType As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtNoofCone As System.Windows.Forms.TextBox
    Friend WithEvents DDIssueNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DDIndentNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DDBranchName As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtFinishedID As System.Windows.Forms.TextBox
    Friend WithEvents DGInwardDetailID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinishedID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGInwardID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GodownName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
