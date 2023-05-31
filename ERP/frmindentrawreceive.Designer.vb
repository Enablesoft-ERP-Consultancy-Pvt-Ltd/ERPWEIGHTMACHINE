<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmindentrawreceive
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
        Me.ChkEdit = New System.Windows.Forms.CheckBox()
        Me.chkcomplete = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtapprovedby = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtcheckedby = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.ddindent = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblsrno = New System.Windows.Forms.Label()
        Me.ChkForReceiveIssItem = New System.Windows.Forms.CheckBox()
        Me.txtcode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtPartyChallanNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtGateInNo = New System.Windows.Forms.TextBox()
        Me.TxtNoOFHank = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ddPartyChallanNo = New System.Windows.Forms.ComboBox()
        Me.lblpartychallanNo = New System.Windows.Forms.Label()
        Me.ddChallanNo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ddempname = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ddProcessName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ddCompName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtidnt = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkchangeTagno = New System.Windows.Forms.CheckBox()
        Me.txttagNo = New System.Windows.Forms.TextBox()
        Me.lblmanualtagno = New System.Windows.Forms.Label()
        Me.ddbinno = New System.Windows.Forms.ComboBox()
        Me.lblbinno = New System.Windows.Forms.Label()
        Me.DDTagNo = New System.Windows.Forms.ComboBox()
        Me.lblTagNo = New System.Windows.Forms.Label()
        Me.DDLotNo = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ddlunit = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ddgodown = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DDOrderNo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DDRECSHADE = New System.Windows.Forms.ComboBox()
        Me.lblrecshade = New System.Windows.Forms.Label()
        Me.ddlshade = New System.Windows.Forms.ComboBox()
        Me.LblColorShade = New System.Windows.Forms.Label()
        Me.dquality = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dditemname = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ddCatagory = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TxtBellWeight = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TxtMoisture = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.ChkForWithoutRate = New System.Windows.Forms.CheckBox()
        Me.TxtRate = New System.Windows.Forms.TextBox()
        Me.lblrate = New System.Windows.Forms.Label()
        Me.TxtLoss = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtrec = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtPenalty = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtpending = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtprerec = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtIndentQty = New System.Windows.Forms.TextBox()
        Me.lblissuedqty = New System.Windows.Forms.Label()
        Me.TxtIssueQty = New System.Windows.Forms.TextBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnpreview = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.dGORDER = New System.Windows.Forms.DataGridView()
        Me.ITEMDESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BAlQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblcategoryid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblitem_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblQualityid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblColorid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbldesignid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblshapeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblshadecolorid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblsizeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblfinished = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblindent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblunitid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvdetail = New System.Windows.Forms.DataGridView()
        Me.prtid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvdetailLotno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvdetailTagno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvdetailgodown = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvdetailqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvdetaillossqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvdetailrate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmb_port = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.BtnComplete = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dGORDER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvdetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChkEdit
        '
        Me.ChkEdit.AutoSize = True
        Me.ChkEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkEdit.Location = New System.Drawing.Point(10, 8)
        Me.ChkEdit.Name = "ChkEdit"
        Me.ChkEdit.Size = New System.Drawing.Size(99, 24)
        Me.ChkEdit.TabIndex = 0
        Me.ChkEdit.Text = "For Edit"
        Me.ChkEdit.UseVisualStyleBackColor = True
        Me.ChkEdit.Visible = False
        '
        'chkcomplete
        '
        Me.chkcomplete.AutoSize = True
        Me.chkcomplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkcomplete.Location = New System.Drawing.Point(114, 8)
        Me.chkcomplete.Name = "chkcomplete"
        Me.chkcomplete.Size = New System.Drawing.Size(232, 24)
        Me.chkcomplete.TabIndex = 1
        Me.chkcomplete.Text = "For Complete Indent No."
        Me.chkcomplete.UseVisualStyleBackColor = True
        Me.chkcomplete.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtapprovedby)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.txtcheckedby)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.ddindent)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.lblsrno)
        Me.Panel1.Controls.Add(Me.ChkForReceiveIssItem)
        Me.Panel1.Controls.Add(Me.txtcode)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.TxtPartyChallanNo)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TxtGateInNo)
        Me.Panel1.Controls.Add(Me.TxtNoOFHank)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtdate)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.ddPartyChallanNo)
        Me.Panel1.Controls.Add(Me.lblpartychallanNo)
        Me.Panel1.Controls.Add(Me.ddChallanNo)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.ddempname)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.ddProcessName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.ddCompName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtidnt)
        Me.Panel1.Location = New System.Drawing.Point(10, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1634, 185)
        Me.Panel1.TabIndex = 2
        '
        'txtapprovedby
        '
        Me.txtapprovedby.Location = New System.Drawing.Point(336, 148)
        Me.txtapprovedby.Name = "txtapprovedby"
        Me.txtapprovedby.Size = New System.Drawing.Size(325, 26)
        Me.txtapprovedby.TabIndex = 29
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(338, 123)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(110, 20)
        Me.Label29.TabIndex = 28
        Me.Label29.Text = "Approved By"
        '
        'txtcheckedby
        '
        Me.txtcheckedby.Location = New System.Drawing.Point(4, 148)
        Me.txtcheckedby.Name = "txtcheckedby"
        Me.txtcheckedby.Size = New System.Drawing.Size(325, 26)
        Me.txtcheckedby.TabIndex = 27
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(6, 123)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(104, 20)
        Me.Label28.TabIndex = 26
        Me.Label28.Text = "Checked By"
        '
        'ddindent
        '
        Me.ddindent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddindent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddindent.FormattingEnabled = True
        Me.ddindent.Location = New System.Drawing.Point(1029, 31)
        Me.ddindent.Name = "ddindent"
        Me.ddindent.Size = New System.Drawing.Size(193, 28)
        Me.ddindent.TabIndex = 4
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(1026, 5)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(93, 20)
        Me.Label25.TabIndex = 25
        Me.Label25.Text = "Indent No."
        '
        'lblsrno
        '
        Me.lblsrno.AutoSize = True
        Me.lblsrno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.ForeColor = System.Drawing.Color.Red
        Me.lblsrno.Location = New System.Drawing.Point(1118, 92)
        Me.lblsrno.Name = "lblsrno"
        Me.lblsrno.Size = New System.Drawing.Size(155, 20)
        Me.lblsrno.TabIndex = 24
        Me.lblsrno.Text = "Sr No. Generated."
        '
        'ChkForReceiveIssItem
        '
        Me.ChkForReceiveIssItem.AutoSize = True
        Me.ChkForReceiveIssItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkForReceiveIssItem.Location = New System.Drawing.Point(696, 91)
        Me.ChkForReceiveIssItem.Name = "ChkForReceiveIssItem"
        Me.ChkForReceiveIssItem.Size = New System.Drawing.Size(276, 24)
        Me.ChkForReceiveIssItem.TabIndex = 11
        Me.ChkForReceiveIssItem.Text = "Check For Receive Issue Item"
        Me.ChkForReceiveIssItem.UseVisualStyleBackColor = True
        '
        'txtcode
        '
        Me.txtcode.Location = New System.Drawing.Point(975, 89)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.Size = New System.Drawing.Size(124, 26)
        Me.txtcode.TabIndex = 12
        Me.txtcode.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(974, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 20)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Product Code"
        Me.Label10.Visible = False
        '
        'TxtPartyChallanNo
        '
        Me.TxtPartyChallanNo.Location = New System.Drawing.Point(501, 91)
        Me.TxtPartyChallanNo.Name = "TxtPartyChallanNo"
        Me.TxtPartyChallanNo.Size = New System.Drawing.Size(188, 26)
        Me.TxtPartyChallanNo.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(501, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 20)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Party Challan No."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(333, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 20)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Gate In No."
        '
        'TxtGateInNo
        '
        Me.TxtGateInNo.Location = New System.Drawing.Point(336, 91)
        Me.TxtGateInNo.Name = "TxtGateInNo"
        Me.TxtGateInNo.Size = New System.Drawing.Size(157, 26)
        Me.TxtGateInNo.TabIndex = 9
        '
        'TxtNoOFHank
        '
        Me.TxtNoOFHank.Location = New System.Drawing.Point(172, 91)
        Me.TxtNoOFHank.Name = "TxtNoOFHank"
        Me.TxtNoOFHank.Size = New System.Drawing.Size(157, 26)
        Me.TxtNoOFHank.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(168, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "No of Hank"
        '
        'txtdate
        '
        Me.txtdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtdate.Location = New System.Drawing.Point(4, 91)
        Me.txtdate.Name = "txtdate"
        Me.txtdate.Size = New System.Drawing.Size(157, 26)
        Me.txtdate.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Rec. Date"
        '
        'ddPartyChallanNo
        '
        Me.ddPartyChallanNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddPartyChallanNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddPartyChallanNo.FormattingEnabled = True
        Me.ddPartyChallanNo.Location = New System.Drawing.Point(1428, 31)
        Me.ddPartyChallanNo.Name = "ddPartyChallanNo"
        Me.ddPartyChallanNo.Size = New System.Drawing.Size(196, 28)
        Me.ddPartyChallanNo.TabIndex = 6
        Me.ddPartyChallanNo.Visible = False
        '
        'lblpartychallanNo
        '
        Me.lblpartychallanNo.AutoSize = True
        Me.lblpartychallanNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpartychallanNo.Location = New System.Drawing.Point(1428, 5)
        Me.lblpartychallanNo.Name = "lblpartychallanNo"
        Me.lblpartychallanNo.Size = New System.Drawing.Size(147, 20)
        Me.lblpartychallanNo.TabIndex = 20
        Me.lblpartychallanNo.Text = "Party Challan No."
        Me.lblpartychallanNo.Visible = False
        '
        'ddChallanNo
        '
        Me.ddChallanNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddChallanNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddChallanNo.FormattingEnabled = True
        Me.ddChallanNo.Location = New System.Drawing.Point(1228, 31)
        Me.ddChallanNo.Name = "ddChallanNo"
        Me.ddChallanNo.Size = New System.Drawing.Size(193, 28)
        Me.ddChallanNo.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1226, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 20)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Challan No."
        '
        'ddempname
        '
        Me.ddempname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddempname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddempname.FormattingEnabled = True
        Me.ddempname.Location = New System.Drawing.Point(692, 31)
        Me.ddempname.Name = "ddempname"
        Me.ddempname.Size = New System.Drawing.Size(330, 28)
        Me.ddempname.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(692, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 20)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Emp/Vendor Name"
        '
        'ddProcessName
        '
        Me.ddProcessName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddProcessName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddProcessName.FormattingEnabled = True
        Me.ddProcessName.Location = New System.Drawing.Point(464, 31)
        Me.ddProcessName.Name = "ddProcessName"
        Me.ddProcessName.Size = New System.Drawing.Size(223, 28)
        Me.ddProcessName.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(460, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 20)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Process Name"
        '
        'ddCompName
        '
        Me.ddCompName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddCompName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddCompName.FormattingEnabled = True
        Me.ddCompName.Location = New System.Drawing.Point(172, 31)
        Me.ddCompName.Name = "ddCompName"
        Me.ddCompName.Size = New System.Drawing.Size(284, 28)
        Me.ddCompName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(168, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Company Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Indent No."
        '
        'txtidnt
        '
        Me.txtidnt.Location = New System.Drawing.Point(4, 31)
        Me.txtidnt.Name = "txtidnt"
        Me.txtidnt.Size = New System.Drawing.Size(157, 26)
        Me.txtidnt.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.chkchangeTagno)
        Me.Panel2.Controls.Add(Me.txttagNo)
        Me.Panel2.Controls.Add(Me.lblmanualtagno)
        Me.Panel2.Controls.Add(Me.ddbinno)
        Me.Panel2.Controls.Add(Me.lblbinno)
        Me.Panel2.Controls.Add(Me.DDTagNo)
        Me.Panel2.Controls.Add(Me.lblTagNo)
        Me.Panel2.Controls.Add(Me.DDLotNo)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.ddlunit)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.ddgodown)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.DDOrderNo)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.DDRECSHADE)
        Me.Panel2.Controls.Add(Me.lblrecshade)
        Me.Panel2.Controls.Add(Me.ddlshade)
        Me.Panel2.Controls.Add(Me.LblColorShade)
        Me.Panel2.Controls.Add(Me.dquality)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.dditemname)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.ddCatagory)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Location = New System.Drawing.Point(10, 231)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1697, 128)
        Me.Panel2.TabIndex = 3
        '
        'chkchangeTagno
        '
        Me.chkchangeTagno.AutoSize = True
        Me.chkchangeTagno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkchangeTagno.ForeColor = System.Drawing.Color.Red
        Me.chkchangeTagno.Location = New System.Drawing.Point(1522, 57)
        Me.chkchangeTagno.Name = "chkchangeTagno"
        Me.chkchangeTagno.Size = New System.Drawing.Size(164, 24)
        Me.chkchangeTagno.TabIndex = 30
        Me.chkchangeTagno.Text = "Change Tag No."
        Me.chkchangeTagno.UseVisualStyleBackColor = True
        Me.chkchangeTagno.Visible = False
        '
        'txttagNo
        '
        Me.txttagNo.Enabled = False
        Me.txttagNo.Location = New System.Drawing.Point(1434, 88)
        Me.txttagNo.Name = "txttagNo"
        Me.txttagNo.Size = New System.Drawing.Size(220, 26)
        Me.txttagNo.TabIndex = 47
        Me.txttagNo.Visible = False
        '
        'lblmanualtagno
        '
        Me.lblmanualtagno.AutoSize = True
        Me.lblmanualtagno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmanualtagno.Location = New System.Drawing.Point(1434, 63)
        Me.lblmanualtagno.Name = "lblmanualtagno"
        Me.lblmanualtagno.Size = New System.Drawing.Size(71, 20)
        Me.lblmanualtagno.TabIndex = 46
        Me.lblmanualtagno.Text = "Tag No."
        Me.lblmanualtagno.Visible = False
        '
        'ddbinno
        '
        Me.ddbinno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddbinno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddbinno.FormattingEnabled = True
        Me.ddbinno.Location = New System.Drawing.Point(540, 88)
        Me.ddbinno.Name = "ddbinno"
        Me.ddbinno.Size = New System.Drawing.Size(259, 28)
        Me.ddbinno.TabIndex = 7
        Me.ddbinno.Visible = False
        '
        'lblbinno
        '
        Me.lblbinno.AutoSize = True
        Me.lblbinno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbinno.Location = New System.Drawing.Point(537, 63)
        Me.lblbinno.Name = "lblbinno"
        Me.lblbinno.Size = New System.Drawing.Size(67, 20)
        Me.lblbinno.TabIndex = 45
        Me.lblbinno.Text = "Bin No."
        Me.lblbinno.Visible = False
        '
        'DDTagNo
        '
        Me.DDTagNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDTagNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDTagNo.FormattingEnabled = True
        Me.DDTagNo.Location = New System.Drawing.Point(1230, 88)
        Me.DDTagNo.Name = "DDTagNo"
        Me.DDTagNo.Size = New System.Drawing.Size(196, 28)
        Me.DDTagNo.TabIndex = 10
        Me.DDTagNo.Visible = False
        '
        'lblTagNo
        '
        Me.lblTagNo.AutoSize = True
        Me.lblTagNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTagNo.Location = New System.Drawing.Point(1227, 63)
        Me.lblTagNo.Name = "lblTagNo"
        Me.lblTagNo.Size = New System.Drawing.Size(71, 20)
        Me.lblTagNo.TabIndex = 43
        Me.lblTagNo.Text = "Tag No."
        Me.lblTagNo.Visible = False
        '
        'DDLotNo
        '
        Me.DDLotNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDLotNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDLotNo.FormattingEnabled = True
        Me.DDLotNo.Location = New System.Drawing.Point(963, 88)
        Me.DDLotNo.Name = "DDLotNo"
        Me.DDLotNo.Size = New System.Drawing.Size(259, 28)
        Me.DDLotNo.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(960, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 20)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Lot No."
        '
        'ddlunit
        '
        Me.ddlunit.FormattingEnabled = True
        Me.ddlunit.Location = New System.Drawing.Point(807, 88)
        Me.ddlunit.Name = "ddlunit"
        Me.ddlunit.Size = New System.Drawing.Size(150, 28)
        Me.ddlunit.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(804, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 20)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Unit"
        '
        'ddgodown
        '
        Me.ddgodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddgodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddgodown.FormattingEnabled = True
        Me.ddgodown.Location = New System.Drawing.Point(273, 88)
        Me.ddgodown.Name = "ddgodown"
        Me.ddgodown.Size = New System.Drawing.Size(259, 28)
        Me.ddgodown.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(270, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(126, 20)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Godown Name"
        '
        'DDOrderNo
        '
        Me.DDOrderNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDOrderNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDOrderNo.FormattingEnabled = True
        Me.DDOrderNo.Location = New System.Drawing.Point(8, 88)
        Me.DDOrderNo.Name = "DDOrderNo"
        Me.DDOrderNo.Size = New System.Drawing.Size(259, 28)
        Me.DDOrderNo.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 20)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Order No."
        '
        'DDRECSHADE
        '
        Me.DDRECSHADE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DDRECSHADE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DDRECSHADE.FormattingEnabled = True
        Me.DDRECSHADE.Location = New System.Drawing.Point(1074, 29)
        Me.DDRECSHADE.Name = "DDRECSHADE"
        Me.DDRECSHADE.Size = New System.Drawing.Size(259, 28)
        Me.DDRECSHADE.TabIndex = 4
        Me.DDRECSHADE.Visible = False
        '
        'lblrecshade
        '
        Me.lblrecshade.AutoSize = True
        Me.lblrecshade.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrecshade.Location = New System.Drawing.Point(1070, 3)
        Me.lblrecshade.Name = "lblrecshade"
        Me.lblrecshade.Size = New System.Drawing.Size(108, 20)
        Me.lblrecshade.TabIndex = 33
        Me.lblrecshade.Text = "Shade Color"
        Me.lblrecshade.Visible = False
        '
        'ddlshade
        '
        Me.ddlshade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddlshade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddlshade.FormattingEnabled = True
        Me.ddlshade.Location = New System.Drawing.Point(807, 29)
        Me.ddlshade.Name = "ddlshade"
        Me.ddlshade.Size = New System.Drawing.Size(259, 28)
        Me.ddlshade.TabIndex = 3
        '
        'LblColorShade
        '
        Me.LblColorShade.AutoSize = True
        Me.LblColorShade.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblColorShade.Location = New System.Drawing.Point(804, 3)
        Me.LblColorShade.Name = "LblColorShade"
        Me.LblColorShade.Size = New System.Drawing.Size(108, 20)
        Me.LblColorShade.TabIndex = 31
        Me.LblColorShade.Text = "Shade Color"
        '
        'dquality
        '
        Me.dquality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.dquality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.dquality.FormattingEnabled = True
        Me.dquality.Location = New System.Drawing.Point(540, 29)
        Me.dquality.Name = "dquality"
        Me.dquality.Size = New System.Drawing.Size(259, 28)
        Me.dquality.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(537, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(115, 20)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Quality Name"
        '
        'dditemname
        '
        Me.dditemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.dditemname.FormattingEnabled = True
        Me.dditemname.Location = New System.Drawing.Point(273, 29)
        Me.dditemname.Name = "dditemname"
        Me.dditemname.Size = New System.Drawing.Size(259, 28)
        Me.dditemname.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(270, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 20)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Item_Name"
        '
        'ddCatagory
        '
        Me.ddCatagory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ddCatagory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ddCatagory.FormattingEnabled = True
        Me.ddCatagory.Location = New System.Drawing.Point(6, 29)
        Me.ddCatagory.Name = "ddCatagory"
        Me.ddCatagory.Size = New System.Drawing.Size(259, 28)
        Me.ddCatagory.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(137, 20)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Category_Name"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TxtBellWeight)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.TxtMoisture)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.ChkForWithoutRate)
        Me.Panel3.Controls.Add(Me.TxtRate)
        Me.Panel3.Controls.Add(Me.lblrate)
        Me.Panel3.Controls.Add(Me.TxtLoss)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.txtrec)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.TxtPenalty)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.txtpending)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.txtprerec)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.TxtIndentQty)
        Me.Panel3.Controls.Add(Me.lblissuedqty)
        Me.Panel3.Controls.Add(Me.TxtIssueQty)
        Me.Panel3.Location = New System.Drawing.Point(10, 368)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1694, 71)
        Me.Panel3.TabIndex = 4
        '
        'TxtBellWeight
        '
        Me.TxtBellWeight.Location = New System.Drawing.Point(930, 31)
        Me.TxtBellWeight.Name = "TxtBellWeight"
        Me.TxtBellWeight.Size = New System.Drawing.Size(104, 26)
        Me.TxtBellWeight.TabIndex = 43
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(934, 5)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 20)
        Me.Label31.TabIndex = 44
        Me.Label31.Text = "Bell Wt"
        '
        'TxtMoisture
        '
        Me.TxtMoisture.Location = New System.Drawing.Point(1299, 31)
        Me.TxtMoisture.Name = "TxtMoisture"
        Me.TxtMoisture.Size = New System.Drawing.Size(96, 26)
        Me.TxtMoisture.TabIndex = 41
        Me.TxtMoisture.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(1304, 5)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(78, 20)
        Me.Label30.TabIndex = 42
        Me.Label30.Text = "Moisture"
        Me.Label30.Visible = False
        '
        'ChkForWithoutRate
        '
        Me.ChkForWithoutRate.AutoSize = True
        Me.ChkForWithoutRate.Location = New System.Drawing.Point(1406, 31)
        Me.ChkForWithoutRate.Name = "ChkForWithoutRate"
        Me.ChkForWithoutRate.Size = New System.Drawing.Size(267, 24)
        Me.ChkForWithoutRate.TabIndex = 3
        Me.ChkForWithoutRate.Text = "Check For Receive Without Rate"
        Me.ChkForWithoutRate.UseVisualStyleBackColor = True
        '
        'TxtRate
        '
        Me.TxtRate.Location = New System.Drawing.Point(1176, 31)
        Me.TxtRate.Name = "TxtRate"
        Me.TxtRate.Size = New System.Drawing.Size(115, 26)
        Me.TxtRate.TabIndex = 2
        Me.TxtRate.Visible = False
        '
        'lblrate
        '
        Me.lblrate.AutoSize = True
        Me.lblrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrate.Location = New System.Drawing.Point(1180, 5)
        Me.lblrate.Name = "lblrate"
        Me.lblrate.Size = New System.Drawing.Size(48, 20)
        Me.lblrate.TabIndex = 40
        Me.lblrate.Text = "Rate"
        Me.lblrate.Visible = False
        '
        'TxtLoss
        '
        Me.TxtLoss.Location = New System.Drawing.Point(1042, 31)
        Me.TxtLoss.Name = "TxtLoss"
        Me.TxtLoss.Size = New System.Drawing.Size(126, 26)
        Me.TxtLoss.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(1047, 5)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 20)
        Me.Label23.TabIndex = 38
        Me.Label23.Text = "Loss Qty."
        '
        'txtrec
        '
        Me.txtrec.Location = New System.Drawing.Point(783, 31)
        Me.txtrec.Name = "txtrec"
        Me.txtrec.ReadOnly = True
        Me.txtrec.Size = New System.Drawing.Size(139, 26)
        Me.txtrec.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(788, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 20)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Rec Qty."
        '
        'TxtPenalty
        '
        Me.TxtPenalty.Location = New System.Drawing.Point(606, 31)
        Me.TxtPenalty.Name = "TxtPenalty"
        Me.TxtPenalty.Size = New System.Drawing.Size(169, 26)
        Me.TxtPenalty.TabIndex = 25
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(604, 5)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(159, 20)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "Penalty/Debit Note"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(460, 5)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 20)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "P Qty."
        '
        'txtpending
        '
        Me.txtpending.BackColor = System.Drawing.SystemColors.Menu
        Me.txtpending.Enabled = False
        Me.txtpending.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpending.Location = New System.Drawing.Point(456, 31)
        Me.txtpending.Name = "txtpending"
        Me.txtpending.Size = New System.Drawing.Size(142, 25)
        Me.txtpending.TabIndex = 31
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(310, 5)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 20)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "PreRec Qty."
        '
        'txtprerec
        '
        Me.txtprerec.BackColor = System.Drawing.SystemColors.Menu
        Me.txtprerec.Enabled = False
        Me.txtprerec.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprerec.Location = New System.Drawing.Point(306, 31)
        Me.txtprerec.Name = "txtprerec"
        Me.txtprerec.Size = New System.Drawing.Size(142, 25)
        Me.txtprerec.TabIndex = 29
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(160, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 20)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Indent Qty."
        '
        'TxtIndentQty
        '
        Me.TxtIndentQty.BackColor = System.Drawing.SystemColors.Menu
        Me.TxtIndentQty.Enabled = False
        Me.TxtIndentQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIndentQty.Location = New System.Drawing.Point(156, 31)
        Me.TxtIndentQty.Name = "TxtIndentQty"
        Me.TxtIndentQty.Size = New System.Drawing.Size(142, 25)
        Me.TxtIndentQty.TabIndex = 27
        '
        'lblissuedqty
        '
        Me.lblissuedqty.AutoSize = True
        Me.lblissuedqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblissuedqty.Location = New System.Drawing.Point(10, 5)
        Me.lblissuedqty.Name = "lblissuedqty"
        Me.lblissuedqty.Size = New System.Drawing.Size(100, 20)
        Me.lblissuedqty.TabIndex = 26
        Me.lblissuedqty.Text = "Issued Qty."
        '
        'TxtIssueQty
        '
        Me.TxtIssueQty.BackColor = System.Drawing.SystemColors.Menu
        Me.TxtIssueQty.Enabled = False
        Me.TxtIssueQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIssueQty.Location = New System.Drawing.Point(6, 31)
        Me.TxtIssueQty.Name = "TxtIssueQty"
        Me.TxtIssueQty.Size = New System.Drawing.Size(142, 25)
        Me.TxtIssueQty.TabIndex = 0
        '
        'txtremarks
        '
        Me.txtremarks.Location = New System.Drawing.Point(94, 449)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(890, 73)
        Me.txtremarks.TabIndex = 41
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(9, 471)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 20)
        Me.Label24.TabIndex = 42
        Me.Label24.Text = "Remarks"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(1006, 449)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(84, 29)
        Me.btnNew.TabIndex = 8
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(1101, 449)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(84, 29)
        Me.btnsave.TabIndex = 5
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnpreview
        '
        Me.btnpreview.Location = New System.Drawing.Point(1192, 449)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(84, 29)
        Me.btnpreview.TabIndex = 6
        Me.btnpreview.Text = "Preview"
        Me.btnpreview.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(1377, 449)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(84, 29)
        Me.btnclose.TabIndex = 7
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'dGORDER
        '
        Me.dGORDER.AllowUserToAddRows = False
        Me.dGORDER.AllowUserToDeleteRows = False
        Me.dGORDER.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dGORDER.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGORDER.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITEMDESCRIPTION, Me.LotNo, Me.TagNo, Me.QTY, Me.BAlQty, Me.lblcategoryid, Me.lblitem_id, Me.lblQualityid, Me.lblColorid, Me.lbldesignid, Me.lblshapeid, Me.lblshadecolorid, Me.lblsizeid, Me.lblqty, Me.lblfinished, Me.lblindent, Me.lblunitid})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dGORDER.DefaultCellStyle = DataGridViewCellStyle1
        Me.dGORDER.Location = New System.Drawing.Point(996, 531)
        Me.dGORDER.Name = "dGORDER"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dGORDER.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dGORDER.RowTemplate.Height = 30
        Me.dGORDER.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dGORDER.Size = New System.Drawing.Size(714, 395)
        Me.dGORDER.TabIndex = 47
        '
        'ITEMDESCRIPTION
        '
        Me.ITEMDESCRIPTION.HeaderText = "ITEMDESCRIPTION"
        Me.ITEMDESCRIPTION.Name = "ITEMDESCRIPTION"
        Me.ITEMDESCRIPTION.ReadOnly = True
        Me.ITEMDESCRIPTION.Width = 157
        '
        'LotNo
        '
        Me.LotNo.HeaderText = "LotNo"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        Me.LotNo.Width = 71
        '
        'TagNo
        '
        Me.TagNo.HeaderText = "TagNo"
        Me.TagNo.Name = "TagNo"
        Me.TagNo.ReadOnly = True
        Me.TagNo.Width = 76
        '
        'QTY
        '
        Me.QTY.HeaderText = "QTY"
        Me.QTY.Name = "QTY"
        Me.QTY.ReadOnly = True
        Me.QTY.Width = 62
        '
        'BAlQty
        '
        Me.BAlQty.HeaderText = "BAl.Qty"
        Me.BAlQty.Name = "BAlQty"
        Me.BAlQty.ReadOnly = True
        Me.BAlQty.Width = 80
        '
        'lblcategoryid
        '
        Me.lblcategoryid.HeaderText = "lblcategoryid"
        Me.lblcategoryid.Name = "lblcategoryid"
        Me.lblcategoryid.Visible = False
        '
        'lblitem_id
        '
        Me.lblitem_id.HeaderText = "lblitem_id"
        Me.lblitem_id.Name = "lblitem_id"
        Me.lblitem_id.Visible = False
        '
        'lblQualityid
        '
        Me.lblQualityid.HeaderText = "lblQualityid"
        Me.lblQualityid.Name = "lblQualityid"
        Me.lblQualityid.Visible = False
        '
        'lblColorid
        '
        Me.lblColorid.HeaderText = "lblColorid"
        Me.lblColorid.Name = "lblColorid"
        Me.lblColorid.Visible = False
        '
        'lbldesignid
        '
        Me.lbldesignid.HeaderText = "lbldesignid"
        Me.lbldesignid.Name = "lbldesignid"
        Me.lbldesignid.Visible = False
        '
        'lblshapeid
        '
        Me.lblshapeid.HeaderText = "lblshapeid"
        Me.lblshapeid.Name = "lblshapeid"
        Me.lblshapeid.Visible = False
        '
        'lblshadecolorid
        '
        Me.lblshadecolorid.HeaderText = "lblshadecolorid"
        Me.lblshadecolorid.Name = "lblshadecolorid"
        Me.lblshadecolorid.Visible = False
        '
        'lblsizeid
        '
        Me.lblsizeid.HeaderText = "lblsizeid"
        Me.lblsizeid.Name = "lblsizeid"
        Me.lblsizeid.Visible = False
        '
        'lblqty
        '
        Me.lblqty.HeaderText = "lblqty"
        Me.lblqty.Name = "lblqty"
        Me.lblqty.Visible = False
        '
        'lblfinished
        '
        Me.lblfinished.HeaderText = "lblfinished"
        Me.lblfinished.Name = "lblfinished"
        Me.lblfinished.Visible = False
        '
        'lblindent
        '
        Me.lblindent.HeaderText = "lblindent"
        Me.lblindent.Name = "lblindent"
        Me.lblindent.Visible = False
        '
        'lblunitid
        '
        Me.lblunitid.HeaderText = "lblunitid"
        Me.lblunitid.Name = "lblunitid"
        Me.lblunitid.Visible = False
        '
        'gvdetail
        '
        Me.gvdetail.AllowUserToAddRows = False
        Me.gvdetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gvdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvdetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prtid, Me.ItemName, Me.Description, Me.gvdetailLotno, Me.gvdetailTagno, Me.gvdetailgodown, Me.gvdetailqty, Me.gvdetaillossqty, Me.gvdetailrate, Me.Edit})
        Me.gvdetail.Location = New System.Drawing.Point(8, 531)
        Me.gvdetail.Name = "gvdetail"
        Me.gvdetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.gvdetail.RowTemplate.Height = 24
        Me.gvdetail.Size = New System.Drawing.Size(982, 394)
        Me.gvdetail.TabIndex = 27
        '
        'prtid
        '
        Me.prtid.HeaderText = "prtid"
        Me.prtid.Name = "prtid"
        Me.prtid.Visible = False
        '
        'ItemName
        '
        Me.ItemName.HeaderText = "ItemName"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        Me.ItemName.Width = 70
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'gvdetailLotno
        '
        Me.gvdetailLotno.HeaderText = "LotNo"
        Me.gvdetailLotno.Name = "gvdetailLotno"
        Me.gvdetailLotno.ReadOnly = True
        Me.gvdetailLotno.Width = 70
        '
        'gvdetailTagno
        '
        Me.gvdetailTagno.HeaderText = "TagNo"
        Me.gvdetailTagno.Name = "gvdetailTagno"
        Me.gvdetailTagno.ReadOnly = True
        '
        'gvdetailgodown
        '
        Me.gvdetailgodown.HeaderText = "Godown Name"
        Me.gvdetailgodown.Name = "gvdetailgodown"
        Me.gvdetailgodown.ReadOnly = True
        '
        'gvdetailqty
        '
        Me.gvdetailqty.HeaderText = "Qty"
        Me.gvdetailqty.Name = "gvdetailqty"
        Me.gvdetailqty.ReadOnly = True
        Me.gvdetailqty.Width = 50
        '
        'gvdetaillossqty
        '
        Me.gvdetaillossqty.HeaderText = "Loss qty"
        Me.gvdetaillossqty.Name = "gvdetaillossqty"
        Me.gvdetaillossqty.Width = 50
        '
        'gvdetailrate
        '
        Me.gvdetailrate.HeaderText = "Rate"
        Me.gvdetailrate.Name = "gvdetailrate"
        Me.gvdetailrate.Width = 50
        '
        'Edit
        '
        Me.Edit.HeaderText = ""
        Me.Edit.Name = "Edit"
        Me.Edit.Text = "Update"
        Me.Edit.UseColumnTextForButtonValue = True
        Me.Edit.Width = 70
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(9, 929)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(379, 20)
        Me.Label26.TabIndex = 48
        Me.Label26.Text = "* select row and press del key to delete record"
        '
        'cmb_port
        '
        Me.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_port.FormattingEnabled = True
        Me.cmb_port.Location = New System.Drawing.Point(650, 929)
        Me.cmb_port.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmb_port.Name = "cmb_port"
        Me.cmb_port.Size = New System.Drawing.Size(180, 28)
        Me.cmb_port.TabIndex = 50
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(542, 934)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 20)
        Me.Label27.TabIndex = 49
        Me.Label27.Text = "Port Name"
        '
        'BtnComplete
        '
        Me.BtnComplete.Location = New System.Drawing.Point(1282, 449)
        Me.BtnComplete.Name = "BtnComplete"
        Me.BtnComplete.Size = New System.Drawing.Size(88, 29)
        Me.BtnComplete.TabIndex = 51
        Me.BtnComplete.Text = "Complete"
        Me.BtnComplete.UseVisualStyleBackColor = True
        '
        'frmindentrawreceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1719, 959)
        Me.Controls.Add(Me.BtnComplete)
        Me.Controls.Add(Me.cmb_port)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.gvdetail)
        Me.Controls.Add(Me.dGORDER)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btnpreview)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.txtremarks)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkcomplete)
        Me.Controls.Add(Me.ChkEdit)
        Me.Name = "frmindentrawreceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INDENT RECEIVE"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dGORDER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvdetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChkEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkcomplete As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Friend WithEvents ChkForReceiveIssItem As System.Windows.Forms.CheckBox
    Friend WithEvents txtcode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtPartyChallanNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtGateInNo As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoOFHank As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ddPartyChallanNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblpartychallanNo As System.Windows.Forms.Label
    Friend WithEvents ddChallanNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ddempname As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ddProcessName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ddCompName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtidnt As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DDTagNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTagNo As System.Windows.Forms.Label
    Friend WithEvents DDLotNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ddlunit As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ddgodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DDOrderNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DDRECSHADE As System.Windows.Forms.ComboBox
    Friend WithEvents lblrecshade As System.Windows.Forms.Label
    Friend WithEvents ddlshade As System.Windows.Forms.ComboBox
    Friend WithEvents LblColorShade As System.Windows.Forms.Label
    Friend WithEvents dquality As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dditemname As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ddCatagory As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ChkForWithoutRate As System.Windows.Forms.CheckBox
    Friend WithEvents TxtRate As System.Windows.Forms.TextBox
    Friend WithEvents lblrate As System.Windows.Forms.Label
    Friend WithEvents TxtLoss As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtrec As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtPenalty As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtpending As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtprerec As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtIndentQty As System.Windows.Forms.TextBox
    Friend WithEvents lblissuedqty As System.Windows.Forms.Label
    Friend WithEvents TxtIssueQty As System.Windows.Forms.TextBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents dGORDER As System.Windows.Forms.DataGridView
    Friend WithEvents ITEMDESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BAlQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblcategoryid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblitem_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblQualityid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblColorid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbldesignid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblshapeid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblshadecolorid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblsizeid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblfinished As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblindent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblunitid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ddindent As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents gvdetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents prtid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvdetailLotno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvdetailTagno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvdetailgodown As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvdetailqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvdetaillossqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvdetailrate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewButtonColumn
    Private WithEvents cmb_port As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ddbinno As System.Windows.Forms.ComboBox
    Friend WithEvents lblbinno As System.Windows.Forms.Label
    Friend WithEvents txtapprovedby As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtcheckedby As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents chkchangeTagno As System.Windows.Forms.CheckBox
    Friend WithEvents txttagNo As System.Windows.Forms.TextBox
    Friend WithEvents lblmanualtagno As System.Windows.Forms.Label
    Friend WithEvents TxtMoisture As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents BtnComplete As System.Windows.Forms.Button
    Friend WithEvents TxtBellWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
End Class
