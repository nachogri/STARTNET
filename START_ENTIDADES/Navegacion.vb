Public Class Navegacion
#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Logueo As Logueo
    Dim _Pagina As Pagina
    Private _HoraEntrada As Date
    Private _HoraSalida As Date
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

    Public Property Logueo() As Logueo
        Get
            Return _Logueo
        End Get
        Set(ByVal value As Logueo)
            _Logueo = value
        End Set
    End Property

    Public Property Pagina() As Pagina
        Get
            Return _Pagina
        End Get
        Set(ByVal value As Pagina)
            _Pagina = value
        End Set
    End Property

    Public Property HoraEntrada() As Date
        Get
            Return _HoraEntrada
        End Get
        Set(ByVal value As Date)
            _HoraEntrada = value
        End Set
    End Property

    Public Property HoraSalida() As Date
        Get
            Return _HoraSalida
        End Get
        Set(ByVal value As Date)
            _HoraSalida = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
