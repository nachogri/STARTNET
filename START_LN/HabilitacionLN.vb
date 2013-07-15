Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class HabilitacionLN
#Region "Objetos privados"
    Dim habilitacionMap As HabilitacionMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"

    Public Function ConsultarPorPatente(ByVal patente As Patente, Optional ByVal Lazy As Boolean = True) As List(Of Habilitacion)
        Return habilitacionMap.ConsultarPorPatente(patente, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Habilitacion)
        Return habilitacionMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        habilitacionMap = New HabilitacionMap
    End Sub
#End Region
End Class
