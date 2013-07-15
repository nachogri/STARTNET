Public Class MovimientoStock

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


    Private _Venta As Venta
    Public Property Venta() As Venta
        Get
            Return _Venta
        End Get
        Set(ByVal value As Venta)
            _Venta = value
        End Set
    End Property



    Private _Producto As Producto
    Public Property Producto() As Producto
        Get
            Return _Producto
        End Get
        Set(ByVal value As Producto)
            _Producto = value
        End Set
    End Property



    Private _Cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Integer)
            _Cantidad = value
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


    Private _Monto As Integer
    Public Property Monto() As Integer
        Get
            Return _Monto
        End Get
        Set(ByVal value As Integer)
            _Monto = value
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


    Private _Tipo As TipoMovimientoStock
    Public Property Tipo() As TipoMovimientoStock
        Get
            Return _Tipo
        End Get
        Set(ByVal value As TipoMovimientoStock)
            _Tipo = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class


Public Enum TipoMovimientoStock
    Ingreso
    Egreso
End Enum

