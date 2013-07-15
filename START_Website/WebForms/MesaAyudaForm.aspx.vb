Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_MesaAyudaForm
    Inherits System.Web.UI.Page


#Region "Propiedades"
    Dim bizMeza As New MesaAyuda
    Dim bizMezaLN As New MesaAyudaLN
#End Region

#Region "Métodos privados"
    Protected Sub EjecutarAccion()
        Try
            If RadioButtonList1.Items(0).Selected Then
                refrescarPregunta(bizMeza.PreguntaSI)
            Else
                refrescarPregunta(bizMeza.PreguntaNO)
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()

    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()
        bizMeza = New MesaAyuda
    End Sub

    Protected Sub LlenarControles()
        Try
            refrescarPregunta(1)
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)
        cuGeneral.ErrorMessage = pMensaje
        cuGeneral.IsValid = False
        vsMensajes.Visible = True
    End Sub

    Protected Function ValidarConsistencia() As Boolean

    End Function

    Private Sub refrescarPregunta(ByVal Id As Integer)
        Try
            If Id = 99 Then
                lblPregunta.Text = bizMeza.Resolucion.Solucion
                btnSiguiente.Visible = False
                pnlRespuestas.Visible = False
            Else
                bizMeza = bizMezaLN.ConsultarPorId(Id)
                lblPregunta.Text = bizMeza.Pregunta
                Session("Mesa") = bizMeza
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            bizMeza = Session("Mesa")

            If Not IsPostBack Then
                Inicializacion()
                LlenarControles()


                If Not Session("Logueo") Is Nothing Then
                    Dim bizSeguimiento As New Seguimiento
                    Dim bizSeguimientoLN As New seguimientoLN
                    Dim bizTarealn As New TareaLN
                    Dim bizTarea As New Tarea
                    bizTarea.Nombre = "Mesa de Ayuda"
                    bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
                    bizSeguimiento.Logueo = Session("Logueo")
                    bizSeguimiento.IdentificadorDeAccion = bizSeguimiento.Logueo.Usuario.NickName
                    bizSeguimientoLN.Insertar(bizSeguimiento)
                End If

            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub


    Protected Sub btnSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        EjecutarAccion()      
    End Sub
#End Region
End Class
