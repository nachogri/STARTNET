
Public Class FactoriaPedidoCotizacionProducto
    Inherits FactoriaProductoEnTransaccion

    Public Overrides Function CrearProducto() As START_ENTIDADES.ProductoEnTransaccion
        Return New PedidoCotizacionProducto()
    End Function
End Class
