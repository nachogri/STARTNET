Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class VentaLN
#Region "Objetos privados"
    Dim ventaMap As VentaMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef venta As Venta) As Integer
        Return ventaMap.Insertar(venta)
    End Function

    Public Function Actualizar(ByVal venta As Venta, Optional ByVal Lazy As Boolean = True) As Integer
        Return ventaMap.Actualizar(venta, Lazy)
    End Function

    Public Function Borrar(ByVal venta As Venta) As Integer
        Return ventaMap.Borrar(venta)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Venta
        Return ventaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Venta, Optional ByVal Lazy As Boolean = True) As List(Of Venta)
        Return ventaMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Venta)
        Return ventaMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        ventaMap = New VentaMap
    End Sub
#End Region
End Class
