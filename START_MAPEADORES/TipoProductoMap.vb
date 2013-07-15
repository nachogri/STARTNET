Imports START_AD
Imports START_ENTIDADES

Public Class TipoProductoMap
#Region "Objetos privados"
    Dim tipoProductoAD As TipoProductoAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef tipoProducto As TipoProducto) As Integer
        Return tipoProductoAD.Insertar(tipoProducto)
    End Function

    Public Function Actualizar(ByVal tipoProducto As TipoProducto) As Integer
        Return tipoProductoAD.Actualizar(tipoProducto)
    End Function

    Public Function Borrar(ByVal tipoProducto As TipoProducto) As Integer
        Return tipoProductoAD.Borrar(tipoProducto)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As TipoProducto
        Return tipoProductoAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As TipoProducto, Optional ByVal Lazy As Boolean = True) As List(Of TipoProducto)
        Return tipoProductoAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of TipoProducto)
        Return tipoProductoAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        tipoProductoAD = New TipoProductoAD
    End Sub
#End Region
End Class
