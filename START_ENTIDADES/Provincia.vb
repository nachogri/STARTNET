Public Class Provincia

#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Nombre As String
    Dim _Pais As Pais
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


    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Pais() As Pais
        Get
            Return _Pais
        End Get
        Set(ByVal value As Pais)
            _Pais = value
        End Set
    End Property

    Private _Localidades As List(Of Localidad)
    Public Property Localidades() As List(Of Localidad)
        Get
            Return _Localidades
        End Get
        Set(ByVal value As List(Of Localidad))
            _Localidades = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class
