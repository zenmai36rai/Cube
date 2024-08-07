﻿Public Class Form1
    Public time As Double = 0

    Class D3_Point
        Public X As Double
        Public Y As Double
        Public Z As Double
        Sub New(ByVal _x, ByVal _y, ByVal _z)
            X = _x
            Y = _y
            Z = _z
        End Sub
    End Class

    Class Pair
        Public P1 As Integer
        Public P2 As Integer
        Sub New(ByVal _p1, ByVal _p2)
            P1 = _p1
            P2 = _p2
        End Sub
    End Class
    Class Triangle
        Public P1 As Integer
        Public P2 As Integer
        Public P3 As Integer
        Sub New(ByVal _p1, ByVal _p2, ByVal _p3)
            P1 = _p1
            P2 = _p2
            P3 = _p3
        End Sub
    End Class

    Class GraphData
        Public Points(8) As D3_Point
        Public Lines(12) As Pair
        Public Triangles(12) As Triangle
        Sub New()
            Points(0) = New D3_Point(0, 0, 0)
            Points(1) = New D3_Point(100, 0, 0)
            Points(2) = New D3_Point(100, 0, 100)
            Points(3) = New D3_Point(0, 0, 100)
            Points(4) = New D3_Point(0, 100, 0)
            Points(5) = New D3_Point(100, 100, 0)
            Points(6) = New D3_Point(100, 100, 100)
            Points(7) = New D3_Point(0, 100, 100)
            Lines(0) = New Pair(0, 1)
            Lines(1) = New Pair(1, 2)
            Lines(2) = New Pair(2, 3)
            Lines(3) = New Pair(3, 0)
            Lines(4) = New Pair(0, 4)
            Lines(5) = New Pair(1, 5)
            Lines(6) = New Pair(2, 6)
            Lines(7) = New Pair(3, 7)
            Lines(8) = New Pair(4, 5)
            Lines(9) = New Pair(5, 6)
            Lines(10) = New Pair(6, 7)
            Lines(11) = New Pair(7, 4)
            Triangles(0) = New Triangle(0, 1, 2)
            Triangles(1) = New Triangle(2, 3, 0)
            Triangles(2) = New Triangle(0, 1, 4)
            Triangles(3) = New Triangle(1, 4, 5)
            Triangles(4) = New Triangle(2, 3, 6)
            Triangles(5) = New Triangle(3, 6, 7)
            'Triangles(6) = New Triangle(1, 2, 6)
            'Triangles(7) = New Triangle(2, 6, 1)
            'Triangles(8) = New Triangle(3, 0, 4)
            'Triangles(9) = New Triangle(4, 6, 7)
            Triangles(6) = New Triangle(4, 5, 6)
            Triangles(7) = New Triangle(6, 7, 4)
        End Sub

        Public Sub Rotate()
            Static pi As Double = 3.141592 / 180
            Dim center_x As Double = 50
            Dim center_z As Double = 50
            For i = 0 To 7 Step 1
                Dim x1 As Double = center_x - Points(i).X
                Dim z1 As Double = center_z - Points(i).Z
                Dim d_rad As Double = pi
                Points(i).X = center_x + x1 * Math.Cos(d_rad) - z1 * Math.Sin(d_rad)
                Points(i).Z = center_x + x1 * Math.Sin(d_rad) + z1 * Math.Cos(d_rad)
            Next
            Form1.time = Form1.time + 1
        End Sub
    End Class
    Dim gd As GraphData

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Draw()
    End Sub
    Private Sub Draw()
        Const OFFSET_A = 40
        Const OFFSET_B = 50
        Const OFFSET_C = 70

        If time = 0 Then
            gd = New GraphData()
        End If
        PictureBox1.BackColor = Color.White
        Dim canvas As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim g As Graphics = Graphics.FromImage(canvas)
        For i = 0 To 11 Step 1
            Dim px1 As Integer = gd.Points(gd.Lines(i).P1).X + gd.Points(gd.Lines(i).P1).Z / 2 + OFFSET_A
            Dim py1 As Integer = gd.Points(gd.Lines(i).P1).Y - gd.Points(gd.Lines(i).P1).Z / 2 + OFFSET_C
            Dim px2 As Integer = gd.Points(gd.Lines(i).P2).X + gd.Points(gd.Lines(i).P2).Z / 2 + OFFSET_A
            Dim py2 As Integer = gd.Points(gd.Lines(i).P2).Y - gd.Points(gd.Lines(i).P2).Z / 2 + OFFSET_C
            g.DrawLine(Pens.Black, px1, py1, px2, py2)
        Next
        Dim colors() As Brush = {Brushes.LightSkyBlue, Brushes.LightGreen, Brushes.LightGreen, Brushes.LightPink, Brushes.LightPink, Brushes.LightGray, Brushes.LightGray}
        For i = 7 To 0 Step -1
            Dim p(2) As Point
            p(0).X = gd.Points(gd.Triangles(i).P1).X + gd.Points(gd.Triangles(i).P1).Z / 2 + OFFSET_A
            p(0).Y = gd.Points(gd.Triangles(i).P1).Y - gd.Points(gd.Triangles(i).P1).Z / 2 + OFFSET_C
            p(1).X = gd.Points(gd.Triangles(i).P2).X + gd.Points(gd.Triangles(i).P2).Z / 2 + OFFSET_A
            p(1).Y = gd.Points(gd.Triangles(i).P2).Y - gd.Points(gd.Triangles(i).P2).Z / 2 + OFFSET_C
            p(2).X = gd.Points(gd.Triangles(i).P3).X + gd.Points(gd.Triangles(i).P3).Z / 2 + OFFSET_A
            p(2).Y = gd.Points(gd.Triangles(i).P3).Y - gd.Points(gd.Triangles(i).P3).Z / 2 + OFFSET_C
            Dim panel_color = colors(i / 2)
            g.FillPolygon(panel_color, p)
        Next

        PictureBox1.Image = canvas
        canvas = New Bitmap(PictureBoxX.Width, PictureBoxX.Height)
        g = Graphics.FromImage(canvas)
        For i = 0 To 11 Step 1
            Dim px1 As Integer = gd.Points(gd.Lines(i).P1).X + OFFSET_A
            Dim py1 As Integer = gd.Points(gd.Lines(i).P1).Y + OFFSET_A
            Dim px2 As Integer = gd.Points(gd.Lines(i).P2).X + OFFSET_A
            Dim py2 As Integer = gd.Points(gd.Lines(i).P2).Y + OFFSET_A
            g.DrawLine(Pens.Black, px1, py1, px2, py2)
        Next
        PictureBoxX.Image = canvas
        canvas = New Bitmap(PictureBoxY.Width, PictureBoxY.Height)
        g = Graphics.FromImage(canvas)
        For i = 0 To 11 Step 1
            Dim px1 As Integer = gd.Points(gd.Lines(i).P1).Z + OFFSET_A
            Dim py1 As Integer = gd.Points(gd.Lines(i).P1).Y + OFFSET_A
            Dim px2 As Integer = gd.Points(gd.Lines(i).P2).Z + OFFSET_A
            Dim py2 As Integer = gd.Points(gd.Lines(i).P2).Y + OFFSET_A
            g.DrawLine(Pens.Black, px1, py1, px2, py2)
        Next
        PictureBoxY.Image = canvas
        canvas = New Bitmap(PictureBoxZ.Width, PictureBoxZ.Height)
        g = Graphics.FromImage(canvas)
        For i = 0 To 11 Step 1
            Dim px1 As Integer = gd.Points(gd.Lines(i).P1).X + OFFSET_A
            Dim py1 As Integer = -1 * gd.Points(gd.Lines(i).P1).Z + 4 * OFFSET_A
            Dim px2 As Integer = gd.Points(gd.Lines(i).P2).X + OFFSET_A
            Dim py2 As Integer = -1 * gd.Points(gd.Lines(i).P2).Z + 4 * OFFSET_A
            g.DrawLine(Pens.Black, px1, py1, px2, py2)
        Next
        PictureBoxZ.Image = canvas
    End Sub

    Private Sub PictureBoxY_Click(sender As Object, e As EventArgs) Handles PictureBoxY.Click

    End Sub

    Private Sub PictureBoxX_Click(sender As Object, e As EventArgs) Handles PictureBoxX.Click

    End Sub

    Private Sub PictureBoxZ_Click(sender As Object, e As EventArgs) Handles PictureBoxZ.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Draw()
        gd.Rotate()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class
