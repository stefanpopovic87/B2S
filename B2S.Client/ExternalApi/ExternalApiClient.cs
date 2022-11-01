using B2S.Contract.Client;
using System.Net.Http.Headers;
using System.Text.Json;

namespace B2S.Client.ExternalApi
{
    internal class ExternalApiClient : IExternalApiClient
    {

        private readonly ExternalApiSettings _externalApiSettings;
        private readonly HttpClient _httpClient;

        public ExternalApiClient(ExternalApiSettings externalApiSettings,
            HttpClient httpClien)
        {
            _externalApiSettings = externalApiSettings;
            _httpClient = httpClien;

            _httpClient.BaseAddress = new Uri(_externalApiSettings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", externalApiSettings.Token);
        }

        public async Task<GetCourseDetailsResponse> GetCourseDetailsAsync(long code)
        {
            HttpResponseMessage clientResponse = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/{code}");

            var responseContent = clientResponse.Content;

            var readedContent = await responseContent.ReadAsStringAsync();

            GetCourseDetailsResponse response = null;

            if (!string.IsNullOrEmpty(readedContent))
            {
                response = JsonSerializer.Deserialize<GetCourseDetailsResponse>(readedContent);
            }

            return response;            
        }
    }
}
