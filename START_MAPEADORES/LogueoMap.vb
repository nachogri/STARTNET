Imports START_AD
Imports START_ENTIDADES

Public Class logueoMap
#Region "Objetos privados"
    Dim logueoAD As logueoAD
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef logueo As logueo) As Integer
        Dim res As Integer = logueoAD.Insertar(logueo)
        Return res
    End Function

    Public Function Actualizar(ByVal logueo As logueo) As Integer
        Dim res As Integer = logueoAD.Actualizar(logueo)

        Return res
    End Function

    Public Function Borrar(ByVal logueo As logueo) As Integer
        Dim res As Integer = logueoAD.Borrar(logueo)

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As logueo
        Dim logueo As Logueo = logueoAD.ConsultarPorId(id, Lazy)

        If Not Lazy Then
            Dim navegacionAD = New NavegacionAD
            logueo.Navegaciones = navegacionAD.ConsultarPorLogueo(logueo, Lazy)
            Dim seguimientoAD = New SeguimientoAD
            logueo.Seguimientos = seguimientoAD.ConsultarPorLogueo(logueo, Lazy)
        End If

        Return logueo
    End Function

    Public Function ConsultarPor(ByVal filtros As Logueo, Optional ByVal Lazy As Boolean = True) As List(Of Logueo)
        Dim logueos As List(Of Logueo) = logueoAD.ConsultarPor(filtros, Lazy)

        If Not Lazy Then
            For Each logueo As Logueo In logueos
                'Dim navegacionAD = New NavegacionAD
                'logueo.Navegaciones = navegacionAD.ConsultarPorLogueo(logueo, Lazy)
                Dim seguimientoAD = New SeguimientoAD
                logueo.Seguimientos = seguimientoAD.ConsultarPorLogueo(logueo)
            Next
        End If

        Return logueos
    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Logueo)
        Dim logueos As List(Of Logueo) = logueoAD.ConsultarTodos(Lazy)

        If Not Lazy Then
            For Each logueo As Logueo In logueos
                Dim navegacionAD = New NavegacionAD
                logueo.Navegaciones = navegacionAD.ConsultarPorLogueo(logueo, Lazy)
                Dim seguimientoAD = New SeguimientoAD
                logueo.Seguimientos = seguimientoAD.ConsultarPorLogueo(logueo, Lazy)
            Next
        End If

        Return logueos
    End Function

#End Region

#Region "Constructores"
    Public Sub New()
        logueoAD = New logueoAD
    End Sub
#End Region
End Class


