Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class MovimientoStockAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef movimientoStock As MovimientoStock) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            movimientoStock.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pms_id", movimientoStock.Identificador))
            parametros.Add(New SqlParameter("@pms_fecha", movimientoStock.Fecha))

            If Not movimientoStock.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@pms_prod_id", movimientoStock.Producto.Identificador))
            End If
            If Not movimientoStock.Venta Is Nothing Then
                parametros.Add(New SqlParameter("@pms_vent_id", movimientoStock.Venta.Identificador))
            End If

            parametros.Add(New SqlParameter("@pms_tipo", movimientoStock.Tipo))
            parametros.Add(New SqlParameter("@pms_cantidad", movimientoStock.Cantidad))
            parametros.Add(New SqlParameter("@pms_monto", movimientoStock.Monto))

            If Not movimientoStock.OrdenCompra Is Nothing Then
                parametros.Add(New SqlParameter("@pms_oc_id", movimientoStock.OrdenCompra.Identificador))
            End If


            res = base.EjecutarInstruccion("SP_MovimientosStock_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal movimientoStock As MovimientoStock) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pms_id", movimientoStock.Identificador))
            parametros.Add(New SqlParameter("@pms_fecha", movimientoStock.Fecha))

            If Not movimientoStock.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@pms_prod_id", movimientoStock.Producto.Identificador))
            End If
            If Not movimientoStock.Venta Is Nothing Then
                parametros.Add(New SqlParameter("@pms_vent_id", movimientoStock.Venta.Identificador))
            End If

            parametros.Add(New SqlParameter("@pms_tipo", movimientoStock.Tipo))
            parametros.Add(New SqlParameter("@pms_cantidad", movimientoStock.Cantidad))
            parametros.Add(New SqlParameter("@pms_monto", movimientoStock.Monto))

            If Not movimientoStock.OrdenCompra Is Nothing Then
                parametros.Add(New SqlParameter("@pms_oc_id", movimientoStock.OrdenCompra.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_MovimientosStock_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal movimientoStock As MovimientoStock) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pms_id", movimientoStock.Identificador))

            res = base.EjecutarInstruccion("SP_MovimientosStock_Borrar", parametros)

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As MovimientoStock
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pms_id", id))

            reader = base.ConsultarReader("SP_MovimientosStock_Consultar", parametros)

            reader.Read()
            Dim movimientoStock As New MovimientoStock
            movimientoStock.Identificador = reader(0)
            movimientoStock.Fecha = reader(1)

            If Not Lazy Then
                Dim productoAD = New ProductoAD
                movimientoStock.Producto = productoAD.ConsultarPorId(reader(2))

                Dim ventaAD = New VentaAD
                movimientoStock.Venta = ventaAD.ConsultarPorId(reader(3))

                Dim ocAD = New OrdenCompraAD
                movimientoStock.OrdenCompra = ocAD.ConsultarPorId(reader(7))
            End If
            movimientoStock.Tipo = reader(4)
            movimientoStock.Cantidad = reader(5)
            movimientoStock.Monto = reader(6)
            If Not reader Is Nothing Then reader.Close()

            Return movimientoStock
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As MovimientoStock, Optional ByVal Lazy As Boolean = True) As List(Of MovimientoStock)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pms_fecha", filtros.Fecha))

            If Not filtros.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@pms_prod_id", filtros.Producto.Identificador))
            End If
            If Not filtros.Venta Is Nothing Then
                parametros.Add(New SqlParameter("@pms_vent_id", filtros.Venta.Identificador))
            End If

            parametros.Add(New SqlParameter("@pms_tipo", filtros.Tipo))
            parametros.Add(New SqlParameter("@pms_cantidad", filtros.Cantidad))
            parametros.Add(New SqlParameter("@pms_monto", filtros.Monto))

            If Not filtros.OrdenCompra Is Nothing Then
                parametros.Add(New SqlParameter("@pms_oc_id", filtros.OrdenCompra.Identificador))
            End If

            reader = base.ConsultarReader("SP_MovimientosStock_ConsultarPor", parametros)

            Dim movimientoStocks As New List(Of MovimientoStock)
            Do While reader.Read()
                Dim movimientoStock As New MovimientoStock
                movimientoStock.Identificador = reader(0)
                movimientoStock.Fecha = reader(1)

                If Not Lazy Then
                    Dim productoAD = New ProductoAD
                    movimientoStock.Producto = productoAD.ConsultarPorId(reader(2))

                    Dim ventaAD = New VentaAD
                    movimientoStock.Venta = ventaAD.ConsultarPorId(reader(3))

                    Dim ocAD = New OrdenCompraAD
                    movimientoStock.OrdenCompra = ocAD.ConsultarPorId(reader(7))
                End If
                movimientoStock.Tipo = reader(4)
                movimientoStock.Cantidad = reader(5)
                movimientoStock.Monto = reader(6)

                movimientoStocks.Add(movimientoStock)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return movimientoStocks

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of MovimientoStock)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_MovimientosStock_ConsultarTodos")

            Dim movimientoStocks As New List(Of MovimientoStock)
            Do While reader.Read()
                Dim movimientoStock As New MovimientoStock
                movimientoStock.Identificador = reader(0)
                movimientoStock.Fecha = reader(1)

                If Not Lazy Then
                    Dim productoAD = New ProductoAD
                    movimientoStock.Producto = productoAD.ConsultarPorId(reader(2))

                    Dim ventaAD = New VentaAD
                    movimientoStock.Venta = ventaAD.ConsultarPorId(reader(3))

                    Dim ocAD = New OrdenCompraAD
                    movimientoStock.OrdenCompra = ocAD.ConsultarPorId(reader(7))
                End If
                movimientoStock.Tipo = reader(4)
                movimientoStock.Cantidad = reader(5)
                movimientoStock.Monto = reader(6)

                movimientoStocks.Add(movimientoStock)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return movimientoStocks
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
