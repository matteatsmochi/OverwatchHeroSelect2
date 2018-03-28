<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoading
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoading))
        Me.barLoading = New System.Windows.Forms.Label()
        Me.tmrLoading = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'barLoading
        '
        Me.barLoading.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.barLoading.Location = New System.Drawing.Point(55, 109)
        Me.barLoading.Name = "barLoading"
        Me.barLoading.Size = New System.Drawing.Size(291, 8)
        Me.barLoading.TabIndex = 1
        '
        'tmrLoading
        '
        Me.tmrLoading.Enabled = True
        Me.tmrLoading.Interval = 15
        '
        'frmLoading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Overwatch_Hero_2._0.My.Resources.Resources.Loading_Screen
        Me.ClientSize = New System.Drawing.Size(400, 150)
        Me.Controls.Add(Me.barLoading)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLoading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents barLoading As Label
    Friend WithEvents tmrLoading As Timer
End Class
