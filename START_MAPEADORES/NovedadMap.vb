Imports START_AD
Imports START_ENTIDADES

Public Class NovedadMap
#Region "Objetos privados"
    Dim novedadAD As NovedadAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef novedad As Novedad) As Integer
        Return novedadAD.Insertar(novedad)        
    End Function

    Public Function Actualizar(ByVal novedad As Novedad) As Integer
        Return novedadAD.Actualizar(novedad)
    End Function

    Public Function Borrar(ByVal novedad As Novedad) As Integer
        Return novedadAD.Borrar(novedad)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Novedad
        Return novedadAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Novedad, Optional ByVal Lazy As Boolean = True) As List(Of Novedad)
        Return novedadAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Novedad)
        Return novedadAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        novedadAD = New NovedadAD
    End Sub
#End Region
End Class
