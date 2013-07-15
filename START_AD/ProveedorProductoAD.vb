
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class ProveedorProductoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef proveedorProducto As ProveedorProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            proveedorProducto.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ppp_id", proveedorProducto.Identificador))

            If Not proveedorProducto.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@ppp_prov_id", proveedorProducto.Proveedor.Identificador))
            End If
            If Not proveedorProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@ppp_prod_id", proveedorProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppp_costo", proveedorProducto.Costo))

            res = base.EjecutarInstruccion("SP_ProveedoresProductos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal proveedorProducto As ProveedorProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ppp_id", proveedorProducto.Identificador))

            If Not proveedorProducto.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@ppp_prov_id", proveedorProducto.Proveedor.Identificador))
            End If
            If Not proveedorProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@ppp_prod_id", proveedorProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppp_costo", proveedorProducto.Costo))

            res = base.EjecutarInstruccion("SP_ProveedoresProductos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal proveedorProducto As ProveedorProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppp_id", proveedorProducto.Identificador))

            res = base.EjecutarInstruccion("SP_ProveedoresProductos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As ProveedorProducto
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppp_id", id))

            reader = base.ConsultarReader("SP_ProveedoresProductos_Consultar", parametros)
            reader.Read()

            Dim proveedorProducto As New ProveedorProducto
            proveedorProducto.Identificador = reader(0)

            If Not Lazy Then
                Dim proveedorAD = New ProveedorAD
                proveedorProducto.Proveedor = proveedorAD.ConsultarPorId(reader(1))
                Dim productoAD = New ProductoAD
                proveedorProducto.Producto = productoAD.ConsultarPorId(reader(2))
            End If
            proveedorProducto.Costo = reader(3)
            If Not reader Is Nothing Then reader.Close()

            Return proveedorProducto
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As ProveedorProducto, Optional ByVal Lazy As Boolean = True) As List(Of ProveedorProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@ppp_prov_id", filtros.Proveedor.Identificador))
            End If
            If Not filtros.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@ppp_prod_id", filtros.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppp_costo", filtros.Costo))

            reader = base.ConsultarReader("SP_ProveedoresProductos_ConsultarPor", parametros)

            Dim proveedorProductos As New List(Of ProveedorProducto)
            Do While reader.Read()
                Dim proveedorProducto As New ProveedorProducto
                proveedorProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim proveedorAD = New ProveedorAD
                    proveedorProducto.Proveedor = proveedorAD.ConsultarPorId(reader(1))
                    Dim productoAD = New ProductoAD
                    proveedorProducto.Producto = productoAD.ConsultarPorId(reader(2))
                End If
                proveedorProducto.Costo = reader(3)
                proveedorProductos.Add(proveedorProducto)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return proveedorProductos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of ProveedorProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_ProveedoresProductos_ConsultarTodos")

            Dim proveedorProductos As New List(Of ProveedorProducto)
            Do While reader.Read()
                Dim proveedorProducto As New ProveedorProducto
                proveedorProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim proveedorAD = New ProveedorAD
                    proveedorProducto.Proveedor = proveedorAD.ConsultarPorId(reader(1))
                    Dim productoAD = New ProductoAD
                    proveedorProducto.Producto = productoAD.ConsultarPorId(reader(2))
                End If
                proveedorProducto.Costo = reader(3)
                proveedorProductos.Add(proveedorProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return proveedorProductos
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