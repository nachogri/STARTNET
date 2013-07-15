Imports START_ENTIDADES
Imports System.Data.SqlClient
Imports System.Xml

Public Class PromocionAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef promocion As Promocion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            promocion.Identificador = Guid.NewGuid
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppromo_id", promocion.Identificador))
            parametros.Add(New SqlParameter("@ppromo_nombre", promocion.Nombre))
            parametros.Add(New SqlParameter("@ppromo_expiracion", promocion.Expiracion))
            parametros.Add(New SqlParameter("@ppromo_requisitos", promocion.Requisitos))

            res = base.EjecutarInstruccion("SP_Promociones_Insertar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Actualizar(ByVal promocion As Promocion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppromo_id", promocion.Identificador))
            parametros.Add(New SqlParameter("@ppromo_nombre", promocion.Nombre))
            parametros.Add(New SqlParameter("@ppromo_expiracion", promocion.Expiracion))
            parametros.Add(New SqlParameter("@ppromo_requisitos", promocion.Requisitos))

            res = base.EjecutarInstruccion("SP_Promociones_Actualizar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function Borrar(ByVal promocion As Promocion) As Integer
        Dim res As Integer = -1
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppromo_id", promocion.Identificador))

            res = base.EjecutarInstruccion("SP_Promociones_Borrar", parametros)
        Catch ex As Exception
            Throw ex
        Finally
            base = Nothing
            parametros = Nothing
        End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Guid, Optional ByVal Lazy As Boolean = True) As Promocion
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@ppromo_id", id))

            reader = base.ConsultarReader("SP_Promociones_Consultar", parametros)
            reader.Read()

            Dim promocion As New Promocion
            promocion.Identificador = reader(0)
            promocion.Nombre = reader(1)
            promocion.Expiracion = reader(2)
            promocion.Requisitos = reader(3)
            If Not reader Is Nothing Then reader.Close()

            Return promocion
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As Promocion, Optional ByVal Lazy As Boolean = True) As List(Of Promocion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            parametros = New List(Of SqlParameter)


            parametros.Add(New SqlParameter("@ppromo_nombre", filtros.Nombre))
            parametros.Add(New SqlParameter("@ppromo_expiracion", filtros.Expiracion))
            parametros.Add(New SqlParameter("@ppromo_requisitos", filtros.Requisitos))


            reader = base.ConsultarReader("SP_Promociones_ConsultarPor", parametros)

            Dim promocions As New List(Of Promocion)
            Do While reader.Read()
                Dim promocion As New Promocion
                promocion.Identificador = reader(0)
                promocion.Nombre = reader(1)
                promocion.Expiracion = reader(2)
                promocion.Requisitos = reader(3)

                promocions.Add(promocion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return promocions

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of Promocion)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_Promociones_ConsultarTodos")

            Dim promocions As New List(Of Promocion)
            Do While reader.Read()
                Dim promocion As New Promocion
                promocion.Identificador = reader(0)
                promocion.Nombre = reader(1)
                promocion.Expiracion = reader(2)
                promocion.Requisitos = reader(3)

                promocions.Add(promocion)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return promocions
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarVigentes() As XmlDocument
        Dim xPromociones As New XmlDocument()
        Dim xWriter As New XmlTextWriter(My.Settings("START_XML_PATH").ToString(), Text.Encoding.UTF8)

        base = New START_SERVICIOS.BaseDeDatosSQL()
        reader = base.ConsultarReader("SP_Promociones_ConsultarVigentes")

        xWriter.Formatting = Formatting.Indented
        xWriter.WriteStartDocument()
        xWriter.WriteComment("Estas son las promos vigentes")
        xWriter.WriteStartElement("Promociones")

        Dim promocions As New List(Of Promocion)
        Do While reader.Read()
            xWriter.WriteStartElement("Promocion")
            xWriter.WriteAttributeString("id", reader(0).ToString())
            xWriter.WriteStartElement("nombre", "")
            xWriter.WriteString(reader(1))
            xWriter.WriteEndElement()
            xWriter.WriteStartElement("expiracion", "")
            xWriter.WriteString(reader(2))
            xWriter.WriteEndElement()
            xWriter.WriteStartElement("requisitos", "")
            xWriter.WriteString(reader(3))
            xWriter.WriteEndElement()
        Loop
        xWriter.WriteEndElement()
        xWriter.WriteEndDocument()
        xWriter.Flush()
        xWriter.Close()

        xPromociones.Load(My.Settings("START_XML_PATH").ToString())

        Return xPromociones
    End Function
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

End Class

