

Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class ProvinciaAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef provincia As Provincia) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            provincia.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pprov_id", provincia.Identificador))
            parametros.Add(New SqlParameter("@pprov_nombre", provincia.Nombre))
            If Not provincia.Pais Is Nothing Then
                parametros.Add(New SqlParameter("@pprov_pais_id", provincia.Pais.Identificador))
            End If


            res = base.EjecutarInstruccion("SP_Provincias_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal provincia As Provincia) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pprov_id", provincia.Identificador))
            parametros.Add(New SqlParameter("@pprov_nombre", provincia.Nombre))
            If Not provincia.Pais Is Nothing Then
                parametros.Add(New SqlParameter("@pprov_pais_id", provincia.Pais.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_Provincias_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal provincia As Provincia) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pprov_id", provincia.Identificador))

            res = base.EjecutarInstruccion("SP_Provincias_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Provincia
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pprov_id", id))

            reader = base.ConsultarReader("SP_Provincias_Consultar", parametros)
            reader.Read()

            Dim provincia As New Provincia
            provincia.Identificador = reader(0)
            provincia.Nombre = reader(1)

            If Not Lazy Then
                Dim paisAD = New PaisAD
                provincia.Pais = paisAD.ConsultarPorId(reader(2))
            End If

            If Not reader Is Nothing Then reader.Close()
            Return provincia
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Provincia, Optional ByVal Lazy As Boolean = True) As List(Of Provincia)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pprov_nombre", filtros.Nombre))
            If Not filtros.Pais Is Nothing Then
                parametros.Add(New SqlParameter("@pprov_pais_id", filtros.Pais.Identificador))
            End If

            reader = base.ConsultarReader("SP_Provincias_ConsultarPor", parametros)

            Dim provincias As New List(Of Provincia)
            Do While reader.Read()
                Dim provincia As New Provincia
                provincia.Identificador = reader(0)
                provincia.Nombre = reader(1)

                If Not Lazy Then
                    Dim paisAD = New PaisAD
                    provincia.Pais = paisAD.ConsultarPorId(reader(2))
                End If


                provincias.Add(provincia)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return provincias

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Provincia)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Provincias_ConsultarTodos")

            Dim provincias As New List(Of Provincia)
            Do While reader.Read()
                Dim provincia As New Provincia
                provincia.Identificador = reader(0)
                provincia.Nombre = reader(1)

                If Not Lazy Then
                    Dim paisAD = New PaisAD
                    provincia.Pais = paisAD.ConsultarPorId(reader(2))
                End If

                provincias.Add(provincia)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return provincias
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region


End Class

