Imports START_AD
Imports START_ENTIDADES

Public Class IdiomaMap
#Region "Objetos privados"
    Dim idiomaAD As IdiomaAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
  

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Idioma
        Dim idioma As Idioma = idiomaAD.ConsultarPorId(id, Lazy)
        If Not Lazy Then
            Dim formatoCulturaAD = New FormatoCulturaAD
            idioma.FormatoCultura = formatoCulturaAD.ConsultarPorIdioma(idioma, Lazy)
        End If
        Return idioma
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Idioma)
        Dim idiomas As List(Of Idioma) = idiomaAD.ConsultarTodos(Lazy)
        For Each Idioma As Idioma In idiomas
            Dim formatoCulturaAD = New FormatoCulturaAD
            Idioma.FormatoCultura = formatoCulturaAD.ConsultarPorIdioma(Idioma, Lazy)
        Next
        Return idiomas
    End Function

    Public Function ConsultarPorUsuario(ByVal usuario As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Idioma)
        idiomaAD.ConsultarPorUsuario(usuario, Lazy)

        Dim idiomas As List(Of Idioma) = idiomaAD.ConsultarPorUsuario(usuario, Lazy)
        For Each Idioma As Idioma In idiomas
            Dim formatoCulturaAD = New FormatoCulturaAD
            Idioma.FormatoCultura = formatoCulturaAD.ConsultarPorIdioma(Idioma, Lazy)
        Next
        Return idiomas
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        idiomaAD = New IdiomaAD
    End Sub
#End Region
End Class
