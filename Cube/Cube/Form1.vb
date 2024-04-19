Public Class Form1
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox1.BackColor = Color.White
        Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim g As Graphics = Graphics.FromImage(canvas)
        g.DrawLine(Pens.Black, 50, 50, 250, 50)
        g.DrawLine(Pens.Black, 250, 50, 270, 20)
        g.DrawLine(Pens.Black, 270, 20, 70, 20)
        g.DrawLine(Pens.Black, 70, 20, 50, 50)
        g.DrawLine(Pens.Black, 50, 50, 50, 250)
        g.DrawLine(Pens.Black, 250, 50, 250, 250)
        g.DrawLine(Pens.Black, 270, 20, 270, 220)
        g.DrawLine(Pens.Black, 70, 20, 70, 220)
        g.DrawLine(Pens.Black, 50, 250, 250, 250)
        g.DrawLine(Pens.Black, 250, 250, 270, 220)
        g.DrawLine(Pens.Black, 270, 220, 70, 220)
        g.DrawLine(Pens.Black, 70, 220, 50, 250)
        PictureBox1.Image = canvas
    End Sub
End Class
