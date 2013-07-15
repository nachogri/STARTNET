Imports START_AD
Imports START_ENTIDADES

Public Class reparacionMap
#Region "Objetos privados"
    Dim reparacionAD As reparacionAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef reparacion As reparacion) As Integer
        Dim res As Integer = reparacionAD.Insertar(reparacion)

        If res > 0 And Not reparacion.Productos Is Nothing Then
            For Each producto As ReparacionProducto In reparacion.Productos
                Dim productoAD As New ReparacionProductoAD
                productoAD.Insertar(producto)
            Next
        End If
        Return res
    End Function

    Public Function Actualizar(ByVal reparacion As reparacion, Optional ByVal Lazy As Boolean = True) As Integer
        Dim res As Integer = reparacionAD.Insertar(reparacion)

        If Not Lazy Then
            If res > 0 And Not reparacion.Productos Is Nothing Then
                For Each producto As ReparacionProducto In reparacion.Productos
                    Dim productoAD As New ReparacionProductoAD
                    productoAD.Actualizar(producto)
                Next
            End If
        End If
        Return res
    End Function

    Public Function Borrar(ByVal reparacion As reparacion) As Integer
        Dim res As Integer = reparacionAD.Insertar(reparacion)

        If res > 0 And Not reparacion.Productos Is Nothing Then 
            For Each producto As ReparacionProducto In reparacion.Productos
                Dim productoAD As New ReparacionProductoAD
                productoAD.Borrar(producto)
            Next
        End If
        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As reparacion
        Dim reparacion As reparacion = reparacionAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim reparacionProductoAD As New reparacionProductoAD
            Dim reparacionProducto As New reparacionProducto
            reparacionProducto.reparacion = reparacion
            reparacion.Productos = reparacionProductoAD.ConsultarPor(reparacionProducto, Lazy)
        End If

        Return reparacion
    End Function

    Public Function ConsultarPor(ByVal filtros As reparacion, Optional ByVal Lazy As Boolean = True) As List(Of reparacion)
        Dim reparacions As List(Of reparacion) = reparacionAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each rep As Reparacion In reparacions
                Dim reparacionProductoAD As New ReparacionProductoAD
                Dim reparacionProducto As New ReparacionProducto
                reparacionProducto.Reparacion = rep
                rep.Productos = reparacionProductoAD.ConsultarPor(reparacionProducto, Lazy)
            Next
        End If

        Return reparacions
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of reparacion)
        Dim reparacions As List(Of reparacion) = reparacionAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each rep As Reparacion In reparacions
                Dim reparacionProductoAD As New ReparacionProductoAD
                Dim reparacionProducto As New ReparacionProducto
                reparacionProducto.Reparacion = rep
                rep.Productos = reparacionProductoAD.ConsultarPor(reparacionProducto, Lazy)
            Next
        End If

        Return reparacions
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        reparacionAD = New reparacionAD
    End Sub
#End Region
End Class


