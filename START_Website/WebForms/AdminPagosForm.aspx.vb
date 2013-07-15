Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_AdminPagosForm
    Inherits System.Web.UI.Page

    Dim bizSeguimiento As New VentaSeguimiento
    Dim bizVenta As New Venta
    Dim bizSeguimientoLN As New VentaSeguimientoLN
    Dim bizVentaLN As New VentaLN
    Dim resultado As Integer
    Dim _Modo As String

#Region "Metodos privados"
    Protected Sub EjecutarAccion()
        Try
            Dim bizTarea As New Tarea


            bizSeguimiento.NumeroFactura = txtFactura.Text
            bizSeguimiento.Comprobante = txtComprobante.Text            
            bizSeguimiento.Estado = Convert.ToInt32(EstadoVenta.Pagada)
            bizSeguimiento.Calificacion = ddlCalificacion.SelectedValue
            bizSeguimiento.Comentarios = txtComentarios.Text
            Dim bizTipoPagoLN As New TipoPagoLN
            bizSeguimiento.Venta.TipoPago = bizTipoPagoLN.ConsultarPorId(New Guid(ddlTipoPago.SelectedValue))

            If _Modo = "A" Then
                resultado = bizSeguimientoLN.Insertar(bizSeguimiento)
                bizTarea.Nombre = "Administración Pagos"
            Else
                resultado = bizSeguimientoLN.Actualizar(bizSeguimiento)
            End If

            If resultado <> 1 Then
                Throw New Exception("Error al ejecutar la acción")
            End If


            Dim bizbSeguimiento As New Seguimiento
            Dim bizbSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN

            bizbSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizbSeguimiento.Logueo = Session("Logueo")
            bizbSeguimiento.IdentificadorDeAccion = txtComprobante.Text
            bizSeguimientoLN.Insertar(bizSeguimiento)


            LlenarControles()

        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()

    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()

    End Sub

    Protected Sub LlenarControles()
        Try

            grvSeguimientos.DataSource = bizSeguimientoLN.ConsultarTodos()
            grvSeguimientos.DataBind()
            Session("dataSource") = grvSeguimientos.DataSource

            CargarTipoPagos()

            'Panel1.Visible = False
            grvSeguimientos.Visible = True
            btnAgregarSeguimiento.Visible = True
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub CargarTipoPagos()
        Try
            Dim bizTipoPagoLN As New TipoPagoLN
            ddlTipoPago.DataSource = bizTipoPagoLN.ConsultarTodos()
            ddlTipoPago.DataTextField = "Descripcion"
            ddlTipoPago.DataValueField = "Identificador"
            ddlTipoPago.DataBind()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub
    Protected Sub MostrarMensaje(ByVal pMensaje As String)
        cuGeneral.IsValid = False
        cuGeneral.ErrorMessage = pMensaje
        vsMensajes.Visible = True
    End Sub

    Private Sub LimpiarControles()
        txtVentaAsociada.Text = ""
        txtFactura.Text = ""
        txtComprobante.Text = ""
        ddlCalificacion.SelectedIndex = -1
        txtComentarios.Text = ""
    End Sub

    Private Sub LoadPago(ByVal id As Guid)
        Try
            _Modo = "M"
            Panel1.Visible = True

            bizSeguimiento = bizSeguimientoLN.ConsultarPorId(id, False)
            txtVentaAsociada.Text = bizSeguimiento.Venta.Identificador.ToString()
            txtFactura.Text = bizSeguimiento.NumeroFactura
            txtComprobante.Text = bizSeguimiento.Comprobante
            ddlCalificacion.SelectedValue = bizSeguimiento.Calificacion
            txtComentarios.Text = bizSeguimiento.Comentarios

        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Function ValidarConsistencia() As Boolean

    End Function
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            _Modo = ViewState("Modo")

            If Not Session("Seguimiento") Is Nothing Then
                bizSeguimiento = Session("Seguimiento")
                '_Modo = "A"
            End If

            If Not IsPostBack Then
                If Not Request.QueryString("ventaId") Is Nothing Then
                    _Modo = "A"

                    grvSeguimientos.Visible = False
                    btnAgregarSeguimiento.Visible = False
                    Panel1.Visible = True
                    LimpiarControles()
                    CargarTipoPagos()
                    txtVentaAsociada.Focus()

                    bizSeguimiento = New VentaSeguimiento
                    bizSeguimiento.Venta = bizVentaLN.ConsultarPorId(New Guid(Request.QueryString("ventaId")), False)
                    Dim lstSeguimientos As List(Of VentaSeguimiento) = bizSeguimientoLN.ConsultarPor(bizSeguimiento)
                    If lstSeguimientos.Count > 0 Then
                        LoadPago(lstSeguimientos(0).Identificador)
                    End If

                    txtVentaAsociada.Text = bizSeguimiento.Venta.Identificador.ToString()

                    Inicializacion()
                    LlenarControles()
                End If
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        EjecutarAccion()
    End Sub

    Protected Sub grvReparaciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvSeguimientos.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim _hyperLink As HyperLink = e.Row.Controls(0).Controls(3)
            _hyperLink.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            _hyperLink.Attributes("onmouseout") = "this.style.textDecoration='none';"
            _hyperLink.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.grvSeguimientos, "Select$" & e.Row.RowIndex)

            If e.Row.Cells(1).Text.Length > 50 Then
                e.Row.Cells(1).Text = e.Row.Cells(1).Text.Substring(0, 50) & "..."
            End If
        End If
    End Sub

    Protected Sub grvSeguimientos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvSeguimientos.SelectedIndexChanged
        LoadPago(grvSeguimientos.SelectedValue)
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Session("Seguimiento") = bizSeguimiento
        ViewState("Modo") = _Modo
    End Sub

    Protected Sub btnAgregarSeguimiento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarSeguimiento.Click

    End Sub

    Protected Sub grvSeguimientos_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvSeguimientos.PageIndexChanged

    End Sub


#End Region
End Class
