Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class TipoProductoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef tipoProducto As TipoProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            tipoProducto.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptprod_id", tipoProducto.Identificador))
            parametros.Add(New SqlParameter("@ptprod_descrip", tipoProducto.Descripcion))

            res = base.EjecutarInstruccion("SP_TipoProductos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal tipoProducto As TipoProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptprod_id", tipoProducto.Identificador))
            parametros.Add(New SqlParameter("@ptprod_descrip", tipoProducto.Descripcion))

            res = base.EjecutarInstruccion("SP_TipoProductos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal tipoProducto As TipoProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptprod_id", tipoProducto.Identificador))

            res = base.EjecutarInstruccion("SP_TipoProductos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As TipoProducto
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptprod_id", id))

            reader = base.ConsultarReader("SP_TipoProductos_Consultar", parametros)
            reader.Read()

            Dim tipoProducto As New TipoProducto
            tipoProducto.Identificador = reader(0)
            tipoProducto.Descripcion = reader(1)
            If Not reader Is Nothing Then reader.Close()

            Return tipoProducto
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As TipoProducto, Optional ByVal Lazy As Boolean = True) As List(Of TipoProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptprod_descrip", filtros.Descripcion))

            reader = base.ConsultarReader("SP_TipoProductos_ConsultarPor", parametros)

            Dim tipoProductos As New List(Of TipoProducto)
            Do While reader.Read()
                Dim tipoProducto As New TipoProducto
                tipoProducto.Identificador = reader(0)
                tipoProducto.Descripcion = reader(1)

                tipoProductos.Add(tipoProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return tipoProductos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of TipoProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_TipoProductos_ConsultarTodos")

            Dim tipoProductos As New List(Of TipoProducto)
            Do While reader.Read()
                Dim tipoProducto As New TipoProducto
                tipoProducto.Identificador = reader(0)
                tipoProducto.Descripcion = reader(1)

                tipoProductos.Add(tipoProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return tipoProductos
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
