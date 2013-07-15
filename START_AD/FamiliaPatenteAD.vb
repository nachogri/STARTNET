Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class FamiliaPatenteAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef familia As Familia) As Integer
        Dim res As Integer = -1
        Try

            For Each pat As Patente In familia.Patentes
                base = New START_SERVICIOS.BaseDeDatosSQL()
                parametros = New List(Of SqlParameter)
                parametros.Clear()
                parametros.Add(New SqlParameter("@pfp_fam_id", familia.Identificador))
                parametros.Add(New SqlParameter("@pfp_pat_id", pat.Identificador))

                res = base.EjecutarInstruccion("SP_FamiliasPatentes_Insertar", parametros)
            Next

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal familia As Familia) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfp_fam_id", familia.Identificador))
            res = base.EjecutarInstruccion("SP_FamiliasPatentes_Borrar_PorFamilia", parametros)

            For Each pat As Patente In familia.Patentes
                parametros.Clear()
                parametros.Add(New SqlParameter("@pfp_fam_id", familia.Identificador))
                parametros.Add(New SqlParameter("@pfp_pat_id", pat.Identificador))

                res = base.EjecutarInstruccion("SP_FamiliasPatentes_Insertar", parametros)
            Next

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal familia As Familia) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfp_fam_id", familia.Identificador))
            res = base.EjecutarInstruccion("SP_FamiliasPatentes_Borrar_PorFamilia", parametros)

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
