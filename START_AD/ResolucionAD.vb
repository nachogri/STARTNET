Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class ResolucionAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef resolucion As Resolucion) As Integer
        Dim res As Integer = -1
        'Try
        '    base = New START_SERVICIOS.BaseDeDatosSQL()

        '    resolucion.Identificador = Guid.NewGuid

        '    parametros = New List(Of SqlParameter)
        '    parametros.Add(New SqlParameter("@pres_id", resolucion.Identificador))
        '    parametros.Add(New SqlParameter("@pres_solucion", resolucion.Solucion))


        '    res = base.EjecutarInstruccion("SP_Resoluciones_Insertar", parametros)
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    base = Nothing
        '    parametros = Nothing
        'End Try

        Return res
    End Function

    Public Function Actualizar(ByVal resolucion As Resolucion) As Integer
        Dim res As Integer = -1
        'Try
        '    base = New START_SERVICIOS.BaseDeDatosSQL()

        '    parametros = New List(Of SqlParameter)

        '    parametros.Add(New SqlParameter("@pres_id", resolucion.Identificador))
        '    parametros.Add(New SqlParameter("@pres_solucion", resolucion.Solucion))

        '    res = base.EjecutarInstruccion("SP_Resoluciones_Actualizar", parametros)
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    base = Nothing
        '    parametros = Nothing
        'End Try

        Return res
    End Function

    Public Function Borrar(ByVal resolucion As Resolucion) As Integer
        Dim res As Integer = -1
        'Try
        '    base = New START_SERVICIOS.BaseDeDatosSQL()

        '    parametros = New List(Of SqlParameter)
        '    parametros.Add(New SqlParameter("@pres_id", resolucion.Identificador))


        '    res = base.EjecutarInstruccion("SP_Resoluciones_Borrar", parametros)
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    base = Nothing
        '    parametros = Nothing
        'End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Integer, Optional ByVal Lazy As Boolean = True) As Resolucion
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pres_id", id))

            reader = base.ConsultarReader("SP_Resoluciones_Consultar", parametros)
            reader.Read()

            Dim resolucion As New Resolucion
            resolucion.Identificador = reader(0)
            resolucion.Solucion = reader(1)
            If Not reader Is Nothing Then reader.Close()

            Return resolucion
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Resolucion, Optional ByVal Lazy As Boolean = True) As List(Of Resolucion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pres_solucion", filtros.Solucion))

            reader = base.ConsultarReader("SP_Resoluciones_ConsultarPor", parametros)

            Dim resolucions As New List(Of Resolucion)
            Do While reader.Read()
                Dim resolucion As New Resolucion
                resolucion.Identificador = reader(0)
                resolucion.Solucion = reader(1)

                resolucions.Add(resolucion)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return resolucions

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Resolucion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Resoluciones_ConsultarTodos")

            Dim resolucions As New List(Of Resolucion)
            Do While reader.Read()
                Dim resolucion As New Resolucion
                resolucion.Identificador = reader(0)
                resolucion.Solucion = reader(1)

                resolucions.Add(resolucion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return resolucions
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

