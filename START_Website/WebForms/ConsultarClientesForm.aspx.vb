Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_ConsultarClientesForm
    Inherits System.Web.UI.Page

#Region "Propiedades y variables privadas"
    Dim bizCliente As New Usuario
    Dim bizClienteLN As New UsuarioLN
#End Region

#Region "Metodos privados"
    Protected Sub Inicializacion()

    End Sub

    Protected Sub EjecutarAccion()
        Try
            grvClientes.DataSource = bizClienteLN.ConsultarPor(ArmarFiltrosBusqueda)
            grvClientes.DataBind()

            Session("dataSource") = grvClientes.DataSource
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

    Private Function ArmarFiltrosBusqueda() As Usuario
        Try
            Dim filtro As New Usuario

            If txtUsuario.Text.Length > 0 Then
                filtro.NickName = txtUsuario.Text
            End If

            If txtNombre.Text.Length > 0 Then
                filtro.Nombre = txtNombre.Text
            End If

            If txtDocumento.Text.Length > 0 Then
                filtro.NroDoc = txtDocumento.Text
            End If

            If txtEmail.Text.Length > 0 Then
                filtro.Email = txtEmail.Text
            End If

            If chkCliente.Checked Then
                filtro.Interno = 0
            End If

            If chkDesarrollador.Checked Then
                filtro.Desarrolla = 1
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

    Protected Sub grvVentas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvClientes.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvClientes.PageIndex = e.NewPageIndex
            grvClientes.DataSource = Session("dataSource")
            grvClientes.DataBind()
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        EjecutarAccion()
    End Sub
#End Region
End Class
