
Imports START_AD
Imports START_ENTIDADES

Public Class usuarioMap
#Region "Objetos privados"
    Dim usuarioAD As usuarioAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef usuario As usuario) As Integer
        Dim res As Integer = usuarioAD.Insertar(usuario)

        If res > 0 Then
            If Not usuario.Patentes Is Nothing Then
                Dim usuarioPatenteAD As New UsuarioPatenteAD
                usuarioPatenteAD.Insertar(usuario)
            End If

            If Not usuario.Familias Is Nothing Then
                Dim usuarioFamiliaAD As New UsuarioFamiliaAD
                usuarioFamiliaAD.Insertar(usuario)
            End If
        End If

        Return res
    End Function

    Public Function Actualizar(ByVal usuario As usuario) As Integer
        Dim res As Integer = usuarioAD.Actualizar(usuario)

        If res > 0 Then
            If Not usuario.Patentes Is Nothing Then
                Dim usuarioPatenteAD As New UsuarioPatenteAD
                usuarioPatenteAD.Actualizar(usuario)
            End If

            If Not usuario.Familias Is Nothing Then
                Dim usuarioFamiliaAD As New UsuarioFamiliaAD
                usuarioFamiliaAD.Actualizar(usuario)
            End If
        End If

        Return res
    End Function

    Public Function Borrar(ByVal usuario As usuario) As Integer
        Dim res As Integer = usuarioAD.Borrar(usuario)

        If res > 0 Then
            If Not usuario.Patentes Is Nothing Then
                Dim usuarioPatenteAD As New UsuarioPatenteAD
                usuarioPatenteAD.Borrar(usuario)
            End If

            If Not usuario.Familias Is Nothing Then
                Dim usuarioFamiliaAD As New UsuarioFamiliaAD
                usuarioFamiliaAD.BorrarPorUsuario(usuario)
            End If            
        End If

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As usuario
        Dim usuario As Usuario = usuarioAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim familiaAD = New FamiliaAD
            usuario.Familias = familiaAD.ConsultarPorUsuario(usuario, Lazy)

            Dim patentesAD = New PatenteAD
            usuario.Patentes = patentesAD.ConsultarPorUsuario(usuario, Lazy)
        End If

        Return usuario
    End Function

    Public Function ConsultarPor(ByVal filtros As usuario, Optional ByVal Lazy As Boolean = True) As List(Of usuario)
        Dim usuarios As List(Of Usuario) = usuarioAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each usu As Usuario In usuarios
                Dim familiaAD = New FamiliaAD
                usu.Familias = familiaAD.ConsultarPorUsuario(usu, Lazy)

                Dim patentesAD = New PatenteAD
                usu.Patentes = patentesAD.ConsultarPorUsuario(usu, Lazy)
            Next
        End If

        Return usuarios
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of usuario)
        Dim usuarios As List(Of Usuario) = usuarioAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each usu As Usuario In usuarios
                Dim familiaAD = New FamiliaAD
                usu.Familias = familiaAD.ConsultarPorUsuario(usu, Lazy)

                Dim patentesAD = New PatenteAD
                usu.Patentes = patentesAD.ConsultarPorUsuario(usu, Lazy)
            Next
        End If

        Return usuarios
    End Function

    Public Function ConsultarPorFamilia(ByVal familia As Familia, Optional ByVal Lazy As Boolean = True) As List(Of Usuario)
        Dim usuarios As List(Of Usuario) = usuarioAD.ConsultarPorFamilia(familia, Lazy)

        If Not Lazy Then
            For Each usu As Usuario In usuarios
                Dim familiaAD = New FamiliaAD
                usu.Familias = familiaAD.ConsultarPorUsuario(usu, Lazy)

                Dim patentesAD = New PatenteAD
                usu.Patentes = patentesAD.ConsultarPorUsuario(usu, Lazy)
            Next
        End If

        Return usuarios
    End Function

    Public Function ConsultarPorNickname(ByVal nickname As String, Optional ByVal Lazy As Boolean = True) As Usuario
        Dim usuario As Usuario = usuarioAD.ConsultarPorNickname(nickname, Lazy)

        If Not Lazy Then
            Dim familiaMap = New familiaMap
            usuario.Familias = familiaMap.ConsultarPorUsuario(usuario, Lazy)

            Dim patentesMap = New patenteMap
            usuario.Patentes = patentesMap.ConsultarPorUsuario(usuario, Lazy)
        End If

        Return usuario    
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        usuarioAD = New UsuarioAD
    End Sub
#End Region
End Class
