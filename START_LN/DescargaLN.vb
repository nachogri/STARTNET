Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class DescargaLN
#Region "Objetos privados"
    Dim DescargaMap As DescargaMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef Descarga As Descarga) As Integer
        Return DescargaMap.Insertar(Descarga)
    End Function

    Public Function Actualizar(ByVal Descarga As Descarga) As Integer
        Return DescargaMap.Actualizar(Descarga)
    End Function

    Public Function Borrar(ByVal Descarga As Descarga) As Integer
        Return DescargaMap.Borrar(Descarga)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Descarga
        Return DescargaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Descarga, Optional ByVal Lazy As Boolean = True) As List(Of Descarga)
        Return DescargaMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Descarga)
        Return DescargaMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        DescargaMap = New DescargaMap
    End Sub
#End Region
End Class
