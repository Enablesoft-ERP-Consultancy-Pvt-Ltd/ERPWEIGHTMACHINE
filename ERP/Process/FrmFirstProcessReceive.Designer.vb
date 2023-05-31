<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFirstProcessReceive
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.TxtStockNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtItemName = New System.Windows.Forms.TextBox()
        Me.TxtQuality = New System.Windows.Forms.TextBox()
        Me.TxtDesign = New System.Windows.Forms.TextBox()
        Me.TxtSize = New System.Windows.Forms.TextBox()
        Me.TxtShape = New System.Windows.Forms.TextBox()
        Me.TxtColor = New System.Windows.Forms.TextBox()
        Me.TxtPcsType = New System.Windows.Forms.TextBox()
        Me.TxtWidth = New System.Windows.Forms.TextBox()
        Me.TxtLength = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtConsumption = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtArea = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtActualLength = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtActualWidth = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtPenalityRemark = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtPenalityAmt = New System.Windows.Forms.TextBox()
        Me.DDQAName = New System.Windows.Forms.ComboBox()
        Me.LblGateInNo = New System.Windows.Forms.Label()
        Me.DDStockQuality = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtFolioNo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtReceiveNo = New System.Windows.Forms.TextBox()
        Me.txtdate = New System.Windows.Forms.DateTimePicker()
        Me.TxtPartyChallanNo = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtComm = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnpreview = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.SrNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TStockNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActualWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActualLength = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Weight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Penality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IssueOrderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process_Rec_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process_Rec_Detail_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnShowData = New System.Windows.Forms.Button()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(331, 127)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(47, 13)
        Me.Label26.TabIndex = 50
        Me.Label26.Text = "Weight"
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(322, 142)
        Me.txtWeight.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.ReadOnly = True
        Me.txtWeight.Size = New System.Drawing.Size(100, 20)
        Me.txtWeight.TabIndex = 8
        '
        'TxtStockNo
        '
        Me.TxtStockNo.Location = New System.Drawing.Point(426, 99)
        Me.TxtStockNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtStockNo.Name = "TxtStockNo"
        Me.TxtStockNo.Size = New System.Drawing.Size(100, 20)
        Me.TxtStockNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(429, 84)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "StockNo"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(0, 455)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 13)
        Me.Label31.TabIndex = 83
        Me.Label31.Text = "Port Name"
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(72, 452)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(260, 21)
        Me.cmb_port.TabIndex = 84
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Item Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(742, 45)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Size"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(632, 45)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Shape"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(498, 45)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Color"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(172, 45)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Quality"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(341, 45)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "Design"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(837, 45)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Pcs Type"
        '
        'TxtItemName
        '
        Me.TxtItemName.Location = New System.Drawing.Point(10, 60)
        Me.TxtItemName.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtItemName.Name = "TxtItemName"
        Me.TxtItemName.ReadOnly = True
        Me.TxtItemName.Size = New System.Drawing.Size(150, 20)
        Me.TxtItemName.TabIndex = 96
        '
        'TxtQuality
        '
        Me.TxtQuality.Location = New System.Drawing.Point(164, 60)
        Me.TxtQuality.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtQuality.Name = "TxtQuality"
        Me.TxtQuality.ReadOnly = True
        Me.TxtQuality.Size = New System.Drawing.Size(150, 20)
        Me.TxtQuality.TabIndex = 97
        '
        'TxtDesign
        '
        Me.TxtDesign.Location = New System.Drawing.Point(318, 60)
        Me.TxtDesign.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtDesign.Name = "TxtDesign"
        Me.TxtDesign.ReadOnly = True
        Me.TxtDesign.Size = New System.Drawing.Size(150, 20)
        Me.TxtDesign.TabIndex = 98
        '
        'TxtSize
        '
        Me.TxtSize.Location = New System.Drawing.Point(730, 60)
        Me.TxtSize.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.ReadOnly = True
        Me.TxtSize.Size = New System.Drawing.Size(100, 20)
        Me.TxtSize.TabIndex = 101
        '
        'TxtShape
        '
        Me.TxtShape.Location = New System.Drawing.Point(626, 60)
        Me.TxtShape.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtShape.Name = "TxtShape"
        Me.TxtShape.ReadOnly = True
        Me.TxtShape.Size = New System.Drawing.Size(100, 20)
        Me.TxtShape.TabIndex = 100
        '
        'TxtColor
        '
        Me.TxtColor.Location = New System.Drawing.Point(472, 60)
        Me.TxtColor.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtColor.Name = "TxtColor"
        Me.TxtColor.ReadOnly = True
        Me.TxtColor.Size = New System.Drawing.Size(150, 20)
        Me.TxtColor.TabIndex = 99
        '
        'TxtPcsType
        '
        Me.TxtPcsType.Location = New System.Drawing.Point(834, 60)
        Me.TxtPcsType.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtPcsType.Name = "TxtPcsType"
        Me.TxtPcsType.ReadOnly = True
        Me.TxtPcsType.Size = New System.Drawing.Size(100, 20)
        Me.TxtPcsType.TabIndex = 102
        '
        'TxtWidth
        '
        Me.TxtWidth.Location = New System.Drawing.Point(938, 60)
        Me.TxtWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtWidth.Name = "TxtWidth"
        Me.TxtWidth.ReadOnly = True
        Me.TxtWidth.Size = New System.Drawing.Size(100, 20)
        Me.TxtWidth.TabIndex = 104
        '
        'TxtLength
        '
        Me.TxtLength.Location = New System.Drawing.Point(10, 99)
        Me.TxtLength.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtLength.Name = "TxtLength"
        Me.TxtLength.ReadOnly = True
        Me.TxtLength.Size = New System.Drawing.Size(100, 20)
        Me.TxtLength.TabIndex = 106
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 84)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Length"
        '
        'TxtConsumption
        '
        Me.TxtConsumption.Location = New System.Drawing.Point(218, 99)
        Me.TxtConsumption.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtConsumption.Name = "TxtConsumption"
        Me.TxtConsumption.ReadOnly = True
        Me.TxtConsumption.Size = New System.Drawing.Size(100, 20)
        Me.TxtConsumption.TabIndex = 110
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(223, 84)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 109
        Me.Label11.Text = "Consumption"
        '
        'TxtArea
        '
        Me.TxtArea.Location = New System.Drawing.Point(114, 99)
        Me.TxtArea.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtArea.Name = "TxtArea"
        Me.TxtArea.ReadOnly = True
        Me.TxtArea.Size = New System.Drawing.Size(100, 20)
        Me.TxtArea.TabIndex = 108
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(128, 84)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 107
        Me.Label12.Text = "Area"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(952, 45)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 111
        Me.Label9.Text = "Width"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(533, 84)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "Actual Width"
        '
        'TxtActualLength
        '
        Me.TxtActualLength.Location = New System.Drawing.Point(634, 99)
        Me.TxtActualLength.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtActualLength.Name = "TxtActualLength"
        Me.TxtActualLength.Size = New System.Drawing.Size(100, 20)
        Me.TxtActualLength.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(637, 84)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 13)
        Me.Label14.TabIndex = 113
        Me.Label14.Text = "Actual Length"
        '
        'TxtActualWidth
        '
        Me.TxtActualWidth.Location = New System.Drawing.Point(530, 99)
        Me.TxtActualWidth.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtActualWidth.Name = "TxtActualWidth"
        Me.TxtActualWidth.Size = New System.Drawing.Size(100, 20)
        Me.TxtActualWidth.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(741, 84)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 13)
        Me.Label15.TabIndex = 119
        Me.Label15.Text = "Penality Amt"
        '
        'TxtPenalityRemark
        '
        Me.TxtPenalityRemark.Location = New System.Drawing.Point(842, 99)
        Me.TxtPenalityRemark.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtPenalityRemark.Name = "TxtPenalityRemark"
        Me.TxtPenalityRemark.Size = New System.Drawing.Size(212, 20)
        Me.TxtPenalityRemark.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(856, 84)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 13)
        Me.Label17.TabIndex = 117
        Me.Label17.Text = "Penality Remark"
        '
        'TxtPenalityAmt
        '
        Me.TxtPenalityAmt.Location = New System.Drawing.Point(738, 99)
        Me.TxtPenalityAmt.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtPenalityAmt.Name = "TxtPenalityAmt"
        Me.TxtPenalityAmt.Size = New System.Drawing.Size(100, 20)
        Me.TxtPenalityAmt.TabIndex = 4
        '
        'DDQAName
        '
        Me.DDQAName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDQAName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDQAName.FormattingEnabled = True
        Me.DDQAName.Location = New System.Drawing.Point(164, 141)
        Me.DDQAName.Margin = New System.Windows.Forms.Padding(2)
        Me.DDQAName.Name = "DDQAName"
        Me.DDQAName.Size = New System.Drawing.Size(154, 21)
        Me.DDQAName.TabIndex = 7
        '
        'LblGateInNo
        '
        Me.LblGateInNo.AutoSize = True
        Me.LblGateInNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGateInNo.ForeColor = System.Drawing.Color.Black
        Me.LblGateInNo.Location = New System.Drawing.Point(167, 124)
        Me.LblGateInNo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblGateInNo.Name = "LblGateInNo"
        Me.LblGateInNo.Size = New System.Drawing.Size(60, 13)
        Me.LblGateInNo.TabIndex = 123
        Me.LblGateInNo.Text = "QA Name"
        '
        'DDStockQuality
        '
        Me.DDStockQuality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDStockQuality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDStockQuality.FormattingEnabled = True
        Me.DDStockQuality.Location = New System.Drawing.Point(10, 141)
        Me.DDStockQuality.Margin = New System.Windows.Forms.Padding(2)
        Me.DDStockQuality.Name = "DDStockQuality"
        Me.DDStockQuality.Size = New System.Drawing.Size(150, 21)
        Me.DDStockQuality.TabIndex = 6
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(13, 125)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(76, 13)
        Me.Label23.TabIndex = 122
        Me.Label23.Text = "Reject/Hold"
        '
        'TxtFolioNo
        '
        Me.TxtFolioNo.Location = New System.Drawing.Point(372, 20)
        Me.TxtFolioNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtFolioNo.Name = "TxtFolioNo"
        Me.TxtFolioNo.ReadOnly = True
        Me.TxtFolioNo.Size = New System.Drawing.Size(150, 20)
        Me.TxtFolioNo.TabIndex = 125
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(386, 5)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 124
        Me.Label18.Text = "Folio No"
        '
        'TxtEmployeeName
        '
        Me.TxtEmployeeName.Location = New System.Drawing.Point(526, 20)
        Me.TxtEmployeeName.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtEmployeeName.Name = "TxtEmployeeName"
        Me.TxtEmployeeName.ReadOnly = True
        Me.TxtEmployeeName.Size = New System.Drawing.Size(528, 20)
        Me.TxtEmployeeName.TabIndex = 127
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(540, 5)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(97, 13)
        Me.Label19.TabIndex = 126
        Me.Label19.Text = "Employee Name"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(119, 5)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 13)
        Me.Label21.TabIndex = 135
        Me.Label21.Text = "Receive No"
        '
        'TxtReceiveNo
        '
        Me.TxtReceiveNo.Location = New System.Drawing.Point(114, 20)
        Me.TxtReceiveNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtReceiveNo.Name = "TxtReceiveNo"
        Me.TxtReceiveNo.Size = New System.Drawing.Size(125, 20)
        Me.TxtReceiveNo.TabIndex = 134
        '
        'txtdate
        '
        Me.txtdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtdate.Location = New System.Drawing.Point(10, 20)
        Me.txtdate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtdate.Name = "txtdate"
        Me.txtdate.Size = New System.Drawing.Size(100, 20)
        Me.txtdate.TabIndex = 133
        '
        'TxtPartyChallanNo
        '
        Me.TxtPartyChallanNo.Location = New System.Drawing.Point(243, 20)
        Me.TxtPartyChallanNo.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtPartyChallanNo.Name = "TxtPartyChallanNo"
        Me.TxtPartyChallanNo.Size = New System.Drawing.Size(125, 20)
        Me.TxtPartyChallanNo.TabIndex = 130
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(253, 5)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(102, 13)
        Me.Label22.TabIndex = 131
        Me.Label22.Text = "Party Challan No"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(19, 5)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 13)
        Me.Label24.TabIndex = 132
        Me.Label24.Text = "Rec Date"
        '
        'TxtComm
        '
        Me.TxtComm.Location = New System.Drawing.Point(322, 99)
        Me.TxtComm.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtComm.Name = "TxtComm"
        Me.TxtComm.ReadOnly = True
        Me.TxtComm.Size = New System.Drawing.Size(100, 20)
        Me.TxtComm.TabIndex = 137
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(327, 84)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 136
        Me.Label20.Text = "Comm"
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(998, 141)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(56, 19)
        Me.btnclose.TabIndex = 13
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnpreview
        '
        Me.btnpreview.Location = New System.Drawing.Point(937, 141)
        Me.btnpreview.Margin = New System.Windows.Forms.Padding(2)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(56, 19)
        Me.btnpreview.TabIndex = 10
        Me.btnpreview.Text = "Preview"
        Me.btnpreview.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(876, 141)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(56, 19)
        Me.btnsave.TabIndex = 9
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnnew
        '
        Me.btnnew.Location = New System.Drawing.Point(816, 141)
        Me.btnnew.Margin = New System.Windows.Forms.Padding(2)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(56, 19)
        Me.btnnew.TabIndex = 12
        Me.btnnew.Text = "New"
        Me.btnnew.UseVisualStyleBackColor = True
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SrNo, Me.TStockNo, Me.Description, Me.ActualWidth, Me.ActualLength, Me.Area, Me.Weight, Me.Comm, Me.Rate, Me.Qty, Me.Penality, Me.IssueOrderID, Me.Process_Rec_ID, Me.Process_Rec_Detail_ID})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG.DefaultCellStyle = DataGridViewCellStyle1
        Me.DG.Location = New System.Drawing.Point(10, 166)
        Me.DG.Margin = New System.Windows.Forms.Padding(2)
        Me.DG.Name = "DG"
        Me.DG.RowTemplate.Height = 24
        Me.DG.Size = New System.Drawing.Size(1044, 281)
        Me.DG.TabIndex = 142
        '
        'SrNo
        '
        Me.SrNo.HeaderText = "SrNo"
        Me.SrNo.Name = "SrNo"
        '
        'TStockNo
        '
        Me.TStockNo.HeaderText = "StockNo"
        Me.TStockNo.Name = "TStockNo"
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 300
        '
        'ActualWidth
        '
        Me.ActualWidth.HeaderText = "ActualWidth"
        Me.ActualWidth.Name = "ActualWidth"
        '
        'ActualLength
        '
        Me.ActualLength.HeaderText = "ActualLength"
        Me.ActualLength.Name = "ActualLength"
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
        'Comm
        '
        Me.Comm.HeaderText = "Comm"
        Me.Comm.Name = "Comm"
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
        'Penality
        '
        Me.Penality.HeaderText = "Penality"
        Me.Penality.Name = "Penality"
        '
        'IssueOrderID
        '
        Me.IssueOrderID.HeaderText = "IssueOrderID"
        Me.IssueOrderID.Name = "IssueOrderID"
        Me.IssueOrderID.Visible = False
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
        'BtnShowData
        '
        Me.BtnShowData.Location = New System.Drawing.Point(744, 141)
        Me.BtnShowData.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnShowData.Name = "BtnShowData"
        Me.BtnShowData.Size = New System.Drawing.Size(68, 19)
        Me.BtnShowData.TabIndex = 11
        Me.BtnShowData.Text = "Show Data"
        Me.BtnShowData.UseVisualStyleBackColor = True
        '
        'FrmFirstProcessReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1059, 475)
        Me.Controls.Add(Me.BtnShowData)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btnpreview)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btnnew)
        Me.Controls.Add(Me.TxtComm)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TxtReceiveNo)
        Me.Controls.Add(Me.txtdate)
        Me.Controls.Add(Me.TxtPartyChallanNo)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.TxtEmployeeName)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TxtFolioNo)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.DDQAName)
        Me.Controls.Add(Me.LblGateInNo)
        Me.Controls.Add(Me.DDStockQuality)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TxtPenalityRemark)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtPenalityAmt)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtActualLength)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtActualWidth)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtConsumption)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtArea)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtLength)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtWidth)
        Me.Controls.Add(Me.TxtPcsType)
        Me.Controls.Add(Me.TxtSize)
        Me.Controls.Add(Me.TxtShape)
        Me.Controls.Add(Me.TxtColor)
        Me.Controls.Add(Me.TxtDesign)
        Me.Controls.Add(Me.TxtQuality)
        Me.Controls.Add(Me.TxtItemName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TxtStockNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtWeight)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label16)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmFirstProcessReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "First Process Receive"
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label

    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents TxtStockNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtItemName As System.Windows.Forms.TextBox
    Friend WithEvents TxtQuality As System.Windows.Forms.TextBox
    Friend WithEvents TxtDesign As System.Windows.Forms.TextBox
    Friend WithEvents TxtSize As System.Windows.Forms.TextBox
    Friend WithEvents TxtShape As System.Windows.Forms.TextBox
    Friend WithEvents TxtColor As System.Windows.Forms.TextBox
    Friend WithEvents TxtPcsType As System.Windows.Forms.TextBox
    Friend WithEvents TxtWidth As System.Windows.Forms.TextBox
    Friend WithEvents TxtLength As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtConsumption As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtArea As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtActualLength As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtActualWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtPenalityRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtPenalityAmt As System.Windows.Forms.TextBox
    Friend WithEvents DDQAName As System.Windows.Forms.ComboBox
    Friend WithEvents LblGateInNo As System.Windows.Forms.Label
    Friend WithEvents DDStockQuality As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtFolioNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtReceiveNo As System.Windows.Forms.TextBox
    Friend WithEvents txtdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtPartyChallanNo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxtComm As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents BtnShowData As System.Windows.Forms.Button
    Friend WithEvents SrNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TStockNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActualWidth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActualLength As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Weight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Penality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IssueOrderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Process_Rec_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Process_Rec_Detail_ID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
