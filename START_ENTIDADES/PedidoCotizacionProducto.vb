Public Class PedidoCotizacionProducto
    Inherits ProductoEnTransaccion

#Region "Objetos privados"

#End Region

#Region "Propiedades"

    Private _PedidoCotizacion As PedidoCotizacion
    Public Property PedidoCotizacion() As PedidoCotizacion
        Get
            Return _PedidoCotizacion
        End Get
        Set(ByVal value As PedidoCotizacion)
            _PedidoCotizacion = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Friend Sub New()

    End Sub
#End Region
End Class
