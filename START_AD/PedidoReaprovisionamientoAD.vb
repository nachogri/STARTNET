
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class PedidoReaprovisionamientoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pedidoReaprovisionamiento As PedidoReaprovisionamiento) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            pedidoReaprovisionamiento.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ppra_id", pedidoReaprovisionamiento.Identificador))

            If Not pedidoReaprovisionamiento.OrdenCompra Is Nothing Then
                parametros.Add(New SqlParameter("@ppra_prov_id", pedidoReaprovisionamiento.OrdenCompra.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppra_fecha_id", pedidoReaprovisionamiento.Fecha))

            If Not pedidoReaprovisionamiento.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@ppra_usu_id", pedidoReaprovisionamiento.Usuario.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_PedidosReamprovisionamiento_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal pedidoReaprovisionamiento As PedidoReaprovisionamiento) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ppra_id", pedidoReaprovisionamiento.Identificador))

            If Not pedidoReaprovisionamiento.OrdenCompra Is Nothing Then
                parametros.Add(New SqlParameter("@ppra_prov_id", pedidoReaprovisionamiento.OrdenCompra.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppra_fecha_id", pedidoReaprovisionamiento.Fecha))

            If Not pedidoReaprovisionamiento.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@ppra_usu_id", pedidoReaprovisionamiento.Usuario.Identificador))
            End If


            res = base.EjecutarInstruccion("SP_PedidosReamprovisionamiento_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal pedidoReaprovisionamiento As PedidoReaprovisionamiento) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppra_id", pedidoReaprovisionamiento.Identificador))

            res = base.EjecutarInstruccion("SP_PedidosReamprovisionamiento_Borrar", parametros)

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As PedidoReaprovisionamiento
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppra_id", id))

            reader = base.ConsultarReader("SP_PedidosReamprovisionamiento_Consultar", parametros)
            reader.Read()
            Dim pedidoReaprovisionamiento As New PedidoReaprovisionamiento
            pedidoReaprovisionamiento.Identificador = reader(0)

            If Not Lazy Then
                Dim OrdenCompraad = New OrdenCompraAD
                pedidoReaprovisionamiento.OrdenCompra = OrdenCompraad.ConsultarPorId(reader(1))

                Dim usuarioAD = New UsuarioAD
                pedidoReaprovisionamiento.Usuario = usuarioAD.ConsultarPorId(reader(2))
            End If

            pedidoReaprovisionamiento.Fecha = reader(3)

            If Not reader Is Nothing Then reader.Close()

            Return pedidoReaprovisionamiento
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As PedidoReaprovisionamiento, Optional ByVal Lazy As Boolean = True) As List(Of PedidoReaprovisionamiento)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.OrdenCompra Is Nothing Then
                parametros.Add(New SqlParameter("@ppra_prov_id", filtros.OrdenCompra.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppra_fecha_id", filtros.Fecha))

            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@ppra_usu_id", filtros.Usuario.Identificador))
            End If

            reader = base.ConsultarReader("SP_PedidosReamprovisionamiento_ConsultarPor", parametros)

            Dim pedidoReaprovisionamientos As New List(Of PedidoReaprovisionamiento)
            Do While reader.Read()
                Dim pedidoReaprovisionamiento As New PedidoReaprovisionamiento
                pedidoReaprovisionamiento.Identificador = reader(0)

                If Not Lazy Then
                    Dim OrdenCompraad = New OrdenCompraAD
                    pedidoReaprovisionamiento.OrdenCompra = OrdenCompraad.ConsultarPorId(reader(1))

                    Dim usuarioAD = New UsuarioAD
                    pedidoReaprovisionamiento.Usuario = usuarioAD.ConsultarPorId(reader(2))
                End If

                pedidoReaprovisionamiento.Fecha = reader(3)

                pedidoReaprovisionamientos.Add(pedidoReaprovisionamiento)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return pedidoReaprovisionamientos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of PedidoReaprovisionamiento)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_PedidosReamprovisionamiento_ConsultarTodos")

            Dim pedidoReaprovisionamientos As New List(Of PedidoReaprovisionamiento)
            Do While reader.Read()
                Dim pedidoReaprovisionamiento As New PedidoReaprovisionamiento
                pedidoReaprovisionamiento.Identificador = reader(0)

                If Not Lazy Then
                    Dim OrdenCompraad = New OrdenCompraAD
                    pedidoReaprovisionamiento.OrdenCompra = OrdenCompraad.ConsultarPorId(reader(1))

                    Dim usuarioAD = New UsuarioAD
                    pedidoReaprovisionamiento.Usuario = usuarioAD.ConsultarPorId(reader(2))
                End If

                pedidoReaprovisionamiento.Fecha = reader(3)

                pedidoReaprovisionamientos.Add(pedidoReaprovisionamiento)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return pedidoReaprovisionamientos
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




