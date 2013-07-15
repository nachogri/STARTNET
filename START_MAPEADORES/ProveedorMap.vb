Imports START_AD
Imports START_ENTIDADES

Public Class ProveedorMap
#Region "Objetos privados"
    Dim proveedorAD As ProveedorAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef proveedor As Proveedor) As Integer
        Dim res As Integer = proveedorAD.Insertar(proveedor)

        If res > 0 Then
            For Each producto As ProveedorProducto In proveedor.Productos
                Dim productoAD As New ProveedorProductoAD
                productoAD.Insertar(producto)
            Next
        End If
        Return res
    End Function

    Public Function Actualizar(ByVal proveedor As Proveedor, Optional ByVal Lazy As Boolean = True) As Integer
        Dim res As Integer = proveedorAD.Insertar(proveedor)

        If Not Lazy Then
            If res > 0 Then
                For Each producto As ProveedorProducto In proveedor.Productos
                    Dim productoAD As New ProveedorProductoAD
                    productoAD.Actualizar(producto)
                Next
            End If
        End If
        Return res
    End Function

    Public Function Borrar(ByVal proveedor As Proveedor) As Integer
        Dim res As Integer = proveedorAD.Insertar(proveedor)

        If res > 0 Then
            For Each producto As ProveedorProducto In proveedor.Productos
                Dim productoAD As New ProveedorProductoAD
                productoAD.Borrar(producto)
            Next
        End If
        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Proveedor
        Dim proveedor As Proveedor = proveedorAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim proveedorProductoAD As New ProveedorProductoAD
            Dim proveedorProducto As New ProveedorProducto
            proveedorProducto.Proveedor = proveedor
            proveedor.Productos = proveedorProductoAD.ConsultarPor(proveedorProducto, Lazy)
        End If

        Return proveedor
    End Function

    Public Function ConsultarPor(ByVal filtros As Proveedor, Optional ByVal Lazy As Boolean = True) As List(Of Proveedor)
        Dim proveedors As List(Of Proveedor) = proveedorAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each prov As Proveedor In proveedors
                Dim proveedorProductoAD As New ProveedorProductoAD
                Dim proveedorProducto As New ProveedorProducto
                proveedorProducto.Proveedor = prov
                prov.Productos = proveedorProductoAD.ConsultarPor(proveedorProducto, Lazy)
            Next
        End If

        Return proveedors
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Proveedor)
        Dim proveedors As List(Of Proveedor) = proveedorAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each prov As Proveedor In proveedors
                Dim proveedorProductoAD As New ProveedorProductoAD
                Dim proveedorProducto As New ProveedorProducto
                proveedorProducto.Proveedor = prov
                prov.Productos = proveedorProductoAD.ConsultarPor(proveedorProducto, Lazy)
            Next
        End If

        Return proveedors
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        proveedorAD = New ProveedorAD
    End Sub
#End Region
End Class


