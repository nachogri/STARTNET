Imports START_AD
Imports START_ENTIDADES

Public Class foroComentarioMap
#Region "Objetos privados"
    Dim foroComentarioAD As foroComentarioAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef foroComentario As foroComentario) As Integer
        Return foroComentarioAD.Insertar(foroComentario)
    End Function

    Public Function Actualizar(ByVal foroComentario As foroComentario) As Integer
        Return foroComentarioAD.Actualizar(foroComentario)
    End Function

    Public Function Borrar(ByVal foroComentario As foroComentario) As Integer
        Return foroComentarioAD.Borrar(foroComentario)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As foroComentario
        Return foroComentarioAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As foroComentario, Optional ByVal Lazy As Boolean = True) As List(Of foroComentario)
        Return foroComentarioAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of foroComentario)
        Return foroComentarioAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        foroComentarioAD = New foroComentarioAD
    End Sub
#End Region
End Class
