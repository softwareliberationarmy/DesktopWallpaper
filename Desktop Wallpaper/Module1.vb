Imports System.IO

Module Module1
    Private Const SPI_SETDESKWALLPAPER As Integer = &H14
    Private Const SPIF_UPDATEINIFILE As Integer = &H1
    Private Const SPIF_SENDWININICHANGE As Integer = &H2
    Private Declare Auto Function SystemParametersInfo Lib "user32.dll" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer


    Friend Sub SetWallpaper(ByVal sFile As String)
        Try
            Dim img As Image = Image.FromFile(sFile)
            Dim ImageDir As New DirectoryInfo("c:\Images\")
            If Not (ImageDir.Exists) Then
                ImageDir.Create()
            End If
            Dim NewImageBMP As String = ImageDir.FullName & Path.GetFileNameWithoutExtension(sFile) & ".bmp"
            img.Save(NewImageBMP, System.Drawing.Imaging.ImageFormat.Bmp)
            Dim ret As Integer = SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, NewImageBMP, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
        Catch Ex As Exception
            MsgBox("There was an error setting the wallpaper: " & Ex.Message)
        End Try
    End Sub



End Module
