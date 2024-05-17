Public Class menuadmin

    Private Sub PendataanJenisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendataanJenisToolStripMenuItem.Click
        Me.Hide()
        jenis.Show()
    End Sub

    Private Sub PendataanBrandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendataanBrandToolStripMenuItem.Click
        Me.Hide()
        brand.Show()
    End Sub

    Private Sub PendataanParfumeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendataanParfumeToolStripMenuItem.Click
        Me.Hide()
        pendataan.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub LaporanDataParfumeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanDataParfumeToolStripMenuItem.Click
        Me.Hide()
        laporanparfume.Show()
    End Sub

    Private Sub LaporanPembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPembelianToolStripMenuItem.Click
        Me.Hide()
        laporankeranjang.Show()
    End Sub
End Class