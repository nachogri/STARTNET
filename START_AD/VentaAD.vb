Imports START_ENTIDADES
Imports System.Data.SqlClient
Imports START_HELPER

Public Class VentaAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef venta As Venta) As Integer
        Dim res As Integer = -1
        Try
            'Utilizacion de transacciones
            'Primero agrego el alta de la venta
            base = New START_SERVICIOS.BaseDeDatosSQL()

            venta.Identificador = Guid.NewGuid
            Dim lstComandos As New List(Of SqlCommand)
            Dim cmdVenta As New SqlCommand()
            cmdVenta.CommandText = "SP_Ventas_Insertar"
            cmdVenta.CommandType = CommandType.StoredProcedure
            cmdVenta.Parameters.Add(New SqlParameter("@pvent_id", venta.Identificador))
            If Not venta.Usuario Is Nothing Then
                cmdVenta.Parameters.Add(New SqlParameter("@pvent_usu_id", venta.Usuario.Identificador))
            End If
            cmdVenta.Parameters.Add(New SqlParameter("@pvent_fecha", venta.Fecha))
            cmdVenta.Parameters.Add(New SqlParameter("@pvent_lugar_entrega", venta.LugarEntrega))
            cmdVenta.Parameters.Add(New SqlParameter("@pvent_plazo_entrega", venta.PlazoEntrega))
            cmdVenta.Parameters.Add(New SqlParameter("@pvent_importe", venta.Importe))
            cmdVenta.Parameters.Add(New SqlParameter("@pvent_promocion", venta.Promocion))
            cmdVenta.Parameters.Add(New SqlParameter("@pvent_imp_total", venta.ImporteTotal))
            If Not venta.TipoPago Is Nothing Then
                cmdVenta.Parameters.Add(New SqlParameter("@pvent_tpago_id", venta.TipoPago.Identificador))
            End If
            cmdVenta.Parameters.Add(New SqlParameter("@pvent_iva", venta.IVA))

            lstComandos.Add(cmdVenta)


            For Each producto As VentaProducto In venta.Productos
                'Ahora agrego el alta de los productos
                Dim cmdVentaProducto As New SqlCommand()
                cmdVentaProducto.CommandText = "SP_VentasProductos_Insertar"
                cmdVentaProducto.CommandType = CommandType.StoredProcedure

                producto.Identificador = Guid.NewGuid
                cmdVentaProducto.Parameters.Add(New SqlParameter("@pvp_id", producto.Identificador))
                If Not producto.Producto Is Nothing Then
                    cmdVentaProducto.Parameters.Add(New SqlParameter("@pvp_prod_id", producto.Producto.Identificador))
                End If
                If Not venta Is Nothing Then
                    cmdVentaProducto.Parameters.Add(New SqlParameter("@pvp_vent_id", venta.Identificador))
                End If
                cmdVentaProducto.Parameters.Add(New SqlParameter("@pvp_cantidad", producto.Cantidad))

                lstComandos.Add(cmdVentaProducto)
            Next

            res = base.EjecutarInstruccionesEnTransaccion(lstComandos)

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal venta As Venta) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pvent_id", venta.Identificador))
            If Not venta.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pvent_usu_id", venta.Usuario.Identificador))
            End If
            parametros.Add(New SqlParameter("@pvent_fecha", venta.Fecha))
            parametros.Add(New SqlParameter("@pvent_lugar_entrega", venta.LugarEntrega))
            parametros.Add(New SqlParameter("@pvent_plazo_entrega", venta.PlazoEntrega))
            parametros.Add(New SqlParameter("@pvent_importe", venta.Importe))
            parametros.Add(New SqlParameter("@pvent_promocion", venta.Promocion))
            parametros.Add(New SqlParameter("@pvent_imp_total", venta.ImporteTotal))
            If Not venta.TipoPago Is Nothing Then
                parametros.Add(New SqlParameter("@pvent_loc_id", venta.TipoPago.Identificador))
            End If
            parametros.Add(New SqlParameter("@pvent_iva", venta.IVA))


            res = base.EjecutarInstruccion("SP_Ventas_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal venta As Venta) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pvent_id", venta.Identificador))

            res = base.EjecutarInstruccion("SP_Ventas_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Venta
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pvent_id", id))

            reader = base.ConsultarReader("SP_Ventas_Consultar", parametros)
            reader.Read()

            Dim venta As New Venta
            venta.Identificador = reader(0)
            venta.Fecha = reader(2)
            venta.LugarEntrega = reader(3)
            venta.PlazoEntrega = reader(4)
            venta.Importe = reader(5)
            venta.Promocion = reader(6)
            venta.Importe = reader(7)
            venta.IVA = reader(9)

            If Not Lazy Then
                Dim tipopagoAD = New TipoPagoAD
                Dim usuarioAD = New UsuarioAD

                venta.TipoPago = tipopagoAD.ConsultarPorId(reader(8))

                venta.Usuario = usuarioAD.ConsultarPorId(reader(1))
            End If

            If Not reader Is Nothing Then reader.Close()

            Return venta
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Venta, Optional ByVal Lazy As Boolean = True) As List(Of Venta)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@pvent_usu_id", filtros.Usuario.Identificador))
            End If
            If Not DateHelper.IsNullDate(filtros.Fecha) Then
                parametros.Add(New SqlParameter("@pvent_fecha", filtros.Fecha))
            Else
                parametros.Add(New SqlParameter("@pvent_fecha", DBNull.Value))
            End If

            parametros.Add(New SqlParameter("@pvent_lugar_entrega", filtros.LugarEntrega))
            parametros.Add(New SqlParameter("@pvent_plazo_entrega", filtros.PlazoEntrega))
            parametros.Add(New SqlParameter("@pvent_importe", DBNull.Value))
            parametros.Add(New SqlParameter("@pvent_promocion", DBNull.Value))
            parametros.Add(New SqlParameter("@pvent_imp_total", filtros.ImporteTotal))

            If Not filtros.Productos Is Nothing AndAlso Not filtros.Productos(0).Producto Is Nothing Then
                parametros.Add(New SqlParameter("@pvent_prod_id", filtros.Productos(0).Producto.Identificador))
            End If

            If Not filtros.TipoPago Is Nothing Then
                parametros.Add(New SqlParameter("@pvent_tpago_id", filtros.TipoPago.Identificador))
            End If
            parametros.Add(New SqlParameter("@pvent_iva", DBNull.Value))

            reader = base.ConsultarReader("SP_Ventas_ConsultarPor", parametros)

            Dim ventas As New List(Of Venta)
            Do While reader.Read()
                Dim venta As New Venta
                venta.Identificador = reader(0)
                venta.Fecha = reader(2)
                venta.LugarEntrega = reader(3)
                venta.PlazoEntrega = reader(4)
                venta.Importe = reader(5)
                venta.Promocion = reader(6)
                venta.Importe = reader(7)
                venta.IVA = reader(9)

                If Not Lazy Then
                    Dim tipopagoAD = New TipoPagoAD
                    Dim usuarioAD = New UsuarioAD
                    venta.TipoPago = tipopagoAD.ConsultarPorId(reader(8))
                    venta.Usuario = usuarioAD.ConsultarPorId(reader(1))
                End If

                ventas.Add(venta)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return ventas

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Venta)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Ventas_ConsultarTodos")

            Dim ventas As New List(Of Venta)
            Do While reader.Read()
                Dim venta As New Venta
                venta.Identificador = reader(0)
                venta.Fecha = reader(2)
                venta.LugarEntrega = reader(3)
                venta.PlazoEntrega = reader(4)
                venta.Importe = reader(5)
                venta.Promocion = reader(6)
                venta.Importe = reader(7)
                venta.IVA = reader(9)

                If Not Lazy Then
                    Dim tipopagoAD = New TipoPagoAD
                    Dim usuarioAD = New UsuarioAD
                    venta.TipoPago = tipopagoAD.ConsultarPorId(reader(8))
                    venta.Usuario = usuarioAD.ConsultarPorId(reader(1))
                End If

                ventas.Add(venta)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return ventas
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
