Public Class PedidoReaprovisionamiento

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




    Private _Usuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return _Usuario
        End Get
        Set(ByVal value As Usuario)
            _Usuario = value
        End Set
    End Property


    Private _OrdenCompra As OrdenCompra
    Public Property OrdenCompra() As OrdenCompra
        Get
            Return _OrdenCompra
        End Get
        Set(ByVal value As OrdenCompra)
            _OrdenCompra = value
        End Set
    End Property


    Private _Fecha As Date
    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property


    Private _Productos As List(Of PedidoReaprovisionamientoProducto)
    Public Property Productos() As List(Of PedidoReaprovisionamientoProducto)
        Get
            Return _Productos
        End Get
        Set(ByVal value As List(Of PedidoReaprovisionamientoProducto))
            _Productos = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
