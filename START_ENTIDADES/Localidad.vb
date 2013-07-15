Public Class Localidad

#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Nombre As String
    Dim _CP As String
    Dim _Provincia As Provincia
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

    Public Property Provincia() As Provincia
        Get
            Return _Provincia
        End Get
        Set(ByVal value As Provincia)
            _Provincia = value
        End Set
    End Property

    Public Property CP() As String
        Get
            Return _CP
        End Get
        Set(ByVal value As String)
            _CP = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property




#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class
