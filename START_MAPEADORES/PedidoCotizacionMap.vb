Imports START_AD
Imports START_ENTIDADES

Public Class PedidoCotizacionMap
#Region "Objetos privados"
    Dim pedidoCotizacionAD As PedidoCotizacionAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pedidoCotizacion As PedidoCotizacion) As Integer
        Dim res As Integer = pedidoCotizacionAD.Insertar(pedidoCotizacion)

        If res > 0 Then
            For Each producto As PedidoCotizacionProducto In pedidoCotizacion.Productos
                Dim productoAD As New PedidoCotizacionProductoAD
                productoAD.Insertar(producto)
            Next
        End If

        Return res
    End Function

    Public Function Actualizar(ByVal pedidoCotizacion As PedidoCotizacion, Optional ByVal Lazy As Boolean = True) As Integer
        Dim res As Integer = pedidoCotizacionAD.Actualizar(pedidoCotizacion)

        If Not Lazy Then
            If res > 0 Then
                For Each producto As PedidoCotizacionProducto In pedidoCotizacion.Productos
                    Dim productoAD As New PedidoCotizacionProductoAD
                    productoAD.Actualizar(producto)
                Next
            End If
        End If

        Return res
    End Function

    Public Function Borrar(ByVal pedidoCotizacion As PedidoCotizacion) As Integer
        Dim res As Integer = pedidoCotizacionAD.Borrar(pedidoCotizacion)

        If res > 0 Then
            For Each producto As PedidoCotizacionProducto In pedidoCotizacion.Productos
                Dim productoAD As New PedidoCotizacionProductoAD
                productoAD.Borrar(producto)
            Next
        End If

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As PedidoCotizacion
        Dim pedidoCotizacion As PedidoCotizacion = pedidoCotizacionAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim pedidoCotizacionProductoAD As New PedidoCotizacionProductoAD
            Dim factoriapedidoCotizacionProducto As New FactoriaPedidoCotizacionProducto
            Dim pedidoCotizacionProducto As PedidoCotizacionProducto = factoriapedidoCotizacionProducto.CrearProducto()
            pedidoCotizacionProducto.PedidoCotizacion = pedidoCotizacion
            pedidoCotizacion.Productos = pedidoCotizacionProductoAD.ConsultarPor(pedidoCotizacionProducto, Lazy)
        End If

        Return pedidoCotizacion
    End Function

    Public Function ConsultarPor(ByVal filtros As PedidoCotizacion, Optional ByVal Lazy As Boolean = True) As List(Of PedidoCotizacion)
        Dim pedidoCotizacions As List(Of PedidoCotizacion) = pedidoCotizacionAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each pedidoCotizacion As PedidoCotizacion In pedidoCotizacions
                Dim pedidoCotizacionProductoAD As New PedidoCotizacionProductoAD
                Dim factoriapedidoCotizacionProducto As New FactoriaPedidoCotizacionProducto
                Dim pedidoCotizacionProducto As PedidoCotizacionProducto = factoriapedidoCotizacionProducto.CrearProducto()
                pedidoCotizacionProducto.PedidoCotizacion = pedidoCotizacion
                pedidoCotizacion.Productos = pedidoCotizacionProductoAD.ConsultarPor(pedidoCotizacionProducto, Lazy)
            Next
        End If

        Return pedidoCotizacions
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of PedidoCotizacion)
        Dim pedidoCotizacions As List(Of PedidoCotizacion) = pedidoCotizacionAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each pedidoCotizacion As PedidoCotizacion In pedidoCotizacions
                Dim pedidoCotizacionProductoAD As New PedidoCotizacionProductoAD
                Dim factoriapedidoCotizacionProducto As New FactoriaPedidoCotizacionProducto
                Dim pedidoCotizacionProducto As PedidoCotizacionProducto = factoriapedidoCotizacionProducto.CrearProducto()
                pedidoCotizacionProducto.PedidoCotizacion = pedidoCotizacion
                pedidoCotizacion.Productos = pedidoCotizacionProductoAD.ConsultarPor(pedidoCotizacionProducto, Lazy)
            Next
        End If

        Return pedidoCotizacions
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        pedidoCotizacionAD = New PedidoCotizacionAD
    End Sub
#End Region
End Class


