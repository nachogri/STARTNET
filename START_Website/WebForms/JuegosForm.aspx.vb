Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_JuegosForm
    Inherits System.Web.UI.Page

#Region "Propiedades"
    Dim bizProductoln As New ProductoLN
#End Region

#Region "Métodos privados"
    Protected Sub EjecutarAccion()

    End Sub

    Protected Sub Finalizacion()

    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()

    End Sub

    Protected Sub LlenarControles()
        Try
            Dim tipoProducto As New TipoProducto
            Dim tipoProductoln As New TipoProductoLN
            tipoProducto.Descripcion = "Juego"
            Dim producto As New Producto
            producto.TipoProducto = tipoProductoln.ConsultarPor(tipoProducto)(0)
            InventarioUC1.DataSource = bizProductoln.ConsultarPor(producto)
        Catch ex As Exception
            cuGeneral.ErrorMessage = ex.Message
            cuGeneral.IsValid = False
            vsMensajes.Visible = True
        End Try
    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)

    End Sub

    Protected Function ValidarConsistencia() As Boolean

    End Function

#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Inicializacion()
            LlenarControles()
        End If

    End Sub
#End Region
End Class
