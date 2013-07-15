Public Class EncuestaSatisfaccion

    Private _Identificador As Guid
    Public Property Identificador() As Guid
        Get
            Return _Identificador
        End Get
        Set(ByVal value As Guid)
            _Identificador = value
        End Set
    End Property


    Private _Usuarios As Usuario
    Public Property Usuario() As Usuario
        Get
            Return _Usuarios
        End Get
        Set(ByVal value As Usuario)
            _Usuarios = value
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


    Private _Pregunta1 As Integer
    Public Property Pregunta1() As Integer
        Get
            Return _Pregunta1
        End Get
        Set(ByVal value As Integer)
            _Pregunta1 = value
        End Set
    End Property


    Private _Pregunta2 As Integer
    Public Property Pregunta2() As Integer
        Get
            Return _Pregunta2
        End Get
        Set(ByVal value As Integer)
            _Pregunta2 = value
        End Set
    End Property


    Private _Pregunta3 As Integer
    Public Property Pregunta3() As Integer
        Get
            Return _Pregunta3
        End Get
        Set(ByVal value As Integer)
            _Pregunta3 = value
        End Set
    End Property


    Private _Pregunta4 As Integer
    Public Property Pregunta4() As Integer
        Get
            Return _Pregunta4
        End Get
        Set(ByVal value As Integer)
            _Pregunta4 = value
        End Set
    End Property


    Private _Pregunta5 As Integer
    Public Property Pregunta5() As Integer
        Get
            Return _Pregunta5
        End Get
        Set(ByVal value As Integer)
            _Pregunta5 = value
        End Set
    End Property


    Private _Pregunta6 As Integer
    Public Property Pregunta6() As Integer
        Get
            Return _Pregunta6
        End Get
        Set(ByVal value As Integer)
            _Pregunta6 = value
        End Set
    End Property

End Class
