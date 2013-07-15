Public Class PagoProveedor
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



    Private _Monto As Integer
    Public Property Monto() As Integer
        Get
            Return _Monto
        End Get
        Set(ByVal value As Integer)
            _Monto = value
        End Set
    End Property


    Private _NumeroFactura As String
    Public Property NumeroFactura() As String
        Get
            Return _NumeroFactura
        End Get
        Set(ByVal value As String)
            _NumeroFactura = value
        End Set
    End Property


    Private _Comprobante As String
    Public Property Comprobante() As String
        Get
            Return _Comprobante
        End Get
        Set(ByVal value As String)
            _Comprobante = value
        End Set
    End Property


    Private _OrdenesCompra As List(Of OrdenCompra)
    Public Property OrdenesCompra() As List(Of OrdenCompra)
        Get
            Return _OrdenesCompra
        End Get
        Set(ByVal value As List(Of OrdenCompra))
            _OrdenesCompra = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
