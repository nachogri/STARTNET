Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class UsuarioFamiliaAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef usuario As Usuario) As Integer
        Dim res As Integer = -1
        Try

            For Each fam As Familia In usuario.Familias
                base = New START_SERVICIOS.BaseDeDatosSQL()

                parametros = New List(Of SqlParameter)
                parametros.Clear()
                parametros.Add(New SqlParameter("@puf_usu_id", usuario.Identificador))
                parametros.Add(New SqlParameter("@puf_fam_id", fam.Identificador))

                res = base.EjecutarInstruccion("SP_UsuariosFamilias_Insertar", parametros)
            Next

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
            parametros.Add(New SqlParameter("@puf_usu_id", usuario.Identificador))
            res = base.EjecutarInstruccion("SP_UsuariosFamilias_Borrar_PorUsuario", parametros)

            For Each fam As Familia In usuario.Familias
                parametros.Clear()
                parametros.Add(New SqlParameter("@puf_usu_id", usuario.Identificador))
                parametros.Add(New SqlParameter("@puf_fam_id", fam.Identificador))

                res = base.EjecutarInstruccion("SP_UsuariosFamilias_Insertar", parametros)
            Next

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function
    Public Function BorrarPorUsuario(ByVal usuario As Usuario) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@puf_usu_id", usuario.Identificador))
            res = base.EjecutarInstruccion("SP_UsuariosFamilias_Borrar_PorUsuario", parametros)

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function BorrarPorFamilia(ByVal familia As Familia) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@puf_fam_id", familia.Identificador))
            res = base.EjecutarInstruccion("SP_UsuariosFamilias_Borrar_PorFamilia", parametros)

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class
