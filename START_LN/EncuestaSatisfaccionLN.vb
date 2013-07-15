Imports START_ENTIDADES
Imports START_MAPEADORES

Public Class EncuestaSatisfaccionLN

#Region "Objetos privados"
    Dim encuestaMap As EncuestaSatisfaccionMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef encuesta As EncuestaSatisfaccion) As Integer
        Return encuestaMap.Insertar(encuesta)
    End Function

    Public Function Actualizar(ByVal encuesta As EncuestaSatisfaccion) As Integer
        Return encuestaMap.Actualizar(encuesta)
    End Function

    Public Function Borrar(ByVal encuesta As EncuestaSatisfaccion) As Integer
        Return encuestaMap.Borrar(encuesta)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As EncuestaSatisfaccion
        Return encuestaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As EncuestaSatisfaccion, Optional ByVal Lazy As Boolean = True) As List(Of EncuestaSatisfaccion)
        Return encuestaMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of EncuestaSatisfaccion)
        Return encuestaMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        encuestaMap = New EncuestaSatisfaccionMap
    End Sub
#End Region
End Class
