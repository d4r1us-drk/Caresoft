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

        //  Métodos CRUD para Sucursal
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

        // Métodos CRUD para TipoServicio
        public async Task<int> CreateTipoServicioAsync(TipoServicioDto tipoServicioDto)
        {
            string json = JsonConvert.SerializeObject(tipoServicioDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/tiposervicio/add", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<List<TipoServicioDto>> GetTipoServiciosAsync()
        {
            var response = await _httpClient.GetAsync("api/tiposervicio/get");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TipoServicioDto>>(jsonResponse);
            }
            return new List<TipoServicioDto>();
        }

        public async Task<int> UpdateTipoServicioAsync(TipoServicioDto tipoServicioDto)
        {
            string json = JsonConvert.SerializeObject(tipoServicioDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/tiposervicio/update", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteTipoServicioAsync(uint idTipoServicio)
        {
            var response = await _httpClient.DeleteAsync($"api/tiposervicio/delete/{idTipoServicio}");

            return response.IsSuccessStatusCode ? 1 : 0;
        }


        // Métodos CRUD para Servicio
        public async Task<int> CreateServicioAsync(ServicioDto servicioDto)
        {
            string json = JsonConvert.SerializeObject(servicioDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/servicio/add", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<List<ServicioDto>> GetServiciosAsync()
        {
            var response = await _httpClient.GetAsync("api/servicio/get");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ServicioDto>>(jsonResponse);
            }
            return new List<ServicioDto>();
        }

        public async Task<int> UpdateServicioAsync(ServicioDto servicioDto)
        {
            string json = JsonConvert.SerializeObject(servicioDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/servicio/update/{servicioDto.ServicioCodigo}", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteServicioAsync(string servicioCodigo)
        {
            var response = await _httpClient.DeleteAsync($"api/servicio/delete/{servicioCodigo}");

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        // Métodos CRUD para Sala
        public async Task<int> CreateSalaAsync(SalaDto salaDto)
        {
            string json = JsonConvert.SerializeObject(salaDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/sala", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<List<SalaDto>> GetSalasAsync()
        {
            var response = await _httpClient.GetAsync("api/sala");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SalaDto>>(jsonResponse);
            }
            return new List<SalaDto>();
        }

        public async Task<int> UpdateSalaEstadoAsync(SalaDto salaDto)
        {
            string json = JsonConvert.SerializeObject(salaDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/sala/{salaDto.NumSala}", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteSalaAsync(uint numSala)
        {
            var response = await _httpClient.DeleteAsync($"api/sala/{numSala}");

            return response.IsSuccessStatusCode ? 1 : 0;
        }

    }
}
