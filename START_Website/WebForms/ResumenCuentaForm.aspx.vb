Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_ResumenCuentaForm
    Inherits System.Web.UI.Page

#Region "Propiedades y variables privadas"
    Dim _Modo As String = "A"
    Dim bizVenta As New Venta
    Dim bizVentaLN As New VentaLN
    Dim bizLogueo As New Logueo
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
            bizLogueo = Session("Logueo")

            Dim dtVentas As New System.Data.DataTable
            dtVentas.Columns.Add("Fecha")
            dtVentas.Columns.Add("Productos")
            dtVentas.Columns.Add("Cantidad")
            dtVentas.Columns.Add("Importe")

            Dim total As Double
            bizVenta.Usuario = bizLogueo.Usuario
            For Each venta As Venta In bizVentaLN.ConsultarPor(bizVenta, False)
                Dim dr As DataRow = dtVentas.NewRow
                dr(0) = venta.Fecha.ToShortDateString
                If Not venta.Productos Is Nothing Then
                    For Each bizVentaProducto As VentaProducto In venta.Productos
                        dr(1) &= bizVentaProducto.Producto.Nombre & ", "
                    Next
                    If dr(1).ToString.Length > 2 Then
                        dr(1).ToString.Substring(0, dr(1).ToString.TrimEnd.Length - 1)
                    End If
                    dr(2) = venta.Productos.Count
                End If
                dr(3) = venta.Importe
                dtVentas.Rows.Add(dr)

                total += venta.Importe

                lblSaldoUltimaFactura.Text = venta.Importe
                lblPago.Text = 0
                lblTotalAPagar.Text = venta.Importe
                lblTotal.Text = total
            Next
            grvVentas.DataSource = dtVentas
            grvVentas.DataBind()

            Session("dataSource") = dtVentas

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

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN
            Dim bizTarea As New Tarea
            bizTarea.Nombre = "Consulta Ventas"
            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = bizSeguimiento.Logueo.Usuario.NickName
            bizSeguimientoLN.Insertar(bizSeguimiento)
        End If
        _Modo = ViewState("Modo")
    End Sub


    Protected Overrides Sub Finalize()
        Finalizacion()
        MyBase.Finalize()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

    End Sub

    Protected Sub grvVentas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvVentas.PageIndexChanging
        If e.NewPageIndex <> -1 Then
            grvVentas.PageIndex = e.NewPageIndex
            grvVentas.DataSource = Session("dataSource")
            grvVentas.DataBind()
        End If
    End Sub
#End Region

End Class
