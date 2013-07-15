Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class ResolucionLN
#Region "Objetos privados"
    Dim resolucionMap As ResolucionMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef resolucion As Resolucion) As Integer
        Return resolucionMap.Insertar(resolucion)
    End Function

    Public Function Actualizar(ByVal resolucion As Resolucion) As Integer
        Return resolucionMap.Actualizar(resolucion)
    End Function

    Public Function Borrar(ByVal resolucion As Resolucion) As Integer
        Return resolucionMap.Borrar(resolucion)
    End Function

    Public Function ConsultarPorId(ByRef id As Integer, Optional ByVal Lazy As Boolean = True) As Resolucion
        Return resolucionMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Resolucion, Optional ByVal Lazy As Boolean = True) As List(Of Resolucion)
        Return resolucionMap.ConsultarPor(filtros, Lazy)        
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Resolucion)
        Return resolucionMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        resolucionMap = New ResolucionMap
    End Sub
#End Region
End Class
