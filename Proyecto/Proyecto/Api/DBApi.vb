Imports System.Net
Imports System.Reflection.Metadata
Imports RestSharp

Public Class DBApi
    Friend ReadOnly Property Put(url As String, headers As List(Of Parametro), parametros As List(Of Parametro), json As Json) As Object
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Function MGet(url As String, headers As List(Of Parametro), param_encode As List(Of Parametro)) As String
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim client = New RestClient()
        client.BaseUrl = New Uri(url)

        Dim request = New RestRequest()
        request.Method = Method.GET

        For Each header As Parametro In headers
            request.AddHeader(header.Clave, header.Valor)
        Next

        For Each parametro As Parametro In param_encode
            request.AddParameter(parametro.Clave, parametro.Valor)
        Next

        Dim response = client.Execute(request).Content.ToString()

        Return response
    End Function
    Public Function Post(url As String, headers As List(Of Parametro), param_encode As List(Of Parametro), _json As Object) As String
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim client = New RestClient()
        client.BaseUrl = New Uri(url)

        Dim request = New RestRequest()
        request.Method = Method.POST
        For Each header As Parametro In headers
            request.AddHeader(header.Clave, header.Valor)
        Next

        For Each parametro As Parametro In param_encode
            request.AddParameter(parametro.Clave, parametro.Valor)
        Next

        If (param_encode.Count = 0) Then
            request.AddJsonBody(_json)
        End If

        Dim response = client.Execute(request).Content.ToString()

        Return response
    End Function


End Class

