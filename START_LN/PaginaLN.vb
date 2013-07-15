Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class PaginaLN
#Region "Objetos privados"
    Dim paginaMap As PaginaMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pagina As Pagina) As Integer
        Return paginaMap.Insertar(pagina)
    End Function

    Public Function Actualizar(ByVal pagina As Pagina) As Integer
        Return paginaMap.Actualizar(pagina)
    End Function

    Public Function Borrar(ByVal pagina As Pagina) As Integer
        Return paginaMap.Borrar(pagina)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Pagina
        Return paginaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Pagina, Optional ByVal Lazy As Boolean = True) As List(Of Pagina)
        Return paginaMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Pagina)
        Return paginaMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        paginaMap = New PaginaMap
    End Sub
#End Region
End Class
