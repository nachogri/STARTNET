Imports START_LN
Imports START_ENTIDADES
Imports START_HELPER

Partial Class WebForms_AltaUsuariosForm
    Inherits System.Web.UI.Page

#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizUsuario As New Usuario
    Dim bizLocalidad As New Localidad
    Dim bizProvincia As New Provincia
    Dim bizPais As New Pais
    Dim bizDomicilio As New Domicilio
    Dim bizUsuarioLN As New UsuarioLN
    Dim bizLocalidadLN As New LocalidadLN
    Dim bizProvinciaLN As New ProvinciaLN
    Dim bizPaisLN As New PaisLN
    Dim bizDomicilioLN As New DomicilioLN
    Dim bizIdiomaLN As New IdiomaLN
    'Dim bizEncriptador As New Encriptador
#End Region

#Region "Metodos privados"
    Protected Sub Inicializacion()
        _Modo = Request.QueryString("Modo")
        ViewState("Modo") = _Modo
        If _Modo = "M" Then
            Dim Logueo As Logueo = Session("Logueo")
            bizUsuario = Logueo.Usuario
            btnAceptar.Text = "Actualizar"
        End If
    End Sub

    Protected Sub EjecutarAccion()
        Try
            Dim resultado As Integer
            Dim bizTarea As New Tarea

            bizUsuario.NickName = txtNickname.Text
            If txtPassword.Text.Length > 0 Then
                bizUsuario.Password = START_HELPER.Encriptador.Encriptar(txtPassword.Text, "E")
            End If

            bizUsuario.Nombre = txtNombre.Text
            bizUsuario.Apellido = txtApellido.Text
            bizUsuario.TipoDoc = ddlDNI.Text
            bizUsuario.NroDoc = txtDocumento.Text
            bizUsuario.FechaNac = DateHelper.ConvertirStringToDate(txtFechaNacimiento.Text)
            bizUsuario.Email = txtEmail.Text
            bizUsuario.Telefono = txtTelefono.Text
            bizUsuario.CUIL = 1
            bizUsuario.CUIT = 1
            bizUsuario.CondicionIVA = Me.ddlVA.SelectedValue


            If ddlIdioma.SelectedValue Is Nothing Then                
                bizUsuario.Idioma = bizIdiomaLN.ConsultarTodos()(1)
            Else
                bizUsuario.Idioma = bizIdiomaLN.ConsultarPorId(New Guid(ddlIdioma.SelectedValue))
            End If


            If _Modo = "A" Then
                bizUsuario.Estado = 0
            Else
                bizUsuario.Estado = 1
            End If

            If chkDesarrollador.Checked Then
                bizUsuario.Desarrolla = 1
            End If
            If chkNewsletter.Checked Then
                bizUsuario.Subscripcion = 1
            End If


            If _Modo = "A" Then
                resultado = bizUsuarioLN.Insertar(bizUsuario)
                bizTarea.Nombre = "Alta Cliente"
            ElseIf _Modo = "M" Then
                resultado = bizUsuarioLN.Actualizar(bizUsuario)
                bizTarea.Nombre = "Actualización de Usuarios"
            End If

            If resultado <> 1 Then
                Throw New Exception("Error al ejecutar la acción")
            End If


            If _Modo = "M" Then
                bizDomicilio.Usuario = bizUsuario
                Dim domicilios As List(Of Domicilio) = bizDomicilioLN.ConsultarPor(bizDomicilio)
                If domicilios.Count = 0 Then
                    bizDomicilio = New Domicilio
                End If
            End If
            bizDomicilio.Calle = txtCalle.Text
            bizDomicilio.Nro = txtNumero.Text
            bizDomicilio.Tipo = ddlDomicilio.SelectedValue
            bizDomicilio.Localidad = bizLocalidadLN.ConsultarPorId(New Guid(ddlLocalidad.SelectedValue))
            bizDomicilio.Usuario = bizUsuario

            If _Modo = "A" Then
                resultado = bizDomicilioLN.Insertar(bizDomicilio)
            ElseIf _Modo = "M" Then
                bizDomicilioLN.Borrar(bizDomicilio)
                resultado = bizDomicilioLN.Insertar(bizDomicilio)
            End If

            If resultado <> 1 Then
                Throw New Exception("Error al ejecutar la acción")
            End If


            If _Modo = "A" Then
                Dim registroEmail As New RegistroEmailLN
                Dim key As Guid = registroEmail.Insertar(bizUsuario)

                Dim helper As New EmailHelper()
                helper.enviarEmail(bizUsuario.Email, "Confirmación de registro a Start.com", "Para confirmar el registro hace click en el siguiente link: " & My.Settings("ConfirmacionPath") & "?key=" & key.ToString())
            Else
                Dim bizSeguimiento As New Seguimiento
                Dim bizSeguimientoLN As New seguimientoLN
                Dim bizTarealn As New TareaLN

                bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
                bizSeguimiento.Logueo = Session("Logueo")
                bizSeguimiento.IdentificadorDeAccion = txtNickname.Text
                bizSeguimientoLN.Insertar(bizSeguimiento)

            End If

            Response.Redirect("Home.aspx")
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()
        bizUsuario = Nothing
        bizLocalidad = Nothing
        bizProvincia = Nothing
        bizPais = Nothing
        bizDomicilio = Nothing
        'bizEncriptador = Nothing
        GC.Collect()
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub LlenarControles()
        Try
            ddlPais.DataSource = bizPaisLN.ConsultarTodos()
            ddlPais.DataTextField = "Nacion"
            ddlPais.DataValueField = "Identificador"
            ddlPais.DataBind()

            ddlIdioma.DataSource = bizIdiomaLN.ConsultarTodos()
            ddlIdioma.DataTextField = "Nombre"
            ddlIdioma.DataValueField = "Identificador"
            ddlIdioma.DataBind()
            ddlIdioma.SelectedIndex = 1

            If _Modo = "A" Then
                RequiredFieldValidator1.Enabled = True
                RequiredFieldValidator2.Enabled = True
            Else
                chkCondiciones.Checked = True

                RequiredFieldValidator2.Enabled = False
                RequiredFieldValidator1.Enabled = False

                txtNickname.Text = bizUsuario.NickName
                If txtPassword.Text.Length > 0 Then
                    txtPassword.Text = bizUsuario.Password 'bizEncriptador.Encriptar(bizUsuario.Password, "D")
                End If

                txtNombre.Text = bizUsuario.Nombre
                txtApellido.Text = bizUsuario.Apellido
                txtPassword.Text = bizUsuario.Password 'bizEncriptador.Encriptar(bizUsuario.Password, "D")
                txtPassword2.Text = bizUsuario.Password 'bizEncriptador.Encriptar(bizUsuario.Password, "D")
                ddlDNI.SelectedValue = bizUsuario.TipoDoc
                txtDocumento.Text = bizUsuario.NroDoc
                txtEmail.Text = bizUsuario.Email
                txtTelefono.Text = bizUsuario.Telefono
                txtFechaNacimiento.Text = bizUsuario.FechaNac
                txtFechaNacimiento_CalendarExtender.SelectedDate = bizUsuario.FechaNac
                txtCUIL.Text = 1
                txtCUIT.Text = 1
                ddlVA.SelectedValue = bizUsuario.CondicionIVA.ToString()

                ddlProvincia.DataSource = bizProvinciaLN.ConsultarTodos
                ddlProvincia.DataTextField = "Nombre"
                ddlProvincia.DataValueField = "Identificador"
                ddlProvincia.DataBind()

                ddlLocalidad.DataSource = bizLocalidadLN.ConsultarTodos
                ddlLocalidad.DataTextField = "Nombre"
                ddlLocalidad.DataValueField = "Identificador"
                ddlLocalidad.DataBind()

                bizDomicilio = New Domicilio
                bizDomicilio.Usuario = bizUsuario
                Dim lstDoms As List(Of Domicilio) = bizDomicilioLN.ConsultarPor(bizDomicilio, False)
                If lstDoms.Count > 0 Then
                    bizDomicilio = lstDoms(0)
                    If Not bizDomicilio Is Nothing Then
                        txtCalle.Text = bizDomicilio.Calle
                        txtNumero.Text = bizDomicilio.Nro
                        ddlDomicilio.SelectedValue = bizDomicilio.Tipo
                        ddlLocalidad.SelectedValue = bizDomicilio.Localidad.Identificador.ToString()
                        ddlLocalidad.SelectedValue = bizDomicilio.Localidad.Provincia.Identificador.ToString()
                    End If
                End If
                
            End If

            txtNickname.Focus()
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
        If txtPassword.Text <> txtPassword2.Text Then
            MostrarMensaje("Las contraseñas ingresadas son diferentes")
            Return False
        End If
        If Not chkCondiciones.Checked Then
            MostrarMensaje("Debe aceptar las condiciones para poder registrarse")
            Return False
        End If
        Return True
    End Function

    Private Sub LimpiarControles()
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtNickname.Text = ""
        txtPassword.Text = ""
        txtPassword2.Text = ""
        txtEmail.Text = ""
        txtDocumento.Text = ""
        txtTelefono.Text = ""
        txtCalle.Text = ""
        txtNumero.Text = ""
    End Sub

