Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class novedadLN
#Region "Objetos privados"
    Dim novedadMap As NovedadMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef novedad As novedad) As Integer
        Return novedadMap.Insertar(novedad)
    End Function

    Public Function Actualizar(ByVal novedad As novedad) As Integer
        Return novedadMap.Actualizar(novedad)
    End Function

    Public Function Borrar(ByVal novedad As novedad) As Integer
        Return novedadMap.Borrar(novedad)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As novedad
        Return novedadMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As novedad, Optional ByVal Lazy As Boolean = True) As List(Of novedad)
        Return novedadMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of novedad)
        Return novedadMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        novedadMap = New novedadMap
    End Sub
#End Region
End Class
