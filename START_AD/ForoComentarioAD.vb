
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class ForoComentarioAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef foroComentario As ForoComentario) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            foroComentario.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfc_id", foroComentario.Identificador))
            parametros.Add(New SqlParameter("@pfc_fecha", foroComentario.Fecha))
            If Not foroComentario.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pfc_usu_id", foroComentario.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@pfc_usu_id", DBNull.Value))
            End If
            If Not foroComentario.Topico Is Nothing Then
                parametros.Add(New SqlParameter("@pfc_ft_id", foroComentario.Topico.Identificador))
            Else
                parametros.Add(New SqlParameter("@pfc_ft_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pfc_mensaje", foroComentario.Mensaje))

            res = base.EjecutarInstruccion("SP_ForoComentarios_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal foroComentario As ForoComentario) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pfc_id", foroComentario.Identificador))
            parametros.Add(New SqlParameter("@pfc_fecha", foroComentario.Fecha))
            If Not foroComentario.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pfc_usu_id", foroComentario.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@pfc_usu_id", DBNull.Value))
            End If
            If Not foroComentario.Topico Is Nothing Then
                parametros.Add(New SqlParameter("@pfc_ft_id", foroComentario.Topico.Identificador))
            Else
                parametros.Add(New SqlParameter("@pfc_ft_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pfc_mensaje", foroComentario.Mensaje))

            res = base.EjecutarInstruccion("SP_ForoComentarios_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal foroComentario As ForoComentario) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfc_id", foroComentario.Identificador))


            res = base.EjecutarInstruccion("SP_ForoComentarios_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As ForoComentario
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfc_id", id))

            reader = base.ConsultarReader("SP_ForoComentarios_Consultar", parametros)

            reader.Read()
            Dim foroComentario As New ForoComentario
            foroComentario.Identificador = reader(0)
            foroComentario.Fecha = reader(1)
            If Not Lazy Then
                Dim usuarioAD = New UsuarioAD
                foroComentario.Usuario = usuarioAD.ConsultarPorId(reader(2))
                Dim topicoAD = New ForoTopicoAD
                foroComentario.Topico = topicoAD.ConsultarPorId(reader(3))
            End If
            foroComentario.Mensaje = reader(4)

            If Not reader Is Nothing Then reader.Close()

            Return foroComentario
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As ForoComentario, Optional ByVal Lazy As Boolean = True) As List(Of ForoComentario)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pfc_fecha", filtros.Fecha))
            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pfc_usu_id", filtros.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@pfc_usu_id", DBNull.Value))
            End If
            If Not filtros.Topico Is Nothing Then
                parametros.Add(New SqlParameter("@pfc_ft_id", filtros.Topico.Identificador))
            Else
                parametros.Add(New SqlParameter("@pfc_ft_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pfc_mensaje", filtros.Mensaje))

            reader = base.ConsultarReader("SP_ForoComentarios_ConsultarPor", parametros)

            Dim foroComentarios As New List(Of ForoComentario)
            Do While reader.Read()
                Dim foroComentario As New ForoComentario
                foroComentario.Identificador = reader(0)
                foroComentario.Fecha = reader(1)
                If Not Lazy Then
                    Dim usuarioAD = New UsuarioAD
                    foroComentario.Usuario = usuarioAD.ConsultarPorId(reader(2))
                    Dim topicoAD = New ForoTopicoAD
                    foroComentario.Topico = topicoAD.ConsultarPorId(reader(3))
                End If
                foroComentario.Mensaje = reader(4)

                foroComentarios.Add(foroComentario)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return foroComentarios

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of ForoComentario)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_ForoComentarios_ConsultarTodos")

            Dim foroComentarios As New List(Of ForoComentario)
            Do While reader.Read()
                Dim foroComentario As New ForoComentario
                foroComentario.Identificador = reader(0)
                foroComentario.Fecha = reader(1)
                If Not Lazy Then
                    Dim usuarioAD = New UsuarioAD
                    foroComentario.Usuario = usuarioAD.ConsultarPorId(reader(2))
                    Dim topicoAD = New ForoTopicoAD
                    foroComentario.Topico = topicoAD.ConsultarPorId(reader(3))
                End If
                foroComentario.Mensaje = reader(4)

                foroComentarios.Add(foroComentario)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return foroComentarios
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
