Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class ReparacionProductoAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef reparacionProducto As ReparacionProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            reparacionProducto.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@prp_id", reparacionProducto.Identificador))

            If Not reparacionProducto.Reparacion Is Nothing Then
                parametros.Add(New SqlParameter("@prp_rep_id", reparacionProducto.Reparacion.Identificador))
            End If
            If Not reparacionProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@prp_prod_id", reparacionProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@prp_garantia", reparacionProducto.Garantia))
            parametros.Add(New SqlParameter("@prp_problema", reparacionProducto.Problema))
            parametros.Add(New SqlParameter("@prp_propio", reparacionProducto.Propio))
            parametros.Add(New SqlParameter("@prp_solucion", reparacionProducto.Solucion))
            parametros.Add(New SqlParameter("@prp_comentarios", reparacionProducto.Comentarios))
            parametros.Add(New SqlParameter("@prp_repuestos", reparacionProducto.Repuestos))

            res = base.EjecutarInstruccion("SP_ReparacionesProductos_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal reparacionProducto As ReparacionProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@prp_id", reparacionProducto.Identificador))

            If Not reparacionProducto.Reparacion Is Nothing Then
                parametros.Add(New SqlParameter("@prp_rep_id", reparacionProducto.Reparacion.Identificador))
            End If
            If Not reparacionProducto.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@prp_prod_id", reparacionProducto.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@prp_garantia", reparacionProducto.Garantia))
            parametros.Add(New SqlParameter("@prp_problema", reparacionProducto.Problema))
            parametros.Add(New SqlParameter("@prp_propio", reparacionProducto.Propio))
            parametros.Add(New SqlParameter("@prp_solucion", reparacionProducto.Solucion))
            parametros.Add(New SqlParameter("@prp_comentarios", reparacionProducto.Comentarios))
            parametros.Add(New SqlParameter("@prp_repuestos", reparacionProducto.Repuestos))

            res = base.EjecutarInstruccion("SP_ReparacionesProductos_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal reparacionProducto As ReparacionProducto) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@prp_id", reparacionProducto.Identificador))

            res = base.EjecutarInstruccion("SP_ReparacionesProductos_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As ReparacionProducto
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@prp_id", id))

            reader = base.ConsultarReader("SP_ReparacionesProductos_Consultar", parametros)
            reader.Read()

            Dim reparacionProducto As New ReparacionProducto
            reparacionProducto.Identificador = reader(0)

            If Not Lazy Then
                Dim productoAD = New ProductoAD
                reparacionProducto.Producto = productoAD.ConsultarPorId(reader(2))

                Dim reparacionAD = New ReparacionAD
                reparacionProducto.Reparacion = reparacionAD.ConsultarPorId(reader(1))
            End If

            reparacionProducto.Garantia = reader(3)
            reparacionProducto.Propio = reader(4)
            reparacionProducto.Problema = reader(5)
            reparacionProducto.Solucion = reader(6)
            reparacionProducto.Comentarios = reader(7)
            reparacionProducto.Repuestos = reader(8)

            If Not reader Is Nothing Then reader.Close()

            Return reparacionProducto
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As ReparacionProducto, Optional ByVal Lazy As Boolean = True) As List(Of ReparacionProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            If Not filtros.Reparacion Is Nothing Then
                parametros.Add(New SqlParameter("@prp_rep_id", filtros.Reparacion.Identificador))
            End If
            If Not filtros.Producto Is Nothing Then
                parametros.Add(New SqlParameter("@prp_prod_id", filtros.Producto.Identificador))
            End If

            parametros.Add(New SqlParameter("@prp_garantia", filtros.Garantia))
            parametros.Add(New SqlParameter("@prp_problema", filtros.Problema))
            parametros.Add(New SqlParameter("@prp_propio", filtros.Propio))
            parametros.Add(New SqlParameter("@prp_solucion", filtros.Solucion))
            parametros.Add(New SqlParameter("@prp_comentarios", filtros.Comentarios))
            parametros.Add(New SqlParameter("@prp_repuestos", filtros.Repuestos))

            reader = base.ConsultarReader("SP_ReparacionesProductos_ConsultarPor", parametros)

            Dim reparacionProductos As New List(Of ReparacionProducto)
            Do While reader.Read()
                Dim reparacionProducto As New ReparacionProducto
                reparacionProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim productoAD = New ProductoAD
                    reparacionProducto.Producto = productoAD.ConsultarPorId(reader(2))

                    Dim reparacionAD = New ReparacionAD
                    reparacionProducto.Reparacion = reparacionAD.ConsultarPorId(reader(1))
                End If

                reparacionProducto.Garantia = reader(3)
                reparacionProducto.Propio = reader(4)
                reparacionProducto.Problema = reader(5)
                reparacionProducto.Solucion = reader(6)
                reparacionProducto.Comentarios = reader(7)
                reparacionProducto.Repuestos = reader(8)

                reparacionProductos.Add(reparacionProducto)
            Loop

            If Not reader Is Nothing Then reader.Close()

            Return reparacionProductos

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of ReparacionProducto)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_ReparacionesProductos_ConsultarTodos")

            Dim reparacionProductos As New List(Of ReparacionProducto)
            Do While reader.Read()
                Dim reparacionProducto As New ReparacionProducto
                reparacionProducto.Identificador = reader(0)

                If Not Lazy Then
                    Dim productoAD = New ProductoAD
                    reparacionProducto.Producto = productoAD.ConsultarPorId(reader(2))

                    Dim reparacionAD = New ReparacionAD
                    reparacionProducto.Reparacion = reparacionAD.ConsultarPorId(reader(1))
                End If

                reparacionProducto.Garantia = reader(3)
                reparacionProducto.Propio = reader(4)
                reparacionProducto.Problema = reader(5)
                reparacionProducto.Solucion = reader(6)
                reparacionProducto.Comentarios = reader(7)
                reparacionProducto.Repuestos = reader(8)

                reparacionProductos.Add(reparacionProducto)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return reparacionProductos
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