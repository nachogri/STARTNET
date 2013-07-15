Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class pedidoCotizacionLN
#Region "Objetos privados"
    Dim pedidoCotizacionMap As pedidoCotizacionMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pedidoCotizacion As pedidoCotizacion) As Integer
        Return pedidoCotizacionMap.Insertar(pedidoCotizacion)
    End Function

    Public Function Actualizar(ByVal pedidoCotizacion As PedidoCotizacion, Optional ByVal Lazy As Boolean = True) As Integer
        Return pedidoCotizacionMap.Actualizar(pedidoCotizacion, Lazy)
    End Function

    Public Function Borrar(ByVal pedidoCotizacion As pedidoCotizacion) As Integer
        Return pedidoCotizacionMap.Borrar(pedidoCotizacion)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As pedidoCotizacion
        Return pedidoCotizacionMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As pedidoCotizacion, Optional ByVal Lazy As Boolean = True) As List(Of pedidoCotizacion)
        Return pedidoCotizacionMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of pedidoCotizacion)
        Return pedidoCotizacionMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        pedidoCotizacionMap = New pedidoCotizacionMap
    End Sub
#End Region
End Class
