Imports START_ENTIDADES
Imports START_LN

Partial Public Class WebForms_Main
    Inherits System.Web.UI.MasterPage

#Region "Propiedades y variables privadas"
    Dim bizLogueo As Logueo
    Dim bizLogueoLN As New LogueoLN
    Dim bizUsuario As Usuario
    Dim bizUsuarioLN As New UsuarioLN
    Dim bizUsuarioAnterior As Usuario
    Dim bizUsuarioAnteriorLN As New UsuarioLN
    Dim _logueado As Boolean
#End Region

#Region "Metodos privados"
    Protected Sub Inicializacion()

    End Sub

    Protected Sub EjecutarAccion()
        Try           
            bizLogueo = New Logueo
            bizLogueo.Usuario = bizUsuario
            bizLogueo.HoraIn = Now.ToShortTimeString
            bizLogueo.Fecha = Today
            bizLogueoLN.Insertar(bizLogueo)

            Session("Logueo") = bizLogueo

            _logueado = True

            smpMenuVertical.Enabled = True
            pnlLogIn.Visible = False
            pnlWelcome.Visible = True
            lblUsuario.Text = bizUsuario.Nombre

            If bizUsuario.Familias.Count > 0 Then
                lblFamilia.Text = bizUsuario.Familias(0).Descripcion
            Else
                lblFamilia.Text = "Usuario externo"
            End If

            ProcesarHabilitaciones()



        Catch ex As Exception
            MostrarMensaje("Ocurrió un error durante el logueo")
        End Try
    End Sub

    Protected Sub Finalizacion()
        bizUsuario = Nothing
        bizLogueo = Nothing
        bizUsuarioLN = Nothing
        bizLogueoLN = Nothing
        GC.Collect()
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub LlenarControles()

    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)
        cuGeneral.IsValid = False
        cuGeneral.Visible = True
        cuGeneral.Text = pMensaje
    End Sub

    Protected Function ValidarConsistencia() As Boolean
        If txtNickname.Text.Trim.Length = 0 Then
            MostrarMensaje("Ingrese un usuario")
            Return False
        End If
        If txtContrasena.Text.Trim.Length = 0 OrElse txtContrasena.Text.Trim.Length > 8 Then
            MostrarMensaje("Ingrese una contraseña válida")
            Return False
        End If
        Return True
    End Function

    Private Function ValidarIntegridad() As Boolean
        Try
            bizUsuario = New Usuario
            bizUsuarioLN = New UsuarioLN

            bizUsuario = bizUsuarioLN.ConsultarPorNickname(txtNickname.Text, False)

            If bizUsuario.Nombre Is Nothing Then
                MostrarMensaje("El usuario o contraseña son invàlidos")
                Return False
            End If

            If bizUsuario.Password.Trim <> START_HELPER.Encriptador.Encriptar(txtContrasena.Text, "E") Then
                MostrarMensaje("El usuario o contraseña son invàlidos")
                Return False
            End If

            If bizUsuario.Estado <> 1 Then
                MostrarMensaje("El usuario no se há confirmado aún")
                Return False
            End If

            Return True
        Catch ex As Exception
            MostrarMensaje(ex.Message)
            Return False
        End Try
    End Function

    Private Sub LogIn()
        If ValidarIntegridad() = True Then
            cuGeneral.ErrorMessage = ""
            EjecutarAccion()

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN
            Dim bizTarea As New Tarea

            bizTarea.Nombre = "Logueo"
            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = txtNickname.Text
            bizSeguimientoLN.Insertar(bizSeguimiento)
        End If
    End Sub

    Private Sub LogOut()
        Try
            Dim resultado As Byte
            Dim bizLogueo As Logueo = Session("Logueo")

            bizLogueo.HoraOut = Now.ToShortTimeString
            resultado = bizLogueoLN.Actualizar(bizLogueo)

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN
            Dim bizTarea As New Tarea

            bizTarea.Nombre = "DesLogueo"
            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = txtNickname.Text
            bizSeguimientoLN.Insertar(bizSeguimiento)

            Session("Logueo") = Nothing
            Session.Clear()

            pnlLogIn.Visible = True
            pnlWelcome.Visible = False
            lblUsuario.Text = ""
            DeshabilitarMenu()

            _logueado = False

            Response.Redirect("Home.aspx")
        Catch ex As Exception
            MostrarMensaje("Se produjo un error al terminar la sesión")
        End Try
    End Sub

    Private Sub DeshabilitarMenu()
        smpMenuVertical.Enabled = False
        menuSTART.Items(5).Enabled = False
        menuSTART.Items(6).Enabled = False
        menuSTART.Items(7).Enabled = False
        DeshabilitarItemsMenu(menuSTART.Items(7).ChildItems)
        menuSTART.Items(8).Enabled = False
        DeshabilitarItemsMenu(menuSTART.Items(8).ChildItems)
    End Sub

    Private Sub DeshabilitarItemsMenu(ByVal items As MenuItemCollection)
        For Each item As MenuItem In items
            item.Enabled = False
            If item.ChildItems.Count > 0 Then
                DeshabilitarItemsMenu(item.ChildItems)
            End If
        Next
    End Sub

    Private Sub ProcesarHabilitaciones()
        Try
            For Each pat As Patente In bizLogueo.Usuario.Patentes
                For Each hab As Habilitacion In pat.Habilitaciones
                    HabilitarItemMenu(hab.Objeto, menuSTART.Items)
                Next
            Next
            For Each fam As Familia In bizLogueo.Usuario.Familias
                For Each pat As Patente In fam.Patentes
                    For Each hab As Habilitacion In pat.Habilitaciones
                        HabilitarItemMenu(hab.Objeto, menuSTART.Items)
                    Next
                Next
            Next

            menuSTART.Items(5).Enabled = True
            menuSTART.Items(6).Enabled = True
            menuSTART.Items(7).Enabled = True

        Catch ex As Exception
            MostrarMensaje("Ocurrió un error")
        End Try
    End Sub

    Private Sub HabilitarItemMenu(ByVal value As String, ByVal items As MenuItemCollection)
        For Each item As MenuItem In items
            If item.Value = value Then
                If Not item.Parent Is Nothing Then
                    item.Parent.Enabled = True
                End If
                item.Enabled = True
                Exit Sub
            End If
            If item.ChildItems.Count > 0 Then
                HabilitarItemMenu(value, item.ChildItems)
            End If
        Next
    End Sub
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            DeshabilitarMenu()
            Inicializacion()
            If Not Session("Logueo") Is Nothing Then
                bizLogueo = Session("Logueo")
                pnlLogIn.Visible = False
                pnlWelcome.Visible = True
                If Not bizLogueo.Usuario Is Nothing Then
                    lblUsuario.Text = bizLogueo.Usuario.Nombre
                End If
                If Not bizLogueo.Usuario.Familias Is Nothing And bizLogueo.Usuario.Familias.Count > 0 Then
                    lblFamilia.Text = bizLogueo.Usuario.Familias(0).Descripcion
                End If
                ProcesarHabilitaciones()
            End If
        End If
    End Sub

    Protected Sub lbLogIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLogIn.Click
        LogIn()
    End Sub

    Protected Sub lbLogOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLogOut.Click
        LogOut()
    End Sub
#End Region

End Class