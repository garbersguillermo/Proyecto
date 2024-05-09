<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Busqueda_organica
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
        Label9 = New Label()
        TextBox1 = New TextBox()
        btnCargarDatos = New Button()
        Button1 = New Button()
        RichTextBox1 = New RichTextBox()
        Button2 = New Button()
        Button3 = New Button()
        txtPorcentaje = New TextBox()
        ComboBox1 = New ComboBox()
        btnPasteFromClipboard = New Button()
        DataGridView1 = New DataGridView()
        CatalogProductId = New DataGridViewTextBoxColumn()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label9.ForeColor = Color.DarkGray
        Label9.Location = New Point(97, 307)
        Label9.Name = "Label9"
        Label9.Size = New Size(152, 15)
        Label9.TabIndex = 66
        Label9.Text = "Powered by SALE HACKS®"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(255, 310)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(240, 23)
        TextBox1.TabIndex = 69
        ' 
        ' btnCargarDatos
        ' 
        btnCargarDatos.Location = New Point(10, 40)
        btnCargarDatos.Name = "btnCargarDatos"
        btnCargarDatos.Size = New Size(75, 23)
        btnCargarDatos.TabIndex = 70
        btnCargarDatos.Text = "Obtener datos"
        btnCargarDatos.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(166, 40)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 73
        Button1.Text = "Segundo"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Location = New Point(423, 41)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(157, 234)
        RichTextBox1.TabIndex = 74
        RichTextBox1.Text = "Fv" & vbLf & "Ferrum" & vbLf & "Piazza" & vbLf & "Rowa" & vbLf & "Hydros" & vbLf & "Johnson" & vbLf & "Mi Pileta" & vbLf & "Atrim" & vbLf & "Peirano" & vbLf & "Aqualaf"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(89, 40)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 75
        Button2.Text = "Primero"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(243, 39)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 76
        Button3.Text = "Tercero"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' txtPorcentaje
        ' 
        txtPorcentaje.Location = New Point(361, 39)
        txtPorcentaje.Name = "txtPorcentaje"
        txtPorcentaje.Size = New Size(22, 23)
        txtPorcentaje.TabIndex = 77
        txtPorcentaje.Text = "38"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"me2", "not_specified", "custom"})
        ComboBox1.Location = New Point(423, 12)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(121, 23)
        ComboBox1.TabIndex = 78
        ComboBox1.Tag = ""
        ComboBox1.Text = "me2"
        ' 
        ' btnPasteFromClipboard
        ' 
        btnPasteFromClipboard.Location = New Point(10, 308)
        btnPasteFromClipboard.Name = "btnPasteFromClipboard"
        btnPasteFromClipboard.Size = New Size(75, 23)
        btnPasteFromClipboard.TabIndex = 80
        btnPasteFromClipboard.Text = "Pegar"
        btnPasteFromClipboard.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {CatalogProductId})
        DataGridView1.Location = New Point(10, 72)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(373, 206)
        DataGridView1.TabIndex = 81
        ' 
        ' CatalogProductId
        ' 
        CatalogProductId.HeaderText = "CatalogProductId"
        CatalogProductId.Name = "CatalogProductId"
        ' 
        ' Busqueda_organica
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        ClientSize = New Size(621, 339)
        Controls.Add(DataGridView1)
        Controls.Add(btnPasteFromClipboard)
        Controls.Add(ComboBox1)
        Controls.Add(txtPorcentaje)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(RichTextBox1)
        Controls.Add(Button1)
        Controls.Add(btnCargarDatos)
        Controls.Add(TextBox1)
        Controls.Add(Label9)
        Name = "Busqueda_organica"
        Text = "Form1"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnCargarDatos As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents txtPorcentaje As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnPasteFromClipboard As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CatalogProductId As DataGridViewTextBoxColumn
End Class
