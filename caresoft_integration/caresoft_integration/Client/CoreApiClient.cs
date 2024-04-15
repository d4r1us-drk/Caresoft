using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using caresoft_core.Dto;
using System.Text;

namespace caresoft_integration.Client
{
    public class CoreApiClient
    {
        private readonly HttpClient _httpClient;

        public CoreApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7038/");
        }

        // Sucursal
        public async Task<int> CreateSucursalAsync(SucursalDto sucursalDto)
        {
            string json = JsonConvert.SerializeObject(sucursalDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/sucursal", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<List<SucursalDto>> GetSucursalesAsync()
        {
            var response = await _httpClient.GetAsync("api/sucursal");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SucursalDto>>(jsonResponse);
            }
            return new List<SucursalDto>();
        }

        public async Task<int> UpdateSucursalAsync(SucursalDto sucursalDto)
        {
            string json = JsonConvert.SerializeObject(sucursalDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/sucursal/{sucursalDto.IdSucursal}", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteSucursalAsync(uint idSucursal)
        {
            var response = await _httpClient.DeleteAsync($"api/sucursal/{idSucursal}");

            return response.IsSuccessStatusCode ? 1 : 0;
        }
    }
}
