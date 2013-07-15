Public Class Idioma
#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Nombre As String
    Dim _leyendas As List(Of Leyenda)
    Private _formatoCultura As FormatoCultura
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

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Leyendas() As List(Of Leyenda)
        Get
            Return _leyendas
        End Get
        Set(ByVal value As List(Of Leyenda))
            _leyendas = value
        End Set
    End Property



    Public Property FormatoCultura() As FormatoCultura
        Get
            Return _formatoCultura
        End Get
        Set(ByVal value As FormatoCultura)
            _formatoCultura = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
