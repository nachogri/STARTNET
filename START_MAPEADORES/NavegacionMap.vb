Imports START_AD
Imports START_ENTIDADES

Public Class NavegacionMap
#Region "Objetos privados"
    Dim navegacionAD As NavegacionAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef navegacion As Navegacion) As Integer
        Return navegacionAD.Insertar(navegacion)
    End Function

    Public Function Actualizar(ByVal navegacion As Navegacion) As Integer
        Return navegacionAD.Actualizar(navegacion)
    End Function

    Public Function Borrar(ByVal navegacion As Navegacion) As Integer
        Return navegacionAD.Borrar(navegacion)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Navegacion
        Return navegacionAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Navegacion, Optional ByVal Lazy As Boolean = True) As List(Of Navegacion)
        Return navegacionAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Navegacion)
        Return navegacionAD.ConsultarTodos(Lazy)
    End Function

    Public Function ConsultarPorLogueo(ByRef logueo As Logueo, Optional ByVal Lazy As Boolean = True) As List(Of Navegacion)
        Return navegacionAD.ConsultarPorLogueo(logueo, Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        navegacionAD = New NavegacionAD
    End Sub
#End Region
End Class
