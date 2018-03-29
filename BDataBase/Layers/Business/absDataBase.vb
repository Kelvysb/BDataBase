﻿

'Copyright 2018 Kelvys B. Pantaleão

'This file is part of BDataBase

'BGlobal Is free software: you can redistribute it And/Or modify
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

'BGlobal é um software livre; você pode redistribuí-lo e/ou 
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

Friend MustInherit Class absDataBase
    Implements IDataBase

#Region "Definitions"
    Protected Const CNS_TIMEOUTCONNECT = 31536000
    Protected Const CNS_TIMEOUTCOMMAND = 31536000
    Protected Const CNS_TRIES = 3
    Protected Const CNS_TRIESDELAY = 1000

    Protected intId As Integer
    Protected strPassword As String
    Protected strUser As String
    Protected strDataBase As String
    Protected strServer As String
    Protected blnBeginTransaction As Boolean

#End Region

#Region "Constructor"
    Friend Sub New(ByVal p_strServer As String, ByVal p_strDataBase As String, ByVal p_strUser As String,
                    ByVal p_strPassword As String, p_intId As Integer)

        Try
            strServer = p_strServer
            strDataBase = p_strDataBase
            strUser = p_strUser
            strPassword = p_strPassword
            blnBeginTransaction = False
            intId = p_intId

            Call sbOpen()

        Catch ex As SqlClient.SqlException
            Throw New DataBaseException(ex)
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try

    End Sub
#End Region

