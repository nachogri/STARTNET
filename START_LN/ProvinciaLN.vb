Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class ProvinciaLN
#Region "Objetos privados"
    Dim provinciaMap As ProvinciaMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef provincia As Provincia) As Integer
        Return provinciaMap.Insertar(provincia)
    End Function

    Public Function Actualizar(ByVal provincia As Provincia) As Integer
        Return provinciaMap.Actualizar(provincia)
    End Function

    Public Function Borrar(ByVal provincia As Provincia) As Integer
        Return provinciaMap.Borrar(provincia)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Provincia
        Return provinciaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Provincia, Optional ByVal Lazy As Boolean = True) As List(Of Provincia)
        Return provinciaMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Provincia)
        Return provinciaMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        provinciaMap = New ProvinciaMap
    End Sub
#End Region
End Class

