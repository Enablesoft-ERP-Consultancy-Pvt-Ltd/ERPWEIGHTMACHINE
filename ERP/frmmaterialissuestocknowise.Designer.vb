<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmaterialissuestocknowise
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtstockno = New System.Windows.Forms.TextBox()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.DDBinNo = New System.Windows.Forms.ComboBox()
        Me.lblbinno = New System.Windows.Forms.Label()
        Me.DDGodown = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblgridindex = New System.Windows.Forms.Label()
        Me.gvdetail = New System.Windows.Forms.DataGridView()
        Me.ItemDescriptionIssued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNoissued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagNoissued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblprmid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblprtid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblprorderid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblprocessid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Itemdescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unitname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lotno = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TagNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Stockqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Consmpqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.issuedqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Balanceqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Issueqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LblIssQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblifinishedid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblissueorderid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbliunitid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblisizeflag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblstockno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvdetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Stock No./Scan"
        '
        'txtstockno
        '
        Me.txtstockno.Location = New System.Drawing.Point(136, 22)
        Me.txtstockno.Margin = New System.Windows.Forms.Padding(2)
        Me.txtstockno.Name = "txtstockno"
        Me.txtstockno.Size = New System.Drawing.Size(182, 20)
        Me.txtstockno.TabIndex = 1
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Itemdescription, Me.Unitname, Me.Lotno, Me.TagNo, Me.Stockqty, Me.Consmpqty, Me.issuedqty, Me.Balanceqty, Me.Issueqty, Me.LblIssQty, Me.lblifinishedid, Me.lblissueorderid, Me.lbliunitid, Me.lblisizeflag, Me.lblstockno})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.DefaultCellStyle = DataGridViewCellStyle2
        Me.DG.Location = New System.Drawing.Point(9, 55)
        Me.DG.Margin = New System.Windows.Forms.Padding(2)
        Me.DG.Name = "DG"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DG.RowTemplate.Height = 24
        Me.DG.Size = New System.Drawing.Size(882, 296)
        Me.DG.TabIndex = 2
        '
        'DDBinNo
        '
        Me.DDBinNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDBinNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDBinNo.FormattingEnabled = True
        Me.DDBinNo.Location = New System.Drawing.Point(488, 22)
        Me.DDBinNo.Margin = New System.Windows.Forms.Padding(2)
        Me.DDBinNo.Name = "DDBinNo"
        Me.DDBinNo.Size = New System.Drawing.Size(164, 21)
        Me.DDBinNo.TabIndex = 12
        Me.DDBinNo.Visible = False
        '
        'lblbinno
        '
        Me.lblbinno.AutoSize = True
        Me.lblbinno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbinno.Location = New System.Drawing.Point(486, 6)
        Me.lblbinno.Name = "lblbinno"
        Me.lblbinno.Size = New System.Drawing.Size(49, 13)
        Me.lblbinno.TabIndex = 13
        Me.lblbinno.Text = "Bin No."
        Me.lblbinno.Visible = False
        '
        'DDGodown
        '
        Me.DDGodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDGodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDGodown.FormattingEnabled = True
        Me.DDGodown.Location = New System.Drawing.Point(321, 22)
        Me.DDGodown.Margin = New System.Windows.Forms.Padding(2)
        Me.DDGodown.Name = "DDGodown"
        Me.DDGodown.Size = New System.Drawing.Size(164, 21)
        Me.DDGodown.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(319, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Godown "
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(716, 598)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(644, 600)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Port Name"
        '
        'lblgridindex
        '
        Me.lblgridindex.AutoSize = True
        Me.lblgridindex.Location = New System.Drawing.Point(842, 600)
        Me.lblgridindex.Name = "lblgridindex"
        Me.lblgridindex.Size = New System.Drawing.Size(52, 13)
        Me.lblgridindex.TabIndex = 51
        Me.lblgridindex.Text = "GridIndex"
        Me.lblgridindex.Visible = False
        '
        'gvdetail
        '
        Me.gvdetail.AllowUserToAddRows = False
        Me.gvdetail.AllowUserToDeleteRows = False
        Me.gvdetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gvdetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gvdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvdetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemDescriptionIssued, Me.LotNoissued, Me.TagNoissued, Me.Qty, Me.lblprmid, Me.lblprtid, Me.lblprorderid, Me.lblprocessid})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvdetail.DefaultCellStyle = DataGridViewCellStyle4
        Me.gvdetail.Location = New System.Drawing.Point(9, 378)
        Me.gvdetail.Margin = New System.Windows.Forms.Padding(2)
        Me.gvdetail.Name = "gvdetail"
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvdetail.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gvdetail.RowTemplate.Height = 24
        Me.gvdetail.Size = New System.Drawing.Size(688, 217)
        Me.gvdetail.TabIndex = 52
        '
        'ItemDescriptionIssued
        '
        Me.ItemDescriptionIssued.HeaderText = "Item Description"
        Me.ItemDescriptionIssued.Name = "ItemDescriptionIssued"
        Me.ItemDescriptionIssued.ReadOnly = True
        Me.ItemDescriptionIssued.Width = 99
        '
        'LotNoissued
        '
        Me.LotNoissued.HeaderText = "Lot No"
        Me.LotNoissued.Name = "LotNoissued"
        Me.LotNoissued.ReadOnly = True
        Me.LotNoissued.Width = 47
        '
        'TagNoissued
        '
        Me.TagNoissued.HeaderText = "Tag No"
        Me.TagNoissued.Name = "TagNoissued"
        Me.TagNoissued.ReadOnly = True
        Me.TagNoissued.Width = 51
        '
        'Qty
        '
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 48
        '
        'lblprmid
        '
        Me.lblprmid.HeaderText = "prmid"
        Me.lblprmid.Name = "lblprmid"
        Me.lblprmid.Visible = False
        Me.lblprmid.Width = 68
        '
        'lblprtid
        '
        Me.lblprtid.HeaderText = "prtid"
        Me.lblprtid.Name = "lblprtid"
        Me.lblprtid.Visible = False
        Me.lblprtid.Width = 61
        '
        'lblprorderid
        '
        Me.lblprorderid.HeaderText = "prorderid"
        Me.lblprorderid.Name = "lblprorderid"
        Me.lblprorderid.Visible = False
        Me.lblprorderid.Width = 91
        '
        'lblprocessid
        '
        Me.lblprocessid.HeaderText = "processid"
        Me.lblprocessid.Name = "lblprocessid"
        Me.lblprocessid.Visible = False
        Me.lblprocessid.Width = 94
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Firebrick
        Me.Label4.Location = New System.Drawing.Point(9, 358)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 17)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "** Issued Details"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Firebrick
        Me.Label5.Location = New System.Drawing.Point(6, 599)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(319, 17)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "* Select row and press del to delete record"
        '
        'Itemdescription
        '
        Me.Itemdescription.HeaderText = "Item Description"
        Me.Itemdescription.Name = "Itemdescription"
        Me.Itemdescription.ReadOnly = True
        Me.Itemdescription.Width = 99
        '
        'Unitname
        '
        Me.Unitname.HeaderText = "Unit"
        Me.Unitname.Name = "Unitname"
        Me.Unitname.ReadOnly = True
        Me.Unitname.Width = 51
        '
        'Lotno
        '
        Me.Lotno.HeaderText = "Lot No."
        Me.Lotno.Name = "Lotno"
        Me.Lotno.Width = 43
        '
        'TagNo
        '
        Me.TagNo.HeaderText = "Tag No."
        Me.TagNo.Name = "TagNo"
        Me.TagNo.Width = 32
        '
        'Stockqty
        '
        Me.Stockqty.HeaderText = "Stock Qty"
        Me.Stockqty.Name = "Stockqty"
        Me.Stockqty.ReadOnly = True
        Me.Stockqty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Stockqty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Stockqty.Width = 54
        '
        'Consmpqty
        '
        Me.Consmpqty.HeaderText = "Consmp qty"
        Me.Consmpqty.Name = "Consmpqty"
        Me.Consmpqty.ReadOnly = True
        Me.Consmpqty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Consmpqty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Consmpqty.Width = 61
        '
        'issuedqty
        '
        Me.issuedqty.HeaderText = "Already Issued"
        Me.issuedqty.Name = "issuedqty"
        Me.issuedqty.ReadOnly = True
        Me.issuedqty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.issuedqty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.issuedqty.Width = 74
        '
        'Balanceqty
        '
        Me.Balanceqty.HeaderText = "Balance Qty"
        Me.Balanceqty.Name = "Balanceqty"
        Me.Balanceqty.ReadOnly = True
        Me.Balanceqty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Balanceqty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Balanceqty.Width = 64
        '
        'Issueqty
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Issueqty.DefaultCellStyle = DataGridViewCellStyle1
        Me.Issueqty.HeaderText = "Issue Qty"
        Me.Issueqty.Name = "Issueqty"
        Me.Issueqty.ReadOnly = True
        Me.Issueqty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Issueqty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Issueqty.Width = 51
        '
        'LblIssQty
        '
        Me.LblIssQty.HeaderText = "Iss Save"
        Me.LblIssQty.Name = "LblIssQty"
        Me.LblIssQty.Width = 68
        '
        'lblifinishedid
        '
        Me.lblifinishedid.HeaderText = "lblifinishedid"
        Me.lblifinishedid.Name = "lblifinishedid"
        Me.lblifinishedid.Visible = False
        Me.lblifinishedid.Width = 88
        '
        'lblissueorderid
        '
        Me.lblissueorderid.HeaderText = "lblissueorderid"
        Me.lblissueorderid.Name = "lblissueorderid"
        Me.lblissueorderid.Visible = False
        Me.lblissueorderid.Width = 98
        '
        'lbliunitid
        '
        Me.lbliunitid.HeaderText = "lbliunitid"
        Me.lbliunitid.Name = "lbliunitid"
        Me.lbliunitid.Visible = False
        Me.lbliunitid.Width = 69
        '
        'lblisizeflag
        '
        Me.lblisizeflag.HeaderText = "lblisizeflag"
        Me.lblisizeflag.Name = "lblisizeflag"
        Me.lblisizeflag.Visible = False
        Me.lblisizeflag.Width = 79
        '
        'lblstockno
        '
        Me.lblstockno.HeaderText = "lblstockno"
        Me.lblstockno.Name = "lblstockno"
        Me.lblstockno.Visible = False
        Me.lblstockno.Width = 80
        '
        'frmmaterialissuestocknowise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(895, 609)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gvdetail)
        Me.Controls.Add(Me.lblgridindex)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DDBinNo)
        Me.Controls.Add(Me.lblbinno)
        Me.Controls.Add(Me.DDGodown)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.txtstockno)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmmaterialissuestocknowise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Material Issue Stock No. Wise"
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvdetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtstockno As System.Windows.Forms.TextBox
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents DDBinNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblbinno As System.Windows.Forms.Label
    Friend WithEvents DDGodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblgridindex As System.Windows.Forms.Label
    Friend WithEvents gvdetail As System.Windows.Forms.DataGridView
    Friend WithEvents ItemDescriptionIssued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNoissued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagNoissued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblprmid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblprtid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblprorderid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblprocessid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Itemdescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unitname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lotno As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TagNo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Stockqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Consmpqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents issuedqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balanceqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Issueqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblIssQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblifinishedid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblissueorderid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbliunitid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblisizeflag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblstockno As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
