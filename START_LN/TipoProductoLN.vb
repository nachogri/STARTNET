Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class TipoProductoLN
#Region "Objetos privados"
    Dim tipoProductoMap As tipoProductoMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef tipoProducto As TipoProducto) As Integer
        Return tipoProductoMap.Insertar(tipoProducto)
    End Function

    Public Function Actualizar(ByVal tipoProducto As TipoProducto) As Integer
        Return tipoProductoMap.Actualizar(tipoProducto)
    End Function

    Public Function Borrar(ByVal tipoProducto As TipoProducto) As Integer
        Return tipoProductoMap.Borrar(tipoProducto)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As TipoProducto
        Return tipoProductoMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As TipoProducto, Optional ByVal Lazy As Boolean = True) As List(Of TipoProducto)
        Return tipoProductoMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of TipoProducto)
        Return tipoProductoMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        tipoProductoMap = New tipoProductoMap
    End Sub
#End Region
End Class

