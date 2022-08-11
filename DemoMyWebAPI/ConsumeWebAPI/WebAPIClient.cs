using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsumeWebAPI.Models;
using Microsoft.Extensions.Logging;

namespace ConsumeWebAPI
{
    public class WebAPIClient
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly HttpClient client;
        private readonly ILogger<WebAPIClient> _logger;

        public WebAPIClient(HttpClient client, ILogger<WebAPIClient> logger)
        {
            this.client = client;
            this._logger = logger;
        }

        public async Task<CateCarViewModel[]> GetCateCarAsync()
        {
            try
            {
                var responseMessage = await this.client.GetAsync("/LoginViewModel");

                if (responseMessage != null)
                {
                    var stream = await responseMessage.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<CateCarViewModel[]>(stream, options);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            return new CateCarViewModel[] { };

        }
    }
}
