Public Class Producto

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


    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property


    Private _Cantidad As String
    Public Property Cantidad() As String
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As String)
            _Cantidad = value
        End Set
    End Property


    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property


    Private _Moneda As Moneda
    Public Property Moneda() As Moneda
        Get
            Return _Moneda
        End Get
        Set(ByVal value As Moneda)
            _Moneda = value
        End Set
    End Property


    Private _Precio As Integer
    Public Property Precio() As Integer
        Get
            Return _Precio
        End Get
        Set(ByVal value As Integer)
            _Precio = value
        End Set
    End Property


    Private _PMR As Integer
    Public Property PMR() As Integer
        Get
            Return _PMR
        End Get
        Set(ByVal value As Integer)
            _PMR = value
        End Set
    End Property


    Private _Dimension As String
    Public Property Dimension() As String
        Get
            Return _Dimension
        End Get
        Set(ByVal value As String)
            _Dimension = value
        End Set
    End Property


    Private _Especificaciones As String
    Public Property Especificaciones() As String
        Get
            Return _Especificaciones
        End Get
        Set(ByVal value As String)
            _Especificaciones = value
        End Set
    End Property


    Private _Fabricante As String
    Public Property Fabricante() As String
        Get
            Return _Fabricante
        End Get
        Set(ByVal value As String)
            _Fabricante = value
        End Set
    End Property


    Private _Nacionalidad As String
    Public Property Nacionalidad() As String
        Get
            Return _Nacionalidad
        End Get
        Set(ByVal value As String)
            _Nacionalidad = value
        End Set
    End Property


    Private _Garantia As String
    Public Property Garantia() As String
        Get
            Return _Garantia
        End Get
        Set(ByVal value As String)
            _Garantia = value
        End Set
    End Property


    Private _TipoProducto As TipoProducto
    Public Property TipoProducto() As TipoProducto
        Get
            Return _TipoProducto
        End Get
        Set(ByVal value As TipoProducto)
            _TipoProducto = value
        End Set
    End Property


    Private _Imagen As Byte()
    Public Property Imagen() As Byte()
        Get
            Return _Imagen
        End Get
        Set(ByVal value As Byte())
            _Imagen = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
