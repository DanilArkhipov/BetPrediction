using System.Text.Json;

namespace Implementation.Extensions;

public static class HttpClientExtensions
{
    public static async Task<TData> GetDataAsync<TData>(this HttpClient client, string requestUrl)
    {
        var response = await client.GetAsync(requestUrl);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception();
        }
        var responseDataJson = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TData>(responseDataJson) ?? throw new InvalidOperationException();
    }
}