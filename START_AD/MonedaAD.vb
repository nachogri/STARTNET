Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class MonedaAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef moneda As Moneda) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            moneda.Identificador = 1

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pmon_id", moneda.Identificador))
            parametros.Add(New SqlParameter("@pmon_nombre", moneda.Nombre))
            parametros.Add(New SqlParameter("@pmon_simbolo", moneda.Simbolo))
            parametros.Add(New SqlParameter("@pmon_cambio_dolar", moneda.CambioDolar))


            res = base.EjecutarInstruccion("SP_Monedas_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal moneda As Moneda) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pmon_id", moneda.Identificador))
            parametros.Add(New SqlParameter("@pmon_nombre", moneda.Nombre))
            parametros.Add(New SqlParameter("@pmon_simbolo", moneda.Simbolo))
            parametros.Add(New SqlParameter("@pmon_cambio_dolar", moneda.CambioDolar))

            res = base.EjecutarInstruccion("SP_Monedas_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal moneda As Moneda) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pmon_id", moneda.Identificador))


            res = base.EjecutarInstruccion("SP_Monedas_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Integer, Optional ByVal Lazy As Boolean = True) As Moneda
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@pmon_id", id))

            reader = base.ConsultarReader("SP_Monedas_Consultar", parametros)

            reader.Read()
            Dim moneda As New Moneda
            moneda.Identificador = reader(0)
            moneda.Nombre = reader(1)
            moneda.Simbolo = reader(2)
            moneda.CambioDolar = reader(3)
            If Not reader Is Nothing Then reader.Close()

            Return moneda
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Moneda, Optional ByVal Lazy As Boolean = True) As List(Of Moneda)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@pmon_nombre", filtros.Nombre))
            parametros.Add(New SqlParameter("@pmon_simbolo", Nothing))
            parametros.Add(New SqlParameter("@pmon_cambio_dolar", Nothing))

            reader = base.ConsultarReader("SP_Monedas_ConsultarPor", parametros)

            Dim monedas As New List(Of Moneda)
            Do While reader.Read()
                Dim moneda As New Moneda
                moneda.Identificador = reader(0)
                moneda.Nombre = reader(1)
                moneda.Simbolo = reader(2)
                moneda.CambioDolar = reader(3)

                monedas.Add(moneda)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return monedas

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Moneda)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Monedas_ConsultarTodos")

            Dim monedas As New List(Of Moneda)
            Do While reader.Read()
                Dim moneda As New Moneda
                moneda.Identificador = reader(0)
                moneda.Nombre = reader(1)
                moneda.Simbolo = reader(2)
                moneda.CambioDolar = reader(3)

                monedas.Add(moneda)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return monedas
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
