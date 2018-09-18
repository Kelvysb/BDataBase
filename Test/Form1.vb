Imports BDataBase

Public Class Form1
    Private Sub btnTestMysql_Click(sender As Object, e As EventArgs) Handles btnTestMysql.Click

        Dim objConnection As BDataBase.IDataBase
        Dim objReturn As List(Of clsTeste)

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("127.0.0.1", "ctr", "user", "password", 0, BDataBase.DataBase.enmDataBaseType.MySql)

            objReturn = objConnection.fnExecute(Of clsTeste)(txtInput.Text)

            grdResult.DataSource = Nothing
            grdResult.DataSource = objReturn

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnTestMsSql_Click(sender As Object, e As EventArgs) Handles btnTestMsSql.Click

        Dim objConnection As BDataBase.IDataBase
        Dim objReturn As DataSet
        Dim objConnectionConfig As clsConfiguration

        Try


            objConnectionConfig = New clsConfiguration()
            objConnectionConfig.Server = "127.0.0.1"
            objConnectionConfig.DataBase = "AdventureWorks2017"
            objConnectionConfig.User = "testUser"
            objConnectionConfig.Password = "sabado25"
            objConnectionConfig.Type = DataBase.enmDataBaseType.MsSql
            objConnectionConfig.ConnetionTimeout = 10

            objConnection = BDataBase.DataBase.fnOpenConnection(objConnectionConfig)

            objReturn = objConnection.fnExecute(txtInput.Text)

            grdResult.DataSource = Nothing
            grdResult.DataSource = objReturn.Tables(0)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnMysqlNonquerry_Click(sender As Object, e As EventArgs) Handles btnMysqlNonquerry.Click

        Dim objConnection As BDataBase.IDataBase

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("127.0.0.1", "testdatabase", "user", "password", BDataBase.DataBase.enmDataBaseType.MySql)

            objConnection.sbExecute(txtInput.Text)

            objConnection.sbCommit()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnmssqlnonquerry_Click(sender As Object, e As EventArgs) Handles btnmssqlnonquerry.Click
        Dim objConnection As BDataBase.IDataBase

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("127.0.0.1,1433", "testdatabase", "adapta", "password", BDataBase.DataBase.enmDataBaseType.MsSql)

            objConnection.sbExecute(txtInput.Text)

            objConnection.sbCommit()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnTesteSqlite_Click(sender As Object, e As EventArgs) Handles btnTesteSqlite.Click

        Dim objConnection As BDataBase.IDataBase
        Dim objReturn As List(Of clsTeste)

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("..\..\testedb", "testedb", "", "", BDataBase.DataBase.enmDataBaseType.SqLite)

            objReturn = objConnection.fnExecute(Of clsTeste)(txtInput.Text)

            grdResult.DataSource = Nothing
            grdResult.DataSource = objReturn

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnTestSqlitenonquerry_Click(sender As Object, e As EventArgs) Handles btnTestSqlitenonquerry.Click
        Dim objConnection As BDataBase.IDataBase

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("..\..\testedb", "testedb", "", "", BDataBase.DataBase.enmDataBaseType.SqLite)

            objConnection.sbExecute(txtInput.Text)

            objConnection.sbCommit()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnMySqlTableinfo_Click(sender As Object, e As EventArgs) Handles btnMySqlTableinfo.Click

        Dim objConnection As BDataBase.IDataBase
        Dim objReturn As BDataBase.clsTableInfo

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("127.0.0.1", "ctr", "user", "password", 0, BDataBase.DataBase.enmDataBaseType.MySql)

            objReturn = objConnection.fnGetTableInfo(txtInput.Text)

            grdResult.DataSource = Nothing
            grdResult.DataSource = objReturn.Columns

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnMsSqlTableinfo_Click(sender As Object, e As EventArgs) Handles btnMsSqlTableinfo.Click

        Dim objConnection As BDataBase.IDataBase
        Dim objReturn As BDataBase.clsTableInfo

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("127.0.0.1,1433", "testdatabase", "adapta", "password", BDataBase.DataBase.enmDataBaseType.MsSql)

            objReturn = objConnection.fnGetTableInfo(txtInput.Text)

            grdResult.DataSource = Nothing
            grdResult.DataSource = objReturn.Columns

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSqliteTableinfo_Click(sender As Object, e As EventArgs) Handles btnSqliteTableinfo.Click

        Dim objConnection As BDataBase.IDataBase
        Dim objReturn As BDataBase.clsTableInfo

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("..\..\testedb", "testedb", "", "", BDataBase.DataBase.enmDataBaseType.SqLite)

            objReturn = objConnection.fnGetTableInfo(txtInput.Text)

            grdResult.DataSource = Nothing
            grdResult.DataSource = objReturn.Columns

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnTestOracle_Click(sender As Object, e As EventArgs) Handles btnTestOracle.Click
        Dim objConnection As BDataBase.IDataBase
        Dim objReturn As DataSet

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("127.0.0.1:1521", "xe", "SYSTEM", "sabado25", 0, BDataBase.DataBase.enmDataBaseType.Oracle)

            objReturn = objConnection.fnExecute(txtInput.Text)

            grdResult.DataSource = Nothing
            grdResult.DataSource = objReturn.Tables(0)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnTextOracleNonQ_Click(sender As Object, e As EventArgs) Handles btnTextOracleNonQ.Click
        Dim objConnection As BDataBase.IDataBase

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("127.0.0.1:1521", "xe", "SYSTEM", "sabado25", 0, BDataBase.DataBase.enmDataBaseType.Oracle)

            objConnection.sbExecute(txtInput.Text)

            objConnection.sbCommit()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnTestOracleTableInfo_Click(sender As Object, e As EventArgs) Handles btnTestOracleTableInfo.Click
        Dim objConnection As BDataBase.IDataBase
        Dim objReturn As BDataBase.clsTableInfo

        Try

            objConnection = BDataBase.DataBase.fnOpenConnection("127.0.0.1:1521", "xe", "SYSTEM", "sabado25", 0, BDataBase.DataBase.enmDataBaseType.Oracle)

            objReturn = objConnection.fnGetTableInfo("TBTEST")

            grdResult.DataSource = Nothing
            grdResult.DataSource = objReturn.Columns

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class


Public Class clsTeste
    Private intId As Integer

    Public Property Id() As Integer
        Get
            Return intId
        End Get
        Set(ByVal value As Integer)
            intId = value
        End Set
    End Property

    Private strChave As String
    Public Property Chave() As String
        Get
            Return strChave
        End Get
        Set(ByVal value As String)
            strChave = value
        End Set
    End Property

    Private strValor As String
    Public Property Valor() As String
        Get
            Return strValor
        End Get
        Set(ByVal value As String)
            strValor = value
        End Set
    End Property
End Class