Imports MySql.Data.MySqlClient

Public Class brand
    ' Deklarasikan koneksi ke database menggunakan MySQL
    Dim connectionString As String = "server=localhost;user=root;password=;database=parfume"
    Private CONN As MySqlConnection
    Private CMD As MySqlCommand
    Private RD As MySqlDataReader

    ' Metode untuk mengatur koneksi ke database
    Private Sub koneksi()
        CONN = New MySqlConnection(connectionString)
        Try
            CONN.Open()
        Catch ex As Exception
            MessageBox.Show("Connection Error: " & ex.Message)
        End Try
    End Sub

    ' Handler untuk event klik tombol Simpan
    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        ' Ambil data dari TextBox
        Dim idBrand As String = txtidbrand.Text
        Dim brandParfum As String = txtbrand.Text

        ' Periksa apakah ada TextBox yang kosong
        If String.IsNullOrWhiteSpace(idBrand) Or String.IsNullOrWhiteSpace(brandParfum) Then
            MessageBox.Show("ID Brand dan Brand Parfume tidak boleh kosong.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Panggil fungsi koneksi
        koneksi()

        Try
            ' Buat perintah SQL untuk memasukkan data ke dalam tabel
            Dim query As String = "INSERT INTO databrandpfm (ID_Brandpfm, Brand_parfume) VALUES (@ID_Brandpfm, @Brand_parfume)"
            CMD = New MySqlCommand(query, CONN)
            ' Tambahkan parameter untuk nilai idBrand dan brandParfum
            CMD.Parameters.AddWithValue("@ID_Brandpfm", idBrand)
            CMD.Parameters.AddWithValue("@Brand_parfume", brandParfum)
            ' Eksekusi perintah SQL
            CMD.ExecuteNonQuery()

            ' Tampilkan pesan berhasil
            MessageBox.Show("Data berhasil disimpan ke database.")
        Catch ex As Exception
            MessageBox.Show("Insert Error: " & ex.Message)
        Finally
            ' Tutup koneksi
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try

        ' Setelah data dimasukkan, kosongkan TextBox
        txtidbrand.Text = ""
        txtbrand.Text = ""

        ' Saat data baru ditambahkan, panggil fungsi untuk menampilkan data terbaru di DataGridView
        TampilkanData()
    End Sub

    ' Handler untuk event klik tombol Ubah
    Private Sub btnubah_Click(sender As Object, e As EventArgs) Handles btnubah.Click
        ' Pastikan ada baris yang dipilih di DataGridView
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih data yang ingin diubah.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Ambil ID_Brandpfm dan brand parfum dari DataGridView
        Dim idBrand As String = DataGridView1.CurrentRow.Cells("ID_Brandpfm").Value.ToString()
        Dim existingBrand As String = DataGridView1.CurrentRow.Cells("Brand_parfume").Value.ToString()

        ' Ambil data baru dari TextBox
        Dim brandParfum As String = txtbrand.Text

        ' Periksa apakah TextBox kosong
        If String.IsNullOrWhiteSpace(brandParfum) Then
            MessageBox.Show("Brand Parfume tidak boleh kosong.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Panggil fungsi koneksi
        koneksi()

        ' Periksa apakah brand parfum yang akan diubah sama dengan yang ada di database
        If brandParfum = existingBrand Then
            MessageBox.Show("Brand Parfume sama dengan yang sebelumnya. Harap ubah brand terlebih dahulu.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lanjutkan proses ubah data
        Try
            ' Buat perintah SQL untuk mengubah data dalam tabel
            Dim query As String = "UPDATE databrandpfm SET Brand_parfume = @Brand_parfume WHERE ID_Brandpfm = @ID_Brandpfm"
            CMD = New MySqlCommand(query, CONN)
            ' Tambahkan parameter untuk nilai idBrand dan brandParfum
            CMD.Parameters.AddWithValue("@ID_Brandpfm", idBrand)
            CMD.Parameters.AddWithValue("@Brand_parfume", brandParfum)
            ' Eksekusi perintah SQL
            CMD.ExecuteNonQuery()

            ' Tampilkan pesan berhasil
            MessageBox.Show("Data berhasil diubah.")
        Catch ex As Exception
            MessageBox.Show("Update Error: " & ex.Message)
        Finally
            ' Tutup koneksi
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try

        ' Setelah data diubah, kosongkan TextBox
        txtidbrand.Text = ""
        txtbrand.Text = ""

        ' Saat data diubah, panggil fungsi untuk menampilkan data terbaru di DataGridView
        TampilkanData()
    End Sub


    ' Handler untuk event klik tombol Hapus
    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        ' Pastikan ada baris yang dipilih di DataGridView
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Pilih data yang ingin dihapus.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Ambil ID_Brandpfm dari DataGridView
        Dim idBrand As String = DataGridView1.CurrentRow.Cells("ID_Brandpfm").Value.ToString()

        ' Panggil fungsi koneksi
        koneksi()

        Try
            ' Buat perintah SQL untuk menghapus data dari tabel
            Dim query As String = "DELETE FROM databrandpfm WHERE ID_Brandpfm = @ID_Brandpfm"
            CMD = New MySqlCommand(query, CONN)
            ' Tambahkan parameter untuk nilai idbrand
            CMD.Parameters.AddWithValue("@ID_Brandpfm", idBrand)
            ' Eksekusi perintah SQL
            CMD.ExecuteNonQuery()

            ' Tampilkan pesan berhasil
            MessageBox.Show("Data berhasil dihapus.")
        Catch ex As Exception
            MessageBox.Show("Delete Error: " & ex.Message)
        Finally
            ' Tutup koneksi
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try

        ' Setelah data dihapus, kosongkan TextBox
        txtidbrand.Text = ""
        txtbrand.Text = ""

        ' Saat data dihapus, panggil fungsi untuk menampilkan data terbaru di DataGridView
        TampilkanData()
    End Sub



    ' Handler untuk event klik tombol Kembali
    Private Sub btnkembali_Click(sender As Object, e As EventArgs) Handles btnkembali.Click
        ' Setelah data dimasukkan, kosongkan TextBox
        'txtidbrand.Text = ""
        txtbrand.Text = ""

        Me.Hide()
        menuadmin.Show()
    End Sub

    ' Handler untuk event load form
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Panggil fungsi untuk mendapatkan ID terakhir dan atur nilai TextBox
        txtidbrand.Text = GetNextBrandID().ToString()

        ConfigureDataGridView()
        TampilkanData() ' Load data when the form loads
    End Sub

    ' Fungsi untuk mendapatkan ID_Brandpfm terakhir dari database
    Private Function GetMaxBrandID() As Integer
        Dim lastID As Integer = 0
        Try
            ' Panggil fungsi koneksi
            koneksi()

            ' Buat perintah SQL untuk mendapatkan ID terakhir
            Dim queryGetLastID As String = "SELECT MAX(ID_Brandpfm) FROM databrandpfm"
            CMD = New MySqlCommand(queryGetLastID, CONN)
            Dim result As Object = CMD.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                lastID = Convert.ToInt32(result)
            End If
        Catch ex As Exception
            MessageBox.Show("Error while getting last ID: " & ex.Message)
        Finally
            ' Tutup koneksi
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try

        Return lastID
    End Function

    ' Fungsi untuk mendapatkan ID_Brandpfm berikutnya
    Private Function GetNextBrandID() As Integer
        Dim lastID As Integer = GetMaxBrandID()
        Return lastID + 1
    End Function


    ' Konfigurasi DataGridView
    Private Sub ConfigureDataGridView()
        ' Clear existing columns
        DataGridView1.Columns.Clear()

        ' Add ID_Brandpfm column
        Dim idColumn As New DataGridViewTextBoxColumn()
        idColumn.Name = "ID_Brandpfm"
        idColumn.HeaderText = "ID Brand Parfume"
        idColumn.DataPropertyName = "ID_Brandpfm"
        DataGridView1.Columns.Add(idColumn)

        ' Add Brand_parfume column
        Dim brandColumn As New DataGridViewTextBoxColumn()
        brandColumn.Name = "Brand_parfume"
        brandColumn.HeaderText = "Brand Parfume"
        brandColumn.DataPropertyName = "Brand_parfume"
        DataGridView1.Columns.Add(brandColumn)
    End Sub

    ' Memuat data ke DataGridView
    Private Sub TampilkanData()
        ' Panggil fungsi koneksi
        koneksi()

        Try
            ' Buat perintah SQL untuk mengambil data dari tabel databrandpfm
            Dim query As String = "SELECT ID_Brandpfm, Brand_parfume FROM databrandpfm"
            Dim adapter As New MySqlDataAdapter(query, CONN)
            Dim dataTable As New DataTable()

            ' Isi DataTable dengan data dari database
            adapter.Fill(dataTable)

            ' Set DataSource DataGridView ke DataTable
            DataGridView1.DataSource = dataTable
        Catch ex As Exception
            MessageBox.Show("Fetch Error: " & ex.Message)
        Finally
            ' Tutup koneksi
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
    End Sub

    ' Event handler untuk DataGridView CellClick
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then ' Pastikan indeks baris valid
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtidbrand.Text = selectedRow.Cells("ID_Brandpfm").Value.ToString()
            txtbrand.Text = selectedRow.Cells("Brand_parfume").Value.ToString()
        End If
    End Sub


    ' Hanya menerima input huruf
    Public Sub HanyaHuruf(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 65) And (tombol <= 90)) Or ((tombol >= 97) And (tombol <= 122)) Or (tombol = 8) Or (tombol = 32) Or (tombol = 46)) Then
            e.Handled = True
        End If
    End Sub

    ' Hanya menerima input angka
    Public Sub HanyaAngka(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8)) Then
            e.Handled = True
        End If
    End Sub

    ' Event untuk hanya menerima input angka di txtidbrand
    Private Sub txtidbrand_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtidbrand.KeyPress
        HanyaAngka(e)
    End Sub

    ' Event untuk hanya menerima input huruf di txtbrand
    Private Sub txtbrand_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbrand.KeyPress
        HanyaHuruf(e)
    End Sub

End Class
