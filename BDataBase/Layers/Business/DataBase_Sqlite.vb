﻿
'Copyright 2018 Kelvys B. Pantaleão

'This file is part of BDataBase

'BDataBase Is free software: you can redistribute it And/Or modify
'it under the terms Of the GNU General Public License As published by
'the Free Software Foundation, either version 3 Of the License, Or
'(at your option) any later version.

'This program Is distributed In the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty Of
'MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License For more details.

'You should have received a copy Of the GNU General Public License
'along with this program.  If Not, see <http://www.gnu.org/licenses/>.


'Este arquivo é parte Do programa BDataBase

'BDataBase é um software livre; você pode redistribuí-lo e/ou 
'modificá-lo dentro dos termos da Licença Pública Geral GNU como 
'publicada pela Fundação Do Software Livre (FSF); na versão 3 da 
'Licença, ou(a seu critério) qualquer versão posterior.

'Este programa é distribuído na esperança de que possa ser  útil, 
'mas SEM NENHUMA GARANTIA; sem uma garantia implícita de ADEQUAÇÃO
'a qualquer MERCADO ou APLICAÇÃO EM PARTICULAR. Veja a
'Licença Pública Geral GNU para maiores detalhes.

'Você deve ter recebido uma cópia da Licença Pública Geral GNU junto
'com este programa, Se não, veja <http://www.gnu.org/licenses/>.

'GitHub: https://github.com/Kelvysb/BDataBase

Imports BDataBase
Imports System.Data.SQLite
Imports System.Threading
Imports System.IO

Friend Class DataBase_Sqlite
    Inherits absDataBase
    Implements IDataBase

#Region "Definitions"
    Private objSqlConnection As SQLiteConnection
    Private objSqlCommand As SQLiteCommand
    Private objSqlDataAdapter As SQLiteDataAdapter
    Private objSqlTransact As SQLiteTransaction
#End Region

#Region "Constructor"
    Friend Sub New(ByVal p_strServer As String, ByVal p_strDataBase As String, ByVal p_strUser As String,
                    ByVal p_strPassword As String, p_intId As Integer, p_intConnectionTimeout As Integer)
        Call MyBase.New(p_strServer, p_strDataBase, p_strUser, p_strPassword, p_intId, p_intConnectionTimeout)
    End Sub

    Friend Sub New(ByVal p_strConnectionString As String)
        Call MyBase.New(p_strConnectionString)
    End Sub

    Friend Sub New(ByVal p_strConnectionString As String, p_intId As Integer)
        Call MyBase.New(p_strConnectionString, p_intId)
    End Sub
#End Region

