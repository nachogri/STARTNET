Imports START_LN
Imports START_ENTIDADES
Imports START_HELPER

Partial Class WebForms_ConsultarBitacoraForm
    Inherits System.Web.UI.Page


#Region "Propiedades y variables"
    Dim bizLogueo As New Logueo
    Dim bizSeguimiento As New Seguimiento
    Dim bizUsuario As New Usuario
    Dim bizTarea As New Tarea
    Dim bizLogueoLN As New LogueoLN
    Dim bizSeguimientoLN As New seguimientoLN
    Dim bizUsuarioLN As New UsuarioLN
    Dim bizTareaLN As New TareaLN
    Dim lstLogueos As New List(Of Logueo)
    Dim _index As Integer
#End Region

#Region "Metodos"
    Protected Sub EjecutarAccion()
        Try
            Dim dtVistaAlfa As New DataTable


            dtVistaAlfa.Columns.Add("Fecha")
            dtVistaAlfa.Columns.Add("Usuario")
            dtVistaAlfa.Columns.Add("HoraIn")
            dtVistaAlfa.Columns.Add("HoraOut")
            dtVistaAlfa.Columns.Add("Tarea")
            dtVistaAlfa.Columns.Add("IdentificadorDeAccion")


            lstLogueos = bizLogueoLN.ConsultarPor(ArmarFiltrosBusqueda, False)
            For Each l As Logueo In lstLogueos
                If Not l.Seguimientos Is Nothing Then
                    For Each bizSeguimiento As Seguimiento In l.Seguimientos
                        Dim drVistaAlfa As DataRow = dtVistaAlfa.NewRow()

                        drVistaAlfa("Fecha") = l.Fecha.ToShortDateString
                        drVistaAlfa("HoraIn") = l.HoraIn.ToString()
                        drVistaAlfa("HoraOut") = l.HoraOut.ToString()
                        drVistaAlfa("Usuario") = l.Usuario.NickName
                        drVistaAlfa("Tarea") = bizSeguimiento.Tarea.Nombre & ":" & bizSeguimiento.Tarea.Descripcion
                        drVistaAlfa("IdentificadorDeAccion") = bizSeguimiento.IdentificadorDeAccion
                        dtVistaAlfa.Rows.Add(drVistaAlfa)
                    Next
                End If
            Next

            grvAcciones.DataSource = dtVistaAlfa
            Session("dataSource") = dtVistaAlfa


            grvAcciones.DataBind()
        Catch ex As Exception
            MostrarMensaje("Ocurrió un error al ejecutar la acción")
        End Try
    End Sub

    Protected Sub Finalizacion()

    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()

    End Sub

    Protected Sub LlenarControles()
        Try
            Dim colUsuarios As New Collection
            bizUsuario.NickName = "-Todos-"
            bizUsuario.Identificador = New Guid()
            colUsuarios.Add(bizUsuario)
            For Each usu As Usuario In bizUsuarioLN.ConsultarTodos
                colUsuarios.Add(usu)
            Next

            ddlUsuarios.DataSource = colUsuarios
            ddlUsuarios.DataTextField = "Nickname"
            ddlUsuarios.DataValueField = "Identificador"
            ddlUsuarios.DataBind()

            Dim colTareas As New Collection
            bizTarea.Nombre = "-Todas-"
            bizTarea.Identificador = New Guid()
            colTareas.Add(bizTarea)
            For Each tar As Tarea In bizTareaLN.ConsultarTodos
                colTareas.Add(tar)
            Next

            ddlAccion.DataSource = colTareas
            ddlAccion.DataTextField = "Nombre"
            ddlAccion.DataValueField = "Identificador"
            ddlAccion.DataBind()


        Catch ex As Exception
            MostrarMensaje("Ocurrió un error al cargar la pagina")
        End Try
    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)
        cuGeneral.IsValid = False
        cuGeneral.ErrorMessage = pMensaje
        vsMensajes.Visible = True
    End Sub

    Protected Function ValidarConsistencia() As Boolean

    End Function

    Private Function ArmarFiltrosBusqueda() As Logueo
        Try

            Dim filtroUsuarios, filtroFecha, filtroAccion As Boolean
            filtroUsuarios = False
            filtroFecha = False
            filtroAccion = False

            If ddlUsuarios.SelectedIndex > 0 Then
                bizLogueo.Usuario = bizUsuarioLN.ConsultarPorId(New Guid(ddlUsuarios.SelectedValue))
                filtroUsuarios = True
            End If
            If txtFecha.Text.Length > 0 Then
                bizLogueo.Fecha = DateHelper.ConvertirStringToDate(txtFecha.Text)
                filtroFecha = True
            End If

            If ddlAccion.SelectedIndex > 0 Then
                bizLogueo.Seguimientos = New List(Of Seguimiento)
                bizSeguimiento.Tarea = bizTareaLN.ConsultarPorId(New Guid(ddlAccion.SelectedValue))
                bizLogueo.Seguimientos.Add(bizSeguimiento)
                filtroAccion = True
            End If

            If Not filtroUsuarios And Not filtroFecha And Not filtroAccion Then
                Throw New Exception("La consulta es demasiado genérica. Por favor refine la búsqueda.")
            End If
            
            Return bizLogueo
        Catch ex As Exception
            MostrarMensaje(ex.Message)
            Return Nothing
        End Try
    End Function
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LlenarControles()
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        EjecutarAccion()
    End Sub

    Protected Sub grvAcciones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grvAcciones.PageIndexChanging
        grvAcciones.PageIndex = e.NewPageIndex
        grvAcciones.DataSource = Session("dataSource")
        grvAcciones.DataBind()
    End Sub
#End Region
End Class