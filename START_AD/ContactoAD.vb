Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class ContactoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef contacto As Contacto) As Integer        
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            contacto.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pcon_id", contacto.Identificador))
            If Not contacto.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pcon_usu_id", contacto.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@pcon_usu_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pcon_fecha", contacto.Fecha))
            parametros.Add(New SqlParameter("@pcon_tipo", contacto.Tipo))
            parametros.Add(New SqlParameter("@pcon_mensaje", contacto.Mensaje))
            If contacto.Respuesta Is Nothing Then
                parametros.Add(New SqlParameter("@pcon_respuesta", ""))
            Else
                parametros.Add(New SqlParameter("@pcon_respuesta", contacto.Respuesta))
            End If


            res = base.EjecutarInstruccion("SP_Contactos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal contacto As Contacto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pcon_id", contacto.Identificador))
            If Not contacto.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pcon_usu_id", contacto.Usuario.Identificador))
            End If
            parametros.Add(New SqlParameter("@pcon_fecha", contacto.Fecha))
            parametros.Add(New SqlParameter("@pcon_tipo", contacto.Tipo))
            parametros.Add(New SqlParameter("@pcon_mensaje", contacto.Mensaje))
            If contacto.Respuesta Is Nothing Then
                parametros.Add(New SqlParameter("@pcon_respuesta", ""))
            Else
                parametros.Add(New SqlParameter("@pcon_respuesta", contacto.Respuesta))
            End If

            res = base.EjecutarInstruccion("SP_Contactos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal contacto As Contacto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pcon_id", contacto.Identificador))


            res = base.EjecutarInstruccion("SP_Contactos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Contacto
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pcon_id", id))

            reader = base.ConsultarReader("SP_Contactos_Consultar", parametros)

            Dim contacto As New Contacto
            reader.Read()
            contacto.Identificador = reader(0)
            If Not Lazy Then
                Dim usuarioAD = New UsuarioAD
                contacto.Usuario = usuarioAD.ConsultarPorId(reader(1))
            End If
            contacto.Fecha = reader(2)
            contacto.Tipo = reader(3)
            contacto.Mensaje = reader(4)
            contacto.Respuesta = reader(5)
            If Not reader Is Nothing Then reader.Close()

            Return contacto
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Contacto, Optional ByVal Lazy As Boolean = True) As List(Of Contacto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pcon_usu_id", filtros.Usuario.Identificador))
            End If
            parametros.Add(New SqlParameter("@pcon_fecha", filtros.Fecha))
            parametros.Add(New SqlParameter("@pcon_tipo", filtros.Tipo))
            parametros.Add(New SqlParameter("@pcon_mensaje", filtros.Mensaje))
            parametros.Add(New SqlParameter("@pcon_respuesta", filtros.Respuesta))

            reader = base.ConsultarReader("SP_Contactos_ConsultarPor", parametros)

            Dim contactos As New List(Of Contacto)
            Do While reader.Read()
                Dim contacto As New Contacto
                contacto.Identificador = reader(0)
                If Not Lazy Then
                    Dim usuarioAD = New UsuarioAD
                    contacto.Usuario = usuarioAD.ConsultarPorId(reader(1))
                End If
                contacto.Fecha = reader(2)
                contacto.Tipo = reader(3)
                contacto.Mensaje = reader(4)
                contacto.Respuesta = reader(5)

                contactos.Add(contacto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return contactos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Contacto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Contactos_ConsultarTodos")

            Dim contactos As New List(Of Contacto)
            Do While reader.Read()
                Dim contacto As New Contacto
                contacto.Identificador = reader(0)
                If Not Lazy Then
                    Dim usuarioAD = New UsuarioAD
                    contacto.Usuario = usuarioAD.ConsultarPorId(reader(1))
                End If
                contacto.Fecha = reader(2)
                contacto.Tipo = reader(3)
                contacto.Mensaje = reader(4)
                contacto.Respuesta = reader(5)

                contactos.Add(contacto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return contactos
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