#Region "Functions and Subroutines"
    Public Overrides Sub sbOpen() Implements IDataBase.sbOpen

        Dim strConnection As String

        Try


            If objSqlConnection Is Nothing = False Then
                If objSqlConnection.State = ConnectionState.Open Then
                    Try
                        objSqlConnection.Close()
                        objSqlConnection = Nothing
                    Catch ex As Exception

                    End Try
                End If
            End If

            If strConnectionString.Equals("") Then
                If strServer.EndsWith(strDataBase) = False Then
                    If strServer.EndsWith("\") Then
                        strServer = strServer & strDataBase
                    Else
                        strServer = strServer & "\" & strDataBase
                    End If
                End If

                If File.Exists(strServer) = False Then
                    SQLiteConnection.CreateFile(strServer)

                End If
                strConnection = "Data Source=" & strServer & ";Version=3;"
            Else
                strConnection = strConnectionString
            End If


            'Create Connection
            objSqlConnection = New SQLiteConnection(strConnection)
            objSqlConnection.Open()

        Catch ex As SQLiteException
            Throw New DataBaseException(ex)
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Sub

    Public Overrides Sub sbClose() Implements IDataBase.sbClose
        Try
            If objSqlConnection Is Nothing = False Then
                If objSqlConnection.State = ConnectionState.Open Then
                    objSqlConnection.Close()
                    objSqlConnection = Nothing
                End If
            End If
        Catch ex As SQLiteException
            Throw New DataBaseException(ex)
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Sub
    Public Overrides Sub sbBegin() Implements IDataBase.sbBegin
        Try

            If objSqlConnection Is Nothing Then
                Call sbOpen()
            End If

            If objSqlConnection.State = ConnectionState.Closed Or objSqlConnection.State = ConnectionState.Broken Then
                Call sbOpen()
            End If

            If Not blnBeginTransaction Then
                objSqlTransact = objSqlConnection.BeginTransaction()
                blnBeginTransaction = True
            End If

        Catch ex As SQLiteException
            Throw New DataBaseException(ex)
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Sub
    Public Overrides Sub sbCommit() Implements IDataBase.sbCommit
        Try

            If objSqlConnection Is Nothing Then
                Call sbOpen()
            End If

            If objSqlConnection.State = ConnectionState.Closed Or objSqlConnection.State = ConnectionState.Broken Then
                Call sbOpen()
            End If

            If blnBeginTransaction = True Then
                objSqlTransact.Commit()
                blnBeginTransaction = False
            End If

        Catch ex As SQLiteException
            Throw New DataBaseException(ex)
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Sub
    Public Overrides Sub sbRollBack() Implements IDataBase.sbRollBack
        Try
            If objSqlConnection Is Nothing Then
                Call sbOpen()
            End If

            If objSqlConnection.State = ConnectionState.Closed Or objSqlConnection.State = ConnectionState.Broken Then
                Call sbOpen()
            End If

            If blnBeginTransaction = True Then
                objSqlTransact.Rollback()
                blnBeginTransaction = False
            End If

        Catch ex As SQLiteException
            Throw New DataBaseException(ex)
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Sub

    Public Overrides Sub sbExecute(p_strCommand As String, ByVal p_intTimeout As Integer, p_objParameters As List(Of clsDataBaseParametes)) Implements IDataBase.sbExecute

        Dim intTries As Integer
        Dim objAuxException As DataBaseException
        Dim blnReconnect As Boolean
        Dim intReturn As Integer

        Try

            intTries = 0
            blnReconnect = False

            Do

                If objSqlConnection Is Nothing Then
                    Call sbOpen()
                End If

                If objSqlConnection.State = ConnectionState.Closed Or objSqlConnection.State = ConnectionState.Broken Then
                    Call sbOpen()
                End If


                objSqlCommand = New SQLiteCommand(p_strCommand, objSqlConnection)

                objSqlCommand.CommandTimeout = p_intTimeout

                If blnBeginTransaction = False Then
                    objSqlTransact = objSqlConnection.BeginTransaction()
                    blnBeginTransaction = True
                End If

                objSqlCommand.Transaction = objSqlTransact

                If p_objParameters.Count > 0 Then
                    For Each Parameter As clsDataBaseParametes In p_objParameters
                        objSqlCommand.Parameters.AddWithValue(Parameter.Key, Parameter.Value)
                    Next
                End If

                Try

                    intTries = intTries + 1

                    intReturn = objSqlCommand.ExecuteNonQuery()

                    If intReturn = 0 AndAlso Not p_strCommand.Trim.ToUpper.StartsWith("CREATE") AndAlso Not p_strCommand.Trim.ToUpper.StartsWith("ALTER") Then
                        Throw New DataBaseException(DataBaseException.enmDataBaseExeptionCode.NotExists, "Not Exists")
                    End If

                    Exit Do

                Catch exBd As DataBaseException

                    If exBd.Code = DataBaseException.enmDataBaseExeptionCode.Erro Or exBd.Code = DataBaseException.enmDataBaseExeptionCode.ConnectionClosed Then
                        If intTries <= CNS_TRIES Then
                            Thread.Sleep(CNS_TRIESDELAY)
                        Else
                            Throw exBd
                        End If
                    Else
                        Throw exBd
                    End If

                Catch ex As SQLiteException

                    objAuxException = New DataBaseException(ex)
                    If objAuxException.Code = DataBaseException.enmDataBaseExeptionCode.Erro Or objAuxException.Code = DataBaseException.enmDataBaseExeptionCode.ConnectionClosed Then
                        If intTries <= CNS_TRIES Then
                            Thread.Sleep(CNS_TRIESDELAY)
                        Else
                            Throw objAuxException
                        End If
                    Else
                        Throw objAuxException
                    End If

                Catch ex As Exception

                    If intTries <= CNS_TRIES Then
                        Thread.Sleep(CNS_TRIESDELAY)
                        blnReconnect = True
                    Else
                        Throw ex
                    End If

                End Try

            Loop

        Catch ex As DataBaseException
            Throw ex
        Catch ex As SQLiteException
            Throw New DataBaseException(ex)
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Sub

    Public Overrides Function fnExecute(ByVal p_strCommand As String, ByVal p_intTimeout As Integer, p_objParameters As List(Of clsDataBaseParametes)) As DataSet Implements IDataBase.fnExecute

        Dim objDataSet As New DataSet
        Dim intTries As Integer
        Dim objAuxException As DataBaseException
        Dim blnReconnect As Boolean

        Try

            intTries = 0
            blnReconnect = False

            Do

                If objSqlConnection Is Nothing Then
                    Call sbOpen()
                End If

                If objSqlConnection.State = ConnectionState.Closed Or objSqlConnection.State = ConnectionState.Broken Then
                    Call sbOpen()
                End If

                objSqlCommand = New SQLiteCommand(p_strCommand, objSqlConnection)

                objSqlCommand.CommandTimeout = p_intTimeout

                If blnBeginTransaction = True Then
                    objSqlCommand.Transaction = objSqlTransact
                End If

                If p_objParameters.Count > 0 Then
                    For Each Parameter As clsDataBaseParametes In p_objParameters
                        objSqlCommand.Parameters.AddWithValue(Parameter.Key, Parameter.Value)
                    Next
                End If

                Try

                    intTries = intTries + 1

                    objSqlDataAdapter = New SQLiteDataAdapter(objSqlCommand)
                    objSqlDataAdapter.Fill(objDataSet)

                    If objDataSet.Tables.Count > 0 AndAlso objDataSet.Tables(0).Rows.Count <= 0 Then
                        Throw New DataBaseException(DataBaseException.enmDataBaseExeptionCode.NotExists, "Not exists")
                    End If

                    Exit Do

                Catch exBd As DataBaseException

                    If exBd.Code = DataBaseException.enmDataBaseExeptionCode.Erro Or exBd.Code = DataBaseException.enmDataBaseExeptionCode.ConnectionClosed Then
                        If intTries <= CNS_TRIES Then
                            Thread.Sleep(CNS_TRIESDELAY)
                        Else
                            Throw exBd
                        End If
                    Else
                        Throw exBd
                    End If

                Catch ex As SQLiteException

                    objAuxException = New DataBaseException(ex)
                    If objAuxException.Code = DataBaseException.enmDataBaseExeptionCode.Erro Or objAuxException.Code = DataBaseException.enmDataBaseExeptionCode.ConnectionClosed Then
                        If intTries <= CNS_TRIES Then
                            Thread.Sleep(CNS_TRIESDELAY)
                        Else
                            Throw objAuxException
                        End If
                    Else
                        Throw objAuxException
                    End If

                Catch ex As Exception

                    If intTries <= CNS_TRIES Then
                        Thread.Sleep(CNS_TRIESDELAY)
                        blnReconnect = True
                    Else
                        Throw ex
                    End If

                End Try

            Loop

            Return objDataSet

        Catch ex As DataBaseException
            Throw ex
        Catch ex As SQLiteException
            Throw New DataBaseException(ex)
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function

    Public Overrides Function fnGetConfiguration() As clsConfiguration

        Dim objReturn As clsConfiguration
        Try

            objReturn = MyBase.fnGetConfiguration()

            objReturn.Type = BDataBase.DataBase.enmDataBaseType.SqLite

            Return objReturn

        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function

    Public Overrides Function fnGetTableInfo(p_strTable As String) As clsTableInfo Implements IDataBase.fnGetTableInfo

        Dim objReturn As clsTableInfo
        Dim strCommand As String
        Dim objAuxDataSet As DataSet

        Try

            objReturn = New clsTableInfo With {.Name = p_strTable}

            'Table info with columns
            strCommand = "PRAGMA table_info(" & p_strTable & ");"
            objAuxDataSet = fnExecute(strCommand)

            objReturn.Columns = (From Register As DataRow In objAuxDataSet.Tables(0).Rows
                                 Select New clsColumnInfo() With {.Index = Register("cid"),
                                                          .Name = Register("name"),
                                                          .Type = fnSelectType(Register("type")),
                                                          .Size = 0,
                                                          .PrimaryKey = IIf(Register("pk") = 1, True, False)}).ToList

            'Indexes info
            Try

                strCommand = "PRAGMA index_list(" & p_strTable & ");"
                objAuxDataSet = fnExecute(strCommand)

                objReturn.Indexes = (From Register As DataRow In objAuxDataSet.Tables(0).Rows
                                     Select New clsIndexInfo() With {.Name = Register("name")}).ToList


                objReturn.Indexes.ForEach(Sub(Index As clsIndexInfo)

                                              strCommand = "PRAGMA index_info(" & Index.Name & ");"
                                              objAuxDataSet = fnExecute(strCommand)

                                              Index.Columns = (From Register As DataRow In objAuxDataSet.Tables(0).Rows
                                                               Select New clsColumnInfo() With {.Index = Register("seqno"),
                                                                                            .Name = Register("name")}).ToList

                                              Index.Columns.ForEach(Sub(Column As clsColumnInfo)
                                                                        Dim objAuxColumn As clsColumnInfo
                                                                        objAuxColumn = objReturn.Columns.Find(Function(Col As clsColumnInfo) Col.Name.Trim.ToUpper = Column.Name.Trim.ToUpper)
                                                                        If objAuxColumn IsNot Nothing Then
                                                                            Column.Type = objAuxColumn.Type
                                                                            Column.Size = objAuxColumn.Size
                                                                        End If
                                                                    End Sub)

                                          End Sub)


            Catch ex As DataBaseException
                If ex.Code <> DataBaseException.enmDataBaseExeptionCode.NotExists Then
                    Throw ex
                End If
            End Try


            Return objReturn

        Catch exBd As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property isOpen() As Boolean Implements IDataBase.isOpen
        Get
            If objSqlConnection IsNot Nothing Then
                Return objSqlConnection.State <> ConnectionState.Closed
            Else
                Return False
            End If
        End Get
    End Property
#End Region

End Class