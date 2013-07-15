Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class PagoProveedorLN
#Region "Objetos privados"
    Dim pagoProveedorMap As pagoProveedorMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pagoProveedor As PagoProveedor) As Integer
        Return pagoProveedorMap.Insertar(pagoProveedor)
    End Function

    Public Function Actualizar(ByVal pagoProveedor As PagoProveedor) As Integer
        Return pagoProveedorMap.Actualizar(pagoProveedor)
    End Function

    Public Function Borrar(ByVal pagoProveedor As PagoProveedor) As Integer
        Return pagoProveedorMap.Borrar(pagoProveedor)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As PagoProveedor
        Return pagoProveedorMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As PagoProveedor, Optional ByVal Lazy As Boolean = True) As List(Of PagoProveedor)
        Return pagoProveedorMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of PagoProveedor)
        Return pagoProveedorMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        pagoProveedorMap = New pagoProveedorMap
    End Sub
#End Region
End Class

