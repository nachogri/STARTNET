Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_NovedadesForm
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

    End Sub

    Protected Sub Finalizacion()
        bizNovedad = Nothing
        GC.Collect()
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub LlenarControles()
        Try
            grvNovedades.DataSource = bizNovedadLN.ConsultarTodos
            Session("dataSource") = grvNovedades.DataSource
            grvNovedades.DataBind()
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
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Inicializacion()
            LlenarControles()
        End If
    End Sub

    Protected Sub grvNovedades_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grvNovedades.RowDataBound

    End Sub

    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub

    Protected Sub grvNovedades_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvNovedades.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvNovedades.PageIndex = e.NewPageIndex
            grvNovedades.DataSource = Session("dataSource")
            grvNovedades.DataBind()
        End If
    End Sub
#End Region
End Class
