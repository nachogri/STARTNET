Imports START_AD
Imports START_ENTIDADES

Public Class OrdenCompraMap
#Region "Objetos privados"
    Dim ordenCompraAD As OrdenCompraAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef ordenCompra As OrdenCompra) As Integer
        Dim res As Integer = ordenCompraAD.Insertar(ordenCompra)

        If res > 0 Then
            For Each producto As OrdenCompraProducto In ordenCompra.Productos
                Dim productoAD As New OrdenCompraProductoAD
                productoAD.Insertar(producto)
            Next
        End If

        Return res
    End Function

    Public Function Actualizar(ByVal ordenCompra As OrdenCompra, Optional ByVal Lazy As Boolean = True) As Integer
        Dim res As Integer = ordenCompraAD.Actualizar(ordenCompra)

        If Not Lazy Then
            If res > 0 Then
                For Each producto As OrdenCompraProducto In ordenCompra.Productos
                    Dim productoAD As New OrdenCompraProductoAD
                    productoAD.Actualizar(producto)
                Next
            End If
        End If

        Return res
    End Function

    Public Function Borrar(ByVal ordenCompra As OrdenCompra) As Integer
        Dim res As Integer = ordenCompraAD.Borrar(ordenCompra)

        If res > 0 Then
            For Each producto As OrdenCompraProducto In ordenCompra.Productos
                Dim productoAD As New OrdenCompraProductoAD
                productoAD.Borrar(producto)
            Next
        End If

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As OrdenCompra
        Dim ordenCompra As OrdenCompra = ordenCompraAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim OrdenCompraProductoAD As New OrdenCompraProductoAD
            Dim factoriaOrdenCompraProducto As New FactoriaOrdenCompraProducto
            Dim OrdenCompraProducto As OrdenCompraProducto = factoriaOrdenCompraProducto.CrearProducto()
            OrdenCompraProducto.OrdenCompra = ordenCompra
            ordenCompra.Productos = OrdenCompraProductoAD.ConsultarPor(OrdenCompraProducto, Lazy)
        End If

        Return ordenCompra
    End Function

    Public Function ConsultarPor(ByVal filtros As OrdenCompra, Optional ByVal Lazy As Boolean = True) As List(Of OrdenCompra)
        Dim ordenCompras As List(Of OrdenCompra) = ordenCompraAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each ordenCompra As OrdenCompra In ordenCompras
                Dim OrdenCompraProductoAD As New OrdenCompraProductoAD
                Dim factoriaOrdenCompraProducto As New FactoriaOrdenCompraProducto
                Dim OrdenCompraProducto As OrdenCompraProducto = factoriaOrdenCompraProducto.CrearProducto()
                OrdenCompraProducto.OrdenCompra = ordenCompra
                ordenCompra.Productos = OrdenCompraProductoAD.ConsultarPor(OrdenCompraProducto, Lazy)
            Next
        End If

        Return ordenCompras
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of OrdenCompra)
        Dim ordenCompras As List(Of OrdenCompra) = ordenCompraAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each ordenCompra As OrdenCompra In ordenCompras
                Dim OrdenCompraProductoAD As New OrdenCompraProductoAD
                Dim factoriaOrdenCompraProducto As New FactoriaOrdenCompraProducto
                Dim OrdenCompraProducto As OrdenCompraProducto = factoriaOrdenCompraProducto.CrearProducto()
                OrdenCompraProducto.OrdenCompra = ordenCompra
                ordenCompra.Productos = OrdenCompraProductoAD.ConsultarPor(OrdenCompraProducto, Lazy)
            Next
        End If

        Return ordenCompras
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        ordenCompraAD = New OrdenCompraAD
    End Sub
#End Region
End Class


