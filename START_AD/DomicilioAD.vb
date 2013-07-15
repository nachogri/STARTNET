Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class DomicilioAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef domicilio As Domicilio) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            domicilio.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pdom_id", domicilio.Identificador))
            parametros.Add(New SqlParameter("@pdom_tipo", domicilio.Tipo))
            parametros.Add(New SqlParameter("@pdom_calle", domicilio.Calle))
            parametros.Add(New SqlParameter("@pdom_nro", domicilio.Nro))
            If Not domicilio.Localidad Is Nothing Then
                parametros.Add(New SqlParameter("@pdom_loc_id", domicilio.Localidad.Identificador))
            End If
            If Not domicilio.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pdom_usu_id", domicilio.Usuario.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_Domicilios_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal domicilio As Domicilio) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pdom_id", domicilio.Identificador))
            parametros.Add(New SqlParameter("@pdom_tipo", domicilio.Tipo))
            parametros.Add(New SqlParameter("@pdom_calle", domicilio.Calle))
            parametros.Add(New SqlParameter("@pdom_nro", domicilio.Nro))
            If Not domicilio.Localidad Is Nothing Then
                parametros.Add(New SqlParameter("@pdom_loc_id", domicilio.Localidad.Identificador))
            End If
            If Not domicilio.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pdom_usu_id", domicilio.Usuario.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_Domicilios_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal domicilio As Domicilio) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pdom_id", domicilio.Identificador))

            res = base.EjecutarInstruccion("SP_Domicilios_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Domicilio
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pdom_id", id))

            reader = base.ConsultarReader("SP_Domicilios_Consultar", parametros)

            reader.Read()
            Dim domicilio As New Domicilio
            domicilio.Identificador = reader(0)
            domicilio.Tipo = reader(1)
            domicilio.Calle = reader(2)
            domicilio.Nro = reader(3)

            If Not Lazy Then
                Dim localidadAD = New LocalidadAD
                Dim usuarioAD = New UsuarioAD
                domicilio.Localidad = localidadAD.ConsultarPorId(reader(4))
                domicilio.Usuario = usuarioAD.ConsultarPorId(reader(5))
            End If
            If Not reader Is Nothing Then reader.Close()

            Return domicilio
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Domicilio, Optional ByVal Lazy As Boolean = True) As List(Of Domicilio)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            'parametros.Add(New SqlParameter("@pdom_tipo", filtros.Tipo))
            'parametros.Add(New SqlParameter("@pdom_calle", filtros.Calle))
            'parametros.Add(New SqlParameter("@pdom_nro", filtros.Nro))
            If Not filtros.Localidad Is Nothing Then
                parametros.Add(New SqlParameter("@pdom_loc_id", filtros.Localidad.Identificador))
            End If
            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pdom_usu_id", filtros.Usuario.Identificador))
            End If

            reader = base.ConsultarReader("SP_Domicilios_ConsultarPor", parametros)

            Dim domicilios As New List(Of Domicilio)
            Do While reader.Read()
                Dim domicilio As New Domicilio
                domicilio.Identificador = reader(0)
                domicilio.Tipo = reader(1)
                domicilio.Calle = reader(2)
                domicilio.Nro = reader(3)

                If Not Lazy Then
                    Dim localidadAD = New LocalidadAD
                    Dim usuarioAD = New UsuarioAD
                    domicilio.Localidad = localidadAD.ConsultarPorId(reader(4), Lazy)
                    domicilio.Usuario = usuarioAD.ConsultarPorId(reader(5))
                End If

                domicilios.Add(domicilio)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return domicilios

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Domicilio)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Domicilios_ConsultarTodos")

            Dim domicilios As New List(Of Domicilio)
            Do While reader.Read()
                Dim domicilio As New Domicilio
                domicilio.Identificador = reader(0)
                domicilio.Tipo = reader(1)
                domicilio.Calle = reader(2)
                domicilio.Nro = reader(3)

                If Not Lazy Then
                    Dim localidadAD = New LocalidadAD
                    Dim usuarioAD = New UsuarioAD
                    domicilio.Localidad = localidadAD.ConsultarPorId(reader(4))
                    domicilio.Usuario = usuarioAD.ConsultarPorId(reader(5))
                End If

                domicilios.Add(domicilio)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return domicilios
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
