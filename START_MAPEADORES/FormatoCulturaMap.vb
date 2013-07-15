Imports START_AD
Imports START_ENTIDADES

Public Class formatoCulturaMap
#Region "Objetos privados"
    Dim formatoCulturaAD As formatoCulturaAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As FormatoCultura
        Return formatoCulturaAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of formatoCultura)
        Return formatoCulturaAD.ConsultarTodos(Lazy)
    End Function

    Public Function ConsultarPorIdioma(ByVal idioma As Idioma, Optional ByVal Lazy As Boolean = True) As FormatoCultura
        Return formatoCulturaAD.ConsultarPorIdioma(idioma, Lazy)
    End Function

#End Region

#Region "Constructores"
    Public Sub New()
        formatoCulturaAD = New formatoCulturaAD
    End Sub
#End Region
End Class
