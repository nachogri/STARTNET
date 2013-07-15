Public Class FormatoCultura
#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Idioma As Idioma
    Private _Hora As String
    Private _Fecha As String
    Private _Numeros As String
#End Region

#Region "Propiedades"
    Public Property Identificador() As Guid
        Get
            Return _Identificador
        End Get
        Set(ByVal value As Guid)
            _Identificador = value
        End Set
    End Property

    Public Property Idioma() As Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property

    Public Property Hora() As String
        Get
            Return _Hora
        End Get
        Set(ByVal value As String)
            _Hora = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    Public Property Numeros() As String
        Get
            Return _Numeros
        End Get
        Set(ByVal value As String)
            _Numeros = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class
