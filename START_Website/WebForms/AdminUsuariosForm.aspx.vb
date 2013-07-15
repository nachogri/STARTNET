Imports START_LN
Imports START_ENTIDADES
Imports START_HELPER

Partial Class WebForms_AdminUsuariosForm
    Inherits System.Web.UI.Page

#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizUsuario As New Usuario
    Dim bizFamilia As New Familia
    Dim bizPatente As New Patente
    Dim bizUsuarioLN As New UsuarioLN
    Dim bizFamiliaLN As New familiaLN
    Dim bizPatenteLN As New patenteLN    
    Dim bizIdioma As New Idioma
    Dim bizIdiomaLN As New IdiomaLN
#End Region

#Region "Metodos privados"
    Protected Sub EjecutarAccion()
        Try
            Dim resultado As Integer
            Dim bizTarea As New Tarea


            bizUsuario.Nombre = txtNombre.Text
            bizUsuario.Apellido = txtApellido.Text
            bizUsuario.NickName = txtNickname.Text
            If txtContrasena.Text.Length > 0 Then
                bizUsuario.Password = START_HELPER.Encriptador.Encriptar(txtContrasena.Text, "E")
            End If
            bizUsuario.Email = txtEmail.Text
            bizUsuario.TipoDoc = ddlDocumentoT.SelectedValue
            bizUsuario.NroDoc = txtNroDocumento.Text
            bizUsuario.Telefono = txtTelefono.Text
            bizUsuario.FechaNac = DateHelper.ConvertirStringToDate(txtFechaNacimiento.Text)
            bizUsuario.Idioma = bizIdiomaLN.ConsultarPorId(New Guid(ddlIdioma.SelectedValue))                        
            bizUsuario.Interno = 1
            bizUsuario.Subscripcion = 0
            bizUsuario.Desarrolla = 0
            bizUsuario.Estado = ddlEstado.SelectedValue

            If _Modo = "A" Then
                resultado = bizUsuarioLN.Insertar(bizUsuario)
                bizTarea.Nombre = "Adm usuario"
            ElseIf _Modo = "M" Then
                resultado = bizUsuarioLN.Actualizar(bizUsuario)
                bizTarea.Nombre = "Actualización de Usuarios"
            ElseIf _Modo = "B" Then
                resultado = bizUsuarioLN.Borrar(bizUsuario)
                bizTarea.Nombre = "Baja de usuarios"
            End If

            If resultado <> 1 Then
                Throw New Exception("Error al ejecutar la acción")
            End If


            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN

            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = txtNickname.Text
            bizSeguimientoLN.Insertar(bizSeguimiento)


            Panel1.Visible = False
            Panel2.Visible = False
            Panel4.Visible = False
            LimpiarControles()
            LlenarControles()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()
        bizUsuario = Nothing
        bizFamilia = Nothing
        bizPatente = Nothing
        bizIdioma = Nothing

    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()
        

    End Sub

    Protected Sub LlenarControles()
        Try
            grvUsuarios.DataSource = bizUsuarioLN.ConsultarTodos()
            grvUsuarios.DataBind()

            Session("dataSource") = grvUsuarios

            lstFamilias.DataSource = bizFamiliaLN.ConsultarTodos()
            lstFamilias.DataTextField = "Descripcion"
            lstFamilias.DataValueField = "Identificador"
            lstFamilias.DataBind()

            lstPatentes.DataSource = bizPatenteLN.ConsultarTodos()
            lstPatentes.DataTextField = "Descripcion"
            lstPatentes.DataValueField = "Identificador"
            lstPatentes.DataBind()

            ddlIdioma.DataSource = bizIdiomaLN.ConsultarTodos()
            ddlIdioma.DataTextField = "Nombre"
            ddlIdioma.DataValueField = "Identificador"
            ddlIdioma.DataBind()

            If _Modo = "A" Then
                RequiredFieldValidator1.Enabled = True
                RequiredFieldValidator2.Enabled = True
            Else
                RequiredFieldValidator1.Enabled = False
                RequiredFieldValidator2.Enabled = False
            End If
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
        If txtContrasena.Text <> txtContrasenaR.Text Then
            MostrarMensaje("Las contraseñas ingresadas son diferentes")
            Return False
        End If
        Return True
    End Function

    Private Sub LoadUsuario(ByVal pId As Guid)
        Try
            _Modo = "M"

            Panel1.Visible = True
            Panel2.Visible = True
            Panel4.Visible = True

            bizUsuario = bizUsuarioLN.ConsultarPorId(pId, False)

            refrescarFamilias()
            refrescarPatentes()

            txtNombre.Text = bizUsuario.Nombre
            txtApellido.Text = bizUsuario.Apellido
            txtNickname.Text = bizUsuario.NickName
            txtContrasena.Text = bizUsuario.Password 'bizEncriptador.Encriptar(bizUsuario.Password, "D")
            txtContrasenaR.Text = bizUsuario.Password 'bizEncriptador.Encriptar(bizUsuario.Password, "D")
            txtEmail.Text = bizUsuario.Email
            ddlDocumentoT.SelectedValue = bizUsuario.TipoDoc
            txtNroDocumento.Text = bizUsuario.NroDoc
            txtTelefono.Text = bizUsuario.Telefono
            txtFechaNacimiento.Text = bizUsuario.FechaNac

            txtFechaNacimiento_CalendarExtender.SelectedDate = bizUsuario.FechaNac


            If bizUsuario.Idioma Is Nothing OrElse bizUsuario.Idioma.Nombre = "Español" Then
                ddlIdioma.SelectedIndex = 0
            Else
                ddlIdioma.SelectedIndex = 1
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarControles()
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtNickname.Text = ""
        txtContrasena.Text = ""
        txtContrasenaR.Text = ""
        txtEmail.Text = ""
        ddlDocumentoT.SelectedValue = "DNI"
        txtNroDocumento.Text = ""
        txtTelefono.Text = ""
        txtFechaNacimiento.Text = ""

        lstFamiliasFinal.Items.Clear()
        lstPatentesFinal.Items.Clear()
    End Sub

    Private Function ValidarConsistenciaFamilia(ByVal pFamiliaSeleccionada As Familia) As Boolean
        If Not bizUsuario.Familias Is Nothing Then
            For Each fam As Familia In bizUsuario.Familias
                If fam.Identificador = pFamiliaSeleccionada.Identificador Then
                    MostrarMensaje("Ya posee esta familia")
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Private Sub refrescarFamilias()
        lstFamiliasFinal.DataSource = bizUsuario.Familias
        lstFamiliasFinal.DataTextField = "Descripcion"
        lstFamiliasFinal.DataBind()
    End Sub

    Private Sub refrescarPatentes()
        lstPatentesFinal.DataSource = bizUsuario.Patentes
        lstPatentesFinal.DataTextField = "Descripcion"
        lstPatentesFinal.DataBind()
    End Sub

    Private Sub AgregarFamilia(ByVal pFamiliaSeleccionada As Familia)        
        If bizUsuario.Familias Is Nothing Then
            bizUsuario.Familias = New List(Of Familia)
        End If
        bizUsuario.Familias.Add(pFamiliaSeleccionada)
        refrescarFamilias()
    End Sub

    Private Function ValidarConsistenciaPatente(ByVal pPatenteSeleccionada As Patente) As Boolean
        If Not bizUsuario.Familias Is Nothing Then
            For Each fam As Familia In bizUsuario.Familias
                Dim patLN As New patenteLN
                fam.Patentes = patLN.ConsultarPorFamilia(fam)
                For Each pat As Patente In fam.Patentes
                    If pat.Identificador = pPatenteSeleccionada.Identificador Then
                        MostrarMensaje("Ya posee esta patente")
                        Return False
                    End If
                Next
            Next
        End If

        If Not bizUsuario.Patentes Is Nothing Then
            For Each pat As Patente In bizUsuario.Patentes
                If pat.Identificador = pPatenteSeleccionada.Identificador Then
                    MostrarMensaje("Ya posee esta patente")
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Private Function ValidarAdministracionUsuarios() As Boolean
        Dim EncontroPatente As Boolean = False
        Dim lstUsuarios As New List(Of Usuario)
        lstUsuarios = bizUsuarioLN.ConsultarTodos(False)

        For Each usu As Usuario In lstUsuarios
            If usu.Identificador <> bizUsuario.Identificador Then

                For Each fam As Familia In usu.Familias
                    fam.Patentes = bizPatenteLN.ConsultarPorFamilia(fam)
                    For Each pat As Patente In fam.Patentes
                        If RTrim(pat.Descripcion) = "Administracion de usuarios" Then
                            EncontroPatente = True
                        End If
                    Next
                Next

                For Each pat As Patente In usu.Patentes
                    If RTrim(pat.Descripcion) = "Administracion de usuarios" Then
                        EncontroPatente = True
                    End If
                Next
            End If
        Next

        Return EncontroPatente
    End Function

    Private Sub AgregarPatente(ByVal pPatenteSeleccionada As Patente)
        If bizUsuario.Patentes Is Nothing Then
            bizUsuario.Patentes = New List(Of Patente)
        End If
        bizUsuario.Patentes.Add(pPatenteSeleccionada)
        refrescarPatentes()
    End Sub

    Private Sub QuitarFamilia(ByVal pFamiliaSeleccionada As Familia)
        If RTrim(pFamiliaSeleccionada.Descripcion) = "Usuario de Sistemas" Then
            If Not ValidarAdministracionUsuarios() Then
                MostrarMensaje("No se pudo quitar la patente para evitar aislamiento")
                Exit Sub
            End If
        End If

        For Each fam As Familia In bizUsuario.Familias
            If fam.Descripcion = pFamiliaSeleccionada.Descripcion Then
                bizUsuario.Familias.Remove(fam)
                Exit For
            End If
        Next

        refrescarFamilias()        
    End Sub

    Private Sub QuitarPatente(ByVal pPatenteSeleccionada As Patente)       
        For Each pat As Patente In bizUsuario.Patentes
            If pat.Descripcion = pPatenteSeleccionada.Descripcion Then
                bizUsuario.Patentes.Remove(pat)
                Exit For
            End If
        Next

        refrescarPatentes()
    End Sub

