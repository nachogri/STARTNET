Public Class ForoTopico

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


    Private _Usuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return _Usuario
        End Get
        Set(ByVal value As Usuario)
            _Usuario = value
        End Set
    End Property


    Private _FechaAlta As Date
    Public Property FechaAlta() As Date
        Get
            Return _FechaAlta
        End Get
        Set(ByVal value As Date)
            _FechaAlta = value
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



    Private _Activo As Byte
    Public Property Activo() As Byte
        Get
            Return _Activo
        End Get
        Set(ByVal value As Byte)
            _Activo = value
        End Set
    End Property



#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
