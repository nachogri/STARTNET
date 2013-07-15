Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class RegistroEmailAD
#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByVal Usuario As Usuario) As Guid
        Dim res As Guid
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            Dim key As Guid = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pre_id", key))
            parametros.Add(New SqlParameter("@pre_usu_id", Usuario.Identificador))


            base.EjecutarInstruccion("SP_RegistracionEmail_Insertar", parametros)

            res = key
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid) As Usuario
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pre_id", id))

            reader = base.ConsultarReader("SP_RegistracionEmail_Consultar", parametros)
            reader.Read()


            Dim usuarioad As New UsuarioAD
            Dim usuario As Usuario = usuarioad.ConsultarPorId(reader(1))

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

#End Region
End Class
