<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Descuentos
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
        check_finde = New CheckBox()
        GroupBox2 = New GroupBox()
        Label3 = New Label()
        txt_fechafin = New TextBox()
        Label4 = New Label()
        txt_horafin = New TextBox()
        GroupBox1 = New GroupBox()
        Label2 = New Label()
        txt_fechainicio = New TextBox()
        Label5 = New Label()
        txt_horainicio = New TextBox()
        Label7 = New Label()
        Label1 = New Label()
        txt_palabrafiltro = New TextBox()
        DataGridView1 = New DataGridView()
        ID = New DataGridViewTextBoxColumn()
        Titulo = New DataGridViewTextBoxColumn()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        listado_ventas = New Button()
        btnEliminarDescuento = New Button()
        txtDescuento = New TextBox()
        btn_Actualizar = New Button()
        Label9 = New Label()
        Combo_catalogo = New ComboBox()
        Combo_descuentos = New ComboBox()
        Label8 = New Label()
        Label10 = New Label()
        label_tipo = New Label()
        combo_tipo = New ComboBox()
        lbl_preciodescuento = New Label()
        lbl_preciosindescuento = New Label()
        Label6 = New Label()
        txt_preciodescuento = New TextBox()
        btn_transformar = New Button()
        btn_incremento_descuento = New Button()
        Label12 = New Label()
        txt_incremento = New TextBox()
        Label11 = New Label()
        GroupBox2.SuspendLayout()
        GroupBox1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' check_finde
        ' 
        check_finde.AutoSize = True
        check_finde.BackColor = Color.Transparent
        check_finde.ForeColor = SystemColors.ButtonFace
        check_finde.Location = New Point(240, 193)
        check_finde.Name = "check_finde"
        check_finde.Size = New Size(102, 19)
        check_finde.TabIndex = 32
        check_finde.Text = "Fin de semana"
        check_finde.UseVisualStyleBackColor = False
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(txt_fechafin)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(txt_horafin)
        GroupBox2.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox2.ForeColor = SystemColors.ButtonFace
        GroupBox2.Location = New Point(178, 139)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(164, 48)
        GroupBox2.TabIndex = 39
        GroupBox2.TabStop = False
        GroupBox2.Text = "Fin"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = SystemColors.ButtonFace
        Label3.Location = New Point(6, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 15)
        Label3.TabIndex = 10
        Label3.Text = "Fecha fin"
        ' 
        ' txt_fechafin
        ' 
        txt_fechafin.Location = New Point(78, 16)
        txt_fechafin.Name = "txt_fechafin"
        txt_fechafin.Size = New Size(78, 23)
        txt_fechafin.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.ForeColor = SystemColors.ButtonFace
        Label4.Location = New Point(166, 19)
        Label4.Name = "Label4"
        Label4.Size = New Size(52, 15)
        Label4.TabIndex = 13
        Label4.Text = "Hora fin"
        ' 
        ' txt_horafin
        ' 
        txt_horafin.Location = New Point(238, 16)
        txt_horafin.Name = "txt_horafin"
        txt_horafin.Size = New Size(78, 23)
        txt_horafin.TabIndex = 15
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(txt_fechainicio)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(txt_horainicio)
        GroupBox1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox1.ForeColor = SystemColors.ButtonFace
        GroupBox1.Location = New Point(176, 90)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(166, 49)
        GroupBox1.TabIndex = 38
        GroupBox1.TabStop = False
        GroupBox1.Text = "Inicio"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = SystemColors.ButtonFace
        Label2.Location = New Point(8, 20)
        Label2.Name = "Label2"
        Label2.Size = New Size(71, 15)
        Label2.TabIndex = 9
        Label2.Text = "Fecha inicio"
        ' 
        ' txt_fechainicio
        ' 
        txt_fechainicio.Location = New Point(80, 17)
        txt_fechainicio.Name = "txt_fechainicio"
        txt_fechainicio.Size = New Size(78, 23)
        txt_fechainicio.TabIndex = 3
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = SystemColors.ButtonFace
        Label5.Location = New Point(168, 20)
        Label5.Name = "Label5"
        Label5.Size = New Size(66, 15)
        Label5.TabIndex = 12
        Label5.Text = "Hora inicio"
        ' 
        ' txt_horainicio
        ' 
        txt_horainicio.Location = New Point(240, 17)
        txt_horainicio.Name = "txt_horainicio"
        txt_horainicio.Size = New Size(78, 23)
        txt_horainicio.TabIndex = 14
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.ForeColor = SystemColors.ButtonFace
        Label7.Location = New Point(171, 48)
        Label7.Name = "Label7"
        Label7.Size = New Size(19, 17)
        Label7.TabIndex = 34
        Label7.Text = "%"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.ButtonFace
        Label1.Location = New Point(125, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 21)
        Label1.TabIndex = 31
        Label1.Text = "Descuento"
        ' 
        ' txt_palabrafiltro
        ' 
        txt_palabrafiltro.Location = New Point(94, 253)
        txt_palabrafiltro.Name = "txt_palabrafiltro"
        txt_palabrafiltro.Size = New Size(249, 23)
        txt_palabrafiltro.TabIndex = 30
        txt_palabrafiltro.Text = "Palabra filtro o ID de producto"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {ID, Titulo, Column1, Column2, Column3, Column4})
        DataGridView1.Location = New Point(8, 283)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(334, 150)
        DataGridView1.TabIndex = 29
        ' 
        ' ID
        ' 
        ID.HeaderText = "ID"
        ID.Name = "ID"
        ' 
        ' Titulo
        ' 
        Titulo.HeaderText = "Titulo"
        Titulo.Name = "Titulo"
        Titulo.Width = 300
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
        ' listado_ventas
        ' 
        listado_ventas.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        listado_ventas.Location = New Point(8, 223)
        listado_ventas.Name = "listado_ventas"
        listado_ventas.Size = New Size(78, 53)
        listado_ventas.TabIndex = 28
        listado_ventas.Text = "Buscar"
        listado_ventas.UseVisualStyleBackColor = True
        ' 
        ' btnEliminarDescuento
        ' 
        btnEliminarDescuento.BackColor = Color.IndianRed
        btnEliminarDescuento.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        btnEliminarDescuento.ForeColor = SystemColors.Control
        btnEliminarDescuento.Location = New Point(8, 51)
        btnEliminarDescuento.Name = "btnEliminarDescuento"
        btnEliminarDescuento.Size = New Size(99, 35)
        btnEliminarDescuento.TabIndex = 27
        btnEliminarDescuento.Text = "Eliminar oferta"
        btnEliminarDescuento.UseVisualStyleBackColor = False
        ' 
        ' txtDescuento
        ' 
        txtDescuento.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        txtDescuento.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        txtDescuento.Location = New Point(144, 46)
        txtDescuento.Name = "txtDescuento"
        txtDescuento.Size = New Size(27, 25)
        txtDescuento.TabIndex = 26
        txtDescuento.Text = "10"
        txtDescuento.TextAlign = HorizontalAlignment.Center
        ' 
        ' btn_Actualizar
        ' 
        btn_Actualizar.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        btn_Actualizar.Location = New Point(8, 10)
        btn_Actualizar.Name = "btn_Actualizar"
        btn_Actualizar.Size = New Size(99, 35)
        btn_Actualizar.TabIndex = 24
        btn_Actualizar.Text = "Aplicar oferta"
        btn_Actualizar.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label9.ForeColor = Color.DarkGray
        Label9.Location = New Point(94, 436)
        Label9.Name = "Label9"
        Label9.Size = New Size(152, 15)
        Label9.TabIndex = 40
        Label9.Text = "Powered by SALE HACKS®"
        ' 
        ' Combo_catalogo
        ' 
        Combo_catalogo.FormattingEnabled = True
        Combo_catalogo.Items.AddRange(New Object() {"SI", "NO", "TODOS"})
        Combo_catalogo.Location = New Point(147, 222)
        Combo_catalogo.Name = "Combo_catalogo"
        Combo_catalogo.Size = New Size(62, 23)
        Combo_catalogo.TabIndex = 41
        Combo_catalogo.Text = "TODOS"
        ' 
        ' Combo_descuentos
        ' 
        Combo_descuentos.FormattingEnabled = True
        Combo_descuentos.Items.AddRange(New Object() {"SI", "NO", "TODOS"})
        Combo_descuentos.Location = New Point(280, 223)
        Combo_descuentos.Name = "Combo_descuentos"
        Combo_descuentos.Size = New Size(62, 23)
        Combo_descuentos.TabIndex = 42
        Combo_descuentos.Text = "TODOS"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.ForeColor = SystemColors.ButtonFace
        Label8.Location = New Point(90, 226)
        Label8.Name = "Label8"
        Label8.Size = New Size(55, 15)
        Label8.TabIndex = 16
        Label8.Text = "Catalogo"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.ForeColor = SystemColors.ButtonFace
        Label10.Location = New Point(216, 228)
        Label10.Name = "Label10"
        Label10.Size = New Size(63, 15)
        Label10.TabIndex = 43
        Label10.Text = "Descuento"
        ' 
        ' label_tipo
        ' 
        label_tipo.AutoSize = True
        label_tipo.ForeColor = SystemColors.ButtonFace
        label_tipo.Location = New Point(95, 197)
        label_tipo.Name = "label_tipo"
        label_tipo.Size = New Size(30, 15)
        label_tipo.TabIndex = 48
        label_tipo.Text = "Tipo"
        ' 
        ' combo_tipo
        ' 
        combo_tipo.FormattingEnabled = True
        combo_tipo.Items.AddRange(New Object() {"CLASICA", "PREMIUM", "TODOS"})
        combo_tipo.Location = New Point(129, 193)
        combo_tipo.Name = "combo_tipo"
        combo_tipo.Size = New Size(80, 23)
        combo_tipo.TabIndex = 47
        combo_tipo.Text = "TODOS"
        ' 
        ' lbl_preciodescuento
        ' 
        lbl_preciodescuento.AutoSize = True
        lbl_preciodescuento.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        lbl_preciodescuento.ForeColor = Color.PaleGreen
        lbl_preciodescuento.Location = New Point(269, 34)
        lbl_preciodescuento.Name = "lbl_preciodescuento"
        lbl_preciodescuento.Size = New Size(47, 21)
        lbl_preciodescuento.TabIndex = 15
        lbl_preciodescuento.Text = "Final"
        ' 
        ' lbl_preciosindescuento
        ' 
        lbl_preciosindescuento.AutoSize = True
        lbl_preciosindescuento.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        lbl_preciosindescuento.ForeColor = Color.Tomato
        lbl_preciosindescuento.Location = New Point(276, 17)
        lbl_preciosindescuento.Name = "lbl_preciosindescuento"
        lbl_preciosindescuento.Size = New Size(32, 15)
        lbl_preciosindescuento.TabIndex = 49
        lbl_preciosindescuento.Text = "Final"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial Narrow", 17.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.ForeColor = SystemColors.ControlDark
        Label6.Location = New Point(213, 30)
        Label6.Name = "Label6"
        Label6.Size = New Size(34, 27)
        Label6.TabIndex = 16
        Label6.Text = ">>"
        ' 
        ' txt_preciodescuento
        ' 
        txt_preciodescuento.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        txt_preciodescuento.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        txt_preciodescuento.Location = New Point(265, 59)
        txt_preciodescuento.Name = "txt_preciodescuento"
        txt_preciodescuento.Size = New Size(71, 25)
        txt_preciodescuento.TabIndex = 50
        txt_preciodescuento.TextAlign = HorizontalAlignment.Center
        ' 
        ' btn_transformar
        ' 
        btn_transformar.Location = New Point(207, 60)
        btn_transformar.Name = "btn_transformar"
        btn_transformar.Size = New Size(42, 24)
        btn_transformar.TabIndex = 51
        btn_transformar.Text = "<<"
        btn_transformar.UseVisualStyleBackColor = True
        ' 
        ' btn_incremento_descuento
        ' 
        btn_incremento_descuento.BackColor = Color.FromArgb(CByte(192), CByte(192), CByte(255))
        btn_incremento_descuento.Location = New Point(8, 92)
        btn_incremento_descuento.Name = "btn_incremento_descuento"
        btn_incremento_descuento.Size = New Size(99, 38)
        btn_incremento_descuento.TabIndex = 79
        btn_incremento_descuento.Text = "Aplica suba + baja"
        btn_incremento_descuento.UseVisualStyleBackColor = False
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label12.ForeColor = SystemColors.ButtonFace
        Label12.Location = New Point(58, 158)
        Label12.Name = "Label12"
        Label12.Size = New Size(19, 17)
        Label12.TabIndex = 82
        Label12.Text = "%"
        ' 
        ' txt_incremento
        ' 
        txt_incremento.BackColor = Color.FromArgb(CByte(192), CByte(192), CByte(255))
        txt_incremento.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        txt_incremento.Location = New Point(31, 156)
        txt_incremento.Name = "txt_incremento"
        txt_incremento.Size = New Size(27, 25)
        txt_incremento.TabIndex = 81
        txt_incremento.Text = "10"
        txt_incremento.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.ForeColor = SystemColors.ButtonFace
        Label11.Location = New Point(10, 132)
        Label11.Name = "Label11"
        Label11.Size = New Size(89, 21)
        Label11.TabIndex = 80
        Label11.Text = "Incremento"
        ' 
        ' Descuentos
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        ClientSize = New Size(352, 453)
        Controls.Add(Label12)
        Controls.Add(txt_incremento)
        Controls.Add(Label11)
        Controls.Add(btn_incremento_descuento)
        Controls.Add(btn_transformar)
        Controls.Add(txt_preciodescuento)
        Controls.Add(Label6)
        Controls.Add(lbl_preciosindescuento)
        Controls.Add(lbl_preciodescuento)
        Controls.Add(label_tipo)
        Controls.Add(combo_tipo)
        Controls.Add(Label10)
        Controls.Add(Label8)
        Controls.Add(Combo_descuentos)
        Controls.Add(Combo_catalogo)
        Controls.Add(Label9)
        Controls.Add(check_finde)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(Label7)
        Controls.Add(Label1)
        Controls.Add(txt_palabrafiltro)
        Controls.Add(DataGridView1)
        Controls.Add(listado_ventas)
        Controls.Add(btnEliminarDescuento)
        Controls.Add(txtDescuento)
        Controls.Add(btn_Actualizar)
        Name = "Descuentos"
        Text = "Descuentos"
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents check_finde As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_fechafin As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_horafin As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_fechainicio As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_horainicio As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_palabrafiltro As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Titulo As DataGridViewTextBoxColumn
    Friend WithEvents listado_ventas As Button
    Friend WithEvents btnEliminarDescuento As Button
    Friend WithEvents txtDescuento As TextBox
    Friend WithEvents btn_Actualizar As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Combo_catalogo As ComboBox
    Friend WithEvents Combo_descuentos As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents label_tipo As Label
    Friend WithEvents combo_tipo As ComboBox
    Friend WithEvents lbl_preciodescuento As Label
    Friend WithEvents lbl_preciosindescuento As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_preciodescuento As TextBox
    Friend WithEvents btn_transformar As Button
    Friend WithEvents btn_incremento_descuento As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_incremento As TextBox
    Friend WithEvents Label11 As Label
End Class
