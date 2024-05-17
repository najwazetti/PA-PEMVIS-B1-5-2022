Imports MySql.Data.MySqlClient

Public Class updatedata

    Private GroupBoxKategori As GroupBox
    Private GroupBoxAlkohol As GroupBox
    Private _idParfume As String

    Public Sub New()
        InitializeComponent()

        GroupBoxKategori = kategori
        GroupBoxAlkohol = Alkohol
    End Sub

    Sub New(idParfume As String)
        InitializeComponent()

        Dim connString As String = "server=localhost;user=root;password=;database=parfume"
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim query As String = "SELECT * FROM dataparfume WHERE ID_Parfume = @ID_Parfume"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID_Parfume", idParfume)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    txtnama.Text = reader("Nama_Parfume").ToString()
                    txtharga.Text = reader("Harga_Parfume").ToString()
                    cbukuran.Text = reader("Ukuran_Parfume").ToString()
                    txtJumlah.Text = reader("Stok_Parfume").ToString()
                    cbbrand.Text = reader("Brand_Parfume").ToString()
                    cbjenis.Text = reader("Jenis_Parfume").ToString()
                End If
            End Using
        End Using

        GroupBoxKategori = kategori
        GroupBoxAlkohol = Alkohol

        _idParfume = idParfume
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label8.Text = _idParfume

        ' Mengisi ComboBox cbjenis dengan data unik dari tabel datajenispfm
        Dim connString As String = "server=localhost;user=root;password=;database=parfume"
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim queryJenis As String = "SELECT DISTINCT Jenis_Parfume FROM datajenispfm"
            Using cmdJenis As New MySqlCommand(queryJenis, conn)
                Using readerJenis As MySqlDataReader = cmdJenis.ExecuteReader()
                    While readerJenis.Read()
                        cbjenis.Items.Add(readerJenis("Jenis_Parfume").ToString())
                    End While
                End Using
            End Using

            ' Mengisi ComboBox cbbrand dengan data unik dari tabel databrandpfm
            Dim queryBrand As String = "SELECT DISTINCT Brand_Parfume FROM databrandpfm"
            Using cmdBrand As New MySqlCommand(queryBrand, conn)
                Using readerBrand As MySqlDataReader = cmdBrand.ExecuteReader()
                    While readerBrand.Read()
                        cbbrand.Items.Add(readerBrand("Brand_Parfume").ToString())
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        ' Validasi input
        If txtnama.Text = "" OrElse txtharga.Text = "" OrElse txtJumlah.Text = "" OrElse
           cbukuran.SelectedItem Is Nothing OrElse cbbrand.SelectedItem Is Nothing OrElse cbjenis.SelectedItem Is Nothing OrElse
           DateTimePicker1.Value = Nothing OrElse (Not rbada.Checked AndAlso Not rbtidakada.Checked) Then
            MsgBox("Harap lengkapi semua inputan!", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        ' Validasi harga
        Dim harga As Decimal
        If Not Decimal.TryParse(txtharga.Text, harga) Then
            MsgBox("Harga harus berupa angka!", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        ' Update data di database
        Dim connString As String = "server=localhost;user=root;password=;database=parfume"
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim query As String = "UPDATE dataparfume SET Nama_Parfume = @Nama_Parfume, Harga_Parfume = @Harga_Parfume, Stok_Parfume = @Stok_Parfume, Ukuran_Parfume = @Ukuran_Parfume, Tanggal_Penambahan = @Tanggal_Penambahan, Kategori_Parfume = @Kategori_Parfume, Alkohol_Parfume = @Alkohol_Parfume, Brand_Parfume = @Brand_Parfume, Jenis_Parfume = @Jenis_Parfume WHERE ID_Parfume = @ID_Parfume"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID_Parfume", _idParfume)
                cmd.Parameters.AddWithValue("@Nama_Parfume", txtnama.Text)
                cmd.Parameters.AddWithValue("@Harga_Parfume", harga)
                cmd.Parameters.AddWithValue("@Stok_Parfume", txtJumlah.Text)
                cmd.Parameters.AddWithValue("@Ukuran_Parfume", cbukuran.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@Tanggal_Penambahan", DateTimePicker1.Value)
                cmd.Parameters.AddWithValue("@Kategori_Parfume", Getkategori())
                cmd.Parameters.AddWithValue("@Alkohol_Parfume", GetAlkohol())
                cmd.Parameters.AddWithValue("@Brand_Parfume", cbbrand.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@Jenis_Parfume", cbjenis.SelectedItem.ToString())
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MsgBox("Data parfum berhasil diupdate!", MsgBoxStyle.Information, "Sukses")

        ' Bersihkan input dan tutup form
        BersihkanInput()
        Me.Hide()
        menuadmin.Show()

        ' Refresh data grid view di Form2
        Dim form2 As laporanparfume = CType(Application.OpenForms("laporanparfume"), laporanparfume)
        If form2 IsNot Nothing Then
            form2.RefreshDataGridView()
        End If
    End Sub

    Private Sub BersihkanInput()
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

    Private Function Getkategori() As String
        Dim kategori As String = ""
        For Each control As Control In GroupBoxKategori.Controls
            If TypeOf control Is CheckBox Then
                Dim checkbox As CheckBox = CType(control, CheckBox)
                If checkbox.Checked Then
                    kategori += checkbox.Text & ", "
                End If
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
        For Each control As Control In GroupBoxKategori.Controls
            If TypeOf control Is CheckBox Then
                Dim checkbox As CheckBox = CType(control, CheckBox)
                checkbox.Checked = False
            End If
        Next
    End Sub

    Private Sub ResetAlkohol()
        rbada.Checked = False
        rbtidakada.Checked = False
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluaraplikasi.Click
        Me.Hide()
        laporanparfume.Show()
    End Sub

    Private Sub txtnama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnama.KeyPress
        HanyaHuruf(e)
    End Sub

    Private Sub txtharga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtharga.KeyPress
        HanyaAngka(e)
    End Sub

    Public Sub HanyaHuruf(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 65) And (tombol <= 90)) Or ((tombol >= 97) And (tombol <= 122)) Or (tombol = 8) Or (tombol = 32) Or (tombol = 46)) Then
            e.Handled = True
        End If
    End Sub

    Public Sub HanyaAngka(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8)) Then
            e.Handled = True
        End If
    End Sub

End Class