#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Usuario") Is Nothing Then
            bizUsuario = Session("Usuario")
            '_Modo = "A"
        End If

        If Not IsPostBack Then
            Inicializacion()
            LlenarControles()
        End If
        _Modo = ViewState("Modo")
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarConsistencia() Then
            EjecutarAccion()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Session("Usuario") = bizUsuario
        ViewState("Modo") = _Modo
    End Sub

    Protected Sub ddlPais_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPais.SelectedIndexChanged, ddlPais.DataBound
        Try
            bizPais = bizPaisLN.ConsultarPorId(New Guid(ddlPais.SelectedValue), False)
            ddlProvincia.DataSource = bizPais.Provincias
            ddlProvincia.DataTextField = "Nombre"
            ddlProvincia.DataValueField = "Identificador"
            ddlProvincia.DataBind()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub ddlProvincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProvincia.SelectedIndexChanged, ddlProvincia.DataBound
        Try
            bizProvincia = bizProvinciaLN.ConsultarPorId(New Guid(ddlProvincia.SelectedValue), False)
            ddlLocalidad.DataSource = bizProvincia.Localidades
            ddlLocalidad.DataTextField = "Nombre"
            ddlLocalidad.DataValueField = "Identificador"
            ddlLocalidad.DataBind()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try

    End Sub

#End Region

End Class

