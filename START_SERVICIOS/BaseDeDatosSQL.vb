Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient


Public Class BaseDeDatosSQL

#Region "Objetos privados"

    Dim _connectionString As String

#End Region

#Region "Constructores"

    Public Sub New()
        _connectionString = My.Settings("START_AD_ConnectionString")

    End Sub

#End Region

#Region "Propiedades"

     Public Property ConnectionString() As String
        Get
            Return _connectionString
        End Get
        Set(ByVal value As String)
            _connectionString = value
        End Set
    End Property

#End Region

#Region "Metodos privados"

    Private Sub AsignarParametros(ByVal cmd As SqlCommand, ByVal cmdParameters As List(Of SqlParameter))
        If (cmdParameters Is Nothing) Then Exit Sub
        For Each p As SqlParameter In cmdParameters
            cmd.Parameters.Add(p)
        Next
    End Sub

#End Region

#Region "EjecutarInstruccion "

    Public Function EjecutarInstruccion(ByVal cmd As String, ByVal cmdType As CommandType, Optional ByVal parameters As List(Of SqlParameter) = Nothing) As Integer
        Dim connection As SqlConnection = Nothing
        Dim transaction As SqlTransaction = Nothing
        Dim command As SqlCommand = Nothing
        Dim res As Integer = -1
        Try
            connection = New SqlConnection(_connectionString)
            command = New SqlCommand(cmd, connection)
            command.CommandType = cmdType
            Me.AsignarParametros(command, parameters)
            connection.Open()
            transaction = connection.BeginTransaction()
            command.Transaction = transaction
            res = command.ExecuteNonQuery()
            transaction.Commit()
        Catch ex As Exception
            If Not (transaction Is Nothing) Then
                transaction.Rollback()
            End If
            Throw ex
        Finally
            If Not (connection Is Nothing) AndAlso (connection.State = ConnectionState.Open) Then connection.Close()
            If Not (command Is Nothing) Then command.Dispose()
            If Not (transaction Is Nothing) Then transaction.Dispose()
        End Try
        Return res
    End Function

    Public Function EjecutarInstruccion(ByVal spname As String, ByVal parameterValues As List(Of SqlParameter)) As Integer
        Dim connection As SqlConnection = Nothing
        Dim transaction As SqlTransaction = Nothing
        Dim command As SqlCommand = Nothing
        Dim res As Integer = -1
        Try
            connection = New SqlConnection(_connectionString)
            command = New SqlCommand(spname, connection)
            command.CommandType = CommandType.StoredProcedure
            connection.Open()            
            Me.AsignarParametros(command, parameterValues)
            transaction = connection.BeginTransaction()
            command.Transaction = transaction
            res = command.ExecuteNonQuery()
            transaction.Commit()
        Catch ex As Exception
            If Not (transaction Is Nothing) Then
                transaction.Rollback()
            End If
            Throw ex
        Finally
            If Not (connection Is Nothing) AndAlso (connection.State = ConnectionState.Open) Then connection.Close()
            If Not (command Is Nothing) Then command.Dispose()
            If Not (transaction Is Nothing) Then transaction.Dispose()
        End Try
        Return res
    End Function

    Public Function EjecutarInstruccionesEnTransaccion(ByVal cmds As List(Of SqlCommand)) As Integer
        Dim connection As SqlConnection = Nothing
        Dim transaction As SqlTransaction = Nothing

        Dim res As Integer = -1
        Try
            connection = New SqlConnection(_connectionString)
            connection.Open()
            transaction = connection.BeginTransaction()

            For Each command As SqlCommand In cmds
                command.Connection = connection
                command.Transaction = transaction
                res = command.ExecuteNonQuery()
            Next

            transaction.Commit()
        Catch ex As Exception
            If Not (transaction Is Nothing) Then
                transaction.Rollback()
            End If
            Throw ex
        Finally
            If Not (connection Is Nothing) AndAlso (connection.State = ConnectionState.Open) Then connection.Close()
            If Not (transaction Is Nothing) Then transaction.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "EjecutarEscalar "

    Public Function EjecutarEscalar(ByVal cmd As String, ByVal cmdType As CommandType, Optional ByVal parameters As List(Of SqlParameter) = Nothing) As Object
        Dim connection As SqlConnection = Nothing
        Dim transaction As SqlTransaction = Nothing
        Dim command As SqlCommand = Nothing
        Dim res As Object = Nothing
        Try
            connection = New SqlConnection(_connectionString)
            command = New SqlCommand(cmd, connection)
            command.CommandType = cmdType
            Me.AsignarParametros(command, parameters)
            connection.Open()
            transaction = connection.BeginTransaction()
            command.Transaction = transaction
            res = command.ExecuteScalar()
            transaction.Commit()
        Catch ex As Exception
            If Not (transaction Is Nothing) Then
                transaction.Rollback()
            End If
            Throw ex
        Finally
            If Not (connection Is Nothing) AndAlso (connection.State = ConnectionState.Open) Then connection.Close()
            If Not (command Is Nothing) Then command.Dispose()
            If Not (transaction Is Nothing) Then transaction.Dispose()
        End Try
        Return res
    End Function

    Public Function EjecutarEscalar(ByVal spname As String, ByVal parameterValues As List(Of SqlParameter)) As Object
        Dim connection As SqlConnection = Nothing
        Dim transaction As SqlTransaction = Nothing
        Dim command As SqlCommand = Nothing
        Dim res As Object = Nothing
        Try
            connection = New SqlConnection(_connectionString)
            command = New SqlCommand(spname, connection)
            command.CommandType = CommandType.StoredProcedure
            connection.Open()
            SqlCommandBuilder.DeriveParameters(command)
            Me.AsignarParametros(command, parameterValues)
            transaction = connection.BeginTransaction()
            command.Transaction = transaction
            res = command.ExecuteScalar()
            transaction.Commit()
        Catch ex As Exception
            If Not (transaction Is Nothing) Then
                transaction.Rollback()
            End If
            Throw ex
        Finally
            If Not (connection Is Nothing) AndAlso (connection.State = ConnectionState.Open) Then connection.Close()
            If Not (command Is Nothing) Then command.Dispose()
            If Not (transaction Is Nothing) Then transaction.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "ConsultarReader "

    Public Function ConsultarReader(ByVal cmd As String, ByVal cmdType As CommandType, Optional ByVal parameters As List(Of SqlParameter) = Nothing) As IDataReader
        Dim connection As SqlConnection = Nothing
        Dim command As SqlCommand = Nothing
        Dim res As SqlDataReader = Nothing
        Try
            connection = New SqlConnection(_connectionString)
            command = New SqlCommand(cmd, connection)
            command.CommandType = cmdType
            Me.AsignarParametros(command, parameters)
            connection.Open()
            res = command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            Throw ex
       
        End Try
        Return CType(res, IDataReader)
    End Function

    Public Function ConsultarReader(ByVal spname As String, Optional ByVal parameterValues As List(Of SqlParameter) = Nothing) As IDataReader
        Dim connection As SqlConnection = Nothing
        Dim command As SqlCommand = Nothing
        Dim res As SqlDataReader = Nothing
        Try
            connection = New SqlConnection(ConnectionString)
            command = New SqlCommand(spname, connection)
            command.CommandType = CommandType.StoredProcedure
            connection.Open()

            Me.AsignarParametros(command, parameterValues)
            res = command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            Throw ex        
        End Try
        Return CType(res, IDataReader)
    End Function

#End Region

#Region "ConsultarDataset "

    Public Function LlenarDataset(ByVal cmd As String, ByVal cmdType As CommandType, Optional ByVal parameters As List(Of SqlParameter) = Nothing) As DataSet
        Dim connection As SqlConnection = Nothing
        Dim command As SqlCommand = Nothing
        Dim sqlda As SqlDataAdapter = Nothing
        Dim res As New DataSet
        Try
            connection = New SqlConnection(_connectionString)
            command = New SqlCommand(cmd, connection)
            command.CommandType = cmdType
            AsignarParametros(command, parameters)
            sqlda = New SqlDataAdapter(command)
            sqlda.Fill(res)
        Catch ex As Exception
            Throw ex
        Finally
            If Not (connection Is Nothing) AndAlso (connection.State = ConnectionState.Open) Then connection.Close()
            If Not (connection Is Nothing) Then connection.Dispose()
            If Not (command Is Nothing) Then command.Dispose()
            If Not (sqlda Is Nothing) Then sqlda.Dispose()
        End Try
        Return res
    End Function

#End Region

End Class
