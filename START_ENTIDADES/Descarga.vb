Public Class Descarga

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


    Private _TipoArchivo As String
    Public Property TipoArchivo() As String
        Get
            Return _TipoArchivo
        End Get
        Set(ByVal value As String)
            _TipoArchivo = value
        End Set
    End Property


    Private _Ruta As String
    Public Property Ruta() As String
        Get
            Return _Ruta
        End Get
        Set(ByVal value As String)
            _Ruta = value
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



    Private _Especificacion As String
    Public Property Especificaciones() As String
        Get
            Return _Especificacion
        End Get
        Set(ByVal value As String)
            _Especificacion = value
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

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
