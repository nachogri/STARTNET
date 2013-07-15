Imports START_AD
Imports START_ENTIDADES

Public Class SeguimientoMap
#Region "Objetos privados"
    Dim seguimientoAD As SeguimientoAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef seguimiento As Seguimiento) As Integer
        Return seguimientoAD.Insertar(seguimiento)
    End Function

    Public Function Actualizar(ByVal seguimiento As Seguimiento) As Integer
        Return seguimientoAD.Actualizar(seguimiento)
    End Function

    Public Function Borrar(ByVal seguimiento As Seguimiento) As Integer
        Return seguimientoAD.Borrar(seguimiento)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Seguimiento
        Return seguimientoAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Seguimiento, Optional ByVal Lazy As Boolean = True) As List(Of Seguimiento)
        Return seguimientoAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Seguimiento)
        Return seguimientoAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        seguimientoAD = New SeguimientoAD
    End Sub
#End Region
End Class
