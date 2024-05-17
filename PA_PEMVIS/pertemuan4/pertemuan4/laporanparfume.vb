Imports MySql.Data.MySqlClient

Public Class laporanparfume
    Dim connectionString As String = "server=localhost;user=root;password=;database=parfume"
    Dim connection As MySqlConnection
    Dim adapter As MySqlDataAdapter
    Dim dataSet As DataSet

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshDataGridView()

    End Sub

    Public Sub RefreshDataGridView()
        connection = New MySqlConnection(connectionString)
        Dim query As String = "SELECT * FROM dataparfume"
        adapter = New MySqlDataAdapter(query, connection)
        Dim dt As New DataTable()
        adapter.Fill(dt)

        DataGridView1.DataSource = dt
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Me.Hide()
        If DataGridView1.CurrentRow IsNot Nothing Then
            Dim selectedRow As DataGridViewRow = DataGridView1.CurrentRow
            Dim idParfume As String = selectedRow.Cells("ID_Parfume").Value.ToString()
            Dim form3 As New updatedata(idParfume)
            If form3.ShowDialog() = DialogResult.OK Then
                RefreshDataGridView()
            End If
        Else
            MessageBox.Show("Pilih baris terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim rowIndex As Integer = DataGridView1.CurrentCell.RowIndex
        Dim selectedRow As DataGridViewRow = DataGridView1.Rows(rowIndex)
        Dim idParfume As String = selectedRow.Cells("ID_Parfume").Value.ToString()

        connection = New MySqlConnection(connectionString)
        connection.Open()

        Dim query As String = "DELETE FROM dataparfume WHERE ID_Parfume = @ID_Parfume"
        Dim command As New MySqlCommand(query, connection)
        command.Parameters.AddWithValue("@ID_Parfume", idParfume)
        command.ExecuteNonQuery()

        connection.Close()

        RefreshDataGridView()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim query As String = "SELECT * FROM dataparfume WHERE ID_Parfume = @ID_Parfume OR Nama_Parfume LIKE @Nama_Parfume"

        Using connection As New MySqlConnection(connectionString)
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
            End Using
        End Using
    End Sub

    Private Sub btnkembali_Click(sender As Object, e As EventArgs) Handles btnkembali.Click
        Me.Hide()
        menuadmin.Show()
    End Sub

    Private Sub btnkeluar_Click(sender As Object, e As EventArgs) Handles btnkeluar.Click
        End
    End Sub

End Class