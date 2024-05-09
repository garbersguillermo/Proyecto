Imports System.Text

Public Class Syteline

    Private datosCopiados As Boolean = False
    Private Sub items_mercadolibre_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles items_mercadolibre.CellContentClick

    End Sub

    Private Sub copiado1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_copiar1_Click(sender As Object, e As EventArgs) Handles btn_copiar1.Click

        datosCopiados = True

        Dim sb As New StringBuilder()

        'Agregar contenido de las filas al StringBuilder
        For Each row As DataGridViewRow In publicaciones_mercado_libre_basico.Rows
            If Not row.IsNewRow Then
                For Each cell As DataGridViewCell In row.Cells
                    sb.Append(cell.Value.ToString() & vbTab)
                Next
                sb.AppendLine()
            End If
        Next

        'Copiar contenido al portapapeles
        Clipboard.SetText(sb.ToString())

        btn_copiar1.BackColor = Color.Green
        btn_copiar1.ForeColor = Color.White
        btn_copiar1.Text = "Copiado"

        'Iniciar el temporizador
        Timer1.Interval = 4000
        Timer1.Start()
    End Sub

    Private Sub Syteline_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Syteline_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not datosCopiados Then
            Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que deseas cerrar sin haber copiado los datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If resultado = DialogResult.No Then
                e.Cancel = True ' Cancela el cierre del formulario.
            Else
                Dim Replicar_publicacion As Form = Application.OpenForms("Replicar_publicacion") ' Obtener la instancia del formulario 1
                Replicar_publicacion.Close() ' Cerrar el formulario 1
                Replicar_publicacion.Dispose()
            End If
        End If


    End Sub

    Private Sub btn_copiar2_Click(sender As Object, e As EventArgs) Handles btn_copiar2.Click

        datosCopiados = True

        Dim sb As New StringBuilder()

        'Agregar contenido de las filas al StringBuilder
        For Each row As DataGridViewRow In items_mercadolibre.Rows
            If Not row.IsNewRow Then
                For Each cell As DataGridViewCell In row.Cells
                    sb.Append(cell.Value.ToString() & vbTab)
                Next
                sb.AppendLine()
            End If
        Next

        'Copiar contenido al portapapeles
        Clipboard.SetText(sb.ToString())

        btn_copiar2.BackColor = Color.Green
        btn_copiar2.ForeColor = Color.White
        btn_copiar2.Text = "Copiado"

        'Iniciar el temporizador
        Timer1.Interval = 4000
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Cambiar el formato del botón al formato original
        btn_copiar1.BackColor = SystemColors.Control
        btn_copiar1.ForeColor = SystemColors.ControlText
        btn_copiar1.Text = "Copiar"

        btn_copiar2.BackColor = SystemColors.Control
        btn_copiar2.ForeColor = SystemColors.ControlText
        btn_copiar2.Text = "Copiar"

        'Detener el temporizador
        Timer1.Stop()
    End Sub




End Class