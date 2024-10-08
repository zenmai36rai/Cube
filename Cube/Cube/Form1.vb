﻿Public Class Form1
    Private DRAW_POINT = False
    Private DRAW_LINE = False
    Private DRAW_POLYGON = True
    Private ROTATE_FLAG = True
    Private GUIDE_FLAG = True
    Public time As Double = 0
    Public _PX As Integer = 0
    Public _PY As Integer = 0
    Public _PZ As Integer = 0

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
        Public BR As Color
        Sub New(ByVal _p1, ByVal _p2, ByVal _p3, ByVal _br)
            P1 = _p1
            P2 = _p2
            P3 = _p3
            BR = Color.FromName(_br)
        End Sub
    End Class

    Class GraphData
        Public Points As List(Of D3_Point)
        Public Lines As List(Of Pair)
        Public Triangles As List(Of Triangle)
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
            Lines = New List(Of Pair)
            Lines.Add(New Pair(0, 1))
            Lines.Add(New Pair(1, 2))
            Lines.Add(New Pair(2, 3))
            Lines.Add(New Pair(3, 0))
            Lines.Add(New Pair(0, 4))
            Lines.Add(New Pair(1, 5))
            Lines.Add(New Pair(2, 6))
            Lines.Add(New Pair(3, 7))
            Lines.Add(New Pair(4, 5))
            Lines.Add(New Pair(5, 6))
            Lines.Add(New Pair(6, 7))
            Lines.Add(New Pair(7, 4))
            Triangles = New List(Of Triangle)
            Triangles.Add(New Triangle(0, 1, 2, "LightSkyBlue"))
            Triangles.Add(New Triangle(2, 3, 0, "LightSkyBlue"))
            Triangles.Add(New Triangle(0, 1, 4, "Yellow"))
            Triangles.Add(New Triangle(1, 4, 5, "Yellow"))
            Triangles.Add(New Triangle(2, 3, 6, "Yellow"))
            Triangles.Add(New Triangle(3, 6, 7, "Yellow"))
            Triangles.Add(New Triangle(1, 2, 5, "Gray"))
            Triangles.Add(New Triangle(5, 6, 2, "Gray"))
            Triangles.Add(New Triangle(3, 0, 4, "Gray"))
            Triangles.Add(New Triangle(4, 7, 3, "Gray"))
            Triangles.Add(New Triangle(4, 5, 6, "Gray"))
            Triangles.Add(New Triangle(6, 7, 4, "Gray"))
            ZList = New List(Of Double)
            DepthOrder = New List(Of Integer)
        End Sub

        Public Sub Rotate()
            Static pi As Double = 3.141592 / 180
            Dim center_x As Double = 50
            Dim center_z As Double = 50
            For i = 0 To Points.Count - 1 Step 1
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
            For i = 0 To Points.Count - 1 Step 1
                ZList.Add(Points(i).Z)
            Next
            ZList.Sort()
            Dim idx = ZList.Count() - 1
            DepthOrder.Clear()
            For k = idx To 0 Step -1
                For i = Triangles.Count - 1 To 0 Step -1
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
        If DRAW_POINT Then
            Dim PenColor() As Color = {Color.Black, Color.Red, Color.Blue, Color.Pink}
            For i = 0 To gd.Points.Count - 1 Step 1
                Dim px1 As Integer = gd.Points(i).X + gd.Points(i).Z / 2 + OFFSET_A
                Dim py1 As Integer = gd.Points(i).Y - gd.Points(i).Z / 2 + OFFSET_C
                Dim r As Rectangle = New Rectangle(px1 - 1, py1 - 1, 2, 2)
                g.DrawEllipse(Pens.Black, r)
            Next
        End If
        If DRAW_LINE Then
            Dim PenColor() As Pen = {Pens.Black, Pens.Red, Pens.Blue, Pens.Pink}
            For i = 0 To gd.Lines.Count - 1 Step 1
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
                Dim b As Brush = New SolidBrush(gd.Triangles(i).BR)
                g.FillPolygon(b, p)
            Next
        End If
        PictureBox1.Image = canvas

        canvas = New Bitmap(PictureBoxX.Width, PictureBoxX.Height)
        g = Graphics.FromImage(canvas)
        For i = 0 To gd.Lines.Count - 1 Step 1
            Dim px1 As Integer = gd.Points(gd.Lines(i).P1).X + OFFSET_A
            Dim py1 As Integer = gd.Points(gd.Lines(i).P1).Y + OFFSET_A
            Dim px2 As Integer = gd.Points(gd.Lines(i).P2).X + OFFSET_A
            Dim py2 As Integer = gd.Points(gd.Lines(i).P2).Y + OFFSET_A
            g.DrawLine(Pens.Black, px1, py1, px2, py2)
        Next
        If GUIDE_FLAG And TextBox1.Text <> "" Then
            Dim px = _PX + OFFSET_A
            g.DrawLine(Pens.Red, px, 0, px, canvas.Height)
        End If
        If GUIDE_FLAG And TextBox2.Text <> "" Then
            Dim py = _PY + OFFSET_A
            g.DrawLine(Pens.Red, 0, py, canvas.Height, py)
        End If
        PictureBoxX.Image = canvas
        canvas = New Bitmap(PictureBoxY.Width, PictureBoxY.Height)
        g = Graphics.FromImage(canvas)
        For i = 0 To gd.Lines.Count - 1 Step 1
            Dim px1 As Integer = gd.Points(gd.Lines(i).P1).Z + OFFSET_A
            Dim py1 As Integer = gd.Points(gd.Lines(i).P1).Y + OFFSET_A
            Dim px2 As Integer = gd.Points(gd.Lines(i).P2).Z + OFFSET_A
            Dim py2 As Integer = gd.Points(gd.Lines(i).P2).Y + OFFSET_A
            g.DrawLine(Pens.Black, px1, py1, px2, py2)
        Next
        If GUIDE_FLAG And TextBox3.Text <> "" Then
            Dim pz = _PZ + OFFSET_A
            g.DrawLine(Pens.Red, pz, 0, pz, canvas.Height)
        End If
        If GUIDE_FLAG And TextBox2.Text <> "" Then
            Dim py = _PY + OFFSET_A
            g.DrawLine(Pens.Red, 0, py, canvas.Height, py)
        End If
        PictureBoxY.Image = canvas
        canvas = New Bitmap(PictureBoxZ.Width, PictureBoxZ.Height)
        g = Graphics.FromImage(canvas)
        For i = 0 To gd.Lines.Count - 1 Step 1
            Dim px1 As Integer = gd.Points(gd.Lines(i).P1).X + OFFSET_A
            Dim py1 As Integer = -1 * gd.Points(gd.Lines(i).P1).Z + 4 * OFFSET_A
            Dim px2 As Integer = gd.Points(gd.Lines(i).P2).X + OFFSET_A
            Dim py2 As Integer = -1 * gd.Points(gd.Lines(i).P2).Z + 4 * OFFSET_A
            g.DrawLine(Pens.Black, px1, py1, px2, py2)
        Next
        If GUIDE_FLAG And TextBox1.Text <> "" Then
            Dim px = _PX + OFFSET_A
            g.DrawLine(Pens.Red, px, 0, px, canvas.Height)
        End If
        If GUIDE_FLAG And TextBox3.Text <> "" Then
            Dim pz = -1 * _PZ + 4 * OFFSET_A
            g.DrawLine(Pens.Red, 0, pz, canvas.Height, pz)
        End If
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
        If ROTATE_FLAG Then
            gd.Rotate()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length > 0 And TextBox2.Text.Length > 0 And TextBox3.Text.Length > 0 Then
            Dim x As Double = TextBox1.Text
            Dim y As Double = TextBox2.Text
            Dim z As Double = TextBox3.Text
            gd.Points.Add(New D3_Point(x, y, z))
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox4.Text.Length > 0 And TextBox5.Text.Length > 0 Then
            Dim p1 As Integer = TextBox4.Text
            Dim p2 As Integer = TextBox5.Text
            'Dim p3 As Integer = TextBox6.Text
            gd.Lines.Add(New Pair(p1, p2))
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ColorDialog1.ShowDialog()
        Dim c As Color = ColorDialog1.Color
        If TextBox7.Text.Length > 0 And TextBox8.Text.Length > 0 And TextBox9.Text.Length > 0 Then
            Dim p1 As Integer = TextBox7.Text
            Dim p2 As Integer = TextBox8.Text
            Dim p3 As Integer = TextBox9.Text
            gd.Triangles.Add(New Triangle(p1, p2, p3, c.ToKnownColor.ToString))
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        DRAW_POINT = CheckBox1.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        DRAW_LINE = CheckBox2.Checked

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        DRAW_POLYGON = CheckBox3.Checked

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Load
        Dim encoding = System.Text.Encoding.UTF8
        Dim filePath As String = "model.txt"
        Dim line As String = String.Empty
        Dim arr As Array
        gd.Points.Clear()
        gd.Lines.Clear()
        gd.Triangles.Clear()

        ' StreamReaderのインスタンスを生成する
        Using strm As IO.StreamReader = New IO.StreamReader(filePath, encoding)
            line = strm.ReadLine()
            While line IsNot Nothing
                ' 読み込んだ1行を配列に格納する
                arr = line.Split(",")
                If arr.Length > 3 And arr(0) = "P" Then
                    gd.Points.Add(New D3_Point(arr(1), arr(2), arr(3)))
                End If
                If arr.Length > 2 And arr(0) = "L" Then
                    gd.Lines.Add(New Pair(arr(1), arr(2)))
                End If
                If arr.Length > 4 And arr(0) = "T" Then
                    gd.Triangles.Add(New Triangle(arr(1), arr(2), arr(3), arr(4)))
                End If
                ' ファイルを1行読み込む
                line = strm.ReadLine()
            End While
        End Using
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Save
        Dim encoding = System.Text.Encoding.UTF8
        Dim filePath As String = "model.txt"
        Dim id As Integer = 1
        Using strm As IO.StreamWriter = New IO.StreamWriter(filePath, False, encoding)
            For Each a In gd.Points
                Dim Text As String = "P," + a.X.ToString + "," + a.Y.ToString + "," + a.Z.ToString
                strm.WriteLine(Text)
            Next
            For Each a In gd.Lines
                Dim Text As String = "L," + a.P1.ToString + "," + a.P2.ToString
                strm.WriteLine(Text)
            Next
            For Each a In gd.Triangles
                Dim Text As String = "T," + a.P1.ToString + "," + a.P2.ToString + "," + a.P3.ToString + "," + a.BR.ToKnownColor.ToString
                strm.WriteLine(Text)
            Next
        End Using

    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        ROTATE_FLAG = CheckBox4.Checked

    End Sub

    Private Sub ColorDialog1_HelpRequest(sender As Object, e As EventArgs) Handles ColorDialog1.HelpRequest

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        GUIDE_FLAG = CheckBox5.Checked

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            _PX = TextBox1.Text

        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text <> "" Then
            _PY = TextBox2.Text
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text <> "" Then
            _PZ = TextBox3.Text
        End If
    End Sub
End Class

' Since 2024 This Code Written By Kyosuke Miyazawa
