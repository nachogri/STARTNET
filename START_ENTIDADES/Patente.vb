Public Class Patente
#Region "Objetos privados"
    Dim _Identificador As Guid
    Dim _Descripcion As String
    Dim _Habilitaciones As List(Of Habilitacion)
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

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Habilitaciones() As List(Of Habilitacion)
        Get
            Return _Habilitaciones
        End Get
        Set(ByVal value As List(Of Habilitacion))
            _Habilitaciones = value
        End Set
    End Property


    Private _Familias As List(Of Familia)
    Public Property Familias() As List(Of Familia)
        Get
            Return _Familias
        End Get
        Set(ByVal value As List(Of Familia))
            _Familias = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class
