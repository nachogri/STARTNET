Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class HabilitacionAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"  

    Public Function ConsultarPorPatente(ByVal patente As Patente, Optional ByVal Lazy As Boolean = True) As List(Of Habilitacion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppat_id", patente.Identificador))

            reader = base.ConsultarReader("SP_PatentesHabilitaciones_ConsultarPorPatente", parametros)

            Dim habilitaciones As New List(Of Habilitacion)
            Do While reader.Read()
                Dim habilitacion As New Habilitacion
                habilitacion.Identificador = reader(0)
                habilitacion.Objeto = reader(2)
                habilitacion.Habilitado = reader(3)
                habilitacion.Patente = patente
                habilitaciones.Add(habilitacion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return habilitaciones

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Habilitacion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Habilitaciones_ConsultarTodos")

            Dim habilitacions As New List(Of Habilitacion)
            Do While reader.Read()
                Dim habilitacion As New Habilitacion
                habilitacion.Identificador = reader(0)
                habilitacion.Objeto = reader(2)
                habilitacion.Habilitado = reader(3)

                If Not Lazy Then
                    Dim PatenteAD = New PatenteAD
                    habilitacion.Patente = PatenteAD.ConsultarPorId(reader(1))
                End If

                habilitacions.Add(habilitacion)
            Loop
            If Not reader Is Nothing Then reader.Close()


            Return habilitacions
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
