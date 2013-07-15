Imports START_ENTIDADES
Imports START_LN
Imports START_HELPER

Partial Public Class ConsultarEncuestasForm
    Inherits System.Web.UI.Page

#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizEncuesta As New EncuestaSatisfaccion
    Dim bizEncuestaLN As New EncuestaSatisfaccionLN
    Dim bizUsuario As New Usuario
    Dim bizUsuarioln As New UsuarioLN
#End Region

#Region "Metodos privados"
    Protected Sub Inicializacion()

    End Sub

    Protected Sub EjecutarAccion()
        Try

            Dim lstEncuestas As New List(Of EncuestaSatisfaccion)

            grvVentas.DataSource = bizEncuestaLN.ConsultarPor(ArmarFiltrosBusqueda(), False)
            grvVentas.DataBind()

            Session("dataSource") = lstEncuestas
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()
        GC.Collect()
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub LlenarControles()
        Try
           
            Dim colUsuarios As New List(Of Usuario)
            bizUsuario.NickName = "-Todos-"
            bizUsuario.Identificador = New Guid()
            colUsuarios.Add(bizUsuario)
            For Each usu As Usuario In bizUsuarioLN.ConsultarTodos
                colUsuarios.Add(usu)
            Next

            ddlUsuarios.DataSource = colUsuarios
            ddlUsuarios.DataTextField = "Nickname"
            ddlUsuarios.DataValueField = "Identificador"
            ddlUsuarios.DataBind()

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

    Private Function ArmarFiltrosBusqueda() As EncuestaSatisfaccion
        Try

            Dim filtro As New EncuestaSatisfaccion
            If ddlUsuarios.SelectedIndex > 0 Then
                filtro.Usuario = bizUsuarioLN.ConsultarPorId(New Guid(ddlUsuarios.SelectedValue))
            End If
            If txtFecha.Text.Length > 0 Then
                filtro.Fecha = DateHelper.ConvertirStringToDate(txtFecha.Text)
            End If
            If ddlRespuesta.SelectedIndex > -1 Then
                filtro.Pregunta1 = ddlRespuesta.SelectedValue
            Else
                filtro.Pregunta1 = -1
            End If

            Return filtro
        Catch ex As Exception
            MostrarMensaje(ex.Message)
            Return Nothing
        End Try
    End Function
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Inicializacion()
            LlenarControles()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

    End Sub

    Protected Sub grvVentas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvVentas.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvVentas.PageIndex = e.NewPageIndex
            grvVentas.DataSource = Session("dataSource")
            grvVentas.DataBind()
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        EjecutarAccion()
    End Sub

#End Region


    Private Sub grvVentas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvVentas.RowDataBound
        If Not e.Row.Cells Is Nothing And e.Row.Cells.Count > 1 Then


            Select Case e.Row.Cells(2).Text
                Case 1
                    e.Row.Cells(2).Text = "Muy Malo"
                    e.Row.Cells(2).ForeColor = Drawing.Color.Red
                Case 2
                    e.Row.Cells(2).Text = "Malo"
                    e.Row.Cells(2).ForeColor = Drawing.Color.Red
                Case 3
                    e.Row.Cells(2).Text = "Regular"
                    e.Row.Cells(2).ForeColor = Drawing.Color.Gold
                Case 4
                    e.Row.Cells(2).Text = "Muy Bueno"
                    e.Row.Cells(2).ForeColor = Drawing.Color.Green
                Case 5
                    e.Row.Cells(2).Text = "Excelente"
                    e.Row.Cells(2).ForeColor = Drawing.Color.Green
            End Select

            Select Case e.Row.Cells(3).Text
                Case 1
                    e.Row.Cells(3).Text = "Muy Malo"
                    e.Row.Cells(3).ForeColor = Drawing.Color.Red
                Case 2
                    e.Row.Cells(3).Text = "Malo"
                    e.Row.Cells(3).ForeColor = Drawing.Color.Red
                Case 3
                    e.Row.Cells(3).Text = "Regular"
                    e.Row.Cells(3).ForeColor = Drawing.Color.Gold
                Case 4
                    e.Row.Cells(3).Text = "Muy Bueno"
                    e.Row.Cells(3).ForeColor = Drawing.Color.Green
                Case 5
                    e.Row.Cells(3).Text = "Excelente"
                    e.Row.Cells(3).ForeColor = Drawing.Color.Green
            End Select

            Select Case e.Row.Cells(4).Text
                Case 1
                    e.Row.Cells(4).Text = "Muy Malo"
                    e.Row.Cells(4).ForeColor = Drawing.Color.Red
                Case 2
                    e.Row.Cells(4).Text = "Malo"
                    e.Row.Cells(4).ForeColor = Drawing.Color.Red
                Case 3
                    e.Row.Cells(4).Text = "Regular"
                    e.Row.Cells(4).ForeColor = Drawing.Color.Gold
                Case 4
                    e.Row.Cells(4).Text = "Muy Bueno"
                    e.Row.Cells(4).ForeColor = Drawing.Color.Green
                Case 5
                    e.Row.Cells(4).Text = "Excelente"
                    e.Row.Cells(4).ForeColor = Drawing.Color.Green
            End Select

            Select Case e.Row.Cells(5).Text
                Case 1
                    e.Row.Cells(5).Text = "Muy Malo"
                    e.Row.Cells(5).ForeColor = Drawing.Color.Red
                Case 2
                    e.Row.Cells(5).Text = "Malo"
                    e.Row.Cells(5).ForeColor = Drawing.Color.Red
                Case 3
                    e.Row.Cells(5).Text = "Regular"
                    e.Row.Cells(5).ForeColor = Drawing.Color.Gold
                Case 4
                    e.Row.Cells(5).Text = "Muy Bueno"
                    e.Row.Cells(5).ForeColor = Drawing.Color.Green
                Case 5
                    e.Row.Cells(5).Text = "Excelente"
                    e.Row.Cells(5).ForeColor = Drawing.Color.Green
            End Select

            Select Case e.Row.Cells(6).Text
                Case 1
                    e.Row.Cells(6).Text = "Muy Malo"
                    e.Row.Cells(6).ForeColor = Drawing.Color.Red
                Case 2
                    e.Row.Cells(6).Text = "Malo"
                    e.Row.Cells(6).ForeColor = Drawing.Color.Red
                Case 3
                    e.Row.Cells(6).Text = "Regular"
                    e.Row.Cells(6).ForeColor = Drawing.Color.Gold
                Case 4
                    e.Row.Cells(6).Text = "Muy Bueno"
                    e.Row.Cells(6).ForeColor = Drawing.Color.Green
                Case 5
                    e.Row.Cells(6).Text = "Excelente"
                    e.Row.Cells(6).ForeColor = Drawing.Color.Green
            End Select

            Select Case e.Row.Cells(7).Text
                Case 1
                    e.Row.Cells(7).Text = "Muy Malo"
                    e.Row.Cells(7).ForeColor = Drawing.Color.Red
                Case 2
                    e.Row.Cells(7).Text = "Malo"
                    e.Row.Cells(7).ForeColor = Drawing.Color.Red
                Case 3
                    e.Row.Cells(7).Text = "Regular"
                    e.Row.Cells(7).ForeColor = Drawing.Color.Gold
                Case 4
                    e.Row.Cells(7).Text = "Muy Bueno"
                    e.Row.Cells(7).ForeColor = Drawing.Color.Green
                Case 5
                    e.Row.Cells(7).Text = "Excelente"
                    e.Row.Cells(7).ForeColor = Drawing.Color.Green
            End Select
        End If
    End Sub
End Class