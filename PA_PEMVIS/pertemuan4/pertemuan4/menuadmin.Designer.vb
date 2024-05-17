<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class menuadmin
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PendataanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PendataanJenisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PendataanBrandToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PendataanParfumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanDataParfumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanPembelianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.MenuStrip1.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PendataanToolStripMenuItem, Me.LaporanToolStripMenuItem, Me.LogOutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(288, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PendataanToolStripMenuItem
        '
        Me.PendataanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PendataanJenisToolStripMenuItem, Me.PendataanBrandToolStripMenuItem, Me.PendataanParfumeToolStripMenuItem})
        Me.PendataanToolStripMenuItem.Name = "PendataanToolStripMenuItem"
        Me.PendataanToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.PendataanToolStripMenuItem.Text = "Pendataan"
        '
        'PendataanJenisToolStripMenuItem
        '
        Me.PendataanJenisToolStripMenuItem.Name = "PendataanJenisToolStripMenuItem"
        Me.PendataanJenisToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PendataanJenisToolStripMenuItem.Text = "Pendataan Jenis"
        '
        'PendataanBrandToolStripMenuItem
        '
        Me.PendataanBrandToolStripMenuItem.Name = "PendataanBrandToolStripMenuItem"
        Me.PendataanBrandToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PendataanBrandToolStripMenuItem.Text = "Pendataan Brand"
        '
        'PendataanParfumeToolStripMenuItem
        '
        Me.PendataanParfumeToolStripMenuItem.Name = "PendataanParfumeToolStripMenuItem"
        Me.PendataanParfumeToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PendataanParfumeToolStripMenuItem.Text = "Pendataan Parfume"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LaporanDataParfumeToolStripMenuItem, Me.LaporanPembelianToolStripMenuItem})
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'LaporanDataParfumeToolStripMenuItem
        '
        Me.LaporanDataParfumeToolStripMenuItem.Name = "LaporanDataParfumeToolStripMenuItem"
        Me.LaporanDataParfumeToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.LaporanDataParfumeToolStripMenuItem.Text = "Laporan Data Parfume"
        '
        'LaporanPembelianToolStripMenuItem
        '
        Me.LaporanPembelianToolStripMenuItem.Name = "LaporanPembelianToolStripMenuItem"
        Me.LaporanPembelianToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.LaporanPembelianToolStripMenuItem.Text = "Laporan Keranjang User"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 212)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "SISTEM PENDATAAN PARFUME"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global._pertemuan4.My.Resources.Resources.WhatsApp_Image_2024_04_24_at_20_27_51_4df87e31_removebg_preview
        Me.PictureBox1.Location = New System.Drawing.Point(95, 114)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(89, 84)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'menuadmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(288, 255)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "menuadmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form7"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PendataanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PendataanJenisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PendataanBrandToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PendataanParfumeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LaporanDataParfumeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanPembelianToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
