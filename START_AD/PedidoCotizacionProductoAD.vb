
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class PedidoCotizacionProductoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pedidosCotizacionProducto As PedidoCotizacionProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            pedidosCotizacionProducto.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppcp_id", pedidosCotizacionProducto.Identificador))

            If Not pedidosCotizacionProducto.PedidoCotizacion Is Nothing Then
                parametros.Add(New SqlParameter("@ppcp_pc_id", pedidosCotizacionProducto.PedidoCotizacion.Identificador))
            End If
            If Not pedidosCotizacionProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@ppcp_prod_id", pedidosCotizacionProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppcp_cantidad", pedidosCotizacionProducto.Cantidad))

            res = base.EjecutarInstruccion("SP_PedidosCotizacionProductos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal pedidosCotizacionProducto As PedidoCotizacionProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            pedidosCotizacionProducto.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppcp_id", pedidosCotizacionProducto.Identificador))

            If Not pedidosCotizacionProducto.PedidoCotizacion Is Nothing Then
                parametros.Add(New SqlParameter("@ppcp_pc_id", pedidosCotizacionProducto.PedidoCotizacion.Identificador))
            End If
            If Not pedidosCotizacionProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@ppcp_prod_id", pedidosCotizacionProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppcp_cantidad", pedidosCotizacionProducto.Cantidad))

            res = base.EjecutarInstruccion("SP_PedidosCotizacionProductos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal pedidosCotizacionProducto As PedidoCotizacionProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppcp_id", pedidosCotizacionProducto.Identificador))

            res = base.EjecutarInstruccion("SP_PedidosCotizacionProductos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As PedidoCotizacionProducto
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppcp_id", id))

            reader = base.ConsultarReader("SP_PedidosCotizacionProductos_Consultar", parametros)
            reader.Read()
            Dim factoriaPedidoCotizacionProducto As New FactoriaPedidoCotizacionProducto
            Dim pedidosCotizacionProducto As PedidoCotizacionProducto = factoriaPedidoCotizacionProducto.CrearProducto()
            pedidosCotizacionProducto.Identificador = reader(0)

            If Not Lazy Then
                Dim PedidoCotizacionAD = New PedidoCotizacionAD
                pedidosCotizacionProducto.PedidoCotizacion = PedidoCotizacionAD.ConsultarPorId(reader(1))

                Dim productoAD = New ProductoAD
                pedidosCotizacionProducto.Producto = productoAD.ConsultarPorId(reader(2))
            End If
            pedidosCotizacionProducto.Cantidad = reader(3)
            If Not reader Is Nothing Then reader.Close()

            Return pedidosCotizacionProducto
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As PedidoCotizacionProducto, Optional ByVal Lazy As Boolean = True) As List(Of PedidoCotizacionProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.PedidoCotizacion Is Nothing Then
                parametros.Add(New SqlParameter("@ppcp_oc_id", filtros.PedidoCotizacion.Identificador))
            End If
            If Not filtros.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@ppcp_prod_id", filtros.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppcp_cantidad", filtros.Cantidad))

            reader = base.ConsultarReader("SP_PedidosCotizacionProductos_ConsultarPor", parametros)

            Dim pedidosCotizacionProductos As New List(Of PedidoCotizacionProducto)
            Do While reader.Read()
                Dim factoriaPedidoCotizacionProducto As New FactoriaPedidoCotizacionProducto
                Dim pedidosCotizacionProducto As PedidoCotizacionProducto = factoriaPedidoCotizacionProducto.CrearProducto()
                pedidosCotizacionProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim PedidoCotizacionAD = New PedidoCotizacionAD
                    pedidosCotizacionProducto.PedidoCotizacion = PedidoCotizacionAD.ConsultarPorId(reader(1))

                    Dim productoAD = New ProductoAD
                    pedidosCotizacionProducto.Producto = productoAD.ConsultarPorId(reader(2))
                End If
                pedidosCotizacionProducto.Cantidad = reader(3)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return pedidosCotizacionProductos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of PedidoCotizacionProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_PedidosCotizacionProductos_ConsultarTodos")

            Dim pedidosCotizacionProductos As New List(Of PedidoCotizacionProducto)
            Do While reader.Read()
                Dim factoriaPedidoCotizacionProducto As New FactoriaPedidoCotizacionProducto
                Dim pedidosCotizacionProducto As PedidoCotizacionProducto = factoriaPedidoCotizacionProducto.CrearProducto()
                pedidosCotizacionProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim PedidoCotizacionAD = New PedidoCotizacionAD
                    pedidosCotizacionProducto.PedidoCotizacion = PedidoCotizacionAD.ConsultarPorId(reader(1))

                    Dim productoAD = New ProductoAD
                    pedidosCotizacionProducto.Producto = productoAD.ConsultarPorId(reader(2))
                End If
                pedidosCotizacionProducto.Cantidad = reader(3)

                pedidosCotizacionProductos.Add(pedidosCotizacionProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return pedidosCotizacionProductos
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
