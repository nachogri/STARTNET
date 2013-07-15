Imports START_AD
Imports START_ENTIDADES
Imports System.Xml

Public Class PromocionMap
#Region "Objetos privados"
    Dim promocionAD As PromocionAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef promocion As Promocion) As Integer
        Dim res As Integer = promocionAD.Insertar(promocion)

        If res > 0 Then
            For Each producto As PromocionProducto In promocion.Productos
                Dim productoAD As New PromocionProductoAD
                productoAD.Insertar(producto)
            Next
        End If

        Return res
    End Function

    Public Function Actualizar(ByVal promocion As Promocion, Optional ByVal Lazy As Boolean = True) As Integer
        Dim res As Integer = promocionAD.Actualizar(promocion)


        If res > 0 Then
            For Each producto As PromocionProducto In promocion.Productos
                Dim productoAD As New PromocionProductoAD
                productoAD.Actualizar(producto)
            Next
        End If

        Return res

    End Function

    Public Function Borrar(ByVal promocion As Promocion) As Integer
        Dim res As Integer = promocionAD.Borrar(promocion)

        If res > 0 Then
            For Each producto As PromocionProducto In promocion.Productos
                Dim productoAD As New PromocionProductoAD
                productoAD.Borrar(producto)
            Next
        End If

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Promocion
        Dim promocion As Promocion = promocionAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim promocionProductoAD As New PromocionProductoAD
            Dim promocionProducto As New PromocionProducto
            promocionProducto.Promocion = promocion
            promocion.Productos = promocionProductoAD.ConsultarPor(promocionProducto, Lazy)
        End If

        Return promocion
    End Function

    Public Function ConsultarPor(ByVal filtros As Promocion, Optional ByVal Lazy As Boolean = True) As List(Of Promocion)
        Dim promocions As List(Of Promocion) = promocionAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each promo As Promocion In promocions
                Dim promocionProductoAD As New PromocionProductoAD
                Dim promocionProducto As New PromocionProducto
                promocionProducto.Promocion = promo
                promo.Productos = promocionProductoAD.ConsultarPor(promocionProducto, Lazy)
            Next
        End If

        Return promocions
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Promocion)
        Dim promocions As List(Of Promocion) = promocionAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each promo As Promocion In promocions
                Dim promocionProductoAD As New PromocionProductoAD
                Dim promocionProducto As New PromocionProducto
                promocionProducto.Promocion = promo
                promo.Productos = promocionProductoAD.ConsultarPor(promocionProducto, Lazy)
            Next
        End If

        Return promocions
    End Function
    Public Function ConsultarVigentes() As XmlDocument
        Return promocionAD.ConsultarVigentes()
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        promocionAD = New PromocionAD
    End Sub
#End Region
End Class


