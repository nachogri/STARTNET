Public Class Reparacion

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


    Private _FechaRecepcion As Date
    Public Property FechaRecepcion() As Date
        Get
            Return _FechaRecepcion
        End Get
        Set(ByVal value As Date)
            _FechaRecepcion = value
        End Set
    End Property


    Private _FechaDevolucion As Date
    Public Property FechaDevolucion() As Date
        Get
            Return _FechaDevolucion
        End Get
        Set(ByVal value As Date)
            _FechaDevolucion = value
        End Set
    End Property


    Private _Estado As EstadoReparacion
    Public Property Estado() As EstadoReparacion
        Get
            Return _Estado
        End Get
        Set(ByVal value As EstadoReparacion)
            _Estado = value
        End Set
    End Property


    Private _Productos As List(Of ReparacionProducto)
    Public Property Productos() As List(Of ReparacionProducto)
        Get
            Return _Productos
        End Get
        Set(ByVal value As List(Of ReparacionProducto))
            _Productos = value
        End Set
    End Property

 
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class


Public Enum EstadoReparacion
    EnProceso = 1
    Reparado = 2
    Cancelado = 3
End Enum

