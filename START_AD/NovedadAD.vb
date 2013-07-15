Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class NovedadAD
#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef novedad As Novedad) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            novedad.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pnov_id", novedad.Identificador))
            parametros.Add(New SqlParameter("@pnov_titulo", novedad.Titulo))
            parametros.Add(New SqlParameter("@pnov_descripcion", novedad.Descripcion))
            parametros.Add(New SqlParameter("@pnov_fecha_actualizacion", novedad.FechaActualizacion))
            parametros.Add(New SqlParameter("@pnov_imagen", novedad.Imagen))

            res = base.EjecutarInstruccion("SP_Novedades_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal novedad As Novedad) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pnov_id", novedad.Identificador))
            parametros.Add(New SqlParameter("@pnov_titulo", novedad.Titulo))
            parametros.Add(New SqlParameter("@pnov_descripcion", novedad.Descripcion))
            parametros.Add(New SqlParameter("@pnov_fecha_actualizacion", novedad.FechaActualizacion))
            parametros.Add(New SqlParameter("@pnov_imagen", novedad.Imagen))

            res = base.EjecutarInstruccion("SP_Novedades_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal novedad As Novedad) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pnov_id", novedad.Identificador))

            res = base.EjecutarInstruccion("SP_Novedades_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Novedad
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pnov_id", id))

            reader = base.ConsultarReader("SP_Novedades_Consultar", parametros)
            reader.Read()
            Dim novedad As New Novedad
            novedad.Identificador = reader(0)
            novedad.Titulo = reader(1)
            novedad.Descripcion = reader(2)
            novedad.FechaActualizacion = reader(3)
            novedad.Imagen = reader(4)
            If Not reader Is Nothing Then reader.Close()

            Return novedad
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Novedad, Optional ByVal Lazy As Boolean = True) As List(Of Novedad)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pnov_id", filtros.Identificador))
            parametros.Add(New SqlParameter("@pnov_titulo", filtros.Titulo))
            parametros.Add(New SqlParameter("@pnov_descripcion", filtros.Descripcion))
            parametros.Add(New SqlParameter("@pnov_fecha_actualizacion", filtros.FechaActualizacion))
            parametros.Add(New SqlParameter("@pnov_imagen", filtros.Imagen))

            reader = base.ConsultarReader("SP_Novedades_ConsultarPor", parametros)

            Dim novedads As New List(Of Novedad)
            Do While reader.Read()
                Dim novedad As New Novedad
                novedad.Identificador = reader(0)
                novedad.Titulo = reader(1)
                novedad.Descripcion = reader(2)
                novedad.FechaActualizacion = reader(3)
                novedad.Imagen = reader(4)

                novedads.Add(novedad)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return novedads

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Novedad)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Novedades_ConsultarTodos")

            Dim novedads As New List(Of Novedad)
            Do While reader.Read()
                Dim novedad As New Novedad
                novedad.Identificador = reader(0)
                novedad.Titulo = reader(1)
                novedad.Descripcion = reader(2)
                novedad.FechaActualizacion = reader(3)
                novedad.Imagen = reader(4)

                novedads.Add(novedad)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return novedads
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
