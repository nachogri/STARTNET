Public Class Seguimiento
#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Logueo As Logueo
    Dim _Tarea As Tarea
    Dim _IdentificadorDeAccion As String
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

    Public Property Tarea() As Tarea
        Get
            Return _Tarea
        End Get
        Set(ByVal value As Tarea)
            _Tarea = value
        End Set
    End Property

    Public Property IdentificadorDeAccion() As String
        Get
            Return _IdentificadorDeAccion
        End Get
        Set(ByVal value As String)
            _IdentificadorDeAccion = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class
