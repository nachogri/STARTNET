Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class ProductoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef producto As Producto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            producto.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pprod_id", producto.Identificador))
            parametros.Add(New SqlParameter("@pprod_nombre", producto.Nombre))
            parametros.Add(New SqlParameter("@pprod_descrip", producto.Descripcion))
            parametros.Add(New SqlParameter("@pprod_cantidad", producto.Cantidad))
            parametros.Add(New SqlParameter("@pprod_moneda", producto.Moneda.Nombre))
            parametros.Add(New SqlParameter("@pprod_precio", producto.Precio))
            parametros.Add(New SqlParameter("@pprod_PMR", producto.PMR))
            parametros.Add(New SqlParameter("@pprod_dimension", producto.Dimension))
            parametros.Add(New SqlParameter("@pprod_nacionalidad", producto.Nacionalidad))
            parametros.Add(New SqlParameter("@pprod_fabricante", producto.Fabricante))
            parametros.Add(New SqlParameter("@pprod_especificaciones", producto.Especificaciones))
            parametros.Add(New SqlParameter("@pprod_garantia", producto.Garantia))
            parametros.Add(New SqlParameter("@pprod_imagen", producto.Imagen))
            If Not producto.TipoProducto Is Nothing Then
                parametros.Add(New SqlParameter("@pprod_tprod_id", producto.TipoProducto.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_Productos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal producto As Producto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pprod_id", producto.Identificador))
            parametros.Add(New SqlParameter("@pprod_nombre", producto.Nombre))
            parametros.Add(New SqlParameter("@pprod_descrip", producto.Descripcion))
            parametros.Add(New SqlParameter("@pprod_cantidad", producto.Cantidad))            
            parametros.Add(New SqlParameter("@pprod_precio", producto.Precio))
            parametros.Add(New SqlParameter("@pprod_PMR", producto.PMR))
            parametros.Add(New SqlParameter("@pprod_dimension", producto.Dimension))
            parametros.Add(New SqlParameter("@pprod_nacionalidad", producto.Nacionalidad))
            parametros.Add(New SqlParameter("@pprod_fabricante", producto.Fabricante))
            parametros.Add(New SqlParameter("@pprod_especificaciones", producto.Especificaciones))
            parametros.Add(New SqlParameter("@pprod_garantia", producto.Garantia))
            parametros.Add(New SqlParameter("@pprod_imagen", producto.Imagen))
            If Not producto.TipoProducto Is Nothing Then
                parametros.Add(New SqlParameter("@pprod_tprod_id", producto.TipoProducto.Identificador))
            End If
            If Not producto.Moneda Is Nothing Then
                parametros.Add(New SqlParameter("@pprod_moneda", producto.Moneda.Nombre))
            End If

            res = base.EjecutarInstruccion("SP_Productos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal producto As Producto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pprod_id", producto.Identificador))

            res = base.EjecutarInstruccion("SP_Productos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Producto
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pprod_id", id))

            reader = base.ConsultarReader("SP_Productos_Consultar", parametros)
            reader.Read()

            Dim producto As New Producto
            producto.Identificador = reader(0)
            producto.Nombre = reader(1)
            producto.Descripcion = reader(2)
            producto.Cantidad = reader(3)

            producto.Precio = reader(5)
            producto.PMR = reader(6)
            producto.Dimension = reader(7)
            producto.Nacionalidad = reader(8)
            producto.Fabricante = reader(9)
            producto.Especificaciones = reader(10)
            producto.Garantia = reader(11)
            producto.Imagen = reader(12)

            If Not Lazy Then
                Dim tipoprodAD = New TipoProductoAD

                producto.TipoProducto = tipoprodAD.ConsultarPorId(reader(13))

                Dim moneda As New Moneda
                moneda.Nombre = reader(4)
                Dim monedaAD As New MonedaAD

                producto.Moneda = monedaAD.ConsultarPor(moneda)(0)
            End If
            If Not reader Is Nothing Then reader.Close()

            Return producto
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Producto, Optional ByVal Lazy As Boolean = True) As List(Of Producto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pprod_nombre", filtros.Nombre))
            parametros.Add(New SqlParameter("@pprod_descrip", filtros.Descripcion))
            parametros.Add(New SqlParameter("@pprod_cantidad", filtros.Cantidad))

            parametros.Add(New SqlParameter("@pprod_precio", Nothing))
            parametros.Add(New SqlParameter("@pprod_PMR", Nothing))
            parametros.Add(New SqlParameter("@pprod_dimension", filtros.Dimension))
            parametros.Add(New SqlParameter("@pprod_nacionalidad", filtros.Nacionalidad))
            parametros.Add(New SqlParameter("@pprod_fabricante", filtros.Fabricante))
            parametros.Add(New SqlParameter("@pprod_especificaciones", filtros.Especificaciones))
            parametros.Add(New SqlParameter("@pprod_garantia", filtros.Garantia))

            If Not filtros.Moneda Is Nothing Then
                parametros.Add(New SqlParameter("@pprod_moneda", filtros.Moneda.Nombre))
            End If
            If Not filtros.TipoProducto Is Nothing Then
                parametros.Add(New SqlParameter("@pprod_tprod_id", filtros.TipoProducto.Identificador))
            End If

            reader = base.ConsultarReader("SP_Productos_ConsultarPor", parametros)

            Dim productos As New List(Of Producto)
            Do While reader.Read()
                Dim producto As New Producto
                producto.Identificador = reader(0)
                producto.Nombre = reader(1)
                producto.Descripcion = reader(2)
                producto.Cantidad = reader(3)
                producto.Precio = reader(5)
                producto.PMR = reader(6)
                producto.Dimension = reader(7)
                producto.Nacionalidad = reader(8)
                producto.Fabricante = reader(9)
                producto.Especificaciones = reader(10)
                producto.Garantia = reader(11)
                producto.Imagen = reader(12)

                If Not Lazy Then
                    Dim tipoprodAD = New TipoProductoAD

                    producto.TipoProducto = tipoprodAD.ConsultarPorId(New Guid(reader(8).ToString()))

                    Dim moneda As New Moneda
                    moneda.Nombre = reader(4)
                    Dim monedaAD As New MonedaAD

                    producto.Moneda = monedaAD.ConsultarPor(moneda)(0)
                End If

                productos.Add(producto)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return productos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Producto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Productos_ConsultarTodos")

            Dim productos As New List(Of Producto)
            Do While reader.Read()
                Dim producto As New Producto
                producto.Identificador = reader(0)
                producto.Nombre = reader(1)
                producto.Descripcion = reader(2)
                producto.Cantidad = reader(3)
                producto.Precio = reader(5)
                producto.PMR = reader(6)
                producto.Dimension = reader(7)
                producto.Nacionalidad = reader(8)
                producto.Fabricante = reader(9)
                producto.Especificaciones = reader(10)
                producto.Garantia = reader(11)
                producto.Imagen = reader(12)

                If Not Lazy Then
                    Dim tipoprodAD = New TipoProductoAD

                    producto.TipoProducto = tipoprodAD.ConsultarPorId(reader(8))

                    Dim moneda As New Moneda
                    moneda.Nombre = reader(4)
                    Dim monedaAD As New MonedaAD

                    producto.Moneda = monedaAD.ConsultarPor(moneda)(0)
                End If

                productos.Add(producto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return productos
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

