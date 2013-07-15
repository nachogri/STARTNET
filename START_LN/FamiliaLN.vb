Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class familiaLN
#Region "Objetos privados"
    Dim familiaMap As familiaMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef familia As familia) As Integer
        Return familiaMap.Insertar(familia)
    End Function

    Public Function Actualizar(ByVal familia As familia) As Integer
        Return familiaMap.Actualizar(familia)
    End Function

    Public Function Borrar(ByVal familia As familia) As Integer
        Return familiaMap.Borrar(Familia)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As familia
        Return familiaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As familia, Optional ByVal Lazy As Boolean = True) As List(Of familia)
        Return familiaMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of familia)
        Return familiaMap.ConsultarTodos(Lazy)
    End Function

    Public Function ConsultarPorUsuario(ByVal usuario As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Familia)
        Return familiaMap.ConsultarPorUsuario(usuario, Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        familiaMap = New familiaMap
    End Sub
#End Region
End Class

