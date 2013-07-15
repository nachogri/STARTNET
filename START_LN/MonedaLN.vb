Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class MonedaLN
#Region "Objetos privados"
    Dim monedaMap As MonedaMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef moneda As Moneda) As Integer
        Return monedaMap.Insertar(moneda)
    End Function

    Public Function Actualizar(ByVal moneda As Moneda) As Integer
        Return monedaMap.Actualizar(moneda)
    End Function

    Public Function Borrar(ByVal moneda As Moneda) As Integer
        Return monedaMap.Borrar(moneda)
    End Function

    Public Function ConsultarPorId(ByRef id As Integer, Optional ByVal Lazy As Boolean = True) As Moneda
        Return monedaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Moneda, Optional ByVal Lazy As Boolean = True) As List(Of Moneda)
        Return monedaMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Moneda)
        Return monedaMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        monedaMap = New MonedaMap
    End Sub
#End Region
End Class
