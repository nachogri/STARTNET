Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class ProveedorLN
#Region "Objetos privados"
    Dim proveedorMap As ProveedorMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef proveedor As Proveedor) As Integer
        Return proveedorMap.Insertar(proveedor)
    End Function

    Public Function Actualizar(ByVal proveedor As Proveedor, Optional ByVal Lazy As Boolean = True) As Integer
        Return proveedorMap.Actualizar(proveedor, Lazy)
    End Function

    Public Function Borrar(ByVal proveedor As Proveedor) As Integer
        Return proveedorMap.Borrar(proveedor)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Proveedor
        Return proveedorMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Proveedor, Optional ByVal Lazy As Boolean = True) As List(Of Proveedor)
        Return proveedorMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Proveedor)
        Return proveedorMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        proveedorMap = New ProveedorMap
    End Sub
#End Region
End Class
