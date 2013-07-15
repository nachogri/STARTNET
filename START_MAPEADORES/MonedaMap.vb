Imports START_AD
Imports START_ENTIDADES

Public Class MonedaMap
#Region "Objetos privados"
    Dim monedaAD As MonedaAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef moneda As Moneda) As Integer
        Return monedaAD.Insertar(moneda)
    End Function

    Public Function Actualizar(ByVal moneda As Moneda) As Integer
        Return monedaAD.Actualizar(moneda)
    End Function

    Public Function Borrar(ByVal moneda As Moneda) As Integer
        Return monedaAD.Borrar(moneda)
    End Function

    Public Function ConsultarPorId(ByRef id As Integer, Optional ByVal Lazy As Boolean = True) As Moneda
        Return monedaAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Moneda, Optional ByVal Lazy As Boolean = True) As List(Of Moneda)
        Return monedaAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Moneda)
        Return monedaAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        monedaAD = New MonedaAD
    End Sub
#End Region
End Class
