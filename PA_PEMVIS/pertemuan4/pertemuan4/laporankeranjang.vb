Imports MySql.Data.MySqlClient

Public Class laporankeranjang
    Private connStr As String = "server=localhost;userid=root;password=;database=parfume"
    Dim connection As MySqlConnection
    Dim adapter As MySqlDataAdapter
    Dim dataSet As DataSet

    Private Sub laporanpembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshDataGridView()

    End Sub

    Public Sub RefreshDataGridView()
        connection = New MySqlConnection(connStr)
        Dim query As String = "SELECT * FROM datapesanan"
        adapter = New MySqlDataAdapter(query, connection)
        Dim dt As New DataTable()
        adapter.Fill(dt)

        DataGridView1.DataSource = dt
    End Sub

    Private Sub ReloadGridView()
        Using conn As New MySqlConnection(connStr)
            Try
                conn.Open()
                Dim sql As String = "SELECT * FROM datapesanan"
                Dim dt As New DataTable
                Using cmd As New MySqlCommand(sql, conn)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
                DataGridView1.Columns.Clear()
                DataGridView1.DataSource = dt

            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ReloadGridView()
    End Sub

    Private Sub btnkembali_Click(sender As Object, e As EventArgs) Handles btnkembali.Click
        Me.Hide()
        menuadmin.Show()
    End Sub

End Class