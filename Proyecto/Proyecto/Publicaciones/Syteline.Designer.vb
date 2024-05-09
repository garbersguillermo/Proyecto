<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Syteline
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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        items_mercadolibre = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        publicaciones_mercado_libre_basico = New DataGridView()
        Combo_especial = New DataGridViewTextBoxColumn()
        Column7 = New DataGridViewTextBoxColumn()
        Column8 = New DataGridViewTextBoxColumn()
        Column9 = New DataGridViewTextBoxColumn()
        Column10 = New DataGridViewTextBoxColumn()
        Column11 = New DataGridViewTextBoxColumn()
        Column12 = New DataGridViewTextBoxColumn()
        Column13 = New DataGridViewTextBoxColumn()
        Column14 = New DataGridViewTextBoxColumn()
        Column15 = New DataGridViewTextBoxColumn()
        Column16 = New DataGridViewTextBoxColumn()
        Column17 = New DataGridViewTextBoxColumn()
        Column18 = New DataGridViewTextBoxColumn()
        btn_copiar1 = New Button()
        btn_copiar2 = New Button()
        Timer1 = New Timer(components)
        GroupBox1 = New GroupBox()
        GroupBox2 = New GroupBox()
        CType(items_mercadolibre, ComponentModel.ISupportInitialize).BeginInit()
        CType(publicaciones_mercado_libre_basico, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' items_mercadolibre
        ' 
        items_mercadolibre.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        items_mercadolibre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        items_mercadolibre.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        items_mercadolibre.ColumnHeadersVisible = False
        items_mercadolibre.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5, Column6})
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        items_mercadolibre.DefaultCellStyle = DataGridViewCellStyle2
        items_mercadolibre.Location = New Point(12, 21)
        items_mercadolibre.Name = "items_mercadolibre"
        items_mercadolibre.RowTemplate.Height = 25
        items_mercadolibre.Size = New Size(273, 155)
        items_mercadolibre.TabIndex = 3
        ' 
        ' Column1
        ' 
        Column1.HeaderText = "Column1"
        Column1.Name = "Column1"
        ' 
        ' Column2
        ' 
        Column2.HeaderText = "Column2"
        Column2.Name = "Column2"
        ' 
        ' Column3
        ' 
        Column3.HeaderText = "Column3"
        Column3.Name = "Column3"
        ' 
        ' Column4
        ' 
        Column4.HeaderText = "Column4"
        Column4.Name = "Column4"
        ' 
        ' Column5
        ' 
        Column5.HeaderText = "Column5"
        Column5.Name = "Column5"
        ' 
        ' Column6
        ' 
        Column6.HeaderText = "Column6"
        Column6.Name = "Column6"
        ' 
        ' publicaciones_mercado_libre_basico
        ' 
        publicaciones_mercado_libre_basico.AllowUserToAddRows = False
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        publicaciones_mercado_libre_basico.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        publicaciones_mercado_libre_basico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        publicaciones_mercado_libre_basico.ColumnHeadersVisible = False
        publicaciones_mercado_libre_basico.Columns.AddRange(New DataGridViewColumn() {Combo_especial, Column7, Column8, Column9, Column10, Column11, Column12, Column13, Column14, Column15, Column16, Column17, Column18})
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = SystemColors.Window
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle4.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.False
        publicaciones_mercado_libre_basico.DefaultCellStyle = DataGridViewCellStyle4
        publicaciones_mercado_libre_basico.Location = New Point(12, 22)
        publicaciones_mercado_libre_basico.Name = "publicaciones_mercado_libre_basico"
        publicaciones_mercado_libre_basico.RowTemplate.Height = 25
        publicaciones_mercado_libre_basico.Size = New Size(273, 154)
        publicaciones_mercado_libre_basico.TabIndex = 2
        ' 
        ' Combo_especial
        ' 
        Combo_especial.HeaderText = "Column7"
        Combo_especial.Name = "Combo_especial"
        ' 
        ' Column7
        ' 
        Column7.HeaderText = "Column7"
        Column7.Name = "Column7"
        ' 
        ' Column8
        ' 
        Column8.HeaderText = "Column8"
        Column8.Name = "Column8"
        ' 
        ' Column9
        ' 
        Column9.HeaderText = "Column9"
        Column9.Name = "Column9"
        ' 
        ' Column10
        ' 
        Column10.HeaderText = "Column10"
        Column10.Name = "Column10"
        ' 
        ' Column11
        ' 
        Column11.HeaderText = "Column11"
        Column11.Name = "Column11"
        ' 
        ' Column12
        ' 
        Column12.HeaderText = "Column12"
        Column12.Name = "Column12"
        ' 
        ' Column13
        ' 
        Column13.HeaderText = "Column13"
        Column13.Name = "Column13"
        ' 
        ' Column14
        ' 
        Column14.HeaderText = "Column14"
        Column14.Name = "Column14"
        ' 
        ' Column15
        ' 
        Column15.HeaderText = "Column15"
        Column15.Name = "Column15"
        ' 
        ' Column16
        ' 
        Column16.HeaderText = "Column16"
        Column16.Name = "Column16"
        ' 
        ' Column17
        ' 
        Column17.HeaderText = "Column17"
        Column17.Name = "Column17"
        ' 
        ' Column18
        ' 
        Column18.HeaderText = "Column18"
        Column18.Name = "Column18"
        ' 
        ' btn_copiar1
        ' 
        btn_copiar1.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        btn_copiar1.Location = New Point(291, 72)
        btn_copiar1.Name = "btn_copiar1"
        btn_copiar1.Size = New Size(118, 46)
        btn_copiar1.TabIndex = 8
        btn_copiar1.Text = "Copiar"
        btn_copiar1.UseVisualStyleBackColor = True
        ' 
        ' btn_copiar2
        ' 
        btn_copiar2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        btn_copiar2.Location = New Point(291, 74)
        btn_copiar2.Name = "btn_copiar2"
        btn_copiar2.Size = New Size(118, 46)
        btn_copiar2.TabIndex = 9
        btn_copiar2.Text = "Copiar"
        btn_copiar2.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(items_mercadolibre)
        GroupBox1.Controls.Add(btn_copiar2)
        GroupBox1.Location = New Point(9, 219)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(415, 186)
        GroupBox1.TabIndex = 10
        GroupBox1.TabStop = False
        GroupBox1.Text = "Items de Mercado Libre"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(publicaciones_mercado_libre_basico)
        GroupBox2.Controls.Add(btn_copiar1)
        GroupBox2.Location = New Point(8, 10)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(415, 203)
        GroupBox2.TabIndex = 11
        GroupBox2.TabStop = False
        GroupBox2.Text = "Publicaciones de Mercado Libre Basico"
        ' 
        ' Syteline
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(435, 414)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Name = "Syteline"
        Text = "Syteline"
        CType(items_mercadolibre, ComponentModel.ISupportInitialize).EndInit()
        CType(publicaciones_mercado_libre_basico, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents items_mercadolibre As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents publicaciones_mercado_libre_basico As DataGridView
    Friend WithEvents Combo_especial As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents btn_copiar1 As Button
    Friend WithEvents btn_copiar2 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
