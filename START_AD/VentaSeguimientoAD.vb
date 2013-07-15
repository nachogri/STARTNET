Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class VentaSeguimientoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef ventaSeguimiento As VentaSeguimiento) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            ventaSeguimiento.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pvs_id", ventaSeguimiento.Identificador))

            If Not ventaSeguimiento.Venta Is Nothing Then
                parametros.Add(New SqlParameter("@pvs_vent_id", ventaSeguimiento.Venta.Identificador))
            End If

            parametros.Add(New SqlParameter("@pvs_estado_id", ventaSeguimiento.Estado))
            parametros.Add(New SqlParameter("@pvs_nro_fac", ventaSeguimiento.NumeroFactura))
            parametros.Add(New SqlParameter("@pvs_comprobante", ventaSeguimiento.Comprobante))
            parametros.Add(New SqlParameter("@pvs_monto_adeudado", ventaSeguimiento.Monto))
            parametros.Add(New SqlParameter("@pvs_calificacion", ventaSeguimiento.Calificacion))
            parametros.Add(New SqlParameter("@pvs_comentarios", ventaSeguimiento.Comentarios))



            res = base.EjecutarInstruccion("SP_VentasSeguimientos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal ventaSeguimiento As VentaSeguimiento) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pvs_id", ventaSeguimiento.Identificador))

            If Not ventaSeguimiento.Venta Is Nothing Then
                parametros.Add(New SqlParameter("@pvs_vent_id", ventaSeguimiento.Venta.Identificador))
            End If

            parametros.Add(New SqlParameter("@pvs_estado_id", ventaSeguimiento.Estado))
            parametros.Add(New SqlParameter("@pvs_nro_fac", ventaSeguimiento.NumeroFactura))
            parametros.Add(New SqlParameter("@pvs_comprobante", ventaSeguimiento.Comprobante))
            parametros.Add(New SqlParameter("@pvs_monto_adeudado", ventaSeguimiento.Monto))
            parametros.Add(New SqlParameter("@pvs_calificacion", ventaSeguimiento.Calificacion))
            parametros.Add(New SqlParameter("@pvs_comentarios", ventaSeguimiento.Comentarios))

            res = base.EjecutarInstruccion("SP_VentasSeguimientos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal ventaSeguimiento As VentaSeguimiento) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pvs_id", ventaSeguimiento.Identificador))

            res = base.EjecutarInstruccion("SP_VentasSeguimientos_Borrar", parametros)

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As VentaSeguimiento
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pvs_id", id))

            reader = base.ConsultarReader("SP_VentasSeguimientos_Consultar", parametros)
            reader.Read()

            Dim ventaSeguimiento As New VentaSeguimiento
            ventaSeguimiento.Identificador = reader(0)

            If Not Lazy Then
                Dim ventaAD = New VentaAD
                ventaSeguimiento.Venta = ventaAD.ConsultarPorId(reader(1))
            End If

            ventaSeguimiento.Estado = reader(2)
            ventaSeguimiento.NumeroFactura = reader(3)
            ventaSeguimiento.Comprobante = reader(4)
            ventaSeguimiento.Monto = reader(5)
            ventaSeguimiento.Calificacion = reader(6)
            ventaSeguimiento.Comentarios = reader(7)
            If Not reader Is Nothing Then reader.Close()

            Return ventaSeguimiento
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As VentaSeguimiento, Optional ByVal Lazy As Boolean = True) As List(Of VentaSeguimiento)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)


            If Not filtros.Venta Is Nothing Then
                parametros.Add(New SqlParameter("@pvs_vent_id", filtros.Venta.Identificador))
            End If

            parametros.Add(New SqlParameter("@pvs_estado_id", filtros.Estado))
            parametros.Add(New SqlParameter("@pvs_nro_fac", filtros.NumeroFactura))
            parametros.Add(New SqlParameter("@pvs_comprobante", filtros.Comprobante))
            parametros.Add(New SqlParameter("@pvs_monto_adeudado", filtros.Monto))
            parametros.Add(New SqlParameter("@pvs_calificacion", filtros.Calificacion))
            parametros.Add(New SqlParameter("@pvs_comentarios", filtros.Comentarios))

            reader = base.ConsultarReader("SP_VentasSeguimientos_ConsultarPor", parametros)

            Dim ventaSeguimientos As New List(Of VentaSeguimiento)
            Do While reader.Read()
                Dim ventaSeguimiento As New VentaSeguimiento
                ventaSeguimiento.Identificador = reader(0)

                If Not Lazy Then
                    Dim ventaAD = New VentaAD
                    ventaSeguimiento.Venta = ventaAD.ConsultarPorId(reader(1))
                End If

                ventaSeguimiento.Estado = reader(2)
                ventaSeguimiento.NumeroFactura = reader(3)
                ventaSeguimiento.Comprobante = reader(4)
                ventaSeguimiento.Monto = reader(5)
                ventaSeguimiento.Calificacion = reader(6)
                ventaSeguimiento.Comentarios = reader(7)

                ventaSeguimientos.Add(ventaSeguimiento)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return ventaSeguimientos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of VentaSeguimiento)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_VentasSeguimientos_ConsultarTodos")

            Dim ventaSeguimientos As New List(Of VentaSeguimiento)
            Do While reader.Read()
                Dim ventaSeguimiento As New VentaSeguimiento
                ventaSeguimiento.Identificador = reader(0)

                If Not Lazy Then
                    Dim ventaAD = New VentaAD
                    ventaSeguimiento.Venta = ventaAD.ConsultarPorId(reader(1))
                End If

                ventaSeguimiento.Estado = reader(2)
                ventaSeguimiento.NumeroFactura = reader(3)
                ventaSeguimiento.Comprobante = reader(4)
                ventaSeguimiento.Monto = reader(5)
                ventaSeguimiento.Calificacion = reader(6)
                ventaSeguimiento.Comentarios = reader(7)

                ventaSeguimientos.Add(ventaSeguimiento)
            Loop

            If Not reader Is Nothing Then reader.Close()
            Return ventaSeguimientos
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


