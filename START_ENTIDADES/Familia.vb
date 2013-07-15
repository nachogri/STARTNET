Public Class Familia
#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Descripcion As String
    Dim _Patentes As List(Of Patente)
    Dim _Usuarios As List(Of Usuario)
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

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Patentes() As List(Of Patente)
        Get
            Return _Patentes
        End Get
        Set(ByVal value As List(Of Patente))
            _Patentes = value
        End Set
    End Property

    Public Property Usuarios() As List(Of Usuario)
        Get
            Return _Usuarios
        End Get
        Set(ByVal value As List(Of Usuario))
            _Usuarios = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class
