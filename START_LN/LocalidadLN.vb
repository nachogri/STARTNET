Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class LocalidadLN
#Region "Objetos privados"
    Dim localidadMap As localidadMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef localidad As Localidad) As Integer
        Return localidadMap.Insertar(localidad)
    End Function

    Public Function Actualizar(ByVal localidad As Localidad) As Integer
        Return localidadMap.Actualizar(localidad)
    End Function

    Public Function Borrar(ByVal localidad As Localidad) As Integer
        Return localidadMap.Borrar(localidad)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Localidad
        Return localidadMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Localidad, Optional ByVal Lazy As Boolean = True) As List(Of Localidad)
        Return localidadMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Localidad)
        Return localidadMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        localidadMap = New localidadMap
    End Sub
#End Region
End Class
