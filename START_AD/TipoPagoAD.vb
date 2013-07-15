Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class TipoPagoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef tipopago As TipoPago) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            tipopago.Identificador = Guid.NewGuid

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptpago_id", tipopago.Identificador))
            parametros.Add(New SqlParameter("@ptpago_descrip", tipopago.Descripcion))
            parametros.Add(New SqlParameter("@ptpago_disponible", tipopago.Disponible))

            res = base.EjecutarInstruccion("SP_TipoPagos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal tipopago As TipoPago) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ptpago_id", tipopago.Identificador))
            parametros.Add(New SqlParameter("@ptpago_descrip", tipopago.Descripcion))
            parametros.Add(New SqlParameter("@ptpago_disponible", tipopago.Disponible))


            res = base.EjecutarInstruccion("SP_TipoPagos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal tipopago As TipoPago) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptpago_id", tipopago.Identificador))


            res = base.EjecutarInstruccion("SP_TipoPagos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As TipoPago
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ptpago_id", id))

            reader = base.ConsultarReader("SP_TipoPagos_Consultar", parametros)
            reader.Read()

            Dim tipopago As New TipoPago
            tipopago.Identificador = reader(0)
            tipopago.Descripcion = reader(1)
            tipopago.Disponible = reader(2)

            If Not reader Is Nothing Then reader.Close()

            Return tipopago
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As TipoPago, Optional ByVal Lazy As Boolean = True) As List(Of TipoPago)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@ptpago_descrip", filtros.Descripcion))
            parametros.Add(New SqlParameter("@ptpago_disponible", filtros.Disponible))

            reader = base.ConsultarReader("SP_TipoPagos_ConsultarPor", parametros)

            Dim tipopagos As New List(Of TipoPago)
            Do While reader.Read()
                Dim tipopago As New TipoPago
                tipopago.Identificador = reader(0)
                tipopago.Descripcion = reader(1)
                tipopago.Disponible = reader(2)

                tipopagos.Add(tipopago)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return tipopagos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of TipoPago)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_TipoPagos_ConsultarTodos")

            Dim tipopagos As New List(Of TipoPago)
            Do While reader.Read()
                Dim tipopago As New TipoPago
                tipopago.Identificador = reader(0)
                tipopago.Descripcion = reader(1)
                tipopago.Disponible = reader(2)

                tipopagos.Add(tipopago)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return tipopagos
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
