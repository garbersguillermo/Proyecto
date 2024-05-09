Imports System.Globalization
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports RestSharp
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Net.WebRequestMethods
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Web
Imports System.Collections.Specialized

Public Class Posiciones_catalogo
    Public token As String
    Private Shared ReadOnly HttpClient As New HttpClient()
    Private Shared ReadOnly MaxDegreeOfParallelism As Integer = 20 ' Ajusta este número según sea apropiado para tu situación.
    Private Shared ReadOnly Semaphore As New SemaphoreSlim(MaxDegreeOfParallelism)
    Private WithEvents ButtonEjecutar As Button

    Public Class ProductItem
        Public Property item_id As String
        Public Property seller_id As Integer
        Public Property price As Decimal

        Public Property listing_type_id As String
        ' Agrega aquí otras propiedades según sean necesarias
    End Class

    Public Class ApiResponse
        Public Property results As List(Of ProductItem)
    End Class

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
        End While

        Return resultados
    End Function



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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



    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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
                        If Double.TryParse(priceValue.ToString(), columna1) Then
                            row.Cells("porcentaje").Value = porcentaje.ToString()
                        End If
                    End If

                    ' Realizar cálculos basados en el nuevo valor de "porcentaje"
                    Dim costoObjetivo As Double = (columna1 * ((100 - porcentaje) / 100)) / 1.21
                    row.Cells("Costo_Objetivo_pricetowin").Value = costoObjetivo.ToString("F2")

                    ' Restaurar el contenido original de "CATALOGPRODUCTID"
                    catalogProductIdCell.Value = catalogProductId

                    For Each row2 As DataGridViewRow In DataGridView1.Rows
                        ' Asegúrate de que la fila no es la fila de nuevo ingreso en un DataGridView con permitir usuarios agregar filas
                        If Not row2.IsNewRow Then
                            ' Inicializar las variables
                            Dim unidadesVendidas As Decimal = 0
                            Dim costo_objetivo As Decimal = 0
                            Dim porcentaje2 As Decimal = 0

                            ' Verificar y convertir "Unidades Vendidas por Mes" a Decimal
                            If row2.Cells("Unidades Vendidas por Mes").Value IsNot Nothing AndAlso Not IsDBNull(row2.Cells("Unidades Vendidas por Mes").Value) Then
                                unidadesVendidas = CDec(row2.Cells("Unidades Vendidas por Mes").Value)
                            End If

                            ' Verificar y convertir "Costo_Objetivo_pricetowin" a Decimal
                            If row2.Cells("Costo_Objetivo_pricetowin").Value IsNot Nothing AndAlso Not IsDBNull(row2.Cells("Costo_Objetivo_pricetowin").Value) Then
                                costo_objetivo = CDec(row2.Cells("Costo_Objetivo_pricetowin").Value)
                            End If

                            ' Verificar y convertir "porcentaje" a Decimal
                            If row2.Cells("porcentaje").Value IsNot Nothing AndAlso Not IsDBNull(row2.Cells("porcentaje").Value) Then
                                porcentaje2 = CDec(row2.Cells("porcentaje").Value)
                            End If

                            ' Realizar el cálculo
                            Dim resultado As Decimal = 0
                            If unidadesVendidas > 0 AndAlso costo_objetivo > 0 AndAlso porcentaje2 >= 0 Then
                                resultado = unidadesVendidas * (costo_objetivo / ((100 - porcentaje2) / 100))
                            End If

                            ' Formatear y asignar el valor a la celda "venta estimada"
                            If DataGridView1.Columns.Contains("venta estimada") Then
                                row2.Cells("venta estimada").Value = FormatearConPuntos(resultado, False)
                            End If
                        End If
                    Next

                    ' Obtener el valor de la columna "seller_id"
                    Dim sellerIdCell As DataGridViewCell = row.Cells("seller_id")
                    Dim sellerId As Object = If(sellerIdCell IsNot Nothing AndAlso sellerIdCell.Value IsNot Nothing, sellerIdCell.Value.ToString(), "")

                    ' Comparar el seller_id y actualizar la columna "Ganando?"
                    If sellerId.ToString() = "183426174" Then
                        row.Cells("Ganando?").Value = "Ganando"
                    Else
                        row.Cells("Ganando?").Value = "NO"
                    End If

                End If
            Next
        Else
            MessageBox.Show("Porcentaje no válido. Ingrese un número válido.")
        End If

        Dim columnaVentaEstimada As DataGridViewColumn = DataGridView1.Columns("venta estimada")

        ' Ordenar el DataGridView de mayor a menor por la columna "venta estimada"
        'DataGridView1.Sort(columnaVentaEstimada, System.ComponentModel.ListSortDirection.Descending)

        ' Diccionarios para almacenar las ventas por periodo para cada catalogProductId
        Dim salesLast7Days As New Dictionary(Of String, Integer)
        Dim salesLast14Days As New Dictionary(Of String, Integer)
        Dim salesLast30Days As New Dictionary(Of String, Integer)

        Dim currentDate As DateTime = DateTime.Now

        ' Recorrer todas las filas de DataGridView2 para sumar las ventas en los periodos
        For Each row As DataGridViewRow In DataGridView2.Rows
            If Not row.IsNewRow AndAlso row.Cells("Datecreated").Value IsNot Nothing AndAlso row.Cells("catalogProductId").Value IsNot Nothing Then
                Dim dateCreated As DateTime = DateTime.Parse(row.Cells("Datecreated").Value.ToString())
                Dim catalogProductId As String = row.Cells("catalogProductId").Value.ToString()
                Dim quantity As Integer = Convert.ToInt32(row.Cells("quantity").Value)

                ' Calcular la diferencia en días
                Dim daysDifference As Integer = (currentDate - dateCreated).Days

                ' Acumular la cantidad para cada catalogProductId y periodo
                If daysDifference <= 30 Then
                    If salesLast30Days.ContainsKey(catalogProductId) Then
                        salesLast30Days(catalogProductId) += quantity
                    Else
                        salesLast30Days.Add(catalogProductId, quantity)
                    End If

                    If daysDifference <= 14 Then
                        If salesLast14Days.ContainsKey(catalogProductId) Then
                            salesLast14Days(catalogProductId) += quantity
                        Else
                            salesLast14Days.Add(catalogProductId, quantity)
                        End If

                        If daysDifference <= 7 Then
                            If salesLast7Days.ContainsKey(catalogProductId) Then
                                salesLast7Days(catalogProductId) += quantity
                            Else
                                salesLast7Days.Add(catalogProductId, quantity)
                            End If
                        End If
                    End If
                End If
            End If
        Next

        ' Recorrer DataGridView1 y actualizar las columnas de ventas
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow AndAlso row.Cells("catalogProductId").Value IsNot Nothing Then
                Dim catalogProductId As String = row.Cells("catalogProductId").Value.ToString()

                row.Cells("7 días").Value = If(salesLast7Days.ContainsKey(catalogProductId), salesLast7Days(catalogProductId), 0)
                row.Cells("14 días").Value = If(salesLast14Days.ContainsKey(catalogProductId), salesLast14Days(catalogProductId), 0)
                row.Cells("30 días").Value = If(salesLast30Days.ContainsKey(catalogProductId), salesLast30Days(catalogProductId), 0)
            End If
        Next
    End Sub

    Private Async Function ProcessBatchAsync(rows As List(Of DataGridViewRow)) As Task
        For Each row As DataGridViewRow In rows
            Try
                ' Registro inicial para cada fila
                Debug.WriteLine("Inicio del procesamiento de la fila: " & row.Index)

                ' Verificar si la celda "CatalogProductId" no está vacía
                If Not row.Cells("CatalogProductId").Value Is Nothing Then
                    ' Obtener el CatalogProductId de DataGridView
                    Dim catalogProductId As String = row.Cells("CatalogProductId").Value.ToString()

                    ' Construir la URL de la API con el CatalogProductId
                    Dim apiURL As String = $"https://api.mercadolibre.com/products/{catalogProductId}"

                    Dim request As WebRequest = WebRequest.Create(apiURL)
                    request.Headers.Add("Authorization", "Bearer " & token)

                    Dim response As WebResponse = Await request.GetResponseAsync()

                    Using stream As Stream = response.GetResponseStream()
                        Using reader As New StreamReader(stream)
                            Dim jsonResponse As String = Await reader.ReadToEndAsync()
                            Dim fechaActual As Date = Date.Today
                            ' Analizar la respuesta JSON
                            Dim productData As JObject = JObject.Parse(jsonResponse)

                            ' Añadir datos a las celdas correspondientes en la fila actual
                            row.Cells("name").Value = productData("name")
                            row.Cells("permalink").Value = productData("permalink")
                            row.Cells("price").Value = productData("buy_box_winner")("price")
                            row.Cells("listing_type_id").Value = productData("buy_box_winner")("listing_type_id")
                            row.Cells("seller_id").Value = productData("buy_box_winner")("seller_id")
                            row.Cells("sold_quantity").Value = productData("sold_quantity")
                            Dim dateCreated As String = productData("date_created").ToString().Split("T"c)(0)
                            row.Cells("date_created").Value = dateCreated

                            Dim fechaCreacion As Date = Date.Parse(dateCreated)
                            Dim mesesDesdeCreacion As Integer = (fechaActual.Year - fechaCreacion.Year) * 12 + fechaActual.Month - fechaCreacion.Month
                            row.Cells("Meses").Value = mesesDesdeCreacion

                            ' Extraer el valor de "PriceToWin" de la respuesta de la API
                            Dim priceToWin As Object = productData("buy_box_winner")("price_to_win")
                            If priceToWin IsNot Nothing Then
                                ' Asignar el valor a la columna "PriceToWin" en la fila actual
                                row.Cells("PriceToWin").Value = priceToWin.ToString()
                            Else
                                ' Manejar el caso donde "price_to_win" no está disponible o es nulo
                                row.Cells("PriceToWin").Value = "" ' o cualquier otro valor predeterminado
                            End If

                            Dim unidadesVendidas As Integer = Convert.ToInt32(productData("sold_quantity"))
                            Dim unidadesVendidasPorMes As Integer = unidadesVendidas / mesesDesdeCreacion
                            row.Cells("Unidades Vendidas por Mes").Value = unidadesVendidasPorMes * 0.125

                            row.Cells("seller_id").Value = productData("buy_box_winner")("seller_id")


                            If productData("buy_box_winner")("shipping") IsNot Nothing AndAlso productData("buy_box_winner")("shipping")("mode") IsNot Nothing Then
                                row.Cells("mode").Value = productData("buy_box_winner")("shipping")("mode").ToString()
                            Else
                                row.Cells("mode").Value = "N/A"
                            End If

                            Dim attributes As JArray = productData("attributes")
                            Dim marca As String = ""
                            Dim linea As String = ""
                            Dim modelo As String = ""

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

                            row.Cells("marca").Value = marca
                            row.Cells("linea").Value = linea
                            row.Cells("modelo").Value = modelo


                            ' Obtener el item_id de la columna "id"
                            Dim itemId As String = row.Cells("id").Value.ToString()

                            ' Construir la URL de la API para obtener el PriceToWin
                            Dim priceToWinApiUrl As String = $"https://api.mercadolibre.com/items/{itemId}/price_to_win?siteId=MLA&version=v2"
                            Dim priceToWinRequest As WebRequest = WebRequest.Create(priceToWinApiUrl)
                            priceToWinRequest.Headers.Add("Authorization", "Bearer " & token)

                            ' Realizar la solicitud a la API
                            Dim priceToWinResponse As WebResponse = Await priceToWinRequest.GetResponseAsync()

                            Using stream2 As Stream = priceToWinResponse.GetResponseStream()
                                Using reader2 As New StreamReader(stream2)
                                    Dim jsonResponse2 As String = Await reader2.ReadToEndAsync()

                                    ' Analizar la respuesta JSON
                                    Dim priceToWinData As JObject = JObject.Parse(jsonResponse2)

                                    ' Extraer y asignar el valor de PriceToWin
                                    Dim priceToWinValue As Object = priceToWinData("price_to_win")
                                    If priceToWinValue IsNot Nothing Then
                                        row.Cells("PriceToWin").Value = priceToWinValue.ToString()
                                    Else
                                        row.Cells("PriceToWin").Value = "N/A"
                                    End If
                                End Using
                            End Using

                            ' Registro después de procesar cada fila
                            Debug.WriteLine("Fila procesada exitosamente: " & row.Index)


                        End Using
                    End Using

                    ' Obtener el ID del artículo (reemplazar "id" con el nombre correcto de la columna si es diferente)
                    Dim itemId2 As String = row.Cells("id").Value.ToString()

                    ' Construir la URL de la API para el artículo
                    Dim itemApiUrl As String = $"https://api.mercadolibre.com/items/{itemId2}"

                    ' Realizar la solicitud a la API
                    Dim itemRequest As WebRequest = WebRequest.Create(itemApiUrl)
                    itemRequest.Headers.Add("Authorization", "Bearer " & token)

                    Dim itemResponse As WebResponse = Await itemRequest.GetResponseAsync()

                    Using itemStream As Stream = itemResponse.GetResponseStream()
                        Using itemReader As New StreamReader(itemStream)
                            Dim jsonResponse As String = Await itemReader.ReadToEndAsync()

                            ' Analizar la respuesta JSON del artículo
                            Dim itemData As JObject = JObject.Parse(jsonResponse)

                            ' Extraer y asignar el valor de "logistic_type"
                            If itemData("shipping") IsNot Nothing AndAlso itemData("shipping")("logistic_type") IsNot Nothing Then
                                row.Cells("logistic_type").Value = itemData("shipping")("logistic_type").ToString()
                            Else
                                row.Cells("logistic_type").Value = "N/A"
                            End If
                        End Using
                    End Using
                End If
            Catch ex As Exception
                ' Registro de errores
                Debug.WriteLine("Error al procesar la fila " & row.Index & ": " & ex.Message)
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
            Dim url As String = "https://api.mercadolibre.com/items?ids=" & columna1Valor

            ' Configurar la solicitud con el token de acceso
            Dim request As New HttpRequestMessage(HttpMethod.Get, url)
            request.Headers.Authorization = New AuthenticationHeaderValue("Bearer", token)

            Dim response As HttpResponseMessage = Await HttpClient.SendAsync(request)

            If response.IsSuccessStatusCode Then
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                Dim jsonArray As JArray = JArray.Parse(responseBody)

                If jsonArray.Count > 0 Then
                    ' Obtener y asignar el Catalog Product ID
                    Dim catalogProductId As String = jsonArray(0).SelectToken("body.catalog_product_id").ToString()
                    row.Cells("CatalogProductId").Value = catalogProductId

                    ' Obtener el estado del ítem y la cantidad disponible
                    Dim itemStatus As String = jsonArray(0).SelectToken("body.status").ToString()
                    Dim availableQuantity As String = jsonArray(0).SelectToken("body.available_quantity").ToString()

                    ' Asignar valor basado en el estado del ítem
                    If itemStatus.ToLower() = "active" Then
                        row.Cells("ItemStatus").Value = availableQuantity
                    ElseIf itemStatus.ToLower() = "paused" Then
                        row.Cells("ItemStatus").Value = "sin stock"
                    Else
                        row.Cells("ItemStatus").Value = "Estado desconocido"
                    End If
                Else
                    row.Cells("CatalogProductId").Value = "No se encontraron datos"
                    row.Cells("ItemStatus").Value = "No disponible"
                End If
            Else
                row.Cells("CatalogProductId").Value = "Error al consultar la API"
                row.Cells("ItemStatus").Value = "Error API"
            End If
        Catch ex As Exception
            ' Manejo de excepciones
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

    Private Function FormatearConPuntos(value As Decimal, incluirDecimales As Boolean) As String
        Dim nfi As New Globalization.NumberFormatInfo()
        nfi.NumberGroupSeparator = "."
        nfi.NumberDecimalSeparator = ","
        If incluirDecimales Then
            Return value.ToString("N2", nfi) ' Formato con dos decimales
        Else
            Return value.ToString("N0", nfi) ' Formato sin decimales
        End If
    End Function

    Private Sub btnPasteFromClipboard_Click_1(sender As Object, e As EventArgs) Handles btnPasteFromClipboard.Click
        ' Verificar si hay texto en el portapapeles
        If Clipboard.ContainsText() Then
            ' Dividir el texto del portapapeles en filas
            Dim rowsFromClipboard As String() = Clipboard.GetText().Split(New Char() {vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

            ' Crear las columnas "recurso" e "id" si no existen
            If Not DataGridView1.Columns.Contains("recurso") Then
                DataGridView1.Columns.Add("recurso", "Recurso")
            End If
            If Not DataGridView1.Columns.Contains("id") Then
                DataGridView1.Columns.Add("id", "id")
            End If

            ' Limpiar las filas existentes
            DataGridView1.Rows.Clear()

            ' Agregar las filas al DataGridView
            For Each row As String In rowsFromClipboard
                ' Usar tabulación como delimitador para dividir las columnas
                Dim columns As String() = row.Split(New Char() {vbTab})

                ' Asegurarse de que cada fila tenga 2 columnas
                If columns.Length = 2 Then
                    Dim rowIndex As Integer = DataGridView1.Rows.Add()
                    DataGridView1.Rows(rowIndex).Cells("recurso").Value = columns(0).Trim()
                    DataGridView1.Rows(rowIndex).Cells("id").Value = columns(1).Trim()
                End If
            Next
        Else
            MessageBox.Show("No hay texto en el portapapeles.")
        End If


        catalogoiditem()
        Dim columnsToCreate As String() = {"ItemStatus", "Costo_Objetivo_pricetowin", "Unidades Vendidas por Mes", "venta estimada", "PriceToWin", "marca", "linea", "modelo", "porcentaje", "name", "permalink", "price", "listing_type_id", "seller_id", "sold_quantity", "date_created", "Meses", "mode", "Ganando?", "logistic_type", "7 días", "14 días", "30 días"}

        For Each columnName As String In columnsToCreate
            If DataGridView1.Columns(columnName) Is Nothing Then
                DataGridView1.Columns.Add(columnName, columnName)
            End If
        Next


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Verificar si hay texto en el portapapeles
        If Clipboard.ContainsText() Then
            ' Dividir el texto del portapapeles en filas
            Dim rowsFromClipboard As String() = Clipboard.GetText().Split(New Char() {vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

            ' Crear las columnas "recurso" e "id" si no existen
            If Not DataGridView1.Columns.Contains("recurso") Then
                DataGridView1.Columns.Add("recurso", "Recurso")
            End If
            If Not DataGridView1.Columns.Contains("id") Then
                DataGridView1.Columns.Add("id", "ID")
            End If

            ' Limpiar las filas existentes
            DataGridView1.Rows.Clear()

            ' Agregar las filas al DataGridView
            For Each row As String In rowsFromClipboard
                ' Usar tabulación como delimitador para dividir las columnas
                Dim columns As String() = row.Split(New Char() {vbTab})

                ' Asegurarse de que cada fila tenga 2 columnas
                If columns.Length = 1 Then
                    Dim rowIndex As Integer = DataGridView1.Rows.Add()
                    DataGridView1.Rows(rowIndex).Cells("CatalogProductId").Value = columns(0).Trim()
                End If
            Next
        Else
            MessageBox.Show("No hay texto en el portapapeles.")
        End If

        Dim columnsToCreate As String() = {"ItemStatus", "Costo_Objetivo_pricetowin", "Unidades Vendidas por Mes", "venta estimada", "PriceToWin", "marca", "linea", "modelo", "porcentaje", "name", "permalink", "price", "listing_type_id", "seller_id", "sold_quantity", "date_created", "Meses", "mode", "Ganando?", "logistic_type", "7 días", "14 días", "30 días"}

        For Each columnName As String In columnsToCreate
            If DataGridView1.Columns(columnName) Is Nothing Then
                DataGridView1.Columns.Add(columnName, columnName)
            End If
        Next

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CargarCompetidoresEnDataGridView()
    End Sub



    ' Añadir columnas si no existen
























    Private Async Sub CargarCompetidoresEnDataGridView()
        Dim catalogProductId As String = TextBox2.Text.Trim()

        If String.IsNullOrWhiteSpace(catalogProductId) Then
            MessageBox.Show("Por favor, ingrese un PRODUCT_ID.")
            Return
        End If

        Try
            Dim apiUrl As String = $"https://api.mercadolibre.com/products/{catalogProductId}/items"
            Dim request As New HttpRequestMessage(HttpMethod.Get, apiUrl)
            request.Headers.Authorization = New AuthenticationHeaderValue("Bearer", token)

            Dim response As HttpResponseMessage = Await HttpClient.SendAsync(request)

            If response.IsSuccessStatusCode Then
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                Dim apiResponse As ApiResponse = JsonConvert.DeserializeObject(Of ApiResponse)(responseBody)
                If apiResponse IsNot Nothing AndAlso apiResponse.results IsNot Nothing Then
                    DataGridView2.Rows.Clear()
                    ConfigurarColumnasDataGridView()

                    For Each item In apiResponse.results
                        DataGridView2.Rows.Add(item.item_id, item.price, item.seller_id, item.listing_type_id)
                    Next
                Else
                    MessageBox.Show("No se encontraron items o la respuesta no pudo ser deserializada.")
                End If
            Else
                MessageBox.Show($"Error al obtener datos de la API. Código de Estado: {response.StatusCode}")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al procesar la solicitud: " & ex.Message)
        End Try
    End Sub

    Private Sub ConfigurarColumnasDataGridView()
        If DataGridView2.Columns.Count = 0 Then
            DataGridView2.Columns.Add("item_id", "Item ID")
            DataGridView2.Columns.Add("price", "Price")
            DataGridView2.Columns.Add("seller_id", "Seller ID")
            DataGridView2.Columns.Add("listing_type_id", "Tipo")
        End If
    End Sub
    Private Sub SetUpDataGridView2()
        ' Clear existing columns
        DataGridView2.Columns.Clear()

        ' Add two columns: one for item ID and one for quantity
        DataGridView2.Columns.Add("Datecreated", "Datecreated")
        DataGridView2.Columns.Add("itemID", "Item ID")
        DataGridView2.Columns.Add("quantity", "Quantity")
        DataGridView2.Columns.Add("catalogProductId", "catalogProductId")
    End Sub
    Private Async Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SetUpDataGridView2()  ' Set up columns first
        Await FetchAndDisplayRecentOrders()
    End Sub


    Private Async Function FetchAndDisplayRecentOrders() As Task

        Dim fechaDesde As Date = Date.Today.AddDays(-30)
        Dim fechaHasta As Date = Date.Today

        ' Format the dates with time component
        Dim formattedFechaDesde As String = fechaDesde.ToString("yyyy-MM-ddT00:00:00.000-00:00", CultureInfo.InvariantCulture)
        Dim formattedFechaHasta As String = fechaHasta.ToString("yyyy-MM-ddT23:59:59.999-00:00", CultureInfo.InvariantCulture)

        Dim offset As Integer = 0
        Dim limit As Integer = 50 ' This might vary depending on the API's allowed maximum
        Dim totalResults As Integer = Integer.MaxValue ' Arbitrary large number to start the loop

        Do While offset < totalResults
            Dim url As String = $"https://api.mercadolibre.com/orders/search?seller=183426174&order.date_created.from={formattedFechaDesde}&order.date_created.to={formattedFechaHasta}&offset={offset}&limit={limit}"

            Using httpClient As New HttpClient()
                ' Replace "YOUR_AUTH_TOKEN" with your actual token
                httpClient.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token)

                Dim response As HttpResponseMessage = Await httpClient.GetAsync(url)
                If response.IsSuccessStatusCode Then
                    Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                    Dim jsonResponse As JObject = JObject.Parse(responseBody)

                    ' Update totalResults
                    totalResults = CInt(jsonResponse("paging")("total"))

                    Dim orders As JArray = jsonResponse("results")
                    For Each order As JObject In orders
                        ' Extraer la fecha de creación del pedido
                        Dim dateCreated As String = order("date_created").ToString()

                        Dim orderItems As JArray = order("order_items")

                        For Each orderItem As JObject In orderItems
                            Dim itemId As String = orderItem("item")("id").ToString()
                            Dim quantity As Integer = CInt(orderItem("quantity"))

                            ' Add row to DataGridView incluyendo la fecha de creación
                            DataGridView2.Invoke(Sub() DataGridView2.Rows.Add(New String() {dateCreated, itemId, quantity.ToString()}))
                        Next
                    Next
                Else
                    ' Handle error or unsuccessful status code
                    MessageBox.Show($"Error fetching order data: {response.StatusCode}")
                    Exit Do
                End If
            End Using

            offset += limit ' Increment offset for next iteration

        Loop


        Dim tasks As New List(Of Task)()

        ' Obtener el catalogProductId para cada itemId en paralelo
        For Each row As DataGridViewRow In DataGridView2.Rows
            If Not row.IsNewRow Then
                Dim itemId As String = row.Cells("ItemID").Value.ToString()
                tasks.Add(GetCatalogProductIdAsync(itemId, row))
            End If
        Next

        ' Esperar a que todas las tareas se completen
        Await Task.WhenAll(tasks)

    End Function

    Private Async Function GetCatalogProductIdAsync(itemId As String, row As DataGridViewRow) As Task
        Using httpClient As New HttpClient()
            Dim apiUrl As String = $"https://api.mercadolibre.com/items?ids={itemId}"

            Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

            If response.IsSuccessStatusCode Then
                Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()

                If jsonResponse.StartsWith("[") Then
                    Dim itemInfo As JObject = JArray.Parse(jsonResponse)(0)
                    Dim catalogProductId As String = itemInfo("body")("catalog_product_id").ToString()
                    DataGridView2.Invoke(Sub() row.Cells("catalogProductId").Value = catalogProductId)
                ElseIf jsonResponse.StartsWith("{") Then
                    Dim itemInfo As JObject = JObject.Parse(jsonResponse)
                    Dim catalogProductId As String = itemInfo("body")("catalog_product_id").ToString()
                    DataGridView2.Invoke(Sub() row.Cells("catalogProductId").Value = catalogProductId)
                Else
                    MessageBox.Show($"Respuesta JSON inesperada para el itemId {itemId}")
                End If
            Else
                MessageBox.Show($"Error al obtener información para el itemId {itemId}")
            End If
        End Using
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class

