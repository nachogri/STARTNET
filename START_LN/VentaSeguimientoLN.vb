Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class VentaSeguimientoLN
#Region "Objetos privados"
    Dim ventaSeguimientoMap As ventaSeguimientoMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef ventaSeguimiento As VentaSeguimiento) As Integer
        Return ventaSeguimientoMap.Insertar(ventaSeguimiento)
    End Function

    Public Function Actualizar(ByVal ventaSeguimiento As VentaSeguimiento) As Integer
        Return ventaSeguimientoMap.Actualizar(ventaSeguimiento)
    End Function

    Public Function Borrar(ByVal ventaSeguimiento As VentaSeguimiento) As Integer
        Return ventaSeguimientoMap.Borrar(ventaSeguimiento)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As VentaSeguimiento
        Return ventaSeguimientoMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As VentaSeguimiento, Optional ByVal Lazy As Boolean = True) As List(Of VentaSeguimiento)
        Return ventaSeguimientoMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of VentaSeguimiento)
        Return ventaSeguimientoMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        ventaSeguimientoMap = New ventaSeguimientoMap
    End Sub
#End Region
End Class

