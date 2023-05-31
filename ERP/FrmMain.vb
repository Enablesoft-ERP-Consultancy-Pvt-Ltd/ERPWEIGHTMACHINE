Imports System.IO
Public Class FrmMain
    Private Sub FrmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If GetServerUserNamePassword() = False Then
            MsgBox("Please Insert Data in Server.txt File", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Message")
            Return
        End If
        Con.ConnectionString = "Data Source=" & VarSQLServer & ";Initial Catalog=" & VarDatabaseName & ";User ID=" & VarSQLUserName & ";Password=" & VarSQLPassword & ""
        FrmLogin.ShowDialog()

        If varuserid = 0 Then
            Me.Close()
        End If

        Call VariableSetting()
        ''*****CALL UPDATER
        Call callupdateexecode()
        ''*************
        If VarMasterCompanyID = 8 Then
            DYEINGToolStripMenuItem.Visible = False
            PurchaseToolStripMenuItem.Visible = False
            SAMPLEToolStripMenuItem.Visible = False
            YARNOPENINGToolStripMenuItem.Visible = False
        End If
        PROCESSToolStripMenuItem.Visible = False
        ''*************
        ''SAMPLEToolStripMenuItem.Visible = False
        If VarMasterCompanyID = 16 Or VarMasterCompanyID = 28 Then
            PROCESSToolStripMenuItem.Visible = True
        End If
    End Sub

    Protected Sub callupdateexecode()
        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(Con, CommandType.Text, "select UPDATERPATHFORWEIGTHMACHINE as Path from mastersetting Where UPDATERPATHFORWEIGTHMACHINE<>''")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim appname As String
                Dim Process As System.Diagnostics.Process
                appname = Process.GetCurrentProcess().ProcessName
                If appname.IndexOf(".vshost") > 0 Then
                    appname = appname.Replace(".vshost", ".exe")
                Else
                    appname = appname + ".exe"
                End If
                ''Checks for the same exe name at remote location
                Dim upFileName As String
                Dim newFileTime As Date
                Dim oldFileTime As Date

                upFileName = ds.Tables(0).Rows(0)("Path").ToString() & "\" & appname
                newFileTime = System.IO.File.GetLastWriteTime(upFileName)
                oldFileTime = System.IO.File.GetLastWriteTime(Application.StartupPath & "\" & appname)

                If newFileTime > oldFileTime Then
                    Dim proc As New System.Diagnostics.Process()
                    proc.StartInfo.FileName = "schUpdaterforweightMachine.exe"
                    Application.Exit()
                    proc.Start()
                Else
                    ''Update Reports Only
                    Dim remotePath As String = ds.Tables(0).Rows(0)("Path").ToString()
                    Dim newFileTimeReport As DateTime
                    Dim oldFileTimeReport As DateTime
                    ' Copy reports
                    'foreach (string rfile in Directory.EnumerateFiles(remotePath + @"\Reports", "*.rpt"))
                    For Each rfile As String In Directory.GetFiles(remotePath + "\Reports", "*.rpt")
                        newFileTimeReport = System.IO.File.GetLastWriteTime(rfile)
                        Dim oFilename As String = Path.GetFileName(rfile)
                        If File.Exists(Convert.ToString(Application.StartupPath + "\Reports\") & oFilename) Then
                            oldFileTimeReport = System.IO.File.GetLastWriteTime(Convert.ToString(Application.StartupPath + "\Reports\") & oFilename)
                            If newFileTimeReport > oldFileTimeReport Then
                                File.Copy(rfile, Convert.ToString(Application.StartupPath + "\Reports\") & oFilename, True)
                            End If
                        Else
                            File.Copy(rfile, Convert.ToString(Application.StartupPath + "\Reports\") & oFilename)
                        End If
                    Next
                    ''
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetServerUserNamePassword() As Boolean
        Dim VarLen As Integer, VarPos As Integer
        Dim File As System.IO.FileStream
        Dim Str As String
        Try
            Str = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Server.txt")
            If Trim(Str) = "" Then MsgBox("Please, Set Server Name, User Id and Password for the Database!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "iCampus Professional") : GetServerUserNamePassword = False : Exit Function

            VarLen = Len(Str)
            VarPos = InStr(1, Str, ":", CompareMethod.Text)
            VarSQLServer = Trim(Mid(Str, 1, VarPos - 1))
            Str = Mid(Str, VarPos + 1, VarLen)

            VarLen = Len(Str)
            VarPos = InStr(1, Str, ":", CompareMethod.Text)
            VarSQLUserName = Trim(Mid(Str, 1, VarPos - 1))

            Str = Mid(Str, VarPos + 1, VarLen)
            VarLen = Len(Str)
            VarPos = InStr(1, Str, ":", CompareMethod.Text)
            VarSQLPassword = Trim(Mid(Str, 1, VarPos - 1))
            If VarSQLPassword = "" Then
                VarSQLPassword = "Eit218"
            End If
            Str = Mid(Str, VarPos + 1, VarLen)
            VarLen = Len(Str)
            VarPos = InStr(1, Str, ":", CompareMethod.Text)
            VarDatabaseName = Trim(Mid(Str, 1, VarPos - 1))



            'varPortNo = ""
            'varBaudRate = 2400
            GetServerUserNamePassword = True
        Catch ex As Exception
            MsgBox(ex.Message)
            GetServerUserNamePassword = False
        End Try
    End Function

    Private Sub RawMaterialIssueToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RawMaterialIssueToolStripMenuItem1.Click
        If VarMasterCompanyID = 8 Then
            FrmRawMaterialIssue.Show()
        Else
            ''FrmRecipeRawMaterialIssue.Show()
            FrmRawMaterialIssueforOthers.Show()
        End If

    End Sub

    Private Sub RawMaterialReceiveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RawMaterialReceiveToolStripMenuItem.Click
        Frmprocessrawreceive.Show()
    End Sub

    Private Sub RawMaterialReturnedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RawMaterialReturnedToolStripMenuItem.Click
        frmRawMaterialReturned.Show()
    End Sub

    Private Sub RECEIVEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RECEIVEToolStripMenuItem.Click
        frmindentrawreceive.Show()
    End Sub

    Private Sub ISSUEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ISSUEToolStripMenuItem.Click
        frmindentrowissue.Show()
    End Sub

    Private Sub ReceiveToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ReceiveToolStripMenuItem1.Click
        frmpurchasereceive.Show()
    End Sub

    Private Sub ISSUEToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ISSUEToolStripMenuItem1.Click
        frmsampleyarndyeing.Show()
    End Sub

    Private Sub RECEIVEToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles RECEIVEToolStripMenuItem2.Click
        frmsampledyeingmaterialreceive.Show()
    End Sub

    Private Sub RAWISSUEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RAWISSUEToolStripMenuItem.Click
        frmsamplerawissue.Show()
    End Sub

    Private Sub ISSUEToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ISSUEToolStripMenuItem2.Click
        frmyarnopeningissue.Show()
    End Sub

    Private Sub RECEIVEToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles RECEIVEToolStripMenuItem3.Click
        frmyarnopeningreceive.Show()
    End Sub

    Private Sub RETURNToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RETURNToolStripMenuItem.Click
        frmyarnopeningreturn.Show()
    End Sub

    Private Sub ISSUEToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ISSUEToolStripMenuItem3.Click
        frmmottelingissue.Show()
    End Sub

    Private Sub ISSUEToolStripMenuItem4_Click(sender As System.Object, e As System.EventArgs) Handles ISSUEToolStripMenuItem4.Click
        frmHandspinningissue.Show()
    End Sub

    Private Sub RECEIVEToolStripMenuItem4_Click(sender As System.Object, e As System.EventArgs) Handles RECEIVEToolStripMenuItem4.Click
        frmmottelingreceive.Show()
    End Sub

    Private Sub RECEIVEToolStripMenuItem5_Click(sender As System.Object, e As System.EventArgs) Handles RECEIVEToolStripMenuItem5.Click
        frmHandspinningreceive.Show()
    End Sub

    Private Sub RETURNToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RETURNToolStripMenuItem1.Click
        frmmottelingreturn.Show()
    End Sub

    Private Sub RETURNToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles RETURNToolStripMenuItem2.Click
        frmHandspinningreturn.Show()
    End Sub

    Private Sub STOCKNOWISEMATERIALISSUEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles STOCKNOWISEMATERIALISSUEToolStripMenuItem.Click
        frmmaterialissuestocknowise.Show()
    End Sub

    Private Sub WeightAttachWithStockNoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WeightAttachWithStockNoToolStripMenuItem.Click
        frmStockNoAttachWeight.Show()
    End Sub

    Private Sub RECIPERAWISSUEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RECIPERAWISSUEToolStripMenuItem.Click
        FrmRecipeRawMaterialIssue.Show()
    End Sub

    Private Sub RETURNToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles RETURNToolStripMenuItem3.Click
        FrmIndentRawReturn.Show()
    End Sub

    Private Sub GATEPASSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GATEPASSToolStripMenuItem.Click
        FrmGeneralGatePass.Show()
    End Sub

    Private Sub GATEINToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GATEINToolStripMenuItem.Click
        FrmGeneralGateIn.Show()
    End Sub

    Private Sub STOCKTRANSFERToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles STOCKTRANSFERToolStripMenuItem.Click
        FrmStockTransfer.Show()
    End Sub

    Private Sub NEXTPROCESSISSUEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NEXTPROCESSISSUEToolStripMenuItem.Click
        FrmNextProcessIssue.Show()
    End Sub

    Private Sub NEXTPROCESSRECEIVEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NEXTPROCESSRECEIVEToolStripMenuItem.Click
        FrmNextProcessReceive.Show()
    End Sub

    Private Sub TASSELRAWISSUEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TASSELRAWISSUEToolStripMenuItem.Click
        FrmTasselMakingOrderRowIssueNew.Show()
    End Sub

    Private Sub DEPARTMENTRAWISSUEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DEPARTMENTRAWISSUEToolStripMenuItem.Click
        FrmDepartmentRowIssue.Show()
    End Sub

    Private Sub DEPARTMENTRAWRECEIVEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DEPARTMENTRAWRECEIVEToolStripMenuItem.Click
        FrmDepartmentRowReceive.Show()
    End Sub

    Private Sub FIRSTPROCESSRECEIVEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FIRSTPROCESSRECEIVEToolStripMenuItem.Click
        FrmFirstProcessReceive.Show()
    End Sub

    Private Sub DEPARTMENTRAWRETURNToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DEPARTMENTRAWRETURNToolStripMenuItem.Click
        FrmDepartmentRowReturn.Show()
    End Sub

    Private Sub DEPARTMENTRAWRETURNRECEIVEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DEPARTMENTRAWRETURNRECEIVEToolStripMenuItem.Click
        FrmDepartmentRowReturnReceice.Show()
    End Sub

    Private Sub DYINGINWARDToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DYINGINWARDToolStripMenuItem.Click
        FrmDyingHouseInward.Show()
    End Sub

    Private Sub ORDERRAWISSUEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ORDERRAWISSUEToolStripMenuItem.Click
        FrmHomeFurnishingProductionOrderRowIssue.Show()
    End Sub

    Private Sub BAZARWEIGHTUPDATEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BAZARWEIGHTUPDATEToolStripMenuItem.Click
        FrmBazaarWeightUpdate.Show()
    End Sub
End Class