﻿Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

        Dim sCulture As String
        If Request.Cookies("lang") Is Nothing OrElse Request.Cookies("lang").Value Is Nothing Then
            If Not Request.QueryString("lang") Is Nothing Then
                sCulture = Request.QueryString("lang")
            Else
                sCulture = "ES"
            End If

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(sCulture)
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(sCulture)

            Dim cookie As HttpCookie = New HttpCookie("lang")
            cookie.Value = sCulture
            Response.SetCookie(cookie)
        Else
            If Not Request.QueryString("lang") Is Nothing Then
                sCulture = Request.QueryString("lang")
            Else
                sCulture = Request.Cookies("lang").Value
            End If

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(sCulture)
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(sCulture)

            Dim cookie As HttpCookie = Request.Cookies("lang")
            cookie.Value = sCulture
            Response.SetCookie(cookie)
        End If

    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class