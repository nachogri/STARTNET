Public Class OrdenCompraProducto
    Inherits ProductoEnTransaccion

#Region "Objetos privados"

#End Region

#Region "Propiedades"

    Private _OrdenCompra As OrdenCompra
    Public Property OrdenCompra() As OrdenCompra
        Get
            Return _OrdenCompra
        End Get
        Set(ByVal value As OrdenCompra)
            _OrdenCompra = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Friend Sub New()

    End Sub
#End Region

End Class
