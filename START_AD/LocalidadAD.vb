
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class LocalidadAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef localidad As Localidad) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            localidad.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ploc_id", localidad.Identificador))
            parametros.Add(New SqlParameter("@ploc_nombre", localidad.Nombre))
            parametros.Add(New SqlParameter("@ploc_cp", localidad.CP))
            If Not localidad.Provincia Is Nothing Then
                parametros.Add(New SqlParameter("@ploc_prov_id", localidad.Provincia.Identificador))
            End If


            res = base.EjecutarInstruccion("SP_Localidades_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal localidad As Localidad) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ploc_id", localidad.Identificador))
            parametros.Add(New SqlParameter("@ploc_nombre", localidad.Nombre))
            parametros.Add(New SqlParameter("@ploc_cp", localidad.CP))
            If Not localidad.Provincia Is Nothing Then
                parametros.Add(New SqlParameter("@ploc_prov_id", localidad.Provincia.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_Localidades_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal localidad As Localidad) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ploc_id", localidad.Identificador))

            res = base.EjecutarInstruccion("SP_Localidades_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Localidad
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ploc_id", id))

            reader = base.ConsultarReader("SP_Localidades_Consultar", parametros)

            reader.Read()
            Dim localidad As New Localidad
            localidad.Identificador = reader(0)
            localidad.Nombre = reader(1)
            localidad.CP = reader(2)

            If Not Lazy Then
                Dim provinciaAD = New ProvinciaAD
                localidad.Provincia = provinciaAD.ConsultarPorId(reader(3), Lazy)
            End If
            If Not reader Is Nothing Then reader.Close()


            Return localidad
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Localidad, Optional ByVal Lazy As Boolean = True) As List(Of Localidad)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ploc_nombre", filtros.Nombre))
            parametros.Add(New SqlParameter("@ploc_cp", filtros.CP))
            If Not filtros.Provincia Is Nothing Then
                parametros.Add(New SqlParameter("@ploc_prov_id", filtros.Provincia.Identificador))
            End If

            reader = base.ConsultarReader("SP_Localidades_ConsultarPor", parametros)

            Dim localidads As New List(Of Localidad)
            Do While reader.Read()
                Dim localidad As New Localidad
                localidad.Identificador = reader(0)
                localidad.Nombre = reader(1)
                localidad.CP = reader(2)

                If Not Lazy Then
                    Dim provinciaAD = New ProvinciaAD
                    localidad.Provincia = provinciaAD.ConsultarPorId(reader(3))
                End If

                localidads.Add(localidad)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return localidads

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Localidad)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Localidades_ConsultarTodos")

            Dim localidads As New List(Of Localidad)
            Do While reader.Read()
                Dim localidad As New Localidad
                localidad.Identificador = reader(0)
                localidad.Nombre = reader(1)
                localidad.CP = reader(2)

                If Not Lazy Then
                    Dim provinciaAD = New ProvinciaAD
                    localidad.Provincia = provinciaAD.ConsultarPorId(reader(3))
                End If

                localidads.Add(localidad)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return localidads
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

