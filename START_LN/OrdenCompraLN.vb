Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class OrdenCompraLN
#Region "Objetos privados"
    Dim ordenCompraMap As OrdenCompraMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef ordenCompra As OrdenCompra) As Integer
        Return ordenCompraMap.Insertar(ordenCompra)
    End Function

    Public Function Actualizar(ByVal ordenCompra As OrdenCompra, Optional ByVal Lazy As Boolean = True) As Integer
        Return ordenCompraMap.Actualizar(ordenCompra, Lazy)
    End Function

    Public Function Borrar(ByVal ordenCompra As OrdenCompra) As Integer
        Return ordenCompraMap.Borrar(ordenCompra)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As OrdenCompra
        Return ordenCompraMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As OrdenCompra, Optional ByVal Lazy As Boolean = True) As List(Of OrdenCompra)
        Return ordenCompraMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of OrdenCompra)
        Return ordenCompraMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        ordenCompraMap = New OrdenCompraMap
    End Sub
#End Region
End Class
