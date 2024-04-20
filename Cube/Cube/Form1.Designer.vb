<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxX = New System.Windows.Forms.PictureBox()
        Me.PictureBoxY = New System.Windows.Forms.PictureBox()
        Me.PictureBoxZ = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxZ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(256, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(207, 207)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBoxX
        '
        Me.PictureBoxX.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBoxX.Location = New System.Drawing.Point(12, 235)
        Me.PictureBoxX.Name = "PictureBoxX"
        Me.PictureBoxX.Size = New System.Drawing.Size(221, 216)
        Me.PictureBoxX.TabIndex = 1
        Me.PictureBoxX.TabStop = False
        '
        'PictureBoxY
        '
        Me.PictureBoxY.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBoxY.Location = New System.Drawing.Point(256, 235)
        Me.PictureBoxY.Name = "PictureBoxY"
        Me.PictureBoxY.Size = New System.Drawing.Size(207, 216)
        Me.PictureBoxY.TabIndex = 2
        Me.PictureBoxY.TabStop = False
        '
        'PictureBoxZ
        '
        Me.PictureBoxZ.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBoxZ.Location = New System.Drawing.Point(12, 12)
        Me.PictureBoxZ.Name = "PictureBoxZ"
        Me.PictureBoxZ.Size = New System.Drawing.Size(221, 207)
        Me.PictureBoxZ.TabIndex = 3
        Me.PictureBoxZ.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 463)
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

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBoxX As PictureBox
    Friend WithEvents PictureBoxY As PictureBox
    Friend WithEvents PictureBoxZ As PictureBox
End Class
