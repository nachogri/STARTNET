Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class ProductoLN
#Region "Objetos privados"
    Dim ProductoMap As ProductoMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef Producto As Producto) As Integer
        Return ProductoMap.Insertar(Producto)
    End Function

    Public Function Actualizar(ByVal Producto As Producto) As Integer
        Return ProductoMap.Actualizar(Producto)
    End Function

    Public Function Borrar(ByVal Producto As Producto) As Integer
        Return ProductoMap.Borrar(Producto)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Producto
        Return ProductoMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Producto, Optional ByVal Lazy As Boolean = True) As List(Of Producto)
        Return ProductoMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Producto)
        Return ProductoMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        ProductoMap = New ProductoMap
    End Sub
#End Region
End Class
