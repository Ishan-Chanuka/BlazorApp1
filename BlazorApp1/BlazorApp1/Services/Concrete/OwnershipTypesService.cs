using BlazorApp1.Models;
using BlazorApp1.ResponseModels;
using BlazorApp1.Services.Interfaces;
using Newtonsoft.Json;

namespace BlazorApp1.Services.Concrete
{
    public class OwnershipTypesService : IOwnershipTypesService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public OwnershipTypesService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _baseUrl = configuration["BaseUrl"]!;
        }

        public async Task<IEnumerable<OwnerShipTypes>> GetOwnershipTypesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/Property/GetOwnerShipTypes");
                
                if ( response is not null )
                {
                    response.EnsureSuccessStatusCode();

                    var ownershipTypesJson = await response.Content.ReadAsStringAsync();
                    var ownershipTypesResponse = JsonConvert.DeserializeObject<OwnershipTypesResponse>(ownershipTypesJson);

                    return ownershipTypesResponse?.Data ?? new List<OwnerShipTypes>();
                }

                return new List<OwnerShipTypes>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
