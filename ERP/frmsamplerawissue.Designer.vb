<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsamplerawissue
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtissuedate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtchallanNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DDissueNo = New System.Windows.Forms.ComboBox()
        Me.DDcompany = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DDvendor = New System.Windows.Forms.ComboBox()
        Me.DDprocess = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DDBinNo = New System.Windows.Forms.ComboBox()
        Me.lblbinno = New System.Windows.Forms.Label()
        Me.TxtProdCode = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtissueqty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtstockqty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DDTagNo = New System.Windows.Forms.ComboBox()
        Me.lbltagno = New System.Windows.Forms.Label()
        Me.DDLotno = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DDunit = New System.Windows.Forms.ComboBox()
        Me.DDGodown = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ddlshade = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dquality = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dditemname = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ddCatagory = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnpreview = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.gvdetail = New System.Windows.Forms.DataGridView()
        Me.prtidgvdetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GodownName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtWeaverIdNoscan = New System.Windows.Forms.TextBox()
        Me.chkcomplete = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gvdetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtissuedate)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtchallanNo)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.DDissueNo)
        Me.Panel1.Controls.Add(Me.DDcompany)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DDvendor)
        Me.Panel1.Controls.Add(Me.DDprocess)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(3, 38)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 49)
        Me.Panel1.TabIndex = 0
        '
        'txtissuedate
        '
        Me.txtissuedate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtissuedate.Location = New System.Drawing.Point(872, 18)
        Me.txtissuedate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtissuedate.Name = "txtissuedate"
        Me.txtissuedate.Size = New System.Drawing.Size(107, 20)
        Me.txtissuedate.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(872, 3)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Issue Date"
        '
        'txtchallanNo
        '
        Me.txtchallanNo.Enabled = False
        Me.txtchallanNo.Location = New System.Drawing.Point(752, 19)
        Me.txtchallanNo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtchallanNo.Name = "txtchallanNo"
        Me.txtchallanNo.Size = New System.Drawing.Size(117, 20)
        Me.txtchallanNo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(752, 3)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Challan No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(589, 2)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Issue No."
        '
        'DDissueNo
        '
        Me.DDissueNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDissueNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDissueNo.FormattingEnabled = True
        Me.DDissueNo.Location = New System.Drawing.Point(591, 19)
        Me.DDissueNo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DDissueNo.Name = "DDissueNo"
        Me.DDissueNo.Size = New System.Drawing.Size(157, 21)
        Me.DDissueNo.TabIndex = 3
        '
        'DDcompany
        '
        Me.DDcompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDcompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDcompany.FormattingEnabled = True
        Me.DDcompany.Location = New System.Drawing.Point(5, 19)
        Me.DDcompany.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DDcompany.Name = "DDcompany"
        Me.DDcompany.Size = New System.Drawing.Size(191, 21)
        Me.DDcompany.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 2)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Company Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(197, 2)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Process Name"
        '
        'DDvendor
        '
        Me.DDvendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDvendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDvendor.FormattingEnabled = True
        Me.DDvendor.Location = New System.Drawing.Point(360, 19)
        Me.DDvendor.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DDvendor.Name = "DDvendor"
        Me.DDvendor.Size = New System.Drawing.Size(228, 21)
        Me.DDvendor.TabIndex = 2
        '
        'DDprocess
        '
        Me.DDprocess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDprocess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDprocess.FormattingEnabled = True
        Me.DDprocess.Location = New System.Drawing.Point(200, 19)
        Me.DDprocess.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DDprocess.Name = "DDprocess"
        Me.DDprocess.Size = New System.Drawing.Size(157, 21)
        Me.DDprocess.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(358, 2)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "vendor Name"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.DDBinNo)
        Me.Panel2.Controls.Add(Me.lblbinno)
        Me.Panel2.Controls.Add(Me.TxtProdCode)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtissueqty)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtstockqty)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.DDTagNo)
        Me.Panel2.Controls.Add(Me.lbltagno)
        Me.Panel2.Controls.Add(Me.DDLotno)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.DDunit)
        Me.Panel2.Controls.Add(Me.DDGodown)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.ddlshade)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.dquality)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.dditemname)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.ddCatagory)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Location = New System.Drawing.Point(3, 91)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 82)
        Me.Panel2.TabIndex = 1
        '
        'DDBinNo
        '
        Me.DDBinNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDBinNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDBinNo.FormattingEnabled = True
        Me.DDBinNo.Location = New System.Drawing.Point(502, 58)
        Me.DDBinNo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DDBinNo.Name = "DDBinNo"
        Me.DDBinNo.Size = New System.Drawing.Size(136, 21)
        Me.DDBinNo.TabIndex = 8
        Me.DDBinNo.Visible = False
        '
        'lblbinno
        '
        Me.lblbinno.AutoSize = True
        Me.lblbinno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbinno.Location = New System.Drawing.Point(500, 41)
        Me.lblbinno.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblbinno.Name = "lblbinno"
        Me.lblbinno.Size = New System.Drawing.Size(49, 13)
        Me.lblbinno.TabIndex = 86
        Me.lblbinno.Text = "Bin No."
        Me.lblbinno.Visible = False
        '
        'TxtProdCode
        '
        Me.TxtProdCode.Location = New System.Drawing.Point(890, 20)
        Me.TxtProdCode.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtProdCode.Name = "TxtProdCode"
        Me.TxtProdCode.Size = New System.Drawing.Size(92, 20)
        Me.TxtProdCode.TabIndex = 65
        Me.TxtProdCode.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(890, 3)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 64
        Me.Label16.Text = "Prod code"
        Me.Label16.Visible = False
        '
        'txtissueqty
        '
        Me.txtissueqty.Location = New System.Drawing.Point(743, 58)
        Me.txtissueqty.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtissueqty.Name = "txtissueqty"
        Me.txtissueqty.ReadOnly = True
        Me.txtissueqty.Size = New System.Drawing.Size(92, 20)
        Me.txtissueqty.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(743, 41)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Issue Qty."
        '
        'txtstockqty
        '
        Me.txtstockqty.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtstockqty.Enabled = False
        Me.txtstockqty.Location = New System.Drawing.Point(642, 58)
        Me.txtstockqty.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtstockqty.Name = "txtstockqty"
        Me.txtstockqty.Size = New System.Drawing.Size(98, 20)
        Me.txtstockqty.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(642, 41)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Stock Qty."
        '
        'DDTagNo
        '
        Me.DDTagNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDTagNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDTagNo.FormattingEnabled = True
        Me.DDTagNo.Location = New System.Drawing.Point(340, 58)
        Me.DDTagNo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DDTagNo.Name = "DDTagNo"
        Me.DDTagNo.Size = New System.Drawing.Size(158, 21)
        Me.DDTagNo.TabIndex = 7
        Me.DDTagNo.Visible = False
        '
        'lbltagno
        '
        Me.lbltagno.AutoSize = True
        Me.lbltagno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltagno.Location = New System.Drawing.Point(338, 41)
        Me.lbltagno.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbltagno.Name = "lbltagno"
        Me.lbltagno.Size = New System.Drawing.Size(53, 13)
        Me.lbltagno.TabIndex = 59
        Me.lbltagno.Text = "Tag No."
        Me.lbltagno.Visible = False
        '
        'DDLotno
        '
        Me.DDLotno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDLotno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDLotno.FormattingEnabled = True
        Me.DDLotno.Location = New System.Drawing.Point(179, 58)
        Me.DDLotno.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DDLotno.Name = "DDLotno"
        Me.DDLotno.Size = New System.Drawing.Size(158, 21)
        Me.DDLotno.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(177, 41)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "Lot No."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(715, 2)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "Unit"
        '
        'DDunit
        '
        Me.DDunit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDunit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDunit.FormattingEnabled = True
        Me.DDunit.Location = New System.Drawing.Point(717, 18)
        Me.DDunit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DDunit.Name = "DDunit"
        Me.DDunit.Size = New System.Drawing.Size(94, 21)
        Me.DDunit.TabIndex = 4
        '
        'DDGodown
        '
        Me.DDGodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDGodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDGodown.FormattingEnabled = True
        Me.DDGodown.Location = New System.Drawing.Point(6, 58)
        Me.DDGodown.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DDGodown.Name = "DDGodown"
        Me.DDGodown.Size = New System.Drawing.Size(170, 21)
        Me.DDGodown.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(4, 41)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 13)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Godown Name"
        '
        'ddlshade
        '
        Me.ddlshade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddlshade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddlshade.FormattingEnabled = True
        Me.ddlshade.Location = New System.Drawing.Point(543, 18)
        Me.ddlshade.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ddlshade.Name = "ddlshade"
        Me.ddlshade.Size = New System.Drawing.Size(170, 21)
        Me.ddlshade.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(541, 2)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Shade color"
        '
        'dquality
        '
        Me.dquality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.dquality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.dquality.FormattingEnabled = True
        Me.dquality.Location = New System.Drawing.Point(369, 18)
        Me.dquality.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dquality.Name = "dquality"
        Me.dquality.Size = New System.Drawing.Size(170, 21)
        Me.dquality.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(367, 2)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Quality Name"
        '
        'dditemname
        '
        Me.dditemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.dditemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.dditemname.FormattingEnabled = True
        Me.dditemname.Location = New System.Drawing.Point(195, 18)
        Me.dditemname.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dditemname.Name = "dditemname"
        Me.dditemname.Size = New System.Drawing.Size(170, 21)
        Me.dditemname.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(193, 2)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Item Name"
        '
        'ddCatagory
        '
        Me.ddCatagory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddCatagory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddCatagory.FormattingEnabled = True
        Me.ddCatagory.Location = New System.Drawing.Point(5, 18)
        Me.ddCatagory.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ddCatagory.Name = "ddCatagory"
        Me.ddCatagory.Size = New System.Drawing.Size(186, 21)
        Me.ddCatagory.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 2)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 13)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Category Name"
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(931, 177)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(56, 20)
        Me.btnclose.TabIndex = 11
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnpreview
        '
        Me.btnpreview.Location = New System.Drawing.Point(872, 177)
        Me.btnpreview.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(56, 20)
        Me.btnpreview.TabIndex = 9
        Me.btnpreview.Text = "Preview"
        Me.btnpreview.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(812, 178)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(56, 20)
        Me.btnsave.TabIndex = 8
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(753, 178)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(56, 20)
        Me.btnNew.TabIndex = 12
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'gvdetail
        '
        Me.gvdetail.AllowUserToAddRows = False
        Me.gvdetail.AllowUserToDeleteRows = False
        Me.gvdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvdetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prtidgvdetail, Me.ItemName, Me.Description, Me.Qty, Me.LotNo, Me.TagNo, Me.GodownName})
        Me.gvdetail.Location = New System.Drawing.Point(3, 205)
        Me.gvdetail.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gvdetail.Name = "gvdetail"
        Me.gvdetail.RowTemplate.Height = 24
        Me.gvdetail.Size = New System.Drawing.Size(984, 252)
        Me.gvdetail.TabIndex = 0
        '
        'prtidgvdetail
        '
        Me.prtidgvdetail.HeaderText = "prtidgvdetail"
        Me.prtidgvdetail.Name = "prtidgvdetail"
        Me.prtidgvdetail.Visible = False
        '
        'ItemName
        '
        Me.ItemName.HeaderText = "Item Name"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        Me.ItemName.Width = 150
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
        '
        'LotNo
        '
        Me.LotNo.HeaderText = "Lot No."
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        '
        'TagNo
        '
        Me.TagNo.HeaderText = "Tag No."
        Me.TagNo.Name = "TagNo"
        Me.TagNo.ReadOnly = True
        '
        'GodownName
        '
        Me.GodownName.HeaderText = "Godown Name"
        Me.GodownName.Name = "GodownName"
        Me.GodownName.ReadOnly = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(1, 466)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(274, 13)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "* Select row and press del key to delete record"
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(867, 462)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 84
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(795, 466)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 13)
        Me.Label31.TabIndex = 83
        Me.Label31.Text = "Port Name"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(362, 0)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(137, 13)
        Me.Label18.TabIndex = 60
        Me.Label18.Text = "Enter/Scan Emp. Code"
        '
        'txtWeaverIdNoscan
        '
        Me.txtWeaverIdNoscan.Location = New System.Drawing.Point(364, 16)
        Me.txtWeaverIdNoscan.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtWeaverIdNoscan.Name = "txtWeaverIdNoscan"
        Me.txtWeaverIdNoscan.Size = New System.Drawing.Size(138, 20)
        Me.txtWeaverIdNoscan.TabIndex = 66
        '
        'chkcomplete
        '
        Me.chkcomplete.AutoSize = True
        Me.chkcomplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkcomplete.Location = New System.Drawing.Point(10, 16)
        Me.chkcomplete.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.chkcomplete.Name = "chkcomplete"
        Me.chkcomplete.Size = New System.Drawing.Size(100, 17)
        Me.chkcomplete.TabIndex = 85
        Me.chkcomplete.Text = "For Complete"
        Me.chkcomplete.UseVisualStyleBackColor = True
        '
        'frmsamplerawissue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 488)
        Me.Controls.Add(Me.chkcomplete)
        Me.Controls.Add(Me.txtWeaverIdNoscan)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.gvdetail)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btnpreview)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmsamplerawissue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "1.54"
        Me.Text = "Sample Raw Issue"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gvdetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtissuedate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtchallanNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DDissueNo As System.Windows.Forms.ComboBox
    Friend WithEvents DDcompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DDvendor As System.Windows.Forms.ComboBox
    Friend WithEvents DDprocess As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ddlshade As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dquality As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dditemname As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ddCatagory As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DDTagNo As System.Windows.Forms.ComboBox
    Friend WithEvents lbltagno As System.Windows.Forms.Label
    Friend WithEvents DDLotno As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DDunit As System.Windows.Forms.ComboBox
    Friend WithEvents DDGodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtProdCode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtissueqty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtstockqty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents gvdetail As System.Windows.Forms.DataGridView
    Friend WithEvents prtidgvdetail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GodownName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtWeaverIdNoscan As System.Windows.Forms.TextBox
    Friend WithEvents chkcomplete As System.Windows.Forms.CheckBox
    Friend WithEvents DDBinNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblbinno As System.Windows.Forms.Label
End Class
