Public Class Habilitacion

#Region "Objetos privados"
    Dim _Identificador As Integer
    Dim _Patente As Patente
    Dim _Objeto As String
    Dim _Habilitado As String
#End Region

#Region "Propiedades"
    Public Property Identificador() As Integer
        Get
            Return _Identificador
        End Get
        Set(ByVal value As Integer)
            _Identificador = value
        End Set
    End Property

    Public Property Patente() As Patente
        Get
            Return _Patente
        End Get
        Set(ByVal value As Patente)
            _Patente = value
        End Set
    End Property

    Public Property Objeto() As String
        Get
            Return _Objeto
        End Get
        Set(ByVal value As String)
            _Objeto = value
        End Set
    End Property

    Public Property Habilitado() As String
        Get
            Return _Habilitado
        End Get
        Set(ByVal value As String)
            _Habilitado = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