#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _Modo = ViewState("Modo")
        If Not Session("Usuario") Is Nothing Then
            bizUsuario = Session("Usuario")
            '_Modo = "A"
        End If

        If Not IsPostBack Then
            Inicializacion()
            Panel1.Visible = False
            Panel2.Visible = False
            Panel4.Visible = False
            LlenarControles()
        End If
    End Sub


    Protected Sub txtNickname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNickname.TextChanged

    End Sub

    Protected Sub grvUsuarios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvUsuarios.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim _hyperLink As HyperLink = e.Row.Controls(0).Controls(3)
            _hyperLink.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            _hyperLink.Attributes("onmouseout") = "this.style.textDecoration='none';"
            _hyperLink.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.grvUsuarios, "Select$" & e.Row.RowIndex)
        End If
    End Sub

    Protected Sub grvUsuarios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvUsuarios.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvUsuarios.PageIndex = e.NewPageIndex
            grvUsuarios.DataSource = Session("dataSource")
            grvUsuarios.DataBind()
        End If
    End Sub

    Protected Sub grvUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grvUsuarios.SelectedIndexChanged
        LoadUsuario(grvUsuarios.SelectedValue)
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarConsistencia() Then
            EjecutarAccion()
            Panel1.Visible = False
            Panel2.Visible = False
            Panel4.Visible = False
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub

    Protected Sub btnAgregarUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarUsuario.Click
        _Modo = "A"
        bizUsuario = New Usuario

        Panel1.Visible = True
        Panel2.Visible = True
        Panel4.Visible = True

        LimpiarControles()
        txtNickname.Focus()
    End Sub

    Protected Sub btnAgregarFamilia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarFamilia.Click
        Try            
            Dim bizFamiliaSeleccionada As New Familia
            bizFamiliaSeleccionada.Descripcion = lstFamilias.SelectedItem.Text
            bizFamiliaSeleccionada = bizFamiliaLN.ConsultarPor(bizFamiliaSeleccionada, False)(0)
            If ValidarConsistenciaFamilia(bizFamiliaSeleccionada) Then
                AgregarFamilia(bizFamiliaSeleccionada)
            End If
        Catch ex As Exception
            MostrarMensaje("Ocurrio un error con la familia seleccionada")
        End Try
    End Sub

    Protected Sub btnAgregarPatente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarPatente.Click
        Try
            Dim bizPatenteSeleccionada As New Patente
            bizPatenteSeleccionada.Descripcion = lstPatentes.SelectedItem.Text
            bizPatenteSeleccionada = bizPatenteLN.ConsultarPor(bizPatenteSeleccionada, False)(0)
            If ValidarConsistenciaPatente(bizPatenteSeleccionada) Then
                AgregarPatente(bizPatenteSeleccionada)
            End If
        Catch ex As Exception
            MostrarMensaje("Ocurrio un error con la patente seleccionada")
        End Try
    End Sub

    Protected Sub btnQuitarFamilia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuitarFamilia.Click
        If lstFamiliasFinal.SelectedIndex >= 0 Then
            Dim bizFamiliaSeleccionada As New Familia
            bizFamiliaSeleccionada.Descripcion = lstFamiliasFinal.SelectedItem.Text
            bizFamiliaSeleccionada = bizFamiliaLN.ConsultarPor(bizFamiliaSeleccionada)(0)
            QuitarFamilia(bizFamiliaSeleccionada)
        End If
    End Sub

    Protected Sub btnQuitarPatente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuitarPatente.Click
        If lstPatentesFinal.SelectedIndex >= 0 Then
            Dim bizPatenteSeleccionada As New Patente
            bizPatenteSeleccionada.Descripcion = lstPatentesFinal.SelectedItem.Text
            bizPatenteSeleccionada = bizPatenteLN.ConsultarPor(bizPatenteSeleccionada)(0)
            QuitarPatente(bizPatenteSeleccionada)
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Session("Usuario") = bizUsuario
        ViewState("Modo") = _Modo
    End Sub

    Protected Sub btnEliminarUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarUsuario.Click
        If Not grvUsuarios.SelectedValue Is Nothing Then
            _Modo = "B"
            EjecutarAccion()
        Else
            MostrarMensaje("Seleccione un usuario a eliminar")
        End If
    End Sub
#End Region

End Class
