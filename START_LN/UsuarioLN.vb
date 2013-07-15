Imports START_MAPEADORES
Imports START_ENTIDADES

Public Class UsuarioLN
#Region "Objetos privados"
    Dim usuarioMap As usuarioMap
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef usuario As Usuario) As Integer
        Return usuarioMap.Insertar(usuario)
    End Function

    Public Function Actualizar(ByVal usuario As Usuario) As Integer
        Return usuarioMap.Actualizar(usuario)
    End Function

    Public Function Borrar(ByVal usuario As Usuario) As Integer
        Return usuarioMap.Borrar(usuario)
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Usuario
        Return usuarioMap.ConsultarPorId(id, Lazy)
    End Function

    Public Function ConsultarPor(ByVal filtros As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Usuario)
        Return usuarioMap.ConsultarPor(filtros, Lazy)
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Usuario)
        Return usuarioMap.ConsultarTodos(Lazy)
    End Function

    Public Function ConsultarPorFamilia(ByVal familia As Familia, Optional ByVal Lazy As Boolean = True) As List(Of Usuario)
        Return usuarioMap.ConsultarPorFamilia(familia, Lazy)
    End Function

    Public Function ConsultarPorNickname(ByRef nickname As String, Optional ByVal Lazy As Boolean = True) As Usuario
        Return usuarioMap.ConsultarPorNickname(nickname, Lazy)
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        usuarioMap = New usuarioMap
    End Sub
#End Region
End Class

