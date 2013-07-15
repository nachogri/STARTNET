Imports START_AD
Imports START_ENTIDADES

Public Class MesaAyudaMap
#Region "Objetos privados"
    Dim mesaAyudaAD As MesaAyudaAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef mesaAyuda As MesaAyuda) As Integer
        Return mesaAyudaAD.Insertar(mesaAyuda)
    End Function

    Public Function Actualizar(ByVal mesaAyuda As MesaAyuda) As Integer
        Return mesaAyudaAD.Actualizar(mesaAyuda)
    End Function

    Public Function Borrar(ByVal mesaAyuda As MesaAyuda) As Integer
        Return mesaAyudaAD.Borrar(mesaAyuda)
    End Function

    Public Function ConsultarPorId(ByRef id As Integer, Optional ByVal Lazy As Boolean = True) As MesaAyuda
        Return mesaAyudaAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As MesaAyuda, Optional ByVal Lazy As Boolean = True) As List(Of MesaAyuda)
        Return mesaAyudaAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of MesaAyuda)
        Return mesaAyudaAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        mesaAyudaAD = New MesaAyudaAD
    End Sub
#End Region
End Class
