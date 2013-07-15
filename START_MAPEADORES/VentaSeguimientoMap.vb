Imports START_AD
Imports START_ENTIDADES

Public Class VentaSeguimientoMap
#Region "Objetos privados"
    Dim ventaSeguimientoAD As VentaSeguimientoAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef ventaSeguimiento As VentaSeguimiento) As Integer
        Return ventaSeguimientoAD.Insertar(ventaSeguimiento)
    End Function

    Public Function Actualizar(ByVal ventaSeguimiento As VentaSeguimiento) As Integer
        Return ventaSeguimientoAD.Actualizar(ventaSeguimiento)
    End Function

    Public Function Borrar(ByVal ventaSeguimiento As VentaSeguimiento) As Integer
        Return ventaSeguimientoAD.Borrar(ventaSeguimiento)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As VentaSeguimiento
        Return ventaSeguimientoAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As VentaSeguimiento, Optional ByVal Lazy As Boolean = True) As List(Of VentaSeguimiento)
        Return ventaSeguimientoAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of VentaSeguimiento)
        Return ventaSeguimientoAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        ventaSeguimientoAD = New VentaSeguimientoAD
    End Sub
#End Region
End Class
