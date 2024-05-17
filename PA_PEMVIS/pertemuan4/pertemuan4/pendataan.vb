Imports MySql.Data.MySqlClient

Public Class pendataan
    Private GroupBoxKategori As GroupBox
    Private GroupBoxAlkohol As GroupBox

    Public Sub New()
        InitializeComponent()

        GroupBoxKategori = kategori
        GroupBoxAlkohol = Alkohol

        ' Load data for ComboBox on form load
        LoadBrandData()
        LoadJenisData()

        ' Set ID_Parfume otomatis terbaca saat form dimuat
        Dim nextID As Integer = GetMaxParfumeID() + 1
        txtidparfume.Text = nextID.ToString()
    End Sub

    Private Sub LoadBrandData()
        cbbrand.Items.Clear() ' Clear existing items
        Dim connString As String = "server=localhost;user=root;password=;database=parfume"
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim query As String = "SELECT Brand_parfume FROM databrandpfm"
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        cbbrand.Items.Add(reader("Brand_parfume").ToString())
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadJenisData()
        cbjenis.Items.Clear() ' Clear existing items
        Dim connString As String = "server=localhost;user=root;password=;database=parfume"
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim query As String = "SELECT Jenis_parfume FROM datajenispfm"
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        cbjenis.Items.Add(reader("Jenis_parfume").ToString())
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Function GetMaxParfumeID() As Integer
        Dim maxID As Integer = 0
        Dim connString As String = "server=localhost;user=root;password=;database=parfume"
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim query As String = "SELECT MAX(ID_Parfume) FROM dataparfume"
            Using cmd As New MySqlCommand(query, conn)
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                    maxID = Convert.ToInt32(result)
                End If
            End Using
        End Using
        Return maxID
    End Function

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtidparfume.Text = "" OrElse txtnama.Text = "" OrElse txtharga.Text = "" OrElse txtJumlah.Text = "" OrElse
            cbukuran.SelectedItem Is Nothing OrElse cbbrand.SelectedItem Is Nothing OrElse cbjenis.SelectedItem Is Nothing OrElse
            DateTimePicker1.Value = Nothing OrElse (Not rbada.Checked AndAlso Not rbtidakada.Checked) Then
            MsgBox("Harap lengkapi semua inputan!", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        Dim harga As Decimal
        If Not Decimal.TryParse(txtharga.Text, harga) Then
            MsgBox("Harga harus berupa angka!", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        Dim stok As Integer
        If Not Integer.TryParse(txtJumlah.Text, stok) Then
            MsgBox("Stok harus berupa angka!", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        Dim connString As String = "server=localhost;user=root;password=;database=parfume"
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim query As String = "INSERT INTO dataparfume (ID_Parfume, Nama_Parfume, Jenis_Parfume, Harga_Parfume, Stok_Parfume, Ukuran_Parfume, Tanggal_Penambahan, Kategori_Parfume, Alkohol_Parfume, Brand_Parfume) " &
                                  "VALUES (@ID_Parfume, @Nama_Parfume, @Jenis_Parfume, @Harga_Parfume, @Stok_Parfume, @Ukuran_Parfume, @Tanggal_Penambahan, @Kategori_Parfume, @Alkohol_Parfume, @Brand_Parfume)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID_Parfume", txtidparfume.Text)
                cmd.Parameters.AddWithValue("@Nama_Parfume", txtnama.Text)
                cmd.Parameters.AddWithValue("@Jenis_Parfume", cbjenis.SelectedItem)
                cmd.Parameters.AddWithValue("@Harga_Parfume", harga)
                cmd.Parameters.AddWithValue("@Stok_Parfume", stok)
                cmd.Parameters.AddWithValue("@Ukuran_Parfume", cbukuran.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@Tanggal_Penambahan", DateTimePicker1.Value)
                cmd.Parameters.AddWithValue("@Kategori_Parfume", Getkategori())
                cmd.Parameters.AddWithValue("@Alkohol_Parfume", GetAlkohol())
                cmd.Parameters.AddWithValue("@Brand_Parfume", cbbrand.SelectedItem.ToString())
                cmd.ExecuteNonQuery()
            End Using
        End Using

        ' Ambil ID parfum maksimum dari database
        Dim nextID As Integer = GetMaxParfumeID() + 1
        ' Set nilai ID_Parfume ke TextBox
        txtidparfume.Text = nextID.ToString()

        MsgBox("Data parfum berhasil disimpan!", MsgBoxStyle.Information, "Sukses")

        BersihkanInput()

        Dim form2 As laporanparfume = CType(Application.OpenForms("Form2"), laporanparfume)
        If form2 IsNot Nothing Then
            form2.RefreshDataGridView()
        End If
    End Sub

    Private Sub BersihkanInput()
        'txtidparfume.Clear()
        txtnama.Clear()
        cbjenis.SelectedIndex = -1
        cbbrand.SelectedIndex = -1
        txtharga.Clear()
        cbukuran.SelectedIndex = -1
        rbada.Checked = False
        rbtidakada.Checked = False
        txtJumlah.Clear()
        'DateTimePicker1.Value = DateTime.Now
        Resetkategori()
        ResetAlkohol()
    End Sub

    Private Sub btnkembali_Click(sender As Object, e As EventArgs) Handles btnkembali.Click
        Me.Hide()
        menuadmin.Show()
    End Sub

    Private Function Getkategori() As String
        Dim kategori As String = ""
        For Each checkbox As CheckBox In GroupBoxKategori.Controls
            If TypeOf checkbox Is CheckBox AndAlso checkbox.Checked Then
                kategori += checkbox.Text & ", "
            End If
        Next
        Return kategori.TrimEnd(", ".ToCharArray())
    End Function

    Private Function GetAlkohol() As String
        If rbada.Checked Then
            Return "Ada"
        ElseIf rbtidakada.Checked Then
            Return "Tidak Ada"
        Else
            Return "Tidak Diketahui"
        End If
    End Function

    Private Sub Resetkategori()
        For Each checkbox As CheckBox In GroupBoxKategori.Controls
            If TypeOf checkbox Is CheckBox Then
                checkbox.Checked = False
            End If
        Next
    End Sub

    Private Sub ResetAlkohol()
        rbada.Checked = False
        rbtidakada.Checked = False
    End Sub

    Public Sub HanyaAngka(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtidparfume_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtidparfume.KeyPress
        HanyaAngka(e)
    End Sub

    Public Sub HanyaHuruf(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 65) And (tombol <= 90)) Or ((tombol >= 97) And (tombol <= 122)) Or (tombol = 8) Or (tombol = 32) Or (tombol = 46)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtnama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnama.KeyPress
        HanyaHuruf(e)
    End Sub

    Private Sub txtharga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtharga.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub txtJumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlah.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub pendataan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
