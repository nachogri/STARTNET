Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class seguimientoLN
#Region "Objetos privados"
    Dim SeguimientoMap As SeguimientoMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef seguimiento As seguimiento) As Integer
        Return seguimientoMap.Insertar(seguimiento)
    End Function

    Public Function Actualizar(ByVal seguimiento As seguimiento) As Integer
        Return seguimientoMap.Actualizar(seguimiento)
    End Function

    Public Function Borrar(ByVal seguimiento As seguimiento) As Integer
        Return seguimientoMap.Borrar(seguimiento)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As seguimiento
        Return seguimientoMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As seguimiento, Optional ByVal Lazy As Boolean = True) As List(Of seguimiento)
        Return seguimientoMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of seguimiento)
        Return seguimientoMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        seguimientoMap = New seguimientoMap
    End Sub
#End Region
End Class

