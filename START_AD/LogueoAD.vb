Imports START_HELPER
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class LogueoAD
#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef logueo As Logueo) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            logueo.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@plog_id", logueo.Identificador))
            If Not logueo.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@plog_usu_id", logueo.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@plog_usu_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@plog_fecha", logueo.Fecha))
            parametros.Add(New SqlParameter("@plog_hora_in", logueo.HoraIn))
            parametros.Add(New SqlParameter("@plog_hora_out", logueo.HoraOut))

            res = base.EjecutarInstruccion("SP_Logueos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal logueo As Logueo) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@plog_id", logueo.Identificador))
            If Not logueo.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@plog_usu_id", logueo.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@plog_usu_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@plog_fecha", logueo.Fecha))
            parametros.Add(New SqlParameter("@plog_hora_in", logueo.HoraIn))
            parametros.Add(New SqlParameter("@plog_hora_out", logueo.HoraOut))


            res = base.EjecutarInstruccion("SP_Logueos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal logueo As Logueo) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@plog_id", logueo.Identificador))

            res = base.EjecutarInstruccion("SP_Logueos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Logueo
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@plog_id", id))

            reader = base.ConsultarReader("SP_Logueos_Consultar", parametros)

            reader.Read()
            Dim logueo As New Logueo
            logueo.Identificador = reader(0)
            Dim usuarioAD = New UsuarioAD
            logueo.Usuario = usuarioAD.ConsultarPorId(reader(1))

            logueo.Fecha = reader(2)
            logueo.HoraIn = IIf(reader(3) Is DBNull.Value, "", reader(3))
            logueo.HoraOut = IIf(reader(4) Is DBNull.Value, "", reader(4))

            If Not reader Is Nothing Then reader.Close()

            Return logueo
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Logueo, Optional ByVal Lazy As Boolean = True) As List(Of Logueo)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)


            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@plog_usu_id", filtros.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@plog_usu_id", DBNull.Value))
            End If

            If Not DateHelper.IsNullDate(filtros.Fecha) Then
                parametros.Add(New SqlParameter("@plog_fecha", filtros.Fecha))
            End If

            parametros.Add(New SqlParameter("@plog_hora_in", DBNull.Value))
            parametros.Add(New SqlParameter("@plog_hora_out", DBNull.Value))

            If Not filtros.Seguimientos Is Nothing AndAlso Not filtros.Seguimientos(0).Tarea Is Nothing Then
                parametros.Add(New SqlParameter("@plog_tarea_id", filtros.Seguimientos(0).Tarea.Identificador))
            Else
                parametros.Add(New SqlParameter("@plog_tarea_id", DBNull.Value))
            End If

            reader = base.ConsultarReader("SP_Logueos_ConsultarPor", parametros)

            Dim logueos As New List(Of Logueo)
            Do While reader.Read()
                Dim logueo As New Logueo
                logueo.Identificador = reader(0)
                Dim usuarioAD = New UsuarioAD
                logueo.Usuario = usuarioAD.ConsultarPorId(reader(1))

                logueo.Fecha = reader(2)
                logueo.HoraIn = IIf(reader(3) Is DBNull.Value, "", reader(3))
                logueo.HoraOut = IIf(reader(4) Is DBNull.Value, "", reader(4))

                logueos.Add(logueo)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return logueos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Logueo)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Logueos_ConsultarTodos")

            Dim logueos As New List(Of Logueo)
            Do While reader.Read()
                Dim logueo As New Logueo
                logueo.Identificador = reader(0)
                Dim usuarioAD = New UsuarioAD
                logueo.Usuario = usuarioAD.ConsultarPorId(reader(1))

                logueo.Fecha = reader(2)
                logueo.HoraIn = IIf(reader(3) Is DBNull.Value, "", reader(3))
                logueo.HoraOut = IIf(reader(4) Is DBNull.Value, "", reader(4))

                logueos.Add(logueo)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return logueos
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
