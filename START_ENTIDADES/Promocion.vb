Public Class Promocion
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



    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property


    Private _Requisitos As String
    Public Property Requisitos() As String
        Get
            Return _Requisitos
        End Get
        Set(ByVal value As String)
            _Requisitos = value
        End Set
    End Property


    Private _Expiracion As Date
    Public Property Expiracion() As Date
        Get
            Return _Expiracion
        End Get
        Set(ByVal value As Date)
            _Expiracion = value
        End Set
    End Property


    Private _Productos As List(Of PromocionProducto)
    Public Property Productos() As List(Of PromocionProducto)
        Get
            Return _Productos
        End Get
        Set(ByVal value As List(Of PromocionProducto))
            _Productos = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
