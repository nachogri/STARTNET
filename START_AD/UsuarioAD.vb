Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class UsuarioAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef usuario As Usuario) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            usuario.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusu_id", usuario.Identificador))
            parametros.Add(New SqlParameter("@pusu_nombre", usuario.Nombre))
            parametros.Add(New SqlParameter("@pusu_apellido", usuario.Apellido))
            parametros.Add(New SqlParameter("@pusu_nick", usuario.NickName))
            parametros.Add(New SqlParameter("@pusu_password", usuario.Password))
            parametros.Add(New SqlParameter("@pusu_tipodoc", usuario.TipoDoc))
            parametros.Add(New SqlParameter("@pusu_doc", usuario.NroDoc))
            parametros.Add(New SqlParameter("@pusu_fecha_nac", usuario.FechaNac))
            parametros.Add(New SqlParameter("@pusu_telefono", usuario.Telefono))
            parametros.Add(New SqlParameter("@pusu_email", usuario.Email))
            parametros.Add(New SqlParameter("@pusu_desarrolla", usuario.Desarrolla))
            parametros.Add(New SqlParameter("@pusu_interno", usuario.Interno))
            parametros.Add(New SqlParameter("@pusu_suscripcion", usuario.Subscripcion))
            parametros.Add(New SqlParameter("@pusu_CUIT", usuario.CUIT))
            parametros.Add(New SqlParameter("@pusu_CUIL", usuario.CUIL))
            parametros.Add(New SqlParameter("@pusu_iva_id", usuario.CondicionIVA))
            parametros.Add(New SqlParameter("@pusu_estado", usuario.Estado))
            If Not usuario.Idioma Is Nothing Then
                parametros.Add(New SqlParameter("@pusu_idioma_id", usuario.Idioma.Identificador))
            End If


            res = base.EjecutarInstruccion("SP_UsuariosRegistrados_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal usuario As Usuario) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()


            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusu_id", usuario.Identificador))
            parametros.Add(New SqlParameter("@pusu_nombre", usuario.Nombre))
            parametros.Add(New SqlParameter("@pusu_apellido", usuario.Apellido))
            parametros.Add(New SqlParameter("@pusu_nick", usuario.NickName))
            parametros.Add(New SqlParameter("@pusu_password", usuario.Password))
            parametros.Add(New SqlParameter("@pusu_tipodoc", usuario.TipoDoc))
            parametros.Add(New SqlParameter("@pusu_doc", usuario.NroDoc))
            parametros.Add(New SqlParameter("@pusu_fecha_nac", usuario.FechaNac))
            parametros.Add(New SqlParameter("@pusu_telefono", usuario.Telefono))
            parametros.Add(New SqlParameter("@pusu_email", usuario.Email))
            parametros.Add(New SqlParameter("@pusu_desarrolla", usuario.Desarrolla))
            parametros.Add(New SqlParameter("@pusu_interno", usuario.Interno))
            parametros.Add(New SqlParameter("@pusu_suscripcion", usuario.Subscripcion))
            parametros.Add(New SqlParameter("@pusu_CUIT", usuario.CUIT))
            parametros.Add(New SqlParameter("@pusu_CUIL", usuario.CUIL))
            parametros.Add(New SqlParameter("@pusu_iva_id", usuario.CondicionIVA))
            parametros.Add(New SqlParameter("@pusu_estado", usuario.Estado))
            If Not usuario.Idioma Is Nothing Then
                parametros.Add(New SqlParameter("@pusu_idioma_id", usuario.Idioma.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_UsuariosRegistrados_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal usuario As Usuario) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusu_id", usuario.Identificador))

            res = base.EjecutarInstruccion("SP_UsuariosRegistrados_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Usuario
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusu_id", id))

            reader = base.ConsultarReader("SP_UsuariosRegistrados_Consultar", parametros)

            reader.Read()
            Dim usuario As New Usuario
            usuario.Identificador = reader(0)
            usuario.Nombre = reader(1)
            usuario.Apellido = reader(2)
            usuario.NickName = reader(3)
            usuario.Password = reader(4)
            usuario.TipoDoc = reader(5)
            usuario.NroDoc = reader(6)
            usuario.FechaNac = reader(7)
            usuario.Telefono = reader(8).ToString()
            usuario.Email = reader(9).ToString()
            usuario.Desarrolla = reader(10)
            usuario.Interno = reader(11)
            usuario.Subscripcion = reader(12)
            usuario.CUIT = reader(13).ToString()
            usuario.CUIL = reader(14).ToString()
            usuario.CondicionIVA = reader(15).ToString()
            usuario.Estado = reader(16).ToString()

            If Not Lazy Then
                Dim idiomaAD = New IdiomaAD
                usuario.Idioma = idiomaAD.ConsultarPorId(reader(17))
            End If

            If Not reader Is Nothing Then reader.Close()

            Return usuario
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Usuario)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()


            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusu_nombre", filtros.Nombre))
            parametros.Add(New SqlParameter("@pusu_apellido", filtros.Apellido))
            parametros.Add(New SqlParameter("@pusu_nick", filtros.NickName))
            parametros.Add(New SqlParameter("@pusu_password", DBNull.Value))
            parametros.Add(New SqlParameter("@pusu_tipodoc", filtros.TipoDoc))
            parametros.Add(New SqlParameter("@pusu_doc", filtros.NroDoc))

            If Not START_HELPER.DateHelper.IsNullDate(filtros.FechaNac) Then
                parametros.Add(New SqlParameter("@pusu_fecha_nac", filtros.FechaNac))
            End If

            parametros.Add(New SqlParameter("@pusu_telefono", DBNull.Value))
            parametros.Add(New SqlParameter("@pusu_email", filtros.Email))
            parametros.Add(New SqlParameter("@pusu_desarrolla", filtros.Desarrolla))
            parametros.Add(New SqlParameter("@pusu_interno", filtros.Interno))
            parametros.Add(New SqlParameter("@pusu_suscripcion", DBNull.Value))
            parametros.Add(New SqlParameter("@pusu_CUIT", DBNull.Value))
            parametros.Add(New SqlParameter("@pusu_CUIL", DBNull.Value))
            parametros.Add(New SqlParameter("@pusu_iva_id", DBNull.Value))
            parametros.Add(New SqlParameter("@pusu_estado", DBNull.Value))
            If Not filtros.Idioma Is Nothing Then
                parametros.Add(New SqlParameter("@pusu_idioma_id", filtros.Idioma.Identificador))
            End If

            reader = base.ConsultarReader("SP_UsuariosRegistrados_ConsultarPor", parametros)

            Dim usuarios As New List(Of Usuario)
            Do While reader.Read()
                Dim usuario As New Usuario
                usuario.Identificador = reader(0)
                usuario.Nombre = reader(1)
                usuario.Apellido = reader(2)
                usuario.NickName = reader(3)
                usuario.Password = reader(4)
                usuario.TipoDoc = reader(5)
                usuario.NroDoc = reader(6)
                usuario.FechaNac = reader(7)
                usuario.Telefono = reader(8).ToString()
                usuario.Email = reader(9).ToString()
                usuario.Desarrolla = reader(10)
                usuario.Interno = reader(11)
                usuario.Subscripcion = reader(12)
                usuario.CUIT = reader(13).ToString()
                usuario.CUIL = reader(14).ToString()
                usuario.CondicionIVA = reader(15).ToString()
                usuario.Estado = reader(16).ToString()

                If Not Lazy Then
                    Dim idiomaAD = New IdiomaAD
                    usuario.Idioma = idiomaAD.ConsultarPorId(reader(4))
                End If

                usuarios.Add(usuario)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return usuarios

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Usuario)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_UsuariosRegistrados_ConsultarTodos")

            Dim usuarios As New List(Of Usuario)
            Do While reader.Read()
                Dim usuario As New Usuario
                usuario.Identificador = reader(0)
                usuario.Nombre = reader(1)
                usuario.Apellido = reader(2)
                usuario.NickName = reader(3)
                usuario.Password = reader(4)
                usuario.TipoDoc = reader(5)
                usuario.NroDoc = reader(6)
                usuario.FechaNac = reader(7)
                usuario.Telefono = reader(8).ToString()
                usuario.Email = reader(9).ToString()
                usuario.Desarrolla = reader(10)
                usuario.Interno = reader(11)
                usuario.Subscripcion = reader(12)
                usuario.CUIT = reader(13).ToString()
                usuario.CUIL = reader(14).ToString()
                usuario.CondicionIVA = reader(15).ToString()
                usuario.Estado = reader(16).ToString()

                If Not Lazy Then
                    Dim idiomaAD = New IdiomaAD
                    usuario.Idioma = idiomaAD.ConsultarPorId(reader(4))
                End If

                usuarios.Add(usuario)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return usuarios
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarPorFamilia(ByVal familia As Familia, Optional ByVal Lazy As Boolean = True) As List(Of Usuario)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfam_id", familia.Identificador))

            reader = base.ConsultarReader("SP_UsuariosRegistrados_ConsultarPorFamilia", parametros)

            Dim usuarios As New List(Of Usuario)
            Do While reader.Read()
                Dim usuario As New Usuario
                Dim usuarioAD As New UsuarioAD
                usuario = usuarioAD.ConsultarPorId(reader(0), Lazy)
                usuarios.Add(usuario)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return usuarios

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPorNickname(ByVal nickname As String, Optional ByVal Lazy As Boolean = True) As Usuario
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pNickname", nickname))

            reader = base.ConsultarReader("SP_UsuariosRegistrados_ConsultarPorNickName", parametros)

            Dim usuario As New Usuario
            If reader.HasRows Then
                reader.Read()
                usuario = ConsultarPorId(reader(0), Lazy)
            End If
            If Not reader Is Nothing Then If Not reader Is Nothing Then reader.Close()

            Return usuario

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
