<%@ WebHandler Language="VB" Class="hlrImageLoader" %>

Imports System
Imports System.Configuration
Imports System.Web
Imports System.IO
Imports START_ENTIDADES
Imports START_LN


Public Class hlrImageLoader : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim id As Guid
        Dim table As String
        If Not context.Request.QueryString("id") Is Nothing Then
            id = new Guid(context.Request.QueryString("id"))
            
        Else
            Throw New ArgumentException("No parameter specified")
        End If
        
        If Not context.Request.QueryString("Table") Is Nothing Then
            table = context.Request.QueryString("Table")
        Else
            Throw New ArgumentException("No parameter specified")
        End If
 
        context.Response.ContentType = "image/jpeg"
        Dim strm As Stream = ShowEmpImage(id, table)
        Dim buffer As Byte() = New Byte(4095) {}
        Dim byteSeq As Integer = strm.Read(buffer, 0, 4096)
 
        Do While byteSeq > 0
            context.Response.OutputStream.Write(buffer, 0, byteSeq)
            byteSeq = strm.Read(buffer, 0, 4096)
        Loop
        'context.Response.BinaryWrite(buffer);
    End Sub
 
    Public Function ShowEmpImage(ByVal id As guid, ByVal table As String) As Stream
             
        Dim img As Object
        Select Case table
            Case "Novedades"               
                Dim bizNovedad As New Novedad                
                Dim bizNovedadLN As New NovedadLN
                bizNovedad = bizNovedadLN.ConsultarPorId(id)
                img = bizNovedad.Imagen
                
            Case "Desarrolladores"
                Dim bizDesarrollador As New Desarrollador
                Dim bizDesarrolladorLN As New DesarrolladorLN
                bizDesarrollador = bizDesarrolladorLN.ConsultarPorId(id)
                img = bizDesarrollador.Imagen

            Case Else
                Dim bizProducto As New Producto
                Dim bizProductoLN As New ProductoLN
                bizProducto = bizProductoLN.ConsultarPorId(id)
                img = bizProducto.Imagen
        End Select
               
        Try
            Return New MemoryStream(CType(img, Byte()))
        Catch
            Return Nothing      
        End Try
    End Function
    
    
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class