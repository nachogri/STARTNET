Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class ContactoLN
#Region "Objetos privados"
    Dim contactoMap As ContactoMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef contacto As Contacto) As Integer
        Return contactoMap.Insertar(contacto)
    End Function

    Public Function Actualizar(ByVal contacto As Contacto) As Integer
        Return contactoMap.Actualizar(contacto)
    End Function

    Public Function Borrar(ByVal contacto As Contacto) As Integer
        Return contactoMap.Borrar(contacto)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Contacto
        Return contactoMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Contacto, Optional ByVal Lazy As Boolean = True) As List(Of Contacto)
        Return contactoMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Contacto)
        Return contactoMap.ConsultarTodos(Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        contactoMap = New ContactoMap
    End Sub
#End Region
End Class
