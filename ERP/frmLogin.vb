Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.Data.SqlClient
Public Class FrmLogin
    Private Sub CmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClose.Click
        Application.Exit()
        Me.Close()
    End Sub
    Private Sub OK_Clk()
        Dim strsql As String
        Dim ds As New DataSet
        Try
            If Con.State = ConnectionState.Closed Then Con.Open()
            If txtUserName.Text = "" And txtPassword.Text = "" Then MsgBox("Please, Enter Login Name and Password!", MsgBoxStyle.OkOnly, "Message") : txtUserName.Focus() : Exit Sub
            If txtUserName.Text = "" Then MsgBox("Please, Enter Login Name!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message") : txtUserName.Focus() : Exit Sub
            If txtPassword.Text = "" Then MsgBox("Please , Enter Password!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message") : txtPassword.Focus() : Exit Sub
            strsql = "select * From [NewUserDetail](Nolock) where LoginName = '" & txtUserName.Text & "' and Password ='" & txtPassword.Text & "'"
            ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, strsql)
            If ds.Tables(0).Rows.Count > 0 Then
                varuserid = ds.Tables(0).Rows(0)("UserId")

                strsql = " Select * From Company_Authentication(Nolock) Where CompanyId = " & DDCompanyName.SelectedValue & " And UserId = " & varuserid & " And MasterCompanyId = " & ds.Tables(0).Rows(0)("CompanyID")
                If ds.Tables(0).Rows.Count > 0 Then
                    VarCompanyID = DDCompanyName.SelectedValue
                    Me.Close()
                Else
                    MsgBox("Please gave excess to user !!", MsgBoxStyle.OkOnly, "Message")
                    txtUserName.Text = ""
                    txtPassword.Text = ""
                    DDCompanyName.Focus()
                End If
            Else
                MsgBox("Invalid Password,Try Again!!", MsgBoxStyle.OkOnly, "Message")
                txtUserName.Text = ""
                txtPassword.Text = ""
                txtUserName.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Err.Clear()
            'Finallydd
            '    Con.Close()
        End Try
    End Sub

    Private Sub CmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOk.Click
        Call OK_Clk()
    End Sub

    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim str As String = "select Distinct CI.CompanyId,Companyname from Companyinfo CI(Nolock) Order By Companyname"

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)

        NewComboFillWithDs(DDCompanyName, ds, 0)
        If DDCompanyName.Items.Count > 0 Then
            DDCompanyName.SelectedIndex = 0
        End If
        txtUserName.Text = ""
        txtPassword.Text = ""
        txtUserName.Focus()
    End Sub

    Private Sub txtUserName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call OK_Clk()
        End If
    End Sub

    Public Sub TrueMenuItems()
        Dim i As Integer
        Dim lblname As String
        For Each item As ToolStripMenuItem In FrmMain.MenuStrip1.Items
            item.Visible = False
            lblname = item.Text
            For Each subitem As ToolStripMenuItem In item.DropDownItems
                subitem.Visible = False
                For Each subitem1 As ToolStripMenuItem In subitem.DropDownItems
                    lblname = subitem1.Text
                    subitem1.Visible = False
                    For Each subitem2 As ToolStripMenuItem In subitem1.DropDownItems
                        lblname = subitem2.Text
                        subitem2.Visible = False
                    Next
                Next
            Next subitem
        Next item
        Call MenuVisibility()
    End Sub
    Public Sub MenuVisibility()
        Dim str As String = ""
        Dim mnu As New ToolStripMenuItem
        Dim i As Integer
        str = "select  F.Srno,ParentId,MenuName from Formname F Inner join userrights UR on F.Srno=UR.srno where parentid=0 And UR.Userid=" & varuserid & " Order by F.Srno"
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, str)
        If ds.Tables(0).Rows.Count > 0 Then
            ''Main Menu Item
            For Each item As ToolStripMenuItem In FrmMain.MenuStrip1.Items
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If item.Name.ToString() = ds.Tables(0).Rows(i)("MenuName").ToString() Then
                        item.Visible = True
                        '''Main Toolstripitem
                        For Each subitem As ToolStripMenuItem In item.DropDownItems
                            Dim Seqchild As [String] = "SELECT F.MenuName,F.Srno FROM Formname F Inner join userrights UR on F.Srno=UR.srno  WHERE F.ParentId=" & ds.Tables(0).Rows(i)("Srno") & " And UR.UserId=" & varuserid & ""
                            Dim dachildmnu As New SqlDataAdapter(Seqchild, Con)
                            Dim dtchild As New DataTable()
                            dachildmnu.Fill(dtchild)
                            For Each dr As DataRow In dtchild.Rows
                                If subitem.Name.ToString() = dr("MenuName").ToString() Then
                                    subitem.Visible = True
                                    ''Tool Child
                                    For Each subitem1 As ToolStripMenuItem In subitem.DropDownItems
                                        Dim ssmnu As New ToolStripMenuItem
                                        Dim Seqchild1 As [String] = "SELECT F.MenuName,F.Srno FROM Formname F Inner join userrights UR on F.Srno=UR.srno WHERE F.ParentId=" & dr("Srno") & " And UR.Userid=" & varuserid & ""
                                        Dim dachildmnu1 As New SqlDataAdapter(Seqchild1, Con)
                                        Dim dtchild1 As New DataTable()
                                        dachildmnu1.Fill(dtchild1)
                                        For Each dr1 As DataRow In dtchild1.Rows
                                            If subitem1.Name.ToString() = dr1("MenuName").ToString() Then
                                                subitem1.Visible = True
                                                ''Tool Child Child
                                                For Each subitem2 As ToolStripMenuItem In subitem1.DropDownItems
                                                    Dim Seqchild2 As [String] = "SELECT F.MenuName,F.Srno FROM Formname F Inner join userrights UR on F.Srno=UR.srno WHERE F.ParentId=" & dr1("Srno") & " And UR.Userid=" & varuserid & ""
                                                    Dim dachildmnu2 As New SqlDataAdapter(Seqchild2, Con)
                                                    Dim dtchild2 As New DataTable()
                                                    dachildmnu2.Fill(dtchild2)
                                                    For Each dr2 As DataRow In dtchild2.Rows
                                                        If subitem2.Name.ToString() = dr2("Menuname").ToString() Then
                                                            subitem2.Visible = True
                                                        End If
                                                    Next
                                                Next
                                            End If
                                        Next
                                    Next
                                End If
                            Next
                        Next
                    End If
                Next
            Next
        End If
    End Sub
End Class