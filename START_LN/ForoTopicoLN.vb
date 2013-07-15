Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class ForoTopicoLN
#Region "Objetos privados"
    Dim foroTopicoMap As foroTopicoMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef foroTopico As ForoTopico) As Integer
        Return foroTopicoMap.Insertar(foroTopico)
    End Function

    Public Function Actualizar(ByVal foroTopico As ForoTopico) As Integer
        Return foroTopicoMap.Actualizar(foroTopico)
    End Function

    Public Function Borrar(ByVal foroTopico As ForoTopico) As Integer
        Return foroTopicoMap.Borrar(foroTopico)       
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As ForoTopico
        Return foroTopicoMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As ForoTopico, Optional ByVal Lazy As Boolean = True) As List(Of ForoTopico)
        Return foroTopicoMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of ForoTopico)
        Return foroTopicoMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        foroTopicoMap = New foroTopicoMap
    End Sub
#End Region
End Class
