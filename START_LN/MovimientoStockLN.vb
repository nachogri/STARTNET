Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class MovimientoStockLN
#Region "Objetos privados"
    Dim movimientoStockMap As MovimientoStockMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef movimientoStock As MovimientoStock) As Integer
        Return movimientoStockMap.Insertar(movimientoStock)
    End Function

    Public Function Actualizar(ByVal movimientoStock As MovimientoStock) As Integer
        Return movimientoStockMap.Actualizar(movimientoStock)
    End Function

    Public Function Borrar(ByVal movimientoStock As MovimientoStock) As Integer
        Return movimientoStockMap.Borrar(movimientoStock)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As MovimientoStock
        Return movimientoStockMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As MovimientoStock, Optional ByVal Lazy As Boolean = True) As List(Of MovimientoStock)
        Return movimientoStockMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of MovimientoStock)
        Return movimientoStockMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        movimientoStockMap = New MovimientoStockMap
    End Sub
#End Region
End Class
