Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class PaisAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pais As Pais) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            pais.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppais_id", pais.Identificador))
            parametros.Add(New SqlParameter("@ppais_nacion", pais.Nacion))

            res = base.EjecutarInstruccion("SP_Paises_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal pais As Pais) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppais_id", pais.Identificador))
            parametros.Add(New SqlParameter("@ppais_nacion", pais.Nacion))

            res = base.EjecutarInstruccion("SP_Paises_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal pais As Pais) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppais_id", pais.Identificador))

            res = base.EjecutarInstruccion("SP_Paises_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Pais
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppais_id", id))


            reader = base.ConsultarReader("SP_Paises_Consultar", parametros)

            reader.Read()
            Dim pais As New Pais
            pais.Identificador = reader(0)
            pais.Nacion = reader(1)
            If Not reader Is Nothing Then reader.Close()

            Return pais
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Pais, Optional ByVal Lazy As Boolean = True) As List(Of Pais)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)


            parametros.Add(New SqlParameter("@ppais_nacion", filtros.Nacion))

            reader = base.ConsultarReader("SP_Paises_ConsultarPor", parametros)

            Dim paiss As New List(Of Pais)
            Do While reader.Read()
                Dim pais As New Pais
                pais.Identificador = reader(0)
                pais.Nacion = reader(1)
                paiss.Add(pais)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return paiss

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Pais)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Paises_ConsultarTodos")

            Dim paiss As New List(Of Pais)
            Do While reader.Read()
                Dim pais As New Pais
                pais.Identificador = reader(0)
                pais.Nacion = reader(1)
                paiss.Add(pais)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return paiss
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

