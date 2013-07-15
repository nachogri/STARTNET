
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class UsuarioPatenteAD

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

            For Each pat As Patente In usuario.Patentes
                base = New START_SERVICIOS.BaseDeDatosSQL()
                parametros = New List(Of SqlParameter)
                parametros.Clear()
                parametros.Add(New SqlParameter("@pup_usu_id", usuario.Identificador))
                parametros.Add(New SqlParameter("@pup_pat_id", pat.Identificador))

                res = base.EjecutarInstruccion("SP_UsuariosPatentes_Insertar", parametros)
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
            parametros.Add(New SqlParameter("@pup_usu_id", usuario.Identificador))
            res = base.EjecutarInstruccion("SP_UsuariosPatentes_Borrar_PorUsuario", parametros)

            For Each pat As Patente In usuario.Patentes
                parametros.Clear()
                parametros.Add(New SqlParameter("@pup_usu_id", usuario.Identificador))
                parametros.Add(New SqlParameter("@pup_pat_id", pat.Identificador))

                res = base.EjecutarInstruccion("SP_UsuariosPatentes_Insertar", parametros)
            Next

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
            parametros.Add(New SqlParameter("@pup_usu_id", usuario.Identificador))
            res = base.EjecutarInstruccion("SP_UsuariosPatentes_Borrar_PorUsuario", parametros)

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
