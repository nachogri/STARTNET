Public Class MesaAyuda

#Region "Objetos privados"

#End Region

#Region "Propiedades"


    Private _Identificador As Integer
    Public Property Identificador() As Integer
        Get
            Return _Identificador
        End Get
        Set(ByVal value As Integer)
            _Identificador = value
        End Set
    End Property



    Private _Pregunta As String
    Public Property Pregunta() As String
        Get
            Return _Pregunta
        End Get
        Set(ByVal value As String)
            _Pregunta = value
        End Set
    End Property


    Private _PreguntaSI As Integer
    Public Property PreguntaSI() As Integer
        Get
            Return _PreguntaSI
        End Get
        Set(ByVal value As Integer)
            _PreguntaSI = value
        End Set
    End Property


    Private _PreguntaNO As Integer
    Public Property PreguntaNO() As Integer
        Get
            Return _PreguntaNO
        End Get
        Set(ByVal value As Integer)
            _PreguntaNO = value
        End Set
    End Property


    Private _Resolucion As Resolucion
    Public Property Resolucion() As Resolucion
        Get
            Return _Resolucion
        End Get
        Set(ByVal value As Resolucion)
            _Resolucion = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
