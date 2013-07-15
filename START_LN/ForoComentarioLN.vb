Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class foroComentarioLN
#Region "Objetos privados"
    Dim foroComentarioMap As foroComentarioMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef foroComentario As foroComentario) As Integer
        Return foroComentarioMap.Insertar(foroComentario)
    End Function

    Public Function Actualizar(ByVal foroComentario As foroComentario) As Integer
        Return foroComentarioMap.Actualizar(foroComentario)
    End Function

    Public Function Borrar(ByVal foroComentario As foroComentario) As Integer
        Return foroComentarioMap.Borrar(foroComentario)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As foroComentario
        Return foroComentarioMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As foroComentario, Optional ByVal Lazy As Boolean = True) As List(Of foroComentario)
        Return foroComentarioMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of foroComentario)
        Return foroComentarioMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        foroComentarioMap = New foroComentarioMap
    End Sub
#End Region
End Class
