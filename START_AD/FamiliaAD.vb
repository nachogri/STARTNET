Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class FamiliaAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef familia As Familia) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            familia.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfam_id", familia.Identificador))
            parametros.Add(New SqlParameter("@pfam_descrip", familia.Descripcion))

            res = base.EjecutarInstruccion("SP_Familias_Insertar", parametros)
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
            parametros.Add(New SqlParameter("@pfam_id", familia.Identificador))
            parametros.Add(New SqlParameter("@pfam_descrip", familia.Descripcion))


            res = base.EjecutarInstruccion("SP_Familias_Actualizar", parametros)
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
            parametros.Add(New SqlParameter("@pfam_id", familia.Identificador))

            res = base.EjecutarInstruccion("SP_Familias_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Familia
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfam_id", id))

            reader = base.ConsultarReader("SP_Familias_Consultar", parametros)

            Dim familia As New Familia
            reader.Read()
            familia.Identificador = reader(0)
            familia.Descripcion = reader(1)
            If Not reader Is Nothing Then reader.Close()

            Return familia
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Familia, Optional ByVal Lazy As Boolean = True) As List(Of Familia)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfam_descrip", filtros.Descripcion))

            reader = base.ConsultarReader("SP_Familias_ConsultarPor", parametros)

            Dim familias As New List(Of Familia)
            Do While reader.Read()
                Dim familia As New Familia
                familia.Identificador = reader(0)
                familia.Descripcion = reader(1)

                familias.Add(familia)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return familias

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarPorUsuario(ByVal usuario As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Familia)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@puf_usu_id", usuario.Identificador))

            reader = base.ConsultarReader("SP_Familias_ConsultarPorUsuario", parametros)

            Dim familias As New List(Of Familia)
            Do While reader.Read()
                Dim familia As New Familia
                Dim familiaAD As New FamiliaAD
                familia = familiaAD.ConsultarPorId(reader(0))

                familias.Add(familia)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return familias

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Familia)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Familias_ConsultarTodos")

            Dim familias As New List(Of Familia)
            Do While reader.Read()
                Dim familia As New Familia
                familia.Identificador = reader(0)
                familia.Descripcion = reader(1)

                familias.Add(familia)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return familias
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
