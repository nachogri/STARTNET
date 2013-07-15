Public Class Usuario
#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Nombre As String
    Dim _Apellido As String
    Dim _NickName As String
    Dim _Password As String
    Dim _TipoDoc As String
    Dim _NroDoc As String
    Dim _FechaNac As Date
    Dim _Telefono As Integer
    Dim _Interno As Byte
    Private _Desarrolla As Byte
    Private _CondicionIVA As CondicionIVA
    Private _CUIT As String
    Private _Subscripcion As Byte
    Private _CUIL As String
    Dim _Email As String
    Dim _Estado As String
    Dim _Familias As List(Of Familia)
    Dim _Patentes As List(Of Patente)
    Private _Domicilios As List(Of Domicilio)
    Private _Idioma As Idioma
#End Region

#Region "Propiedades"
    Public Property Identificador() As Guid
        Get
            Return _Identificador
        End Get
        Set(ByVal value As Guid)
            _Identificador = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Apellido() As String
        Get
            Return _Apellido
        End Get
        Set(ByVal value As String)
            _Apellido = value
        End Set
    End Property

    Public Property NickName() As String
        Get
            Return _NickName
        End Get
        Set(ByVal value As String)
            _NickName = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property

    Public Property TipoDoc() As String
        Get
            Return _TipoDoc
        End Get
        Set(ByVal value As String)
            _TipoDoc = value
        End Set
    End Property

    Public Property NroDoc() As String
        Get
            Return _NroDoc
        End Get
        Set(ByVal value As String)
            _NroDoc = value
        End Set
    End Property

    Public Property FechaNac() As Date
        Get
            Return _FechaNac
        End Get
        Set(ByVal value As Date)
            _FechaNac = value
        End Set
    End Property

    Public Property Telefono() As Integer
        Get
            Return _Telefono
        End Get
        Set(ByVal value As Integer)
            _Telefono = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Public Property Interno() As Byte
        Get
            Return _Interno
        End Get
        Set(ByVal value As Byte)
            _Interno = value
        End Set
    End Property

    Public Property Desarrolla() As Byte
        Get
            Return _Desarrolla
        End Get
        Set(ByVal value As Byte)
            _Desarrolla = value
        End Set
    End Property

    Public Property Familias() As List(Of Familia)
        Get
            Return _Familias
        End Get
        Set(ByVal value As List(Of Familia))
            _Familias = value
        End Set
    End Property

    Public Property Patentes() As List(Of Patente)
        Get
            Return _Patentes
        End Get
        Set(ByVal value As List(Of Patente))
            _Patentes = value
        End Set
    End Property

    Public Property Domicilios() As List(Of Domicilio)
        Get
            Return _Domicilios
        End Get
        Set(ByVal value As List(Of Domicilio))
            _Domicilios = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
        End Set
    End Property

    Public Property CondicionIVA() As CondicionIVA
        Get
            Return _CondicionIVA
        End Get
        Set(ByVal value As CondicionIVA)
            _CondicionIVA = value
        End Set
    End Property

    Public Property CUIL() As String
        Get
            Return _CUIL
        End Get
        Set(ByVal value As String)
            _CUIL = value
        End Set
    End Property

    Public Property CUIT() As String
        Get
            Return _CUIT
        End Get
        Set(ByVal value As String)
            _CUIT = value
        End Set
    End Property

    Public Property Subscripcion() As Byte
        Get
            Return _Subscripcion
        End Get
        Set(ByVal value As Byte)
            _Subscripcion = value
        End Set
    End Property

    Public Property Idioma() As Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class


Public Enum CondicionIVA
    ResponsableInscripto
    ResponsableNoInscripto
    ConsumidorFinal
End Enum

