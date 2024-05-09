Imports System.Net
Imports Newtonsoft.Json
Imports RestSharp
Imports System.IO
Imports System.Text
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json.Linq
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Public Class Descuentos
    Public token As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MLToken()

        customCulture = CType(CultureInfo.GetCultureInfo("es-AR").Clone(), CultureInfo)
        customCulture.NumberFormat.NumberGroupSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = customCulture
        System.Threading.Thread.CurrentThread.CurrentUICulture = customCulture

        Dim startDate As DateTime = DateTime.Now
        Dim finishDate As DateTime = startDate.AddDays(1).Date.AddHours(6)

        txt_fechainicio.Text = startDate.ToString("yyyy-MM-dd")
        txt_horainicio.Text = startDate.ToString("HH:mm:ss")
        txt_fechafin.Text = finishDate.ToString("yyyy-MM-dd")
        txt_horafin.Text = finishDate.ToString("HH:mm:ss")

    End Sub
    Private Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_Actualizar.Click
        Try
            Dim client As New RestClient("https://api.mercadolibre.com/")
            Dim discount As New Discount With {
            .discount_percent = txtDescuento.Text,
            .start_date = DateTime.ParseExact(txt_fechainicio.Text & " " & txt_horainicio.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyy-MM-ddTHH:mm:ss"),
            .finish_date = DateTime.ParseExact(txt_fechafin.Text & " " & txt_horafin.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyy-MM-ddTHH:mm:ss"),
            .promotion_type = "PRICE_DISCOUNT"
        }

            Dim jsonDiscount = JsonConvert.SerializeObject(discount)
            Dim countSuccess As Integer = 0

            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim id As String = row.Cells(0).Value

                If Not String.IsNullOrEmpty(id) Then
                    Dim request As New RestRequest("seller-promotions/items/" & id, Method.POST)
                    request.AddHeader("Authorization", "Bearer " & token)
                    request.AddHeader("Content-Type", "application/json")
                    request.AddParameter("application/json", jsonDiscount, ParameterType.RequestBody)

                    Dim response = client.Execute(request)

                    If response.StatusCode = HttpStatusCode.Created Then
                        countSuccess += 1
                    Else
                        MessageBox.Show($"Error al aplicar descuento al producto {id}. Estado: {response.StatusCode}")
                    End If
                End If
            Next

            If countSuccess = DataGridView1.Rows.Count Then
                MessageBox.Show("Descuentos aplicados")
            End If


            ' SQL SQL SQL SQL SQL SQL SQL SQL 

            ' Valida y convierte el texto del TextBox a Integer
            ' Valida y convierte el texto del TextBox a Integer
            Dim descuento As Integer
            If Integer.TryParse(txtDescuento.Text, descuento) Then

                ' Convierte el texto de "txt_fechafin" a DateTime y le agrega el tiempo 23:59:00
                Dim fechafin As DateTime
                If DateTime.TryParse(txt_fechafin.Text, fechafin) Then
                    fechafin = fechafin.Date.AddHours(23).AddMinutes(59).AddSeconds(0)

                    ' Verifica si el texto de "txt_palabrafiltro" comienza con "MLA"
                    Dim busqueda As String
                    If txt_palabrafiltro.Text.StartsWith("MLA") AndAlso DataGridView1.RowCount > 0 Then
                        ' Si es así, toma el valor de la segunda columna de la primera fila de DataGridView1
                        busqueda = DataGridView1.Rows(0).Cells("Column2").Value.ToString()
                    Else
                        ' Si no, toma el texto de "txt_palabrafiltro"
                        busqueda = txt_palabrafiltro.Text
                    End If


                Else
                    MessageBox.Show("Por favor, ingrese una fecha válida en el campo Fecha Fin.")
                End If

            Else
                MessageBox.Show("Por favor, ingrese un número válido en el campo Descuento.")
            End If

        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error: {ex.Message}")
        End Try
        ' FIN SQL SQL SQL SQL SQL SQL SQL SQL 
    End Sub

    ' ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOSELIMINAR DESCENTOS
    Private Async Sub btnEliminarDescuento_Click(sender As Object, e As EventArgs) Handles btnEliminarDescuento.Click
        Dim descuentosEliminados As Integer = 0




        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim itemId As String = row.Cells(0).Value.ToString()
                If Await EliminarDescuentoAsync(itemId, token) Then
                    descuentosEliminados += 1
                End If
            End If
        Next


        MessageBox.Show($"Se eliminaron {descuentosEliminados} promociones de descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Async Function EliminarDescuentoAsync(itemId As String, accessToken As String) As Task(Of Boolean)
        Dim baseUrl As String = "https://api.mercadolibre.com/seller-promotions/items/"
        Dim promotionType As String = "PRICE_DISCOUNT"

        Using httpClient As New HttpClient()
            httpClient.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Bearer", accessToken)

            Dim requestUrl As String = $"{baseUrl}{itemId}?promotion_type={promotionType}"
            Dim response As HttpResponseMessage = Await httpClient.DeleteAsync(requestUrl)

            If response.IsSuccessStatusCode Then
                Return True
            Else
                Dim errorContent As String = Await response.Content.ReadAsStringAsync()
                If response.StatusCode = HttpStatusCode.BadRequest AndAlso errorContent.Contains("No offers found for item") Then
                    ' Ignora el error específico "No offers found for item" y continúa con el siguiente artículo.
                    Return False
                Else
                    Return False
                End If
            End If
        End Using
    End Function


    Function GetActivePromotions(userId As String, token As String) As Dictionary(Of String, String)
        Dim client As New RestClient("https://api.mercadolibre.com/")
        Dim request As New RestRequest("seller-promotions/users/" & userId, Method.GET)
        request.AddHeader("Authorization", "Bearer " & token)
        request.AddHeader("Content-Type", "application/json")

        Dim response = client.Execute(request)

        If response.StatusCode = HttpStatusCode.OK Then
            Dim jsonResponse = JsonConvert.DeserializeObject(Of JsonResponse)(response.Content)
            Dim activePromotions = New Dictionary(Of String, String)

            For Each promotion In jsonResponse.results
                If promotion.status = "active" Then
                    activePromotions.Add(promotion.item_id, promotion.id)
                End If
            Next

            Return activePromotions
        Else
            Return Nothing
        End If
    End Function

    ' ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOSELIMINAR DESCENTOS


    Private Sub ObtenerPublicaciones(ByVal token As String, ByVal sellerId As String, ByVal input As String)
        Dim totalResults As Integer = 0
        Dim offset As Integer = 0
        Dim limit As Integer = 50

        DataGridView1.Rows.Clear()

        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("Column1", "Item ID")
        DataGridView1.Columns.Add("Column2", "Título")
        DataGridView1.Columns.Add("Column3", "Precio")
        DataGridView1.Columns.Add("Column4", "Precio Original")
        DataGridView1.Columns.Add("Column5", "Distinto")
        DataGridView1.Columns.Add("Column6", "Catálogo")
        DataGridView1.Columns.Add("Column7", "Tipo")
        DataGridView1.Columns.Add("Column8", "Price To Win")


        Dim client As New RestClient("https://api.mercadolibre.com/")

        Dim request As New RestRequest($"items/{input}", Method.GET)
        request.AddHeader("Authorization", $"Bearer {token}")
        Dim response As IRestResponse = client.Execute(request)
        If response.StatusCode = HttpStatusCode.OK Then
            Dim jsonResponse As JObject = JObject.Parse(response.Content)

            Dim itemId As String = jsonResponse("id").ToString()
            Dim title As String = jsonResponse("title").ToString()

            Dim price As Double = 0
            Dim priceStr As String = jsonResponse("price").ToString()
            If Not String.IsNullOrEmpty(priceStr) AndAlso Double.TryParse(priceStr, price) Then
                price = Convert.ToDouble(priceStr)
            End If

            Dim originalPrice As Double = 0
            Dim originalPriceStr As String = jsonResponse("original_price").ToString()
            If Not String.IsNullOrEmpty(originalPriceStr) AndAlso Double.TryParse(originalPriceStr, originalPrice) Then
                originalPrice = Convert.ToDouble(originalPriceStr)
            Else
                originalPrice = 0
            End If

            Dim preciosDistintos As Boolean = (originalPrice <> 0 AndAlso price <> originalPrice)

            Dim catalogListing As String = jsonResponse("catalog_listing")?.ToString()

            Dim listingTypeId As String = jsonResponse("listing_type_id").ToString()
            If listingTypeId = "gold_special" Then
                listingTypeId = "Clasica"
            ElseIf listingTypeId = "gold_pro" Then
                listingTypeId = "Premium"
            End If

            Dim tipoSeleccionado As String = combo_tipo.SelectedItem.ToString()

            If ((tipoSeleccionado = "PREMIUM" AndAlso listingTypeId = "Premium") OrElse
            (tipoSeleccionado = "CLASICA" AndAlso listingTypeId = "Clasica") OrElse
            tipoSeleccionado = "TODOS") Then
                If FiltrarPorDescuento(Combo_descuentos.SelectedItem.ToString(), preciosDistintos) Then
                    DataGridView1.Rows.Add(itemId, title, price, originalPrice, If(preciosDistintos, "si", "no"), catalogListing, listingTypeId, "")
                End If
            End If
        Else
            While True
                request = New RestRequest($"sites/MLA/search", Method.GET)
                request.AddHeader("Authorization", $"Bearer {token}")
                request.AddParameter("seller_id", sellerId)
                request.AddParameter("q", input)
                request.AddParameter("offset", offset)
                request.AddParameter("limit", limit)
                request.AddParameter("search_type", "scan")

                Try
                    response = client.Execute(request)

                    If response.StatusCode = HttpStatusCode.OK Then
                        Dim jsonResponse As JObject = JObject.Parse(response.Content)
                        Dim results As JArray = DirectCast(jsonResponse("results"), JArray)

                        If totalResults = 0 Then
                            totalResults = Convert.ToInt32(jsonResponse("paging")("total"))
                        End If

                        For Each result As JObject In results
                            Dim itemId As String = result("id").ToString()
                            Dim title As String = result("title").ToString()

                            Dim price As Double = 0
                            Dim priceStr As String = result("price").ToString()
                            If Not String.IsNullOrEmpty(priceStr) AndAlso Double.TryParse(priceStr, price) Then
                                price = Convert.ToDouble(priceStr)
                            End If

                            Dim originalPrice As Double = 0
                            Dim originalPriceStr As String = result("original_price").ToString()
                            If Not String.IsNullOrEmpty(originalPriceStr) AndAlso Double.TryParse(originalPriceStr, originalPrice) Then
                                originalPrice = Convert.ToDouble(originalPriceStr)
                            Else
                                originalPrice = 0
                            End If

                            Dim preciosDistintos As Boolean = (originalPrice <> 0 AndAlso price <> originalPrice)

                            Dim catalogListing As String = result("catalog_listing")?.ToString()

                            Dim listingTypeId As String = result("listing_type_id").ToString()
                            If listingTypeId = "gold_special" Then
                                listingTypeId = "Clasica"
                            ElseIf listingTypeId = "gold_pro" Then
                                listingTypeId = "Premium"
                            End If

                            Dim palabras() As String = input.Split(" ")
                            Dim todasPalabrasEncontradas As Boolean = True
                            For Each palabra As String In palabras
                                If title.IndexOf(palabra, StringComparison.OrdinalIgnoreCase) < 0 Then
                                    todasPalabrasEncontradas = False
                                    Exit For
                                End If
                            Next

                            If todasPalabrasEncontradas Then
                                Dim tipoSeleccionado As String = combo_tipo.SelectedItem.ToString()
                                Select Case Combo_catalogo.SelectedItem.ToString()
                                    Case "SI"
                                        If catalogListing = "True" AndAlso
                                   ((tipoSeleccionado = "PREMIUM" AndAlso listingTypeId = "Premium") OrElse
                                    (tipoSeleccionado = "CLASICA" AndAlso listingTypeId = "Clasica") OrElse
                                    tipoSeleccionado = "TODOS") Then
                                            If FiltrarPorDescuento(Combo_descuentos.SelectedItem.ToString(), preciosDistintos) Then
                                                DataGridView1.Rows.Add(itemId, title, price, originalPrice, If(preciosDistintos, "si", "no"), catalogListing, listingTypeId, "")
                                            End If
                                        End If
                                    Case "NO"
                                        If String.IsNullOrEmpty(catalogListing) AndAlso
                                   ((tipoSeleccionado = "PREMIUM" AndAlso listingTypeId = "Premium") OrElse
                                    (tipoSeleccionado = "CLASICA" AndAlso listingTypeId = "Clasica") OrElse
                                    tipoSeleccionado = "TODOS") Then
                                            If FiltrarPorDescuento(Combo_descuentos.SelectedItem.ToString(), preciosDistintos) Then
                                                DataGridView1.Rows.Add(itemId, title, price, originalPrice, If(preciosDistintos, "si", "no"), catalogListing, listingTypeId, "")
                                            End If
                                        End If
                                    Case "TODOS"
                                        If ((tipoSeleccionado = "PREMIUM" AndAlso listingTypeId = "Premium") OrElse
                                    (tipoSeleccionado = "CLASICA" AndAlso listingTypeId = "Clasica") OrElse
                                    tipoSeleccionado = "TODOS") Then
                                            If FiltrarPorDescuento(Combo_descuentos.SelectedItem.ToString(), preciosDistintos) Then
                                                DataGridView1.Rows.Add(itemId, title, price, originalPrice, If(preciosDistintos, "si", "no"), catalogListing, listingTypeId, "")
                                            End If
                                        End If
                                End Select

                            End If
                        Next
                    Else
                        MsgBox("No se pudo obtener la respuesta del servidor. Por favor, intente nuevamente.", vbCritical)
                        Exit Sub
                    End If

                    offset += 50

                    If offset >= totalResults OrElse DataGridView1.Rows.Count >= totalResults Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrió un error al obtener las publicaciones. " + ex.Message, vbCritical)
                    Exit Sub
                End Try

            End While
        End If


    End Sub


    Private Async Sub FetchPriceToWinAsync()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim catalogListing As String = row.Cells("Column6").Value.ToString()
                If catalogListing = "True" Then
                    Dim item_id As String = row.Cells("Column1").Value.ToString()
                    Try
                        Dim priceToWin As String = Await GetPriceToWin2(item_id)
                        row.Cells("Column8").Value = priceToWin
                    Catch ex As Exception
                        row.Cells("Column8").Value = "Error: " & ex.Message
                    End Try
                End If
            End If
        Next
    End Sub


    Public Async Function GetPriceToWin2(item_id As String) As Task(Of String)
        Dim result As String = ""
        Dim siteId As String = "MLA" ' Reemplaza "TU_SITE_ID" por el valor correcto del SITE_ID

        Using client As New WebClient()
            Dim url As String = $"https://api.mercadolibre.com/items/{item_id}/price_to_win?siteId={siteId}&version=v2"
            client.Headers(HttpRequestHeader.Authorization) = "Bearer " & token

            Dim response As String = client.DownloadString(url)
            Dim data As JObject = JObject.Parse(response)
            result = data("price_to_win").ToString()

        End Using

        Return result
    End Function



    Private Function FiltrarPorDescuento(ByVal descuento As String, ByVal preciosDistintos As Boolean) As Boolean
        Select Case descuento
            Case "SI"
                If preciosDistintos Then
                    Return True
                End If
            Case "NO"
                If Not preciosDistintos Then
                    Return True
                End If
            Case "TODOS"
                Return True
        End Select
        Return False
    End Function


    Private Async Sub listado_ventas_Click(sender As Object, e As EventArgs) Handles listado_ventas.Click
        Dim acces_token As String = token
        Dim sellerId As String = "183426174"
        Dim palabraFiltro As String = txt_palabrafiltro.Text

        ObtenerPublicaciones(acces_token, sellerId, palabraFiltro)
        FetchPriceToWinAsync()

    End Sub


    Private Sub check_finde_CheckedChanged(sender As Object, e As EventArgs) Handles check_finde.CheckedChanged
        Dim today As DateTime = DateTime.Today
        Dim daysUntilFriday As Integer = (DayOfWeek.Friday - today.DayOfWeek + 7) Mod 7
        Dim friday As DateTime = today.AddDays(daysUntilFriday)
        Dim formattedDate As String = friday.ToString("yyyy-MM-dd")
        txt_fechainicio.Text = formattedDate

        Dim daysUntilMonday As Integer = (DayOfWeek.Monday - friday.DayOfWeek + 7) Mod 7
        Dim monday As DateTime = friday.AddDays(daysUntilMonday)
        Dim formattedDate2 As String = monday.ToString("yyyy-MM-dd")
        txt_fechafin.Text = formattedDate2

        txt_horainicio.Text = "16:00:00"
        txt_horafin.Text = "06:00:00"

    End Sub

    Private Async Sub btn_Actualizarmshops_Click(sender As Object, e As EventArgs)
        Dim itemId As String = "MLA905133135"
        Dim discountPercentage As Double = 13
        Dim accessToken As String = token 'Asegúrate de reemplazar 'token' con la variable que almacena tu token de acceso

        Dim httpClient As HttpClient = New HttpClient()
        httpClient.DefaultRequestHeaders.Authorization = New Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken)
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json")

        ' Obtener el precio actual del artículo
        Dim getItemUrl As String = $"https://api.mercadolibre.com/items/{itemId}"
        Dim getPriceResponse As HttpResponseMessage = Await httpClient.GetAsync(getItemUrl)
        getPriceResponse.EnsureSuccessStatusCode()

        Dim getPriceJson As String = Await getPriceResponse.Content.ReadAsStringAsync()
        Dim itemData As JObject = JObject.Parse(getPriceJson)
        Dim currentPrice As Double = itemData("price").Value(Of Double)()

        ' Calcular el nuevo precio con el descuento
        Dim salePrice As Double = Math.Round(currentPrice * (1 - discountPercentage / 100), 2)

        ' Establecer la fecha de inicio y finalización de la promoción
        Dim saleStartDate As String = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
        Dim saleEndDate As String = DateTime.UtcNow.AddDays(7).ToString("yyyy-MM-ddTHH:mm:ss.fffZ") ' Establecer la duración de la promoción a 7 días (puedes cambiar esto)

        ' Actualizar el artículo con el precio de descuento y las fechas de inicio y finalización de la promoción
        Dim updatePriceUrl As String = $"https://api.mercadolibre.com/items/{itemId}"
        Dim updateData As JObject = New JObject(
        New JProperty("sale_price", salePrice),
        New JProperty("sale_price_start_date", saleStartDate),
        New JProperty("sale_price_end_date", saleEndDate)
    )
        Dim updateContent As StringContent = New StringContent(updateData.ToString(), Encoding.UTF8, "application/json")

        Dim updateResponse As HttpResponseMessage = Nothing
        Dim exception As HttpRequestException = Nothing

        Try
            updateResponse = Await httpClient.PutAsync(updatePriceUrl, updateContent)
            updateResponse.EnsureSuccessStatusCode()

            MessageBox.Show($"La promoción del {discountPercentage}% de descuento se ha aplicado exitosamente a la publicación {itemId}.", "Promoción aplicada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As HttpRequestException
            exception = ex
        End Try

        If exception IsNot Nothing Then
            Dim responseContent As String = String.Empty
            If updateResponse IsNot Nothing AndAlso updateResponse.Content IsNot Nothing Then
                responseContent = Await updateResponse.Content.ReadAsStringAsync()
            End If
            txt_palabrafiltro.Text = $"Error al aplicar la promoción. Código de estado: {updateResponse?.StatusCode}{Environment.NewLine}Mensaje de error: {exception.Message}{Environment.NewLine}Contenido de la respuesta: {responseContent}" & "Error" & MessageBoxButtons.OK & MessageBoxIcon.Error
        End If
    End Sub



    Public Sub New()
        InitializeComponent()
        txt_palabrafiltro.Text = "Palabra filtro o ID de producto"
        txt_palabrafiltro.ForeColor = Color.Gray

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        customCulture = CType(CultureInfo.GetCultureInfo("es-AR").Clone(), CultureInfo)
        customCulture.NumberFormat.NumberGroupSeparator = "."

    End Sub

    Private Sub txt_palabrafiltro_Enter(sender As Object, e As EventArgs) Handles txt_palabrafiltro.Enter
        If txt_palabrafiltro.Text = "Palabra filtro o ID de producto" Then
            txt_palabrafiltro.Text = ""
            txt_palabrafiltro.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_palabrafiltro_Leave(sender As Object, e As EventArgs) Handles txt_palabrafiltro.Leave
        If txt_palabrafiltro.Text = "" Then
            txt_palabrafiltro.Text = "Palabra filtro o ID de producto"
            txt_palabrafiltro.ForeColor = Color.Gray
        End If
    End Sub




    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        CalcularDescuento()
    End Sub

    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged
        CalcularDescuento()
    End Sub

    Private customCulture As CultureInfo
    Private Sub CalcularDescuento()
        If DataGridView1.CurrentRow IsNot Nothing AndAlso Not String.IsNullOrEmpty(txtDescuento.Text) Then
            Dim precioOriginal As Double = 0
            If Double.TryParse(DataGridView1.CurrentRow.Cells("Column4").Value.ToString(), precioOriginal) AndAlso precioOriginal > 0 Then
                CalcularPrecioConDescuento(precioOriginal)
                lbl_preciosindescuento.Text = precioOriginal.ToString("N0", customCulture)
            Else
                Dim precio As Double = Convert.ToDouble(DataGridView1.CurrentRow.Cells("Column3").Value)
                CalcularPrecioConDescuento(precio)
                lbl_preciosindescuento.Text = precio.ToString("N0", customCulture)
            End If
        End If


    End Sub

    Private Sub CalcularPrecioConDescuento(precio As Double)
        Dim descuento As Double = Convert.ToDouble(txtDescuento.Text) / 100
        Dim customCulture As CultureInfo = CType(CultureInfo.GetCultureInfo("es-AR").Clone(), CultureInfo)
        customCulture.NumberFormat.NumberGroupSeparator = "."
        lbl_preciodescuento.Text = (precio - precio * descuento).ToString("N0", customCulture)
    End Sub

    Private Sub lbl_preciosindescuento_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles lbl_preciosindescuento.Paint
        Dim strikeThroughPen As New Pen(Color.Red, 2)
        e.Graphics.DrawLine(strikeThroughPen, New Point(0, lbl_preciosindescuento.Height / 2), New Point(lbl_preciosindescuento.Width, lbl_preciosindescuento.Height / 2))
    End Sub

    Private Sub btn_transformar_Click(sender As Object, e As EventArgs) Handles btn_transformar.Click
        lbl_preciosindescuento.Text = txt_preciodescuento.Text

        ' Asegúrate de que una fila esté seleccionada en DataGridView1
        If DataGridView1.CurrentRow IsNot Nothing Then
            ' Obten el precio original de la fila seleccionada en DataGridView1
            Dim precioOriginal As Double = Convert.ToDouble(DataGridView1.CurrentRow.Cells("Column3").Value)

            ' Asegúrate de que se haya ingresado un precio con descuento
            If Not String.IsNullOrEmpty(txt_preciodescuento.Text) Then
                ' Obten el precio con descuento ingresado
                Dim precioConDescuento As Double = Convert.ToDouble(txt_preciodescuento.Text)

                ' Calcula el porcentaje de descuento necesario para llegar al precio con descuento
                Dim descuento As Double = (precioOriginal - precioConDescuento) / precioOriginal * 100

                ' Actualiza txtDescuento con el valor absoluto del porcentaje de descuento calculado
                txtDescuento.Text = Math.Round(Math.Abs(descuento)).ToString(customCulture)
            End If
        End If
    End Sub

    Private Sub txt_preciodescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_preciodescuento.KeyPress
        If (Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_preciodescuento_TextChanged(sender As Object, e As EventArgs) Handles txt_preciodescuento.TextChanged
        If Not String.IsNullOrEmpty(txt_preciodescuento.Text) Then
            ' Remover cualquier formato existente
            Dim text As String = txt_preciodescuento.Text.Replace(".", "")

            ' Convertir a número
            If Decimal.TryParse(text, Nothing) Then
                ' Formatear con puntos como separadores de miles
                txt_preciodescuento.Text = Decimal.Parse(text).ToString("N0")
            End If
        End If
    End Sub




    Private Async Function GetPriceToWin(item_id As String) As Task(Of String)
        Dim result As String = ""
        Dim siteId As String = "TU_SITE_ID" ' Reemplaza "TU_SITE_ID" por el valor correcto del SITE_ID

        Using client As New HttpClient()
            Dim url As String = $"https://api.mercadolibre.com/items/{item_id}/price_to_win?siteId={siteId}&version=v2"
            client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", token)

            Dim response As HttpResponseMessage = Await client.GetAsync(url)

            If response.IsSuccessStatusCode Then
                Dim responseContent As String = Await response.Content.ReadAsStringAsync()
                Dim data As JObject = JObject.Parse(responseContent)
                result = data("price_to_win").ToString()
            Else
                Throw New Exception("No se pudo obtener el price to win. Código de estado HTTP: " & response.StatusCode)
            End If
        End Using

        Return result
    End Function




    ' INCREMENTO Y DESCUENTO.

    Private Sub btn_incremento_descuento_Click(sender As Object, e As EventArgs) Handles btn_incremento_descuento.Click
        Dim acces_token As String = token

        Dim porcentaje_incremento As Double
        If Double.TryParse(txt_incremento.Text, porcentaje_incremento) AndAlso porcentaje_incremento >= 0 Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim itemID As String = row.Cells(0).Value.ToString()
                    Dim precio_actual As Double = ObtenerPrecioActual(acces_token, itemID)

                    If precio_actual >= 0 Then
                        Dim nuevo_precio As Double = Math.Round(precio_actual * (1 + porcentaje_incremento / 100), 2)
                        Dim jsonUpdatedPrice As String = "{""price"":" & nuevo_precio.ToString(System.Globalization.CultureInfo.InvariantCulture) & "}"
                        Dim success As Boolean = UpdateItemPrice(acces_token, itemID, jsonUpdatedPrice)

                        ' Si la actualización del precio fue exitosa, aplicar descuento
                        If success Then
                            ' Ahora, calcular el porcentaje de descuento para devolver al precio original
                            Dim descuento_porcentaje As Double = 100 * (nuevo_precio - precio_actual) / nuevo_precio
                            AplicarDescuento(acces_token, itemID, descuento_porcentaje)
                        End If
                    End If
                End If
            Next
        Else
            MessageBox.Show("Por favor, ingrese un número válido en el campo de incremento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub AplicarDescuento(acces_token As String, itemID As String, descuento_porcentaje As Double)
        Dim client As New RestClient("https://api.mercadolibre.com/")
        Dim discount As New Discount With {
            .discount_percent = descuento_porcentaje,
            .start_date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
            .finish_date = DateTime.Now.AddDays(7).ToString("yyyy-MM-ddTHH:mm:ss"),
            .promotion_type = "PRICE_DISCOUNT"
        }

        Dim jsonDiscount = JsonConvert.SerializeObject(discount)
        Dim request As New RestRequest("seller-promotions/items/" & itemID, Method.POST)
        request.AddHeader("Authorization", "Bearer " & acces_token)
        request.AddHeader("Content-Type", "application/json")
        request.AddParameter("application/json", jsonDiscount, ParameterType.RequestBody)

        Dim response = client.Execute(request)

        If response.StatusCode = HttpStatusCode.Created Then
            MessageBox.Show($"Descuento aplicado al artículo {itemID}")
        Else
            Dim errorResponse As JObject = JObject.Parse(response.Content)
            MessageBox.Show($"Error al aplicar descuento al artículo {itemID}. Mensaje: {errorResponse("message").ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Function ObtenerPrecioActual(acces_token As String, itemID As String) As Double
        Dim client As New RestClient($"https://api.mercadolibre.com/items/{itemID}")
        Dim request As New RestRequest(Method.GET)

        request.AddHeader("Authorization", $"Bearer {acces_token}")

        Dim response As IRestResponse = client.Execute(request)
        If response.StatusCode = System.Net.HttpStatusCode.OK Then
            Dim itemInfo As JObject = JObject.Parse(response.Content)
            Return CDbl(itemInfo("price").ToString())
        Else
            Dim errorResponse As JObject = JObject.Parse(response.Content)
            MessageBox.Show($"Error al obtener el precio actual. Mensaje: {errorResponse("message").ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End If
    End Function

    Public Function UpdateItemPrice(acces_token As String, itemID As String, jsonUpdatedPrice As String) As Boolean
        Dim client As New RestClient($"https://api.mercadolibre.com/items/{itemID}")
        Dim request As New RestRequest(Method.PUT)

        request.AddHeader("Authorization", $"Bearer {acces_token}")
        request.AddHeader("Content-Type", "application/json")
        request.AddParameter("application/json", jsonUpdatedPrice, ParameterType.RequestBody)

        Dim response As IRestResponse = client.Execute(request)
        If response.StatusCode = System.Net.HttpStatusCode.OK Then
            MessageBox.Show("El precio se actualizó correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            Dim errorResponse As JObject = JObject.Parse(response.Content)
            MessageBox.Show($"Error al actualizar el precio. Mensaje: {errorResponse("message").ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function

End Class


' ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOSELIMINAR DESCENTOS
Public Class JsonResponse
    Public Property results As List(Of Promotion)
End Class

Public Class Promotion
    Public Property id As String
    Public Property item_id As String
    Public Property status As String
End Class

' ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOS ELIMINAR DESCENTOSELIMINAR DESCENTOS


Public Class Discount
    Public Property discount_percent As Integer
    Public Property top_discount_percent As Integer
    Public Property start_date As String
    Public Property finish_date As String
    Public Property promotion_type As String
End Class
Public Class Deal
    Public Property id As String
    Public Property promotion_id As String
End Class


Public Class Publicacion
    Public Property id As String

    Public Property StockFull As Integer

End Class