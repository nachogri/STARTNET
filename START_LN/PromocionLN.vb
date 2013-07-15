Imports START_MAPEADORES
Imports START_ENTIDADES
Imports System.Xml

Public Class promocionLN
#Region "Objetos privados"
    Dim promocionMap As promocionMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef promocion As promocion) As Integer
        Return promocionMap.Insertar(promocion)
    End Function

    Public Function Actualizar(ByVal promocion As Promocion, Optional ByVal Lazy As Boolean = True) As Integer
        Return promocionMap.Actualizar(promocion, Lazy)
    End Function

    Public Function Borrar(ByVal promocion As promocion) As Integer
        Return promocionMap.Borrar(promocion)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As promocion
        Return promocionMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As promocion, Optional ByVal Lazy As Boolean = True) As List(Of promocion)
        Return promocionMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of promocion)
        Return promocionMap.ConsultarTodos(Lazy)
    End Function
    Public Function ConsultarVigentes() As XmlDocument
        Return promocionMap.ConsultarVigentes()
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        promocionMap = New promocionMap
    End Sub
#End Region
End Class
