
Imports START_AD
Imports START_ENTIDADES

Public Class PaisMap
#Region "Objetos privados"
    Dim paisAD As PaisAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pais As Pais) As Integer
        Return PaisAD.Insertar(Pais)
    End Function

    Public Function Actualizar(ByVal pais As Pais) As Integer
        Return PaisAD.Actualizar(Pais)
    End Function

    Public Function Borrar(ByVal pais As Pais) As Integer
        Return PaisAD.Borrar(Pais)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Pais
        Dim pais As Pais = paisAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim provinciaAD As New ProvinciaAD
            Dim provincia As New Provincia
            provincia.Pais = pais
            pais.Provincias = provinciaAD.ConsultarPor(provincia, Lazy)
        End If

        Return pais
    End Function

    Public Function ConsultarPor(ByVal filtros As Pais, Optional ByVal Lazy As Boolean = True) As List(Of Pais)
        Dim paises As List(Of Pais) = paisAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each prov As Pais In paises
                Dim provinciaAD As New ProvinciaAD
                Dim provincia As New Provincia
                provincia.Pais = prov
                prov.Provincias = provinciaAD.ConsultarPor(provincia, Lazy)
            Next
        End If

        Return paises
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Pais)
        Dim paises As List(Of Pais) = paisAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each prov As Pais In paises
                Dim provinciaAD As New ProvinciaAD
                Dim provincia As New Provincia
                provincia.Pais = prov
                prov.Provincias = provinciaAD.ConsultarPor(provincia, Lazy)
            Next
        End If

        Return paises
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        paisAD = New PaisAD
    End Sub
#End Region
End Class
