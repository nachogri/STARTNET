Imports START_AD
Imports START_ENTIDADES

Public Class ProductoMap
#Region "Objetos privados"
    Dim ProductoAD As ProductoAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef Producto As Producto) As Integer
        Return ProductoAD.Insertar(Producto)
    End Function

    Public Function Actualizar(ByVal Producto As Producto) As Integer
        Return ProductoAD.Actualizar(Producto)
    End Function

    Public Function Borrar(ByVal Producto As Producto) As Integer
        Return ProductoAD.Borrar(Producto)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Producto
        Return ProductoAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Producto, Optional ByVal Lazy As Boolean = True) As List(Of Producto)
        Return ProductoAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Producto)
        Return ProductoAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        ProductoAD = New ProductoAD
    End Sub
#End Region
End Class
