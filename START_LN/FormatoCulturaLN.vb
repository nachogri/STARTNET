Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class formatoCulturaLN
#Region "Objetos privados"
    Dim formatoCulturaMap As formatoCulturaMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As formatoCultura
        Return formatoCulturaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of formatoCultura)
        Return formatoCulturaMap.ConsultarTodos(Lazy)
    End Function

    Public Function ConsultarPorIdioma(ByVal idioma As Idioma, Optional ByVal Lazy As Boolean = True) As FormatoCultura
        Return formatoCulturaMap.ConsultarPorIdioma(idioma, Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        formatoCulturaMap = New formatoCulturaMap
    End Sub
#End Region
End Class
