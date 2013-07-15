Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class PromocionProductoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef promocionProducto As PromocionProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            promocionProducto.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppromp_id", promocionProducto.Identificador))

            If Not promocionProducto.Promocion Is Nothing Then
                parametros.Add(New SqlParameter("@ppromp_promo_id", promocionProducto.Promocion.Identificador))
            End If
            If Not promocionProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@ppromp_prod_id", promocionProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppromp_regalo", promocionProducto.Regalo))
            parametros.Add(New SqlParameter("@ppromp_descuento", promocionProducto.Descuento))

            res = base.EjecutarInstruccion("SP_PromocionesProductos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal promocionProducto As PromocionProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ppromp_id", promocionProducto.Identificador))

            If Not promocionProducto.Promocion Is Nothing Then
                parametros.Add(New SqlParameter("@ppromp_promo_id", promocionProducto.Promocion.Identificador))
            End If
            If Not promocionProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@ppromp_prod_id", promocionProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppromp_regalo", promocionProducto.Regalo))
            parametros.Add(New SqlParameter("@ppromp_descuento", promocionProducto.Descuento))

            res = base.EjecutarInstruccion("SP_PromocionesProductos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal promocionProducto As PromocionProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppromp_id", promocionProducto.Identificador))

            res = base.EjecutarInstruccion("SP_PromocionesProductos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As PromocionProducto
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppromp_id", id))

            reader = base.ConsultarReader("SP_PromocionesProductos_Consultar", parametros)
            reader.Read()

            Dim promocionProducto As New PromocionProducto
            promocionProducto.Identificador = reader(0)

            If Not Lazy Then
                Dim productoAD = New ProductoAD
                promocionProducto.Producto = productoAD.ConsultarPorId(reader(1))

                Dim promocionAD = New PromocionAD
                promocionProducto.Promocion = promocionAD.ConsultarPorId(reader(2))
            End If
            promocionProducto.Regalo = reader(3)
            promocionProducto.Descuento = reader(4)
            If Not reader Is Nothing Then reader.Close()

            Return promocionProducto
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As PromocionProducto, Optional ByVal Lazy As Boolean = True) As List(Of PromocionProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@ppromp_prod_id", filtros.Producto.Identificador))
            End If
            If Not filtros.Promocion Is Nothing Then
                parametros.Add(New SqlParameter("@ppromp_promo_id", filtros.Promocion.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppromp_regalo", DBNull.Value))
            parametros.Add(New SqlParameter("@ppromp_descuento", DBNull.Value))

            reader = base.ConsultarReader("SP_PromocionesProductos_ConsultarPor", parametros)

            Dim promocionProductos As New List(Of PromocionProducto)
            Do While reader.Read()
                Dim promocionProducto As New PromocionProducto
                promocionProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim productoAD = New ProductoAD
                    promocionProducto.Producto = productoAD.ConsultarPorId(reader(1))

                    Dim promocionAD = New PromocionAD
                    promocionProducto.Promocion = promocionAD.ConsultarPorId(reader(2))
                End If
                promocionProducto.Regalo = reader(3)
                promocionProducto.Descuento = reader(4)

                promocionProductos.Add(promocionProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return promocionProductos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of PromocionProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_PromocionesProductos_ConsultarTodos")

            Dim promocionProductos As New List(Of PromocionProducto)
            Do While reader.Read()
                Dim promocionProducto As New PromocionProducto
                promocionProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim productoAD = New ProductoAD
                    promocionProducto.Producto = productoAD.ConsultarPorId(reader(1))

                    Dim promocionAD = New PromocionAD
                    promocionProducto.Promocion = promocionAD.ConsultarPorId(reader(2))
                End If
                promocionProducto.Regalo = reader(3)
                promocionProducto.Descuento = reader(4)

                promocionProductos.Add(promocionProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return promocionProductos
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