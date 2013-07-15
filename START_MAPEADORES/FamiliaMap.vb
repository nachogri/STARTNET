Imports START_AD
Imports START_ENTIDADES

Public Class familiaMap
#Region "Objetos privados"
    Dim familiaAD As familiaAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef familia As familia) As Integer
        Dim res As Integer = familiaAD.Insertar(familia)

        If res > 0 Then
            If Not familia.Patentes Is Nothing Then
                Dim familiaPatenteAD As New FamiliaPatenteAD
                familiaPatenteAD.Insertar(familia)
            End If            
        End If

        Return res
    End Function

    Public Function Actualizar(ByVal familia As familia) As Integer
        Dim res As Integer = familiaAD.Actualizar(familia)

        If res > 0 Then
            Dim familiaPatenteAD As New FamiliaPatenteAD
            familiaPatenteAD.Actualizar(familia)
        End If

        Return res
    End Function

    Public Function Borrar(ByVal familia As familia) As Integer
        Dim res As Integer = familiaAD.Borrar(familia)

        If res > 0 Then
            Dim usuariofamiliaAD As New UsuarioFamiliaAD
            usuariofamiliaAD.BorrarPorFamilia(familia)

            Dim familiaPatenteAD As New FamiliaPatenteAD
            familiaPatenteAD.Borrar(familia)
        End If

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As familia
        Dim familia As Familia = familiaAD.ConsultarPorId(id)

        If Not Lazy Then
            Dim patenteMAP = New patenteMap
            familia.Patentes = patenteMAP.ConsultarPorFamilia(familia)
            Dim usuarioAD = New UsuarioAD
            familia.Usuarios = usuarioAD.ConsultarPorFamilia(familia)
        End If

        Return familia
    End Function

    Public Function ConsultarPor(ByVal filtros As familia, Optional ByVal Lazy As Boolean = True) As List(Of familia)
        Dim familias As List(Of Familia) = FamiliaAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each familia As Familia In familias
                Dim patenteMAP = New patenteMap
                familia.Patentes = patenteMAP.ConsultarPorFamilia(familia, Lazy)
                Dim usuarioAD = New UsuarioAD
                familia.Usuarios = usuarioAD.ConsultarPorFamilia(familia, Lazy)
            Next
        End If

        Return familias
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of familia)
        Dim familias As List(Of Familia) = FamiliaAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each familia As Familia In familias
                Dim patenteMAP = New patenteMap
                familia.Patentes = patenteMAP.ConsultarPorFamilia(familia, Lazy)
                Dim usuarioAD = New UsuarioAD
                familia.Usuarios = usuarioAD.ConsultarPorFamilia(familia, Lazy)
            Next
        End If

        Return familias
    End Function

    Public Function ConsultarPorUsuario(ByVal usuario As Usuario, Optional ByVal Lazy As Boolean = True) As List(Of Familia)
        Dim familias As List(Of Familia) = familiaAD.ConsultarPorUsuario(usuario, Lazy)

        If Not Lazy Then
            For Each familia As Familia In familias
                Dim patenteMAP = New patenteMap
                familia.Patentes = patenteMAP.ConsultarPorFamilia(familia, Lazy)
                Dim usuarioAD = New UsuarioAD
                familia.Usuarios = usuarioAD.ConsultarPorFamilia(familia, Lazy)
            Next
        End If

        Return familias
    End Function
#End Region

#Region "Constructores"
    Public Sub New()
        FamiliaAD = New FamiliaAD
    End Sub
#End Region
End Class


