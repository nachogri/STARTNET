Imports START_AD
Imports START_ENTIDADES

Public Class MovimientoStockMap
#Region "Objetos privados"
    Dim movimientoStockAD As MovimientoStockAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef movimientoStock As MovimientoStock) As Integer
        Return movimientoStockAD.Insertar(movimientoStock)
    End Function

    Public Function Actualizar(ByVal movimientoStock As MovimientoStock) As Integer
        Return movimientoStockAD.Actualizar(movimientoStock)
    End Function

    Public Function Borrar(ByVal movimientoStock As MovimientoStock) As Integer
        Return movimientoStockAD.Borrar(movimientoStock)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As MovimientoStock
        Return movimientoStockAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As MovimientoStock, Optional ByVal Lazy As Boolean = True) As List(Of MovimientoStock)
        Return movimientoStockAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of MovimientoStock)
        Return movimientoStockAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        movimientoStockAD = New MovimientoStockAD
    End Sub
#End Region
End Class
