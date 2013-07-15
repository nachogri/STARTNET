Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class patenteLN
#Region "Objetos privados"
    Dim patenteMap As patenteMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef patente As patente) As Integer
        Return PatenteMap.Insertar(Patente)
    End Function

    Public Function Actualizar(ByVal patente As patente) As Integer
        Return PatenteMap.Actualizar(Patente)
    End Function

    Public Function Borrar(ByVal patente As patente) As Integer
        Return PatenteMap.Borrar(Patente)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As patente
        Return patenteMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As patente, Optional ByVal Lazy As Boolean = True) As List(Of patente)
        Return PatenteMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of patente)
        Return PatenteMap.ConsultarTodos(Lazy)
    End Function

    Public Function ConsultarPorFamilia(ByVal familia As Familia, Optional ByVal Lazy As Boolean = True) As List(Of Patente)
        Return patenteMap.ConsultarPorFamilia(familia, Lazy)
    End Function

    Public Function ConsultarPorUsuario(ByVal usuario As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Patente)
        Return patenteMap.ConsultarPorUsuario(usuario, Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        PatenteMap = New PatenteMap
    End Sub
#End Region
End Class

