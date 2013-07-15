
Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class DesarrolladorLN
#Region "Objetos privados"
    Dim DesarrolladorMap As DesarrolladorMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef Desarrollador As Desarrollador) As Integer
        Return DesarrolladorMap.Insertar(Desarrollador)
    End Function

    Public Function Actualizar(ByVal Desarrollador As Desarrollador) As Integer
        Return DesarrolladorMap.Actualizar(Desarrollador)
    End Function

    Public Function Borrar(ByVal Desarrollador As Desarrollador) As Integer
        Return DesarrolladorMap.Borrar(Desarrollador)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Desarrollador
        Return DesarrolladorMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Desarrollador, Optional ByVal Lazy As Boolean = True) As List(Of Desarrollador)
        Return DesarrolladorMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Desarrollador)
        Return DesarrolladorMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        DesarrolladorMap = New DesarrolladorMap
    End Sub
#End Region
End Class
