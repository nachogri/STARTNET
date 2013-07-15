Imports START_AD
Imports START_ENTIDADES

Public Class ResolucionMap
#Region "Objetos privados"
    Dim resolucionAD As resolucionAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef resolucion As resolucion) As Integer
        Return resolucionAD.Insertar(resolucion)
    End Function

    Public Function Actualizar(ByVal resolucion As resolucion) As Integer
        Return resolucionAD.Actualizar(resolucion)
    End Function

    Public Function Borrar(ByVal resolucion As resolucion) As Integer
        Return resolucionAD.Borrar(resolucion)
    End Function

    Public Function ConsultarPorId(ByRef id As Integer, Optional ByVal Lazy As Boolean = True) As Resolucion
        Return resolucionAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As resolucion, Optional ByVal Lazy As Boolean = True) As List(Of resolucion)
        Return resolucionAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of resolucion)
        Return resolucionAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        resolucionAD = New ResolucionAD
    End Sub
#End Region
End Class
