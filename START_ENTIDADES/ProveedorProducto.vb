Public Class ProveedorProducto
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



    Private _Costo As Integer
    Public Property Costo() As Integer
        Get
            Return _Costo
        End Get
        Set(ByVal value As Integer)
            _Costo = value
        End Set
    End Property


    Private _Proveedor As Proveedor
    Public Property Proveedor() As Proveedor
        Get
            Return _Proveedor
        End Get
        Set(ByVal value As Proveedor)
            _Proveedor = value
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



#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
