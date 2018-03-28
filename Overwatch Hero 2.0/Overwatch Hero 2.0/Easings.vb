Imports System
Module Easings
    Private Const PI As Single = Math.PI

    Private Const HALFPI As Single = Math.PI / 2.0F

    Public Enum Functions
        Linear
        QuadraticEaseIn
        QuadraticEaseOut
        QuadraticEaseInOut
        CubicEaseIn
        CubicEaseOut
        CubicEaseInOut
        QuarticEaseIn
        QuarticEaseOut
        QuarticEaseInOut
        QuinticEaseIn
        QuinticEaseOut
        QuinticEaseInOut
        SineEaseIn
        SineEaseOut
        SineEaseInOut
        CircularEaseIn
        CircularEaseOut
        CircularEaseInOut
        ExponentialEaseIn
        ExponentialEaseOut
        ExponentialEaseInOut
        ElasticEaseIn
        ElasticEaseOut
        ElasticEaseInOut
        BackEaseIn
        BackEaseOut
        BackEaseInOut
        BounceEaseIn
        BounceEaseOut
        BounceEaseInOut
    End Enum

    Function Interpolate(ByVal p As Single, ByVal [function] As Functions) As Single
        Select Case [function]
            Case Functions.QuadraticEaseOut
                Return QuadraticEaseOut(p)
            Case Functions.QuadraticEaseIn
                Return QuadraticEaseIn(p)
            Case Functions.QuadraticEaseInOut
                Return QuadraticEaseInOut(p)
            Case Functions.CubicEaseIn
                Return CubicEaseIn(p)
            Case Functions.CubicEaseOut
                Return CubicEaseOut(p)
            Case Functions.CubicEaseInOut
                Return CubicEaseInOut(p)
            Case Functions.QuarticEaseIn
                Return QuarticEaseIn(p)
            Case Functions.QuarticEaseOut
                Return QuarticEaseOut(p)
            Case Functions.QuarticEaseInOut
                Return QuarticEaseInOut(p)
            Case Functions.QuinticEaseIn
                Return QuinticEaseIn(p)
            Case Functions.QuinticEaseOut
                Return QuinticEaseOut(p)
            Case Functions.QuinticEaseInOut
                Return QuinticEaseInOut(p)
            Case Functions.SineEaseIn
                Return SineEaseIn(p)
            Case Functions.SineEaseOut
                Return SineEaseOut(p)
            Case Functions.SineEaseInOut
                Return SineEaseInOut(p)
            Case Functions.CircularEaseIn
                Return CircularEaseIn(p)
            Case Functions.CircularEaseOut
                Return CircularEaseOut(p)
            Case Functions.CircularEaseInOut
                Return CircularEaseInOut(p)
            Case Functions.ExponentialEaseIn
                Return ExponentialEaseIn(p)
            Case Functions.ExponentialEaseOut
                Return ExponentialEaseOut(p)
            Case Functions.ExponentialEaseInOut
                Return ExponentialEaseInOut(p)
            Case Functions.ElasticEaseIn
                Return ElasticEaseIn(p)
            Case Functions.ElasticEaseOut
                Return ElasticEaseOut(p)
            Case Functions.ElasticEaseInOut
                Return ElasticEaseInOut(p)
            Case Functions.BackEaseIn
                Return BackEaseIn(p)
            Case Functions.BackEaseOut
                Return BackEaseOut(p)
            Case Functions.BackEaseInOut
                Return BackEaseInOut(p)
            Case Functions.BounceEaseIn
                Return BounceEaseIn(p)
            Case Functions.BounceEaseOut
                Return BounceEaseOut(p)
            Case Functions.BounceEaseInOut
                Return BounceEaseInOut(p)
            Case Else
                Return Linear(p)
        End Select
    End Function

    Function Linear(ByVal p As Single) As Single
        Return p
    End Function

    Function QuadraticEaseIn(ByVal p As Single) As Single
        Return p * p
    End Function

    Function QuadraticEaseOut(ByVal p As Single) As Single
        Return -(p * (p - 2))
    End Function

    Function QuadraticEaseInOut(ByVal p As Single) As Single
        If p < 0.5F Then
            Return 2 * p * p
        Else
            Return (-2 * p * p) + (4 * p) - 1
        End If
    End Function

    Function CubicEaseIn(ByVal p As Single) As Single
        Return p * p * p
    End Function

    Function CubicEaseOut(ByVal p As Single) As Single
        Dim f As Single = (p - 1)
        Return f * f * f + 1
    End Function

    Function CubicEaseInOut(ByVal p As Single) As Single
        If p < 0.5F Then
            Return 4 * p * p * p
        Else
            Dim f As Single = ((2 * p) - 2)
            Return 0.5F * f * f * f + 1
        End If
    End Function

    Function QuarticEaseIn(ByVal p As Single) As Single
        Return p * p * p * p
    End Function

    Function QuarticEaseOut(ByVal p As Single) As Single
        Dim f As Single = (p - 1)
        Return f * f * f * (1 - p) + 1
    End Function

    Function QuarticEaseInOut(ByVal p As Single) As Single
        If p < 0.5F Then
            Return 8 * p * p * p * p
        Else
            Dim f As Single = (p - 1)
            Return -8 * f * f * f * f + 1
        End If
    End Function

    Function QuinticEaseIn(ByVal p As Single) As Single
        Return p * p * p * p * p
    End Function

    Function QuinticEaseOut(ByVal p As Single) As Single
        Dim f As Single = (p - 1)
        Return f * f * f * f * f + 1
    End Function

    Function QuinticEaseInOut(ByVal p As Single) As Single
        If p < 0.5F Then
            Return 16 * p * p * p * p * p
        Else
            Dim f As Single = ((2 * p) - 2)
            Return 0.5F * f * f * f * f * f + 1
        End If
    End Function

    Function SineEaseIn(ByVal p As Single) As Single
        Return Math.Sin((p - 1) * HALFPI) + 1
    End Function

    Function SineEaseOut(ByVal p As Single) As Single
        Return Math.Sin(p * HALFPI)
    End Function

    Function SineEaseInOut(ByVal p As Single) As Single
        Return 0.5F * (1 - Math.Cos(p * PI))
    End Function

    Function CircularEaseIn(ByVal p As Single) As Single
        Return 1 - Math.Sqrt(1 - (p * p))
    End Function

    Function CircularEaseOut(ByVal p As Single) As Single
        Return Math.Sqrt((2 - p) * p)
    End Function

    Function CircularEaseInOut(ByVal p As Single) As Single
        If p < 0.5F Then
            Return 0.5F * (1 - Math.Sqrt(1 - 4 * (p * p)))
        Else
            Return 0.5F * (Math.Sqrt(-((2 * p) - 3) * ((2 * p) - 1)) + 1)
        End If
    End Function

    Function ExponentialEaseIn(ByVal p As Single) As Single
        Return If((p = 0F), p, Math.Pow(2, 10 * (p - 1)))
    End Function

    Function ExponentialEaseOut(ByVal p As Single) As Single
        Return If((p = 1.0F), p, 1 - Math.Pow(2, -10 * p))
    End Function

    Function ExponentialEaseInOut(ByVal p As Single) As Single
        If p = 0 OrElse p = 1 Then Return p
        If p < 0.5F Then
            Return 0.5F * Math.Pow(2, (20 * p) - 10)
        Else
            Return -0.5F * Math.Pow(2, (-20 * p) + 10) + 1
        End If
    End Function

    Function ElasticEaseIn(ByVal p As Single) As Single
        Return Math.Sin(13 * HALFPI * p) * Math.Pow(2, 10 * (p - 1))
    End Function

    Function ElasticEaseOut(ByVal p As Single) As Single
        Return Math.Sin(-13 * HALFPI * (p + 1)) * Math.Pow(2, -10 * p) + 1
    End Function

    Function ElasticEaseInOut(ByVal p As Single) As Single
        If p < 0.5F Then
            Return 0.5F * Math.Sin(13 * HALFPI * (2 * p)) * Math.Pow(2, 10 * ((2 * p) - 1))
        Else
            Return 0.5F * (Math.Sin(-13 * HALFPI * ((2 * p - 1) + 1)) * Math.Pow(2, -10 * (2 * p - 1)) + 2)
        End If
    End Function

    Function BackEaseIn(ByVal p As Single) As Single
        Return p * p * p - p * Math.Sin(p * PI)
    End Function

    Function BackEaseOut(ByVal p As Single) As Single
        Dim f As Single = (1 - p)
        Return 1 - (f * f * f - f * Math.Sin(f * PI))
    End Function

    Function BackEaseInOut(ByVal p As Single) As Single
        If p < 0.5F Then
            Dim f As Single = 2 * p
            Return 0.5F * (f * f * f - f * Math.Sin(f * PI))
        Else
            Dim f As Single = (1 - (2 * p - 1))
            Return 0.5F * (1 - (f * f * f - f * Math.Sin(f * PI))) + 0.5F
        End If
    End Function

    Function BounceEaseIn(ByVal p As Single) As Single
        Return 1 - BounceEaseOut(1 - p)
    End Function

    Function BounceEaseOut(ByVal p As Single) As Single
        If p < 4 / 11.0F Then
            Return (121 * p * p) / 16.0F
        ElseIf p < 8 / 11.0F Then
            Return (363 / 40.0F * p * p) - (99 / 10.0F * p) + 17 / 5.0F
        ElseIf p < 9 / 10.0F Then
            Return (4356 / 361.0F * p * p) - (35442 / 1805.0F * p) + 16061 / 1805.0F
        Else
            Return (54 / 5.0F * p * p) - (513 / 25.0F * p) + 268 / 25.0F
        End If
    End Function

    Function BounceEaseInOut(ByVal p As Single) As Single
        If p < 0.5F Then
            Return 0.5F * BounceEaseIn(p * 2)
        Else
            Return 0.5F * BounceEaseOut(p * 2 - 1) + 0.5F
        End If
    End Function

End Module
