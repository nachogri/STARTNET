Public Class Encriptador
#Region "Objetos privados"

#End Region

#Region "Métodos"
    Public Shared Function Encriptar(ByVal pCadena As String, ByVal pModo As String) As String
        Dim i As Integer
        Dim Desviacion As Integer
        Dim SG_Encriptado As String = ""

        If pModo = "E" Or pModo = "D" Then
            Desviacion = 1 * (25 / 6) + 2 * 3999 / 8812 ' Factor de Desviacion para el encriptado
            If pModo = "E" Then 'Modo seleccionado: Encriptar
                For i = 1 To Len(pCadena)
                    SG_Encriptado = SG_Encriptado + Chr(Asc(Mid(pCadena, i, 1)) + Desviacion)
                    'Va acumulando en el resultado cada letra del string inicial,
                    'desde i hasta el próximo caracter, o sea, de a uno.
                    'A cada caracter a su vez lo transforma a ASCII y le agrega el
                    'factor de Desviación, y luego lo vuelve a transformar en Caracter.                    
                Next i
            ElseIf pModo = "D" Then 'Modo seleccionado: Desencriptar
                For i = 1 To Len(pCadena)
                    SG_Encriptado = SG_Encriptado + Chr(Asc(Mid(pCadena, i, 1)) - Desviacion)
                    'Realiza el proceso inverso.
                Next i
            End If
        End If

        Return SG_Encriptado
    End Function
#End Region
End Class
