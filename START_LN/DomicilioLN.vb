Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class DomicilioLN
#Region "Objetos privados"
    Dim DomicilioMap As DomicilioMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef Domicilio As Domicilio) As Integer
        Return DomicilioMap.Insertar(Domicilio)
    End Function

    Public Function Actualizar(ByVal Domicilio As Domicilio) As Integer
        Return DomicilioMap.Actualizar(Domicilio)
    End Function

    Public Function Borrar(ByVal Domicilio As Domicilio) As Integer
        Return DomicilioMap.Borrar(Domicilio)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Domicilio
        Return DomicilioMap.ConsultarPorId(id, Lazy)

    End Function

    Public Function ConsultarPor(ByVal filtros As Domicilio, Optional ByVal Lazy As Boolean = True) As List(Of Domicilio)
        Return DomicilioMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Domicilio)
        Return DomicilioMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        DomicilioMap = New DomicilioMap
    End Sub
#End Region
End Class
