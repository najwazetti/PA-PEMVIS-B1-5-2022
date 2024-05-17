Imports MySql.Data.MySqlClient

Public Class login
    Public Function ValidateLogin(username As String, password As String) As Boolean
        Dim query As String = "SELECT ID_User FROM datauser WHERE Username_User = @Username_User AND Password_User = @Password_User"

        CMD = New MySqlCommand(query, CONN)
        CMD.Parameters.AddWithValue("@Username_User", username)
        CMD.Parameters.AddWithValue("@Password_User", password)

        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If

            ' Debugging: log parameter values
            Console.WriteLine("Username_User: " & username)
            Console.WriteLine("Password_User: " & password)

            RD = CMD.ExecuteReader()

            If RD.HasRows Then
                While RD.Read()
                    LoggedUserId = RD.GetInt32(0)
                End While
                Return True
            Else
                ' Debugging: no rows found
                Console.WriteLine("No rows found for the given username and password.")
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Error while validating login: " & ex.Message)
            Return False
        Finally
            If RD IsNot Nothing Then
                RD.Close()  ' Ensure the reader is closed
            End If
            If CONN IsNot Nothing AndAlso CONN.State = ConnectionState.Open Then
                CONN.Close()  ' Ensure the connection is closed
            End If
        End Try
    End Function


    Private Sub txtpassword_TextChanged(sender As Object, e As EventArgs) Handles txtpassword.TextChanged
        ' Jika checkbox cbshowpass tidak dicentang, maka mask password dengan bintang
        If Not cbshowpass.Checked Then
            txtpassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub cbshowpass_CheckedChanged(sender As Object, e As EventArgs) Handles cbshowpass.CheckedChanged
        ' Jika checkbox cbshowpass dicentang, maka tampilkan password
        If cbshowpass.Checked Then
            txtpassword.PasswordChar = ""
        Else
            txtpassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        ' Cek apakah username dan password sesuai dengan yang diinginkan
        If txtusername.Text = "username" AndAlso txtpassword.Text = "password" Then
            ' Jika sesuai, tampilkan form menu
            Dim menuForm As New menuadmin()
            menuForm.Show()
            Me.Hide()

        ElseIf ValidateLogin(txtusername.Text, txtpassword.Text) Then
            ' Jika login berhasil
            ' Simpan ID pengguna yang login ke variabel global LoggedUserId
            LoggedUserId = GetUserIdByUsername(txtusername.Text)

            ' Memuat data keranjang pengguna dari database
            keranjang.RefreshKeranjang()
            order.Show()
            Me.Hide()

        Else
            ' Jika tidak sesuai, tampilkan pesan kesalahan
            MessageBox.Show("Username atau password salah!")
        End If

        ' Setelah berhasil login, bersihkan inputan
        txtusername.Text = ""
        txtpassword.Text = ""

    End Sub

    Private Function GetUserIdByUsername(username As String) As Integer
        Dim userId As Integer = 0
        Dim query As String = "SELECT ID_User FROM datauser WHERE Username_User = @Username_User"

        Try
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If

            CMD = New MySqlCommand(query, CONN)
            CMD.Parameters.AddWithValue("@Username_User", username)

            Dim result = CMD.ExecuteScalar()
            If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                userId = Convert.ToInt32(result)
            End If
        Catch ex As Exception
            MessageBox.Show("Error retrieving user ID: " & ex.Message)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try

        Return userId
    End Function


    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnsignup_Click(sender As Object, e As EventArgs) Handles btnsignup.Click
        registrasi.Show()
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub
End Class