Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_ContactoForm
    Inherits System.Web.UI.Page

    Protected Sub EjecutarAccion()

    End Sub

    Protected Sub Finalizacion()

    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()

    End Sub

    Protected Sub LlenarControles()

    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)

    End Sub

    Protected Function ValidarConsistencia() As Boolean

    End Function

    Protected Sub BtnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviar.Click
        Try
            Dim mensaje As New Contacto
            Dim mensajeLN As New ContactoLN
            mensaje.Tipo = ddlTipo.SelectedValue
            mensaje.Mensaje = txtMensaje.Text
            mensaje.Fecha = Today
            Dim logueo As Logueo = Session("Logueo")
            mensaje.Usuario = logueo.Usuario
            mensajeLN.Insertar(mensaje)

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN
            Dim bizTarea As New Tarea
            bizTarea.Nombre = "Nuevo Contacto"
            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = bizSeguimiento.Logueo.Usuario.NickName
            bizSeguimientoLN.Insertar(bizSeguimiento)

         

            txtMensaje.Text = ""
        Catch ex As Exception
            cuGeneral.IsValid = False
            cuGeneral.ErrorMessage = ex.Message
            vsMensajes.Visible = True
        End Try
    End Sub
End Class
