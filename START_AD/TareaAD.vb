Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class TareaAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef tarea As Tarea) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            tarea.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptar_id", tarea.Identificador))
            parametros.Add(New SqlParameter("@ptar_nombre", tarea.Nombre))
            parametros.Add(New SqlParameter("@ptar_descrip", tarea.Descripcion))

            res = base.EjecutarInstruccion("SP_Tareas_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal tarea As Tarea) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptar_id", tarea.Identificador))
            parametros.Add(New SqlParameter("@ptar_nombre", tarea.Nombre))
            parametros.Add(New SqlParameter("@ptar_descrip", tarea.Descripcion))

            res = base.EjecutarInstruccion("SP_Tareas_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal tarea As Tarea) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptar_id", tarea.Identificador))

            res = base.EjecutarInstruccion("SP_Tareas_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Tarea
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptar_id", id))

            reader = base.ConsultarReader("SP_Tareas_Consultar", parametros)
            reader.Read()

            Dim tarea As New Tarea
            tarea.Identificador = reader(0)
            tarea.Nombre = reader(1)
            tarea.Descripcion = reader(2)
            If Not reader Is Nothing Then reader.Close()

            Return tarea
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Tarea, Optional ByVal Lazy As Boolean = True) As List(Of Tarea)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ptar_nombre", filtros.Nombre))
            parametros.Add(New SqlParameter("@ptar_descrip", filtros.Descripcion))

            reader = base.ConsultarReader("SP_Tareas_ConsultarPor", parametros)

            Dim tareas As New List(Of Tarea)
            Do While reader.Read()
                Dim tarea As New Tarea
                tarea.Identificador = reader(0)
                tarea.Nombre = reader(1)
                tarea.Descripcion = reader(2)

                tareas.Add(tarea)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return tareas

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Tarea)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Tareas_ConsultarTodos")

            Dim tareas As New List(Of Tarea)
            Do While reader.Read()
                Dim tarea As New Tarea
                tarea.Identificador = reader(0)
                tarea.Nombre = reader(1)
                tarea.Descripcion = reader(2)

                tareas.Add(tarea)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return tareas
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
