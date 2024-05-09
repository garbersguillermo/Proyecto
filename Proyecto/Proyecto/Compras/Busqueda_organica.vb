Imports System.Globalization
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Busqueda_organica
    Public token As String
    Private Shared ReadOnly HttpClient As New HttpClient()
    Private Shared ReadOnly MaxDegreeOfParallelism As Integer = 20 ' Ajusta este número según sea apropiado para tu situación.
    Private Shared ReadOnly Semaphore As New SemaphoreSlim(MaxDegreeOfParallelism)
    Private WithEvents ButtonEjecutar As Button

    Public Class Resultado
        Public Property id As String

        Public Property Etiqueta As String

        'Public Property catalog_product_id As String
        'Public Property title As String

    End Class

    Public Class RespuestaAPI
        Public Property results As List(Of Resultado)
    End Class


    Private Async Function ProcessQueryAsync(query As String) As Task(Of List(Of Resultado))
        Dim offset As Integer = 0
        Dim limit As Integer = 50
        Dim maxResults As Integer = 1000
        Dim client As New HttpClient()
        Dim resultados As New List(Of Resultado)

        While offset < maxResults
            Try
                Dim response As HttpResponseMessage = Await client.GetAsync($"https://api.mercadolibre.com/sites/MLA/search?q={query}&offset={offset}&limit={limit}")
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                If response.IsSuccessStatusCode Then
                    Dim respuesta As RespuestaAPI = JsonConvert.DeserializeObject(Of RespuestaAPI)(responseBody)

                    ' Agregar los resultados a la lista con la etiqueta/nombre de la consulta
                    For Each resultado In respuesta.results
                        resultado.Etiqueta = query
                        resultados.Add(resultado)
                    Next

                    If respuesta.results.Count < limit Then
                        Exit While
                    End If

                    offset += limit
                Else
                    MessageBox.Show($"Error obteniendo datos de la API. Código de Estado: {response.StatusCode.ToString()} - Respuesta: {responseBody}")
                    Exit While
                End If
            Catch ex As Exception
                ' Manejar la excepción y mostrar un mensaje de error
                MessageBox.Show($"Error al realizar la solicitud a la API: {ex.Message}")
                Exit While
            End Try

        End While

        Return resultados
    End Function


    Private Async Sub btnCargarDatos_Click(sender As Object, e As EventArgs) Handles btnCargarDatos.Click
        TextBox1.Text = ComboBox1.Text

        DataGridView1.DataSource = Nothing
        ' Limpiar el DataGridView
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        ' Crear una columna "CatalogProductId"
        Dim col As New DataGridViewTextBoxColumn()
        col.Name = "CatalogProductId"
        col.HeaderText = "CatalogProductId"
        DataGridView1.Columns.Add(col)

        Dim todosLosResultados As New List(Of Resultado)

        ' Procesar cada línea del RichTextBox de forma independiente
        For Each query In RichTextBox1.Lines
            Dim resultados = Await ProcessQueryAsync(query)
            todosLosResultados.AddRange(resultados)
        Next

        ' Asignar todos los resultados al DataGridView
        DataGridView1.DataSource = todosLosResultados
    End Sub

    Private Sub Busqueda_organica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MLToken()
        TextBox1.Text = token
    End Sub




    Private Sub EliminarDuplicadosSegundaColumna()
        '' Crear un HashSet para almacenar valores únicos de la segunda columna
        'Dim valoresUnicos As New HashSet(Of String)()

        '' Obtener el índice de la segunda columna en función de su nombre
        'Dim segundaColumnaIndex As Integer = DataGridView1.Columns("catalog_product_id").Index

        '' Obtener la lista de resultados enlazada al DataGridView
        'Dim resultados As List(Of Resultado) = DirectCast(DataGridView1.DataSource, List(Of Resultado))

        '' Crear una nueva lista para almacenar los datos filtrados
        'Dim resultadosFiltrados As New List(Of Resultado)()

        '' Recorrer todas las filas de la lista original
        'For Each resultado As Resultado In resultados
        '    ' Obtener el valor de la segunda columna
        '    Dim valorSegundaColumna As String = resultado.catalog_product_id

        '    ' Verificar si el valor ya está en el conjunto de valores únicos
        '    If Not valoresUnicos.Contains(valorSegundaColumna) Then
        '        ' Agregar el resultado completo a la lista de resultados filtrados
        '        resultadosFiltrados.Add(resultado)

        '        ' Agregar el valor al conjunto de valores únicos
        '        valoresUnicos.Add(valorSegundaColumna)
        '    End If
        'Next

        '' Actualizar el DataGridView con la lista de resultados filtrados
        'DataGridView1.DataSource = resultadosFiltrados
        Dim hashset As New HashSet(Of String)() ' Para rastrear los valores ya vistos
        Dim nuevoDgv As New DataGridView() ' Nueva instancia de DataGridView

        ' Configurar el nuevo DataGridView con las mismas columnas
        For Each col As DataGridViewColumn In DataGridView1.Columns
            nuevoDgv.Columns.Add(DirectCast(col.Clone(), DataGridViewColumn))
        Next

        ' Transferir las filas que queremos conservar al nuevo DataGridView
        For Each fila As DataGridViewRow In DataGridView1.Rows
            If Not fila.IsNewRow Then
                Dim valor As String = If(fila.Cells("CatalogProductId").Value, "").ToString().Trim()

                ' Si el valor no ha sido visto y no es vacío, transferir la fila al nuevo DataGridView
                If hashset.Add(valor) AndAlso Not String.IsNullOrEmpty(valor) Then
                    nuevoDgv.Rows.Add(fila.Cells.Cast(Of DataGridViewCell)().Select(Function(c) c.Value).ToArray())
                End If
            End If
        Next

        ' Establecer la posición y dimensiones del nuevo DataGridView basado en el original
        nuevoDgv.Location = DataGridView1.Location
        nuevoDgv.Size = DataGridView1.Size
        nuevoDgv.Anchor = DataGridView1.Anchor

        ' Reemplazar el DataGridView original con el nuevo
        Me.Controls.Remove(DataGridView1)
        DataGridView1.Dispose()
        DataGridView1 = nuevoDgv
        Me.Controls.Add(DataGridView1)
    End Sub

    Private Sub EliminarDuplicadosSegundalisting()

        Dim hashset As New HashSet(Of String)() ' Para rastrear los valores ya vistos
        Dim nuevoDgv As New DataGridView() ' Nueva instancia de DataGridView

        ' Configurar el nuevo DataGridView con las mismas columnas
        For Each col As DataGridViewColumn In DataGridView1.Columns
            nuevoDgv.Columns.Add(DirectCast(col.Clone(), DataGridViewColumn))
        Next

        ' Transferir las filas que queremos conservar al nuevo DataGridView
        For Each fila As DataGridViewRow In DataGridView1.Rows
            If Not fila.IsNewRow Then
                Dim valor As String = If(fila.Cells("listing_type_id").Value, "").ToString().Trim()

                ' Si el valor no ha sido visto y no es vacío, transferir la fila al nuevo DataGridView
                If hashset.Add(valor) AndAlso Not String.IsNullOrEmpty(valor) Then
                    nuevoDgv.Rows.Add(fila.Cells.Cast(Of DataGridViewCell)().Select(Function(c) c.Value).ToArray())
                End If
            End If
        Next

        ' Establecer la posición y dimensiones del nuevo DataGridView basado en el original
        nuevoDgv.Location = DataGridView1.Location
        nuevoDgv.Size = DataGridView1.Size
        nuevoDgv.Anchor = DataGridView1.Anchor

        ' Reemplazar el DataGridView original con el nuevo
        Me.Controls.Remove(DataGridView1)
        DataGridView1.Dispose()
        DataGridView1 = nuevoDgv
        Me.Controls.Add(DataGridView1)
    End Sub

    Private Sub EliminarFilasVaciasListingTypeId()
        Dim filasAConservar As New List(Of DataGridViewRow)() ' Lista de filas que queremos conservar

        ' Identificar las filas que queremos conservar
        For Each fila As DataGridViewRow In DataGridView1.Rows
            If Not fila.IsNewRow Then
                Dim valor As String = If(fila.Cells("listing_type_id").Value, "").ToString().Trim()

                ' Si el valor no es vacío, añadir a filasAConservar
                If Not String.IsNullOrEmpty(valor) Then
                    filasAConservar.Add(fila.Clone())
                    For i As Integer = 0 To fila.Cells.Count - 1
                        filasAConservar(filasAConservar.Count - 1).Cells(i).Value = fila.Cells(i).Value
                    Next
                End If
            End If
        Next

        ' Ahora, desvincular el DataGridView (si está vinculado a un origen de datos)
        DataGridView1.DataSource = Nothing

        ' Vaciar el DataGridView, omitiendo la fila "nueva"
        For i As Integer = DataGridView1.Rows.Count - 2 To 0 Step -1 ' Empezamos desde el penúltimo índice y vamos hacia atrás
            DataGridView1.Rows.RemoveAt(i)
        Next

        ' Agregar las filas conservadas
        For Each fila In filasAConservar
            DataGridView1.Rows.Add(fila.Cells.Cast(Of DataGridViewCell)().Select(Function(c) c.Value).ToArray())
        Next
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        catalogoiditem()
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        EliminarDuplicadosSegundaColumna()
        ' Crear nuevas columnas si no existen
        Dim columnsToCreate As String() = {"Costo_Objetivo_pricetowin", "Unidades Vendidas por Mes", "venta estimada", "PriceToWin", "marca", "linea", "modelo", "porcentaje", "name", "permalink", "price", "listing_type_id", "seller_id", "sold_quantity", "date_created", "Meses desde la Creación", "mode"}

        For Each columnName As String In columnsToCreate
            If DataGridView1.Columns(columnName) Is Nothing Then
                DataGridView1.Columns.Add(columnName, columnName)
            End If
        Next

        Dim batchSize As Integer = 3 ' Tamaño del lote para procesar en paralelo
        Dim tasks As New List(Of Task)()

        For i As Integer = 0 To DataGridView1.Rows.Count - 1 Step batchSize
            Dim batchRows As List(Of DataGridViewRow) = DataGridView1.Rows.Cast(Of DataGridViewRow)().Skip(i).Take(batchSize).ToList()

            ' Procesar el lote de forma asíncrona y agregarlo a la lista de tareas
            Dim task As Task = ProcessBatchAsync(batchRows)
            tasks.Add(task)
        Next

        ' Esperar a que se completen todas las tareas en paralelo
        Await Task.WhenAll(tasks)



        MessageBox.Show("Procesamiento completado.")



    End Sub

    Private Async Function ProcessBatchAsync(rows As List(Of DataGridViewRow)) As Task
        For Each row As DataGridViewRow In rows
            Try
                ' Check if the CatalogProductId cell is not empty
                If Not row.Cells("CatalogProductId").Value Is Nothing Then
                    ' Get the CatalogProductId from the DataGridView
                    Dim catalogProductId As String = row.Cells("CatalogProductId").Value.ToString()

                    ' Build the API URL with the CatalogProductId
                    Dim apiURL As String = $"https://api.mercadolibre.com/products/{catalogProductId}"

                    Dim request As WebRequest = WebRequest.Create(apiURL)
                    request.Headers.Add("Authorization", "Bearer " & token)

                    Dim response As WebResponse = Await request.GetResponseAsync()

                    Using stream As Stream = response.GetResponseStream()
                        Using reader As New StreamReader(stream)
                            Dim jsonResponse As String = Await reader.ReadToEndAsync()
                            Dim fechaActual As Date = Date.Today
                            ' Parse JSON Response
                            Dim productData As JObject = JObject.Parse(jsonResponse)

                            ' Add data to the corresponding cells in the current row
                            row.Cells("name").Value = productData("name")
                            row.Cells("permalink").Value = productData("permalink")
                            row.Cells("price").Value = productData("buy_box_winner")("price")
                            row.Cells("listing_type_id").Value = productData("buy_box_winner")("listing_type_id")
                            row.Cells("seller_id").Value = productData("buy_box_winner")("seller_id")
                            row.Cells("seller_id").Value = productData("buy_box_winner")("seller_id")
                            ' Add "sold_quantity" to the corresponding cell in the current row
                            row.Cells("sold_quantity").Value = productData("sold_quantity")
                            ' Get "date_created" and assign its value to the corresponding cell in the current row
                            Dim dateCreated As String = productData("date_created").ToString().Split("T"c)(0)
                            row.Cells("date_created").Value = dateCreated

                            ' Perform additional operations using "sold_quantity" and "date_created"
                            Dim fechaCreacion As Date = Date.Parse(dateCreated)
                            Dim mesesDesdeCreacion As Integer = (fechaActual.Year - fechaCreacion.Year) * 12 + fechaActual.Month - fechaCreacion.Month
                            row.Cells("Meses desde la Creación").Value = mesesDesdeCreacion

                            Dim unidadesVendidas As Integer = Convert.ToInt32(productData("sold_quantity"))
                            Dim unidadesVendidasPorMes As Integer = unidadesVendidas / mesesDesdeCreacion
                            row.Cells("Unidades Vendidas por Mes").Value = unidadesVendidasPorMes * 0.5

                            ' Access the "shipping" object within "buy_box_winner"
                            Dim shippingObject As JObject = productData("buy_box_winner")("shipping")

                            ' Check if "mode" exists within "shipping"
                            If shippingObject IsNot Nothing AndAlso shippingObject("mode") IsNot Nothing Then
                                ' If "mode" exists, assign its value to the corresponding cell in the current row
                                row.Cells("mode").Value = shippingObject("mode").ToString()
                            Else
                                ' If "mode" doesn't exist, you can assign a default value or handle it as needed
                                row.Cells("mode").Value = "N/A"
                            End If


                            ' Buscar los valores dentro del arreglo "attributes"
                            Dim attributes As JArray = productData("attributes")

                            ' Variables para almacenar los valores de Marca, Línea y Modelo
                            Dim marca As String = ""
                            Dim linea As String = ""
                            Dim modelo As String = ""

                            ' Iterar a través de los elementos en el arreglo "attributes"
                            For Each attribute As JObject In attributes
                                Dim attributeName As String = attribute("name").ToString()
                                Select Case attributeName
                                    Case "Marca"
                                        marca = attribute("values")(0)("name").ToString()
                                    Case "Línea"
                                        linea = attribute("values")(0)("name").ToString()
                                    Case "Modelo"
                                        modelo = attribute("values")(0)("name").ToString()
                                End Select
                            Next

                            ' Asignar los valores de "Marca", "Línea" y "Modelo" a las celdas correspondientes en la fila actual
                            row.Cells("marca").Value = marca
                            row.Cells("linea").Value = linea
                            row.Cells("modelo").Value = modelo

                        End Using
                    End Using
                End If
            Catch ex As Exception
                ' Ignorar errores y continuar con la siguiente fila
                Debug.WriteLine("Error processing row: " & ex.Message)
            End Try
        Next
    End Function




    ' Esta función procesará una fila individual
    Private Async Function WithEventsAsync(row As DataGridViewRow) As Task
        Using httpClient As New HttpClient()
            Try
                Dim columna1Valor As String = row.Cells("id").Value.ToString()
                Dim url As String = "https://api.mercadolibre.com/items?ids=" & columna1Valor
                Dim response As HttpResponseMessage = Await httpClient.GetAsync(url)

                If response.IsSuccessStatusCode Then
                    Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                    Dim jsonArray As JArray = JArray.Parse(responseBody)

                    If jsonArray.Count > 0 Then
                        Dim variationsArray As JArray = jsonArray(0).SelectToken("body.variations")
                        If variationsArray IsNot Nothing AndAlso variationsArray.Count > 0 Then
                            Dim catalogProductId As String = variationsArray(0).SelectToken("catalog_product_id").ToString()
                            row.Cells("CatalogProductId").Value = catalogProductId
                        Else
                            Dim catalogProductId As String = jsonArray(0).SelectToken("body.catalog_product_id").ToString()
                            row.Cells("CatalogProductId").Value = catalogProductId
                        End If
                    Else
                        row.Cells("CatalogProductId").Value = "No se encontraron datos"
                    End If
                Else
                    row.Cells("CatalogProductId").Value = "Error al consultar la API"
                End If
            Catch ex As Exception
                ' Omitido el manejo de excepciones para simplificar
            End Try
        End Using
    End Function

    ' Esta función procesará una fila individual
    Private Async Function ProcessRowAsync(row As DataGridViewRow) As Task
        Await Semaphore.WaitAsync()
        Try
            Dim columna1Valor As String = row.Cells("id").Value.ToString()
            Dim url As String = "https://api.mercadolibre.com/items/" & columna1Valor
            Dim response As HttpResponseMessage = Await HttpClient.GetAsync(url)
            If response.IsSuccessStatusCode Then
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                Dim jsonObject As JObject = JObject.Parse(responseBody)

                ' Intenta obtener el catalog_product_id directamente desde el objeto JSON.
                Dim catalogProductId As String = jsonObject.SelectToken("catalog_product_id")?.ToString()

                If Not String.IsNullOrWhiteSpace(catalogProductId) Then
                    row.Cells("CatalogProductId").Value = catalogProductId
                Else
                    ' Si no se encuentra catalog_product_id, intenta buscar en las variaciones.
                    Dim variationsArray As JArray = jsonObject.SelectToken("variations")
                    If variationsArray IsNot Nothing AndAlso variationsArray.Count > 0 Then
                        catalogProductId = variationsArray(0).SelectToken("catalog_product_id")?.ToString()
                        If Not String.IsNullOrWhiteSpace(catalogProductId) Then
                            row.Cells("CatalogProductId").Value = catalogProductId
                        Else
                            row.Cells("CatalogProductId").Value = "No disponible"
                        End If
                    Else
                        row.Cells("CatalogProductId").Value = "No disponible"
                    End If
                End If
            Else
                row.Cells("CatalogProductId").Value = "Error al consultar la API"
            End If

        Catch ex As Exception
            ' Aquí deberías manejar las excepciones de forma adecuada.
            ' Por ejemplo, podrías mostrar un mensaje al usuario o escribir en un log.
        Finally
            Semaphore.Release()
        End Try
    End Function

    Public Async Sub catalogoiditem()
        Dim tasks As New List(Of Task)()

        For Each row As DataGridViewRow In DataGridView1.Rows
            tasks.Add(ProcessRowAsync(row))
        Next

        Await Task.WhenAll(tasks)
    End Sub
















    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Verificar si el valor en txtPorcentaje se puede convertir a Double
        Dim porcentaje As Double
        If Double.TryParse(txtPorcentaje.Text, porcentaje) Then
            ' Actualizar la columna "porcentaje" en cada fila del DataGridView
            For Each row As DataGridViewRow In DataGridView1.Rows
                ' Verificar si la fila no es nula
                If row IsNot Nothing Then
                    ' Mantener el contenido de la columna "CATALOGPRODUCTID" sin cambios
                    Dim catalogProductIdCell As DataGridViewCell = row.Cells("CATALOGPRODUCTID")
                    Dim catalogProductId As Object = catalogProductIdCell.Value

                    ' Declarar la variable columna1
                    Dim columna1 As Double = 0.0

                    ' Verificar si la celda "PriceToWin" no es nula ni vacía
                    Dim priceToWinCell As DataGridViewCell = row.Cells("PriceToWin")
                    Dim priceToWinValue As Object = If(priceToWinCell IsNot Nothing AndAlso priceToWinCell.Value IsNot Nothing, priceToWinCell.Value.ToString(), "")

                    ' Verificar si la celda "price" no es nula ni vacía
                    Dim priceCell As DataGridViewCell = row.Cells("price")
                    Dim priceValue As Object = If(priceCell IsNot Nothing AndAlso priceCell.Value IsNot Nothing, priceCell.Value.ToString(), "")

                    If Not String.IsNullOrEmpty(priceToWinValue.ToString()) Then
                        ' Verificar si el valor en la celda "PriceToWin" se puede convertir a Double
                        If Double.TryParse(priceToWinValue.ToString(), columna1) Then
                            ' Si "PriceToWin" es mayor que 0, actualizar el valor de la columna "porcentaje"
                            If columna1 > 0 Then
                                row.Cells("porcentaje").Value = porcentaje.ToString()
                            End If
                        End If
                    ElseIf Not String.IsNullOrEmpty(priceValue.ToString()) Then
                        ' Si la celda "PriceToWin" está vacía, usar la columna "price" para el cálculo
                        If Double.TryParse(priceValue.ToString() * 0.95, columna1) Then

                            row.Cells("porcentaje").Value = porcentaje.ToString()
                        End If
                    End If

                    ' Realizar cálculos basados en el nuevo valor de "porcentaje"
                    Dim costoObjetivo As Double = (columna1 * ((100 - porcentaje) / 100)) / 1.21
                    row.Cells("Costo_Objetivo_pricetowin").Value = costoObjetivo.ToString("F2")

                    ' Restaurar el contenido original de "CATALOGPRODUCTID"
                    catalogProductIdCell.Value = catalogProductId

                    For Each row2 As DataGridViewRow In DataGridView1.Rows
                        Dim unidadesVendidas As Integer = CInt(row2.Cells("Unidades Vendidas por Mes").Value)
                        Dim costo_objetivo As Integer = CInt(row2.Cells("Costo_Objetivo_pricetowin").Value)
                        Dim porcentaje2 As Decimal = CDec(row2.Cells("porcentaje").Value)


                        Dim resultado As Decimal = unidadesVendidas * (costo_objetivo / ((100 - porcentaje2) / 100))

                        ' Asegúrate de que la columna "Resultado" exista en tu DataGridView.
                        If DataGridView1.Columns.Contains("venta estimada") Then
                            row2.Cells("venta estimada").Value = resultado
                        Else
                            ' Si la columna "Resultado" no existe, puedes agregarla aquí o manejarla de otra manera.
                        End If

                    Next


                End If
            Next
        Else
            MessageBox.Show("Porcentaje no válido. Ingrese un número válido.")
        End If

        Dim columnaVentaEstimada As DataGridViewColumn = DataGridView1.Columns("venta estimada")

        ' Ordenar el DataGridView de mayor a menor por la columna "venta estimada"
        DataGridView1.Sort(columnaVentaEstimada, System.ComponentModel.ListSortDirection.Descending)

        DataGridView1.Columns("venta estimada").DefaultCellStyle.Format = "N0"



        EliminarFilasVaciasListingTypeId()


    End Sub



    Async Sub pricetowin()
        Dim priceToWinColumnIndex As Integer = GetOrCreateColumnIndex("PriceToWin")
        Dim catalogProductIdColumnIndex As Integer = GetOrCreateColumnIndex("CatalogProductId")

        Dim rows As List(Of DataGridViewRow) = DataGridView1.Rows.Cast(Of DataGridViewRow)().ToList()
        Dim tasks As List(Of Task) = New List(Of Task)

        For i = 0 To rows.Count - 1 Step 50
            Dim chunk As List(Of DataGridViewRow) = rows.Skip(i).Take(50).ToList()
            Dim task As Task = ProcessChunk(chunk, priceToWinColumnIndex, catalogProductIdColumnIndex)
            tasks.Add(task)
        Next

        Await Task.WhenAll(tasks)

    End Sub

    'Private WithEvents DataGridView1 As DataGridView


    Private Function GetOrCreateColumnIndex(columnName As String) As Integer
        For Each column As DataGridViewColumn In DataGridView1.Columns
            If column.Name = columnName Then
                Return column.Index
            End If
        Next

        Return DataGridView1.Columns.Add(columnName, columnName)
    End Function

    Private Async Function ProcessChunk(chunk As List(Of DataGridViewRow), priceToWinColumnIndex As Integer, catalogProductIdColumnIndex As Integer) As Task
        Dim tasks As List(Of Task) = chunk.Select(Function(row) ProcessRow(row, priceToWinColumnIndex, catalogProductIdColumnIndex)).ToList()
        Await Task.WhenAll(tasks)
    End Function

    Private Async Function ProcessRow(row As DataGridViewRow, priceToWinColumnIndex As Integer, catalogProductIdColumnIndex As Integer) As Task
        Dim itemID As String = row.Cells("porcentaje").Value.ToString()
        Dim url As String = $"https://api.mercadolibre.com/items/{itemID}/price_to_win?version=v2"

        Using httpClient As New HttpClient()
            httpClient.Timeout = TimeSpan.FromMinutes(15)
            httpClient.DefaultRequestHeaders.Add("Authorization", token)

            Dim response As HttpResponseMessage = Await httpClient.GetAsync(url)

            If response.IsSuccessStatusCode Then
                Dim json As String = Await response.Content.ReadAsStringAsync()
                Dim data As JObject = JsonConvert.DeserializeObject(Of JObject)(json)

                ' Verifica si "PriceToWin" es nulo antes de asignar el valor a la celda.
                If data("price_to_win")?.Type <> JTokenType.Null Then
                    Dim priceToWin As Double = data("price_to_win").ToObject(Of Double)()
                    row.Cells(priceToWinColumnIndex).Value = priceToWin.ToString()
                Else
                    ' Si "PriceToWin" es nulo, deja la celda en blanco.
                    row.Cells(priceToWinColumnIndex).Value = String.Empty
                End If

                Dim catalogProductId As String = If(data("catalog_product_id")?.Type <> JTokenType.Null, data("catalog_product_id").ToString(), "N/A")
                row.Cells(catalogProductIdColumnIndex).Value = catalogProductId
            Else
                ' Manejo de errores aquí si la solicitud no tiene éxito.
            End If
        End Using
    End Function


    Private Sub btnPasteFromClipboard_Click_1(sender As Object, e As EventArgs) Handles btnPasteFromClipboard.Click
        ' Verificar si hay texto en el portapapeles
        If Clipboard.ContainsText() Then
            Dim idsFromClipboard As String() = Clipboard.GetText().Split(New Char() {vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

            ' Asegurarte de que la columna "id" exista en el DataGridView
            If Not DataGridView1.Columns.Contains("id") Then
                Dim idColumn As New DataGridViewTextBoxColumn()
                idColumn.Name = "id"
                idColumn.HeaderText = "ID"
                DataGridView1.Columns.Add(idColumn)
            End If

            ' Limpiar las filas existentes
            DataGridView1.Rows.Clear()

            ' Agregar los ID al DataGridView en la columna "id"
            For Each id As String In idsFromClipboard
                Dim rowIndex As Integer = DataGridView1.Rows.Add()
                DataGridView1.Rows(rowIndex).Cells("id").Value = id
            Next
        Else
            MessageBox.Show("No hay texto en el portapapeles.")
        End If
    End Sub

End Class
