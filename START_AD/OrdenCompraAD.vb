
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class OrdenCompraAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef ordenCompra As OrdenCompra) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            ordenCompra.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@poc_id", ordenCompra.Identificador))

            If Not ordenCompra.PagoProveedor Is Nothing Then
                parametros.Add(New SqlParameter("@poc_pagp_id", ordenCompra.PagoProveedor.Identificador))
            End If

            If Not ordenCompra.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@poc_prov_id", ordenCompra.Proveedor.Identificador))
            End If

            parametros.Add(New SqlParameter("@poc_fecha_id", ordenCompra.Fecha))
            parametros.Add(New SqlParameter("@poc_fecha_entrega", ordenCompra.FechaEntrega))
            parametros.Add(New SqlParameter("@poc_monto_total", ordenCompra.MontoTotal))
            parametros.Add(New SqlParameter("@poc_condiciones_pago", ordenCompra.CondicionesPago))
            parametros.Add(New SqlParameter("@poc_comentarios", ordenCompra.Comentarios))

            If Not ordenCompra.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@poc_usu_id", ordenCompra.Usuario.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_OrdenesCompra_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal ordenCompra As OrdenCompra) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@poc_id", ordenCompra.Identificador))

            If Not ordenCompra.PagoProveedor Is Nothing Then
                parametros.Add(New SqlParameter("@poc_pagp_id", ordenCompra.PagoProveedor.Identificador))
            End If

            If Not ordenCompra.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@poc_prov_id", ordenCompra.Proveedor.Identificador))
            End If

            parametros.Add(New SqlParameter("@poc_fecha_id", ordenCompra.Fecha))
            parametros.Add(New SqlParameter("@poc_fecha_entrega", ordenCompra.FechaEntrega))
            parametros.Add(New SqlParameter("@poc_monto_total", ordenCompra.MontoTotal))
            parametros.Add(New SqlParameter("@poc_condiciones_pago", ordenCompra.CondicionesPago))
            parametros.Add(New SqlParameter("@poc_comentarios", ordenCompra.Comentarios))

            If Not ordenCompra.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@poc_usu_id", ordenCompra.Usuario.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_OrdenesCompra_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal ordenCompra As OrdenCompra) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@poc_id", ordenCompra.Identificador))

            res = base.EjecutarInstruccion("SP_OrdenesCompra_Borrar", parametros)

        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As OrdenCompra
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@poc_id", id))

            reader = base.ConsultarReader("SP_OrdenesCompra_Consultar", parametros)
            reader.Read()
            Dim ordenCompra As New OrdenCompra
            ordenCompra.Identificador = reader(0)

            If Not Lazy Then
                Dim pagoProveedor = New PagoProveedorAD
                ordenCompra.PagoProveedor = pagoProveedor.ConsultarPorId(reader(1))

                Dim proveedor = New ProveedorAD
                ordenCompra.Proveedor = proveedor.ConsultarPorId(reader(2))

                Dim usuarioAD = New UsuarioAD
                ordenCompra.Usuario = usuarioAD.ConsultarPorId(reader(8))
            End If

            ordenCompra.Fecha = reader(3)
            ordenCompra.FechaEntrega = reader(4)
            ordenCompra.MontoTotal = reader(5)
            ordenCompra.CondicionesPago = reader(6)
            ordenCompra.Comentarios = reader(7)

            If Not reader Is Nothing Then reader.Close()

            Return ordenCompra
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As OrdenCompra, Optional ByVal Lazy As Boolean = True) As List(Of OrdenCompra)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.PagoProveedor Is Nothing Then
                parametros.Add(New SqlParameter("@poc_pagp_id", filtros.PagoProveedor.Identificador))
            End If

            If Not filtros.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@poc_prov_id", filtros.Proveedor.Identificador))
            End If

            parametros.Add(New SqlParameter("@poc_fecha_id", filtros.Fecha))
            parametros.Add(New SqlParameter("@poc_fecha_entrega", filtros.FechaEntrega))
            parametros.Add(New SqlParameter("@poc_monto_total", filtros.MontoTotal))
            parametros.Add(New SqlParameter("@poc_condiciones_pago", filtros.CondicionesPago))
            parametros.Add(New SqlParameter("@poc_comentarios", filtros.Comentarios))

            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@poc_usu_id", filtros.Usuario.Identificador))
            End If

            reader = base.ConsultarReader("SP_OrdenesCompra_ConsultarPor", parametros)

            Dim ordenCompras As New List(Of OrdenCompra)
            Do While reader.Read()
                Dim ordenCompra As New OrdenCompra
                ordenCompra.Identificador = reader(0)

                If Not Lazy Then
                    Dim pagoProveedor = New PagoProveedorAD
                    ordenCompra.PagoProveedor = pagoProveedor.ConsultarPorId(reader(1))

                    Dim proveedor = New ProveedorAD
                    ordenCompra.Proveedor = proveedor.ConsultarPorId(reader(2))

                    Dim usuarioAD = New UsuarioAD
                    ordenCompra.Usuario = usuarioAD.ConsultarPorId(reader(8))
                End If

                ordenCompra.Fecha = reader(3)
                ordenCompra.FechaEntrega = reader(4)
                ordenCompra.MontoTotal = reader(5)
                ordenCompra.CondicionesPago = reader(6)
                ordenCompra.Comentarios = reader(7)

                ordenCompras.Add(ordenCompra)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return ordenCompras

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of OrdenCompra)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_OrdenesCompra_ConsultarTodos")

            Dim ordenCompras As New List(Of OrdenCompra)
            Do While reader.Read()
                Dim ordenCompra As New OrdenCompra
                ordenCompra.Identificador = reader(0)

                If Not Lazy Then
                    Dim pagoProveedor = New PagoProveedorAD
                    ordenCompra.PagoProveedor = pagoProveedor.ConsultarPorId(reader(1))

                    Dim proveedor = New ProveedorAD
                    ordenCompra.Proveedor = proveedor.ConsultarPorId(reader(2))

                    Dim usuarioAD = New UsuarioAD
                    ordenCompra.Usuario = usuarioAD.ConsultarPorId(reader(8))
                End If

                ordenCompra.Fecha = reader(3)
                ordenCompra.FechaEntrega = reader(4)
                ordenCompra.MontoTotal = reader(5)
                ordenCompra.CondicionesPago = reader(6)
                ordenCompra.Comentarios = reader(7)
                ordenCompras.Add(ordenCompra)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return ordenCompras
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



