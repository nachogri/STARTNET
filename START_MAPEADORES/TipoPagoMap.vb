Imports START_AD
Imports START_ENTIDADES

Public Class TipoPagoMap
#Region "Objetos privados"
    Dim tipoPagoAD As TipoPagoAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef tipoPago As TipoPago) As Integer
        Return tipoPagoAD.Insertar(tipoPago)
    End Function

    Public Function Actualizar(ByVal tipoPago As TipoPago) As Integer
        Return tipoPagoAD.Actualizar(tipoPago)
    End Function

    Public Function Borrar(ByVal tipoPago As TipoPago) As Integer
        Return tipoPagoAD.Borrar(tipoPago)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As TipoPago
        Return tipoPagoAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As TipoPago, Optional ByVal Lazy As Boolean = True) As List(Of TipoPago)
        Return tipoPagoAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of TipoPago)
        Return tipoPagoAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        tipoPagoAD = New TipoPagoAD
    End Sub
#End Region
End Class
