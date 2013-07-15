Imports START_ENTIDADES
Imports START_LN

Partial Public Class AdministracionParametrosForm
    Inherits System.Web.UI.Page
#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizLocalidad As New Localidad
    Dim bizProvincia As New Provincia
    Dim bizPais As New Pais
    Dim bizLocalidadLN As New LocalidadLN
    Dim bizProvinciaLN As New ProvinciaLN
    Dim bizPaisLN As New PaisLN
#End Region

#Region "Metodos privados"
    Protected Sub Inicializacion()

    End Sub

    Protected Sub EjecutarAccion()
        Try

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
            lstPaises.DataSource = bizPaisLN.ConsultarTodos()
            lstPaises.DataTextField = "Nacion"
            lstPaises.DataValueField = "Identificador"
            lstPaises.DataBind()

            ddlPaises.DataSource = bizPaisLN.ConsultarTodos()
            ddlPaises.DataTextField = "Nacion"
            ddlPaises.DataValueField = "Identificador"
            ddlPaises.DataBind()

            lstProvincias.DataSource = bizProvinciaLN.ConsultarTodos
            lstProvincias.DataTextField = "Nombre"
            lstProvincias.DataValueField = "Identificador"
            lstProvincias.DataBind()

            ddProvincias.DataSource = bizProvinciaLN.ConsultarTodos
            ddProvincias.DataTextField = "Nombre"
            ddProvincias.DataValueField = "Identificador"
            ddProvincias.DataBind()

            lstLocalidades.DataSource = bizLocalidadLN.ConsultarTodos
            lstLocalidades.DataTextField = "Nombre"
            lstLocalidades.DataValueField = "Identificador"
            lstLocalidades.DataBind()

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

    Private Sub AgregarPais()
        bizPais.Nacion = txtPais.Text
        bizPaisLN.Insertar(bizPais)
        LlenarControles()
    End Sub

    Private Sub AgregarProvincia()
        bizProvincia.Nombre = txtProvincia.Text        
        bizProvincia.Pais = bizPaisLN.ConsultarPorId(New Guid(ddlPaises.SelectedValue))
        bizProvinciaLN.Insertar(bizProvincia)
        LlenarControles()
    End Sub

    Private Sub AgregarLocalidad()
        bizLocalidad.Nombre = txtLocalidad.Text
        bizLocalidad.CP = txtCP.Text
        bizLocalidad.Provincia = bizProvinciaLN.ConsultarPorId(New Guid(ddProvincias.SelectedValue))
        bizLocalidadLN.Insertar(bizLocalidad)
        LlenarControles()
    End Sub
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Inicializacion()
            LlenarControles()
        End If
        _Modo = ViewState("Modo")
    End Sub


    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub


    Protected Sub btnAgregarPais_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregarPais.Click
        AgregarPais()
    End Sub

    Protected Sub btnAgregarPaises_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregarPaises.Click
        AgregarProvincia()
    End Sub

    Protected Sub btnAgregarLocalidades_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregarLocalidades.Click
        AgregarLocalidad()
    End Sub
#End Region

End Class