Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class TareaLN
#Region "Objetos privados"
    Dim tareaMap As TareaMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef tarea As Tarea) As Integer
        Return tareaMap.Insertar(tarea)
    End Function

    Public Function Actualizar(ByVal tarea As Tarea) As Integer
        Return tareaMap.Actualizar(tarea)
    End Function

    Public Function Borrar(ByVal tarea As Tarea) As Integer
        Return tareaMap.Borrar(tarea)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Tarea
        Return tareaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Tarea, Optional ByVal Lazy As Boolean = True) As List(Of Tarea)
        Return tareaMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Tarea)
        Return tareaMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        tareaMap = New TareaMap
    End Sub
#End Region
End Class
