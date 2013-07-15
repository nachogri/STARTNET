Public Class Venta

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




    Private _LugarEntrega As String
    Public Property LugarEntrega() As String
        Get
            Return _LugarEntrega
        End Get
        Set(ByVal value As String)
            _LugarEntrega = value
        End Set
    End Property


    Private _PlazoEntrega As String
    Public Property PlazoEntrega() As String
        Get
            Return _PlazoEntrega
        End Get
        Set(ByVal value As String)
            _PlazoEntrega = value
        End Set
    End Property


    Private _Importe As Integer
    Public Property Importe() As Integer
        Get
            Return _Importe
        End Get
        Set(ByVal value As Integer)
            _Importe = value
        End Set
    End Property


    Private _Promocion As Integer
    Public Property Promocion() As Integer
        Get
            Return _Promocion
        End Get
        Set(ByVal value As Integer)
            _Promocion = value
        End Set
    End Property


    Private _ImporteTotal As String
    Public Property ImporteTotal() As String
        Get
            Return _ImporteTotal
        End Get
        Set(ByVal value As String)
            _ImporteTotal = value
        End Set
    End Property


    Private _TipoPago As TipoPago
    Public Property TipoPago() As TipoPago
        Get
            Return _TipoPago
        End Get
        Set(ByVal value As TipoPago)
            _TipoPago = value
        End Set
    End Property


    Private _Productos As List(Of VentaProducto)
    Public Property Productos() As List(Of VentaProducto)
        Get
            Return _Productos
        End Get
        Set(ByVal value As List(Of VentaProducto))
            _Productos = value
        End Set
    End Property


    Private _IVA As Integer
    Public Property IVA() As Integer
        Get
            Return _IVA
        End Get
        Set(ByVal value As Integer)
            _IVA = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
