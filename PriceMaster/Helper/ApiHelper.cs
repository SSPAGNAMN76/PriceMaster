using System.Text;
using Newtonsoft.Json;
using PriceMaster.Models;

namespace PriceMaster.Helper;

public static class ApiHelper
{
    private static readonly HttpClient HttpClient = new HttpClient();

    public static async Task<TResponse> GetApiResponse<TResponse>(string apiUrl)
    {
        HttpResponseMessage response = await HttpClient.GetAsync(apiUrl);
        await HandleResponseError(response);

        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }

    public static async Task<TResponse> PostApiResponse<TResponse>(string apiUrl, object requestBody)
    {
        string requestBodyJson = JsonConvert.SerializeObject(requestBody);
        HttpContent content = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await HttpClient.PostAsync(apiUrl, content);
        await HandleResponseError(response);

        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(responseBody)!;
    }

    private static async Task HandleResponseError(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            string errorMessage = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(errorMessage))
            {
                errorMessage = response.ReasonPhrase ?? string.Empty;
            }

            throw new ApiException(errorMessage, response.StatusCode);
        }
    }
}