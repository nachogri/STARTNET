Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class VentaProductoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef ventaProducto As VentaProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            ventaProducto.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pvp_id", ventaProducto.Identificador))

            If Not ventaProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@pvp_prod_id", ventaProducto.Producto.Identificador))
            End If
            If Not ventaProducto.Venta Is Nothing Then
                parametros.Add(New SqlParameter("@pvp_vent_id", ventaProducto.Venta.Identificador))
            End If

            parametros.Add(New SqlParameter("@pvp_cantidad", ventaProducto.Cantidad))

            res = base.EjecutarInstruccion("SP_VentaProductos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal ventaProducto As VentaProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pvp_id", ventaProducto.Identificador))

            If Not ventaProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@pvp_prod_id", ventaProducto.Producto.Identificador))
            End If
            If Not ventaProducto.Venta Is Nothing Then
                parametros.Add(New SqlParameter("@pvp_vent_id", ventaProducto.Venta.Identificador))
            End If

            parametros.Add(New SqlParameter("@pvp_cantidad", ventaProducto.Cantidad))

            res = base.EjecutarInstruccion("SP_VentasProductos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal ventaProducto As VentaProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pvp_id", ventaProducto.Identificador))

            res = base.EjecutarInstruccion("SP_VentasProductos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As VentaProducto
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pvp_id", id))

            reader = base.ConsultarReader("SP_VentasProductos_Consultar", parametros)
            reader.Read()

            Dim ventaProducto As New VentaProducto
            ventaProducto.Identificador = reader(0)

            If Not Lazy Then
                Dim productoAD = New ProductoAD
                ventaProducto.Producto = productoAD.ConsultarPorId(reader(1))

                Dim ventaAD = New VentaAD
                ventaProducto.Venta = ventaAD.ConsultarPorId(reader(2))
            End If
            ventaProducto.Cantidad = reader(3)


            If Not reader Is Nothing Then reader.Close()
            Return ventaProducto
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As VentaProducto, Optional ByVal Lazy As Boolean = True) As List(Of VentaProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@pvp_prod_id", filtros.Producto.Identificador))
            End If
            If Not filtros.Venta Is Nothing Then
                parametros.Add(New SqlParameter("@pvp_vent_id", filtros.Venta.Identificador))
            End If

            parametros.Add(New SqlParameter("@pvp_cantidad", DBNull.Value))

            reader = base.ConsultarReader("SP_VentasProductos_ConsultarPor", parametros)

            Dim ventaProductos As New List(Of VentaProducto)
            Do While reader.Read()
                Dim ventaProducto As New VentaProducto
                ventaProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim productoAD = New ProductoAD
                    ventaProducto.Producto = productoAD.ConsultarPorId(reader(1))

                    Dim ventaAD = New VentaAD
                    ventaProducto.Venta = ventaAD.ConsultarPorId(reader(2))
                End If
                ventaProducto.Cantidad = reader(3)

                ventaProductos.Add(ventaProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return ventaProductos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of VentaProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_VentasProductos_ConsultarTodos")

            Dim ventaProductos As New List(Of VentaProducto)
            Do While reader.Read()
                Dim ventaProducto As New VentaProducto
                ventaProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim productoAD = New ProductoAD
                    ventaProducto.Producto = productoAD.ConsultarPorId(reader(1))

                    Dim ventaAD = New VentaAD
                    ventaProducto.Venta = ventaAD.ConsultarPorId(reader(2))
                End If
                ventaProducto.Cantidad = reader(3)

                ventaProductos.Add(ventaProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return ventaProductos
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