<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class reporte_a_compras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnPasteFromClipboard = New Button()
        Button4 = New Button()
        txtPorcentaje = New TextBox()
        Button3 = New Button()
        Button1 = New Button()
        TextBox1 = New TextBox()
        DataGridView1 = New DataGridView()
        CatalogProductId = New DataGridViewTextBoxColumn()
        Label9 = New Label()
        DataGridView2 = New DataGridView()
        DataGridView3 = New DataGridView()
        GroupBox1 = New GroupBox()
        Label1 = New Label()
        txtLimiteFacturacion = New TextBox()
        btnPasteFromClipboard2 = New Button()
        Button6 = New Button()
        Button5 = New Button()
        DataGridView4 = New DataGridView()
        Ventas = New Button()
        Datos = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(DataGridView4, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnPasteFromClipboard
        ' 
        btnPasteFromClipboard.Location = New Point(11, 313)
        btnPasteFromClipboard.Name = "btnPasteFromClipboard"
        btnPasteFromClipboard.Size = New Size(162, 23)
        btnPasteFromClipboard.TabIndex = 92
        btnPasteFromClipboard.Text = "Pegar SKU - ItemID"
        btnPasteFromClipboard.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(401, 18)
        Button4.Name = "Button4"
        Button4.Size = New Size(59, 49)
        Button4.TabIndex = 91
        Button4.Text = "Copiar"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' txtPorcentaje
        ' 
        txtPorcentaje.Location = New Point(362, 42)
        txtPorcentaje.Name = "txtPorcentaje"
        txtPorcentaje.Size = New Size(22, 23)
        txtPorcentaje.TabIndex = 89
        txtPorcentaje.Text = "35"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(98, 42)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 88
        Button3.Text = "Tercero"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(182, 525)
        Button1.Name = "Button1"
        Button1.Size = New Size(162, 23)
        Button1.TabIndex = 85
        Button1.Text = "Traer catalogo"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(504, 320)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(47, 23)
        TextBox1.TabIndex = 83
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {CatalogProductId})
        DataGridView1.Location = New Point(11, 73)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(373, 234)
        DataGridView1.TabIndex = 82
        ' 
        ' CatalogProductId
        ' 
        CatalogProductId.HeaderText = "CatalogProductId"
        CatalogProductId.Name = "CatalogProductId"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label9.ForeColor = Color.DarkGray
        Label9.Location = New Point(574, 325)
        Label9.Name = "Label9"
        Label9.Size = New Size(152, 15)
        Label9.TabIndex = 81
        Label9.Text = "Powered by SALE HACKS®"
        ' 
        ' DataGridView2
        ' 
        DataGridView2.AllowUserToAddRows = False
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Location = New Point(401, 73)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.RowTemplate.Height = 25
        DataGridView2.Size = New Size(373, 234)
        DataGridView2.TabIndex = 93
        ' 
        ' DataGridView3
        ' 
        DataGridView3.AllowUserToAddRows = False
        DataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView3.Location = New Point(17, 40)
        DataGridView3.Name = "DataGridView3"
        DataGridView3.RowTemplate.Height = 25
        DataGridView3.Size = New Size(373, 252)
        DataGridView3.TabIndex = 94
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.DarkSlateBlue
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(txtLimiteFacturacion)
        GroupBox1.Controls.Add(btnPasteFromClipboard2)
        GroupBox1.Controls.Add(Button6)
        GroupBox1.Controls.Add(DataGridView3)
        GroupBox1.ForeColor = SystemColors.ActiveCaptionText
        GroupBox1.Location = New Point(789, 18)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(546, 322)
        GroupBox1.TabIndex = 95
        GroupBox1.TabStop = False
        GroupBox1.Text = "3 Pegar aca la info del excel terminar para obtener el analisis final"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(404, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(131, 15)
        Label1.TabIndex = 98
        Label1.Text = "Venta minima estimada"
        ' 
        ' txtLimiteFacturacion
        ' 
        txtLimiteFacturacion.Location = New Point(404, 58)
        txtLimiteFacturacion.Name = "txtLimiteFacturacion"
        txtLimiteFacturacion.Size = New Size(131, 23)
        txtLimiteFacturacion.TabIndex = 97
        txtLimiteFacturacion.Text = "750000"
        ' 
        ' btnPasteFromClipboard2
        ' 
        btnPasteFromClipboard2.Location = New Point(396, 265)
        btnPasteFromClipboard2.Name = "btnPasteFromClipboard2"
        btnPasteFromClipboard2.Size = New Size(139, 23)
        btnPasteFromClipboard2.TabIndex = 96
        btnPasteFromClipboard2.Text = "Pegar y generar analisis"
        btnPasteFromClipboard2.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(407, 136)
        Button6.Name = "Button6"
        Button6.Size = New Size(112, 90)
        Button6.TabIndex = 95
        Button6.Text = "Copiar"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(222, 313)
        Button5.Name = "Button5"
        Button5.Size = New Size(162, 23)
        Button5.TabIndex = 96
        Button5.Text = "Pegar CatalogID"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' DataGridView4
        ' 
        DataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView4.Location = New Point(350, 411)
        DataGridView4.Name = "DataGridView4"
        DataGridView4.RowTemplate.Height = 25
        DataGridView4.Size = New Size(657, 180)
        DataGridView4.TabIndex = 97
        ' 
        ' Ventas
        ' 
        Ventas.Location = New Point(269, 568)
        Ventas.Name = "Ventas"
        Ventas.Size = New Size(75, 23)
        Ventas.TabIndex = 98
        Ventas.Text = "2) Ventas"
        Ventas.UseVisualStyleBackColor = True
        Ventas.Visible = False
        ' 
        ' Datos
        ' 
        Datos.Location = New Point(12, 42)
        Datos.Name = "Datos"
        Datos.Size = New Size(80, 23)
        Datos.TabIndex = 99
        Datos.Text = "3) Datos API"
        Datos.UseVisualStyleBackColor = True
        ' 
        ' reporte_a_compras
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateBlue
        ClientSize = New Size(1374, 630)
        Controls.Add(Datos)
        Controls.Add(Ventas)
        Controls.Add(DataGridView4)
        Controls.Add(Button5)
        Controls.Add(GroupBox1)
        Controls.Add(DataGridView2)
        Controls.Add(btnPasteFromClipboard)
        Controls.Add(Button4)
        Controls.Add(txtPorcentaje)
        Controls.Add(Button3)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Controls.Add(DataGridView1)
        Controls.Add(Label9)
        Name = "reporte_a_compras"
        Text = "d"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DataGridView4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnPasteFromClipboard As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents txtPorcentaje As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label9 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents CatalogProductId As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnPasteFromClipboard2 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLimiteFacturacion As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents Ventas As Button
    Friend WithEvents Datos As Button
End Class
