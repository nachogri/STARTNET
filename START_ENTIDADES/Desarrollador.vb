Public Class Desarrollador    

#Region "Objetos privados"

#End Region

#Region "Propiedades"
    Private _Identificador As Guid
    Public Property Identificador() As Guid
        Get
            Return _Identificador
        End Get
        Set(ByVal value As Guid)
            _Identificador = value
        End Set
    End Property


    Private _usuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As Usuario)
            _usuario = value
        End Set
    End Property


    Private _DescripcionProducto As String
    Public Property DescripcionProducto() As String
        Get
            Return _DescripcionProducto
        End Get
        Set(ByVal value As String)
            _DescripcionProducto = value
        End Set
    End Property


    Private _RazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
        End Set
    End Property


    Private _Aviso As String
    Public Property Aviso() As String
        Get
            Return _Aviso
        End Get
        Set(ByVal value As String)
            _Aviso = value
        End Set
    End Property


    Private _Comentarios As String
    Public Property Comentarios() As String
        Get
            Return _Comentarios
        End Get
        Set(ByVal value As String)
            _Comentarios = value
        End Set
    End Property


    Private _Imagen As Byte()
    Public Property Imagen() As Byte()
        Get
            Return _Imagen
        End Get
        Set(ByVal value As Byte())
            _Imagen = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class
