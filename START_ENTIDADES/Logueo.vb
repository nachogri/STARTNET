Public Class Logueo

#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Usuario As Usuario
    Dim _Fecha As Date
    Dim _HoraIn As String
    Dim _HoraOut As String
    Dim _Seguimientos As List(Of Seguimiento)
    Private _Navegaciones As List(Of Navegacion)
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

    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property HoraIn() As String
        Get
            Return _HoraIn
        End Get
        Set(ByVal value As String)
            _HoraIn = value
        End Set
    End Property

    Public Property HoraOut() As String
        Get
            Return _HoraOut
        End Get
        Set(ByVal value As String)
            _HoraOut = value
        End Set
    End Property

    Public Property Seguimientos() As List(Of Seguimiento)
        Get
            Return _Seguimientos
        End Get
        Set(ByVal value As List(Of Seguimiento))
            _Seguimientos = value
        End Set
    End Property

    Public Property Navegaciones() As List(Of Navegacion)
        Get
            Return _Navegaciones
        End Get
        Set(ByVal value As List(Of Navegacion))
            _Navegaciones = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
