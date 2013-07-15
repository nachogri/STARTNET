
Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class PagoProveedorAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef pagoProveedor As PagoProveedor) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            pagoProveedor.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppagp_id", pagoProveedor.Identificador))

            If Not pagoProveedor.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@ppagp_prov_id", pagoProveedor.Proveedor.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppagp_fecha", pagoProveedor.Fecha))
            parametros.Add(New SqlParameter("@ppagp_monto", pagoProveedor.Monto))
            parametros.Add(New SqlParameter("@ppagp_nro_factura", pagoProveedor.NumeroFactura))
            parametros.Add(New SqlParameter("@ppagp_nro_comentarios", pagoProveedor.Comentarios))
            parametros.Add(New SqlParameter("@ppagp_comprobante", pagoProveedor.Comprobante))

            If Not pagoProveedor.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@ppagp_usuario_id", pagoProveedor.Usuario.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_PagoProveedores_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal pagoProveedor As PagoProveedor) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ppagp_id", pagoProveedor.Identificador))

            If Not pagoProveedor.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@ppagp_prov_id", pagoProveedor.Proveedor.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppagp_fecha", pagoProveedor.Fecha))
            parametros.Add(New SqlParameter("@ppagp_monto", pagoProveedor.Monto))
            parametros.Add(New SqlParameter("@ppagp_nro_factura", pagoProveedor.NumeroFactura))
            parametros.Add(New SqlParameter("@ppagp_nro_comentarios", pagoProveedor.Comentarios))
            parametros.Add(New SqlParameter("@ppagp_comprobante", pagoProveedor.Comprobante))

            If Not pagoProveedor.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@ppagp_usuario_id", pagoProveedor.Usuario.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_PagoProveedores_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal pagoProveedor As PagoProveedor) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppagp_id", pagoProveedor.Identificador))

            res = base.EjecutarInstruccion("SP_PagoProveedores_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As PagoProveedor
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppagp_id", id))

            reader = base.ConsultarReader("SP_PagoProveedores_Consultar", parametros)
            reader.Read()
            Dim pagoProveedor As New PagoProveedor
            pagoProveedor.Identificador = reader(0)
            pagoProveedor.Fecha = reader(2)
            pagoProveedor.Monto = reader(3)
            pagoProveedor.NumeroFactura = reader(4)
            pagoProveedor.Comentarios = reader(5)
            pagoProveedor.Comprobante = reader(6)

            If Not Lazy Then
                Dim proveedorAD = New ProveedorAD
                pagoProveedor.Proveedor = proveedorAD.ConsultarPorId(reader(1))

                Dim usuarioAD = New UsuarioAD
                pagoProveedor.Usuario = usuarioAD.ConsultarPorId(reader(7))
            End If

            If Not reader Is Nothing Then reader.Close()

            Return pagoProveedor
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As PagoProveedor, Optional ByVal Lazy As Boolean = True) As List(Of PagoProveedor)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.Proveedor Is Nothing Then
                parametros.Add(New SqlParameter("@ppagp_prov_id", filtros.Proveedor.Identificador))
            End If

            parametros.Add(New SqlParameter("@ppagp_fecha", filtros.Fecha))
            parametros.Add(New SqlParameter("@ppagp_monto", filtros.Monto))
            parametros.Add(New SqlParameter("@ppagp_nro_factura", filtros.NumeroFactura))
            parametros.Add(New SqlParameter("@ppagp_nro_comentarios", filtros.Comentarios))
            parametros.Add(New SqlParameter("@ppagp_comprobante", filtros.Comprobante))

            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@ppagp_usuario_id", filtros.Usuario.Identificador))
            End If

            reader = base.ConsultarReader("SP_PagoProveedores_ConsultarPor", parametros)

            Dim pagoProveedors As New List(Of PagoProveedor)
            Do While reader.Read()
                Dim pagoProveedor As New PagoProveedor
                pagoProveedor.Identificador = reader(0)
                pagoProveedor.Fecha = reader(2)
                pagoProveedor.Monto = reader(3)
                pagoProveedor.NumeroFactura = reader(4)
                pagoProveedor.Comentarios = reader(5)
                pagoProveedor.Comprobante = reader(6)

                If Not Lazy Then
                    Dim proveedorAD = New ProveedorAD
                    pagoProveedor.Proveedor = proveedorAD.ConsultarPorId(reader(1))

                    Dim usuarioAD = New UsuarioAD
                    pagoProveedor.Usuario = usuarioAD.ConsultarPorId(reader(7))
                End If

                pagoProveedors.Add(pagoProveedor)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return pagoProveedors

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of PagoProveedor)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_PagoProveedores_ConsultarTodos")

            Dim pagoProveedors As New List(Of PagoProveedor)
            Do While reader.Read()
                Dim pagoProveedor As New PagoProveedor
                pagoProveedor.Identificador = reader(0)
                pagoProveedor.Fecha = reader(2)
                pagoProveedor.Monto = reader(3)
                pagoProveedor.NumeroFactura = reader(4)
                pagoProveedor.Comentarios = reader(5)
                pagoProveedor.Comprobante = reader(6)

                If Not Lazy Then
                    Dim proveedorAD = New ProveedorAD
                    pagoProveedor.Proveedor = proveedorAD.ConsultarPorId(reader(1))

                    Dim usuarioAD = New UsuarioAD
                    pagoProveedor.Usuario = usuarioAD.ConsultarPorId(reader(7))
                End If

                pagoProveedors.Add(pagoProveedor)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return pagoProveedors
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
