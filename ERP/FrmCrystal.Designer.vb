<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrystal
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
        Me.CR1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CR1
        '
        Me.CR1.ActiveViewIndex = -1
        Me.CR1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CR1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CR1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CR1.Location = New System.Drawing.Point(0, 0)
        Me.CR1.Name = "CR1"
        Me.CR1.SelectionFormula = ""
        Me.CR1.Size = New System.Drawing.Size(833, 503)
        Me.CR1.TabIndex = 0
        Me.CR1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CR1.ViewTimeSelectionFormula = ""
        '
        'FrmCrystal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 503)
        Me.Controls.Add(Me.CR1)
        Me.Name = "FrmCrystal"
        Me.Text = "FrmCrystal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CR1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
