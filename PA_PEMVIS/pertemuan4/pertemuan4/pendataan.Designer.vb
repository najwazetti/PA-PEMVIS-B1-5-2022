<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pendataan
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
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtJumlah = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbbrand = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.kategori = New System.Windows.Forms.GroupBox()
        Me.aquatic = New System.Windows.Forms.CheckBox()
        Me.gourmand = New System.Windows.Forms.CheckBox()
        Me.aromatic = New System.Windows.Forms.CheckBox()
        Me.fresh = New System.Windows.Forms.CheckBox()
        Me.oriental = New System.Windows.Forms.CheckBox()
        Me.woody = New System.Windows.Forms.CheckBox()
        Me.fruity = New System.Windows.Forms.CheckBox()
        Me.floral = New System.Windows.Forms.CheckBox()
        Me.btnkembali = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cbukuran = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbjenis = New System.Windows.Forms.ComboBox()
        Me.txtharga = New System.Windows.Forms.TextBox()
        Me.Alkohol = New System.Windows.Forms.GroupBox()
        Me.rbtidakada = New System.Windows.Forms.RadioButton()
        Me.rbada = New System.Windows.Forms.RadioButton()
        Me.txtnama = New System.Windows.Forms.TextBox()
        Me.txtidparfume = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.kategori.SuspendLayout()
        Me.Alkohol.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnsimpan
        '
        Me.btnsimpan.BackColor = System.Drawing.Color.Linen
        Me.btnsimpan.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsimpan.Location = New System.Drawing.Point(348, 400)
        Me.btnsimpan.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(788, 44)
        Me.btnsimpan.TabIndex = 4
        Me.btnsimpan.Text = "SIMPAN DATA"
        Me.btnsimpan.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Panel1.Controls.Add(Me.txtJumlah)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cbbrand)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.kategori)
        Me.Panel1.Controls.Add(Me.btnkembali)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.cbukuran)
        Me.Panel1.Controls.Add(Me.btnsimpan)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cbjenis)
        Me.Panel1.Controls.Add(Me.txtharga)
        Me.Panel1.Controls.Add(Me.Alkohol)
        Me.Panel1.Controls.Add(Me.txtnama)
        Me.Panel1.Controls.Add(Me.txtidparfume)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(0, 115)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1156, 577)
        Me.Panel1.TabIndex = 10
        '
        'txtJumlah
        '
        Me.txtJumlah.Location = New System.Drawing.Point(276, 340)
        Me.txtJumlah.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.txtJumlah.Name = "txtJumlah"
        Me.txtJumlah.Size = New System.Drawing.Size(336, 31)
        Me.txtJumlah.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 342)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(203, 29)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Jumlah Parfume "
        '
        'cbbrand
        '
        Me.cbbrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbrand.FormattingEnabled = True
        Me.cbbrand.Location = New System.Drawing.Point(276, 188)
        Me.cbbrand.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbbrand.Name = "cbbrand"
        Me.cbbrand.Size = New System.Drawing.Size(336, 33)
        Me.cbbrand.TabIndex = 32
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 192)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(185, 29)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Brand Parfume"
        '
        'kategori
        '
        Me.kategori.Controls.Add(Me.aquatic)
        Me.kategori.Controls.Add(Me.gourmand)
        Me.kategori.Controls.Add(Me.aromatic)
        Me.kategori.Controls.Add(Me.fresh)
        Me.kategori.Controls.Add(Me.oriental)
        Me.kategori.Controls.Add(Me.woody)
        Me.kategori.Controls.Add(Me.fruity)
        Me.kategori.Controls.Add(Me.floral)
        Me.kategori.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kategori.Location = New System.Drawing.Point(652, 88)
        Me.kategori.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.kategori.Name = "kategori"
        Me.kategori.Padding = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.kategori.Size = New System.Drawing.Size(508, 292)
        Me.kategori.TabIndex = 30
        Me.kategori.TabStop = False
        Me.kategori.Text = "Kategori"
        '
        'aquatic
        '
        Me.aquatic.AutoSize = True
        Me.aquatic.Location = New System.Drawing.Point(220, 106)
        Me.aquatic.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.aquatic.Name = "aquatic"
        Me.aquatic.Size = New System.Drawing.Size(247, 33)
        Me.aquatic.TabIndex = 7
        Me.aquatic.Text = "Aquatic or Marine"
        Me.aquatic.UseVisualStyleBackColor = True
        '
        'gourmand
        '
        Me.gourmand.AutoSize = True
        Me.gourmand.Location = New System.Drawing.Point(220, 40)
        Me.gourmand.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.gourmand.Name = "gourmand"
        Me.gourmand.Size = New System.Drawing.Size(167, 33)
        Me.gourmand.TabIndex = 6
        Me.gourmand.Text = "Gourmand"
        Me.gourmand.UseVisualStyleBackColor = True
        '
        'aromatic
        '
        Me.aromatic.AutoSize = True
        Me.aromatic.Location = New System.Drawing.Point(220, 235)
        Me.aromatic.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.aromatic.Name = "aromatic"
        Me.aromatic.Size = New System.Drawing.Size(261, 33)
        Me.aromatic.TabIndex = 5
        Me.aromatic.Text = "Aromatic or Herbal"
        Me.aromatic.UseVisualStyleBackColor = True
        '
        'fresh
        '
        Me.fresh.AutoSize = True
        Me.fresh.Location = New System.Drawing.Point(28, 235)
        Me.fresh.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.fresh.Name = "fresh"
        Me.fresh.Size = New System.Drawing.Size(107, 33)
        Me.fresh.TabIndex = 4
        Me.fresh.Text = "Fresh"
        Me.fresh.UseVisualStyleBackColor = True
        '
        'oriental
        '
        Me.oriental.AutoSize = True
        Me.oriental.Location = New System.Drawing.Point(220, 169)
        Me.oriental.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.oriental.Name = "oriental"
        Me.oriental.Size = New System.Drawing.Size(141, 33)
        Me.oriental.TabIndex = 3
        Me.oriental.Text = "Oriental"
        Me.oriental.UseVisualStyleBackColor = True
        '
        'woody
        '
        Me.woody.AutoSize = True
        Me.woody.Location = New System.Drawing.Point(28, 169)
        Me.woody.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.woody.Name = "woody"
        Me.woody.Size = New System.Drawing.Size(122, 33)
        Me.woody.TabIndex = 2
        Me.woody.Text = "Woody"
        Me.woody.UseVisualStyleBackColor = True
        '
        'fruity
        '
        Me.fruity.AutoSize = True
        Me.fruity.Location = New System.Drawing.Point(28, 106)
        Me.fruity.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.fruity.Name = "fruity"
        Me.fruity.Size = New System.Drawing.Size(112, 33)
        Me.fruity.TabIndex = 1
        Me.fruity.Text = "Fruity"
        Me.fruity.UseVisualStyleBackColor = True
        '
        'floral
        '
        Me.floral.AutoSize = True
        Me.floral.Location = New System.Drawing.Point(28, 40)
        Me.floral.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.floral.Name = "floral"
        Me.floral.Size = New System.Drawing.Size(112, 33)
        Me.floral.TabIndex = 0
        Me.floral.Text = "Floral"
        Me.floral.UseVisualStyleBackColor = True
        '
        'btnkembali
        '
        Me.btnkembali.BackColor = System.Drawing.Color.Linen
        Me.btnkembali.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnkembali.Location = New System.Drawing.Point(348, 456)
        Me.btnkembali.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnkembali.Name = "btnkembali"
        Me.btnkembali.Size = New System.Drawing.Size(788, 44)
        Me.btnkembali.TabIndex = 28
        Me.btnkembali.Text = "KEMBALI"
        Me.btnkembali.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(652, 35)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.DateTimePicker1.MaxDate = New Date(2024, 5, 15, 21, 34, 54, 0)
        Me.DateTimePicker1.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(484, 37)
        Me.DateTimePicker1.TabIndex = 23
        Me.DateTimePicker1.Value = New Date(2024, 5, 15, 0, 0, 0, 0)
        '
        'cbukuran
        '
        Me.cbukuran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbukuran.FormattingEnabled = True
        Me.cbukuran.Items.AddRange(New Object() {"10 ML", "15 ML", "50 ML", "75 ML", "100 ML", "125 ML", "150 ML"})
        Me.cbukuran.Location = New System.Drawing.Point(276, 288)
        Me.cbukuran.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbukuran.Name = "cbukuran"
        Me.cbukuran.Size = New System.Drawing.Size(336, 33)
        Me.cbukuran.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 288)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(202, 29)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Ukuran Parfume"
        '
        'cbjenis
        '
        Me.cbjenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbjenis.FormattingEnabled = True
        Me.cbjenis.Location = New System.Drawing.Point(276, 135)
        Me.cbjenis.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.cbjenis.Name = "cbjenis"
        Me.cbjenis.Size = New System.Drawing.Size(336, 33)
        Me.cbjenis.TabIndex = 19
        '
        'txtharga
        '
        Me.txtharga.Location = New System.Drawing.Point(276, 238)
        Me.txtharga.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.txtharga.Name = "txtharga"
        Me.txtharga.Size = New System.Drawing.Size(336, 31)
        Me.txtharga.TabIndex = 20
        '
        'Alkohol
        '
        Me.Alkohol.Controls.Add(Me.rbtidakada)
        Me.Alkohol.Controls.Add(Me.rbada)
        Me.Alkohol.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Alkohol.Location = New System.Drawing.Point(4, 400)
        Me.Alkohol.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Alkohol.Name = "Alkohol"
        Me.Alkohol.Padding = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Alkohol.Size = New System.Drawing.Size(332, 92)
        Me.Alkohol.TabIndex = 22
        Me.Alkohol.TabStop = False
        Me.Alkohol.Text = "Kadar Alkohol Parfume"
        '
        'rbtidakada
        '
        Me.rbtidakada.AutoSize = True
        Me.rbtidakada.Location = New System.Drawing.Point(156, 40)
        Me.rbtidakada.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.rbtidakada.Name = "rbtidakada"
        Me.rbtidakada.Size = New System.Drawing.Size(160, 33)
        Me.rbtidakada.TabIndex = 1
        Me.rbtidakada.TabStop = True
        Me.rbtidakada.Text = "Tidak Ada"
        Me.rbtidakada.UseVisualStyleBackColor = True
        '
        'rbada
        '
        Me.rbada.AutoSize = True
        Me.rbada.Location = New System.Drawing.Point(20, 40)
        Me.rbada.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.rbada.Name = "rbada"
        Me.rbada.Size = New System.Drawing.Size(88, 33)
        Me.rbada.TabIndex = 0
        Me.rbada.TabStop = True
        Me.rbada.Text = "Ada"
        Me.rbada.UseVisualStyleBackColor = True
        '
        'txtnama
        '
        Me.txtnama.Location = New System.Drawing.Point(276, 85)
        Me.txtnama.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.txtnama.Name = "txtnama"
        Me.txtnama.Size = New System.Drawing.Size(336, 31)
        Me.txtnama.TabIndex = 18
        '
        'txtidparfume
        '
        Me.txtidparfume.Location = New System.Drawing.Point(276, 35)
        Me.txtidparfume.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.txtidparfume.Name = "txtidparfume"
        Me.txtidparfume.Size = New System.Drawing.Size(336, 31)
        Me.txtidparfume.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 35)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 29)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "ID Parfume"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 244)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 29)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Harga Parfume"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 29)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Nama Parfume"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Constantia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 140)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(172, 29)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Jenis Parfume"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(455, 51)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "PENDATAAN PARFUME"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global._pertemuan4.My.Resources.Resources._4e8c8a940e0b5fbc2f57fee088fa7928_removebg_preview
        Me.PictureBox1.Location = New System.Drawing.Point(448, -15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(168, 154)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'pendataan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(1148, 635)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Name = "pendataan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.kategori.ResumeLayout(False)
        Me.kategori.PerformLayout()
        Me.Alkohol.ResumeLayout(False)
        Me.Alkohol.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnsimpan As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtidparfume As System.Windows.Forms.TextBox
    Friend WithEvents txtnama As System.Windows.Forms.TextBox
    Friend WithEvents cbjenis As System.Windows.Forms.ComboBox
    Friend WithEvents txtharga As System.Windows.Forms.TextBox
    Friend WithEvents Alkohol As System.Windows.Forms.GroupBox
    Friend WithEvents rbtidakada As System.Windows.Forms.RadioButton
    Friend WithEvents rbada As System.Windows.Forms.RadioButton
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbukuran As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnkembali As System.Windows.Forms.Button
    Friend WithEvents kategori As System.Windows.Forms.GroupBox
    Friend WithEvents aquatic As System.Windows.Forms.CheckBox
    Friend WithEvents gourmand As System.Windows.Forms.CheckBox
    Friend WithEvents aromatic As System.Windows.Forms.CheckBox
    Friend WithEvents fresh As System.Windows.Forms.CheckBox
    Friend WithEvents oriental As System.Windows.Forms.CheckBox
    Friend WithEvents woody As System.Windows.Forms.CheckBox
    Friend WithEvents fruity As System.Windows.Forms.CheckBox
    Friend WithEvents floral As System.Windows.Forms.CheckBox
    Friend WithEvents cbbrand As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtJumlah As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
