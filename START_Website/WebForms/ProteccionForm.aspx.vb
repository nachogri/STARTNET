Imports START_LN
Imports START_ENTIDADES
Imports Microsoft.SqlServer
Imports System.Data.SqlClient

Partial Class WebForms_ProteccionForm
    Inherits System.Web.UI.Page


#Region "Propiedades y variables"

#End Region

#Region "Metodos"
    Protected Sub EjecutarAccion()
        Try

        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Protected Sub Finalizacion()

    End Sub

    Protected Sub Imprimir()

    End Sub

    Protected Sub Inicializacion()

    End Sub

    Protected Sub LlenarControles()
        Dim file As New IO.FileInfo(My.Settings("BackupPath"))
        If Not file Is Nothing Then
            lblFechaBackup.Text = file.LastWriteTime
        End If

    End Sub

    Protected Sub MostrarMensaje(ByVal pMensaje As String)
        cuGeneral.IsValid = False
        cuGeneral.ErrorMessage = pMensaje
        vsMensajes.Visible = True
    End Sub

    Protected Function ValidarConsistencia() As Boolean

    End Function

    Private Sub GenerarBackup()
        Try
            Dim con As SqlConnection = New SqlConnection(My.Settings("START_AD_ConnectionString"))
            Dim cmd As SqlCommand = New SqlCommand("backup database START_SQLBD to disk= '" & My.Settings("BackupPath") & "'", con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN
            Dim bizTarea As New Tarea

            bizTarea.Nombre = "BackUp"
            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = bizSeguimiento.Logueo.Usuario.NickName
            bizSeguimientoLN.Insertar(bizSeguimiento)

            lblFechaBackup.Text = Now
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub RestaurarBackup()
        Try
            Dim con As SqlConnection = New SqlConnection(My.Settings("START_AD_ConnectionString"))
            Dim cmd As SqlCommand = New SqlCommand("ALTER DATABASE [START_SQLBD] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", con)
            con.Open()
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("USE MASTER RESTORE DATABASE [START_SQLBD] FROM DISK='" & My.Settings("BackupPath") & "' with replace, nounload", con)
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("ALTER DATABASE [START_SQLBD] SET MULTI_USER WITH ROLLBACK IMMEDIATE", con)
            cmd.ExecuteNonQuery()

            con.Close()

            Dim bizSeguimiento As New Seguimiento
            Dim bizSeguimientoLN As New seguimientoLN
            Dim bizTarealn As New TareaLN
            Dim bizTarea As New Tarea

            bizTarea.Nombre = "Restore"
            bizSeguimiento.Tarea = bizTarealn.ConsultarPor(bizTarea)(0)
            bizSeguimiento.Logueo = Session("Logueo")
            bizSeguimiento.IdentificadorDeAccion = bizSeguimiento.Logueo.Usuario.NickName
            bizSeguimientoLN.Insertar(bizSeguimiento)
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub

    Private Sub EnviarNewsLetter()
        lblFechaNewsLetter.Text = Now
    End Sub

#End Region

#Region "Eventos"

    Protected Sub btnGenerarBackup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarBackup.Click
        GenerarBackup()
    End Sub

    Protected Sub btnRestaurarBackup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRestaurarBackup.Click
        RestaurarBackup()
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim usuarioLN As New UsuarioLN
            Dim usuarios As List(Of Usuario) = usuarioLN.ConsultarTodos()
            Dim promo As New promocionLN
            Dim promos As System.Xml.XmlDocument = promo.ConsultarVigentes()
            Dim helper As New START_HELPER.EmailHelper
            Dim emails As Integer
            For Each usu As Usuario In usuarios
                If Not usu.Interno Then
                    emails += 1
                    helper.enviarEmail(usu.Email, "START Newsletter", promos.OuterXml)
                End If
            Next
            lblFechaNewsLetter.Text = Now.ToString() & " - se enviaron: " & emails & " emails."
        Catch ex As Exception
            MostrarMensaje(ex.Message)
        End Try
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LlenarControles()
        End If

    End Sub
End Class
