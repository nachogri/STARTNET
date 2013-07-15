Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class TipoPagoLN
#Region "Objetos privados"
    Dim tipoPagoMap As TipoPagoMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef tipoPago As TipoPago) As Integer
        Return tipoPagoMap.Insertar(tipoPago)
    End Function

    Public Function Actualizar(ByVal tipoPago As TipoPago) As Integer
        Return tipoPagoMap.Actualizar(tipoPago)
    End Function

    Public Function Borrar(ByVal tipoPago As TipoPago) As Integer
        Return tipoPagoMap.Borrar(tipoPago)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As TipoPago
        Return tipoPagoMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As TipoPago, Optional ByVal Lazy As Boolean = True) As List(Of TipoPago)
        Return tipoPagoMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of TipoPago)
        Return tipoPagoMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        tipoPagoMap = New TipoPagoMap
    End Sub
#End Region
End Class

