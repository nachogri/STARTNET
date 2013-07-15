Imports START_ENTIDADES
Imports START_MAPEADORES

Public Class RegistroEmailLN
#Region "Objetos privados"
    Dim registroEmailMap As New RegistroEmailMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef usuario As Usuario) As Guid
        Return registroEmailMap.Insertar(usuario)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid) As Usuario
        Return registroEmailMap.ConsultarPorId(id)
    End Function
#End Region

End Class
