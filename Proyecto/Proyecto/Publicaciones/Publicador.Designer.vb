<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Publicador
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
        Label3 = New Label()
        GroupBox3 = New GroupBox()
        Label5 = New Label()
        lbl_sku2 = New Label()
        TextBox3 = New TextBox()
        Label2 = New Label()
        Button2 = New Button()
        TextBox4 = New TextBox()
        GroupBox1 = New GroupBox()
        txt_replicar = New TextBox()
        btn_replicar = New Button()
        GroupBox2 = New GroupBox()
        Label4 = New Label()
        lbl_sku1 = New Label()
        TextBox1 = New TextBox()
        Label1 = New Label()
        Button1 = New Button()
        TextBox2 = New TextBox()
        asd = New GroupBox()
        txt_sku = New TextBox()
        txt_sku6 = New TextBox()
        txt_sku3 = New TextBox()
        txt_sku4 = New TextBox()
        txt_sku5 = New TextBox()
        txt_sku2 = New TextBox()
        Panel2 = New Panel()
        items_mercadolibre = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        Panel1 = New Panel()
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
        txt_eliminar_nuevas = New Button()
        OpenFileDialog1 = New OpenFileDialog()
        GroupBox4 = New GroupBox()
        txtCatalogProductID = New TextBox()
        Button3 = New Button()
        txtTitle = New TextBox()
        txtCategoryID = New TextBox()
        GroupBox3.SuspendLayout()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        asd.SuspendLayout()
        Panel2.SuspendLayout()
        CType(items_mercadolibre, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(publicaciones_mercado_libre_basico, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox4.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label3.ForeColor = Color.Silver
        Label3.Location = New Point(203, 538)
        Label3.Name = "Label3"
        Label3.Size = New Size(152, 15)
        Label3.TabIndex = 26
        Label3.Text = "Powered by SALE HACKS®"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(Label5)
        GroupBox3.Controls.Add(lbl_sku2)
        GroupBox3.Controls.Add(TextBox3)
        GroupBox3.Controls.Add(Label2)
        GroupBox3.Controls.Add(Button2)
        GroupBox3.Controls.Add(TextBox4)
        GroupBox3.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox3.ForeColor = Color.White
        GroupBox3.Location = New Point(11, 399)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(336, 108)
        GroupBox3.TabIndex = 24
        GroupBox3.TabStop = False
        GroupBox3.Text = "Nueva publicación PREMIUM"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label5.ForeColor = Color.Silver
        Label5.Location = New Point(96, 90)
        Label5.Name = "Label5"
        Label5.Size = New Size(107, 15)
        Label5.TabIndex = 19
        Label5.Text = "Se creo con el SKU:"
        ' 
        ' lbl_sku2
        ' 
        lbl_sku2.AutoSize = True
        lbl_sku2.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        lbl_sku2.ForeColor = Color.Silver
        lbl_sku2.Location = New Point(206, 90)
        lbl_sku2.Name = "lbl_sku2"
        lbl_sku2.Size = New Size(126, 15)
        lbl_sku2.TabIndex = 18
        lbl_sku2.Text = "ID publicación creada:"
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(172, 55)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(155, 23)
        TextBox3.TabIndex = 16
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(8, 22)
        Label2.Name = "Label2"
        Label2.Size = New Size(161, 21)
        Label2.TabIndex = 14
        Label2.Text = "ID publicación creada:"
        ' 
        ' Button2
        ' 
        Button2.ForeColor = Color.Black
        Button2.Location = New Point(8, 51)
        Button2.Name = "Button2"
        Button2.Size = New Size(158, 29)
        Button2.TabIndex = 15
        Button2.Text = "Modificar publicación"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(172, 22)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(155, 23)
        TextBox4.TabIndex = 10
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txt_replicar)
        GroupBox1.Controls.Add(btn_replicar)
        GroupBox1.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox1.ForeColor = Color.White
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(331, 67)
        GroupBox1.TabIndex = 22
        GroupBox1.TabStop = False
        GroupBox1.Text = "Crear catalogo / indicar MLA"
        ' 
        ' txt_replicar
        ' 
        txt_replicar.Location = New Point(6, 29)
        txt_replicar.Name = "txt_replicar"
        txt_replicar.Size = New Size(155, 23)
        txt_replicar.TabIndex = 2
        ' 
        ' btn_replicar
        ' 
        btn_replicar.ForeColor = Color.Black
        btn_replicar.Location = New Point(167, 28)
        btn_replicar.Name = "btn_replicar"
        btn_replicar.Size = New Size(155, 23)
        btn_replicar.TabIndex = 3
        btn_replicar.Text = "Replicar Catalogo"
        btn_replicar.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(lbl_sku1)
        GroupBox2.Controls.Add(TextBox1)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(Button1)
        GroupBox2.Controls.Add(TextBox2)
        GroupBox2.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox2.ForeColor = Color.White
        GroupBox2.Location = New Point(11, 285)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(336, 108)
        GroupBox2.TabIndex = 23
        GroupBox2.TabStop = False
        GroupBox2.Text = "Nueva publicación CLASICA"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label4.ForeColor = Color.Silver
        Label4.Location = New Point(96, 84)
        Label4.Name = "Label4"
        Label4.Size = New Size(107, 15)
        Label4.TabIndex = 18
        Label4.Text = "Se creo con el SKU:"
        ' 
        ' lbl_sku1
        ' 
        lbl_sku1.AutoSize = True
        lbl_sku1.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        lbl_sku1.ForeColor = Color.Silver
        lbl_sku1.Location = New Point(206, 84)
        lbl_sku1.Name = "lbl_sku1"
        lbl_sku1.Size = New Size(126, 15)
        lbl_sku1.TabIndex = 17
        lbl_sku1.Text = "ID publicación creada:"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(173, 51)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(155, 23)
        TextBox1.TabIndex = 16
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(9, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(161, 21)
        Label1.TabIndex = 14
        Label1.Text = "ID publicación creada:"
        ' 
        ' Button1
        ' 
        Button1.ForeColor = Color.Black
        Button1.Location = New Point(9, 47)
        Button1.Name = "Button1"
        Button1.Size = New Size(158, 29)
        Button1.TabIndex = 15
        Button1.Text = "Modificar publicación"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(173, 20)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(155, 23)
        TextBox2.TabIndex = 10
        ' 
        ' asd
        ' 
        asd.Controls.Add(txt_sku)
        asd.Controls.Add(txt_sku6)
        asd.Controls.Add(txt_sku3)
        asd.Controls.Add(txt_sku4)
        asd.Controls.Add(txt_sku5)
        asd.Controls.Add(txt_sku2)
        asd.Controls.Add(Panel2)
        asd.Controls.Add(Panel1)
        asd.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        asd.ForeColor = Color.White
        asd.Location = New Point(12, 159)
        asd.Name = "asd"
        asd.Size = New Size(331, 120)
        asd.TabIndex = 21
        asd.TabStop = False
        asd.Text = "Indicar SKUS"
        ' 
        ' txt_sku
        ' 
        txt_sku.Location = New Point(6, 26)
        txt_sku.Name = "txt_sku"
        txt_sku.Size = New Size(155, 23)
        txt_sku.TabIndex = 4
        ' 
        ' txt_sku6
        ' 
        txt_sku6.Location = New Point(167, 84)
        txt_sku6.Name = "txt_sku6"
        txt_sku6.Size = New Size(155, 23)
        txt_sku6.TabIndex = 9
        ' 
        ' txt_sku3
        ' 
        txt_sku3.Location = New Point(6, 55)
        txt_sku3.Name = "txt_sku3"
        txt_sku3.Size = New Size(155, 23)
        txt_sku3.TabIndex = 5
        ' 
        ' txt_sku4
        ' 
        txt_sku4.Location = New Point(167, 55)
        txt_sku4.Name = "txt_sku4"
        txt_sku4.Size = New Size(155, 23)
        txt_sku4.TabIndex = 8
        ' 
        ' txt_sku5
        ' 
        txt_sku5.Location = New Point(6, 84)
        txt_sku5.Name = "txt_sku5"
        txt_sku5.Size = New Size(155, 23)
        txt_sku5.TabIndex = 6
        ' 
        ' txt_sku2
        ' 
        txt_sku2.Location = New Point(167, 26)
        txt_sku2.Name = "txt_sku2"
        txt_sku2.Size = New Size(155, 23)
        txt_sku2.TabIndex = 7
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(items_mercadolibre)
        Panel2.Location = New Point(197, 42)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(49, 36)
        Panel2.TabIndex = 13
        Panel2.Visible = False
        ' 
        ' items_mercadolibre
        ' 
        items_mercadolibre.AllowUserToAddRows = False
        items_mercadolibre.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        items_mercadolibre.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5, Column6})
        items_mercadolibre.Location = New Point(3, 15)
        items_mercadolibre.Name = "items_mercadolibre"
        items_mercadolibre.RowTemplate.Height = 25
        items_mercadolibre.Size = New Size(185, 77)
        items_mercadolibre.TabIndex = 1
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
        ' Panel1
        ' 
        Panel1.Controls.Add(publicaciones_mercado_libre_basico)
        Panel1.Location = New Point(21, 42)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(39, 36)
        Panel1.TabIndex = 12
        Panel1.Visible = False
        ' 
        ' publicaciones_mercado_libre_basico
        ' 
        publicaciones_mercado_libre_basico.AllowUserToAddRows = False
        publicaciones_mercado_libre_basico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        publicaciones_mercado_libre_basico.Columns.AddRange(New DataGridViewColumn() {Combo_especial, Column7, Column8, Column9, Column10, Column11, Column12, Column13, Column14, Column15, Column16, Column17, Column18})
        publicaciones_mercado_libre_basico.Location = New Point(3, 13)
        publicaciones_mercado_libre_basico.Name = "publicaciones_mercado_libre_basico"
        publicaciones_mercado_libre_basico.RowTemplate.Height = 25
        publicaciones_mercado_libre_basico.Size = New Size(212, 85)
        publicaciones_mercado_libre_basico.TabIndex = 0
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
        ' txt_eliminar_nuevas
        ' 
        txt_eliminar_nuevas.BackColor = Color.IndianRed
        txt_eliminar_nuevas.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        txt_eliminar_nuevas.Location = New Point(11, 511)
        txt_eliminar_nuevas.Name = "txt_eliminar_nuevas"
        txt_eliminar_nuevas.Size = New Size(139, 42)
        txt_eliminar_nuevas.TabIndex = 25
        txt_eliminar_nuevas.Text = "Eliminar ambas"
        txt_eliminar_nuevas.UseVisualStyleBackColor = False
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(txtCatalogProductID)
        GroupBox4.Controls.Add(Button3)
        GroupBox4.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point)
        GroupBox4.ForeColor = Color.White
        GroupBox4.Location = New Point(11, 86)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(331, 67)
        GroupBox4.TabIndex = 23
        GroupBox4.TabStop = False
        GroupBox4.Text = "Crear catalogo / indicar productID"
        ' 
        ' txtCatalogProductID
        ' 
        txtCatalogProductID.Location = New Point(6, 29)
        txtCatalogProductID.Name = "txtCatalogProductID"
        txtCatalogProductID.Size = New Size(155, 23)
        txtCatalogProductID.TabIndex = 2
        ' 
        ' Button3
        ' 
        Button3.ForeColor = Color.Black
        Button3.Location = New Point(167, 28)
        Button3.Name = "Button3"
        Button3.Size = New Size(155, 23)
        Button3.TabIndex = 3
        Button3.Text = "Replicar"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' txtTitle
        ' 
        txtTitle.Location = New Point(365, 23)
        txtTitle.Name = "txtTitle"
        txtTitle.Size = New Size(155, 23)
        txtTitle.TabIndex = 4
        txtTitle.Visible = False
        ' 
        ' txtCategoryID
        ' 
        txtCategoryID.Location = New Point(365, 56)
        txtCategoryID.Name = "txtCategoryID"
        txtCategoryID.Size = New Size(155, 23)
        txtCategoryID.TabIndex = 27
        txtCategoryID.Visible = False
        ' 
        ' Publicador
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        ClientSize = New Size(358, 566)
        Controls.Add(txtCategoryID)
        Controls.Add(txtTitle)
        Controls.Add(GroupBox4)
        Controls.Add(Label3)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox1)
        Controls.Add(GroupBox2)
        Controls.Add(asd)
        Controls.Add(txt_eliminar_nuevas)
        Name = "Publicador"
        Text = "Publicador"
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        asd.ResumeLayout(False)
        asd.PerformLayout()
        Panel2.ResumeLayout(False)
        CType(items_mercadolibre, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        CType(publicaciones_mercado_libre_basico, ComponentModel.ISupportInitialize).EndInit()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lbl_sku2 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txt_replicar As TextBox
    Friend WithEvents btn_replicar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_sku1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents asd As GroupBox
    Friend WithEvents txt_sku As TextBox
    Friend WithEvents txt_sku6 As TextBox
    Friend WithEvents txt_sku3 As TextBox
    Friend WithEvents txt_sku4 As TextBox
    Friend WithEvents txt_sku5 As TextBox
    Friend WithEvents txt_sku2 As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents items_mercadolibre As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
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
    Friend WithEvents txt_eliminar_nuevas As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtCatalogProductID As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtCategoryID As TextBox
End Class
