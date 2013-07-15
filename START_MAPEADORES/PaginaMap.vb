Imports START_AD
Imports START_ENTIDADES

Public Class PaginaMap
#Region "Objetos privados"
    Dim paginaAD As PaginaAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pagina As Pagina) As Integer
        Return paginaAD.Insertar(pagina)
    End Function

    Public Function Actualizar(ByVal pagina As Pagina) As Integer
        Return paginaAD.Actualizar(pagina)
    End Function

    Public Function Borrar(ByVal pagina As Pagina) As Integer
        Return paginaAD.Borrar(pagina)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Pagina
        Return paginaAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Pagina, Optional ByVal Lazy As Boolean = True) As List(Of Pagina)
        Return paginaAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Pagina)
        Return paginaAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        paginaAD = New PaginaAD
    End Sub
#End Region
End Class
