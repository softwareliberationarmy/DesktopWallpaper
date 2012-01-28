Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnImage As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnWallpaper As System.Windows.Forms.Button
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnImage = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnWallpaper = New System.Windows.Forms.Button
        Me.txtFile = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnImage
        '
        Me.btnImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImage.Location = New System.Drawing.Point(8, 448)
        Me.btnImage.Name = "btnImage"
        Me.btnImage.Size = New System.Drawing.Size(88, 32)
        Me.btnImage.TabIndex = 0
        Me.btnImage.Text = "Locate Image..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(520, 424)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(472, 448)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 32)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        '
        'btnWallpaper
        '
        Me.btnWallpaper.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnWallpaper.Location = New System.Drawing.Point(112, 448)
        Me.btnWallpaper.Name = "btnWallpaper"
        Me.btnWallpaper.Size = New System.Drawing.Size(152, 32)
        Me.btnWallpaper.TabIndex = 3
        Me.btnWallpaper.Text = "Set as Wallpaper"
        '
        'txtFile
        '
        Me.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFile.Location = New System.Drawing.Point(296, 464)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.TabIndex = 4
        Me.txtFile.Text = ""
        Me.txtFile.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(552, 485)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.btnImage)
        Me.Controls.Add(Me.btnWallpaper)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImage.Click
        Dim ofd As New OpenFileDialog

        With ofd
            .Title = "Locate the Wallpaper Image..."
            .Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.png)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"
            .FilterIndex = 1
            .CheckFileExists = True

            If (.ShowDialog() <> DialogResult.Cancel) Then
                PictureBox1.Image = Image.FromFile(.FileName)
                txtFile.Text = .FileName
            End If
        End With
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnWallpaper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWallpaper.Click
        'If (PictureBox1.Image Is Nothing) Then
        If (txtFile.Text.Length = 0) Then
            MessageBox.Show("No image present", "Missing Image", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        SetWallpaper(txtFile.Text) 'Me.PictureBox1.Image)
    End Sub
End Class
