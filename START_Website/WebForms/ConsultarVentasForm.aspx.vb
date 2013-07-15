Imports START_LN
Imports START_ENTIDADES
Imports START_HELPER

Partial Class WebForms_ConsultarVentasForm
    Inherits System.Web.UI.Page

#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizVenta As New Venta
    Dim bizVentaLN As New VentaLN
    Dim bizLogueo As New Logueo
    Dim bizUsuario As New Usuario
    Dim bizUsuarioLN As New UsuarioLN
    Dim bizProducto As New Producto
    Dim bizProductoLN As New ProductoLN
    Dim bizTipoPagoLN As New TipoPagoLN
#End Region

#Region "Metodos privados"
    Protected Sub Inicializacion()

    End Sub

    Protected Sub EjecutarAccion()
        Try
            bizLogueo = Session("Logueo")

            Dim dtVentas As New System.Data.DataTable
            dtVentas.Columns.Add("Fecha")
            dtVentas.Columns.Add("Usuario")
            dtVentas.Columns.Add("Productos")
            dtVentas.Columns.Add("Cantidad")
            dtVentas.Columns.Add("Importe")
            dtVentas.Columns.Add("Identificador")


            Dim total As Double
            For Each venta As Venta In bizVentaLN.ConsultarPor(ArmarFiltrosBusqueda(), False)
                Dim dr As DataRow = dtVentas.NewRow
                dr(0) = venta.Fecha.ToShortDateString
                dr(1) = venta.Usuario.NickName
                If Not venta.Productos Is Nothing Then
                    For Each bizVentaProducto As VentaProducto In venta.Productos
                        dr(2) &= bizVentaProducto.Producto.Nombre & ", "
                    Next
                    dr(2).ToString.Substring(0, dr(2).ToString.TrimEnd.Length - 1)
                    dr(3) = venta.Productos.Count
                End If
                dr(4) = venta.Importe
                dr(5) = venta.Identificador
                dtVentas.Rows.Add(dr)

                total += venta.Importe
            Next
            grvVentas.DataSource = dtVentas
            grvVentas.DataBind()

            Session("dataSource") = dtVentas
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()
        GC.Collect()
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub LlenarControles()
        Try
            Dim colUsuarios As New List(Of Usuario)
            bizUsuario.NickName = "-Todos-"
            bizUsuario.Identificador = New Guid()
            colUsuarios.Add(bizUsuario)
            For Each usu As Usuario In bizUsuarioLN.ConsultarTodos
                colUsuarios.Add(usu)
            Next

            ddlUsuarios.DataSource = colUsuarios
            ddlUsuarios.DataTextField = "Nickname"
            ddlUsuarios.DataValueField = "Identificador"
            ddlUsuarios.DataBind()

            Dim colProducto As New List(Of Producto)
            bizProducto.Nombre = "-Todos-"
            bizProducto.Identificador = New Guid()
            colProducto.Add(bizProducto)
            For Each prod As Producto In bizProductoLN.ConsultarTodos
                colProducto.Add(prod)
            Next

            ddlProductos.DataSource = colProducto
            ddlProductos.DataTextField = "Nombre"
            ddlProductos.DataValueField = "Identificador"
            ddlProductos.DataBind()


            ddlTipoPago.DataSource = bizTipoPagoLN.ConsultarTodos
            ddlTipoPago.DataTextField = "Descripcion"
            ddlTipoPago.DataValueField = "Identificador"
            ddlTipoPago.DataBind()
            Dim item As New ListItem
            item.Text = "- Todos -"
            item.Value = 0
            ddlTipoPago.Items.Insert(0, item)

        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)
        cuGeneral.IsValid = False
        cuGeneral.ErrorMessage = pMensaje
        vsMensajes.Visible = True
    End Sub

    Protected Function ValidarConsistencia() As Boolean

        Return True
    End Function

    Private Function ArmarFiltrosBusqueda() As Venta
        Try

            Dim filtro As New Venta
            If ddlUsuarios.SelectedIndex > 0 Then
                filtro.Usuario = bizUsuarioLN.ConsultarPorId(New Guid(ddlUsuarios.SelectedValue))
            End If
            If txtFecha.Text.Length > 0 Then
                filtro.Fecha = DateHelper.ConvertirStringToDate(txtFecha.Text)
            End If

            If ddlProductos.SelectedIndex > 0 Then
                filtro.Productos = New List(Of VentaProducto)
                Dim ventaProducto As New VentaProducto
                ventaProducto.Producto = bizProductoLN.ConsultarPorId(New Guid(ddlProductos.SelectedValue))
                filtro.Productos.Add(ventaProducto)
            End If
            If txtMonto.Text.Length > 0 Then
                filtro.ImporteTotal = txtMonto.Text
            End If
            If ddlTipoPago.SelectedIndex > 0 Then
                filtro.TipoPago = bizTipoPagoLN.ConsultarPorId(New Guid(ddlTipoPago.SelectedValue))
            End If

            Return filtro
        Catch ex As Exception
            MostrarMensaje(ex.Message)
            Return Nothing
        End Try
    End Function
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Inicializacion()
            LlenarControles()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

    End Sub

    Protected Sub grvVentas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvVentas.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvVentas.PageIndex = e.NewPageIndex
            grvVentas.DataSource = Session("dataSource")
            grvVentas.DataBind()
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        EjecutarAccion()
    End Sub

#End Region
End Class
