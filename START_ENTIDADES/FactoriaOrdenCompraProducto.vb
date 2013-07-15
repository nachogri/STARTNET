
Public Class FactoriaOrdenCompraProducto
    Inherits FactoriaProductoEnTransaccion

    Public Overrides Function CrearProducto() As START_ENTIDADES.ProductoEnTransaccion
        Return New OrdenCompraProducto()
    End Function
End Class
