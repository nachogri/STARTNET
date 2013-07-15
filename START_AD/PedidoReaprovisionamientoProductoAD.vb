
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class PedidoReaprovisionamientoProductoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pedidosReaprovisionamientoProducto As PedidoReaprovisionamientoProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            pedidosReaprovisionamientoProducto.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@prap_id", pedidosReaprovisionamientoProducto.Identificador))

            If Not pedidosReaprovisionamientoProducto.PedidoReaprovisionamiento Is Nothing Then
                parametros.Add(New SqlParameter("@prap_pra_id", pedidosReaprovisionamientoProducto.PedidoReaprovisionamiento.Identificador))
            End If
            If Not pedidosReaprovisionamientoProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@prap_prod_id", pedidosReaprovisionamientoProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@prap_cantidad", pedidosReaprovisionamientoProducto.Cantidad))

            res = base.EjecutarInstruccion("SP_PedidosReaprovisionamientoProductos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal pedidosReaprovisionamientoProducto As PedidoReaprovisionamientoProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@prap_id", pedidosReaprovisionamientoProducto.Identificador))

            If Not pedidosReaprovisionamientoProducto.PedidoReaprovisionamiento Is Nothing Then
                parametros.Add(New SqlParameter("@prap_pra_id", pedidosReaprovisionamientoProducto.PedidoReaprovisionamiento.Identificador))
            End If
            If Not pedidosReaprovisionamientoProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@prap_prod_id", pedidosReaprovisionamientoProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@prap_cantidad", pedidosReaprovisionamientoProducto.Cantidad))

            res = base.EjecutarInstruccion("SP_PedidosReaprovisionamientoProductos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal pedidosReaprovisionamientoProducto As PedidoReaprovisionamientoProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@prap_id", pedidosReaprovisionamientoProducto.Identificador))

            res = base.EjecutarInstruccion("SP_PedidosReaprovisionamientoProductos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As PedidoReaprovisionamientoProducto
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@prap_id", id))

            reader = base.ConsultarReader("SP_PedidosReaprovisionamientoProductos_Consultar", parametros)
            reader.Read()
            Dim factoriaPedidoReaprovisionamientoProducto As New FactoriaPedidoReaprovisionamientoProducto
            Dim pedidosReaprovisionamientoProducto As PedidoReaprovisionamientoProducto = factoriaPedidoReaprovisionamientoProducto.CrearProducto()
            pedidosReaprovisionamientoProducto.Identificador = reader(0)

            If Not Lazy Then
                Dim PedidoReaprovisionamientoAD = New PedidoReaprovisionamientoAD
                pedidosReaprovisionamientoProducto.PedidoReaprovisionamiento = PedidoReaprovisionamientoAD.ConsultarPorId(reader(1))

                Dim productoAD = New ProductoAD
                pedidosReaprovisionamientoProducto.Producto = productoAD.ConsultarPorId(reader(2))
            End If
            pedidosReaprovisionamientoProducto.Cantidad = reader(3)

            If Not reader Is Nothing Then reader.Close()


            Return pedidosReaprovisionamientoProducto
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As PedidoReaprovisionamientoProducto, Optional ByVal Lazy As Boolean = True) As List(Of PedidoReaprovisionamientoProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.PedidoReaprovisionamiento Is Nothing Then
                parametros.Add(New SqlParameter("@prap_pra_id", filtros.PedidoReaprovisionamiento.Identificador))
            End If
            If Not filtros.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@prap_prod_id", filtros.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@prap_cantidad", filtros.Cantidad))

            reader = base.ConsultarReader("SP_PedidosReaprovisionamientoProductos_ConsultarPor", parametros)

            Dim pedidosReaprovisionamientoProductos As New List(Of PedidoReaprovisionamientoProducto)
            Do While reader.Read()
                Dim factoriaPedidoReaprovisionamientoProducto As New FactoriaPedidoReaprovisionamientoProducto
                Dim pedidosReaprovisionamientoProducto As PedidoReaprovisionamientoProducto = factoriaPedidoReaprovisionamientoProducto.CrearProducto()
                pedidosReaprovisionamientoProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim PedidoReaprovisionamientoAD = New PedidoReaprovisionamientoAD
                    pedidosReaprovisionamientoProducto.PedidoReaprovisionamiento = PedidoReaprovisionamientoAD.ConsultarPorId(reader(1))

                    Dim productoAD = New ProductoAD
                    pedidosReaprovisionamientoProducto.Producto = productoAD.ConsultarPorId(reader(2))
                End If
                pedidosReaprovisionamientoProducto.Cantidad = reader(3)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return pedidosReaprovisionamientoProductos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of PedidoReaprovisionamientoProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_PedidosReaprovisionamientoProductos_ConsultarTodos")

            Dim pedidosReaprovisionamientoProductos As New List(Of PedidoReaprovisionamientoProducto)
            Do While reader.Read()
                Dim factoriaPedidoReaprovisionamientoProducto As New FactoriaPedidoReaprovisionamientoProducto
                Dim pedidosReaprovisionamientoProducto As PedidoReaprovisionamientoProducto = factoriaPedidoReaprovisionamientoProducto.CrearProducto()
                pedidosReaprovisionamientoProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim PedidoReaprovisionamientoAD = New PedidoReaprovisionamientoAD
                    pedidosReaprovisionamientoProducto.PedidoReaprovisionamiento = PedidoReaprovisionamientoAD.ConsultarPorId(reader(1))

                    Dim productoAD = New ProductoAD
                    pedidosReaprovisionamientoProducto.Producto = productoAD.ConsultarPorId(reader(2))
                End If
                pedidosReaprovisionamientoProducto.Cantidad = reader(3)

                pedidosReaprovisionamientoProductos.Add(pedidosReaprovisionamientoProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return pedidosReaprovisionamientoProductos
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
