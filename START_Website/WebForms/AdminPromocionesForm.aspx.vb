Imports START_LN
Imports START_ENTIDADES
Imports START_HELPER

Partial Public Class WebForms_AdminPromocionesForm
    Inherits System.Web.UI.Page

#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizPromocion As New Promocion
    Dim bizPromocionLN As New promocionLN
#End Region

#Region "Metodos privados"
    Protected Sub Inicializacion()

    End Sub

    Protected Sub EjecutarAccion()
        Try
            Dim resultado As Integer
            Dim bizTarea As New Tarea

            bizPromocion.Nombre = txtNombre.Text.Replace("'", "")
            bizPromocion.Requisitos = txtRequisitos.Text.Replace("'", "")
            bizPromocion.Expiracion = DateHelper.ConvertirStringToDate(txtExpiracion.Text)


            If _Modo = "A" Then
                resultado = bizPromocionLN.Insertar(bizPromocion)
                bizTarea.Nombre = "Alta de Promociones"
            ElseIf _Modo = "M" Then
                resultado = bizPromocionLN.Actualizar(bizPromocion)
                bizTarea.Nombre = "Modificacion de Promociones"
            ElseIf _Modo = "B" Then
                resultado = bizPromocionLN.Borrar(bizPromocion)
                bizTarea.Nombre = "Baja de Promociones"
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
        bizPromocion = Nothing
        GC.Collect()
    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub LlenarControles()
        Try
            grvPromociones.DataSource = bizPromocionLN.ConsultarTodos()
            grvPromociones.DataBind()
            Session("dataSource") = grvPromociones.DataSource

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

    Private Sub LoadPromocion(ByVal pId As Guid)
        Try
            _Modo = "M"

            Panel2.Visible = True

            bizPromocion = bizPromocionLN.ConsultarPorId(pId, False)

            txtNombre.Text = bizPromocion.Nombre
            txtRequisitos.Text = bizPromocion.Requisitos
            txtExpiracion.Text = bizPromocion.Expiracion

            refrescarProductos()
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarControles()
        txtNombre.Text = ""
        txtRequisitos.Text = ""
        txtExpiracion.Text = ""
        lstProductosFinal.Items.Clear()

    End Sub

    Private Sub refrescarProductos()
        Dim listProductos As New List(Of Producto)
        For Each Prod As PromocionProducto In bizPromocion.Productos
            listProductos.Add(Prod.Producto)
        Next
        lstProductosFinal.DataSource = listProductos
        lstProductosFinal.DataTextField = "Nombre"
        lstProductosFinal.DataBind()
    End Sub

    Private Sub AgregarProducto(ByVal pProductoSeleccionado As Producto)
        Dim promoProducto As New PromocionProducto
        promoProducto.Producto = pProductoSeleccionado
        promoProducto.Promocion = bizPromocion
        promoProducto.Regalo = 0
        promoProducto.Descuento = txtDecuento.Text

        If bizPromocion.Productos Is Nothing Then
            bizPromocion.Productos = New List(Of PromocionProducto)
        End If
        bizPromocion.Productos.Add(promoProducto)
        refrescarProductos()
    End Sub


    Private Sub QuitarProducto(ByVal pProductoSeleccionada As Producto)
        For Each prod As PromocionProducto In bizPromocion.Productos
            If prod.Producto.Nombre = pProductoSeleccionada.Nombre Then
                bizPromocion.Productos.Remove(prod)
                Exit For
            End If
        Next

        refrescarProductos()
    End Sub
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _Modo = ViewState("Modo")
        If Not Session("Promocion") Is Nothing Then
            bizPromocion = Session("Promocion")
            '_Modo = "A"
        End If

        If Not IsPostBack Then
            Inicializacion()
            Panel2.Visible = False
            LlenarControles()
        End If
    End Sub

    Protected Sub grvPromociones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvPromociones.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvPromociones.PageIndex = e.NewPageIndex
            grvPromociones.DataSource = Session("dataSource")
            grvPromociones.DataBind()
        End If
    End Sub

    Protected Sub grvPromociones_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grvPromociones.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim _hyperLink As HyperLink = e.Row.Controls(0).Controls(3)
            _hyperLink.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';"
            _hyperLink.Attributes("onmouseout") = "this.style.textDecoration='none';"
            _hyperLink.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.grvPromociones, "Select$" & e.Row.RowIndex)

            If e.Row.Cells(1).Text.Length > 50 Then
                e.Row.Cells(1).Text = e.Row.Cells(1).Text.Substring(0, 50) & "..."
            End If
        End If
    End Sub

    Protected Sub grvPromociones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvPromociones.SelectedIndexChanged
        LoadPromocion(grvPromociones.SelectedValue)
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
        Session("Promocion") = bizPromocion
        ViewState("Modo") = _Modo
    End Sub

    Protected Sub btnEliminarPromocion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminarPromocion.Click
        If Not grvPromociones.SelectedValue Is Nothing Then
            _Modo = "B"
            EjecutarAccion()
        Else
            MostrarMensaje("Seleccione un Promocion a eliminar")
        End If
    End Sub

    Protected Sub btnAgregarPromocion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarPromocion.Click
        _Modo = "A"
        bizPromocion = New Promocion

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

