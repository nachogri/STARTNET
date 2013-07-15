Imports START_LN
Imports START_ENTIDADES
Imports System.Data

Partial Class WebForms_VentaForm
    Inherits System.Web.UI.Page

#Region "Propiedades y objetos internos"
    Dim bizVenta As Venta
    Dim dtVenta As Data.DataTable
#End Region

#Region "Metodos privados"
    Protected Sub EjecutarAccion()
        Try
            Dim bizVenta As New Venta
            Dim bizVentaLN As New VentaLN
            Dim _Logueo As Logueo = Session("Logueo")
            Dim bizTarea As New Tarea

            bizVenta.Fecha = Today
            bizVenta.Importe = lblTotal.Text
            bizVenta.LugarEntrega = txtDomicilio.Text

            bizVenta.Usuario = _Logueo.Usuario
            bizVenta.ImporteTotal = lblTotal.Text
            bizVenta.Promocion = Nothing
            bizVenta.PlazoEntrega = "10 días"

            Dim tipoPagoLN As New TipoPagoLN            
            bizVenta.TipoPago = tipoPagoLN.ConsultarPorId(New Guid(ddlTipoPago.SelectedValue))

            bizVenta.IVA = ddlIVA.SelectedValue

            bizVenta.Productos = New List(Of VentaProducto)
            For Each dr As DataRow In dtVenta.Rows
                Dim bizVentaProd As New VentaProducto
                Dim bizproducto As New Producto
                Dim bizproductoLN As New ProductoLN
                bizVentaProd.Producto = bizproductoLN.ConsultarPorId(New Guid(dr(4).ToString()))
                bizVentaProd.Cantidad = dr(1)
                bizVenta.Productos.Add(bizVentaProd)
            Next

            Dim resultado As Integer
            resultado = bizVentaLN.Insertar(bizVenta)

            If resultado <> 1 Then
                Throw New Exception("Error al ejecutar la acción")
            Else
                For Each dr As DataRow In dtVenta.Rows
                    Dim bizproducto As New Producto
                    Dim bizproductoLN As New ProductoLN
                    bizproducto = bizproductoLN.ConsultarPorId(New Guid(dr(4).ToString()), False)
                    bizproducto.Cantidad -= dr(1)
                    bizproductoLN.Actualizar(bizproducto)
                Next
            End If

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN

            bizTarea.Nombre = "Confirmación de venta"
            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = _Logueo.Usuario.NickName
            bizSeguimientoLN.Insertar(bizSeguimiento)

            Response.Redirect("ReciboForm.aspx?Dom=" & bizVenta.LugarEntrega, True)

        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()
        Session("Venta") = dtVenta
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()
        If Not Session("Venta") Is Nothing Then
            dtVenta = Session("Venta")
        Else
            dtVenta = New DataTable
            Dim dtCol1 As New DataColumn("Producto")
            Dim dtCol2 As New DataColumn("Cantidad")
            Dim dtCol3 As New DataColumn("Precio")
            Dim dtCol4 As New DataColumn("PrecioFinal")
            Dim dtCol5 As New DataColumn("IdProducto")
            Dim dtCol6 As New DataColumn("Tipo")
            dtVenta.Columns.Add(dtCol1)
            dtVenta.Columns.Add(dtCol2)
            dtVenta.Columns.Add(dtCol3)
            dtVenta.Columns.Add(dtCol4)
            dtVenta.Columns.Add(dtCol5)
            dtVenta.Columns.Add(dtCol6)

            btnRecalcular.Visible = False
            btnCheckOut.Enabled = False
        End If
    End Sub

    Protected Sub LlenarControles()
        Try
            If Request.QueryString("IdProducto") <> "" Then
                Dim idProducto As Guid = New Guid(Request.QueryString("IdProducto"))
                If idProducto <> Nothing Then
                    Dim bizProducto As New Producto
                    Dim bizProductoLN As New ProductoLN
                    bizProducto = bizProductoLN.ConsultarPorId(idProducto, False)

                    Dim drProdVenta As DataRow = dtVenta.NewRow
                    drProdVenta(0) = bizProducto.Nombre
                    drProdVenta(1) = 1
                    drProdVenta(2) = bizProducto.Precio
                    drProdVenta(3) = bizProducto.Precio
                    drProdVenta(4) = bizProducto.Identificador
                    drProdVenta(5) = bizProducto.TipoProducto.Descripcion
                    dtVenta.Rows.Add(drProdVenta)
                End If
            End If

            Dim tipoPagoLN As New TipoPagoLN
            ddlTipoPago.DataSource = tipoPagoLN.ConsultarTodos()
            ddlTipoPago.DataTextField = "Descripcion"
            ddlTipoPago.DataValueField = "Identificador"
            ddlTipoPago.DataBind()

            Dim bizDomicilio As New Domicilio
            Dim bizDomicilioLN As New DomicilioLN

            Dim _Logueo As Logueo = Session("Logueo")
            bizDomicilio.Usuario = _Logueo.Usuario
            bizDomicilio = bizDomicilioLN.ConsultarPor(bizDomicilio, False)(0)
            txtDomicilio.Text = "Calle: " & bizDomicilio.Calle & " - Altura: " & bizDomicilio.Nro & " - Localidad: " & bizDomicilio.Localidad.Nombre & " (" & bizDomicilio.Tipo & ")"

            
            grvVenta.DataSource = dtVenta
            grvVenta.DataBind()

            lblPromocion.Text = 0
            Recalcular()


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
        If dtVenta Is Nothing Then
            dtVenta = Session("Venta")
        End If
        For Each dr As DataRow In dtVenta.Rows
            Dim bizProducto As New Producto
            Dim bizProductoLN As New ProductoLN
            bizProducto = bizProductoLN.ConsultarPorId(New Guid(dr(4).ToString()))
            If bizProducto.Cantidad < Convert.ToInt32((1)) Then
                MostrarMensaje("Lamentablemente no hay suficiente stock para el producto:" & dr(0))
                Return False
            End If
        Next
        If Convert.ToInt32(lblTotal.Text) > 50000 Then
            MostrarMensaje("Este pedido supera el monto máximo permitido. Para realizar esta compra por favor comuniquese telefónicamente.")
            Return False
        End If
        If grvVenta.Rows.Count < 1 Then
            MostrarMensaje("Debe tener un producto en su carrito al menos.")
            Return False
        End If
        Return True
    End Function

    Private Sub Recalcular()
        Try
            Dim subTotal As Integer
            If dtVenta Is Nothing Then
                dtVenta = Session("Venta")
            End If
            For Each dr As Data.DataRow In dtVenta.Rows
                Dim ddlCantidad As DropDownList = grvVenta.Rows(dtVenta.Rows.IndexOf(dr)).Cells(2).Controls(1)
                dr(1) = ddlCantidad.SelectedValue
                dr(3) = ddlCantidad.SelectedValue * dr(2)
                subTotal += dr(3)
            Next
            lblSubtotal.Text = subTotal
            If lblPromocion.Text.Length > 0 AndAlso Convert.ToInt32(lblPromocion.Text) > 0 Then
                lblTotal.Text = subTotal + (subTotal * (Convert.ToInt32(lblPromocion.Text) / 100))
            Else
                lblTotal.Text = subTotal
            End If

            grvVenta.DataSource = dtVenta
            grvVenta.DataBind()

            btnRecalcular.Visible = True
            btnCheckOut.Enabled = True
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub QuitarItem(ByVal item As Integer)
        Try
            If dtVenta Is Nothing Then
                dtVenta = Session("Venta")
            End If
            dtVenta.Rows.RemoveAt(item)

            Recalcular()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Inicializacion()
            LlenarControles()
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Session("Venta") = dtVenta
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Finalizacion()
    End Sub

    Protected Sub btnRecalcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecalcular.Click
        Recalcular()
    End Sub

    Protected Sub grvProductos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvVenta.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim _hyperLink As HyperLink = e.Row.Controls(0).Controls(1)
            _hyperLink.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            _hyperLink.Attributes("onmouseout") = "this.style.textDecoration='none';"
            _hyperLink.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.grvVenta, "Select$" & e.Row.RowIndex)

            Dim ddlCantidad As DropDownList = e.Row.Cells(2).Controls(1)
            ddlCantidad.SelectedValue = dtVenta.Rows(e.Row.DataItemIndex)(1)
        End If
    End Sub

    Protected Sub grvVenta_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles grvVenta.SelectedIndexChanging
        QuitarItem(e.NewSelectedIndex)
        e.NewSelectedIndex = -1
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckOut.Click
        Try
            If ValidarConsistencia() Then
                EjecutarAccion()
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub
#End Region

End Class
