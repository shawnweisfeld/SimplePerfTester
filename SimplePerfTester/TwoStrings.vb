Public Class TwoStrings

    Private _stringOne As String
    Public Property StringOne() As String
        Get
            Return _stringOne
        End Get
        Set(ByVal value As String)
            _stringOne = value
        End Set
    End Property

    Private _stringTwo As String
    Public Property StringTwo() As String
        Get
            Return _stringTwo
        End Get
        Set(ByVal value As String)
            _stringTwo = value
        End Set
    End Property

    Sub New(stringOne As String, stringTwo As String)
        Me.StringOne = stringOne
        Me.StringTwo = stringTwo
    End Sub

End Class
