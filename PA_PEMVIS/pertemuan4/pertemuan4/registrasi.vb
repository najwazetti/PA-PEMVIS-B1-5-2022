Imports MySql.Data.MySqlClient

Public Class registrasi
    Private Sub txtpassword_TextChanged(sender As Object, e As EventArgs) Handles txtpassword.TextChanged
        ' Jika checkbox cbshowpass tidak dicentang, maka mask password dengan bintang
        If Not cbshowpass.Checked Then
            txtpassword.PasswordChar = "*"c
            txtverifypass.PasswordChar = "*"c
        End If
    End Sub

    Private Sub cbshowpass_CheckedChanged(sender As Object, e As EventArgs) Handles cbshowpass.CheckedChanged
        ' Jika checkbox cbshowpass dicentang, maka tampilkan password
        If cbshowpass.Checked Then
            txtpassword.PasswordChar = ControlChars.NullChar
            txtverifypass.PasswordChar = ControlChars.NullChar
        Else
            txtpassword.PasswordChar = "*"c
            txtverifypass.PasswordChar = "*"c
        End If
    End Sub

    Private Function IsUsernameExist(Username_User As String) As Boolean
        Dim connStr As String = "server=localhost;userid=root;password=;database=parfume"
        Dim query As String = "SELECT COUNT(*) FROM datauser WHERE Username_User = @Username_User"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Username_User", Username_User)

                Try
                    connection.Open()
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return count > 0
                Catch ex As Exception
                    MessageBox.Show("Error while validating username: " & ex.Message)
                    Clear()
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Function IsEmailExist(Email_User As String) As Boolean
        Dim connStr As String = "server=localhost;userid=root;password=;database=parfume"
        Dim query As String = "SELECT COUNT(*) FROM datauser WHERE Email_User = @Email_User"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Email_User", Email_User)

                Try
                    connection.Open()
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return count > 0
                Catch ex As Exception
                    MessageBox.Show("Error while validating email: " & ex.Message)
                    Clear()
                    Return False
                End Try
            End Using
        End Using
    End Function

    ' Deklarasikan variabel global untuk menyimpan informasi pengguna
    Public Shared RegisteredUserName As String
    Public Shared RegisteredUserAddress As String

    Private Sub btnsignup_Click(sender As Object, e As EventArgs) Handles btnsignup.Click
        If String.IsNullOrWhiteSpace(txtusername.Text) OrElse String.IsNullOrWhiteSpace(txtemail.Text) OrElse String.IsNullOrWhiteSpace(txtpassword.Text) OrElse String.IsNullOrWhiteSpace(txtverifypass.Text) Then
            MessageBox.Show("Semua kolom harus diisi. Silakan lengkapi form registrasi.")
            Return
        End If

        Dim Address_User As String = txtaddress.Text
        Dim Username_User As String = txtusername.Text
        Dim Email_User As String = txtemail.Text
        Dim Password_User As String = txtpassword.Text
        Dim Name_User As String = txtname.Text


        If txtpassword.Text <> txtverifypass.Text Then
            MessageBox.Show("Password harus sama.")
            Return
        End If

        If IsUsernameExist(Username_User) Then
            MessageBox.Show("Username sudah digunakan. Silakan pilih username lain.")
            Clear()
            Return
        End If

        If IsEmailExist(Email_User) Then
            MessageBox.Show("Email sudah digunakan. Silakan gunakan email lain.")
            Clear()
            Return
        End If

        Dim success As Boolean = SaveToDatabase(Name_User, Username_User, Email_User, Password_User, Address_User)
        If success Then
            ' Simpan informasi pengguna dalam variabel global
            RegisteredUserName = Name_User
            RegisteredUserAddress = Address_User
            MessageBox.Show("Berhasil menyimpan informasi registrasi.")

            login.Show()
            Me.Hide()
        Else
            MessageBox.Show("Gagal menyimpan informasi registrasi.")
            Clear()
        End If
    End Sub

    Private Function SaveToDatabase(Name_User As String, Username_User As String, Email_User As String, Password_User As String, Address_User As String) As Boolean
        Dim connStr As String = "server=localhost;userid=root;password=;database=parfume"
        Dim query As String = "INSERT INTO datauser (Name_User, Username_User, Email_User, Password_User, Address_User) VALUES (@Name_User, @Username_User, @Email_User, @Password_User, @Address_User)"

        Using connection As New MySqlConnection(connStr)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Name_User", Name_User)
                command.Parameters.AddWithValue("@Username_User", Username_User)
                command.Parameters.AddWithValue("@Email_User", Email_User)
                command.Parameters.AddWithValue("@Password_User", Password_User)
                command.Parameters.AddWithValue("@Address_User", Address_User)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    MessageBox.Show("Error while saving data to database: " & ex.Message)
                    Clear()
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Clear()
        txtname.Clear()
        txtusername.Clear()
        txtemail.Clear()
        txtpassword.Clear()
        txtverifypass.Clear()
        txtusername.Focus()
        txtaddress.Clear()
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusername.Focus()
    End Sub


    Private Function Address_User() As Object
        Throw New NotImplementedException
    End Function

End Class
