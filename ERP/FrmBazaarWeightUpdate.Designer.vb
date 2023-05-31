<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBazaarWeightUpdate
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnShowData = New System.Windows.Forms.Button()
        Me.TxtReceiveDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DDCompanyName = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Lblprmid = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.Chkboxitem = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ReceiveChallanNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceiveDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QualityName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalRecQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtTotalWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtChkPcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtChkWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDryWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROCESS_REC_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QualityId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Grpweight = New System.Windows.Forms.GroupBox()
        Me.lblgridindex = New System.Windows.Forms.Label()
        Me.btnweight = New System.Windows.Forms.Button()
        Me.txtweight = New System.Windows.Forms.TextBox()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grpweight.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnShowData)
        Me.GroupBox1.Controls.Add(Me.TxtReceiveDate)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.DDCompanyName)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(9, -4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 51)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'BtnShowData
        '
        Me.BtnShowData.Location = New System.Drawing.Point(300, 27)
        Me.BtnShowData.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnShowData.Name = "BtnShowData"
        Me.BtnShowData.Size = New System.Drawing.Size(82, 20)
        Me.BtnShowData.TabIndex = 54
        Me.BtnShowData.Text = "Show Data"
        Me.BtnShowData.UseVisualStyleBackColor = True
        '
        'TxtReceiveDate
        '
        Me.TxtReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtReceiveDate.Location = New System.Drawing.Point(185, 27)
        Me.TxtReceiveDate.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtReceiveDate.Name = "TxtReceiveDate"
        Me.TxtReceiveDate.Size = New System.Drawing.Size(109, 20)
        Me.TxtReceiveDate.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(188, 10)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Issue Date"
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
        Me.GroupBox3.Controls.Add(Me.DG)
        Me.GroupBox3.Location = New System.Drawing.Point(1, 50)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1015, 275)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chkboxitem, Me.ReceiveChallanNo, Me.EmpName, Me.ReceiveDate, Me.QualityName, Me.TotalRecQty, Me.TxtTotalWeight, Me.txtChkPcs, Me.txtChkWeight, Me.txtDryWeight, Me.PROCESS_REC_ID, Me.QualityId})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.DefaultCellStyle = DataGridViewCellStyle5
        Me.DG.Location = New System.Drawing.Point(4, 12)
        Me.DG.Name = "DG"
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DG.Size = New System.Drawing.Size(1005, 259)
        Me.DG.TabIndex = 1
        '
        'Chkboxitem
        '
        Me.Chkboxitem.HeaderText = ""
        Me.Chkboxitem.Name = "Chkboxitem"
        Me.Chkboxitem.Width = 5
        '
        'ReceiveChallanNo
        '
        Me.ReceiveChallanNo.HeaderText = "Challan No"
        Me.ReceiveChallanNo.Name = "ReceiveChallanNo"
        Me.ReceiveChallanNo.Width = 84
        '
        'EmpName
        '
        Me.EmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.EmpName.HeaderText = "Emp Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        Me.EmpName.Width = 150
        '
        'ReceiveDate
        '
        Me.ReceiveDate.HeaderText = "Receive Date"
        Me.ReceiveDate.Name = "ReceiveDate"
        Me.ReceiveDate.ReadOnly = True
        Me.ReceiveDate.Width = 98
        '
        'QualityName
        '
        Me.QualityName.HeaderText = "Quality Name"
        Me.QualityName.Name = "QualityName"
        Me.QualityName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QualityName.Width = 95
        '
        'TotalRecQty
        '
        Me.TotalRecQty.HeaderText = "Total Qty"
        Me.TotalRecQty.Name = "TotalRecQty"
        Me.TotalRecQty.ReadOnly = True
        Me.TotalRecQty.Width = 75
        '
        'TxtTotalWeight
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow
        Me.TxtTotalWeight.DefaultCellStyle = DataGridViewCellStyle1
        Me.TxtTotalWeight.HeaderText = "Total Wt"
        Me.TxtTotalWeight.Name = "TxtTotalWeight"
        Me.TxtTotalWeight.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TxtTotalWeight.Width = 73
        '
        'txtChkPcs
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtChkPcs.DefaultCellStyle = DataGridViewCellStyle2
        Me.txtChkPcs.HeaderText = "Chk Pcs"
        Me.txtChkPcs.Name = "txtChkPcs"
        Me.txtChkPcs.Width = 72
        '
        'txtChkWeight
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow
        Me.txtChkWeight.DefaultCellStyle = DataGridViewCellStyle3
        Me.txtChkWeight.HeaderText = "Chk Wt"
        Me.txtChkWeight.Name = "txtChkWeight"
        Me.txtChkWeight.Width = 68
        '
        'txtDryWeight
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Yellow
        Me.txtDryWeight.DefaultCellStyle = DataGridViewCellStyle4
        Me.txtDryWeight.HeaderText = "Dry Wt"
        Me.txtDryWeight.Name = "txtDryWeight"
        Me.txtDryWeight.Width = 65
        '
        'PROCESS_REC_ID
        '
        Me.PROCESS_REC_ID.HeaderText = "PROCESS_REC_ID"
        Me.PROCESS_REC_ID.Name = "PROCESS_REC_ID"
        Me.PROCESS_REC_ID.Visible = False
        Me.PROCESS_REC_ID.Width = 128
        '
        'QualityId
        '
        Me.QualityId.HeaderText = "QualityId"
        Me.QualityId.Name = "QualityId"
        Me.QualityId.Visible = False
        Me.QualityId.Width = 73
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(732, 331)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(75, 23)
        Me.BtnNew.TabIndex = 7
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(873, 331)
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
        Me.Label2.Location = New System.Drawing.Point(342, 336)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Port Name"
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(414, 333)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(121, 21)
        Me.cmb_port.TabIndex = 47
        '
        'Grpweight
        '
        Me.Grpweight.Controls.Add(Me.lblgridindex)
        Me.Grpweight.Controls.Add(Me.btnweight)
        Me.Grpweight.Controls.Add(Me.txtweight)
        Me.Grpweight.Location = New System.Drawing.Point(652, -4)
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
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(812, 331)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(56, 23)
        Me.btnsave.TabIndex = 55
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'FrmBazaarWeightUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1023, 364)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.Lblprmid)
        Me.Controls.Add(Me.Grpweight)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmBazaarWeightUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bazar Weight Update"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grpweight.ResumeLayout(False)
        Me.Grpweight.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents Lblprmid As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Grpweight As System.Windows.Forms.GroupBox
    Friend WithEvents btnweight As System.Windows.Forms.Button
    Friend WithEvents txtweight As System.Windows.Forms.TextBox
    Friend WithEvents lblgridindex As System.Windows.Forms.Label
    Friend WithEvents DDCompanyName As System.Windows.Forms.ComboBox

    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents TxtReceiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnShowData As System.Windows.Forms.Button
    Friend WithEvents Chkboxitem As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ReceiveChallanNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QualityName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalRecQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtTotalWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtChkPcs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtChkWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDryWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESS_REC_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QualityId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnsave As System.Windows.Forms.Button
End Class
