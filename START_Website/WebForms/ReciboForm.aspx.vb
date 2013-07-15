Imports START_LN
Imports START_ENTIDADES

Partial Class WebForms_ReciboForm
    Inherits System.Web.UI.Page


#Region "Propiedades y objetos internos"
    Dim bizVenta As Venta
    Dim dtVenta As Data.DataTable
#End Region

#Region "Metodos privados"
    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()
        If Not Session("Venta") Is Nothing Then
            dtVenta = Session("Venta")
            Session("Venta") = Nothing
        End If
    End Sub

    Protected Sub LlenarControles()
        Try
            Dim subTotal As Integer
            Dim cantTotal As Integer

            lblPromocion.Text = 0

            For Each dr As DataRow In dtVenta.Rows
                cantTotal += dr(1)
                subTotal += dr(3)
            Next
            lblSubtotal.Text = subTotal
            If lblPromocion.Text.Length > 0 AndAlso Convert.ToInt32(lblPromocion.Text) > 0 Then
                lblTotal.Text = subTotal + (subTotal * (Convert.ToInt32(lblPromocion.Text) / 100))
            Else
                lblTotal.Text = subTotal
            End If

            grvVenta.DataSource = dtVenta
            grvVenta.DataBind()

            Dim _Logueo As Logueo = Session("Logueo")
            lblUsuario.Text = _Logueo.Usuario.Nombre & ", " & _Logueo.Usuario.Apellido
            lblFecha.Text = Now.ToString("dd/MM/yyyy hh:mm:ss")
            lblPrecio.Text = lblTotal.Text
            lblCantidad.Text = cantTotal
            Dim domicilio As String = Request.QueryString("Dom")
            If domicilio = "" Then
                Dim bizDomicilio As New Domicilio
                bizDomicilio.Usuario = _Logueo.Usuario
                Dim bizDomicilioLN As New DomicilioLN
                bizDomicilio = bizDomicilioLN.ConsultarPor(bizDomicilio, False)(0)
                domicilio = "Calle: " & bizDomicilio.Calle & " - Altura: " & bizDomicilio.Nro & " - Localidad: " & bizDomicilio.Localidad.Nombre & " (" & bizDomicilio.Tipo & ")"
            End If
            lblDomicilio.Text = domicilio

        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)
        cuGeneral.IsValid = False
        cuGeneral.ErrorMessage = pMensaje
        vsMensajes.Visible = True
    End Sub


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
