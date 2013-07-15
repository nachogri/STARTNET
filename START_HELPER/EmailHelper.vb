Public Class EmailHelper
    Public Function enviarEmail(ByVal pTo As String, ByVal pSubject As String, ByVal pBody As String) As Integer
        Try
            Dim SMTPServer As New System.Net.Mail.SmtpClient("smtp.gmail.com")
            SMTPServer.Port = 587
            SMTPServer.Credentials = New System.Net.NetworkCredential("nachogri@gmail.com", "innerspace")
            SMTPServer.EnableSsl = True
            SMTPServer.Send("nachogri@gmail.com", pTo, pSubject, pBody)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
