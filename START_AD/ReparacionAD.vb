Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class ReparacionAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef reparacion As Reparacion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            reparacion.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@prep_id", reparacion.Identificador))
            If Not reparacion.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@prep_usu_id", reparacion.Usuario.Identificador))
            End If

            parametros.Add(New SqlParameter("@prep_fecha_recepcion", reparacion.FechaRecepcion))
            parametros.Add(New SqlParameter("@prep_fecha_devolucion", reparacion.FechaDevolucion))
            parametros.Add(New SqlParameter("@prep_importe_total", reparacion.ImporteTotal))
            parametros.Add(New SqlParameter("@prep_estado", reparacion.Estado))

            If Not reparacion.TipoPago Is Nothing Then
                parametros.Add(New SqlParameter("@prep_tpago_id", reparacion.TipoPago.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_Reparaciones_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal reparacion As Reparacion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@prep_id", reparacion.Identificador))
            If Not reparacion.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@prep_usu_id", reparacion.Usuario.Identificador))
            End If

            parametros.Add(New SqlParameter("@prep_fecha_recepcion", reparacion.FechaRecepcion))
            parametros.Add(New SqlParameter("@prep_fecha_devolucion", reparacion.FechaDevolucion))
            parametros.Add(New SqlParameter("@prep_importe_total", reparacion.ImporteTotal))
            parametros.Add(New SqlParameter("@prep_estado", reparacion.Estado))

            If Not reparacion.TipoPago Is Nothing Then
                parametros.Add(New SqlParameter("@prep_tpago_id", reparacion.TipoPago.Identificador))
            End If

            res = base.EjecutarInstruccion("SP_Reparaciones_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal reparacion As Reparacion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@prep_id", reparacion.Identificador))

            res = base.EjecutarInstruccion("SP_Reparaciones_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Reparacion
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@prep_id", id))

            reader = base.ConsultarReader("SP_Reparaciones_Consultar", parametros)
            reader.Read()

            Dim reparacion As New Reparacion
            reparacion.Identificador = reader(0)
            reparacion.FechaRecepcion = reader(2)
            reparacion.FechaDevolucion = reader(3)
            reparacion.ImporteTotal = reader(4)
            reparacion.Estado = reader(6)

            If Not Lazy Then
                Dim tipopagoAD = New TipoPagoAD
                Dim usuarioAD = New UsuarioAD

                reparacion.TipoPago = tipopagoAD.ConsultarPorId(reader(5))
                reparacion.Usuario = usuarioAD.ConsultarPorId(reader(1))
            End If
            If Not reader Is Nothing Then reader.Close()

            Return reparacion
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Reparacion, Optional ByVal Lazy As Boolean = True) As List(Of Reparacion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            If Not filtros.Usuario Is Nothing Then
                parametros.Add(New SqlParameter("@prep_usu_id", filtros.Usuario.Identificador))
            End If

            parametros.Add(New SqlParameter("@prep_fecha_recepcion", filtros.FechaRecepcion))
            parametros.Add(New SqlParameter("@prep_fecha_devolucion", filtros.FechaDevolucion))
            parametros.Add(New SqlParameter("@prep_importe_total", filtros.ImporteTotal))
            parametros.Add(New SqlParameter("@prep_estado", filtros.Estado))

            If Not filtros.TipoPago Is Nothing Then
                parametros.Add(New SqlParameter("@prep_tpago_id", filtros.TipoPago.Identificador))
            End If

            reader = base.ConsultarReader("SP_Reparaciones_ConsultarPor", parametros)

            Dim reparacions As New List(Of Reparacion)
            Do While reader.Read()
                Dim reparacion As New Reparacion
                reparacion.Identificador = reader(0)
                reparacion.FechaRecepcion = reader(2)
                reparacion.FechaDevolucion = reader(3)
                reparacion.ImporteTotal = reader(4)
                reparacion.Estado = reader(6)

                If Not Lazy Then
                    Dim tipopagoAD = New TipoPagoAD
                    Dim usuarioAD = New UsuarioAD

                    reparacion.TipoPago = tipopagoAD.ConsultarPorId(reader(5))
                    reparacion.Usuario = usuarioAD.ConsultarPorId(reader(1))
                End If

                reparacions.Add(reparacion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return reparacions

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Reparacion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Reparaciones_ConsultarTodos")

            Dim reparacions As New List(Of Reparacion)
            Do While reader.Read()
                Dim reparacion As New Reparacion
                reparacion.Identificador = reader(0)
                reparacion.FechaRecepcion = reader(2)
                reparacion.FechaDevolucion = reader(3)
                reparacion.ImporteTotal = reader(4)
                reparacion.Estado = reader(6)

                If Not Lazy Then
                    Dim tipopagoAD = New TipoPagoAD
                    Dim usuarioAD = New UsuarioAD

                    reparacion.TipoPago = tipopagoAD.ConsultarPorId(reader(5))
                    reparacion.Usuario = usuarioAD.ConsultarPorId(reader(1))
                End If

                reparacions.Add(reparacion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return reparacions
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


