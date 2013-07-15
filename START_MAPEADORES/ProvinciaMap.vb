Imports START_AD
Imports START_ENTIDADES

Public Class ProvinciaMap
#Region "Objetos privados"
    Dim provinciaAD As ProvinciaAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef provincia As Provincia) As Integer
        Return ProvinciaAD.Insertar(Provincia)
    End Function

    Public Function Actualizar(ByVal provincia As Provincia) As Integer
        Return ProvinciaAD.Actualizar(Provincia)
    End Function

    Public Function Borrar(ByVal provincia As Provincia) As Integer
        Return ProvinciaAD.Borrar(Provincia)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Provincia
        Dim provincia As Provincia = provinciaAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim localidadAD As New LocalidadAD
            Dim localidad As New Localidad
            localidad.Provincia = provincia
            provincia.Localidades = localidadAD.ConsultarPor(localidad, Lazy)
        End If
        
        Return provincia
    End Function

    Public Function ConsultarPor(ByVal filtros As Provincia, Optional ByVal Lazy As Boolean = True) As List(Of Provincia)
        Dim provincias As List(Of Provincia) = provinciaAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each prov As Provincia In provincias
                Dim localidadAD As New LocalidadAD
                Dim localidad As New Localidad
                localidad.Provincia = prov
                prov.Localidades = localidadAD.ConsultarPor(localidad, Lazy)
            Next
        End If

        Return provincias
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Provincia)
        Dim provincias As List(Of Provincia) = provinciaAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each prov As Provincia In provincias
                Dim localidadAD As New LocalidadAD
                Dim localidad As New Localidad
                localidad.Provincia = prov
                prov.Localidades = localidadAD.ConsultarPor(localidad, Lazy)
            Next
        End If

        Return provincias
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        ProvinciaAD = New ProvinciaAD
    End Sub
#End Region
End Class


