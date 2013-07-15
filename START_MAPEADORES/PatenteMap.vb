Imports START_AD
Imports START_ENTIDADES

Public Class patenteMap
#Region "Objetos privados"
    Dim patenteAD As patenteAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef patente As patente) As Integer
        Return PatenteAD.Insertar(Patente)
    End Function

    Public Function Actualizar(ByVal patente As patente) As Integer
        Return PatenteAD.Actualizar(Patente)
    End Function

    Public Function Borrar(ByVal patente As patente) As Integer
        Return PatenteAD.Borrar(Patente)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As patente
        Dim patente As Patente = patenteAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim habilitacionAD As New HabilitacionAD
            patente.Habilitaciones = habilitacionAD.ConsultarPorPatente(patente, Lazy)
        End If

        Return patente
    End Function

    Public Function ConsultarPor(ByVal filtros As patente, Optional ByVal Lazy As Boolean = True) As List(Of patente)
        Dim patentes As List(Of Patente) = PatenteAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each patente As Patente In patentes
                Dim habilitacionAD As New HabilitacionAD
                patente.Habilitaciones = habilitacionAD.ConsultarPorPatente(patente, Lazy)
            Next
        End If

        Return patentes
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of patente)
        Dim patentes As List(Of Patente) = PatenteAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each patente As Patente In patentes
                Dim habilitacionAD As New HabilitacionAD
                patente.Habilitaciones = habilitacionAD.ConsultarPorPatente(patente, Lazy)
            Next
        End If

        Return patentes
    End Function

    Public Function ConsultarPorFamilia(ByVal familia As Familia, Optional ByVal Lazy As Boolean = True) As List(Of Patente)
        Dim patentes As List(Of Patente) = patenteAD.ConsultarPorFamilia(familia, Lazy)

        If Not Lazy Then
            For Each patente As Patente In patentes
                Dim habilitacionAD As New HabilitacionAD
                patente.Habilitaciones = habilitacionAD.ConsultarPorPatente(patente)
            Next
        End If

        Return patentes
    End Function

    Public Function ConsultarPorUsuario(ByVal usuario As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Patente)
        Dim patentes As List(Of Patente) = patenteAD.ConsultarPorUsuario(usuario, Lazy)

        If Not Lazy Then
            For Each patente As Patente In patentes
                Dim habilitacionAD As New HabilitacionAD
                patente.Habilitaciones = habilitacionAD.ConsultarPorPatente(patente, Lazy)
            Next
        End If

        Return patentes
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        PatenteAD = New PatenteAD
    End Sub
#End Region
End Class


