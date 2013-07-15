

Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class SeguimientoAD
#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef seguimiento As Seguimiento) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            seguimiento.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pseg_identificador", seguimiento.Identificador))
            If Not seguimiento.Logueo Is Nothing Then
                parametros.Add(New SqlParameter("@pseg_log_id", seguimiento.Logueo.Identificador))
            Else
                parametros.Add(New SqlParameter("@pseg_log_id", DBNull.Value))
            End If
            If Not seguimiento.Tarea Is Nothing Then
                parametros.Add(New SqlParameter("@pseg_tar_id", seguimiento.Tarea.Identificador))
            Else
                parametros.Add(New SqlParameter("@pseg_tar_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pseg_identificador_accion", seguimiento.IdentificadorDeAccion))


            res = base.EjecutarInstruccion("SP_Seguimientos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal seguimiento As Seguimiento) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pseg_identificador", seguimiento.Identificador))
            If Not seguimiento.Logueo Is Nothing Then
                parametros.Add(New SqlParameter("@pseg_log_id", seguimiento.Logueo.Identificador))
            Else
                parametros.Add(New SqlParameter("@pseg_log_id", DBNull.Value))
            End If
            If Not seguimiento.Tarea Is Nothing Then
                parametros.Add(New SqlParameter("@pseg_tar_id", seguimiento.Tarea.Identificador))
            Else
                parametros.Add(New SqlParameter("@pseg_tar_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pseg_identificador_accion", seguimiento.IdentificadorDeAccion))

            res = base.EjecutarInstruccion("SP_Seguimientos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal seguimiento As Seguimiento) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pseg_identificador", seguimiento.Identificador))

            res = base.EjecutarInstruccion("SP_Seguimientos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Seguimiento
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pseg_identificador", id))

            reader = base.ConsultarReader("SP_Seguimientos_Consultar", parametros)
            reader.Read()

            Dim seguimiento As New Seguimiento
            seguimiento.Identificador = reader(0)
            If Not Lazy Then
                Dim logueoAD As New LogueoAD
                seguimiento.Logueo = logueoAD.ConsultarPorId(reader(1))

                Dim tareaAD As New TareaAD
                seguimiento.Tarea = tareaAD.ConsultarPorId(reader(2))
            End If
            seguimiento.IdentificadorDeAccion = reader(3)

            If Not reader Is Nothing Then reader.Close()

            Return seguimiento
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPorLogueo(ByRef logueo As Logueo, Optional ByVal Lazy As Boolean = True) As List(Of Seguimiento)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@plog_id", logueo.Identificador))
            reader = base.ConsultarReader("SP_Seguimientos_ConsultarPorLogueo", parametros)

            Dim seguimientos As New List(Of Seguimiento)
            Do While reader.Read()
                Dim seguimiento As New Seguimiento
                seguimiento.Identificador = reader(0)
                If Not Lazy Then
                    Dim logueoAD As New LogueoAD
                    seguimiento.Logueo = logueoAD.ConsultarPorId(reader(1))
                End If

                Dim tareaAD As New TareaAD
                seguimiento.Tarea = tareaAD.ConsultarPorId(reader(2))

                seguimiento.IdentificadorDeAccion = reader(3)

                seguimientos.Add(seguimiento)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return seguimientos
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Seguimiento, Optional ByVal Lazy As Boolean = True) As List(Of Seguimiento)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)


            If Not filtros.Logueo Is Nothing Then
                parametros.Add(New SqlParameter("@pseg_log_id", filtros.Logueo.Identificador))
            Else
                parametros.Add(New SqlParameter("@pseg_log_id", DBNull.Value))
            End If
            If Not filtros.Tarea Is Nothing Then
                parametros.Add(New SqlParameter("@pseg_tar_id", filtros.Tarea.Identificador))
            Else
                parametros.Add(New SqlParameter("@pseg_tar_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pseg_identificador_accion", filtros.IdentificadorDeAccion))

            reader = base.ConsultarReader("SP_Seguimientos_ConsultarPor", parametros)

            Dim seguimientos As New List(Of Seguimiento)
            Do While reader.Read()
                Dim seguimiento As New Seguimiento
                seguimiento.Identificador = reader(0)
                If Not Lazy Then
                    Dim logueoAD As New LogueoAD
                    seguimiento.Logueo = logueoAD.ConsultarPorId(reader(1))

                    Dim tareaAD As New TareaAD
                    seguimiento.Tarea = tareaAD.ConsultarPorId(reader(2))
                End If
                seguimiento.IdentificadorDeAccion = reader(3)

                seguimientos.Add(seguimiento)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return seguimientos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Seguimiento)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Seguimientos_ConsultarTodos")

            Dim seguimientos As New List(Of Seguimiento)
            Do While reader.Read()
                Dim seguimiento As New Seguimiento
                seguimiento.Identificador = reader(0)
                If Not Lazy Then
                    Dim logueoAD As New LogueoAD
                    seguimiento.Logueo = logueoAD.ConsultarPorId(reader(1))

                    Dim tareaAD As New TareaAD
                    seguimiento.Tarea = tareaAD.ConsultarPorId(reader(2))
                End If
                seguimiento.IdentificadorDeAccion = reader(3)

                seguimientos.Add(seguimiento)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return seguimientos
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
