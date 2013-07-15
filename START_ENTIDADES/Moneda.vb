Public Class Moneda

#Region "Objetos privados"

#End Region

#Region "Propiedades"


    Private _Identificador As Integer
    Public Property Identificador() As Integer
        Get
            Return _Identificador
        End Get
        Set(ByVal value As Integer)
            _Identificador = value
        End Set
    End Property



    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property


    Private _Simbolo As String
    Public Property Simbolo() As String
        Get
            Return _Simbolo
        End Get
        Set(ByVal value As String)
            _Simbolo = value
        End Set
    End Property


    Private _CambioDolar As Double
    Public Property CambioDolar() As Double
        Get
            Return _CambioDolar
        End Get
        Set(ByVal value As Double)
            _CambioDolar = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
