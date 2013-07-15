Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_DetalleForm
    Inherits System.Web.UI.Page

    Dim _Id As Guid
    Dim tipoForm As String
    Dim titulo As String
    Dim descripcion As String

    Protected Sub EjecutarAccion()

    End Sub

    Protected Sub Finalizacion()

    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()
        tipoForm = Request.QueryString("Table")
        _Id = New Guid(context.Request.QueryString("Id"))
    End Sub

    Protected Sub LlenarControles()
        Try
            Select Case tipoForm
                Case "Novedades"
                    Me.Title = "START.com - Novedades"
                    Dim novedad As New Novedad
                    Dim novedadLN As New novedadLN
                    novedad = novedadLN.ConsultarPorId(_Id)
                    lblTitulo.Text = novedad.Titulo
                    lblDescripcion.Text = novedad.Descripcion
                    Image1.ImageUrl = "~/webForms/hlrImageLoader.ashx?Table=Novedades&Id=" & _Id.ToString()
                Case "Productos"
                    Me.Title = "START.com - Productos"
                    Dim producto As New Producto
                    Dim productoLN As New ProductoLN
                    producto = productoLN.ConsultarPorId(_Id)
                    lblTitulo.Text = producto.Nombre
                    lblDescripcion.Text = producto.Especificaciones
                    Image1.ImageUrl = "~/webForms/hlrImageLoader.ashx?Table=Productos&Id=" & _Id.ToString()
                Case Else
            End Select

        Catch ex As Exception
            cuGeneral.IsValid = False
            cuGeneral.ErrorMessage = ex.Message
            vsMensajes.Visible = True
        End Try
    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)

    End Sub

    Protected Function ValidarConsistencia() As Boolean

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Inicializacion()
            LlenarControles()
        End If
    End Sub
End Class
