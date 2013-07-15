Public Class PedidoReaprovisionamientoProducto
    Inherits ProductoEnTransaccion

#Region "Objetos privados"

#End Region

#Region "Propiedades"

    Private _PedidoReaprovisionamiento As PedidoReaprovisionamiento
    Public Property PedidoReaprovisionamiento() As PedidoReaprovisionamiento
        Get
            Return _PedidoReaprovisionamiento
        End Get
        Set(ByVal value As PedidoReaprovisionamiento)
            _PedidoReaprovisionamiento = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Friend Sub New()

    End Sub
#End Region
End Class
