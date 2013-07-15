Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class FormatoCulturaAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As FormatoCultura
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pfc_id", id))

            reader = base.ConsultarReader("SP_FormatoCulturas_Consultar", parametros)

            Dim FormatoCultura As New FormatoCultura
            reader.Read()
            FormatoCultura.Identificador = reader(0)
            FormatoCultura.Hora = reader(1)
            FormatoCultura.Fecha = reader(2)
            FormatoCultura.Numeros = reader(3)
            If Not Lazy Then
                Dim IdiomaAD = New IdiomaAD
                FormatoCultura.Idioma = IdiomaAD.ConsultarPorId(reader(4))
            End If
            If Not reader Is Nothing Then reader.Close()

            Return FormatoCultura
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPorIdioma(ByVal idioma As Idioma, Optional ByVal Lazy As Boolean = True) As FormatoCultura
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pidioma_id", idioma.Identificador))

            reader = base.ConsultarReader("SP_FormatosCulturas_ConsultarPorIdioma", parametros)


            Dim formatoCultura As New FormatoCultura
            reader.Read()
            formatoCultura.Identificador = reader(0)
            formatoCultura.Hora = reader(1)
            formatoCultura.Fecha = reader(2)
            formatoCultura.Numeros = reader(3)
            If Not Lazy Then
                Dim IdiomaAD = New IdiomaAD
                formatoCultura.Idioma = IdiomaAD.ConsultarPorId(reader(4))
            End If
            If Not reader Is Nothing Then reader.Close()

            Return formatoCultura

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of FormatoCultura)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_FormatoCulturas_ConsultarTodos")

            Dim formatoCulturas As New List(Of FormatoCultura)
            Do While reader.Read()
                Dim formatoCultura As New FormatoCultura
                formatoCultura.Identificador = reader(0)
                formatoCultura.Hora = reader(1)
                formatoCultura.Fecha = reader(2)
                formatoCultura.Numeros = reader(3)
                If Not Lazy Then
                    Dim IdiomaAD = New IdiomaAD
                    formatoCultura.Idioma = IdiomaAD.ConsultarPorId(reader(4))
                End If

                formatoCulturas.Add(formatoCultura)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return formatoCulturas
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