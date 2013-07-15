Imports START_AD
Imports START_ENTIDADES

Public Class ContactoMap
#Region "Objetos privados"
    Dim contactoAD As ContactoAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef contacto As Contacto) As Integer
        Return contactoAD.Insertar(contacto)
    End Function

    Public Function Actualizar(ByVal contacto As Contacto) As Integer
        Return contactoAD.Actualizar(contacto)
    End Function

    Public Function Borrar(ByVal contacto As Contacto) As Integer
        Return contactoAD.Borrar(contacto)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Contacto
        Return contactoAD.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Contacto, Optional ByVal Lazy As Boolean = True) As List(Of Contacto)
        Return contactoAD.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Contacto)
        Return contactoAD.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        contactoAD = New ContactoAD
    End Sub
#End Region
End Class
