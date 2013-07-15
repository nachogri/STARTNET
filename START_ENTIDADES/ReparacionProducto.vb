Public Class ReparacionProducto

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


    Private _Reparacion As Reparacion
    Public Property Reparacion() As Reparacion
        Get
            Return _Reparacion
        End Get
        Set(ByVal value As Reparacion)
            _Reparacion = value
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


    Private _Garantia As String
    Public Property Garantia() As String
        Get
            Return _Garantia
        End Get
        Set(ByVal value As String)
            _Garantia = value
        End Set
    End Property


    Private _Problema As String
    Public Property Problema() As String
        Get
            Return _Problema
        End Get
        Set(ByVal value As String)
            _Problema = value
        End Set
    End Property


    Private _Solucion As String
    Public Property Solucion() As String
        Get
            Return _Solucion
        End Get
        Set(ByVal value As String)
            _Solucion = value
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



    Private _Repuestos As String
    Public Property Repuestos() As String
        Get
            Return _Repuestos
        End Get
        Set(ByVal value As String)
            _Repuestos = value
        End Set
    End Property


    Private _Propio As Byte
    Public Property Propio() As Byte
        Get
            Return _Propio
        End Get
        Set(ByVal value As Byte)
            _Propio = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
