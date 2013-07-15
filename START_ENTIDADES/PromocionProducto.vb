Public Class PromocionProducto
#Region "Objetos privados"

#End Region

#Region "Propiedades"


    Private _Identificador As Guid
    Public Property Identificador() As Guid
        Get
            Return _Identificador
        End Get
        Set(ByVal value As Guid)
            _Identificador = value
        End Set
    End Property



    Private _Producto As Producto
    Public Property Producto() As Producto
        Get
            Return _Producto
        End Get
        Set(ByVal value As Producto)
            _Producto = value
        End Set
    End Property


    Private _Promocion As Promocion
    Public Property Promocion() As Promocion
        Get
            Return _Promocion
        End Get
        Set(ByVal value As Promocion)
            _Promocion = value
        End Set
    End Property


    Private _Descuento As Integer
    Public Property Descuento() As Integer
        Get
            Return _Descuento
        End Get
        Set(ByVal value As Integer)
            _Descuento = value
        End Set
    End Property


    Private _Regalo As Byte
    Public Property Regalo() As Byte
        Get
            Return _Regalo
        End Get
        Set(ByVal value As Byte)
            _Regalo = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
