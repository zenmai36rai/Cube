<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxX = New System.Windows.Forms.PictureBox()
        Me.PictureBoxY = New System.Windows.Forms.PictureBox()
        Me.PictureBoxZ = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxZ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(256, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(207, 207)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBoxX
        '
        Me.PictureBoxX.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBoxX.Location = New System.Drawing.Point(12, 244)
        Me.PictureBoxX.Name = "PictureBoxX"
        Me.PictureBoxX.Size = New System.Drawing.Size(221, 216)
        Me.PictureBoxX.TabIndex = 1
        Me.PictureBoxX.TabStop = False
        '
        'PictureBoxY
        '
        Me.PictureBoxY.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBoxY.Location = New System.Drawing.Point(256, 244)
        Me.PictureBoxY.Name = "PictureBoxY"
        Me.PictureBoxY.Size = New System.Drawing.Size(207, 216)
        Me.PictureBoxY.TabIndex = 2
        Me.PictureBoxY.TabStop = False
        '
        'PictureBoxZ
        '
        Me.PictureBoxZ.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBoxZ.Location = New System.Drawing.Point(12, 19)
        Me.PictureBoxZ.Name = "PictureBoxZ"
        Me.PictureBoxZ.Size = New System.Drawing.Size(221, 207)
        Me.PictureBoxZ.TabIndex = 3
        Me.PictureBoxZ.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 229)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "X"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(254, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Z"
        '
        'Timer1
        '
        Me.Timer1.Interval = 17
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(490, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 28)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Point"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(552, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(51, 28)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Line"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(609, 26)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(56, 28)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Polygon"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 472)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBoxZ)
        Me.Controls.Add(Me.PictureBoxY)
        Me.Controls.Add(Me.PictureBoxX)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxZ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBoxX As PictureBox
    Friend WithEvents PictureBoxY As PictureBox
    Friend WithEvents PictureBoxZ As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
