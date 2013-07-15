Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class MesaAyudaLN
#Region "Objetos privados"
    Dim mesaAyudaMap As MesaAyudaMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef mesaAyuda As MesaAyuda) As Integer
        Return mesaAyudaMap.Insertar(mesaAyuda)        
    End Function

    Public Function Actualizar(ByVal mesaAyuda As MesaAyuda) As Integer
        Return mesaAyudaMap.Actualizar(mesaAyuda)
    End Function

    Public Function Borrar(ByVal mesaAyuda As MesaAyuda) As Integer
        Return mesaAyudaMap.Borrar(mesaAyuda)
    End Function

    Public Function ConsultarPorId(ByRef id As Integer, Optional ByVal Lazy As Boolean = True) As MesaAyuda
        Return mesaAyudaMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As MesaAyuda, Optional ByVal Lazy As Boolean = True) As List(Of MesaAyuda)
        Return mesaAyudaMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of MesaAyuda)
        Return mesaAyudaMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        mesaAyudaMap = New MesaAyudaMap
    End Sub
#End Region
End Class
