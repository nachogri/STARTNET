

Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class IdiomaAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Idioma
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pidioma_id", id))

            reader = base.ConsultarReader("SP_Idiomas_Consultar", parametros)

            Dim idioma As New Idioma
            reader.Read()
            idioma.Identificador = reader(0)
            idioma.Nombre = reader(1)
            If Not reader Is Nothing Then reader.Close()


            Return idioma
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPorUsuario(ByVal usuario As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Idioma)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pusu_id", usuario.Identificador))

            reader = base.ConsultarReader("SP_Idiomas_ConsultarPorUsuario", parametros)

            Dim idiomas As New List(Of Idioma)
            Do While reader.Read()
                Dim idioma As New Idioma
                idioma.Identificador = reader(0)
                idioma.Nombre = reader(1)
                If Not Lazy Then
                    Dim formatoCulturaAD = New FormatoCulturaAD
                    idioma.FormatoCultura = formatoCulturaAD.ConsultarPorIdioma(idioma)
                End If

                idiomas.Add(idioma)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return idiomas

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Idioma)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Idiomas_ConsultarTodos")

            Dim idiomas As New List(Of Idioma)
            Do While reader.Read()
                Dim idioma As New Idioma
                idioma.Identificador = reader(0)
                idioma.Nombre = reader(1)

                If Not Lazy Then
                    Dim formatoCulturaAD = New FormatoCulturaAD
                    idioma.FormatoCultura = formatoCulturaAD.ConsultarPorIdioma(idioma)
                End If

                idiomas.Add(idioma)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return idiomas
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class

