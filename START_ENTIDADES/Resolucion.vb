Public Class Resolucion


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



    Private _Solucion As String
    Public Property Solucion() As String
        Get
            Return _Solucion
        End Get
        Set(ByVal value As String)
            _Solucion = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
