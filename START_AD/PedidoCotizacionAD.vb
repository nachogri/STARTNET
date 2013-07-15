Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class PedidoCotizacionAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pedidoCotizacion As PedidoCotizacion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            pedidoCotizacion.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ppc_id", pedidoCotizacion.Identificador))

            If Not pedidoCotizacion.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@ppc_prov_id", pedidoCotizacion.Proveedor.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppc_fecha_id", pedidoCotizacion.Fecha))
            parametros.Add(New SqlParameter("@ppc_comentarios", pedidoCotizacion.Comentarios))

            If Not pedidoCotizacion.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@ppc_usu_id", pedidoCotizacion.Usuario.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_PedidosCotizacion_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal pedidoCotizacion As PedidoCotizacion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ppc_id", pedidoCotizacion.Identificador))

            If Not pedidoCotizacion.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@ppc_prov_id", pedidoCotizacion.Proveedor.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppc_fecha_id", pedidoCotizacion.Fecha))
            parametros.Add(New SqlParameter("@ppc_comentarios", pedidoCotizacion.Comentarios))

            If Not pedidoCotizacion.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@ppc_usu_id", pedidoCotizacion.Usuario.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_PedidosCotizacion_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal pedidoCotizacion As PedidoCotizacion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppc_id", pedidoCotizacion.Identificador))

            res = base.EjecutarInstruccion("SP_PedidosCotizacion_Borrar", parametros)

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As PedidoCotizacion
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppc_id", id))

            reader = base.ConsultarReader("SP_PedidosCotizacion_Consultar", parametros)
            reader.Read()

            Dim pedidoCotizacion As New PedidoCotizacion
            pedidoCotizacion.Identificador = reader(0)

            If Not Lazy Then
                Dim proveedor = New ProveedorAD
                pedidoCotizacion.Proveedor = proveedor.ConsultarPorId(reader(1))

                Dim usuarioAD = New UsuarioAD
                pedidoCotizacion.Usuario = usuarioAD.ConsultarPorId(reader(4))
            End If

            pedidoCotizacion.Fecha = reader(2)
            pedidoCotizacion.Comentarios = reader(3)

            If Not reader Is Nothing Then reader.Close()

            Return pedidoCotizacion
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As PedidoCotizacion, Optional ByVal Lazy As Boolean = True) As List(Of PedidoCotizacion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@ppc_prov_id", filtros.Proveedor.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppc_fecha_id", filtros.Fecha))
            parametros.Add(New SqlParameter("@ppc_comentarios", filtros.Comentarios))

            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@ppc_usu_id", filtros.Usuario.Identificador))
            End If

            reader = base.ConsultarReader("SP_PedidosCotizacion_ConsultarPor", parametros)

            Dim pedidoCotizacions As New List(Of PedidoCotizacion)
            Do While reader.Read()
                Dim pedidoCotizacion As New PedidoCotizacion
                pedidoCotizacion.Identificador = reader(0)

                If Not Lazy Then
                    Dim proveedor = New ProveedorAD
                    pedidoCotizacion.Proveedor = proveedor.ConsultarPorId(reader(1))

                    Dim usuarioAD = New UsuarioAD
                    pedidoCotizacion.Usuario = usuarioAD.ConsultarPorId(reader(4))
                End If

                pedidoCotizacion.Fecha = reader(2)
                pedidoCotizacion.Comentarios = reader(3)

                pedidoCotizacions.Add(pedidoCotizacion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return pedidoCotizacions

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of PedidoCotizacion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_PedidosCotizacion_ConsultarTodos")

            Dim pedidoCotizacions As New List(Of PedidoCotizacion)
            Do While reader.Read()
                Dim pedidoCotizacion As New PedidoCotizacion
                pedidoCotizacion.Identificador = reader(0)

                If Not Lazy Then
                    Dim proveedor = New ProveedorAD
                    pedidoCotizacion.Proveedor = proveedor.ConsultarPorId(reader(1))

                    Dim usuarioAD = New UsuarioAD
                    pedidoCotizacion.Usuario = usuarioAD.ConsultarPorId(reader(4))
                End If

                pedidoCotizacion.Fecha = reader(2)
                pedidoCotizacion.Comentarios = reader(3)

                pedidoCotizacions.Add(pedidoCotizacion)
            Loop

            If Not reader Is Nothing Then reader.Close()
            Return pedidoCotizacions
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



