Imports System.Windows.Forms
Imports System.Windows.Forms.DataFormats
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Imports RestSharp
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.ComponentModel.DataAnnotations
Imports System.Net.Http
Imports System.Net.Http.Headers

Public Class Publicador

    Public token As String
    Public token2 As String
    Private Sub Replicar_publicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MLToken()
    End Sub
    Private Sub btn_replicar_Click(sender As Object, e As EventArgs) Handles btn_replicar.Click

        Dim skuList As New List(Of Integer)()

        For Each skuTextBox As TextBox In {txt_sku, txt_sku2, txt_sku3, txt_sku4, txt_sku5, txt_sku6}
            If Not String.IsNullOrEmpty(skuTextBox.Text) Then
                skuList.Add(Integer.Parse(skuTextBox.Text))
            End If
        Next

        Dim sum As Integer = 0
        For Each num As Integer In skuList
            If num Mod 2 = 0 Then
                sum += num
            End If
        Next

        ' If there are no SKU texts in the list, show an error message.
        If skuList.Count = 0 Then
            MsgBox("No se asocio ningun SKU a la publicación, por favor cargar SKU en el/los campos correspondientes.")
            Return
        End If

        'Obtener detalles de la publicación original
        Dim originalPublicationId As String = txt_replicar.Text
        Dim originalPublicationDetails As JObject = GetPublicationDetails(originalPublicationId)

        'Crear una nueva publicación utilizando los detalles de la publicación original
        Dim newPublicationDetails As JObject = CreateNewPublication(originalPublicationDetails)
        Dim newPublicationDetails2 As JObject = CreateNewPublication2(originalPublicationDetails)

        'Enviar la nueva publicación a Mercado Libre para su publicación
        Dim newPublicationId As String = PublishNewPublication(newPublicationDetails)
        Dim newPublicationId2 As String = PublishNewPublication(newPublicationDetails2)

        ' Show the new publication IDs in the TextBoxes.
        TextBox2.Text = newPublicationId
        TextBox4.Text = newPublicationId2

        ' Show a message indicating the new publications have been created.
        MsgBox("Las nuevas publicaciónes han sido creadas con los ID " & newPublicationId & " y " & newPublicationId2)

        ' Add the new publication IDs to the DataGridView rows.
        For Each newPublicationIdItem In {newPublicationId, newPublicationId2}
            If Not String.IsNullOrEmpty(TextBox2.Text) And Not String.IsNullOrEmpty(TextBox4.Text) Then
                Dim row As String() = {newPublicationIdItem, "", "", "", "1", "1"}
                items_mercadolibre.Rows.Add(row)
            End If
        Next

        ' Add rows to the publicaciones_mercado_libre_basico DataGridView for each SKU text.
        For Each skuText As Integer In skuList
            If skuText > 0 And Not String.IsNullOrEmpty(TextBox2.Text) And Not String.IsNullOrEmpty(TextBox4.Text) Then ' Agregar solo si el valor de SKU es mayor que 0.
                Dim row As String() = {"1", "1", "", "", "", "", "", newPublicationId, newPublicationId, originalPublicationDetails("title"), skuText.ToString(), "", "1"}
                Dim row_premium As String() = {"1", "1", "", "", "", "", "", newPublicationId2, newPublicationId2, originalPublicationDetails("title"), skuText.ToString(), "", "1"}
                publicaciones_mercado_libre_basico.Rows.Add(row)
                publicaciones_mercado_libre_basico.Rows.Add(row_premium)
            End If
        Next
        'DESCRIPCION + ATRIBUTOS

        Dim atributosTexto As String = ""


        'Realizar la solicitud HTTP GET a la API de MercadoLibre para obtener los atributos de la publicación
        Dim url As String = "https://api.mercadolibre.com/items/" + newPublicationId
        Dim solicitud As HttpWebRequest = WebRequest.Create(url)
        Dim respuesta As HttpWebResponse = solicitud.GetResponse()

        'Leer la respuesta y convertirla a una cadena de texto
        Dim stream As System.IO.Stream = respuesta.GetResponseStream()
        Dim lector As New System.IO.StreamReader(stream)
        Dim respuestaTexto As String = lector.ReadToEnd()

        'Analizar la respuesta JSON y obtener los atributos de la publicación
        Dim respuestaJson As Object = JsonConvert.DeserializeObject(respuestaTexto)
        Dim atributos As JArray = respuestaJson("attributes")

        'Recorrer los atributos y mostrarlos en el TextBox
        For Each atributo As JObject In atributos
            atributosTexto += atributo("name").ToString() + ": " + atributo("value_name").ToString() + vbCrLf
        Next

        ' Obtener la descripción del archivo de texto
        Dim path As String = My.Application.Info.DirectoryPath & "\Publicaciones\Descripcion.txt" 'PRUEBAA
        Dim descripcion As String = File.ReadAllText(path)
        Dim titulo As String = originalPublicationDetails("title").ToString()
        Dim descripcion_real As String = "¡Bienvenido a BAÑ%FERTA! ¡Las mejores ofertas para renovar tu hogar!" & vbCrLf & vbCrLf & titulo & vbCrLf & vbCrLf & atributosTexto & vbCrLf & vbCrLf & "¿Buscas cuotas sin interés?: https://articulo.mercadolibre.com.ar/MLA-" & newPublicationId2.Substring(3) & vbCrLf & vbCrLf & "Items: " & txt_sku.Text & " " & txt_sku2.Text & " " & txt_sku3.Text & " " & txt_sku4.Text & " " & txt_sku5.Text & " " & txt_sku6.Text & " " & descripcion
        Dim url10 As String = "https://api.mercadolibre.com/items/" & newPublicationId & "/description"

        ' Crear el objeto de la solicitud
        Dim request As HttpWebRequest = WebRequest.Create(url10)
        request.Method = "PUT"
        request.Headers.Add("Authorization", "Bearer " & token)
        request.ContentType = "application/json"

        ' Crear el objeto JSON para la nueva descripción
        Dim json As String = JsonConvert.SerializeObject(New With {.plain_text = descripcion_real})

        ' Convertir el objeto JSON a un array de bytes y escribirlo en el cuerpo de la solicitud
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(json)
        Using stream10 As Stream = request.GetRequestStream()
            stream10.Write(bytes, 0, bytes.Length)
        End Using

        ' Enviar la solicitud y obtener la respuesta
        Try
            Dim response As HttpWebResponse = request.GetResponse()
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            ' Mostrar un mensaje de éxito si la descripción se modificó correctamente
            'MessageBox.Show("La descripción se modificó correctamente.")
        Catch ex As WebException
            ' Mostrar un mensaje de error si la descripción no se pudo modificar
            MessageBox.Show("Error al modificar la descripción: " & ex.Message)
        End Try


        '  MODIFICO DESCRIPCION PREMIUM

        'DESCRIPCION + ATRIBUTOS

        Dim atributosTexto2 As String = ""

        'Realizar la solicitud HTTP GET a la API de MercadoLibre para obtener los atributos de la publicación
        Dim url2 As String = "https://api.mercadolibre.com/items/" + newPublicationId2
        Dim solicitud2 As HttpWebRequest = WebRequest.Create(url2)
        Dim respuesta2 As HttpWebResponse = solicitud2.GetResponse()

        'Leer la respuesta y convertirla a una cadena de texto
        Dim stream2 As System.IO.Stream = respuesta2.GetResponseStream()
        Dim lector2 As New System.IO.StreamReader(stream2)
        Dim respuestaTexto2 As String = lector2.ReadToEnd()

        'Analizar la respuesta JSON y obtener los atributos de la publicación
        Dim respuestaJson2 As Object = JsonConvert.DeserializeObject(respuestaTexto2)
        Dim atributos2 As JArray = respuestaJson2("attributes")

        'Recorrer los atributos y mostrarlos en el TextBox
        For Each atributo2 As JObject In atributos2
            atributosTexto2 += atributo2("name").ToString() + ": " + atributo2("value_name").ToString() + vbCrLf
        Next



        Dim titulo2 As String = originalPublicationDetails("title").ToString()
        Dim descripcion_real2 As String = "¡Bienvenido a BAÑ%FERTA! ¡Las mejores ofertas para renovar tu hogar!" & vbCrLf & vbCrLf & titulo2 & vbCrLf & vbCrLf & atributosTexto2 & vbCrLf & vbCrLf & "¿Buscas un mejor precio??: https://articulo.mercadolibre.com.ar/MLA-" & newPublicationId.Substring(3) & vbCrLf & vbCrLf & "Items: " & txt_sku.Text & " " & txt_sku2.Text & " " & txt_sku3.Text & " " & txt_sku4.Text & " " & txt_sku5.Text & " " & txt_sku6.Text & " " & descripcion
        Dim url20 As String = "https://api.mercadolibre.com/items/" & newPublicationId2 & "/description"

        ' Crear el objeto de la solicitud
        Dim request2 As HttpWebRequest = WebRequest.Create(url20)
        request2.Method = "PUT"
        request2.Headers.Add("Authorization", "Bearer " & token)
        request2.ContentType = "application/json"

        ' Crear el objeto JSON para la nueva descripción
        Dim json2 As String = JsonConvert.SerializeObject(New With {.plain_text = descripcion_real2})

        ' Convertir el objeto JSON a un array de bytes y escribirlo en el cuerpo de la solicitud
        Dim bytes2 As Byte() = Encoding.UTF8.GetBytes(json2)
        Using stream20 As Stream = request2.GetRequestStream()
            stream20.Write(bytes2, 0, bytes2.Length)
        End Using

        ' Enviar la solicitud y obtener la respuesta
        Try
            Dim response2 As HttpWebResponse = request2.GetResponse()
            Dim dataStream2 As Stream = response2.GetResponseStream()
            Dim reader2 As New StreamReader(dataStream2)
            Dim responseFromServer2 As String = reader2.ReadToEnd()

            ' Mostrar un mensaje de éxito si la descripción se modificó correctamente
            'MessageBox.Show("La descripción se modificó correctamente.")
        Catch ex As WebException
            ' Mostrar un mensaje de error si la descripción no se pudo modificar
            MessageBox.Show("Error al modificar la descripción: " & ex.Message)
        End Try


        'MODIFICAR SKU CLASICA

        Dim request3 As HttpWebRequest = WebRequest.Create($"https://api.mercadolibre.com/items/{newPublicationId}")
        request3.Method = "PUT"
        request3.ContentType = "application/json"
        request3.Headers.Add("Authorization", "Bearer " & token)

        Dim data3 As JObject = New JObject()
        data3.Add("seller_custom_field", newPublicationId)
        Dim json3 As String = data3.ToString()
        Dim bytes3 As Byte() = System.Text.Encoding.UTF8.GetBytes(json3)
        request3.ContentLength = bytes3.Length
        Using stream40 As Stream = request3.GetRequestStream()
            stream40.Write(bytes3, 0, bytes3.Length)
        End Using

        ' Enviar la solicitud y procesar la respuesta
        Try
            Dim response3 As HttpWebResponse = request3.GetResponse()
            If response3.StatusCode = HttpStatusCode.OK Then
            Else
                MsgBox("Se ha producido un error al actualizar el SKU en: " & newPublicationId)
            End If
        Catch ex As WebException
            Dim response3 As HttpWebResponse = CType(ex.Response, HttpWebResponse)
            Dim reader3 As New StreamReader(response3.GetResponseStream())
            Dim errorResponse As String = reader3.ReadToEnd()
            MsgBox($"Se ha producido un error al actualizar el campo personalizado del vendedor: {errorResponse}")
        End Try

        TextBox1.Text = "https://www.mercadolibre.com.ar/publicaciones/" & TextBox2.Text & "/modificar/"



        ' MODIFICAR SKU PREMIUM
        Dim request4 As HttpWebRequest = WebRequest.Create($"https://api.mercadolibre.com/items/{newPublicationId2}")
        request4.Method = "PUT"
        request4.ContentType = "application/json"
        request4.Headers.Add("Authorization", "Bearer " & token)
        Dim data4 As JObject = New JObject()
        data4.Add("seller_custom_field", newPublicationId2)
        Dim json4 As String = data4.ToString()
        Dim bytes4 As Byte() = System.Text.Encoding.UTF8.GetBytes(json4)
        request4.ContentLength = bytes4.Length
        Using stream40dos As Stream = request4.GetRequestStream()
            stream40dos.Write(bytes4, 0, bytes4.Length)
        End Using

        ' Enviar la solicitud y procesar la respuesta
        Try
            Dim response4 As HttpWebResponse = request4.GetResponse()
            If response4.StatusCode = HttpStatusCode.OK Then
            Else
                MsgBox("Se ha producido un error al actualizar el SKU en: " & newPublicationId2)
            End If
        Catch ex As WebException
            Dim response4 As HttpWebResponse = CType(ex.Response, HttpWebResponse)
            Dim reader4 As New StreamReader(response4.GetResponseStream())
            Dim errorResponse2 As String = reader4.ReadToEnd()
            MsgBox($"Se ha producido un error al actualizar el campo personalizado del vendedor: {errorResponse2}")
        End Try
        TextBox3.Text = "https://www.mercadolibre.com.ar/publicaciones/" & TextBox4.Text & "/modificar/"


        Dim sellerCustomField As String = GetSellerCustomField(newPublicationId)
        Dim sellerCustomField2 As String = GetSellerCustomField(newPublicationId2)
        lbl_sku1.Text = sellerCustomField
        lbl_sku2.Text = sellerCustomField2


        txt_sku.Text = ""
        txt_sku2.Text = ""
        txt_sku3.Text = ""
        txt_sku4.Text = ""
        txt_sku5.Text = ""
        txt_sku6.Text = ""
        txt_replicar.Text = ""


    End Sub




    Private Function DeletePublication(publicationId As String, accessToken As String) As Boolean
        ' Construir la URL de la API de Mercado Libre para actualizar el estado de la publicación a "closed".
        Dim url As String = "https://api.mercadolibre.com/items/" & publicationId
        ' Crear una instancia del cliente HttpClient para enviar la solicitud HTTP.
        Dim client As New HttpClient()

        ' Configurar la solicitud HTTP.
        Dim request As New HttpRequestMessage(HttpMethod.Put, url)
        request.Headers.Authorization = New AuthenticationHeaderValue("Bearer", accessToken)

        ' Crear el cuerpo de la solicitud HTTP.
        Dim requestBody As New JObject()
        requestBody("status") = "closed"
        request.Content = New StringContent(requestBody.ToString(), Encoding.UTF8, "application/json")

        Try
            ' Enviar la solicitud HTTP y recibir la respuesta.
            Dim response As HttpResponseMessage = client.SendAsync(request).Result

            ' Analizar la respuesta HTTP y devolver el resultado.
            If response.IsSuccessStatusCode Then
                Return True
            Else
                Dim errorJson As JObject = JObject.Parse(response.Content.ReadAsStringAsync().Result)
                Dim errorMessage As String = errorJson.SelectToken("message").ToString()
                MsgBox("Error al eliminar la publicación: " & errorMessage)
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar la publicación: " & ex.Message)
            Return False
        End Try
    End Function





    Private Sub Replicar_publicacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim dgvPublicacionesVacio As Boolean = (publicaciones_mercado_libre_basico.Rows.Count = 0)
        Dim dgvItemsVacio As Boolean = (items_mercadolibre.Rows.Count = 0)


        If Not dgvPublicacionesVacio Or Not dgvItemsVacio Then


            Dim form2Abierto As Boolean = False
            For Each form As Form In Application.OpenForms
                If TypeOf form Is Syteline Then
                    form2Abierto = True
                    Exit For
                End If
            Next

            If Not form2Abierto Then
                Dim Syteline As New Syteline()
                Syteline.Show()
            End If


            ' Almacenar datos de DataGridView en variables temporales
            Dim publicaciones As List(Of List(Of String)) = New List(Of List(Of String))
            Dim items As List(Of List(Of String)) = New List(Of List(Of String))

            For Each row As DataGridViewRow In publicaciones_mercado_libre_basico.Rows
                Dim fila As List(Of String) = New List(Of String)
                For Each cell As DataGridViewCell In row.Cells
                    fila.Add(cell.Value)
                Next
                publicaciones.Add(fila)
            Next

            For Each row As DataGridViewRow In items_mercadolibre.Rows
                Dim fila As List(Of String) = New List(Of String)
                For Each cell As DataGridViewCell In row.Cells
                    fila.Add(cell.Value)
                Next
                items.Add(fila)
            Next

            ' Obtener Form2
            Dim form2 As Syteline = Application.OpenForms.OfType(Of Syteline).FirstOrDefault()

            If form2 IsNot Nothing Then
                ' Asignar datos almacenados en Form2
                form2.publicaciones_mercado_libre_basico.Rows.Clear()
                For Each publicacion As List(Of String) In publicaciones
                    form2.publicaciones_mercado_libre_basico.Rows.Add(publicacion.ToArray())
                Next

                form2.items_mercadolibre.Rows.Clear()
                For Each item As List(Of String) In items
                    form2.items_mercadolibre.Rows.Add(item.ToArray())
                Next
            End If


            e.Cancel = True ' Cancelar el cierre del formulario 1
            Me.Hide() ' Ocultar el formulario 1

        End If
    End Sub

    Private Function GetPublicationDetails(publicationId As String) As JObject
        Dim client As New RestClient("https://api.mercadolibre.com/items/" & publicationId)
        Dim request As New RestRequest(Method.GET)

        ' Agregar el token de acceso como encabezado de autorización
        request.AddHeader("Authorization", "Bearer " & token)

        Try
            Dim response As IRestResponse = client.Execute(request)
            If response.StatusCode = HttpStatusCode.OK Then
                Return JObject.Parse(response.Content)
            Else
                ' Manejar otros códigos de estado de respuesta aquí
                Throw New Exception("Error en la solicitud: " & response.StatusCode.ToString())
            End If
        Catch ex As Exception
            ' Manejar excepciones generales aquí
            Throw New Exception("Error al obtener detalles de la publicación: " & ex.Message)
        End Try
    End Function
    Private Function CreateNewPublication(originalPublicationDetails As JObject) As JObject
        Dim newPublicationDetails As New JObject()
        Dim newSaleTerms As New JArray()

        'Copiar los campos necesarios de la publicación original a la nueva publicación
        newPublicationDetails.Add("title", originalPublicationDetails("title"))
        newPublicationDetails.Add("category_id", originalPublicationDetails("category_id"))
        newPublicationDetails.Add("price", 999999)
        newPublicationDetails.Add("currency_id", originalPublicationDetails("currency_id"))
        newPublicationDetails.Add("available_quantity", 1)
        newPublicationDetails.Add("buying_mode", originalPublicationDetails("buying_mode"))
        newPublicationDetails.Add("listing_type_id", "gold_special")
        newPublicationDetails.Add("condition", originalPublicationDetails("condition"))
        newPublicationDetails.Add("video_id", "7SUFYFVpWZ0")
        newPublicationDetails.Add("site_id", "MLA")
        newPublicationDetails.Add("channels", New JArray("marketplace", "mshops"))


        'Dim videos As New JArray()
        'videos.Add(New JObject(New JProperty("video_id", "7SUFYFVpWZ0")))
        'newPublicationDetails.Add("videos", videos)


        Dim pictures As New JArray()
        Dim originalPictures As JArray = originalPublicationDetails("pictures")
        If originalPictures.Count > 0 Then
            Dim firstPicture As JObject = originalPictures(0)
            pictures.Add(firstPicture)
            pictures.Add(New JObject(New JProperty("source", "https://http2.mlstatic.com/D_NQ_NP_674468-MLA54519934843_032023-O.webp")))
            pictures.Add(New JObject(New JProperty("source", "https://http2.mlstatic.com/D_NQ_NP_839829-MLA54519934853_032023-O.webp")))
            pictures.Add(New JObject(New JProperty("source", "https://http2.mlstatic.com/D_NQ_NP_728758-MLA54519827399_032023-O.webp")))
            pictures.Add(New JObject(New JProperty("source", "https://http2.mlstatic.com/D_NQ_NP_680788-MLA54522305616_032023-O.webp")))
        End If
        newPublicationDetails.Add("pictures", pictures)




        ' Agregar la primera imagen de la publicación original y otra imagen adicional a cada variación
        Dim originalVariations As JArray = originalPublicationDetails("variations")
        Dim newVariations As New JArray()

        For Each variation As JObject In originalVariations
            'Crear la nueva variación con la imagen original
            Dim newVariation As New JObject(variation)
            Dim newPictureIds As New JArray()
            newPictureIds.Add(originalPictures(0)("id"))
            newPictureIds.Add("674468-MLA54519934843_032023") 'Agregar el ID de la imagen adicional
            newPictureIds.Add("839829-MLA54519934853_032023") 'Agregar el ID de la imagen adicional
            newPictureIds.Add("728758-MLA54519827399_032023") 'Agregar el ID de la imagen adicional
            newPictureIds.Add("680788-MLA54522305616_032023") 'Agregar el ID de la imagen adicional

            'Actualizar las picture_ids de la variación con la imagen original y la imagen adicional
            newVariation("picture_ids") = newPictureIds
            newVariation("price") = "999999"
            newVariations.Add(newVariation)
        Next

        ' Agregar las variaciones actualizadas a la nueva publicación
        newPublicationDetails.Add("variations", newVariations)



        'Agregar todos los términos de venta a la nueva publicación
        For Each term As JObject In originalPublicationDetails("sale_terms")
            newSaleTerms.Add(term)
        Next
        newPublicationDetails.Add("sale_terms", newSaleTerms)


        'Copiar los atributos de la publicación original a la nueva publicación
        Dim attributes As JArray = originalPublicationDetails("attributes")
        Dim newAttributes As New JArray()

        For Each attribute As JObject In attributes
            Dim newAttribute As New JObject(attribute)
            If newAttribute("value_id") Is Nothing AndAlso newAttribute("value_name") Is Nothing Then
                newAttribute("value_id") = "-1"
                newAttribute("value_name") = "null"
            ElseIf newAttribute("value_id") Is Nothing Then
                newAttribute("value_id") = "-1"
            ElseIf newAttribute("value_name") Is Nothing Then
                newAttribute("value_name") = "null"
            End If
            newAttributes.Add(newAttribute)
        Next

        newPublicationDetails.Add("attributes", newAttributes)


        ' Copiar los detalles de envío
        Dim newShippingDetails As New JObject()
        newShippingDetails.Add("local_pick_up", "true")
        newShippingDetails.Add("mode", originalPublicationDetails("shipping")("mode"))
        newShippingDetails.Add("dimensions", originalPublicationDetails("shipping")("dimensions"))

        ' Agregar los detalles de envío a la nueva publicación
        newPublicationDetails.Add("shipping", newShippingDetails)



        Return newPublicationDetails
    End Function

    Private Function ImageToByte(ByVal img As Image) As Byte()
        Using stream As New MemoryStream()
            img.Save(stream, img.RawFormat)
            Return stream.ToArray()
        End Using
    End Function



    Private Function PublishNewPublication(newPublicationDetails As JObject) As String
        Dim client As New RestClient("https://api.mercadolibre.com/items")
        Dim request As New RestRequest(Method.POST)

        'Agregar el token de acceso como encabezado de autorización
        request.AddHeader("Authorization", "Bearer " & token)

        'Agregar los detalles de la nueva publicación como parámetros de la solicitud
        request.AddParameter("application/json", newPublicationDetails.ToString(), ParameterType.RequestBody)

        Dim response As IRestResponse = client.Execute(request)
        Dim responseContent As String = response.Content

        Dim jsonResponse As JObject = JObject.Parse(responseContent)
        Dim newPublicationId As String = jsonResponse("id")

        If String.IsNullOrEmpty(newPublicationId) Then
            MsgBox("No se pudo crear la publicación.")
            Return String.Empty
        End If

        Return newPublicationId
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim url As String = "https://www.mercadolibre.com.ar/publicaciones/" & TextBox2.Text & "/modificar/"
        Process.Start("cmd", "/c start " & url)


    End Sub



    Private Sub btn_descripcion_Click(sender As Object, e As EventArgs)
        ' Definir las variables necesarias
        Dim idPublicacion As String = TextBox2.Text ' ID de la publicación
        Dim sellerCustomField As String = "LA VOY A ROMPER TODA"

        ' Crear la solicitud de actualización
        Dim request As HttpWebRequest = WebRequest.Create($"https://api.mercadolibre.com/items/{idPublicacion}")
        request.Method = "PUT"
        request.ContentType = "application/json"
        request.Headers.Add("Authorization", "Bearer " & token)

        Dim data As JObject = New JObject()
        data.Add("seller_custom_field", sellerCustomField)
        Dim json As String = data.ToString()

        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(json)
        request.ContentLength = bytes.Length

        Using stream As Stream = request.GetRequestStream()
            stream.Write(bytes, 0, bytes.Length)
        End Using

        ' Enviar la solicitud y procesar la respuesta
        Try
            Dim response As HttpWebResponse = request.GetResponse()
            If response.StatusCode = HttpStatusCode.OK Then
                MsgBox("El campo personalizado del vendedor ha sido actualizado correctamente.")
            Else
                MsgBox("Se ha producido un error al actualizar el campo personalizado del vendedor.")
            End If
        Catch ex As WebException
            Dim response As HttpWebResponse = CType(ex.Response, HttpWebResponse)
            Dim reader As New StreamReader(response.GetResponseStream())
            Dim errorResponse As String = reader.ReadToEnd()
            MsgBox($"Se ha producido un error al actualizar el campo personalizado del vendedor: {errorResponse}")
        End Try
    End Sub



    Private Function CreateNewPublication2(originalPublicationDetails As JObject) As JObject

        Dim newPublicationDetails As New JObject()
        Dim newSaleTerms As New JArray()

        'Copiar los campos necesarios de la publicación original a la nueva publicación
        newPublicationDetails.Add("title", originalPublicationDetails("title"))
        newPublicationDetails.Add("category_id", originalPublicationDetails("category_id"))
        newPublicationDetails.Add("price", 999999)
        newPublicationDetails.Add("currency_id", originalPublicationDetails("currency_id"))
        newPublicationDetails.Add("available_quantity", originalPublicationDetails("available_quantity"))
        newPublicationDetails.Add("buying_mode", originalPublicationDetails("buying_mode"))
        newPublicationDetails.Add("listing_type_id", "gold_pro")
        newPublicationDetails.Add("condition", originalPublicationDetails("condition"))
        newPublicationDetails.Add("video_id", "7SUFYFVpWZ0")
        newPublicationDetails.Add("site_id", "MLA")
        newPublicationDetails.Add("channels", New JArray("marketplace", "mshops"))


        Dim pictures As New JArray()
        Dim originalPictures As JArray = originalPublicationDetails("pictures")
        If originalPictures.Count > 0 Then
            Dim firstPicture As JObject = originalPictures(0)
            pictures.Add(firstPicture)
            pictures.Add(New JObject(New JProperty("source", "https://http2.mlstatic.com/D_NQ_NP_674468-MLA54519934843_032023-O.webp")))
            pictures.Add(New JObject(New JProperty("source", "https://http2.mlstatic.com/D_NQ_NP_839829-MLA54519934853_032023-O.webp")))
            pictures.Add(New JObject(New JProperty("source", "https://http2.mlstatic.com/D_NQ_NP_728758-MLA54519827399_032023-O.webp")))
            pictures.Add(New JObject(New JProperty("source", "https://http2.mlstatic.com/D_NQ_NP_680788-MLA54522305616_032023-O.webp")))
        End If
        newPublicationDetails.Add("pictures", pictures)




        ' Agregar la primera imagen de la publicación original y otra imagen adicional a cada variación
        Dim originalVariations As JArray = originalPublicationDetails("variations")
        Dim newVariations As New JArray()

        For Each variation As JObject In originalVariations
            'Crear la nueva variación con la imagen original
            Dim newVariation As New JObject(variation)
            Dim newPictureIds As New JArray()
            newPictureIds.Add(originalPictures(0)("id"))
            newPictureIds.Add("674468-MLA54519934843_032023") 'Agregar el ID de la imagen adicional
            newPictureIds.Add("839829-MLA54519934853_032023") 'Agregar el ID de la imagen adicional
            newPictureIds.Add("728758-MLA54519827399_032023") 'Agregar el ID de la imagen adicional
            newPictureIds.Add("680788-MLA54522305616_032023") 'Agregar el ID de la imagen adicional

            'Actualizar las picture_ids de la variación con la imagen original y la imagen adicional
            newVariation("picture_ids") = newPictureIds
            newVariation("price") = "999999"
            newVariations.Add(newVariation)
        Next

        ' Agregar las variaciones actualizadas a la nueva publicación
        newPublicationDetails.Add("variations", newVariations)



        'Agregar todos los términos de venta a la nueva publicación
        For Each term As JObject In originalPublicationDetails("sale_terms")
            newSaleTerms.Add(term)
        Next
        newPublicationDetails.Add("sale_terms", newSaleTerms)


        'Copiar los atributos de la publicación original a la nueva publicación
        Dim attributes As JArray = originalPublicationDetails("attributes")
        Dim newAttributes As New JArray()

        For Each attribute As JObject In attributes
            Dim newAttribute As New JObject(attribute)
            newAttributes.Add(newAttribute)
        Next

        newPublicationDetails.Add("attributes", newAttributes)


        ' Copiar los detalles de envío
        Dim newShippingDetails2 As New JObject()
        newShippingDetails2.Add("local_pick_up", "true")
        newShippingDetails2.Add("mode", originalPublicationDetails("shipping")("mode"))
        newShippingDetails2.Add("dimensions", originalPublicationDetails("shipping")("dimensions"))

        ' Agregar los detalles de envío a la nueva publicación

        newPublicationDetails.Add("shipping", newShippingDetails2)

        Return newPublicationDetails
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim url As String = "https://www.mercadolibre.com.ar/publicaciones/" & TextBox4.Text & "/modificar/"
        Process.Start("cmd", "/c start " & url)

    End Sub



    Private Function GetSellerCustomField(publicationId As String) As String

        ' Obtener la URL de la API de Mercado Libre para la publicación específica
        Dim url As String = "https://api.mercadolibre.com/items/" + publicationId

        ' Crear una solicitud HTTP GET a la URL de la API
        Dim request As HttpWebRequest = WebRequest.Create(url)
        request.Method = "GET"

        ' Agregar el token de acceso a la solicitud HTTP
        request.Headers.Add("Authorization", "Bearer " & token)

        ' Obtener la respuesta de la API
        Dim response As HttpWebResponse = request.GetResponse()

        ' Leer la respuesta y convertirla a una cadena de texto
        Dim reader As New System.IO.StreamReader(response.GetResponseStream())
        Dim responseText As String = reader.ReadToEnd()

        ' Analizar la respuesta JSON y obtener el valor del campo personalizado "seller_custom_field"
        Dim responseJson As JObject = JObject.Parse(responseText)
        Dim sellerCustomField As String = responseJson("seller_custom_field").ToString()

        ' Devolver el valor del campo personalizado "seller_custom_field"
        Return sellerCustomField

    End Function

    Private Sub txt_eliminar_nuevas_Click(sender As Object, e As EventArgs) Handles txt_eliminar_nuevas.Click
        Dim publicationId As String = TextBox2.Text
        Dim publicationId2 As String = TextBox4.Text  ' ID de la publicación que deseas eliminar.
        Dim accessToken As String = token ' Reemplaza "APP_USR-1234567890" con tu token de acceso.

        ' Obtener los IDs de publicación eliminados.
        Dim deletedPublicationIds As New List(Of String)()
        If Not String.IsNullOrEmpty(publicationId) AndAlso DeletePublication(publicationId, accessToken) Then
            deletedPublicationIds.Add(publicationId)
            TextBox2.Text = "ELIMINADA"
            TextBox1.Text = ""
        End If
        If Not String.IsNullOrEmpty(publicationId2) AndAlso DeletePublication(publicationId2, accessToken) Then
            deletedPublicationIds.Add(publicationId2)
            TextBox4.Text = "ELIMINADA"
            TextBox3.Text = ""
        End If

        ' Eliminar las filas correspondientes en los DataGridViews.
        For Each publicationIdToDelete In deletedPublicationIds
            ' Eliminar las filas correspondientes en el DataGridView items_mercadolibre.
            For i As Integer = items_mercadolibre.Rows.Count - 1 To 0 Step -1
                If items_mercadolibre.Rows(i).Cells(0).Value = publicationIdToDelete Then
                    items_mercadolibre.Rows.RemoveAt(i)
                End If
            Next

            ' Eliminar las filas correspondientes en el DataGridView publicaciones_mercado_libre_basico.
            For i As Integer = publicaciones_mercado_libre_basico.Rows.Count - 1 To 0 Step -1
                If publicaciones_mercado_libre_basico.Rows(i).Cells(7).Value = publicationIdToDelete Or publicaciones_mercado_libre_basico.Rows(i).Cells(8).Value = publicationIdToDelete Then
                    publicaciones_mercado_libre_basico.Rows.RemoveAt(i)
                End If
            Next
        Next


    End Sub

    Private Sub asd_Enter(sender As Object, e As EventArgs) Handles asd.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim httpClient As New HttpClient()
        Dim accessToken As String = token  ' Reemplaza con tu token real
        Dim productId As String = txtCatalogProductID.Text  ' Obtén el product_id desde el TextBox

        If String.IsNullOrEmpty(productId) Then
            MessageBox.Show("El Product ID está vacío.")
            Return
        End If

        httpClient.DefaultRequestHeaders.Authorization = New Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken)

        Dim response As HttpResponseMessage = Await httpClient.GetAsync($"https://api.mercadolibre.com/products/{productId}")

        If response IsNot Nothing AndAlso response.IsSuccessStatusCode Then
            Dim content As String = Await response.Content.ReadAsStringAsync()
            Dim json As JObject = JObject.Parse(content)

            ' Accede a category_id dentro de buy_box_winner
            If json.ContainsKey("buy_box_winner") AndAlso json("buy_box_winner").HasValues AndAlso json("buy_box_winner")("category_id") IsNot Nothing Then
                txtCategoryID.Text = json("buy_box_winner")("category_id").ToString()
            Else
                MessageBox.Show("category_id no encontrado en la respuesta.")
            End If

            ' Accede a name para el título
            If json.ContainsKey("name") Then
                txtTitle.Text = json("name").ToString()
            Else
                MessageBox.Show("name (título) no encontrado en la respuesta.")
            End If
        Else
            MessageBox.Show("Error al cargar los datos.")
        End If


        Try
            Dim client As HttpClient = New HttpClient()

            ' Leer los datos de los TextBox
            Dim category_id As String = txtCategoryID.Text
            Dim product_id As String = txtCatalogProductID.Text
            Dim title As String = txtTitle.Text
            Dim price As Decimal = 10000000
            Dim currency_id As String = "ARS"
            Dim available_quantity As Integer = 1
            Dim attributes As Object() = {
                New With {.id = "CARRIER", .name = "Compañía telefónica", .value_id = "298335", .value_name = "Liberado"},
                New With {.id = "ITEM_CONDITION", .name = "Condición del ítem", .value_id = "2230284", .value_name = "Nuevo"}
            }
            Dim catalog_listing As Boolean = True

            ' Configurar el encabezado de autorización y el tipo de contenido
            client.DefaultRequestHeaders.Authorization = New Net.Http.Headers.AuthenticationHeaderValue("Bearer", Trim(token))

            Dim itemIds As New List(Of String)
            Dim goldSpecialItemId As String = String.Empty
            Dim goldProItemId As String = String.Empty

            ' Crear las dos publicaciones (gold_special y gold_pro)
            For Each listingType In New String() {"gold_special", "gold_pro"}
                ' Crear el objeto JSON para enviar
                Dim postData As Object = New With {
                    .site_id = "MLA",
                    .title = title,
                    .category_id = category_id,
                    .price = price,
                    .currency_id = currency_id,
                    .available_quantity = available_quantity,
                    .buying_mode = "buy_it_now",
                    .listing_type_id = listingType,
                    .pictures = New Object() {},
                    .attributes = attributes,
                    .catalog_product_id = product_id,
                    .catalog_listing = catalog_listing
                }

                Dim json As String = JsonConvert.SerializeObject(postData)

                Dim response3 As HttpResponseMessage = Await client.PostAsync("https://api.mercadolibre.com/items", New StringContent(json, Encoding.UTF8, "application/json"))

                If response3.IsSuccessStatusCode Then
                    Dim jsonString As String = Await response3.Content.ReadAsStringAsync()
                    Dim jsonData As JObject = JObject.Parse(jsonString)
                    Dim itemId As String = jsonData("id").ToString()
                    itemIds.Add($"ID del ítem {listingType}: {itemId}")

                    If listingType = "gold_special" Then
                        goldSpecialItemId = itemId
                    ElseIf listingType = "gold_pro" Then
                        goldProItemId = itemId
                    End If



                    'MODIFICAR SKU CLASICA

                    Dim request3 As HttpWebRequest = WebRequest.Create($"https://api.mercadolibre.com/items/{goldSpecialItemId}")
                    request3.Method = "PUT"
                    request3.ContentType = "application/json"
                    request3.Headers.Add("Authorization", "Bearer " & token)

                    Dim data3 As JObject = New JObject()
                    data3.Add("seller_custom_field", goldSpecialItemId)
                    Dim json3 As String = data3.ToString()
                    Dim bytes3 As Byte() = System.Text.Encoding.UTF8.GetBytes(json3)
                    request3.ContentLength = bytes3.Length
                    Using stream40 As Stream = request3.GetRequestStream()
                        stream40.Write(bytes3, 0, bytes3.Length)
                    End Using


                    ' MODIFICAR SKU PREMIUM
                    Dim request4 As HttpWebRequest = WebRequest.Create($"https://api.mercadolibre.com/items/{goldProItemId}")
                    request4.Method = "PUT"
                    request4.ContentType = "application/json"
                    request4.Headers.Add("Authorization", "Bearer " & token)
                    Dim data4 As JObject = New JObject()
                    data4.Add("seller_custom_field", goldProItemId)
                    Dim json4 As String = data4.ToString()
                    Dim bytes4 As Byte() = System.Text.Encoding.UTF8.GetBytes(json4)
                    request4.ContentLength = bytes4.Length
                    Using stream40dos As Stream = request4.GetRequestStream()
                        stream40dos.Write(bytes4, 0, bytes4.Length)
                    End Using


                    TextBox2.Text = goldProItemId
                    TextBox4.Text = goldSpecialItemId
                    TextBox1.Text = "https://www.mercadolibre.com.ar/publicaciones/" & TextBox2.Text & "/modificar/"
                    TextBox3.Text = "https://www.mercadolibre.com.ar/publicaciones/" & TextBox4.Text & "/modificar/"







                    If Not String.IsNullOrEmpty(goldSpecialItemId) And Not String.IsNullOrEmpty(TextBox2.Text) And Not String.IsNullOrEmpty(TextBox4.Text) Then
                        Dim row As String() = {goldSpecialItemId, "", "", "", "1", "1"}
                        items_mercadolibre.Rows.Add(row)
                    End If
                    If Not String.IsNullOrEmpty(goldProItemId) And Not String.IsNullOrEmpty(TextBox2.Text) And Not String.IsNullOrEmpty(TextBox4.Text) Then
                        Dim row As String() = {goldProItemId, "", "", "", "1", "1"}
                        items_mercadolibre.Rows.Add(row)
                    End If



                    Dim skuList As New List(Of Integer)()

                    For Each skuTextBox As TextBox In {txt_sku, txt_sku2, txt_sku3, txt_sku4, txt_sku5, txt_sku6}
                        If Not String.IsNullOrEmpty(skuTextBox.Text) Then
                            skuList.Add(skuTextBox.Text)
                        End If
                    Next

                    For Each skuText As Integer In skuList
                        If skuText > 0 And Not String.IsNullOrEmpty(TextBox2.Text) And Not String.IsNullOrEmpty(TextBox4.Text) Then
                            Dim row As String() = {"1", "1", "", "", "", "", "", "", goldSpecialItemId, goldSpecialItemId, title, skuText.ToString(), "", "1"}
                            Dim row_premium As String() = {"1", "1", "", "", "", "", "", "", goldProItemId, goldProItemId, title, skuText.ToString(), "", "1"}
                            publicaciones_mercado_libre_basico.Rows.Add(row)
                            publicaciones_mercado_libre_basico.Rows.Add(row_premium)
                        End If
                    Next





                Else
                    Dim errorContent As String = Await response.Content.ReadAsStringAsync()
                    MessageBox.Show($"Error al crear la publicación {listingType}: {response3.StatusCode} - {response3.ReasonPhrase}. Detalles: {errorContent}")
                    txtCatalogProductID.Text = $"Error al crear la publicación {listingType}: {response3.StatusCode} - {response3.ReasonPhrase}. Detalles: {errorContent}"

                End If
            Next

            ' Mostrar los item_ids en un solo cuadro de diálogo
            MessageBox.Show(String.Join(Environment.NewLine, itemIds))


        Catch ex As Exception
            txtCatalogProductID.Text = $"Se produjo un error: {ex.Message}"
            MessageBox.Show($"Se produjo un error: {ex.Message}")
        End Try






    End Sub

End Class

