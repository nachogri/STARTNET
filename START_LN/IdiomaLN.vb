Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class IdiomaLN
#Region "Objetos privados"
    Dim idiomaMap As idiomaMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    
    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Idioma
        Return idiomaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPorUsuario(ByVal usuario As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Idioma)
        Return idiomaMap.ConsultarPorUsuario(usuario, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Idioma)
        Return idiomaMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        idiomaMap = New IdiomaMap
    End Sub
#End Region
End Class
