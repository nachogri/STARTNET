Imports START_AD
Imports START_ENTIDADES

Public Class ForoTopicoMap
#Region "Objetos privados"
    Dim foroTopicoAD As ForoTopicoAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef foroTopico As ForoTopico) As Integer
        Return foroTopicoAD.Insertar(foroTopico)
    End Function

    Public Function Actualizar(ByVal foroTopico As ForoTopico) As Integer
        Return foroTopicoAD.Actualizar(foroTopico)
    End Function

    Public Function Borrar(ByVal foroTopico As ForoTopico) As Integer
        Return foroTopicoAD.Borrar(foroTopico)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As ForoTopico
        Return foroTopicoAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As ForoTopico, Optional ByVal Lazy As Boolean = True) As List(Of ForoTopico)
        Return foroTopicoAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of ForoTopico)
        Return foroTopicoAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        foroTopicoAD = New ForoTopicoAD
    End Sub
#End Region
End Class
