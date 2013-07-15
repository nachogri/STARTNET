Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class ProveedorAD
#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef proveedor As Proveedor) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            proveedor.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pprov_id", proveedor.Identificador))
            parametros.Add(New SqlParameter("@pprov_nombre", proveedor.Nombre))
            parametros.Add(New SqlParameter("@pprov_telefono", proveedor.Telefono))
            parametros.Add(New SqlParameter("@pprov_email", proveedor.Email))
            parametros.Add(New SqlParameter("@pprov_dom_id", proveedor.Domicilio))

            res = base.EjecutarInstruccion("SP_Proveedores_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal proveedor As Proveedor) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()


            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pprov_id", proveedor.Identificador))
            parametros.Add(New SqlParameter("@pprov_nombre", proveedor.Nombre))
            parametros.Add(New SqlParameter("@pprov_telefono", proveedor.Telefono))
            parametros.Add(New SqlParameter("@pprov_email", proveedor.Email))
        parametros.Add(New SqlParameter("@pprov_dom_id", proveedor.Domicilio))

            res = base.EjecutarInstruccion("SP_Proveedores_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal proveedor As Proveedor) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pprov_id", proveedor.Identificador))

            res = base.EjecutarInstruccion("SP_Proveedores_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Proveedor
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pprov_id", id))

            reader = base.ConsultarReader("SP_Proveedores_Consultar", parametros)
            reader.Read()

            Dim proveedor As New Proveedor
            proveedor.Identificador = reader(0)
            proveedor.Nombre = reader(1)
            proveedor.Email = reader(2)
            proveedor.Telefono = reader(3)
            proveedor.Domicilio = reader(4)
            
            If Not reader Is Nothing Then reader.Close()

            Return proveedor
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Proveedor, Optional ByVal Lazy As Boolean = True) As List(Of Proveedor)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()


            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pprov_nombre", filtros.Nombre))
            parametros.Add(New SqlParameter("@pprov_telefono", filtros.Telefono))
            parametros.Add(New SqlParameter("@pprov_email", filtros.Email))            
            parametros.Add(New SqlParameter("@pprov_dom_id", filtros.Domicilio))        

            reader = base.ConsultarReader("SP_Proveedores_ConsultarPor", parametros)

            Dim proveedors As New List(Of Proveedor)
            Do While reader.Read()
                Dim proveedor As New Proveedor
                proveedor.Identificador = reader(0)
                proveedor.Nombre = reader(1)
                proveedor.Email = reader(2)
                proveedor.Telefono = reader(3)
                proveedor.Domicilio = reader(4)

                proveedors.Add(proveedor)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return proveedors

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Proveedor)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Proveedores_ConsultarTodos")

            Dim proveedors As New List(Of Proveedor)
            Do While reader.Read()
                Dim proveedor As New Proveedor
                proveedor.Identificador = reader(0)
                proveedor.Nombre = reader(1)
                proveedor.Email = reader(2)
                proveedor.Telefono = reader(3)
                proveedor.Domicilio = reader(4)

                proveedors.Add(proveedor)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return proveedors
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

