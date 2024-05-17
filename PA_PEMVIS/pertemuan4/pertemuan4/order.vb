Imports MySql.Data.MySqlClient

Public Class order
    Dim connStr As String = "server=localhost;user=root;password=;database=parfume"
    Dim connection As MySqlConnection
    Dim adapter As MySqlDataAdapter
    Dim dataSet As DataSet

    Private Sub Clear()
        txtjumlahbarang.Clear()
        txtkodebarang.Clear()
        txtSearch.Clear()
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        RefreshDataGridView()
    End Sub

    Public Sub RefreshDataGridView()
        connection = New MySqlConnection(connStr)
        Dim query As String = "SELECT ID_Parfume, Nama_Parfume, Jenis_Parfume, Brand_Parfume, Harga_Parfume, Stok_Parfume FROM dataparfume WHERE Stok_Parfume > 0"
        adapter = New MySqlDataAdapter(query, connection)
        Dim dt As New DataTable()
        adapter.Fill(dt)

        DataGridView1.DataSource = dt

        ' Sembunyikan kolom Tanggal_Penambahan jika ada
        If DataGridView1.Columns.Contains("Tanggal_Penambahan") Then
            DataGridView1.Columns("Tanggal_Penambahan").Visible = False
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtkodebarang.Text = selectedRow.Cells("ID_Parfume").Value.ToString()
        End If
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Dim ID_Parfume As String = txtkodebarang.Text
        Dim jumlah As Integer
        If Not Integer.TryParse(txtjumlahbarang.Text, jumlah) OrElse jumlah <= 0 Then
            MessageBox.Show("Jumlah barang harus berupa angka positif.")
            Return
        End If

        If Not CheckStok(ID_Parfume, jumlah) Then
            MessageBox.Show("Stok barang tidak cukup.")
            Return
        End If

        Dim CurrentUsername As String = GetCurrentUsername()
        Dim Nama_Barang As String = GetNama_Barang(ID_Parfume)
        Dim Harga_Barang As Decimal = GetTotal_Harga(ID_Parfume)

        Using connection As New MySqlConnection(connStr)
            Dim query As String = "INSERT INTO datapesanan (ID_User, ID_Parfume, Nama_Barang, Jumlah_Barang, Total_Harga) VALUES (@ID_User, @ID_Parfume, @Nama_Barang, @Jumlah_Barang, @Total_Harga)"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID_User", LoggedUserId)
                command.Parameters.AddWithValue("@ID_Parfume", ID_Parfume)
                command.Parameters.AddWithValue("@Nama_Barang", Nama_Barang)
                command.Parameters.AddWithValue("@Jumlah_Barang", jumlah)
                command.Parameters.AddWithValue("@Total_Harga", Harga_Barang)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    UpdateStok(ID_Parfume, jumlah)
                    MessageBox.Show("Pesanan berhasil ditambahkan ke keranjang.")
                    Clear()
                Catch ex As Exception
                    MessageBox.Show("Error while saving order: " & ex.Message)
                End Try
            End Using
        End Using

        keranjang.RefreshKeranjang()
        RefreshDataGridView() ' Refresh DataGridView after updating stock
    End Sub

    Private Function GetIdRegisByCurrentUsername() As Integer
        Dim idRegis As Integer = 0
        Dim query As String = "SELECT id_user FROM datauser WHERE username_user = @username"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@username", Me.GetCurrentUsername)

                Try
                    connection.Open()
                    idRegis = Convert.ToInt32(command.ExecuteScalar())
                Catch ex As Exception
                    MessageBox.Show("Error while retrieving idRegis: " & ex.Message)
                End Try
            End Using
        End Using

        Return idRegis
    End Function

    Private Sub UpdateStok(ID_Parfume As String, jumlah As Integer)
        Using connection As New MySqlConnection(connStr)
            Dim query As String = "UPDATE dataparfume SET Stok_Parfume = Stok_Parfume - @jumlah WHERE ID_Parfume = @ID_Parfume"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@jumlah", jumlah)
                command.Parameters.AddWithValue("@ID_Parfume", ID_Parfume)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error while updating stock: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private currentUser As String = "exampleUser" ' Ganti dengan mekanisme yang sesuai untuk mendapatkan username saat ini

    Private Function GetCurrentUsername() As String
        Return currentUser
    End Function

    Private Function GetNama_Barang(ID_Parfume As String) As String
        Dim query As String = "SELECT Nama_Parfume FROM dataparfume WHERE ID_Parfume = @ID_Parfume"
        Dim namaBarang As String = ""

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID_Parfume", ID_Parfume)

                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        namaBarang = result.ToString()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error while fetching product name: " & ex.Message)
                End Try
            End Using
        End Using

        Return namaBarang
    End Function

    Private Function GetTotal_Harga(ID_Parfume As String) As Decimal
        Dim query As String = "SELECT Harga_Parfume FROM dataparfume WHERE ID_Parfume = @ID_Parfume"
        Dim harga As Decimal = 0

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID_Parfume", ID_Parfume)

                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        harga = Convert.ToDecimal(result)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error while fetching product price: " & ex.Message)
                End Try
            End Using
        End Using

        Return harga
    End Function

    Private Function CheckStok(ID_Parfume As String, jumlah As Integer) As Boolean
        Dim query As String = "SELECT Stok_Parfume FROM dataparfume WHERE ID_Parfume = @ID_Parfume"
        Dim stok As Integer = 0

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID_Parfume", ID_Parfume)

                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        stok = Convert.ToInt32(result)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error while checking stock: " & ex.Message)
                End Try
            End Using
        End Using

        Return stok >= jumlah
    End Function

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim query As String = "SELECT ID_Parfume, Nama_Parfume, Harga_Parfume, Stok_Parfume FROM dataparfume WHERE (ID_Parfume = @ID_Parfume OR Nama_Parfume LIKE @Nama_Parfume) AND Stok_Parfume > 0"

        Using connection As New MySqlConnection(connStr)
            Using adapter As New MySqlDataAdapter(query, connection)
                Dim idParfume As Integer
                If Integer.TryParse(txtSearch.Text, idParfume) Then
                    adapter.SelectCommand.Parameters.AddWithValue("@ID_Parfume", idParfume)
                    adapter.SelectCommand.Parameters.AddWithValue("@Nama_Parfume", "%" & txtSearch.Text & "%")
                Else
                    adapter.SelectCommand.Parameters.AddWithValue("@ID_Parfume", DBNull.Value)
                    adapter.SelectCommand.Parameters.AddWithValue("@Nama_Parfume", "%" & txtSearch.Text & "%")
                End If

                Dim dataSet As New DataSet()
                adapter.Fill(dataSet, "dataparfume")
                DataGridView1.DataSource = dataSet.Tables("dataparfume")

                ' Sembunyikan kolom Tanggal_Penambahan jika ada
                If DataGridView1.Columns.Contains("Tanggal_Penambahan") Then
                    DataGridView1.Columns("Tanggal_Penambahan").Visible = False
                End If
            End Using
        End Using
    End Sub

    ' Event untuk hanya menerima input angka positif di txtjumlahbarang
    Private Sub txtjumlahbarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtjumlahbarang.KeyPress
        Dim tombol As Integer = Asc(e.KeyChar)
        ' Hanya izinkan angka dan tombol backspace
        If Not (Char.IsDigit(e.KeyChar) Or tombol = 8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnlogout_Click(sender As Object, e As EventArgs) Handles btnlogout.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        keranjang.Show()
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        End
    End Sub

    Private Sub txtkodebarang_TextChanged(sender As Object, e As EventArgs) Handles txtkodebarang.TextChanged

    End Sub
End Class