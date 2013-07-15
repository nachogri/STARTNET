Imports START_ENTIDADES
Imports System.Data.SqlClient

Public Class MesaAyudaAD

#Region "Objetos privados"
    Dim base As START_SERVICIOS.BaseDeDatosSQL
    Dim parametros As List(Of SqlParameter)
    Dim reader As SqlDataReader
#End Region

#Region "Propiedades"

#End Region

#Region "Métodos"
    Public Function Insertar(ByRef mesaAyuda As MesaAyuda) As Integer
        Dim res As Integer = -1
        'Try
        '    base = New START_SERVICIOS.BaseDeDatosSQL()

        '    mesaAyuda.Identificador = Guid.NewGuid

        '    parametros = New List(Of SqlParameter)
        '    parametros.Add(New SqlParameter("@payu_id", mesaAyuda.Identificador))
        '    parametros.Add(New SqlParameter("@payu_pregunta", mesaAyuda.Pregunta))
        '    parametros.Add(New SqlParameter("@payu_psi", mesaAyuda.PreguntaSI))
        '    parametros.Add(New SqlParameter("@payu_pno", mesaAyuda.PreguntaNO))

        '    If Not mesaAyuda.Resolucion Is Nothing Then
        '        parametros.Add(New SqlParameter("@payu_ft_id", mesaAyuda.Resolucion.Identificador))
        '    Else
        '        parametros.Add(New SqlParameter("@payu_ft_id", DBNull.Value))
        '    End If


        '    res = base.EjecutarInstruccion("SP_MesaAyuda_Insertar", parametros)
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    base = Nothing
        '    parametros = Nothing
        'End Try

        Return res
    End Function

    Public Function Actualizar(ByVal mesaAyuda As MesaAyuda) As Integer
        Dim res As Integer = -1
        'Try
        '    base = New START_SERVICIOS.BaseDeDatosSQL()

        '    parametros = New List(Of SqlParameter)

        '    parametros = New List(Of SqlParameter)
        '    parametros.Add(New SqlParameter("@payu_id", mesaAyuda.Identificador))
        '    parametros.Add(New SqlParameter("@payu_pregunta", mesaAyuda.Pregunta))
        '    parametros.Add(New SqlParameter("@payu_psi", mesaAyuda.PreguntaSI))
        '    parametros.Add(New SqlParameter("@payu_pno", mesaAyuda.PreguntaNO))

        '    If Not mesaAyuda.Resolucion Is Nothing Then
        '        parametros.Add(New SqlParameter("@payu_ft_id", mesaAyuda.Resolucion.Identificador))
        '    Else
        '        parametros.Add(New SqlParameter("@payu_ft_id", DBNull.Value))
        '    End If


        '    res = base.EjecutarInstruccion("SP_MesaAyuda_Actualizar", parametros)
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    base = Nothing
        '    parametros = Nothing
        'End Try

        Return res
    End Function

    Public Function Borrar(ByVal mesaAyuda As MesaAyuda) As Integer
        Dim res As Integer = -1
        'Try
        '    base = New START_SERVICIOS.BaseDeDatosSQL()

        '    parametros = New List(Of SqlParameter)
        '    parametros.Add(New SqlParameter("@payu_id", mesaAyuda.Identificador))


        '    res = base.EjecutarInstruccion("SP_MesaAyuda_Borrar", parametros)
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    base = Nothing
        '    parametros = Nothing
        'End Try

        Return res
    End Function

    Public Function ConsultarPorId(ByRef id As Integer, Optional ByVal Lazy As Boolean = True) As MesaAyuda
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            Dim mesaAyuda As New MesaAyuda

          
            parametros = New List(Of SqlParameter)
            parametros.Add(New SqlParameter("@payu_id", id))

            reader = base.ConsultarReader("SP_MesaAyuda_Consultar", parametros)

            reader.Read()

            mesaAyuda.Identificador = reader(0)
            mesaAyuda.Pregunta = reader(1)
            Dim mesaAyudaAD As New MesaAyudaAD
            mesaAyuda.PreguntaSI = reader(2)
            mesaAyuda.PreguntaNO = reader(3)


            If Not reader(4) Is DBNull.Value Then
                Dim resolucionAD = New ResolucionAD
                mesaAyuda.Resolucion = resolucionAD.ConsultarPorId(reader(4))
            End If

            If Not reader Is Nothing Then reader.Close()

            Return mesaAyuda

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try
    End Function

    Public Function ConsultarPor(ByVal filtros As MesaAyuda, Optional ByVal Lazy As Boolean = True) As List(Of MesaAyuda)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()

            parametros = New List(Of SqlParameter)

            parametros.Add(New SqlParameter("@payu_pregunta", filtros.Pregunta))
            parametros.Add(New SqlParameter("@payu_psi", filtros.PreguntaSI))
            parametros.Add(New SqlParameter("@payu_pno", filtros.PreguntaNO))

            If Not filtros.Resolucion Is Nothing Then
                parametros.Add(New SqlParameter("@payu_ft_id", filtros.Resolucion.Identificador))
            Else
                parametros.Add(New SqlParameter("@payu_ft_id", DBNull.Value))
            End If


            reader = base.ConsultarReader("SP_MesaAyuda_ConsultarPor", parametros)

            Dim mesaAyudas As New List(Of MesaAyuda)
            Do While reader.Read()
                Dim mesaAyuda As New MesaAyuda
                mesaAyuda.Identificador = reader(0)
                mesaAyuda.Pregunta = reader(1)
                mesaAyuda.PreguntaSI = reader(2)
                mesaAyuda.PreguntaNO = reader(3)

                If Not reader(4) Is DBNull.Value Then
                    Dim resolucionAD = New ResolucionAD
                    mesaAyuda.Resolucion = resolucionAD.ConsultarPorId(reader(4))
                End If


                mesaAyudas.Add(mesaAyuda)
            Loop

            Return mesaAyudas

        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function

    Public Function ConsultarTodos(Optional ByVal Lazy As Boolean = True) As List(Of MesaAyuda)
        Try
            base = New START_SERVICIOS.BaseDeDatosSQL()
            reader = base.ConsultarReader("SP_MesaAyuda_ConsultarTodos")

            Dim mesaAyudas As New List(Of MesaAyuda)
            Do While reader.Read()
                Dim mesaAyuda As New MesaAyuda
                mesaAyuda.Identificador = reader(0)
                mesaAyuda.Pregunta = reader(1)
                mesaAyuda.PreguntaSI = reader(2)
                mesaAyuda.PreguntaNO = reader(3)


                Dim resolucionAD = New ResolucionAD
                mesaAyuda.Resolucion = resolucionAD.ConsultarPorId(reader(4))


                mesaAyudas.Add(mesaAyuda)
            Loop
            If Not reader Is Nothing Then reader.Close()

            Return mesaAyudas
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            base = Nothing
            parametros = Nothing
        End Try

    End Function
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region
End Class

