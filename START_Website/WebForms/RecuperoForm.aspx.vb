Imports START_ENTIDADES
Imports START_LN
Imports START_HELPER

Partial Public Class RecuperoForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEnviar.Click
        Dim usuarioLn As New UsuarioLN
        Dim usuario As Usuario = usuarioLn.ConsultarPorNickname(TextBox1.Text)
        Dim helper As New EmailHelper
        helper.enviarEmail(usuario.Email, "Recupero de contraseña - Start.com", "Usuario:" & usuario.NickName & " - Contraseña:" & START_HELPER.Encriptador.Encriptar(usuario.Password, "D"))

        Response.Redirect("Home.aspx")


    End Sub
End Class