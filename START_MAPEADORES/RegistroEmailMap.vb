Imports START_ENTIDADES
Imports START_AD

Public Class RegistroEmailMap
#Region "Objetos privados"
    Dim registroEmailAD As New RegistroEmailAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef usuario As Usuario) As Guid
        Return registroEmailAD.Insertar(usuario)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid) As Usuario
        Return registroEmailAD.ConsultarPorId(id)
    End Function
#End Region

End Class
