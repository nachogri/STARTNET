Imports START_ENTIDADES
Imports START_LN

Partial Public Class EncuestaForm
    Inherits System.Web.UI.Page

#Region "Propiedades y objetos internos"
    Dim bizVenta As Venta
    Dim dtVenta As Data.DataTable
#End Region

#Region "Metodos privados"
    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()
       
    End Sub

    Protected Sub LlenarControles()
      
    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)
        cuGeneral.IsValid = False
        cuGeneral.ErrorMessage = pMensaje
        vsMensajes.Visible = True
    End Sub


#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Inicializacion()
            LlenarControles()
        End If
    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEnviar.Click
        Try
            Dim encuesta As New EncuestaSatisfaccion
            Dim encuestaLN As New EncuestaSatisfaccionLN

            Dim _Logueo As Logueo = Session("Logueo")
            encuesta.Usuario = _Logueo.Usuario
            encuesta.Fecha = Now()
            encuesta.Pregunta1 = rblExperiencia.SelectedValue
            encuesta.Pregunta2 = rblCatalogo.SelectedValue
            encuesta.Pregunta3 = rblCarrito.SelectedValue
            encuesta.Pregunta4 = rblMesaAyuda.SelectedValue
            encuesta.Pregunta5 = rblContacto.SelectedValue
            encuesta.Pregunta6 = rblComunidad.SelectedValue

            encuestaLN.Insertar(encuesta)
            Response.Redirect("Home.aspx")
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub
#End Region

   
End Class