#Region "Functions and Subroutines"
    Public MustOverride Sub sbOpen() Implements IDataBase.sbOpen

    Public MustOverride Sub sbClose() Implements IDataBase.sbClose

    Public MustOverride Sub sbBegin() Implements IDataBase.sbBegin

    Public MustOverride Sub sbCommit() Implements IDataBase.sbCommit

    Public MustOverride Sub sbRollBack() Implements IDataBase.sbRollBack

    Public Overridable Sub sbExecute(p_strCommand As String) Implements IDataBase.sbExecute
        Try
            Call sbExecute(p_strCommand, CNS_TIMEOUTCOMMAND, New List(Of clsDataBaseParametes))
        Catch ex As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Sub
    Public Overridable Sub sbExecute(p_strCommand As String, ByVal p_intTimeout As Integer) Implements IDataBase.sbExecute
        Try
            Call sbExecute(p_strCommand, p_intTimeout, New List(Of clsDataBaseParametes))
        Catch ex As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Sub
    Public Overridable Sub sbExecute(p_strCommand As String, p_objParameters As List(Of clsDataBaseParametes)) Implements IDataBase.sbExecute
        Try
            Call sbExecute(p_strCommand, CNS_TIMEOUTCOMMAND, p_objParameters)
        Catch ex As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Sub
    Public MustOverride Sub sbExecute(p_strCommand As String, ByVal p_intTimeout As Integer, p_objParameters As List(Of clsDataBaseParametes)) Implements IDataBase.sbExecute

    Public Function fnExecute(p_strCommand As String) As DataSet Implements IDataBase.fnExecute
        Try
            Return fnExecute(p_strCommand, CNS_TIMEOUTCOMMAND, New List(Of clsDataBaseParametes))
        Catch ex As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function
    Public Overridable Function fnExecute(p_strCommand As String, ByVal p_intTimeout As Integer) As DataSet Implements IDataBase.fnExecute
        Try
            Return fnExecute(p_strCommand, p_intTimeout, New List(Of clsDataBaseParametes))
        Catch ex As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function
    Public Overridable Function fnExecute(ByVal p_strCommand As String, p_objParameters As List(Of clsDataBaseParametes)) As DataSet Implements IDataBase.fnExecute
        Try
            Return fnExecute(p_strCommand, CNS_TIMEOUTCOMMAND, p_objParameters)
        Catch ex As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function
    Public MustOverride Function fnExecute(ByVal p_strCommand As String, ByVal p_intTimeout As Integer, p_objParameters As List(Of clsDataBaseParametes)) As DataSet Implements IDataBase.fnExecute

    Public Overridable Function fnExecute(Of T)(p_strCommand As String) As List(Of T) Implements IDataBase.fnExecute
        Try
            Return fnExecute(Of T)(p_strCommand, CNS_TIMEOUTCOMMAND, New List(Of clsDataBaseParametes))
        Catch ex As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function
    Public Overridable Function fnExecute(Of T)(p_strCommand As String, ByVal p_intTimeout As Integer) As List(Of T) Implements IDataBase.fnExecute
        Try
            Return fnExecute(Of T)(p_strCommand, p_intTimeout, New List(Of clsDataBaseParametes))
        Catch ex As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function
    Public Overridable Function fnExecute(Of T)(p_strCommand As String, p_objParametros As List(Of clsDataBaseParametes)) As List(Of T) Implements IDataBase.fnExecute
        Try
            Return fnExecute(Of T)(p_strCommand, CNS_TIMEOUTCOMMAND, p_objParametros)
        Catch ex As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function
    Public Overridable Function fnExecute(Of T)(p_strCommand As String, ByVal p_intTimeout As Integer, p_objParameters As List(Of clsDataBaseParametes)) As List(Of T) Implements IDataBase.fnExecute

        Dim objauxDataSet As DataSet
        Dim objReturn As List(Of T)
        Dim objAuxProperties As List(Of Reflection.PropertyInfo)
        Dim objauxType As Type
        Dim objauxConstructor As Reflection.ConstructorInfo
        Dim objAuxReturn As T

        Try

            objReturn = New List(Of T)

            objauxType = GetType(T)

            objAuxProperties = objauxType.GetProperties.ToList

            If objAuxProperties Is Nothing OrElse objAuxProperties.Count = 0 Then
                Throw New DataBaseException(DataBaseException.enmDataBaseExeptionCode.Erro, "Parameter type (" & objauxType.Name & ") must have some properties.")
            End If

            objauxConstructor = objauxType.GetConstructor({})

            If objauxConstructor Is Nothing Then
                Throw New DataBaseException(DataBaseException.enmDataBaseExeptionCode.Erro, "Parameter type (" & objauxType.Name & ") must have an empty constructor.")
            End If

            objauxDataSet = fnExecute(p_strCommand, p_intTimeout, p_objParameters)

            For Each Register As DataRow In objauxDataSet.Tables(0).Rows

                objAuxReturn = objauxConstructor.Invoke({})

                For Each Prop As Reflection.PropertyInfo In objAuxProperties

                    Try
                        Prop.SetValue(objAuxReturn, Register(Prop.Name))
                    Catch ex As Exception
                        Try
                            If Register(Prop.Name).GetType Is GetType(Int64) And Prop.PropertyType IsNot GetType(Int64) Then
                                Prop.SetValue(objAuxReturn, CInt(Register(Prop.Name)))
                            Else
                                Prop.SetValue(objAuxReturn, CStr(Register(Prop.Name)))
                            End If
                        Catch ex2 As Exception

                        End Try
                    End Try

                Next

                objReturn.Add(objAuxReturn)

            Next

            Return objReturn

        Catch ex As DataBaseException
            Throw
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function

    Public Overridable Function fnGetConfiguration() As clsConfiguration Implements IDataBase.fnGetConfiguration
        Try
            Return New clsConfiguration() With {.Server = strServer, .DataBase = strDataBase, .User = strUser, .Password = strPassword}
        Catch ex As Exception
            Throw New DataBaseException(ex)
        End Try
    End Function

    Public MustOverride Function fnGetTableInfo(p_strTable As String) As clsTableInfo Implements IDataBase.fnGetTableInfo

    Protected Function fnSelectType(p_strType As String) As enm_ColumnType

        Dim enmReturn As enm_ColumnType
        Dim strAuxInput As String

        Try

            enmReturn = enm_ColumnType.Text

            If p_strType.IndexOf("(") <> -1 Then
                strAuxInput = p_strType.Substring(0, p_strType.IndexOf("("))
            Else
                strAuxInput = p_strType
            End If

            Select Case strAuxInput.Trim.ToUpper
                Case "TEXT", "BLOOB", "VARCHAR", "CHAR", "NCHAR", "TINYBLOB", "TINYTEXT", "MEDIUMBLOB", "MEDIUMTEXT", "LONGBLOB", "LONGTEXT", "ENUM"
                    enmReturn = enm_ColumnType.Text
                Case "INTEGER", "INT", "TINYINT", "SMALLINT", "MEDIUMINT", "BIGINT"
                    enmReturn = enm_ColumnType.Int
                Case "REAL", "FLOAT", "DOUBLE", "DECIMAL"
                    enmReturn = enm_ColumnType.Number
                Case "BOOLEAN"
                    enmReturn = enm_ColumnType.Bool
                Case "DATE", "DATETIME", "TIMESTAMP", "TIME", "YEAR"
                    enmReturn = enm_ColumnType.DateTime
            End Select

            Return enmReturn

        Catch ex As Exception
            Throw
        End Try
    End Function

    Protected Function fnGetSize(p_strInput As String) As Integer

        Dim intReturn As Integer
        Dim strAuxInput As String

        Try

            intReturn = 0

            If p_strInput.IndexOf("(") <> -1 AndAlso p_strInput.IndexOf(")") <> -1 Then

                strAuxInput = p_strInput.Substring(p_strInput.IndexOf("(")).Replace("(", "").Replace(")", "")

                If IsNumeric(strAuxInput) = True Then
                    intReturn = CInt(strAuxInput)
                End If

            End If

            Return intReturn


        Catch ex As Exception
            intReturn = 0
        End Try

        Return intReturn

    End Function
#End Region

#Region "Properties"
    Public Overridable ReadOnly Property Server() As String Implements IDataBase.Server
        Get
            Return strServer
        End Get
    End Property
    Public Overridable ReadOnly Property DataBase() As String Implements IDataBase.DataBase
        Get
            Return strDataBase
        End Get
    End Property
    Public Overridable ReadOnly Property User() As String Implements IDataBase.User
        Get
            Return strUser
        End Get
    End Property
    Public Overridable ReadOnly Property Password() As String Implements IDataBase.Password
        Get
            Return strPassword
        End Get
    End Property
    Public MustOverride ReadOnly Property isOpen() As Boolean Implements IDataBase.isOpen

    Public Overridable ReadOnly Property ConnectionId As Integer Implements IDataBase.ConnectionId
        Get
            Return intId
        End Get
    End Property
#End Region

End Class
