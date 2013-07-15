Public NotInheritable Class DateHelper
    Public Shared Function ConvertirStringToDate(ByVal fecha As String) As Date
        Dim culture As New System.Globalization.CultureInfo("es-AR")
        Dim dateTimeFormat As New System.Globalization.DateTimeFormatInfo
        dateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        culture.DateTimeFormat = dateTimeFormat

        Return Convert.ToDateTime(fecha, culture)
    End Function

    Public Shared Function IsNullDate(ByVal fecha As String) As Boolean
        If fecha = "12:00:00 AM" Or fecha = "0:00:00" Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
