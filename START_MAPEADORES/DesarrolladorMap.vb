
Imports START_AD
Imports START_ENTIDADES

Public Class DesarrolladorMap
#Region "Objetos privados"
    Dim DesarrolladorAD As DesarrolladorAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef Desarrollador As Desarrollador) As Integer
        Return DesarrolladorAD.Insertar(Desarrollador)
    End Function

    Public Function Actualizar(ByVal Desarrollador As Desarrollador) As Integer
        Return DesarrolladorAD.Actualizar(Desarrollador)
    End Function

    Public Function Borrar(ByVal Desarrollador As Desarrollador) As Integer
        Return DesarrolladorAD.Borrar(Desarrollador)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Desarrollador
        Return DesarrolladorAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Desarrollador, Optional ByVal Lazy As Boolean = True) As List(Of Desarrollador)
        Return DesarrolladorAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Desarrollador)
        Return DesarrolladorAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        DesarrolladorAD = New DesarrolladorAD
    End Sub
#End Region
End Class
