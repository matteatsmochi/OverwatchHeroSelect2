Public Class frmLoading
    Dim LoadingStrength As Integer = 1

    Private Sub frmLoading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        barLoading.Width = 0
    End Sub

    Private Sub tmrLoading_Tick(sender As Object, e As EventArgs) Handles tmrLoading.Tick
        If barLoading.Width >= 291 Then
            'load application
            tmrLoading.Enabled = False
            frmOverwatchHeroSelect.Show()
            'close window
            Me.Close()
        ElseIf barLoading.Width >= 100 Then
            LoadingStrength = 3
            barLoading.Width += LoadingStrength
        Else
            barLoading.Width += LoadingStrength
        End If
    End Sub
End Class