

Imports START_AD
Imports START_ENTIDADES

Public Class DescargaMap
#Region "Objetos privados"
    Dim descargaAD As DescargaAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef Descarga As Descarga) As Integer
        Return descargaAD.Insertar(Descarga)
    End Function

    Public Function Actualizar(ByVal Descarga As Descarga) As Integer
        Return descargaAD.Actualizar(Descarga)
    End Function

    Public Function Borrar(ByVal Descarga As Descarga) As Integer
        Return descargaAD.Borrar(Descarga)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Descarga
        Return descargaAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Descarga, Optional ByVal Lazy As Boolean = True) As List(Of Descarga)
        Return descargaAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Descarga)
        Return descargaAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        descargaAD = New DescargaAD
    End Sub
#End Region
End Class
