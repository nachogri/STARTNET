Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_InventarioForm
    Inherits System.Web.UI.Page


#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizProducto As New Producto
    Dim bizTipoProducto As New TipoProducto
    Dim bizProductoLN As New ProductoLN
    Dim bizTipoProductoLN As New TipoProductoLN
    Dim bizMonedaLN As New MonedaLN
#End Region

#Region "Metodos privados"
    Protected Sub Inicializacion()
     
    End Sub

    Protected Sub EjecutarAccion()
        Try
            Dim resultado As Integer
            Dim bizTarea As New Tarea

            bizProducto.Nombre = txtNombre.Text.Replace("'", "")
            bizProducto.Descripcion = txtDescripcion.Text.Replace("'", "")
            bizProducto.Precio = txtPrecio.Text            
            bizProducto.Cantidad = txtCantidad.Text
            bizProducto.PMR = txtPMR.Text
            bizProducto.Dimension = txtDimension.Text
            bizProducto.Fabricante = txtFabricante.Text
            bizProducto.Nacionalidad = txtNacionalidad.Text
            bizProducto.Especificaciones = txtEspecificaciones.Text.Replace("'", "")

            Dim tipoProducto As New TipoProducto
            tipoProducto.Descripcion = ddlTipoProducto.SelectedValue
            bizProducto.TipoProducto = bizTipoProductoLN.ConsultarPor(tipoProducto)(0)

            bizProducto.Moneda = bizMonedaLN.ConsultarPorId(ddlMoneda.SelectedValue)
            bizProducto.Garantia = ddlGarantia.SelectedValue

            Dim selectedFile As HttpPostedFile = File1.PostedFile
            Dim imageLength As Integer = selectedFile.ContentLength
            Dim imageType As String = selectedFile.ContentType
            Dim binaryImagedata(imageLength) As Byte
            selectedFile.InputStream.Read(binaryImagedata, 0, imageLength)
            If binaryImagedata.Length > 1 Then
                bizProducto.Imagen = binaryImagedata
            Else
                bizProducto.Imagen = Nothing
            End If

            If _Modo = "A" Then
                resultado = bizProductoLN.Insertar(bizProducto)
                bizTarea.Nombre = "Administración Stock Alta"
            ElseIf _Modo = "M" Then
                resultado = bizProductoLN.Actualizar(bizProducto)
                bizTarea.Nombre = "Administración Stock Modificación"
            ElseIf _Modo = "B" Then
                resultado = bizProductoLN.Borrar(bizProducto)
                bizTarea.Nombre = "Administración Stock Baja"
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

            Panel1.Visible = False
            LimpiarControles()
            LlenarControles()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()
        bizProducto = Nothing
        bizTipoProducto = Nothing
        GC.Collect()
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub LlenarControles()
        Try
            grvInventario.DataSource = bizProductoLN.ConsultarTodos()
            grvInventario.DataBind()
            Session("dataSource") = grvInventario.DataSource

            ddlTipoProducto.DataSource = bizTipoProductoLN.ConsultarTodos()
            ddlTipoProducto.DataTextField = "Descripcion"
            ddlTipoProducto.DataValueField = "Descripcion"
            ddlTipoProducto.DataBind()

            ddlMoneda.DataSource = bizMonedaLN.ConsultarTodos()
            ddlMoneda.DataTextField = "Nombre"
            ddlMoneda.DataValueField = "Identificador"
            ddlMoneda.DataBind()

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

    Private Sub LoadProducto(ByVal pId As Guid)
        Try
            _Modo = "M"

            Panel1.Visible = True

            bizProducto = bizProductoLN.ConsultarPorId(pId, False)

            txtNombre.Text = bizProducto.Nombre
            txtDescripcion.Text = bizProducto.Descripcion
            txtPrecio.Text = bizProducto.Precio
            txtCantidad.Text = bizProducto.Cantidad
            txtPMR.Text = bizProducto.PMR
            txtNacionalidad.Text = bizProducto.Nacionalidad
            txtDimension.Text = bizProducto.Dimension
            txtFabricante.Text = bizProducto.Fabricante
            txtEspecificaciones.Text = bizProducto.Especificaciones
            If Not bizProducto.TipoProducto Is Nothing Then
                ddlTipoProducto.SelectedValue = bizProducto.TipoProducto.Descripcion
            End If
            ddlMoneda.SelectedValue = bizProducto.Moneda.Identificador
            ddlGarantia.SelectedValue = bizProducto.Garantia

        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarControles()
        txtNombre.Text = ""
        txtDescripcion.Text = ""
        txtPrecio.Text = ""      
        txtCantidad.Text = ""
        txtPMR.Text = ""
        txtDimension.Text = ""
        txtFabricante.Text = ""
        txtEspecificaciones.Text = ""
        ddlTipoProducto.SelectedIndex = -1
        ddlMoneda.SelectedIndex = -1
        ddlGarantia.SelectedIndex = -1
    End Sub
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _Modo = ViewState("Modo")
        If Not Session("Producto") Is Nothing Then
            bizProducto = Session("Producto")
            '_Modo = "A"
        End If

        If Not IsPostBack Then
            Inicializacion()
            Panel1.Visible = False
            LlenarControles()
        End If
    End Sub

    Protected Sub grvInventario_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvInventario.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvInventario.PageIndex = e.NewPageIndex
            grvInventario.DataSource = Session("dataSource")
            grvInventario.DataBind()
        End If
    End Sub

    Protected Sub grvInventario_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grvInventario.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim _hyperLink As HyperLink = e.Row.Controls(0).Controls(3)
            _hyperLink.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            _hyperLink.Attributes("onmouseout") = "this.style.textDecoration='none';"
            _hyperLink.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.grvInventario, "Select$" & e.Row.RowIndex)

            If e.Row.Cells(1).Text.Length > 50 Then
                e.Row.Cells(1).Text = e.Row.Cells(1).Text.Substring(0, 50) & "..."
            End If
        End If
    End Sub

    Protected Sub grvInventario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvInventario.SelectedIndexChanged
        LoadProducto(grvInventario.SelectedValue)
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidarConsistencia() Then
            EjecutarAccion()
            Panel1.Visible = False

        End If
    End Sub

    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Session("Producto") = bizProducto
        ViewState("Modo") = _Modo
    End Sub

    Protected Sub btnEliminarProducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarProducto.Click
        If Not grvInventario.SelectedValue Is Nothing Then
            _Modo = "B"
            EjecutarAccion()
        Else
            MostrarMensaje("Seleccione un producto a eliminar")
        End If
    End Sub

    Protected Sub btnAgregarProducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarProducto.Click
        _Modo = "A"
        bizProducto = New Producto

        Panel1.Visible = True

        LimpiarControles()
        txtNombre.Focus()
    End Sub
#End Region

End Class
