Public Class Form1
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
        Public Points As List(Of D3_Point)
        Public Lines(12) As Pair
        Public Triangles(12) As Triangle
        Public ZList As List(Of Double)
        Public DepthOrder As List(Of Integer)
        Sub New()
            Points = New List(Of D3_Point)
            Points.Add(New D3_Point(0, 0, 0))
            Points.Add(New D3_Point(100, 0, 0))
            Points.Add(New D3_Point(100, 0, 100))
            Points.Add(New D3_Point(0, 0, 100))
            Points.Add(New D3_Point(0, 100, 0))
            Points.Add(New D3_Point(100, 100, 0))
            Points.Add(New D3_Point(100, 100, 100))
            Points.Add(New D3_Point(0, 100, 100))
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
            Triangles(6) = New Triangle(1, 2, 5)
            Triangles(7) = New Triangle(5, 6, 2)
            Triangles(8) = New Triangle(3, 0, 4)
            Triangles(9) = New Triangle(4, 7, 3)
            Triangles(10) = New Triangle(4, 5, 6)
            Triangles(11) = New Triangle(6, 7, 4)
            ZList = New List(Of Double)
            DepthOrder = New List(Of Integer)
        End Sub

        Public Sub Rotate()
            Static pi As Double = 3.141592 / 180
            Dim center_x As Double = 50
            Dim center_z As Double = 50
            For i = 0 To 7 Step 1
                Dim x1 As Double = center_x - Points(i).X
                Dim z1 As Double = center_z - Points(i).Z
                Dim d_rad As Double = pi
                Points(i).X = center_x - x1 * Math.Cos(d_rad) + z1 * Math.Sin(d_rad)
                Points(i).Z = center_x - x1 * Math.Sin(d_rad) - z1 * Math.Cos(d_rad)
            Next
            Form1.time = Form1.time + 1
        End Sub
        Public Sub ZSort()
            ZList.Clear()
            For i = 0 To 7 Step 1
                ZList.Add(Points(i).Z)
            Next
            ZList.Sort()
            Dim idx = ZList.Count() - 1
            DepthOrder.Clear()
            For k = idx To 0 Step -1
                For i = 11 To 0 Step -1
                    If ZList(k) = GetMaxZ(Triangles(i)) Then
                        DepthOrder.Add(i)
                    End If
                Next
            Next
        End Sub
        Public Function GetMaxZ(ByVal t As Triangle) As Double
            Dim MaxZ As Double = -1000
            If Points(t.P1).Z > MaxZ Then
                MaxZ = Points(t.P1).Z
            End If
            If Points(t.P2).Z > MaxZ Then
                MaxZ = Points(t.P2).Z
            End If
            If Points(t.P3).Z > MaxZ Then
                MaxZ = Points(t.P3).Z
            End If
            Return MaxZ
        End Function
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
        Const DRAW_POINT = False
        Const DRAW_LINE = False
        Const DRAW_POLYGON = True
        If DRAW_POINT Then
            Dim PenColor() As Color = {Color.Black, Color.Red, Color.Blue, Color.Pink}
            For i = 0 To 7 Step 1
                Dim px1 As Integer = gd.Points(i).X + gd.Points(i).Z / 2 + OFFSET_A
                Dim py1 As Integer = gd.Points(i).Y - gd.Points(i).Z / 2 + OFFSET_C
                Dim r As Rectangle = New Rectangle(px1 - 1, py1 - 1, 2, 2)
                g.DrawEllipse(Pens.Black, r)
            Next
        End If
        If DRAW_LINE Then
            Dim PenColor() As Pen = {Pens.Black, Pens.Red, Pens.Blue, Pens.Pink}
            For i = 0 To 11 Step 1
                Dim px1 As Integer = gd.Points(gd.Lines(i).P1).X + gd.Points(gd.Lines(i).P1).Z / 2 + OFFSET_A
                Dim py1 As Integer = gd.Points(gd.Lines(i).P1).Y - gd.Points(gd.Lines(i).P1).Z / 2 + OFFSET_C
                Dim px2 As Integer = gd.Points(gd.Lines(i).P2).X + gd.Points(gd.Lines(i).P2).Z / 2 + OFFSET_A
                Dim py2 As Integer = gd.Points(gd.Lines(i).P2).Y - gd.Points(gd.Lines(i).P2).Z / 2 + OFFSET_C
                g.DrawLine(PenColor(0), px1, py1, px2, py2)
            Next
        End If
        If DRAW_POLYGON Then
            gd.ZSort()
            Dim colors() As Brush = {Brushes.LightSkyBlue, Brushes.Yellow, Brushes.Yellow, Brushes.Gray, Brushes.Gray, Brushes.Gray, Brushes.Gray}
            Dim mk As Integer = gd.DepthOrder.Count() - 1
            For k = 0 To mk Step 1
                Dim i = gd.DepthOrder(k)
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
        End If
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
