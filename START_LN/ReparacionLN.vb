Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class ReparacionLN
#Region "Objetos privados"
    Dim reparacionMap As ReparacionMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef reparacion As Reparacion) As Integer
        Return reparacionMap.Insertar(reparacion)
    End Function

    Public Function Actualizar(ByVal reparacion As Reparacion, Optional ByVal Lazy As Boolean = True) As Integer
        Return reparacionMap.Actualizar(reparacion, Lazy)
    End Function

    Public Function Borrar(ByVal reparacion As Reparacion) As Integer
        Return reparacionMap.Borrar(reparacion)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Reparacion
        Return reparacionMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Reparacion, Optional ByVal Lazy As Boolean = True) As List(Of Reparacion)
        Return reparacionMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Reparacion)
        Return reparacionMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        reparacionMap = New ReparacionMap
    End Sub
#End Region
End Class
