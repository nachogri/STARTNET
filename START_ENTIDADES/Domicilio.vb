Public Class Domicilio

#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Tipo As String
    Dim _Calle As String
    Dim _Nro As Integer
    Dim _Localidad As Localidad
    Dim _Usuario As Usuario    
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

    Public Property Usuario() As Usuario
        Get
            Return _Usuario
        End Get
        Set(ByVal value As Usuario)
            _Usuario = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Property Calle() As String
        Get
            Return _Calle
        End Get
        Set(ByVal value As String)
            _Calle = value
        End Set
    End Property

    Public Property Nro() As Integer
        Get
            Return _Nro
        End Get
        Set(ByVal value As Integer)
            _Nro = value
        End Set
    End Property

    Public Property Localidad() As Localidad
        Get
            Return _Localidad
        End Get
        Set(ByVal value As Localidad)
            _Localidad = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
