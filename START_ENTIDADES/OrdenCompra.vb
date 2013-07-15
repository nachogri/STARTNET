Public Class OrdenCompra
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


    Private _Usuario As Usuario
    Public Property Usuario() As Usuario
        Get
            Return _Usuario
        End Get
        Set(ByVal value As Usuario)
            _Usuario = value
        End Set
    End Property



    Private _Fecha As Date
    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property


    Private _FechaEntrega As Date
    Public Property FechaEntrega() As Date
        Get
            Return _FechaEntrega
        End Get
        Set(ByVal value As Date)
            _FechaEntrega = value
        End Set
    End Property


    Private _Productos As List(Of OrdenCompraProducto)
    Public Property Productos() As List(Of OrdenCompraProducto)
        Get
            Return _Productos
        End Get
        Set(ByVal value As List(Of OrdenCompraProducto))
            _Productos = value
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


    Private _Comentarios As String
    Public Property Comentarios() As String
        Get
            Return _Comentarios
        End Get
        Set(ByVal value As String)
            _Comentarios = value
        End Set
    End Property


    Private _MontoTotal As Integer
    Public Property MontoTotal() As Integer
        Get
            Return _MontoTotal
        End Get
        Set(ByVal value As Integer)
            _MontoTotal = value
        End Set
    End Property


    Private _CondicionesPago As String
    Public Property CondicionesPago() As String
        Get
            Return _CondicionesPago
        End Get
        Set(ByVal value As String)
            _CondicionesPago = value
        End Set
    End Property


    Private _PagoProveedor As PagoProveedor
    Public Property PagoProveedor() As PagoProveedor
        Get
            Return _PagoProveedor
        End Get
        Set(ByVal value As PagoProveedor)
            _PagoProveedor = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
