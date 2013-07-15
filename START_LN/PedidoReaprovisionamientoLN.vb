Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class pedidoReaprovisionamientoLN
#Region "Objetos privados"
    Dim pedidoReaprovisionamientoMap As pedidoReaprovisionamientoMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pedidoReaprovisionamiento As pedidoReaprovisionamiento) As Integer
        Return pedidoReaprovisionamientoMap.Insertar(pedidoReaprovisionamiento)
    End Function

    Public Function Actualizar(ByVal pedidoReaprovisionamiento As PedidoReaprovisionamiento, Optional ByVal Lazy As Boolean = True) As Integer
        Return pedidoReaprovisionamientoMap.Actualizar(pedidoReaprovisionamiento, Lazy)
    End Function

    Public Function Borrar(ByVal pedidoReaprovisionamiento As pedidoReaprovisionamiento) As Integer
        Return pedidoReaprovisionamientoMap.Borrar(pedidoReaprovisionamiento)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As pedidoReaprovisionamiento
        Return pedidoReaprovisionamientoMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As pedidoReaprovisionamiento, Optional ByVal Lazy As Boolean = True) As List(Of pedidoReaprovisionamiento)
        Return pedidoReaprovisionamientoMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of pedidoReaprovisionamiento)
        Return pedidoReaprovisionamientoMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        pedidoReaprovisionamientoMap = New pedidoReaprovisionamientoMap
    End Sub
#End Region
End Class
