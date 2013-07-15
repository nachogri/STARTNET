Imports START_AD
Imports START_ENTIDADES

Public Class DomicilioMap
#Region "Objetos privados"
    Dim DomicilioAD As DomicilioAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef Domicilio As Domicilio) As Integer
        Return DomicilioAD.Insertar(Domicilio)
    End Function

    Public Function Actualizar(ByVal Domicilio As Domicilio) As Integer
        Return DomicilioAD.Actualizar(Domicilio)
    End Function

    Public Function Borrar(ByVal Domicilio As Domicilio) As Integer
        Return DomicilioAD.Borrar(Domicilio)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Domicilio
        Return DomicilioAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Domicilio, Optional ByVal Lazy As Boolean = True) As List(Of Domicilio)
        Return DomicilioAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Domicilio)
        Return DomicilioAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        DomicilioAD = New DomicilioAD
    End Sub
#End Region
End Class
