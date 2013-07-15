Imports START_HELPER
Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_AdminNovedadesForm
    Inherits System.Web.UI.Page


#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizNovedad As New Novedad    
    Dim bizNovedadLN As New novedadLN        
#End Region

#Region "Metodos privados"
    Protected Sub Inicializacion()

    End Sub

    Protected Sub EjecutarAccion()
        Try
            Dim resultado As Integer
            Dim bizTarea As New Tarea

            bizNovedad.Titulo = txtTitulo.Text.Replace("'", "")
            bizNovedad.Descripcion = txtDecripcion.Text.Replace("'", "")
            bizNovedad.FechaActualizacion = DateHelper.ConvertirStringToDate(txtFecha.Text)


            Dim selectedFile As HttpPostedFile = File1.PostedFile
            Dim imageLength As Integer = selectedFile.ContentLength
            Dim imageType As String = selectedFile.ContentType
            Dim binaryImagedata(imageLength) As Byte
            selectedFile.InputStream.Read(binaryImagedata, 0, imageLength)
            If binaryImagedata.Length > 1 Then
                bizNovedad.Imagen = binaryImagedata
            Else
                bizNovedad.Imagen = Nothing
            End If

            If _Modo = "A" Then
                resultado = bizNovedadLN.Insertar(bizNovedad)
                bizTarea.Nombre = "Alta de Novedades"
            ElseIf _Modo = "M" Then
                resultado = bizNovedadLN.Actualizar(bizNovedad)
                bizTarea.Nombre = "Modificación Novedades"
            ElseIf _Modo = "B" Then
                resultado = bizNovedadLN.Borrar(bizNovedad)
                bizTarea.Nombre = "Modificación Novedades"
            End If

            If resultado <> 1 Then
                Throw New Exception("Error al ejecutar la acción")
            End If

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN

            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = txtTitulo.Text
            bizSeguimientoLN.Insertar(bizSeguimiento)



            Panel2.Visible = False
            LimpiarControles()
            LlenarControles()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()
        bizNovedad = Nothing
        GC.Collect()
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub LlenarControles()
        Try
            grvNovedades.DataSource = bizNovedadLN.ConsultarTodos()
            grvNovedades.DataBind()
            Session("dataSource") = grvNovedades.DataSource

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

    Private Sub LoadNovedad(ByVal pId As Guid)
        Try
            _Modo = "M"

            Panel2.Visible = True

            bizNovedad = bizNovedadLN.ConsultarPorId(pId, False)

            txtTitulo.Text = bizNovedad.Titulo
            txtDecripcion.Text = bizNovedad.Descripcion
            txtFecha.Text = bizNovedad.FechaActualizacion


        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarControles()
        txtTitulo.Text = ""
        txtDecripcion.Text = ""

    End Sub
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _Modo = ViewState("Modo")
        If Not Session("Novedad") Is Nothing Then
            bizNovedad = Session("Novedad")
            '_Modo = "A"
        End If

        If Not IsPostBack Then
            Inicializacion()
            Panel2.Visible = False
            LlenarControles()
        End If
    End Sub

    Protected Sub grvNovedades_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvNovedades.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvNovedades.PageIndex = e.NewPageIndex
            grvNovedades.DataSource = Session("dataSource")
            grvNovedades.DataBind()
        End If
    End Sub

    Protected Sub grvNovedades_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grvNovedades.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim _hyperLink As HyperLink = e.Row.Controls(0).Controls(3)
            _hyperLink.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            _hyperLink.Attributes("onmouseout") = "this.style.textDecoration='none';"
            _hyperLink.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.grvNovedades, "Select$" & e.Row.RowIndex)

            If e.Row.Cells(1).Text.Length > 50 Then
                e.Row.Cells(1).Text = e.Row.Cells(1).Text.Substring(0, 50) & "..."
            End If
        End If
    End Sub

    Protected Sub grvNovedades_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvNovedades.SelectedIndexChanged
        LoadNovedad(grvNovedades.SelectedValue)
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarConsistencia() Then
            EjecutarAccion()
            Panel2.Visible = False

        End If
    End Sub

    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Session("Novedad") = bizNovedad
        ViewState("Modo") = _Modo
    End Sub

    Protected Sub btnEliminarNovedad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarNovedad.Click
        If Not grvNovedades.SelectedValue Is Nothing Then
            _Modo = "B"
            EjecutarAccion()
        Else
            MostrarMensaje("Seleccione un Novedad a eliminar")
        End If
    End Sub

    Protected Sub btnAgregarNovedad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarNovedad.Click
        _Modo = "A"
        bizNovedad = New Novedad

        Panel2.Visible = True

        LimpiarControles()
        txtTitulo.Focus()
    End Sub

#End Region
End Class
