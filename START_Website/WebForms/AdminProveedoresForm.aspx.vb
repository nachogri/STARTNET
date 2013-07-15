Imports START_LN
Imports START_ENTIDADES

Partial Public Class WebForms_AdminProveedoresForm
    Inherits System.Web.UI.Page
#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizProveedor As New Proveedor
    Dim bizProveedorLN As New ProveedorLN
    Dim bizDomicilio As New Domicilio
    Dim bizDomicilioLN As New DomicilioLN
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
            Dim resultado As Integer
            Dim bizTarea As New Tarea

            bizProveedor.Nombre = txtNombre.Text.Replace("'", "")
            bizProveedor.Email = txtEmail.Text.Replace("'", "")
            bizProveedor.Telefono = txtTelefono.Text
            bizProveedor.Domicilio = txtDomicilio.Text

            If _Modo = "A" Then
                resultado = bizProveedorLN.Insertar(bizProveedor)
                bizTarea.Nombre = "Alta de Proveedor"
            ElseIf _Modo = "M" Then
                resultado = bizProveedorLN.Actualizar(bizProveedor)
                bizTarea.Nombre = "Modificación de proveedor"
            ElseIf _Modo = "B" Then
                resultado = bizProveedorLN.Borrar(bizProveedor)
                bizTarea.Nombre = "Baja de proveedor"
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
            LimpiarControles()
            LlenarControles()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()
        bizProveedor = Nothing
        GC.Collect()
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub LlenarControles()
        Try
            grvProveedores.DataSource = bizProveedorLN.ConsultarTodos()
            grvProveedores.DataBind()
            Session("dataSource") = grvProveedores.DataSource

            Dim bizProductoLN As New ProductoLN
            lstProductos.DataSource = bizProductoLN.ConsultarTodos
            lstProductos.DataTextField = "Nombre"
            lstProductos.DataValueField = "Identificador"
            lstProductos.DataBind()


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

    Private Sub LoadProveedor(ByVal pId As Guid)
        Try
            _Modo = "M"

            Panel2.Visible = True

            bizProveedor = bizProveedorLN.ConsultarPorId(pId, False)

            txtNombre.Text = bizProveedor.Nombre
            txtEmail.Text = bizProveedor.Email
            txtTelefono.Text = bizProveedor.Telefono
            txtDomicilio.Text = bizProveedor.Domicilio

            refrescarProductos()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarControles()
        txtNombre.Text = ""
        txtEmail.Text = ""
        txtTelefono.Text = ""
        lstProductosFinal.Items.Clear()

    End Sub

    Private Sub refrescarProductos()
        Dim listProductos As New List(Of Producto)
        For Each Prod As ProveedorProducto In bizProveedor.Productos
            listProductos.Add(Prod.Producto)
        Next
        lstProductosFinal.DataSource = listProductos
        lstProductosFinal.DataTextField = "Nombre"
        lstProductosFinal.DataBind()
    End Sub

    Private Sub AgregarProducto(ByVal pProductoSeleccionado As Producto)
        Dim promoProducto As New ProveedorProducto
        promoProducto.Producto = pProductoSeleccionado
        promoProducto.Proveedor = bizProveedor
        promoProducto.Costo = txtPrecio.Text        

        If bizProveedor.Productos Is Nothing Then
            bizProveedor.Productos = New List(Of ProveedorProducto)
        End If
        bizProveedor.Productos.Add(promoProducto)
        refrescarProductos()
    End Sub


    Private Sub QuitarProducto(ByVal pProductoSeleccionada As Producto)
        For Each prod As ProveedorProducto In bizProveedor.Productos
            If prod.Producto.Nombre = pProductoSeleccionada.Nombre Then
                bizProveedor.Productos.Remove(prod)
                Exit For
            End If
        Next

        refrescarProductos()
    End Sub
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _Modo = ViewState("Modo")
        If Not Session("Proveedor") Is Nothing Then
            bizProveedor = Session("Proveedor")
            '_Modo = "A"
        End If

        If Not IsPostBack Then
            Inicializacion()
            Panel2.Visible = False
            LlenarControles()
        End If
    End Sub

    Protected Sub grvProveedores_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvProveedores.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvProveedores.PageIndex = e.NewPageIndex
            grvProveedores.DataSource = Session("dataSource")
            grvProveedores.DataBind()
        End If
    End Sub

    Protected Sub grvProveedores_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grvProveedores.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim _hyperLink As HyperLink = e.Row.Controls(0).Controls(3)
            _hyperLink.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            _hyperLink.Attributes("onmouseout") = "this.style.textDecoration='none';"
            _hyperLink.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.grvProveedores, "Select$" & e.Row.RowIndex)

            If e.Row.Cells(1).Text.Length > 50 Then
                e.Row.Cells(1).Text = e.Row.Cells(1).Text.Substring(0, 50) & "..."
            End If
        End If
    End Sub

    Protected Sub grvProveedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvProveedores.SelectedIndexChanged
        LoadProveedor(grvProveedores.SelectedValue)
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
        Session("Proveedor") = bizProveedor
        ViewState("Modo") = _Modo
    End Sub

    Protected Sub btnEliminarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarProveedor.Click
        If Not grvProveedores.SelectedValue Is Nothing Then
            _Modo = "B"
            EjecutarAccion()
        Else
            MostrarMensaje("Seleccione un Proveedor a eliminar")
        End If
    End Sub

    Protected Sub btnAgregarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
        _Modo = "A"
        bizProveedor = New Proveedor

        Panel2.Visible = True

        LimpiarControles()
        txtNombre.Focus()
    End Sub

    Protected Sub btnAgregarProducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarProducto.Click
        Try
            Dim bizProductoSeleccionada As New Producto
            Dim bizProductoLN As New ProductoLN
            bizProductoSeleccionada.Nombre = lstProductos.SelectedItem.Text
            bizProductoSeleccionada = bizProductoLN.ConsultarPor(bizProductoSeleccionada)(0)
            AgregarProducto(bizProductoSeleccionada)

        Catch ex As Exception
            MostrarMensaje("Ocurrio un error con la Producto seleccionada")
        End Try
    End Sub

    Protected Sub btnQuitarFamilia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuitarProducto.Click
        If lstProductosFinal.SelectedIndex >= 0 Then
            Dim bizProductoLN As New ProductoLN
            Dim bizProductoSeleccionada As New Producto
            bizProductoSeleccionada.Nombre = lstProductosFinal.SelectedItem.Text
            bizProductoSeleccionada = bizProductoLN.ConsultarPor(bizProductoSeleccionada)(0)
            QuitarProducto(bizProductoSeleccionada)
        End If
    End Sub

#End Region
End Class

