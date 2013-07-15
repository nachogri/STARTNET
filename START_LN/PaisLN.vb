Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class PaisLN
#Region "Objetos privados"
    Dim paisMap As PaisMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pais As Pais) As Integer
        Return paisMap.Insertar(pais)
    End Function

    Public Function Actualizar(ByVal pais As Pais) As Integer
        Return paisMap.Actualizar(pais)
    End Function

    Public Function Borrar(ByVal pais As Pais) As Integer
        Return paisMap.Borrar(pais)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Pais
        Return paisMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Pais, Optional ByVal Lazy As Boolean = True) As List(Of Pais)
        Return paisMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Pais)
        Return paisMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        paisMap = New PaisMap
    End Sub
#End Region
End Class
