Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class PatenteAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef patente As Patente) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            patente.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppat_id", patente.Identificador))
            parametros.Add(New SqlParameter("@ppat_descrip", patente.Descripcion))

            res = base.EjecutarInstruccion("SP_Patentes_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal patente As Patente) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppat_id", patente.Identificador))
            parametros.Add(New SqlParameter("@ppat_descrip", patente.Descripcion))

            res = base.EjecutarInstruccion("SP_Patentes_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal patente As Patente) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppat_id", patente.Identificador))

            res = base.EjecutarInstruccion("SP_Patentes_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Patente
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppat_id", id))

            reader = base.ConsultarReader("SP_Patentes_Consultar", parametros)

            reader.Read()
            Dim patente As New Patente
            patente.Identificador = reader(0)
            patente.Descripcion = reader(1)
            If Not reader Is Nothing Then reader.Close()


            Return patente
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Patente, Optional ByVal Lazy As Boolean = True) As List(Of Patente)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppat_descrip", filtros.Descripcion))

            reader = base.ConsultarReader("SP_Patentes_ConsultarPor", parametros)

            Dim patentes As New List(Of Patente)
            Do While reader.Read()
                Dim patente As New Patente
                patente.Identificador = reader(0)
                patente.Descripcion = reader(1)

                patentes.Add(patente)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return patentes

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Patente)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Patentes_ConsultarTodos")

            Dim patentes As New List(Of Patente)
            Do While reader.Read()
                Dim patente As New Patente
                patente.Identificador = reader(0)
                patente.Descripcion = reader(1)
                patentes.Add(patente)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return patentes
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarPorFamilia(ByVal familia As Familia, Optional ByVal Lazy As Boolean = True) As List(Of Patente)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfam_id", familia.Identificador))

            reader = base.ConsultarReader("SP_Patentes_ConsultarPorFamilia", parametros)

            Dim patentes As New List(Of Patente)
            Do While reader.Read()
                Dim patente As New Patente
                Dim patenteAD As New PatenteAD
                patente = patenteAD.ConsultarPorId(reader(0))
                patentes.Add(patente)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return patentes

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPorUsuario(ByVal usuario As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Patente)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusu_id", usuario.Identificador))

            reader = base.ConsultarReader("SP_Patentes_ConsultarPorUsuario", parametros)

            Dim patentes As New List(Of Patente)
            Do While reader.Read()
                Dim patente As New Patente
                Dim patenteAD As New PatenteAD
                patente = patenteAD.ConsultarPorId(reader(0))

                patentes.Add(patente)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return patentes

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

