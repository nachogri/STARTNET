
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class ForoTopicoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef foroTopico As ForoTopico) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            foroTopico.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pft_id", foroTopico.Identificador))
            parametros.Add(New SqlParameter("@pft_fecha_alta", foroTopico.FechaAlta))
            If Not foroTopico.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pft_usu_id", foroTopico.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@pft_usu_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pft_descrip", foroTopico.Descripcion))
            parametros.Add(New SqlParameter("@pft_activo", foroTopico.Activo))

            res = base.EjecutarInstruccion("SP_ForoTopicos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal foroTopico As ForoTopico) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pft_id", foroTopico.Identificador))
            parametros.Add(New SqlParameter("@pft_fecha_alta", foroTopico.FechaAlta))
            If Not foroTopico.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pft_usu_id", foroTopico.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@pft_usu_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pft_descrip", foroTopico.Descripcion))
            parametros.Add(New SqlParameter("@pft_activo", foroTopico.Activo))

            res = base.EjecutarInstruccion("SP_ForoTopicos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal foroTopico As ForoTopico) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pft_id", foroTopico.Identificador))


            res = base.EjecutarInstruccion("SP_ForoTopicos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As ForoTopico
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pft_id", id))

            reader = base.ConsultarReader("SP_ForoTopicos_Consultar", parametros)

            reader.Read()

            Dim foroTopico As New ForoTopico
            foroTopico.Identificador = reader(0)
            foroTopico.FechaAlta = reader(1)
            If Not Lazy Then
                Dim usuarioAD = New UsuarioAD
                foroTopico.Usuario = usuarioAD.ConsultarPorId(reader(2))
            End If
            foroTopico.Descripcion = reader(3)
            foroTopico.Activo = reader(4)

            If Not reader Is Nothing Then reader.Close()

            Return foroTopico
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As ForoTopico, Optional ByVal Lazy As Boolean = True) As List(Of ForoTopico)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pft_fecha_alta", filtros.FechaAlta))
            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pft_usu_id", filtros.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@pft_usu_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pft_descrip", filtros.Descripcion))
            parametros.Add(New SqlParameter("@pft_activo", filtros.Activo))

            reader = base.ConsultarReader("SP_ForoTopicos_ConsultarPor", parametros)

            Dim foroTopicos As New List(Of ForoTopico)
            Do While reader.Read()
                Dim foroTopico As New ForoTopico
                foroTopico.Identificador = reader(0)
                foroTopico.FechaAlta = reader(1)
                If Not Lazy Then
                    Dim usuarioAD = New UsuarioAD
                    foroTopico.Usuario = usuarioAD.ConsultarPorId(reader(2))
                End If
                foroTopico.Descripcion = reader(3)
                foroTopico.Activo = reader(4)

                foroTopicos.Add(foroTopico)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return foroTopicos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of ForoTopico)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_ForoTopicos_ConsultarTodos")

            Dim foroTopicos As New List(Of ForoTopico)
            Do While reader.Read()
                Dim foroTopico As New ForoTopico
                foroTopico.Identificador = reader(0)
                foroTopico.FechaAlta = reader(1)
                If Not Lazy Then
                    Dim usuarioAD = New UsuarioAD
                    foroTopico.Usuario = usuarioAD.ConsultarPorId(reader(2))
                End If
                foroTopico.Descripcion = reader(3)
                foroTopico.Activo = reader(4)

                foroTopicos.Add(foroTopico)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return foroTopicos
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
