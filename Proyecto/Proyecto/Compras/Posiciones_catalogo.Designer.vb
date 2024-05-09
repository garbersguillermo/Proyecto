<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Posiciones_catalogo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Button5 = New Button()
        btnPasteFromClipboard = New Button()
        Button4 = New Button()
        txtPorcentaje = New TextBox()
        Button1 = New Button()
        DataGridView1 = New DataGridView()
        CatalogProductId = New DataGridViewTextBoxColumn()
        DataGridView2 = New DataGridView()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Button6 = New Button()
        Button7 = New Button()
        Label2 = New Label()
        GroupBox1 = New GroupBox()
        Button2 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(223, 313)
        Button5.Name = "Button5"
        Button5.Size = New Size(162, 23)
        Button5.TabIndex = 104
        Button5.Text = "Pegar CatalogID"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' btnPasteFromClipboard
        ' 
        btnPasteFromClipboard.Location = New Point(12, 313)
        btnPasteFromClipboard.Name = "btnPasteFromClipboard"
        btnPasteFromClipboard.Size = New Size(162, 23)
        btnPasteFromClipboard.TabIndex = 103
        btnPasteFromClipboard.Text = "Pegar SKU - ItemID"
        btnPasteFromClipboard.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(235, 9)
        Button4.Name = "Button4"
        Button4.Size = New Size(64, 55)
        Button4.TabIndex = 102
        Button4.Text = "Copiar"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' txtPorcentaje
        ' 
        txtPorcentaje.Location = New Point(10, 22)
        txtPorcentaje.Name = "txtPorcentaje"
        txtPorcentaje.Size = New Size(22, 23)
        txtPorcentaje.TabIndex = 101
        txtPorcentaje.Text = "35"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(90, 38)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 25)
        Button1.TabIndex = 98
        Button1.Text = "Segundo"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {CatalogProductId})
        DataGridView1.Location = New Point(12, 73)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(373, 234)
        DataGridView1.TabIndex = 97
        ' 
        ' CatalogProductId
        ' 
        CatalogProductId.HeaderText = "CatalogProductId"
        CatalogProductId.Name = "CatalogProductId"
        ' 
        ' DataGridView2
        ' 
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Location = New Point(484, 73)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.RowTemplate.Height = 25
        DataGridView2.Size = New Size(365, 234)
        DataGridView2.TabIndex = 105
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(410, 313)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(100, 23)
        TextBox1.TabIndex = 106
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(484, 41)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(100, 23)
        TextBox2.TabIndex = 107
        TextBox2.Text = "MLA24592469"
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(590, 15)
        Button6.Name = "Button6"
        Button6.Size = New Size(95, 49)
        Button6.TabIndex = 108
        Button6.Text = "Competencia catalogo"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.Location = New Point(12, 38)
        Button7.Name = "Button7"
        Button7.Size = New Size(75, 23)
        Button7.TabIndex = 109
        Button7.Text = "Ventas"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(37, 28)
        Label2.Name = "Label2"
        Label2.Size = New Size(17, 15)
        Label2.TabIndex = 111
        Label2.Text = "%"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(txtPorcentaje)
        GroupBox1.Location = New Point(321, 13)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(64, 50)
        GroupBox1.TabIndex = 112
        GroupBox1.TabStop = False
        GroupBox1.Text = "Margen"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(700, 15)
        Button2.Name = "Button2"
        Button2.Size = New Size(95, 49)
        Button2.TabIndex = 113
        Button2.Text = "Ventas"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Posiciones_catalogo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(884, 352)
        Controls.Add(Button2)
        Controls.Add(GroupBox1)
        Controls.Add(Button7)
        Controls.Add(Button6)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(DataGridView2)
        Controls.Add(Button5)
        Controls.Add(btnPasteFromClipboard)
        Controls.Add(Button4)
        Controls.Add(Button1)
        Controls.Add(DataGridView1)
        Name = "Posiciones_catalogo"
        Text = "Posiciones_catalogo"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button5 As Button
    Friend WithEvents btnPasteFromClipboard As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents txtPorcentaje As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CatalogProductId As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
End Class
