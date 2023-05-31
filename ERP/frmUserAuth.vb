Public Class frmUserAuth
    Private Sub frmUserAuth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        varPassOK = False
    End Sub
    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        varPassOK = False
        If subformopen = 1 Then ''DYEING
            If UCase(Trim(txtPass.Text)) <> UCase(varAdmPassDyeing) Then
                MsgBox("Wrong Password....")
                txtPass.Text = ""
                Exit Sub
            End If
        ElseIf UCase(Trim(txtPass.Text)) <> UCase(varAdmPass) Then
            MsgBox("Wrong Password....")
            txtPass.Text = ""
            Exit Sub
        End If
        varPassOK = True
        If chkS.Checked = False Then
            txtPass.Text = ""
        End If
        subformopen = 0
        Me.Close()
    End Sub
    Private Sub txtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdSubmit.Focus()
        End If
    End Sub
End Class