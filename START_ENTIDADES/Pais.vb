Public Class Pais

#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Nacion As String
    Dim _Provincias As List(Of Provincia)
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

    Public Property Nacion() As String
        Get
            Return _Nacion
        End Get
        Set(ByVal value As String)
            _Nacion = value
        End Set
    End Property

    Public Property Provincias() As List(Of Provincia)
        Get
            Return _Provincias
        End Get
        Set(ByVal value As List(Of Provincia))
            _Provincias = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class
