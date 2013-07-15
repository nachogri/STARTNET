
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class DesarrolladorAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef desarrollador As Desarrollador) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            desarrollador.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusud_id", desarrollador.Identificador))
            If Not desarrollador.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pusud_usu_id", desarrollador.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@pusud_usu_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pusud_descrip_prod", desarrollador.DescripcionProducto))
            parametros.Add(New SqlParameter("@pusud_razon_social", desarrollador.RazonSocial))
            parametros.Add(New SqlParameter("@pusud_aviso", desarrollador.Aviso))
            parametros.Add(New SqlParameter("@pusud_comentarios", desarrollador.Comentarios))
            parametros.Add(New SqlParameter("@pusud_imagen", desarrollador.Imagen))

            res = base.EjecutarInstruccion("SP_Desarrolladores_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal desarrollador As Desarrollador) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusud_id", desarrollador.Identificador))
            If Not desarrollador.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pusud_usu_id", desarrollador.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@pusud_usu_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pusud_descrip_prod", desarrollador.DescripcionProducto))
            parametros.Add(New SqlParameter("@pusud_razon_social", desarrollador.RazonSocial))
            parametros.Add(New SqlParameter("@pusud_aviso", desarrollador.Aviso))
            parametros.Add(New SqlParameter("@pusud_comentarios", desarrollador.Comentarios))
            parametros.Add(New SqlParameter("@pusud_imagen", desarrollador.Imagen))

            res = base.EjecutarInstruccion("SP_Desarrolladores_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal desarrollador As Desarrollador) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusud_id", desarrollador.Identificador))


            res = base.EjecutarInstruccion("SP_Desarrolladores_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Desarrollador
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusud_id", id))

            reader = base.ConsultarReader("SP_Desarrolladores_Consultar", parametros)

            reader.Read()
            Dim desarrollador As New Desarrollador
            desarrollador.Identificador = reader(0)

            Dim usuarioAD = New UsuarioAD
            desarrollador.Usuario = usuarioAD.ConsultarPorId(reader(1))

            desarrollador.DescripcionProducto = reader(2)
            desarrollador.RazonSocial = reader(3)
            desarrollador.Aviso = reader(4)
            desarrollador.Comentarios = reader(5)
            desarrollador.Imagen = reader(6)
            If Not reader Is Nothing Then reader.Close()

            Return desarrollador
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Desarrollador, Optional ByVal Lazy As Boolean = True) As List(Of Desarrollador)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pusud_usu_id", filtros.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@pusud_usu_id", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@pusud_descrip_prod", filtros.DescripcionProducto))
            parametros.Add(New SqlParameter("@pusud_razon_social", filtros.RazonSocial))
            parametros.Add(New SqlParameter("@pusud_aviso", filtros.Aviso))
            parametros.Add(New SqlParameter("@pusud_comentarios", filtros.Comentarios))
            parametros.Add(New SqlParameter("@pusud_imagen", filtros.Imagen))

            reader = base.ConsultarReader("SP_Desarrolladores_ConsultarPor", parametros)

            Dim desarrolladors As New List(Of Desarrollador)
            Do While reader.Read()
                Dim desarrollador As New Desarrollador
                desarrollador.Identificador = reader(0)

                Dim usuarioAD = New UsuarioAD
                desarrollador.Usuario = usuarioAD.ConsultarPorId(reader(1))

                desarrollador.DescripcionProducto = reader(2)
                desarrollador.RazonSocial = reader(3)
                desarrollador.Aviso = reader(4)
                desarrollador.Comentarios = reader(5)
                desarrollador.Imagen = reader(6)

                desarrolladors.Add(desarrollador)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return desarrolladors

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Desarrollador)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Desarrolladores_ConsultarTodos")

            Dim desarrolladors As New List(Of Desarrollador)
            Do While reader.Read()
                Dim desarrollador As New Desarrollador
                desarrollador.Identificador = reader(0)

                Dim usuarioAD = New UsuarioAD
                desarrollador.Usuario = usuarioAD.ConsultarPorId(reader(1))

                desarrollador.DescripcionProducto = reader(2)
                desarrollador.RazonSocial = reader(3)
                desarrollador.Aviso = reader(4)
                desarrollador.Comentarios = reader(5)
                desarrollador.Imagen = reader(6)


                desarrolladors.Add(desarrollador)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return desarrolladors
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
