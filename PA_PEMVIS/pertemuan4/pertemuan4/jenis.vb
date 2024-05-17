Imports MySql.Data.MySqlClient

Public Class jenis

    ' Deklarasi variabel koneksi dan command
    Private CONN As MySqlConnection
    Private CMD As MySqlCommand

    ' Metode untuk mengatur koneksi ke database
    Private Sub koneksi()
        Dim connStr As String = "server=localhost;userid=root;password=;database=parfume"
        CONN = New MySqlConnection(connStr)
        Try
            CONN.Open()
        Catch ex As Exception
            MessageBox.Show("Connection Error: " & ex.Message)
        End Try
    End Sub

    ' Konfigurasi DataGridView
    Private Sub ConfigureDataGridView()
        ' Clear existing columns
        DataGridView1.Columns.Clear()

        ' Add ID_Jenispfm column
        Dim idColumn As New DataGridViewTextBoxColumn()
        idColumn.Name = "ID_Jenispfm"
        idColumn.HeaderText = "ID Jenis Parfume"
        idColumn.DataPropertyName = "ID_Jenispfm"
        DataGridView1.Columns.Add(idColumn)

        ' Add Jenis_parfume column
        Dim jenisColumn As New DataGridViewTextBoxColumn()
        jenisColumn.Name = "Jenis_parfume"
        jenisColumn.HeaderText = "Jenis Parfume"
        jenisColumn.DataPropertyName = "Jenis_parfume"
        DataGridView1.Columns.Add(jenisColumn)
    End Sub

    ' Memuat data ke DataGridView
    Private Sub TampilkanData()
        ' Panggil fungsi koneksi
        koneksi()

        Try
            ' Buat perintah SQL untuk mengambil data dari tabel
            Dim query As String = "SELECT ID_Jenispfm, Jenis_parfume FROM datajenispfm"
            Dim adapter As New MySqlDataAdapter(query, CONN)
            Dim table As New DataTable()

            ' Isi DataTable dengan data dari database
            adapter.Fill(table)

            ' Set DataSource DataGridView ke DataTable
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Load Data Error: " & ex.Message)
        Finally
            ' Tutup koneksi
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try
    End Sub

    ' Handler untuk event klik tombol Simpan
    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        ' Ambil data dari TextBox
        Dim idJenis As String = txidjenis.Text
        Dim jenisParfum As String = txtjenispfm.Text

        ' Periksa apakah ada TextBox yang kosong
        If String.IsNullOrWhiteSpace(idJenis) Or String.IsNullOrWhiteSpace(jenisParfum) Then
            MessageBox.Show("ID Jenis dan Jenis Parfume tidak boleh kosong.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Panggil fungsi koneksi
        koneksi()

        Try
            ' Buat perintah SQL untuk memasukkan data ke dalam tabel
            Dim query As String = "INSERT INTO datajenispfm (ID_Jenispfm, Jenis_parfume) VALUES (@ID_Jenispfm, @Jenis_parfume)"
            CMD = New MySqlCommand(query, CONN)
            ' Tambahkan parameter untuk nilai idjenis dan jenisparfum
            CMD.Parameters.AddWithValue("@ID_Jenispfm", idJenis)
            CMD.Parameters.AddWithValue("@Jenis_parfume", jenisParfum)
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
        txidjenis.Text = ""
        txtjenispfm.Text = ""

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

        ' Ambil ID_Jenispfm dari DataGridView
        Dim idJenis As String = DataGridView1.CurrentRow.Cells("ID_Jenispfm").Value.ToString()
        Dim existingJenisParfum As String = DataGridView1.CurrentRow.Cells("Jenis_parfume").Value.ToString()

        ' Ambil data baru dari TextBox
        Dim jenisParfum As String = txtjenispfm.Text

        ' Periksa apakah TextBox kosong
        If String.IsNullOrWhiteSpace(jenisParfum) Then
            MessageBox.Show("Jenis Parfume tidak boleh kosong.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Panggil fungsi koneksi
        koneksi()

        ' Periksa apakah jenis parfum yang akan diubah sama dengan yang ada di database
        If jenisParfum = existingJenisParfum Then
            MessageBox.Show("Jenis Parfume sama dengan yang sebelumnya. Harap ubah jenis parfume terlebih dahulu.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lanjutkan proses ubah data
        Try
            ' Buat perintah SQL untuk mengubah data dalam tabel
            Dim query As String = "UPDATE datajenispfm SET Jenis_parfume = @Jenis_parfume WHERE ID_Jenispfm = @ID_Jenispfm"
            CMD = New MySqlCommand(query, CONN)
            ' Tambahkan parameter untuk nilai idJenis dan jenisParfum
            CMD.Parameters.AddWithValue("@ID_Jenispfm", idJenis)
            CMD.Parameters.AddWithValue("@Jenis_parfume", jenisParfum)
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
        txidjenis.Text = ""
        txtjenispfm.Text = ""

        ' Saat data diubah, panggil fungsi untuk menampilkan data terbaru di DataGridView
        TampilkanData()
    End Sub



    ' Handler untuk event klik tombol Hapus
    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        ' Ambil ID_Jenispfm dari DataGridView
        Dim idJenis As String = DataGridView1.CurrentRow.Cells("ID_Jenispfm").Value.ToString()

        ' Panggil fungsi koneksi
        koneksi()

        Try
            ' Buat perintah SQL untuk menghapus data dari tabel
            Dim query As String = "DELETE FROM datajenispfm WHERE ID_Jenispfm = @ID_Jenispfm"
            CMD = New MySqlCommand(query, CONN)
            ' Tambahkan parameter untuk nilai idjenis
            CMD.Parameters.AddWithValue("@ID_Jenispfm", idJenis)
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
        txidjenis.Text = ""
        txtjenispfm.Text = ""

        ' Saat data dihapus, panggil fungsi untuk menampilkan data terbaru di DataGridView
        TampilkanData()

    End Sub

    ' Handler untuk event klik tombol Kembali
    Private Sub btnkembali_Click(sender As Object, e As EventArgs) Handles btnkembali.Click
        ' Setelah data dimasukkan, kosongkan TextBox
        'txidjenis.Text = ""
        txtjenispfm.Text = ""

        Me.Hide()
        menuadmin.Show()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then ' Pastikan indeks baris valid
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txidjenis.Text = selectedRow.Cells("ID_Jenispfm").Value.ToString()
            txtjenispfm.Text = selectedRow.Cells("Jenis_parfume").Value.ToString()
        End If
    End Sub


    ' Handler untuk event load form
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Panggil fungsi untuk mendapatkan ID terakhir dan atur nilai TextBox
        txidjenis.Text = GetNextJenisID().ToString()

        ConfigureDataGridView()
        TampilkanData() ' Load data when the form loads
    End Sub

    ' Fungsi untuk mendapatkan ID_Jenispfm terakhir dari database
    Private Function GetMaxJenisID() As Integer
        Dim lastID As Integer = 0
        Try
            ' Panggil fungsi koneksi
            koneksi()

            ' Buat perintah SQL untuk mendapatkan ID terakhir
            Dim queryGetLastID As String = "SELECT MAX(ID_Jenispfm) FROM datajenispfm"
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

    ' Fungsi untuk mendapatkan ID_Jenispfm berikutnya
    Private Function GetNextJenisID() As Integer
        Dim lastID As Integer = GetMaxJenisID()
        Return lastID + 1
    End Function


End Class

