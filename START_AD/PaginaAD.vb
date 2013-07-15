

Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class PaginaAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pagina As Pagina) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            pagina.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppag_id", pagina.Identificador))
            parametros.Add(New SqlParameter("@ppag_nombre", pagina.Nombre))
            parametros.Add(New SqlParameter("@ppag_descrip", pagina.Descripcion))

            res = base.EjecutarInstruccion("SP_Paginas_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal pagina As Pagina) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppag_id", pagina.Identificador))
            parametros.Add(New SqlParameter("@ppag_nombre", pagina.Nombre))
            parametros.Add(New SqlParameter("@ppag_descrip", pagina.Descripcion))

            res = base.EjecutarInstruccion("SP_Paginas_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal pagina As Pagina) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppag_id", pagina.Identificador))
            parametros.Add(New SqlParameter("@ppag_nombre", pagina.Nombre))
            parametros.Add(New SqlParameter("@ppag_descrip", pagina.Descripcion))

            res = base.EjecutarInstruccion("SP_Paginas_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Pagina
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppag_id", id))

            reader = base.ConsultarReader("SP_Paginas_Consultar", parametros)
            reader.Read()
            Dim pagina As New Pagina
            pagina.Identificador = reader(0)
            pagina.Nombre = reader(1)
            pagina.Descripcion = reader(2)
            If Not reader Is Nothing Then reader.Close()

            Return pagina
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Pagina, Optional ByVal Lazy As Boolean = True) As List(Of Pagina)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ppag_nombre", filtros.Nombre))
            parametros.Add(New SqlParameter("@ppag_descrip", filtros.Descripcion))

            reader = base.ConsultarReader("SP_Paginas_ConsultarPor", parametros)

            Dim paginas As New List(Of Pagina)
            Do While reader.Read()
                Dim pagina As New Pagina
                pagina.Identificador = reader(0)
                pagina.Nombre = reader(1)
                pagina.Descripcion = reader(2)

                paginas.Add(pagina)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return paginas

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Pagina)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Paginas_ConsultarTodos")

            Dim paginas As New List(Of Pagina)
            Do While reader.Read()
                Dim pagina As New Pagina
                pagina.Identificador = reader(0)
                pagina.Nombre = reader(1)
                pagina.Descripcion = reader(2)

                paginas.Add(pagina)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return paginas
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
