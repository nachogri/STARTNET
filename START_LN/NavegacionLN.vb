Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class NavegacionLN
#Region "Objetos privados"
    Dim navegacionMap As navegacionMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef navegacion As Navegacion) As Integer
        Return navegacionMap.Insertar(navegacion)
    End Function

    Public Function Actualizar(ByVal navegacion As Navegacion) As Integer
        Return navegacionMap.Actualizar(navegacion)
    End Function

    Public Function Borrar(ByVal navegacion As Navegacion) As Integer
        Return navegacionMap.Borrar(navegacion)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Navegacion
        Return navegacionMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Navegacion, Optional ByVal Lazy As Boolean = True) As List(Of Navegacion)
        Return navegacionMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Navegacion)
        Return navegacionMap.ConsultarTodos(Lazy)
    End Function

    Public Function ConsultarPorLogueo(ByRef logueo As Logueo, Optional ByVal Lazy As Boolean = True) As List(Of Navegacion)
        Return navegacionMap.ConsultarPorLogueo(logueo, Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        navegacionMap = New navegacionMap
    End Sub
#End Region
End Class
