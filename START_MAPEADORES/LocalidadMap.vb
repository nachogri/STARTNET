Imports START_AD
Imports START_ENTIDADES

Public Class LocalidadMap
#Region "Objetos privados"
    Dim localidadAD As LocalidadAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef localidad As Localidad) As Integer
        Return localidadAD.Insertar(localidad)
    End Function

    Public Function Actualizar(ByVal localidad As Localidad) As Integer
        Return localidadAD.Actualizar(localidad)
    End Function

    Public Function Borrar(ByVal localidad As Localidad) As Integer
        Return localidadAD.Borrar(localidad)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Localidad
        Return localidadAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Localidad, Optional ByVal Lazy As Boolean = True) As List(Of Localidad)
        Return localidadAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Localidad)
        Return localidadAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        localidadAD = New LocalidadAD
    End Sub
#End Region
End Class
