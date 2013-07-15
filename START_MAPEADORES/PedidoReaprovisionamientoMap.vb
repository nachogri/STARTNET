Imports START_AD
Imports START_ENTIDADES

Public Class pedidoReaprovisionamientoMap
#Region "Objetos privados"
    Dim pedidoReaprovisionamientoAD As pedidoReaprovisionamientoAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pedidoReaprovisionamiento As pedidoReaprovisionamiento) As Integer
        Dim res As Integer = pedidoReaprovisionamientoAD.Insertar(pedidoReaprovisionamiento)

        If res > 0 Then
            For Each producto As pedidoReaprovisionamientoProducto In pedidoReaprovisionamiento.Productos
                Dim productoAD As New pedidoReaprovisionamientoProductoAD
                productoAD.Insertar(producto)
            Next
        End If

        Return res
    End Function

    Public Function Actualizar(ByVal pedidoReaprovisionamiento As pedidoReaprovisionamiento, Optional ByVal Lazy As Boolean = True) As Integer
        Dim res As Integer = pedidoReaprovisionamientoAD.Actualizar(pedidoReaprovisionamiento)

        If Not Lazy Then
            If res > 0 Then
                For Each producto As pedidoReaprovisionamientoProducto In pedidoReaprovisionamiento.Productos
                    Dim productoAD As New pedidoReaprovisionamientoProductoAD
                    productoAD.Actualizar(producto)
                Next
            End If
        End If

        Return res
    End Function

    Public Function Borrar(ByVal pedidoReaprovisionamiento As pedidoReaprovisionamiento) As Integer
        Dim res As Integer = pedidoReaprovisionamientoAD.Borrar(pedidoReaprovisionamiento)

        If res > 0 Then
            For Each producto As pedidoReaprovisionamientoProducto In pedidoReaprovisionamiento.Productos
                Dim productoAD As New pedidoReaprovisionamientoProductoAD
                productoAD.Borrar(producto)
            Next
        End If

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As pedidoReaprovisionamiento
        Dim pedidoReaprovisionamiento As PedidoReaprovisionamiento = pedidoReaprovisionamientoAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim pedidoReaprovisionamientoProductoAD As New pedidoReaprovisionamientoProductoAD
            Dim factoriapedidoReaprovisionamientoProducto As New FactoriapedidoReaprovisionamientoProducto
            Dim pedidoReaprovisionamientoProducto As pedidoReaprovisionamientoProducto = factoriapedidoReaprovisionamientoProducto.CrearProducto()
            pedidoReaprovisionamientoProducto.pedidoReaprovisionamiento = pedidoReaprovisionamiento
            pedidoReaprovisionamiento.Productos = pedidoReaprovisionamientoProductoAD.ConsultarPor(pedidoReaprovisionamientoProducto, Lazy)
        End If

        Return pedidoReaprovisionamiento
    End Function

    Public Function ConsultarPor(ByVal filtros As pedidoReaprovisionamiento, Optional ByVal Lazy As Boolean = True) As List(Of pedidoReaprovisionamiento)
        Dim pedidoReaprovisionamientos As List(Of pedidoReaprovisionamiento) = pedidoReaprovisionamientoAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each pedidoReaprovisionamiento As pedidoReaprovisionamiento In pedidoReaprovisionamientos
                Dim pedidoReaprovisionamientoProductoAD As New pedidoReaprovisionamientoProductoAD
                Dim factoriapedidoReaprovisionamientoProducto As New FactoriapedidoReaprovisionamientoProducto
                Dim pedidoReaprovisionamientoProducto As pedidoReaprovisionamientoProducto = factoriapedidoReaprovisionamientoProducto.CrearProducto()
                pedidoReaprovisionamientoProducto.pedidoReaprovisionamiento = pedidoReaprovisionamiento
                pedidoReaprovisionamiento.Productos = pedidoReaprovisionamientoProductoAD.ConsultarPor(pedidoReaprovisionamientoProducto, Lazy)
            Next
        End If

        Return pedidoReaprovisionamientos
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of pedidoReaprovisionamiento)
        Dim pedidoReaprovisionamientos As List(Of pedidoReaprovisionamiento) = pedidoReaprovisionamientoAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each pedidoReaprovisionamiento As pedidoReaprovisionamiento In pedidoReaprovisionamientos
                Dim pedidoReaprovisionamientoProductoAD As New PedidoReaprovisionamientoProductoAD
                Dim factoriapedidoReaprovisionamientoProducto As New FactoriapedidoReaprovisionamientoProducto
                Dim pedidoReaprovisionamientoProducto As pedidoReaprovisionamientoProducto = factoriapedidoReaprovisionamientoProducto.CrearProducto()
                pedidoReaprovisionamientoProducto.pedidoReaprovisionamiento = pedidoReaprovisionamiento
                pedidoReaprovisionamiento.Productos = pedidoReaprovisionamientoProductoAD.ConsultarPor(pedidoReaprovisionamientoProducto, Lazy)
            Next
        End If

        Return pedidoReaprovisionamientos
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        pedidoReaprovisionamientoAD = New pedidoReaprovisionamientoAD
    End Sub
#End Region
End Class


