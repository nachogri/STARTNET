Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_AdminFamiliasForm
    Inherits System.Web.UI.Page

#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizFamilia As New Familia
    Dim bizPatente As New Patente
    Dim bizFamiliaLN As New familiaLN
    Dim bizPatenteLN As New patenteLN
#End Region

#Region "Metodos privados"
    Protected Sub EjecutarAccion()
        Try
            Dim resultado As Integer
            Dim bizTarea As New Tarea

            bizFamilia.Descripcion = txtNombre.Text
            
            If _Modo = "A" Then
                resultado = bizFamiliaLN.Insertar(bizFamilia)
                bizTarea.Nombre = "Alta de Familia"
            ElseIf _Modo = "M" Then
                resultado = bizFamiliaLN.Actualizar(bizFamilia)
                bizTarea.Nombre = "Modificación Familia"
            ElseIf _Modo = "B" Then
                resultado = bizFamiliaLN.Borrar(bizFamilia)
                bizTarea.Nombre = "Baja de Familia"
            End If

            If resultado <> 1 Then
                Throw New Exception("Error al ejecutar la acción")
            End If

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN

            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = txtNombre.Text
            bizSeguimientoLN.Insertar(bizSeguimiento)


            Panel2.Visible = False
            Panel4.Visible = False
            LimpiarControles()
            LlenarControles()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()
        bizFamilia = Nothing
        bizPatente = Nothing
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()


    End Sub

    Protected Sub LlenarControles()
        Try
            grvFamilias.DataSource = bizFamiliaLN.ConsultarTodos()
            grvFamilias.DataBind()

            Session("dataSource") = grvFamilias.DataSource

            lstPatentes.DataSource = bizPatenteLN.ConsultarTodos()
            lstPatentes.DataTextField = "Descripcion"
            lstPatentes.DataValueField = "Identificador"
            lstPatentes.DataBind()

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

    Private Sub LoadFamilia(ByVal pId As Guid)
        Try
            _Modo = "M"

            Panel2.Visible = True
            Panel4.Visible = True

            bizFamilia = bizFamiliaLN.ConsultarPorId(pId, False)

            refrescarPatentes()

            txtNombre.Text = bizFamilia.Descripcion


        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarControles()
        txtNombre.Text = ""
        lstPatentesFinal.Items.Clear()
    End Sub

    Private Sub refrescarPatentes()
        lstPatentesFinal.DataSource = bizFamilia.Patentes
        lstPatentesFinal.DataTextField = "Descripcion"
        lstPatentesFinal.DataBind()
    End Sub

    Private Function ValidarConsistenciaPatente(ByVal pPatenteSeleccionada As Patente) As Boolean
        If Not bizFamilia.Patentes Is Nothing Then
            For Each pat As Patente In bizFamilia.Patentes
                If pat.Identificador = pPatenteSeleccionada.Identificador Then
                    MostrarMensaje("Ya posee esta patente")
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    Private Sub AgregarPatente(ByVal pPatenteSeleccionada As Patente)
        If bizFamilia.Patentes Is Nothing Then
            bizFamilia.Patentes = New List(Of Patente)
        End If
        bizFamilia.Patentes.Add(pPatenteSeleccionada)
        refrescarPatentes()
    End Sub


    Private Sub QuitarPatente(ByVal pPatenteSeleccionada As Patente)
        For Each pat As Patente In bizFamilia.Patentes
            If pat.Descripcion = pPatenteSeleccionada.Descripcion Then
                bizFamilia.Patentes.Remove(pat)
                Exit For
            End If
        Next

        refrescarPatentes()
    End Sub

#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _Modo = ViewState("Modo")
        If Not Session("Familia") Is Nothing Then
            bizFamilia = Session("Familia")
            '_Modo = "A"
        End If

        If Not IsPostBack Then
            Inicializacion()
            Panel2.Visible = False
            Panel4.Visible = False
            LlenarControles()
        End If
    End Sub


    Protected Sub grvFamilias_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvFamilias.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim _hyperLink As HyperLink = e.Row.Controls(0).Controls(3)
            _hyperLink.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            _hyperLink.Attributes("onmouseout") = "this.style.textDecoration='none';"
            _hyperLink.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.grvFamilias, "Select$" & e.Row.RowIndex)
        End If
    End Sub

    Protected Sub grvFamilias_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvFamilias.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvFamilias.PageIndex = e.NewPageIndex
            grvFamilias.DataSource = Session("dataSource")
            grvFamilias.DataBind()
        End If
    End Sub

    Protected Sub grvFamilias_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grvFamilias.SelectedIndexChanged
        LoadFamilia(grvFamilias.SelectedValue)
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarConsistencia() Then
            EjecutarAccion()

            Panel2.Visible = False
            Panel4.Visible = False
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub

    Protected Sub btnAgregarFamiliao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarFamilia.Click
        _Modo = "A"
        bizFamilia = New Familia

        Panel2.Visible = True
        Panel4.Visible = True

        LimpiarControles()
        txtNombre.Focus()
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

    Protected Sub btnQuitarPatente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuitarPatente.Click
        If lstPatentesFinal.SelectedIndex >= 0 Then
            Dim bizPatenteSeleccionada As New Patente
            bizPatenteSeleccionada.Descripcion = lstPatentesFinal.SelectedItem.Text
            bizPatenteSeleccionada = bizPatenteLN.ConsultarPor(bizPatenteSeleccionada)(0)
            QuitarPatente(bizPatenteSeleccionada)
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Session("Familia") = bizFamilia
        ViewState("Modo") = _Modo
    End Sub

    Protected Sub btnEliminarFamilia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarFamilia.Click
        If Not grvFamilias.SelectedValue Is Nothing Then
            _Modo = "B"
            EjecutarAccion()
        Else
            MostrarMensaje("Seleccione una familia a eliminar")
        End If
    End Sub

    'Protected Sub btnEliminarUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarUsuario.Click
    '    If Not grvFamilias.SelectedValue Is Nothing Then
    '        _Modo = "B"
    '        EjecutarAccion()
    '    Else
    '        MostrarMensaje("Seleccione una familia a eliminar")
    '    End If
    'End Sub
#End Region

   
End Class
