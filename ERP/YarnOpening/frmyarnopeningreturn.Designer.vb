<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmyarnopeningreturn
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
        Me.DDBinNo = New System.Windows.Forms.ComboBox()
        Me.lblbinno = New System.Windows.Forms.Label()
        Me.txtLotno = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DDGodown = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtretdate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtretNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DDIssueno = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtWeaverIdNoscan = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.DDvendor = New System.Windows.Forms.ComboBox()
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
        Me.ItemDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lotno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tagno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Issuedqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Receivedqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Retqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RetQtyEnter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblissuemasterid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblitemfinishedid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblunitid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblflagsize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblissuemasterdetailid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GpMasterdetails.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGReturnedDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GpMasterdetails
        '
        Me.GpMasterdetails.Controls.Add(Me.DDBinNo)
        Me.GpMasterdetails.Controls.Add(Me.lblbinno)
        Me.GpMasterdetails.Controls.Add(Me.txtLotno)
        Me.GpMasterdetails.Controls.Add(Me.Label7)
        Me.GpMasterdetails.Controls.Add(Me.DDGodown)
        Me.GpMasterdetails.Controls.Add(Me.Label6)
        Me.GpMasterdetails.Controls.Add(Me.txtretdate)
        Me.GpMasterdetails.Controls.Add(Me.Label5)
        Me.GpMasterdetails.Controls.Add(Me.txtretNo)
        Me.GpMasterdetails.Controls.Add(Me.Label4)
        Me.GpMasterdetails.Controls.Add(Me.DDIssueno)
        Me.GpMasterdetails.Controls.Add(Me.Label3)
        Me.GpMasterdetails.Controls.Add(Me.txtWeaverIdNoscan)
        Me.GpMasterdetails.Controls.Add(Me.Label21)
        Me.GpMasterdetails.Controls.Add(Me.DDvendor)
        Me.GpMasterdetails.Controls.Add(Me.Label2)
        Me.GpMasterdetails.Controls.Add(Me.DDcompany)
        Me.GpMasterdetails.Controls.Add(Me.Label1)
        Me.GpMasterdetails.ForeColor = System.Drawing.Color.Red
        Me.GpMasterdetails.Location = New System.Drawing.Point(4, 0)
        Me.GpMasterdetails.Margin = New System.Windows.Forms.Padding(2)
        Me.GpMasterdetails.Name = "GpMasterdetails"
        Me.GpMasterdetails.Padding = New System.Windows.Forms.Padding(2)
        Me.GpMasterdetails.Size = New System.Drawing.Size(966, 129)
        Me.GpMasterdetails.TabIndex = 1
        Me.GpMasterdetails.TabStop = False
        Me.GpMasterdetails.Text = "Master Details"
        '
        'DDBinNo
        '
        Me.DDBinNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDBinNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDBinNo.FormattingEnabled = True
        Me.DDBinNo.Location = New System.Drawing.Point(223, 102)
        Me.DDBinNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDBinNo.Name = "DDBinNo"
        Me.DDBinNo.Size = New System.Drawing.Size(146, 21)
        Me.DDBinNo.TabIndex = 85
        Me.DDBinNo.Visible = False
        '
        'lblbinno
        '
        Me.lblbinno.AutoSize = True
        Me.lblbinno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbinno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblbinno.Location = New System.Drawing.Point(220, 85)
        Me.lblbinno.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblbinno.Name = "lblbinno"
        Me.lblbinno.Size = New System.Drawing.Size(49, 13)
        Me.lblbinno.TabIndex = 84
        Me.lblbinno.Text = "Bin No."
        Me.lblbinno.Visible = False
        '
        'txtLotno
        '
        Me.txtLotno.Location = New System.Drawing.Point(440, 63)
        Me.txtLotno.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLotno.Name = "txtLotno"
        Me.txtLotno.Size = New System.Drawing.Size(136, 20)
        Me.txtLotno.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(438, 47)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Lot No."
        '
        'DDGodown
        '
        Me.DDGodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDGodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDGodown.FormattingEnabled = True
        Me.DDGodown.Location = New System.Drawing.Point(8, 102)
        Me.DDGodown.Margin = New System.Windows.Forms.Padding(2)
        Me.DDGodown.Name = "DDGodown"
        Me.DDGodown.Size = New System.Drawing.Size(212, 21)
        Me.DDGodown.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(5, 85)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Godown Name"
        '
        'txtretdate
        '
        Me.txtretdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtretdate.Location = New System.Drawing.Point(859, 63)
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
        Me.Label5.Location = New System.Drawing.Point(856, 47)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Return Date"
        '
        'txtretNo
        '
        Me.txtretNo.Enabled = False
        Me.txtretNo.Location = New System.Drawing.Point(750, 63)
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
        Me.Label4.Location = New System.Drawing.Point(748, 47)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Return No."
        '
        'DDIssueno
        '
        Me.DDIssueno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDIssueno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDIssueno.FormattingEnabled = True
        Me.DDIssueno.Location = New System.Drawing.Point(579, 63)
        Me.DDIssueno.Margin = New System.Windows.Forms.Padding(2)
        Me.DDIssueno.Name = "DDIssueno"
        Me.DDIssueno.Size = New System.Drawing.Size(168, 21)
        Me.DDIssueno.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(577, 47)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Issue No."
        '
        'txtWeaverIdNoscan
        '
        Me.txtWeaverIdNoscan.Location = New System.Drawing.Point(221, 27)
        Me.txtWeaverIdNoscan.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWeaverIdNoscan.Name = "txtWeaverIdNoscan"
        Me.txtWeaverIdNoscan.Size = New System.Drawing.Size(213, 20)
        Me.txtWeaverIdNoscan.TabIndex = 12
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(219, 11)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(137, 13)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Enter/Scan Emp. Code"
        '
        'DDvendor
        '
        Me.DDvendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDvendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDvendor.FormattingEnabled = True
        Me.DDvendor.Location = New System.Drawing.Point(221, 63)
        Me.DDvendor.Margin = New System.Windows.Forms.Padding(2)
        Me.DDvendor.Name = "DDvendor"
        Me.DDvendor.Size = New System.Drawing.Size(213, 21)
        Me.DDvendor.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(219, 47)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Vendor Name"
        '
        'DDcompany
        '
        Me.DDcompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDcompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDcompany.FormattingEnabled = True
        Me.DDcompany.Location = New System.Drawing.Point(8, 63)
        Me.DDcompany.Margin = New System.Windows.Forms.Padding(2)
        Me.DDcompany.Name = "DDcompany"
        Me.DDcompany.Size = New System.Drawing.Size(210, 21)
        Me.DDcompany.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(5, 47)
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
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemDescription, Me.Unit, Me.Lotno, Me.Tagno, Me.Issuedqty, Me.Receivedqty, Me.Pqty, Me.Retqty, Me.RetQtyEnter, Me.lblissuemasterid, Me.lblitemfinishedid, Me.lblunitid, Me.lblflagsize, Me.lblissuemasterdetailid})
        Me.DG.Location = New System.Drawing.Point(9, 134)
        Me.DG.Margin = New System.Windows.Forms.Padding(2)
        Me.DG.Name = "DG"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DG.RowTemplate.Height = 24
        Me.DG.Size = New System.Drawing.Size(960, 212)
        Me.DG.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DGReturnedDetail)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 358)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(960, 215)
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
        Me.DGReturnedDetail.Size = New System.Drawing.Size(951, 191)
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
        Me.btnnew.Location = New System.Drawing.Point(785, 580)
        Me.btnnew.Margin = New System.Windows.Forms.Padding(2)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(56, 19)
        Me.btnnew.TabIndex = 21
        Me.btnnew.Text = "New"
        Me.btnnew.UseVisualStyleBackColor = True
        '
        'btnpreview
        '
        Me.btnpreview.Location = New System.Drawing.Point(846, 580)
        Me.btnpreview.Margin = New System.Windows.Forms.Padding(2)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(56, 19)
        Me.btnpreview.TabIndex = 22
        Me.btnpreview.Text = "Preview"
        Me.btnpreview.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(907, 580)
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
        Me.cmb_port.Location = New System.Drawing.Point(645, 580)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 82
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(579, 583)
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
        Me.Label28.Location = New System.Drawing.Point(7, 580)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(349, 17)
        Me.Label28.TabIndex = 83
        Me.Label28.Text = "* Select row and press del key to delete record"
        '
        'ItemDescription
        '
        Me.ItemDescription.HeaderText = "Item Description"
        Me.ItemDescription.Name = "ItemDescription"
        Me.ItemDescription.ReadOnly = True
        Me.ItemDescription.Width = 99
        '
        'Unit
        '
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        Me.Unit.Width = 51
        '
        'Lotno
        '
        Me.Lotno.HeaderText = "Lot No."
        Me.Lotno.Name = "Lotno"
        Me.Lotno.ReadOnly = True
        Me.Lotno.Width = 62
        '
        'Tagno
        '
        Me.Tagno.HeaderText = "Tag No."
        Me.Tagno.Name = "Tagno"
        Me.Tagno.ReadOnly = True
        Me.Tagno.Width = 51
        '
        'Issuedqty
        '
        Me.Issuedqty.HeaderText = "Issued Qty"
        Me.Issuedqty.Name = "Issuedqty"
        Me.Issuedqty.ReadOnly = True
        Me.Issuedqty.Width = 76
        '
        'Receivedqty
        '
        Me.Receivedqty.HeaderText = "Received Qty"
        Me.Receivedqty.Name = "Receivedqty"
        Me.Receivedqty.ReadOnly = True
        Me.Receivedqty.Width = 89
        '
        'Pqty
        '
        Me.Pqty.HeaderText = "Pqty"
        Me.Pqty.Name = "Pqty"
        Me.Pqty.ReadOnly = True
        Me.Pqty.Width = 53
        '
        'Retqty
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Retqty.DefaultCellStyle = DataGridViewCellStyle1
        Me.Retqty.HeaderText = "Ret. Qty Wt"
        Me.Retqty.Name = "Retqty"
        Me.Retqty.ReadOnly = True
        Me.Retqty.Width = 69
        '
        'RetQtyEnter
        '
        Me.RetQtyEnter.HeaderText = "Ret Qty"
        Me.RetQtyEnter.Name = "RetQtyEnter"
        Me.RetQtyEnter.Width = 49
        '
        'lblissuemasterid
        '
        Me.lblissuemasterid.HeaderText = "lblissuemasterid"
        Me.lblissuemasterid.Name = "lblissuemasterid"
        Me.lblissuemasterid.Visible = False
        Me.lblissuemasterid.Width = 105
        '
        'lblitemfinishedid
        '
        Me.lblitemfinishedid.HeaderText = "lblitemfinishedid"
        Me.lblitemfinishedid.Name = "lblitemfinishedid"
        Me.lblitemfinishedid.Visible = False
        Me.lblitemfinishedid.Width = 105
        '
        'lblunitid
        '
        Me.lblunitid.HeaderText = "lblunitid"
        Me.lblunitid.Name = "lblunitid"
        Me.lblunitid.Visible = False
        Me.lblunitid.Width = 67
        '
        'lblflagsize
        '
        Me.lblflagsize.HeaderText = "lblflagsize"
        Me.lblflagsize.Name = "lblflagsize"
        Me.lblflagsize.Visible = False
        Me.lblflagsize.Width = 77
        '
        'lblissuemasterdetailid
        '
        Me.lblissuemasterdetailid.HeaderText = "lblissuemasterdetailid"
        Me.lblissuemasterdetailid.Name = "lblissuemasterdetailid"
        Me.lblissuemasterdetailid.Visible = False
        Me.lblissuemasterdetailid.Width = 130
        '
        'frmyarnopeningreturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(975, 609)
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
        Me.Name = "frmyarnopeningreturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Yarn Opening Return"
        Me.GpMasterdetails.ResumeLayout(False)
        Me.GpMasterdetails.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DGReturnedDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GpMasterdetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtWeaverIdNoscan As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents DDvendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DDcompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DDGodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtretdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtretNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DDIssueno As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DGReturnedDetail As System.Windows.Forms.DataGridView
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents txtLotno As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
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
    Friend WithEvents DDBinNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblbinno As System.Windows.Forms.Label
    Friend WithEvents ItemDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lotno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tagno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Issuedqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Receivedqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Retqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RetQtyEnter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblissuemasterid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblitemfinishedid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblunitid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblflagsize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblissuemasterdetailid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
