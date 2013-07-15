Imports START_LN
Imports START_ENTIDADES
Imports START_HELPER

Partial Class WebForms_AdminMensajesForm
    Inherits System.Web.UI.Page

#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizMensaje As New Contacto
    Dim bizMensajeLN As New ContactoLN
#End Region

#Region "Metodos privados"
    Protected Sub Inicializacion()

    End Sub

    Protected Sub EjecutarAccion()
        Try
            Dim resultado As Integer

            bizMensaje.Respuesta = txtRespuesta.Text

            resultado = bizMensajeLN.Actualizar(bizMensaje)

            Dim helper As New emailhelper
            helper.enviarEmail(bizMensaje.Usuario.Email, "Respuesta a su mensaje", bizMensaje.Respuesta)


            If resultado <> 1 Then
                Throw New Exception("Error al ejecutar la acción")
            End If

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN
            Dim bizTarea As New Tarea
            bizTarea.Nombre = "Adm de Mensajes"
            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = bizSeguimiento.Logueo.Usuario.NickName
            bizSeguimientoLN.Insertar(bizSeguimiento)

            LlenarControles()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()
        bizMensaje = Nothing
        GC.Collect()
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub LlenarControles()
        Try
            grvMensajes.DataSource = bizMensajeLN.ConsultarTodos()
            grvMensajes.DataBind()
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

    Private Sub LoadMensaje(ByVal pId As Guid)
        Try
            _Modo = "M"

            Panel1.Visible = True

            bizMensaje = bizMensajeLN.ConsultarPorId(pId, False)

            txtUsuario.Text = bizMensaje.Usuario.NickName
            txtTipo.Text = bizMensaje.Tipo
            txtMensaje.Text = bizMensaje.Mensaje
            txtFecha.Text = bizMensaje.Fecha

        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarControles()
        txtUsuario.Text = ""
        txtMensaje.Text = ""
        txtFecha.Text = ""

    End Sub
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _Modo = ViewState("Modo")
        If Not Session("Mensaje") Is Nothing Then
            bizMensaje = Session("Mensaje")
            '_Modo = "A"
        End If

        If Not IsPostBack Then
            Inicializacion()

            Panel1.Visible = False

            LlenarControles()
        End If
    End Sub

    Protected Sub grvUsuarios_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grvMensajes.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim _hyperLink As HyperLink = e.Row.Controls(0).Controls(3)
            _hyperLink.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            _hyperLink.Attributes("onmouseout") = "this.style.textDecoration='none';"
            _hyperLink.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.grvMensajes, "Select$" & e.Row.RowIndex)

            If e.Row.Cells(1).Text.Length > 50 Then
                e.Row.Cells(1).Text = e.Row.Cells(1).Text.Substring(0, 50) & "..."
            End If
        End If
    End Sub

    Protected Sub grvUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvMensajes.SelectedIndexChanged
        LoadMensaje(grvMensajes.SelectedValue)
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarConsistencia() Then
            EjecutarAccion()
            Panel1.Visible = False
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Session("Mensaje") = bizMensaje
        ViewState("Modo") = _Modo
    End Sub

#End Region
End Class
