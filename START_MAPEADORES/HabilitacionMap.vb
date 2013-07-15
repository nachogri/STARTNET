Imports START_AD
Imports START_ENTIDADES

Public Class HabilitacionMap
#Region "Objetos privados"
    Dim habilitacionAD As HabilitacionAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function ConsultarPorPatente(ByVal patente As Patente, Optional ByVal Lazy As Boolean = True) As List(Of Habilitacion)
        Return habilitacionAD.ConsultarPorPatente(patente, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Habilitacion)
        Return habilitacionAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        habilitacionAD = New HabilitacionAD
    End Sub
#End Region
End Class
