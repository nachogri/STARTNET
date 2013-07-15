Public Class VentaSeguimiento

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


    Private _Estado As EstadoVenta
    Public Property Estado() As EstadoVenta
        Get
            Return _Estado
        End Get
        Set(ByVal value As EstadoVenta)
            _Estado = value
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


    Private _Monto As Integer
    Public Property Monto() As Integer
        Get
            Return _Monto
        End Get
        Set(ByVal value As Integer)
            _Monto = value
        End Set
    End Property



    Private _Calificacion As String
    Public Property Calificacion() As String
        Get
            Return _Calificacion
        End Get
        Set(ByVal value As String)
            _Calificacion = value
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


    Private _Venta As Venta
    Public Property Venta() As Venta
        Get
            Return _Venta
        End Get
        Set(ByVal value As Venta)
            _Venta = value
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

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class


Public Enum EstadoVenta
    Pagada
    PorPagar
    Cancelada
End Enum

