
Public Class FactoriaPedidoReaprovisionamientoProducto
    Inherits FactoriaProductoEnTransaccion

    Public Overrides Function CrearProducto() As START_ENTIDADES.ProductoEnTransaccion
        Return New PedidoReaprovisionamientoProducto()
    End Function
End Class
