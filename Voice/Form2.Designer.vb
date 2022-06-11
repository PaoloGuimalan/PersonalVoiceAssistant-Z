<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuGradientPanel1 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.GunaCircleProgressBar1 = New Guna.UI.WinForms.GunaCircleProgressBar()
        Me.GunaCircleProgressBar2 = New Guna.UI.WinForms.GunaCircleProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BunifuGradientPanel1.SuspendLayout()
        Me.GunaCircleProgressBar1.SuspendLayout()
        Me.GunaCircleProgressBar2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 255
        Me.BunifuElipse1.TargetControl = Me
        '
        'BunifuGradientPanel1
        '
        Me.BunifuGradientPanel1.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel1.Controls.Add(Me.GunaCircleProgressBar1)
        Me.BunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Black
        Me.BunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Black
        Me.BunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Black
        Me.BunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Black
        Me.BunifuGradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BunifuGradientPanel1.Name = "BunifuGradientPanel1"
        Me.BunifuGradientPanel1.Quality = 10
        Me.BunifuGradientPanel1.Size = New System.Drawing.Size(219, 219)
        Me.BunifuGradientPanel1.TabIndex = 2
        '
        'GunaCircleProgressBar1
        '
        Me.GunaCircleProgressBar1.Animated = True
        Me.GunaCircleProgressBar1.AnimationSpeed = 0.6!
        Me.GunaCircleProgressBar1.BackColor = System.Drawing.Color.Transparent
        Me.GunaCircleProgressBar1.BaseColor = System.Drawing.Color.Transparent
        Me.GunaCircleProgressBar1.Controls.Add(Me.GunaCircleProgressBar2)
        Me.GunaCircleProgressBar1.Controls.Add(Me.Label1)
        Me.GunaCircleProgressBar1.IdleColor = System.Drawing.Color.Cyan
        Me.GunaCircleProgressBar1.IdleOffset = 10
        Me.GunaCircleProgressBar1.IdleThickness = 5
        Me.GunaCircleProgressBar1.Image = Nothing
        Me.GunaCircleProgressBar1.ImageSize = New System.Drawing.Size(52, 52)
        Me.GunaCircleProgressBar1.Location = New System.Drawing.Point(2, 4)
        Me.GunaCircleProgressBar1.Name = "GunaCircleProgressBar1"
        Me.GunaCircleProgressBar1.ProgressMaxColor = System.Drawing.Color.Lime
        Me.GunaCircleProgressBar1.ProgressMinColor = System.Drawing.Color.Lime
        Me.GunaCircleProgressBar1.ProgressOffset = 5
        Me.GunaCircleProgressBar1.ProgressThickness = 13
        Me.GunaCircleProgressBar1.Size = New System.Drawing.Size(216, 213)
        Me.GunaCircleProgressBar1.TabIndex = 4
        Me.GunaCircleProgressBar1.Value = 30
        '
        'GunaCircleProgressBar2
        '
        Me.GunaCircleProgressBar2.Animated = True
        Me.GunaCircleProgressBar2.AnimationSpeed = 0.6!
        Me.GunaCircleProgressBar2.BackColor = System.Drawing.Color.Transparent
        Me.GunaCircleProgressBar2.Backwards = True
        Me.GunaCircleProgressBar2.BaseColor = System.Drawing.Color.Transparent
        Me.GunaCircleProgressBar2.Controls.Add(Me.Label3)
        Me.GunaCircleProgressBar2.Controls.Add(Me.Label2)
        Me.GunaCircleProgressBar2.IdleColor = System.Drawing.Color.Cyan
        Me.GunaCircleProgressBar2.IdleOffset = 10
        Me.GunaCircleProgressBar2.IdleThickness = 5
        Me.GunaCircleProgressBar2.Image = Nothing
        Me.GunaCircleProgressBar2.ImageSize = New System.Drawing.Size(52, 52)
        Me.GunaCircleProgressBar2.Location = New System.Drawing.Point(23, 21)
        Me.GunaCircleProgressBar2.Name = "GunaCircleProgressBar2"
        Me.GunaCircleProgressBar2.ProgressMaxColor = System.Drawing.Color.Lime
        Me.GunaCircleProgressBar2.ProgressMinColor = System.Drawing.Color.Lime
        Me.GunaCircleProgressBar2.ProgressOffset = 5
        Me.GunaCircleProgressBar2.ProgressThickness = 13
        Me.GunaCircleProgressBar2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GunaCircleProgressBar2.Size = New System.Drawing.Size(173, 172)
        Me.GunaCircleProgressBar2.TabIndex = 5
        Me.GunaCircleProgressBar2.Value = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Cyan
        Me.Label3.Location = New System.Drawing.Point(52, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Control Panel"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Cyan
        Me.Label2.Location = New System.Drawing.Point(32, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "I'm 1011010"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(55, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "I'm 1011010"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 219)
        Me.ControlBox = False
        Me.Controls.Add(Me.BunifuGradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Z"
        Me.BunifuGradientPanel1.ResumeLayout(False)
        Me.GunaCircleProgressBar1.ResumeLayout(False)
        Me.GunaCircleProgressBar1.PerformLayout()
        Me.GunaCircleProgressBar2.ResumeLayout(False)
        Me.GunaCircleProgressBar2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuGradientPanel1 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents GunaCircleProgressBar1 As Guna.UI.WinForms.GunaCircleProgressBar
    Friend WithEvents GunaCircleProgressBar2 As Guna.UI.WinForms.GunaCircleProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
