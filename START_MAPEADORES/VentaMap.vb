Imports START_AD
Imports START_ENTIDADES

Public Class VentaMap
#Region "Objetos privados"
    Dim ventaAD As VentaAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef venta As Venta) As Integer        
        Dim res As Integer = ventaAD.Insertar(venta)

        Return res
    End Function

    Public Function Actualizar(ByVal venta As Venta, Optional ByVal Lazy As Boolean = True) As Integer
        Dim res As Integer = ventaAD.Actualizar(Venta)

        If Not Lazy Then
            If res > 0 Then
                For Each producto As VentaProducto In Venta.Productos
                    Dim productoAD As New VentaProductoAD
                    productoAD.Actualizar(producto)
                Next
            End If
        End If

        Return res
    End Function

    Public Function Borrar(ByVal venta As Venta) As Integer
        Dim res As Integer = ventaAD.Borrar(Venta)

        If res > 0 Then
            For Each producto As VentaProducto In Venta.Productos
                Dim productoAD As New VentaProductoAD
                productoAD.Borrar(producto)
            Next
        End If

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Venta
        Dim venta As Venta = ventaAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim ventaProductoAD As New VentaProductoAD
            Dim ventaProducto As New VentaProducto
            ventaProducto.Venta = venta
            venta.Productos = ventaProductoAD.ConsultarPor(ventaProducto, Lazy)
        End If

        Return venta
    End Function

    Public Function ConsultarPor(ByVal filtros As Venta, Optional ByVal Lazy As Boolean = True) As List(Of Venta)
        Dim ventaes As List(Of Venta) = ventaAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each venta As Venta In ventaes
                Dim ventaProductoAD As New VentaProductoAD
                Dim ventaProducto As New VentaProducto
                ventaProducto.Venta = venta
                venta.Productos = ventaProductoAD.ConsultarPor(ventaProducto, Lazy)
            Next
        End If

        Return ventaes
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Venta)
        Dim ventaes As List(Of Venta) = ventaAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each venta As Venta In ventaes
                Dim ventaProductoAD As New VentaProductoAD
                Dim ventaProducto As New VentaProducto
                ventaProducto.Venta = venta
                venta.Productos = ventaProductoAD.ConsultarPor(ventaProducto, Lazy)
            Next
        End If

        Return ventaes
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        ventaAD = New VentaAD
    End Sub
#End Region
End Class
