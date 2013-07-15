Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class OrdenCompraProductoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef ordenesCompraProducto As OrdenCompraProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            ordenesCompraProducto.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pocp_id", ordenesCompraProducto.Identificador))

            If Not ordenesCompraProducto.OrdenCompra Is Nothing Then
                parametros.Add(New SqlParameter("@pocp_oc_id", ordenesCompraProducto.OrdenCompra.Identificador))
            End If
            If Not ordenesCompraProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@pocp_prod_id", ordenesCompraProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@pocp_cantidad", ordenesCompraProducto.Cantidad))

            res = base.EjecutarInstruccion("SP_OrdenesCompraProductos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal ordenesCompraProducto As OrdenCompraProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pocp_id", ordenesCompraProducto.Identificador))

            If Not ordenesCompraProducto.OrdenCompra Is Nothing Then
                parametros.Add(New SqlParameter("@pocp_oc_id", ordenesCompraProducto.OrdenCompra.Identificador))
            End If
            If Not ordenesCompraProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@pocp_prod_id", ordenesCompraProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@pocp_cantidad", ordenesCompraProducto.Cantidad))

            res = base.EjecutarInstruccion("SP_OrdenesCompraProductos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal ordenesCompraProducto As OrdenCompraProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pocp_id", ordenesCompraProducto.Identificador))

            res = base.EjecutarInstruccion("SP_OrdenesCompraProductos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As OrdenCompraProducto
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pocp_id", id))

            reader = base.ConsultarReader("SP_OrdenesCompraProductos_Consultar", parametros)
            reader.Read()
            Dim factoriaOrdenCompraProducto As New FactoriaOrdenCompraProducto
            Dim ordenesCompraProducto As OrdenCompraProducto = factoriaOrdenCompraProducto.CrearProducto()
            ordenesCompraProducto.Identificador = reader(0)

            If Not Lazy Then
                Dim ordenesCompraAD = New OrdenCompraAD
                ordenesCompraProducto.OrdenCompra = ordenesCompraAD.ConsultarPorId(reader(1))

                Dim productoAD = New ProductoAD
                ordenesCompraProducto.Producto = productoAD.ConsultarPorId(reader(2))
            End If
            ordenesCompraProducto.Cantidad = reader(3)
            If Not reader Is Nothing Then reader.Close()

            Return ordenesCompraProducto
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As OrdenCompraProducto, Optional ByVal Lazy As Boolean = True) As List(Of OrdenCompraProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.OrdenCompra Is Nothing Then
                parametros.Add(New SqlParameter("@pocp_oc_id", filtros.OrdenCompra.Identificador))
            End If
            If Not filtros.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@pocp_prod_id", filtros.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@pocp_cantidad", filtros.Cantidad))

            reader = base.ConsultarReader("SP_OrdenesCompraProductos_ConsultarPor", parametros)

            Dim ordenesCompraProductos As New List(Of OrdenCompraProducto)
            Do While reader.Read()
                Dim factoriaOrdenCompraProducto As New FactoriaOrdenCompraProducto
                Dim ordenesCompraProducto As OrdenCompraProducto = factoriaOrdenCompraProducto.CrearProducto()
                ordenesCompraProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim ordenesCompraAD = New OrdenCompraAD
                    ordenesCompraProducto.OrdenCompra = ordenesCompraAD.ConsultarPorId(reader(1))

                    Dim productoAD = New ProductoAD
                    ordenesCompraProducto.Producto = productoAD.ConsultarPorId(reader(2))
                End If
                ordenesCompraProducto.Cantidad = reader(3)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return ordenesCompraProductos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of OrdenCompraProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_OrdenesCompraProductos_ConsultarTodos")

            Dim ordenesCompraProductos As New List(Of OrdenCompraProducto)
            Do While reader.Read()
                Dim factoriaOrdenCompraProducto As New FactoriaOrdenCompraProducto
                Dim ordenesCompraProducto As OrdenCompraProducto = factoriaOrdenCompraProducto.CrearProducto()
                ordenesCompraProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim ordenesCompraAD = New OrdenCompraAD
                    ordenesCompraProducto.OrdenCompra = ordenesCompraAD.ConsultarPorId(reader(1))

                    Dim productoAD = New ProductoAD
                    ordenesCompraProducto.Producto = productoAD.ConsultarPorId(reader(2))
                End If
                ordenesCompraProducto.Cantidad = reader(3)

                ordenesCompraProductos.Add(ordenesCompraProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return ordenesCompraProductos
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
