Imports START_LN
Imports START_ENTIDADES
Imports START_HELPER

Partial Class WebForms_AdminReparacionesForm
    Inherits System.Web.UI.Page
    Dim bizReparacion As New Reparacion
    Dim bizUsuario As New Usuario
    Dim bizReparacionLN As New ReparacionLN
    Dim bizUsuarioLN As New UsuarioLN
    Dim resultado As Integer
    Dim _Modo As String

#Region "Metodos privados"
    Protected Sub EjecutarAccion()
        Try
            bizReparacion.Usuario = bizUsuarioLN.ConsultarPorNickname(txtUsuario.Text)
            bizReparacion.FechaRecepcion = DateHelper.ConvertirStringToDate(txtFechaRecepcion.Text)
            bizReparacion.FechaDevolucion = DateHelper.ConvertirStringToDate(txtFechaDevolucion.Text)
            bizReparacion.Estado = Convert.ToInt32(ddlEstado.SelectedValue)
            bizReparacion.ImporteTotal = txtMonto.Text
            Dim bizTipoPago As New TipoPagoLN
            bizReparacion.TipoPago = bizTipoPago.ConsultarPorId(New Guid(ddlTipoPago.SelectedValue))

            If _Modo = "A" Then
                resultado = bizReparacionLN.Insertar(bizReparacion)
            ElseIf _Modo = "M" Then
                resultado = bizReparacionLN.Actualizar(bizReparacion)
            End If

            If resultado <> 1 Then
                Throw New Exception("Error al ejecutar la acción")
            End If

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN
            Dim bizTarea As New Tarea
            bizTarea.Nombre = "Administración de Reparaciones"
            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = txtUsuario.Text
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
        grvReparaciones.DataSource = bizReparacionLN.ConsultarTodos()
        grvReparaciones.DataBind()
        Session("dataSource") = grvReparaciones.DataSource

        Dim bizTipoPago As New TipoPagoLN
        ddlTipoPago.DataSource = bizTipoPago.ConsultarTodos()
        ddlTipoPago.DataTextField = "Descripcion"
        ddlTipoPago.DataValueField = "Identificador"
        ddlTipoPago.DataBind()

    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)
        cuGeneral.IsValid = False
        cuGeneral.ErrorMessage = pMensaje
        vsMensajes.Visible = True
    End Sub

    Private Sub LimpiarControles()
        txtUsuario.Text = ""
        txtMonto.Text = ""
        txtFechaRecepcion.Text = ""
        txtFechaDevolucion.Text = ""

    End Sub

    Private Sub LoadReparacion(ByVal id As Guid)
        Try
            _Modo = "M"
            Panel1.Visible = True

            bizReparacion = bizReparacionLN.ConsultarPorId(id, False)
            txtUsuario.Text = bizReparacion.Usuario.NickName
            txtMonto.Text = bizReparacion.ImporteTotal
            txtFechaRecepcion.Text = bizReparacion.FechaRecepcion.ToShortDateString()
            txtFechaDevolucion.Text = bizReparacion.FechaDevolucion.ToShortDateString()
            ddlEstado.SelectedValue = bizReparacion.Estado

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
            If Not Session("Reparacion") Is Nothing Then
                bizReparacion = Session("Reparacion")
                '_Modo = "A"
            End If

            If Not IsPostBack Then
                Inicializacion()
                Panel1.Visible = False
                LlenarControles()
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        EjecutarAccion()
    End Sub

    Protected Sub grvReparaciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvReparaciones.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim _hyperLink As HyperLink = e.Row.Controls(0).Controls(3)
            _hyperLink.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            _hyperLink.Attributes("onmouseout") = "this.style.textDecoration='none';"
            _hyperLink.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.grvReparaciones, "Select$" & e.Row.RowIndex)

            If e.Row.Cells(1).Text.Length > 50 Then
                e.Row.Cells(1).Text = e.Row.Cells(1).Text.Substring(0, 50) & "..."
            End If
        End If
    End Sub
    Protected Sub btnAgregarNovedad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarNovedad.Click
        _Modo = "A"
        bizReparacion = New Reparacion

        Panel1.Visible = True

        LimpiarControles()
        txtUsuario.Focus()
    End Sub

    Protected Sub grvReparaciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvReparaciones.SelectedIndexChanged
        LoadReparacion(grvReparaciones.SelectedValue)
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Session("Reparacion") = bizReparacion
        ViewState("Modo") = _Modo
    End Sub

#End Region

End Class
