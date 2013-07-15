Imports START_AD
Imports START_ENTIDADES

Public Class TareaMap
#Region "Objetos privados"
    Dim tareaAD As TareaAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef tarea As Tarea) As Integer
        Return tareaAD.Insertar(tarea)
    End Function

    Public Function Actualizar(ByVal tarea As Tarea) As Integer
        Return tareaAD.Actualizar(tarea)
    End Function

    Public Function Borrar(ByVal tarea As Tarea) As Integer
        Return tareaAD.Borrar(tarea)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Tarea
        Return tareaAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Tarea, Optional ByVal Lazy As Boolean = True) As List(Of Tarea)
        Return tareaAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Tarea)
        Return tareaAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        tareaAD = New TareaAD
    End Sub
#End Region
End Class
