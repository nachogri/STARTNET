Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class EncuestaSatisfaccionAD
#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef EncuestaSatisfaccion As EncuestaSatisfaccion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            EncuestaSatisfaccion.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@psatis_id", EncuestaSatisfaccion.Identificador))
            If Not EncuestaSatisfaccion.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@psatis_user_id", EncuestaSatisfaccion.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@psatis_user_id", DBNull.Value))
            End If

            If Not START_HELPER.DateHelper.IsNullDate(EncuestaSatisfaccion.Fecha) Then
                parametros.Add(New SqlParameter("@psatis_fecha", EncuestaSatisfaccion.Fecha))
            Else
                parametros.Add(New SqlParameter("@psatis_fecha", DBNull.Value))
            End If

            parametros.Add(New SqlParameter("@psatis_preg1", EncuestaSatisfaccion.Pregunta1))
            parametros.Add(New SqlParameter("@psatis_preg2", EncuestaSatisfaccion.Pregunta2))
            parametros.Add(New SqlParameter("@psatis_preg3", EncuestaSatisfaccion.Pregunta3))
            parametros.Add(New SqlParameter("@psatis_preg4", EncuestaSatisfaccion.Pregunta4))
            parametros.Add(New SqlParameter("@psatis_preg5", EncuestaSatisfaccion.Pregunta5))
            parametros.Add(New SqlParameter("@psatis_preg6", EncuestaSatisfaccion.Pregunta6))


            res = base.EjecutarInstruccion("SP_EncuestaSatisfaccion_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal EncuestaSatisfaccion As EncuestaSatisfaccion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@psatis_id", EncuestaSatisfaccion.Identificador))
            If Not EncuestaSatisfaccion.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@psatis_user_id", EncuestaSatisfaccion.Usuario.Identificador))
            Else
                parametros.Add(New SqlParameter("@psatis_user_id", DBNull.Value))
            End If

            
            If Not START_HELPER.DateHelper.IsNullDate(EncuestaSatisfaccion.Fecha) Then
                parametros.Add(New SqlParameter("@psatis_fecha", EncuestaSatisfaccion.Fecha))
            Else
                parametros.Add(New SqlParameter("@psatis_fecha", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@psatis_preg1", EncuestaSatisfaccion.Pregunta1))
            parametros.Add(New SqlParameter("@psatis_preg2", EncuestaSatisfaccion.Pregunta2))
            parametros.Add(New SqlParameter("@psatis_preg3", EncuestaSatisfaccion.Pregunta3))
            parametros.Add(New SqlParameter("@psatis_preg4", EncuestaSatisfaccion.Pregunta4))
            parametros.Add(New SqlParameter("@psatis_preg5", EncuestaSatisfaccion.Pregunta5))
            parametros.Add(New SqlParameter("@psatis_preg6", EncuestaSatisfaccion.Pregunta6))

            res = base.EjecutarInstruccion("SP_EncuestaSatisfaccion_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal EncuestaSatisfaccion As EncuestaSatisfaccion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@psatis_id", EncuestaSatisfaccion.Identificador))


            res = base.EjecutarInstruccion("SP_EncuestaSatisfaccion_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As EncuestaSatisfaccion
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@psatis_id", id))

            reader = base.ConsultarReader("SP_EncuestaSatisfaccion_Consultar", parametros)

            Dim EncuestaSatisfaccion As New EncuestaSatisfaccion
            reader.Read()
            EncuestaSatisfaccion.Identificador = reader(0)
            If Not Lazy Then
                Dim usuarioAD = New UsuarioAD
                EncuestaSatisfaccion.Usuario = usuarioAD.ConsultarPorId(reader(1))
            End If
            EncuestaSatisfaccion.Fecha = reader(2)
            EncuestaSatisfaccion.Pregunta1 = reader(3)
            EncuestaSatisfaccion.Pregunta2 = reader(4)
            EncuestaSatisfaccion.Pregunta3 = reader(5)
            EncuestaSatisfaccion.Pregunta4 = reader(6)
            EncuestaSatisfaccion.Pregunta5 = reader(7)
            EncuestaSatisfaccion.Pregunta6 = reader(8)
            
            If Not reader Is Nothing Then reader.Close()

            Return EncuestaSatisfaccion
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As EncuestaSatisfaccion, Optional ByVal Lazy As Boolean = True) As List(Of EncuestaSatisfaccion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@psatis_user_id", filtros.Usuario.Identificador))
            End If
            If Not START_HELPER.DateHelper.IsNullDate(filtros.Fecha) Then
                parametros.Add(New SqlParameter("@psatis_fecha", filtros.Fecha))
            Else
                parametros.Add(New SqlParameter("@psatis_fecha", DBNull.Value))
            End If
            parametros.Add(New SqlParameter("@psatis_respuesta", filtros.Pregunta1))            

            reader = base.ConsultarReader("SP_EncuestaSatisfaccion_ConsultarPor", parametros)

            Dim EncuestaSatisfaccions As New List(Of EncuestaSatisfaccion)
            Do While reader.Read()
                Dim EncuestaSatisfaccion As New EncuestaSatisfaccion
                EncuestaSatisfaccion.Identificador = reader(0)
                If Not Lazy Then
                    Dim usuarioAD = New UsuarioAD
                    EncuestaSatisfaccion.Usuario = usuarioAD.ConsultarPorId(reader(1))
                End If
                EncuestaSatisfaccion.Fecha = reader(2)                
                EncuestaSatisfaccion.Pregunta1 = reader(3)
                EncuestaSatisfaccion.Pregunta2 = reader(4)
                EncuestaSatisfaccion.Pregunta3 = reader(5)
                EncuestaSatisfaccion.Pregunta4 = reader(6)
                EncuestaSatisfaccion.Pregunta5 = reader(7)
                EncuestaSatisfaccion.Pregunta6 = reader(8)


                EncuestaSatisfaccions.Add(EncuestaSatisfaccion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return EncuestaSatisfaccions

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of EncuestaSatisfaccion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_EncuestaSatisfaccion_ConsultarTodos")

            Dim EncuestaSatisfaccions As New List(Of EncuestaSatisfaccion)
            Do While reader.Read()
                Dim EncuestaSatisfaccion As New EncuestaSatisfaccion
                EncuestaSatisfaccion.Identificador = reader(0)
                If Not Lazy Then
                    Dim usuarioAD = New UsuarioAD
                    EncuestaSatisfaccion.Usuario = usuarioAD.ConsultarPorId(reader(1))
                End If
                EncuestaSatisfaccion.Fecha = reader(2)
                EncuestaSatisfaccion.Pregunta1 = reader(3)
                EncuestaSatisfaccion.Pregunta2 = reader(4)
                EncuestaSatisfaccion.Pregunta3 = reader(5)
                EncuestaSatisfaccion.Pregunta4 = reader(6)
                EncuestaSatisfaccion.Pregunta5 = reader(7)
                EncuestaSatisfaccion.Pregunta6 = reader(8)

                EncuestaSatisfaccions.Add(EncuestaSatisfaccion)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return EncuestaSatisfaccions
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
