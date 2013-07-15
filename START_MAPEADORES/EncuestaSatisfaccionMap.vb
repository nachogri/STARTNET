Imports START_AD
Imports START_ENTIDADES

Public Class EncuestaSatisfaccionMap

#Region "Objetos privados"
    Dim encuestaAD As EncuestaSatisfaccionAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef encuesta As EncuestaSatisfaccion) As Integer
        Return encuestaAD.Insertar(encuesta)
    End Function

    Public Function Actualizar(ByVal encuesta As EncuestaSatisfaccion) As Integer
        Return encuestaAD.Actualizar(encuesta)
    End Function

    Public Function Borrar(ByVal encuesta As EncuestaSatisfaccion) As Integer
        Return encuestaAD.Borrar(encuesta)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As EncuestaSatisfaccion
        Return encuestaAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As EncuestaSatisfaccion, Optional ByVal Lazy As Boolean = True) As List(Of EncuestaSatisfaccion)
        Return encuestaAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of EncuestaSatisfaccion)
        Return encuestaAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        encuestaAD = New EncuestaSatisfaccionAD
    End Sub
#End Region
End Class
