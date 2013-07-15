Imports START_LN
Imports START_ENTIDADES
Partial Public Class ConfirmacionRegistroForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Request.QueryString("key") <> "" Then
                Dim key As Guid = New Guid(Request.QueryString("key"))
                Dim registracion As New RegistroEmailLN

                Dim usuario As Usuario = registracion.ConsultarPorId(key)
                usuario.Estado = 1
                Dim usuarioln As New UsuarioLN
                usuarioln.Actualizar(usuario)

                Response.Redirect("Home.aspx")
            End If
        Catch ex As Exception
            cuGeneral.IsValid = False
            cuGeneral.ErrorMessage = "Se produjo un error durante la confirmacións"
        End Try
    End Sub

End Class