Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class LogueoLN
#Region "Objetos privados"
    Dim logueoMap As logueoMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef logueo As Logueo) As Integer
        Return logueoMap.Insertar(logueo)
    End Function

    Public Function Actualizar(ByVal logueo As Logueo) As Integer
        Return logueoMap.Actualizar(logueo)
    End Function

    Public Function Borrar(ByVal logueo As Logueo) As Integer
        Return logueoMap.Borrar(logueo)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Logueo
        Return logueoMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Logueo, Optional ByVal Lazy As Boolean = True) As List(Of Logueo)
        Return logueoMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Logueo)
        Return logueoMap.ConsultarTodos(Lazy)
    End Function

#End Region

#Region "Constructores"
    Public Sub New()
        logueoMap = New logueoMap
    End Sub
#End Region
End Class

