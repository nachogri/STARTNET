Public Class Leyenda

#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Idioma As Idioma
    Dim _ClaseContenedor As String
    Dim _Objeto As String
    Dim _Indice As Short
    Dim _Texto1 As String
    Dim _Texto2 As String
    Dim _Texto3 As String
    Dim _ToolTip As String
    Dim _TypeOf As String    
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

    Public Property Idioma() As Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property

    Public Property ClaseContenedor() As String
        Get
            Return _ClaseContenedor
        End Get
        Set(ByVal value As String)
            _ClaseContenedor = value
        End Set
    End Property

    Public Property Objeto() As String
        Get
            Return _Objeto
        End Get
        Set(ByVal value As String)
            _Objeto = value
        End Set
    End Property

    Public Property Indice() As Short
        Get
            Return _Indice
        End Get
        Set(ByVal value As Short)
            _Indice = value
        End Set
    End Property

    Public Property Texto1() As String
        Get
            Return _Texto1
        End Get
        Set(ByVal value As String)
            _Texto1 = value
        End Set
    End Property

    Public Property Texto2() As String
        Get
            Return _Texto2
        End Get
        Set(ByVal value As String)
            _Texto2 = value
        End Set
    End Property

    Public Property Texto3() As String
        Get
            Return _Texto3
        End Get
        Set(ByVal value As String)
            _Texto3 = value
        End Set
    End Property

    Public Property ToolTip() As String
        Get
            Return _ToolTip
        End Get
        Set(ByVal value As String)
            _ToolTip = value
        End Set
    End Property

    Public Property TheTypeOf() As String
        Get
            Return _TypeOf
        End Get
        Set(ByVal value As String)
            _TypeOf = value
        End Set
    End Property





#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
