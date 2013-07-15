
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class NavegacionAD
#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef navegacion As Navegacion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            navegacion.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pnav_id", navegacion.Identificador))
            If Not navegacion.Logueo Is Nothing Then
                parametros.Add(New SqlParameter("@pnav_log_id", navegacion.Logueo.Identificador))
            Else
                parametros.Add(New SqlParameter("@pnav_log_id", DBNull.Value))
            End If
            If Not navegacion.Pagina Is Nothing Then
                parametros.Add(New SqlParameter("@pnav_pag_id", navegacion.Pagina.Identificador))
            Else
                parametros.Add(New SqlParameter("@pnav_pag_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pnav_hora_entrada", navegacion.HoraEntrada))
            parametros.Add(New SqlParameter("@pnav_hora_salida", navegacion.HoraSalida))


            res = base.EjecutarInstruccion("SP_Navegacions_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal navegacion As Navegacion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pnav_id", navegacion.Identificador))
            If Not navegacion.Logueo Is Nothing Then
                parametros.Add(New SqlParameter("@pnav_log_id", navegacion.Logueo.Identificador))
            Else
                parametros.Add(New SqlParameter("@pnav_log_id", DBNull.Value))
            End If
            If Not navegacion.Pagina Is Nothing Then
                parametros.Add(New SqlParameter("@pnav_pag_id", navegacion.Pagina.Identificador))
            Else
                parametros.Add(New SqlParameter("@pnav_pag_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pnav_hora_entrada", navegacion.HoraEntrada))
            parametros.Add(New SqlParameter("@pnav_hora_salida", navegacion.HoraSalida))

            res = base.EjecutarInstruccion("SP_Navegacions_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal navegacion As Navegacion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pnav_id", navegacion.Identificador))

            res = base.EjecutarInstruccion("SP_Navegacions_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Navegacion
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pnav_id", id))

            reader = base.ConsultarReader("SP_Navegacions_Consultar", parametros)
            reader.Read()

            Dim navegacion As New Navegacion
            navegacion.Identificador = reader(0)
            If Not Lazy Then
                Dim logueoAD As New LogueoAD
                navegacion.Logueo = logueoAD.ConsultarPorId(reader(1))

                Dim paginaAD As New PaginaAD
                navegacion.Pagina = paginaAD.ConsultarPorId(reader(2))
            End If
            navegacion.HoraEntrada = reader(3)
            navegacion.HoraEntrada = reader(4)

            If Not reader Is Nothing Then reader.Close()
            Return navegacion
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPorLogueo(ByRef logueo As Logueo, Optional ByVal Lazy As Boolean = True) As List(Of Navegacion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@plog_id", logueo.Identificador))
            reader = base.ConsultarReader("SP_Navegaciones_ConsultarPorLogueo", parametros)

            Dim navegacions As New List(Of Navegacion)
            Do While reader.Read()
                Dim navegacion As New Navegacion
                navegacion.Identificador = reader(0)
                If Not Lazy Then
                    Dim logueoAD As New LogueoAD
                    navegacion.Logueo = logueoAD.ConsultarPorId(reader(1))

                    Dim paginaAD As New PaginaAD
                    navegacion.Pagina = paginaAD.ConsultarPorId(reader(2))
                End If
                navegacion.HoraEntrada = reader(3)
                navegacion.HoraEntrada = reader(4)
                navegacions.Add(navegacion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return navegacions
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Navegacion, Optional ByVal Lazy As Boolean = True) As List(Of Navegacion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)


            If Not filtros.Logueo Is Nothing Then
                parametros.Add(New SqlParameter("@pnav_log_id", filtros.Logueo.Identificador))
            Else
                parametros.Add(New SqlParameter("@pnav_log_id", DBNull.Value))
            End If
            If Not filtros.Pagina Is Nothing Then
                parametros.Add(New SqlParameter("@pnav_pag_id", filtros.Pagina.Identificador))
            Else
                parametros.Add(New SqlParameter("@pnav_pag_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pnav_hora_entrada", filtros.HoraEntrada))
            parametros.Add(New SqlParameter("@pnav_hora_salida", filtros.HoraSalida))

            reader = base.ConsultarReader("SP_Navegacions_ConsultarPor", parametros)

            Dim navegacions As New List(Of Navegacion)
            Do While reader.Read()
                Dim navegacion As New Navegacion
                navegacion.Identificador = reader(0)
                If Not Lazy Then
                    Dim logueoAD As New LogueoAD
                    navegacion.Logueo = logueoAD.ConsultarPorId(reader(1))

                    Dim paginaAD As New PaginaAD
                    navegacion.Pagina = paginaAD.ConsultarPorId(reader(2))
                End If
                navegacion.HoraEntrada = reader(3)
                navegacion.HoraEntrada = reader(4)

                navegacions.Add(navegacion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return navegacions

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Navegacion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Navegacions_ConsultarTodos")

            Dim navegacions As New List(Of Navegacion)
            Do While reader.Read()
                Dim navegacion As New Navegacion
                navegacion.Identificador = reader(0)
                If Not Lazy Then
                    Dim logueoAD As New LogueoAD
                    navegacion.Logueo = logueoAD.ConsultarPorId(reader(1))

                    Dim paginaAD As New PaginaAD
                    navegacion.Pagina = paginaAD.ConsultarPorId(reader(2))
                End If
                navegacion.HoraEntrada = reader(3)
                navegacion.HoraEntrada = reader(4)

                navegacions.Add(navegacion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return navegacions
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
