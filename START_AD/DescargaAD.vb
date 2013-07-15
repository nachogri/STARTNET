Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class DescargaAD
#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef descarga As Descarga) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            descarga.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pdes_id", descarga.Identificador))
            parametros.Add(New SqlParameter("@pdes_tipo_archivo", descarga.TipoArchivo))
            parametros.Add(New SqlParameter("@pdes_ruta", descarga.Ruta))
            parametros.Add(New SqlParameter("@pdes_descrip", descarga.Descripcion))
            parametros.Add(New SqlParameter("@pdes_especificaciones", descarga.Especificaciones))
            parametros.Add(New SqlParameter("@pdes_fecha_actualizacion", descarga.FechaActualizacion))


            res = base.EjecutarInstruccion("SP_Descargas_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal descarga As Descarga) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pdes_id", descarga.Identificador))
            parametros.Add(New SqlParameter("@pdes_tipo_archivo", descarga.TipoArchivo))
            parametros.Add(New SqlParameter("@pdes_ruta", descarga.Ruta))
            parametros.Add(New SqlParameter("@pdes_descrip", descarga.Descripcion))
            parametros.Add(New SqlParameter("@pdes_especificaciones", descarga.Especificaciones))
            parametros.Add(New SqlParameter("@pdes_fecha_actualizacion", descarga.FechaActualizacion))


            res = base.EjecutarInstruccion("SP_Descargas_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal descarga As Descarga) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pdes_id", descarga.Identificador))

            res = base.EjecutarInstruccion("SP_Descargas_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Descarga
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pdes_id", id))

            reader = base.ConsultarReader("SP_Descargas_Consultar", parametros)

            reader.Read()
            Dim descarga As New Descarga
            descarga.Identificador = reader(0)
            descarga.TipoArchivo = reader(1)
            descarga.Ruta = reader(2)
            descarga.Descripcion = reader(3)
            descarga.Especificaciones = reader(4)
            descarga.FechaActualizacion = reader(5)
            If Not reader Is Nothing Then reader.Close()

            Return descarga
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Descarga, Optional ByVal Lazy As Boolean = True) As List(Of Descarga)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pdes_tipo_archivo", filtros.TipoArchivo))
            parametros.Add(New SqlParameter("@pdes_ruta", filtros.Ruta))
            parametros.Add(New SqlParameter("@pdes_descrip", filtros.Descripcion))
            parametros.Add(New SqlParameter("@pdes_especificaciones", filtros.Especificaciones))
            parametros.Add(New SqlParameter("@pdes_fecha_actualizacion", filtros.FechaActualizacion))

            reader = base.ConsultarReader("SP_Descargas_ConsultarPor", parametros)

            Dim descargas As New List(Of Descarga)
            Do While reader.Read()
                Dim descarga As New Descarga
                descarga.Identificador = reader(0)
                descarga.TipoArchivo = reader(1)
                descarga.Ruta = reader(2)
                descarga.Descripcion = reader(3)
                descarga.Especificaciones = reader(4)
                descarga.FechaActualizacion = reader(5)


                descargas.Add(descarga)
            Loop
            If Not reader Is Nothing Then reader.Close()
            Return descargas

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Descarga)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Descargas_ConsultarTodos")

            Dim descargas As New List(Of Descarga)
            Do While reader.Read()
                Dim descarga As New Descarga

                descarga.Identificador = reader(0)
                descarga.TipoArchivo = reader(1)
                descarga.Ruta = reader(2)
                descarga.Descripcion = reader(3)
                descarga.Especificaciones = reader(4)
                descarga.FechaActualizacion = reader(5)

                descargas.Add(descarga)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return descargas
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
