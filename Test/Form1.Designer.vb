<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnTestMysql = New System.Windows.Forms.Button()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.grdResult = New System.Windows.Forms.DataGridView()
        Me.btnTestMsSql = New System.Windows.Forms.Button()
        Me.btnmssqlnonquerry = New System.Windows.Forms.Button()
        Me.btnMysqlNonquerry = New System.Windows.Forms.Button()
        Me.btnTestSqlitenonquerry = New System.Windows.Forms.Button()
        Me.btnTesteSqlite = New System.Windows.Forms.Button()
        Me.btnSqliteTableinfo = New System.Windows.Forms.Button()
        Me.btnMsSqlTableinfo = New System.Windows.Forms.Button()
        Me.btnMySqlTableinfo = New System.Windows.Forms.Button()
        Me.btnTestOracleTableInfo = New System.Windows.Forms.Button()
        Me.btnTextOracleNonQ = New System.Windows.Forms.Button()
        Me.btnTestOracle = New System.Windows.Forms.Button()
        CType(Me.grdResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnTestMysql
        '
        Me.btnTestMysql.Location = New System.Drawing.Point(12, 12)
        Me.btnTestMysql.Name = "btnTestMysql"
        Me.btnTestMysql.Size = New System.Drawing.Size(141, 40)
        Me.btnTestMysql.TabIndex = 0
        Me.btnTestMysql.Text = "Test MySql"
        Me.btnTestMysql.UseVisualStyleBackColor = True
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(12, 152)
        Me.txtInput.Multiline = True
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(582, 214)
        Me.txtInput.TabIndex = 1
        Me.txtInput.Text = "select * from tbtest"
        '
        'grdResult
        '
        Me.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdResult.Location = New System.Drawing.Point(600, 12)
        Me.grdResult.Name = "grdResult"
        Me.grdResult.Size = New System.Drawing.Size(398, 354)
        Me.grdResult.TabIndex = 2
        '
        'btnTestMsSql
        '
        Me.btnTestMsSql.Location = New System.Drawing.Point(159, 12)
        Me.btnTestMsSql.Name = "btnTestMsSql"
        Me.btnTestMsSql.Size = New System.Drawing.Size(141, 40)
        Me.btnTestMsSql.TabIndex = 3
        Me.btnTestMsSql.Text = "Test MsSql"
        Me.btnTestMsSql.UseVisualStyleBackColor = True
        '
        'btnmssqlnonquerry
        '
        Me.btnmssqlnonquerry.Location = New System.Drawing.Point(159, 58)
        Me.btnmssqlnonquerry.Name = "btnmssqlnonquerry"
        Me.btnmssqlnonquerry.Size = New System.Drawing.Size(141, 40)
        Me.btnmssqlnonquerry.TabIndex = 5
        Me.btnmssqlnonquerry.Text = "Test MsSql  non querry"
        Me.btnmssqlnonquerry.UseVisualStyleBackColor = True
        '
        'btnMysqlNonquerry
        '
        Me.btnMysqlNonquerry.Location = New System.Drawing.Point(12, 58)
        Me.btnMysqlNonquerry.Name = "btnMysqlNonquerry"
        Me.btnMysqlNonquerry.Size = New System.Drawing.Size(141, 40)
        Me.btnMysqlNonquerry.TabIndex = 4
        Me.btnMysqlNonquerry.Text = "Test MySql non querry"
        Me.btnMysqlNonquerry.UseVisualStyleBackColor = True
        '
        'btnTestSqlitenonquerry
        '
        Me.btnTestSqlitenonquerry.Location = New System.Drawing.Point(306, 58)
        Me.btnTestSqlitenonquerry.Name = "btnTestSqlitenonquerry"
        Me.btnTestSqlitenonquerry.Size = New System.Drawing.Size(141, 40)
        Me.btnTestSqlitenonquerry.TabIndex = 7
        Me.btnTestSqlitenonquerry.Text = "Test Sqlite  non querry"
        Me.btnTestSqlitenonquerry.UseVisualStyleBackColor = True
        '
        'btnTesteSqlite
        '
        Me.btnTesteSqlite.Location = New System.Drawing.Point(306, 12)
        Me.btnTesteSqlite.Name = "btnTesteSqlite"
        Me.btnTesteSqlite.Size = New System.Drawing.Size(141, 40)
        Me.btnTesteSqlite.TabIndex = 6
        Me.btnTesteSqlite.Text = "Test Sqlite"
        Me.btnTesteSqlite.UseVisualStyleBackColor = True
        '
        'btnSqliteTableinfo
        '
        Me.btnSqliteTableinfo.Location = New System.Drawing.Point(306, 104)
        Me.btnSqliteTableinfo.Name = "btnSqliteTableinfo"
        Me.btnSqliteTableinfo.Size = New System.Drawing.Size(141, 40)
        Me.btnSqliteTableinfo.TabIndex = 10
        Me.btnSqliteTableinfo.Text = "Test Sqlite  tableinfo"
        Me.btnSqliteTableinfo.UseVisualStyleBackColor = True
        '
        'btnMsSqlTableinfo
        '
        Me.btnMsSqlTableinfo.Location = New System.Drawing.Point(159, 104)
        Me.btnMsSqlTableinfo.Name = "btnMsSqlTableinfo"
        Me.btnMsSqlTableinfo.Size = New System.Drawing.Size(141, 40)
        Me.btnMsSqlTableinfo.TabIndex = 9
        Me.btnMsSqlTableinfo.Text = "Test MsSql  tabeinfo"
        Me.btnMsSqlTableinfo.UseVisualStyleBackColor = True
        '
        'btnMySqlTableinfo
        '
        Me.btnMySqlTableinfo.Location = New System.Drawing.Point(12, 104)
        Me.btnMySqlTableinfo.Name = "btnMySqlTableinfo"
        Me.btnMySqlTableinfo.Size = New System.Drawing.Size(141, 40)
        Me.btnMySqlTableinfo.TabIndex = 8
        Me.btnMySqlTableinfo.Text = "Test MySql TableInfo"
        Me.btnMySqlTableinfo.UseVisualStyleBackColor = True
        '
        'btnTestOracleTableInfo
        '
        Me.btnTestOracleTableInfo.Location = New System.Drawing.Point(453, 104)
        Me.btnTestOracleTableInfo.Name = "btnTestOracleTableInfo"
        Me.btnTestOracleTableInfo.Size = New System.Drawing.Size(141, 40)
        Me.btnTestOracleTableInfo.TabIndex = 13
        Me.btnTestOracleTableInfo.Text = "Test Oracle  tableinfo"
        Me.btnTestOracleTableInfo.UseVisualStyleBackColor = True
        '
        'btnTextOracleNonQ
        '
        Me.btnTextOracleNonQ.Location = New System.Drawing.Point(453, 58)
        Me.btnTextOracleNonQ.Name = "btnTextOracleNonQ"
        Me.btnTextOracleNonQ.Size = New System.Drawing.Size(141, 40)
        Me.btnTextOracleNonQ.TabIndex = 12
        Me.btnTextOracleNonQ.Text = "Test Oracle  non querry"
        Me.btnTextOracleNonQ.UseVisualStyleBackColor = True
        '
        'btnTestOracle
        '
        Me.btnTestOracle.Location = New System.Drawing.Point(453, 12)
        Me.btnTestOracle.Name = "btnTestOracle"
        Me.btnTestOracle.Size = New System.Drawing.Size(141, 40)
        Me.btnTestOracle.TabIndex = 11
        Me.btnTestOracle.Text = "Test Oracle"
        Me.btnTestOracle.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 378)
        Me.Controls.Add(Me.btnTestOracleTableInfo)
        Me.Controls.Add(Me.btnTextOracleNonQ)
        Me.Controls.Add(Me.btnTestOracle)
        Me.Controls.Add(Me.btnSqliteTableinfo)
        Me.Controls.Add(Me.btnMsSqlTableinfo)
        Me.Controls.Add(Me.btnMySqlTableinfo)
        Me.Controls.Add(Me.btnTestSqlitenonquerry)
        Me.Controls.Add(Me.btnTesteSqlite)
        Me.Controls.Add(Me.btnmssqlnonquerry)
        Me.Controls.Add(Me.btnMysqlNonquerry)
        Me.Controls.Add(Me.btnTestMsSql)
        Me.Controls.Add(Me.grdResult)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.btnTestMysql)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.grdResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnTestMysql As Button
    Friend WithEvents txtInput As TextBox
    Friend WithEvents grdResult As DataGridView
    Friend WithEvents btnTestMsSql As Button
    Friend WithEvents btnmssqlnonquerry As Button
    Friend WithEvents btnMysqlNonquerry As Button
    Friend WithEvents btnTestSqlitenonquerry As Button
    Friend WithEvents btnTesteSqlite As Button
    Friend WithEvents btnSqliteTableinfo As Button
    Friend WithEvents btnMsSqlTableinfo As Button
    Friend WithEvents btnMySqlTableinfo As Button
    Friend WithEvents btnTestOracleTableInfo As Button
    Friend WithEvents btnTextOracleNonQ As Button
    Friend WithEvents btnTestOracle As Button
End Class
