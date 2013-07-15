Imports START_AD
Imports START_ENTIDADES

Public Class PagoProveedorMap
#Region "Objetos privados"
    Dim pagoProveedorAD As PagoProveedorAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pagoProveedor As PagoProveedor) As Integer
        Return pagoProveedorAD.Insertar(pagoProveedor)
    End Function

    Public Function Actualizar(ByVal pagoProveedor As PagoProveedor) As Integer
        Return pagoProveedorAD.Actualizar(pagoProveedor)
    End Function

    Public Function Borrar(ByVal pagoProveedor As PagoProveedor) As Integer
        Return pagoProveedorAD.Borrar(pagoProveedor)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As PagoProveedor
        Dim pagoProveedor As PagoProveedor = pagoProveedorAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim ordenCompraAD As New OrdenCompraAD
            Dim ordenCompra As New OrdenCompra
            ordenCompra.PagoProveedor = pagoProveedor
            pagoProveedor.OrdenesCompra = ordenCompraAD.ConsultarPor(ordenCompra, Lazy)
        End If

        Return pagoProveedor
    End Function

    Public Function ConsultarPor(ByVal filtros As PagoProveedor, Optional ByVal Lazy As Boolean = True) As List(Of PagoProveedor)
        Dim pagoProveedors As List(Of PagoProveedor) = pagoProveedorAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each pago As PagoProveedor In pagoProveedors
                Dim ordenCompraAD As New OrdenCompraAD
                Dim ordenCompra As New OrdenCompra
                ordenCompra.PagoProveedor = pago
                pago.OrdenesCompra = ordenCompraAD.ConsultarPor(ordenCompra, Lazy)
            Next
        End If

        Return pagoProveedors
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of PagoProveedor)
        Dim pagoProveedors As List(Of PagoProveedor) = pagoProveedorAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each pago As PagoProveedor In pagoProveedors
                Dim ordenCompraAD As New OrdenCompraAD
                Dim ordenCompra As New OrdenCompra
                ordenCompra.PagoProveedor = pago
                pago.OrdenesCompra = ordenCompraAD.ConsultarPor(ordenCompra, Lazy)
            Next
        End If

        Return pagoProveedors
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        pagoProveedorAD = New PagoProveedorAD
    End Sub
#End Region
End Class


