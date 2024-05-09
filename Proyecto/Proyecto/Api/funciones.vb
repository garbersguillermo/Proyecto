Imports System.Windows
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Module funciones
    Dim formato21 As Integer
    Public Sub MLToken()

        Dim json As New jsonToken
        Dim api = New DBApi
        Dim url = "https://api.mercadolibre.com/oauth/token"
        Dim headers = New List(Of Parametro) From {
            New Parametro("accept", "application/json"),
            New Parametro("content-type", "application/x-www-form-urlencoded")
        }
        Dim parametros = New List(Of Parametro)
        json.grant_type = "refresh_token"
        json.client_id = "748785826240870"
        json.client_secret = "DQ1Q6nim60l3LSYVJzVwstNd9KxbTmma"
        json.refresh_token = "TG-65943186ff4e850001a97d35-183426174"
        Dim response = api.Post(url, headers, parametros, json)
        Dim objeto = JsonConvert.DeserializeObject(Of propiedades)(response)

        reporte_a_compras.token = objeto.access_token
        Busqueda_organica.token = objeto.access_token
        Posiciones_catalogo.token = objeto.access_token
        'Campañas.token = objeto.access_token
        Descuentos.token = objeto.access_token
        Publicador.token = objeto.access_token
        'Mensajes.token = "Bearer " & objeto.access_token
        'Publicaciones_en_baja.token = "Bearer " & objeto.access_token
        'detalleventas.TextBox1.Text = objeto.access_token

        Dim json2 As New jsonToken
        Dim api2 = New DBApi
        Dim url2 = "https://api.mercadolibre.com/oauth/token"
        Dim headers2 = New List(Of Parametro) From {
            New Parametro("accept", "application/json"),
            New Parametro("content-type", "application/x-www-form-urlencoded")
        }
        Dim parametros2 = New List(Of Parametro)
        json2.grant_type = "refresh_token"
        json2.client_id = "748785826240870"
        json2.client_secret = "DQ1Q6nim60l3LSYVJzVwstNd9KxbTmma"
        json2.refresh_token = "TG-641337fe1fadb10001623264-134232558"
        Dim response2 = api2.Post(url2, headers2, parametros2, json2)
        Dim objeto2 = JsonConvert.DeserializeObject(Of propiedades)(response2)

        'detalleventas.token = "Bearer " & objeto2.access_token
        'Pruebas.token = "Bearer " & objeto2.access_token
        'preguntas_respuestas.token = objeto2.access_token
        'preguntas_respuestas.client_id = json2.client_id
        'Form1.token = "Bearer " & objeto2.access_token
        'Replicar_publicacion.token2 = objeto2.access_token
        'Mensajes.token = "Bearer " & objeto2.access_token
        'detalleventas.TextBox1.Text = objeto.access_token

    End Sub





    'Public Class Order
    '    Public Property id As String
    '    Public Property date_created As DateTime
    '    Public Property total_amount As Decimal
    '    Public Property order_items As List(Of OrderItem)
    'End Class

    'Public Class OrderItem
    '    Public Property item As Item
    '    Public Property unit_price As Decimal
    '    Public Property quantity As Integer
    'End Class

    'Public Class Item
    '    Public Property id As String
    '    Public Property title As String
    'End Class


    Public Class Questions
        Public Property Results As List(Of Question)
    End Class

    Public Class Question
        Public Property Id As String
        Public Property Text As String
        Public Property Status As String
        Public Property date_created As String
        Public Property item_id As String

    End Class


End Module
Class user
    Public Property id As String
    Public Property seller As JObject
    Public Property title As String
    Public Property price As String
    Public Property listing_type_id As String
    Public Property available_quantity As String
    Public Property permalink As String
    Public Property paging As JObject
    Public Property primary_results As String
    Public Property sold_quantity As String
    Public Property thumbnail As String


End Class

Class Json

End Class
Class propiedades
    Public Property category_name As String
    Public Property seller_id As String
    Public Property title As String
    Public Property price As String
    Public Property id As String
    Public Property results As Object
    Public Property access_token As String


End Class

Public Class Answer
    Public Property text As String
    Public Property question_id As String
End Class
Public Class jsonAgregar_stock
    Public Property available_quantity As String
End Class
Public Class jsonModificar_stock
    Public Property available_quantity As String
End Class
Public Class jsonCrear_descripcion
    Public Property plain_text As String
End Class
Public Class jsonModificar_descripcion
    Public Property plain_text As String
End Class
Public Class jsonCambiar_titulo_precio
    Public Property title As String
    Public Property price As String
End Class
Public Class jsonToken
    Public Property grant_type As String
    Public Property client_id As String
    Public Property client_secret As String
    Public Property code As String
    Public Property redirect_uri As String

    Public Property refresh_token As String
End Class


