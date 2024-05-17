Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class keranjang
    ' Deklarasi objek untuk cetak dokumen dan pratinjau cetak
    Private WithEvents printDoc As New PrintDocument()
    Private printPreview As New PrintPreviewDialog()

    ' Variabel untuk menyimpan nama dan alamat pengguna
    Private Name_User As String = ""
    Private Address_User As String = ""
    Private selectedItemId As Integer = -1

    ' Event handler untuk perubahan seleksi pada DataGridView
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            selectedItemId = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells(0).Value)
        Else
            selectedItemId = -1
        End If
    End Sub

    ' Event handler untuk saat form di-load
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi() ' Memanggil fungsi untuk koneksi ke database
        RefreshKeranjang() ' Memuat ulang data keranjang
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect ' Mengatur mode seleksi DataGridView
    End Sub

    ' Fungsi untuk memuat ulang data keranjang
    Public Sub RefreshKeranjang()
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim query As String = "SELECT * FROM datapesanan WHERE ID_User = @ID_User"

            DT = New DataTable
            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@ID_User", LoggedUserId)
            DA = New MySqlDataAdapter(CMD)
            DA.Fill(DT)
            DataGridView1.Columns.Clear()
            DataGridView1.DataSource = DT

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    ' Fungsi untuk mendapatkan username saat ini (contoh saja, disesuaikan dengan mekanisme penyimpanan username)
    Private Function GetCurrentUsername() As String
        Return "exampleUser"
    End Function

    ' Event handler untuk tombol checkout
    Private Sub btncheckout_Click(sender As Object, e As EventArgs) Handles btncheckout.Click
        ' Tampilkan kotak dialog konfirmasi
        Dim result As DialogResult = MessageBox.Show("Yakin akan membeli barang?", "Konfirmasi Pembelian", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Ambil data pengguna sebelum menampilkan pratinjau cetak
            GetUserData()
            printPreview.Document = printDoc
            AddHandler printDoc.EndPrint, AddressOf printDoc_EndPrint ' Tambahkan event handler untuk EndPrint
            printPreview.ShowDialog()
        End If
    End Sub

    ' Fungsi untuk mendapatkan data pengguna dari database
    Private Sub GetUserData()
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim query As String = "SELECT Name_User, Address_User FROM datauser WHERE ID_User = @ID_User"

            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@ID_User", LoggedUserId)
            RD = CMD.ExecuteReader()

            If RD.HasRows Then
                While RD.Read()
                    Name_User = RD("Name_User").ToString()
                    Address_User = RD("Address_User").ToString()
                End While
            End If

            RD.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Public Sub LoadUserCart(userId As Integer)
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim query As String = "SELECT * FROM datapesanan WHERE ID_User = @ID_User"

            DT = New DataTable
            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@ID_User", userId)
            DA = New MySqlDataAdapter(CMD)
            DA.Fill(DT)
            DataGridView1.Columns.Clear()
            DataGridView1.DataSource = DT

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    ' Fungsi untuk mendapatkan harga parfum berdasarkan ID parfum dari tabel dataparfume
    Private Function GetHargaParfum(idParfume As String) As Decimal
        Dim price As Decimal = 0
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If

            Dim query As String = "SELECT Harga_Parfume FROM dataparfume WHERE ID_Parfume = @ID_Parfume"
            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@ID_Parfume", idParfume)
            Dim result = CMD.ExecuteScalar()
            If result IsNot Nothing Then
                price = Convert.ToDecimal(result)
            End If
        Catch ex As Exception
            MsgBox("Error getting price of item: " & ex.Message)
        End Try
        Return price
    End Function

    ' Event handler untuk cetak halaman
    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDoc.PrintPage
        Dim fontHeader As New Font("Arial", 20, FontStyle.Bold)
        Dim fontSubHeader As New Font("Arial", 16, FontStyle.Bold)
        Dim fontRegular As New Font("Arial", 12)
        Dim fontItalic As New Font("Arial", 12, FontStyle.Italic)
        Dim brush As New SolidBrush(Color.Black)
        Dim pen As New Pen(Color.Black)
        Dim startX As Integer = 50
        Dim startY As Integer = 50
        Dim offset As Integer = 40

        ' Header
        e.Graphics.DrawString("Receipt", fontHeader, brush, startX, startY)
        e.Graphics.DrawString("Parfume Store", fontSubHeader, brush, startX, startY + offset)
        offset += 40

        ' Garis dekoratif
        e.Graphics.DrawLine(pen, startX, startY + offset, startX + 700, startY + offset)
        offset += 20

        ' Nama dan Alamat Pengguna
        e.Graphics.DrawString("Name: " & Name_User, fontRegular, brush, startX, startY + offset)
        offset += 20
        e.Graphics.DrawString("Address: " & Address_User, fontRegular, brush, startX, startY + offset)
        offset += 20

        ' Tanggal dan Waktu
        e.Graphics.DrawString("Date: " & DateTime.Now.ToString("dd/MM/yyyy"), fontRegular, brush, startX, startY + offset)
        offset += 20
        e.Graphics.DrawString("Time: " & DateTime.Now.ToString("HH:mm:ss"), fontRegular, brush, startX, startY + offset)
        offset += 20

        ' Garis dekoratif
        e.Graphics.DrawLine(pen, startX, startY + offset, startX + 700, startY + offset)
        offset += 20

        ' Header tabel
        e.Graphics.DrawString("Item", fontSubHeader, brush, startX, startY + offset)
        e.Graphics.DrawString("Quantity", fontSubHeader, brush, startX + 300, startY + offset)
        e.Graphics.DrawString("Price", fontSubHeader, brush, startX + 450, startY + offset)
        e.Graphics.DrawString("Total", fontSubHeader, brush, startX + 600, startY + offset)
        offset += 30

        ' Garis dekoratif
        e.Graphics.DrawLine(pen, startX, startY + offset, startX + 700, startY + offset)
        offset += 20

        ' Data
        Dim grandTotal As Decimal = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For
            Dim item As String = row.Cells("Nama_Barang").Value.ToString()
            Dim quantity As Integer = Convert.ToInt32(row.Cells("Jumlah_Barang").Value)
            Dim idParfume As String = row.Cells("ID_Parfume").Value.ToString()
            ' Mendapatkan harga parfum berdasarkan ID parfume
            Dim price As Decimal = GetHargaParfum(idParfume)

            ' Menghitung total harga berdasarkan harga parfum dan kuantitas
            Dim total As Decimal = quantity * price

            e.Graphics.DrawString(item, fontRegular, brush, startX, startY + offset)
            e.Graphics.DrawString(quantity.ToString(), fontRegular, brush, startX + 300, startY + offset)
            e.Graphics.DrawString(price.ToString("C2"), fontRegular, brush, startX + 450, startY + offset)
            e.Graphics.DrawString(total.ToString("C2"), fontRegular, brush, startX + 600, startY + offset)

            grandTotal += total
            offset += 20
        Next

        ' Garis dekoratif
        e.Graphics.DrawLine(pen, startX, startY + offset, startX + 700, startY + offset)
        offset += 20

        ' Total keseluruhan
        e.Graphics.DrawString("Grand Total:", fontSubHeader, brush, startX + 450, startY + offset)
        e.Graphics.DrawString(grandTotal.ToString("C2"), fontSubHeader, brush, startX + 600, startY + offset)
        offset += 40

        ' Footer
        e.Graphics.DrawString("Thank you for your purchase!", fontItalic, brush, startX, startY + offset)
        offset += 20
        e.Graphics.DrawString("Please visit us again!", fontItalic, brush, startX, startY + offset)

        ' Garis dekoratif terakhir
        offset += 40
        e.Graphics.DrawLine(pen, startX, startY + offset, startX + 700, startY + offset)
    End Sub


    ' Event handler untuk menghapus item dari keranjang setelah selesai mencetak
    Private Sub printDoc_EndPrint(sender As Object, e As PrintEventArgs)
        DeleteCartItems()
    End Sub

    ' Fungsi untuk menghapus item dari keranjang di database
    Private Sub DeleteCartItems()
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
            Dim query As String = "DELETE FROM datapesanan WHERE ID_User = @ID_User"
            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@ID_User", LoggedUserId)
            CMD.ExecuteNonQuery()
            RefreshKeranjang()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Try
            If DataGridView1.SelectedRows.Count > 0 Then ' Pastikan ada baris yang dipilih
                Dim idPesanan As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ID_Pesanan").Value)
                Dim stokYangDihapus As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("Jumlah_Barang").Value)
                Dim idParfume As String = DataGridView1.SelectedRows(0).Cells("ID_Parfume").Value.ToString()

                If CONN.State = ConnectionState.Closed Then
                    CONN.Open()
                End If

                Dim query As String = "DELETE FROM datapesanan WHERE ID_Pesanan = @ID_Pesanan"
                CMD = New MySqlCommand(query, CONN)
                CMD.Parameters.AddWithValue("@ID_Pesanan", idPesanan)
                CMD.ExecuteNonQuery()

                RefreshKeranjang() ' Perbarui tampilan keranjang setelah menghapus item

                ' Tambahkan stok yang dihapus kembali ke stok barang di form order
                UpdateStok(idParfume, stokYangDihapus)
            Else
                MsgBox("No item selected.") ' Jika tidak ada baris yang dipilih
            End If
        Catch ex As Exception
            MsgBox("Error deleting item: " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateStok(ID_Parfume As String, jumlah As Integer)
        Dim connStr As String = "server=localhost;user=root;password=;database=parfume"

        Try
            Using connection As New MySqlConnection(connStr)
                connection.Open()

                Dim query As String = "UPDATE dataparfume SET Stok_Parfume = Stok_Parfume + @jumlah WHERE ID_Parfume = @ID_Parfume"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@jumlah", jumlah)
                    command.Parameters.AddWithValue("@ID_Parfume", ID_Parfume)
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error while updating stock: " & ex.Message)
        End Try
    End Sub


    ' Fungsi untuk mendapatkan jumlah barang dari keranjang berdasarkan ID_Pesanan
    Private Function GetJumlahBarang(idPesanan As Integer) As Integer
        Dim jumlah As Integer = 0
        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If

            Dim query As String = "SELECT Jumlah_Barang FROM datapesanan WHERE ID_Pesanan = @ID_Pesanan"
            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@ID_Pesanan", idPesanan)
            Dim result = CMD.ExecuteScalar()
            If result IsNot Nothing Then
                jumlah = Convert.ToInt32(result)
            End If
        Catch ex As Exception
            MsgBox("Error getting quantity of item: " & ex.Message)
        End Try
        Return jumlah
    End Function

    ' Event handler untuk tombol kembali ke halaman order di form keranjang
    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        ' Menyembunyikan form keranjang
        Me.Hide()

        ' Menampilkan kembali form order
        order.Show()

        ' Memanggil fungsi RefreshOrder dari form order untuk memperbarui data order
        order.RefreshDataGridView()
    End Sub

End Class