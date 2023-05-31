<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRawMaterialIssue
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtfolioNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkforCone = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lblprmid = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DGOrderdetail = New System.Windows.Forms.DataGridView()
        Me.Article = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Userid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comanyid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Length = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Width = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Orderid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemFinishedId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DGConsumption = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DGConsumptionConeType = New System.Windows.Forms.DataGridView()
        Me.Itemname1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinishedId1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Godown1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Description1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Consmpqty1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.issuedqty1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pendqty1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lotno1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Stockqty1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contype = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.noofcones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Issueqty1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Save1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnPreview = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Grpweight = New System.Windows.Forms.GroupBox()
        Me.lblgridindex = New System.Windows.Forms.Label()
        Me.btnweight = New System.Windows.Forms.Button()
        Me.txtweight = New System.Windows.Forms.TextBox()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Itemid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Godown = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConsmpQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Issuedqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PendQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lotno = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.stockqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.issueqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.save = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GetWt = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGOrderdetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGConsumption, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DGConsumptionConeType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grpweight.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtfolioNo
        '
        Me.txtfolioNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfolioNo.Location = New System.Drawing.Point(86, 26)
        Me.txtfolioNo.Name = "txtfolioNo"
        Me.txtfolioNo.Size = New System.Drawing.Size(100, 20)
        Me.txtfolioNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Folio No"
        '
        'chkforCone
        '
        Me.chkforCone.AutoSize = True
        Me.chkforCone.ForeColor = System.Drawing.Color.Red
        Me.chkforCone.Location = New System.Drawing.Point(237, 29)
        Me.chkforCone.Name = "chkforCone"
        Me.chkforCone.Size = New System.Drawing.Size(131, 17)
        Me.chkforCone.TabIndex = 2
        Me.chkforCone.Text = "Check For Cone Issue"
        Me.chkforCone.UseVisualStyleBackColor = True
        Me.chkforCone.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lblprmid)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkforCone)
        Me.GroupBox1.Controls.Add(Me.txtfolioNo)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(475, 48)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Lblprmid
        '
        Me.Lblprmid.AutoSize = True
        Me.Lblprmid.Location = New System.Drawing.Point(537, 29)
        Me.Lblprmid.Name = "Lblprmid"
        Me.Lblprmid.Size = New System.Drawing.Size(0, 13)
        Me.Lblprmid.TabIndex = 3
        Me.Lblprmid.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DGOrderdetail)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(472, 75)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'DGOrderdetail
        '
        Me.DGOrderdetail.AllowUserToAddRows = False
        Me.DGOrderdetail.AllowUserToDeleteRows = False
        Me.DGOrderdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGOrderdetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Article, Me.Userid, Me.Comanyid, Me.Length, Me.Width, Me.Rate, Me.Area, Me.Amount, Me.Orderid, Me.ItemFinishedId, Me.UnitId, Me.Color, Me.size, Me.Qty})
        Me.DGOrderdetail.Location = New System.Drawing.Point(9, 12)
        Me.DGOrderdetail.Name = "DGOrderdetail"
        Me.DGOrderdetail.Size = New System.Drawing.Size(446, 57)
        Me.DGOrderdetail.TabIndex = 0
        '
        'Article
        '
        Me.Article.HeaderText = "ARTICLES"
        Me.Article.Name = "Article"
        Me.Article.ReadOnly = True
        '
        'Userid
        '
        Me.Userid.HeaderText = "Userid"
        Me.Userid.Name = "Userid"
        Me.Userid.Visible = False
        '
        'Comanyid
        '
        Me.Comanyid.HeaderText = "Comanyid"
        Me.Comanyid.Name = "Comanyid"
        Me.Comanyid.Visible = False
        '
        'Length
        '
        Me.Length.HeaderText = "Length"
        Me.Length.Name = "Length"
        Me.Length.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Length.Visible = False
        '
        'Width
        '
        Me.Width.HeaderText = "Width"
        Me.Width.Name = "Width"
        Me.Width.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Width.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Width.Visible = False
        '
        'Rate
        '
        Me.Rate.HeaderText = "Rate"
        Me.Rate.Name = "Rate"
        Me.Rate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Rate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Rate.Visible = False
        '
        'Area
        '
        Me.Area.HeaderText = "Area"
        Me.Area.Name = "Area"
        Me.Area.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Area.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Area.Visible = False
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Amount.Visible = False
        '
        'Orderid
        '
        Me.Orderid.HeaderText = "Orderid"
        Me.Orderid.Name = "Orderid"
        Me.Orderid.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Orderid.Visible = False
        '
        'ItemFinishedId
        '
        Me.ItemFinishedId.HeaderText = "ItemFinishedId"
        Me.ItemFinishedId.Name = "ItemFinishedId"
        Me.ItemFinishedId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ItemFinishedId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ItemFinishedId.Visible = False
        '
        'UnitId
        '
        Me.UnitId.HeaderText = "Unit Name"
        Me.UnitId.Name = "UnitId"
        Me.UnitId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UnitId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UnitId.Visible = False
        '
        'Color
        '
        Me.Color.HeaderText = "COLOR"
        Me.Color.Name = "Color"
        Me.Color.ReadOnly = True
        '
        'size
        '
        Me.size.HeaderText = "SIZE"
        Me.size.Name = "size"
        Me.size.ReadOnly = True
        '
        'Qty
        '
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DGConsumption)
        Me.GroupBox3.Location = New System.Drawing.Point(1, 136)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(970, 273)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'DGConsumption
        '
        Me.DGConsumption.AllowUserToAddRows = False
        Me.DGConsumption.AllowUserToDeleteRows = False
        Me.DGConsumption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGConsumption.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemName, Me.Itemid, Me.Godown, Me.Description, Me.ConsmpQty, Me.Issuedqty, Me.PendQty, Me.lotno, Me.stockqty, Me.issueqty, Me.Remarks, Me.save, Me.GetWt})
        Me.DGConsumption.Location = New System.Drawing.Point(9, 15)
        Me.DGConsumption.Name = "DGConsumption"
        Me.DGConsumption.Size = New System.Drawing.Size(955, 259)
        Me.DGConsumption.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DGConsumptionConeType)
        Me.GroupBox4.Location = New System.Drawing.Point(1, 421)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(970, 132)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'DGConsumptionConeType
        '
        Me.DGConsumptionConeType.AllowUserToAddRows = False
        Me.DGConsumptionConeType.AllowUserToDeleteRows = False
        Me.DGConsumptionConeType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGConsumptionConeType.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Itemname1, Me.FinishedId1, Me.Godown1, Me.Description1, Me.Consmpqty1, Me.issuedqty1, Me.Pendqty1, Me.lotno1, Me.Stockqty1, Me.contype, Me.noofcones, Me.Issueqty1, Me.Remarks1, Me.Save1})
        Me.DGConsumptionConeType.Location = New System.Drawing.Point(6, 8)
        Me.DGConsumptionConeType.Name = "DGConsumptionConeType"
        Me.DGConsumptionConeType.Size = New System.Drawing.Size(964, 119)
        Me.DGConsumptionConeType.TabIndex = 0
        '
        'Itemname1
        '
        Me.Itemname1.HeaderText = "Item Name"
        Me.Itemname1.Name = "Itemname1"
        Me.Itemname1.ReadOnly = True
        '
        'FinishedId1
        '
        Me.FinishedId1.HeaderText = "FinishedId"
        Me.FinishedId1.Name = "FinishedId1"
        Me.FinishedId1.Visible = False
        '
        'Godown1
        '
        Me.Godown1.HeaderText = "Godown"
        Me.Godown1.Name = "Godown1"
        Me.Godown1.Visible = False
        '
        'Description1
        '
        Me.Description1.HeaderText = "Description"
        Me.Description1.Name = "Description1"
        Me.Description1.ReadOnly = True
        '
        'Consmpqty1
        '
        Me.Consmpqty1.HeaderText = "Consmp Qty"
        Me.Consmpqty1.Name = "Consmpqty1"
        Me.Consmpqty1.ReadOnly = True
        Me.Consmpqty1.Width = 60
        '
        'issuedqty1
        '
        Me.issuedqty1.HeaderText = "Issued Qty"
        Me.issuedqty1.Name = "issuedqty1"
        Me.issuedqty1.ReadOnly = True
        Me.issuedqty1.Width = 60
        '
        'Pendqty1
        '
        Me.Pendqty1.HeaderText = "Pend Qty"
        Me.Pendqty1.Name = "Pendqty1"
        Me.Pendqty1.ReadOnly = True
        Me.Pendqty1.Width = 60
        '
        'lotno1
        '
        Me.lotno1.HeaderText = "LotNo/BatchNo"
        Me.lotno1.Name = "lotno1"
        Me.lotno1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lotno1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.lotno1.Width = 90
        '
        'Stockqty1
        '
        Me.Stockqty1.HeaderText = "Stock Qty"
        Me.Stockqty1.Name = "Stockqty1"
        Me.Stockqty1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Stockqty1.Width = 75
        '
        'contype
        '
        Me.contype.HeaderText = "Cone Type"
        Me.contype.Name = "contype"
        Me.contype.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.contype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.contype.Width = 75
        '
        'noofcones
        '
        Me.noofcones.HeaderText = "No of Cones"
        Me.noofcones.Name = "noofcones"
        Me.noofcones.Width = 60
        '
        'Issueqty1
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.Issueqty1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Issueqty1.HeaderText = "Issue Qty"
        Me.Issueqty1.Name = "Issueqty1"
        Me.Issueqty1.Width = 60
        '
        'Remarks1
        '
        Me.Remarks1.HeaderText = "Remarks"
        Me.Remarks1.Name = "Remarks1"
        Me.Remarks1.ReadOnly = True
        Me.Remarks1.Width = 75
        '
        'Save1
        '
        Me.Save1.HeaderText = "Save"
        Me.Save1.Name = "Save1"
        Me.Save1.Text = "Save"
        Me.Save1.UseColumnTextForButtonValue = True
        Me.Save1.Width = 75
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(733, 558)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(75, 23)
        Me.BtnNew.TabIndex = 7
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnPreview
        '
        Me.BtnPreview.Location = New System.Drawing.Point(814, 559)
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(75, 23)
        Me.BtnPreview.TabIndex = 8
        Me.BtnPreview.Text = "Preview"
        Me.BtnPreview.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(895, 559)
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
        Me.Label2.Location = New System.Drawing.Point(507, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Port Name"
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(579, 23)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 47
        '
        'Grpweight
        '
        Me.Grpweight.Controls.Add(Me.lblgridindex)
        Me.Grpweight.Controls.Add(Me.btnweight)
        Me.Grpweight.Controls.Add(Me.txtweight)
        Me.Grpweight.Location = New System.Drawing.Point(769, 82)
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
        'ItemName
        '
        Me.ItemName.HeaderText = "Item Name"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        '
        'Itemid
        '
        Me.Itemid.HeaderText = "Itemid"
        Me.Itemid.Name = "Itemid"
        Me.Itemid.Visible = False
        '
        'Godown
        '
        Me.Godown.HeaderText = "Godown"
        Me.Godown.Name = "Godown"
        Me.Godown.Visible = False
        '
        'Description
        '
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
        Me.ConsmpQty.Width = 70
        '
        'Issuedqty
        '
        Me.Issuedqty.HeaderText = "Issued Qty"
        Me.Issuedqty.Name = "Issuedqty"
        Me.Issuedqty.ReadOnly = True
        Me.Issuedqty.Width = 60
        '
        'PendQty
        '
        Me.PendQty.HeaderText = "Pend Qty"
        Me.PendQty.Name = "PendQty"
        Me.PendQty.ReadOnly = True
        Me.PendQty.Width = 60
        '
        'lotno
        '
        Me.lotno.HeaderText = "LotNo/BatchNo"
        Me.lotno.Name = "lotno"
        Me.lotno.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lotno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.lotno.Width = 90
        '
        'stockqty
        '
        Me.stockqty.HeaderText = "Stock Qty"
        Me.stockqty.Name = "stockqty"
        Me.stockqty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.stockqty.Width = 75
        '
        'issueqty
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow
        Me.issueqty.DefaultCellStyle = DataGridViewCellStyle1
        Me.issueqty.HeaderText = "Issue Qty"
        Me.issueqty.Name = "issueqty"
        Me.issueqty.ReadOnly = True
        Me.issueqty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.issueqty.Width = 75
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
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
        Me.save.Width = 60
        '
        'GetWt
        '
        Me.GetWt.HeaderText = ""
        Me.GetWt.Name = "GetWt"
        Me.GetWt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GetWt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.GetWt.Text = "Get Wt."
        Me.GetWt.UseColumnTextForLinkValue = True
        Me.GetWt.Width = 70
        '
        'FrmRawMaterialIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 583)
        Me.Controls.Add(Me.Grpweight)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnPreview)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmRawMaterialIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Raw Material Issue"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DGOrderdetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DGConsumption, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DGConsumptionConeType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grpweight.ResumeLayout(False)
        Me.Grpweight.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtfolioNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkforCone As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DGOrderdetail As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DGConsumption As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DGConsumptionConeType As System.Windows.Forms.DataGridView
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnPreview As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents Lblprmid As System.Windows.Forms.Label
    Friend WithEvents Article As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comanyid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Length As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Width As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Orderid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemFinishedId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Itemname1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinishedId1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Godown1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Description1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Consmpqty1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents issuedqty1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pendqty1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lotno1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Stockqty1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents contype As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents noofcones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Issueqty1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Save1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Grpweight As System.Windows.Forms.GroupBox
    Friend WithEvents btnweight As System.Windows.Forms.Button
    Friend WithEvents txtweight As System.Windows.Forms.TextBox
    Friend WithEvents lblgridindex As System.Windows.Forms.Label
    Friend WithEvents ItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Itemid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Godown As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConsmpQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Issuedqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PendQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lotno As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents stockqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents issueqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents save As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents GetWt As System.Windows.Forms.DataGridViewLinkColumn
End Class
