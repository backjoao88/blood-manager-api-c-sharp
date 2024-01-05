using System.Text.Json;
using Core.Dtos;
using Core.Services;

namespace BloodManager.Infrastructure.Services;

public class ViaCepPostalCodeService : IPostalCodeService
{
    private HttpClient _httpClient;

    public ViaCepPostalCodeService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<PostalCodeDto?> CheckPostalCodeAsync(string postalCode)
    {
        _httpClient.CancelPendingRequests();
        string requestUrl = $"https://viacep.com.br/ws/{postalCode}/json";
        var httpResponse = await _httpClient.GetAsync(requestUrl);
        string responseJsonString = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var document = JsonDocument.Parse(responseJsonString);
        var documentRoot = document.RootElement;
        var city = documentRoot.GetProperty("localidade").GetString() ?? "";
        var state = documentRoot.GetProperty("uf").GetString() ?? "";
        var street = documentRoot.GetProperty("logradouro").GetString() ?? "";
        return new PostalCodeDto(street, city, state);
    }
}