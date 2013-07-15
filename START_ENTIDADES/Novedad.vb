Public Class Novedad

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


    Private _Titulo As String
    Public Property Titulo() As String
        Get
            Return _Titulo
        End Get
        Set(ByVal value As String)
            _Titulo = value
        End Set
    End Property


    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property


    Private _FechaActualizacion As Date
    Public Property FechaActualizacion() As Date
        Get
            Return _FechaActualizacion
        End Get
        Set(ByVal value As Date)
            _FechaActualizacion = value
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
