<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRawMaterialReturned
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblprid = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFolioNo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.DGDetail = New System.Windows.Forms.DataGridView()
        Me.Catagory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.userid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IssuedQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceivedQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IssueOrderid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompanyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Godown = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinishedId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReturnQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.save = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblprid)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtFolioNo)
        Me.GroupBox1.Location = New System.Drawing.Point(1, -4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(703, 33)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblprid
        '
        Me.lblprid.AutoSize = True
        Me.lblprid.Location = New System.Drawing.Point(430, 20)
        Me.lblprid.Name = "lblprid"
        Me.lblprid.Size = New System.Drawing.Size(0, 13)
        Me.lblprid.TabIndex = 4
        Me.lblprid.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Enter Folio No"
        '
        'txtFolioNo
        '
        Me.txtFolioNo.Location = New System.Drawing.Point(91, 7)
        Me.txtFolioNo.Name = "txtFolioNo"
        Me.txtFolioNo.Size = New System.Drawing.Size(207, 20)
        Me.txtFolioNo.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnNew)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.btnClose)
        Me.GroupBox2.Controls.Add(Me.DGDetail)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(703, 333)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(539, 307)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 12
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-191, -181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Enter Folio No"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(-111, -181)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 11
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(620, 307)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'DGDetail
        '
        Me.DGDetail.AllowUserToAddRows = False
        Me.DGDetail.AllowUserToDeleteRows = False
        Me.DGDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Catagory, Me.userid, Me.ItemName, Me.Description, Me.IssuedQty, Me.ReceivedQty, Me.IssueOrderid, Me.CompanyId, Me.Godown, Me.CategoryId, Me.FinishedId, Me.UnitId, Me.LotNo, Me.ReturnQty, Me.save})
        Me.DGDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGDetail.Location = New System.Drawing.Point(6, 5)
        Me.DGDetail.Name = "DGDetail"
        Me.DGDetail.Size = New System.Drawing.Size(697, 296)
        Me.DGDetail.TabIndex = 0
        '
        'Catagory
        '
        Me.Catagory.HeaderText = "Catagory"
        Me.Catagory.Name = "Catagory"
        Me.Catagory.Visible = False
        '
        'userid
        '
        Me.userid.HeaderText = "user id"
        Me.userid.Name = "userid"
        Me.userid.Visible = False
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
        Me.Description.Width = 120
        '
        'IssuedQty
        '
        Me.IssuedQty.HeaderText = "Issued Qty"
        Me.IssuedQty.Name = "IssuedQty"
        Me.IssuedQty.ReadOnly = True
        Me.IssuedQty.Width = 85
        '
        'ReceivedQty
        '
        Me.ReceivedQty.HeaderText = "Received Qty"
        Me.ReceivedQty.Name = "ReceivedQty"
        Me.ReceivedQty.ReadOnly = True
        Me.ReceivedQty.Width = 85
        '
        'IssueOrderid
        '
        Me.IssueOrderid.HeaderText = "IssueOrderid"
        Me.IssueOrderid.Name = "IssueOrderid"
        Me.IssueOrderid.Visible = False
        '
        'CompanyId
        '
        Me.CompanyId.HeaderText = "CompanyId"
        Me.CompanyId.Name = "CompanyId"
        Me.CompanyId.Visible = False
        '
        'Godown
        '
        Me.Godown.HeaderText = "Godown"
        Me.Godown.Name = "Godown"
        Me.Godown.Visible = False
        '
        'CategoryId
        '
        Me.CategoryId.HeaderText = "CategoryId"
        Me.CategoryId.Name = "CategoryId"
        Me.CategoryId.Visible = False
        '
        'FinishedId
        '
        Me.FinishedId.HeaderText = "FinishedId"
        Me.FinishedId.Name = "FinishedId"
        Me.FinishedId.Visible = False
        '
        'UnitId
        '
        Me.UnitId.HeaderText = "UnitId"
        Me.UnitId.Name = "UnitId"
        Me.UnitId.Visible = False
        '
        'LotNo
        '
        Me.LotNo.HeaderText = "LotNo/BatchNo"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        Me.LotNo.Width = 90
        '
        'ReturnQty
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow
        Me.ReturnQty.DefaultCellStyle = DataGridViewCellStyle1
        Me.ReturnQty.HeaderText = "Return Qty"
        Me.ReturnQty.Name = "ReturnQty"
        Me.ReturnQty.ReadOnly = True
        Me.ReturnQty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReturnQty.Width = 60
        '
        'save
        '
        Me.save.HeaderText = "Save"
        Me.save.Name = "save"
        Me.save.Text = "Save"
        Me.save.Width = 85
        '
        'frmRawMaterialReturned
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 368)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmRawMaterialReturned"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Raw Material Returned"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFolioNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DGDetail As System.Windows.Forms.DataGridView
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblprid As System.Windows.Forms.Label
    Friend WithEvents Catagory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IssuedQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IssueOrderid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompanyId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Godown As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategoryId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinishedId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents save As System.Windows.Forms.DataGridViewButtonColumn
End Class
