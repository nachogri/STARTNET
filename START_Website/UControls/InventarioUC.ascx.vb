Imports START_ENTIDADES

Partial Class WebForms_UControls_InventarioUC
    Inherits System.Web.UI.UserControl

#Region "Propiedades"
    Public UsuarioLogueado As Boolean
    Dim source As New List(Of Producto)
    Public Property DataSource() As List(Of Producto)
        Get
            Return source
        End Get
        Set(ByVal value As List(Of Producto))
            source = value
        End Set
    End Property

#End Region

#Region "Métodos privados"
    Private Sub FillGrid()
        Me.grvInventario.DataSource = source
        Session("datasource") = source
        Me.grvInventario.DataBind()

    End Sub
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Logueo") Is Nothing Then
            UsuarioLogueado = False
        Else
            UsuarioLogueado = True
        End If
        If Not IsPostBack Then
            FillGrid()
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvInventario.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvInventario.PageIndex = e.NewPageIndex
            grvInventario.DataSource = Session("datasource")
            grvInventario.DataBind()
        End If
    End Sub

    Protected Sub grvInventario_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvInventario.RowDataBound

    End Sub
#End Region



End Class
