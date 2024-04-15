using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using caresoft_core.Dto;
using System.Text;
using caresoft_core.Models;

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
            var response = await _httpClient.PostAsync("api/sala/add", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<List<SalaDto>> GetSalasAsync()
        {
            var response = await _httpClient.GetAsync("api/sala/get");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SalaDto>>(jsonResponse);
            }
            return new List<SalaDto>();
        }

        public async Task<int> UpdateSalaEstadoAsync(uint numSala, string nuevoEstado)
        {
            string json = JsonConvert.SerializeObject(new { NumSala = numSala, Estado = nuevoEstado });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/sala/update/{numSala}", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteSalaAsync(uint numSala)
        {
            var response = await _httpClient.DeleteAsync($"api/sala/delete/{numSala}");

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        // Método CRUD para Reserva
        public async Task<int> AddReservaServicioAsync(ReservaServicioDto reserva)
        {
            string json = JsonConvert.SerializeObject(reserva);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/reservaServicio/add", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<List<ReservaServicioDto>> GetReservaServiciosListAsync()
        {
            var response = await _httpClient.GetAsync("api/reservaServicio/get");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ReservaServicioDto>>(jsonResponse);
            }
            return new List<ReservaServicioDto>();
        }

        public async Task<int> UpdateReservaServicioAsync(ReservaServicioDto reserva)
        {
            string json = JsonConvert.SerializeObject(reserva);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/reservaServicio/update", content);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> ToggleEstadoReservaServicioAsync(uint idReserva)
        {
            var response = await _httpClient.PutAsync($"api/reservaServicio/toggle-state/{idReserva}", null);

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteReservaServicioAsync(uint idReserva)
        {
            var response = await _httpClient.DeleteAsync($"api/reservaServicio/delete/{idReserva}");

            return response.IsSuccessStatusCode ? 1 : 0;
        }

        // Método CRUD para Proveedor
        public async Task<IEnumerable<ProveedorDto>> GetProveedoresAsync()
        {
            var response = await _httpClient.GetAsync("api/proveedor/get");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ProveedorDto>>(jsonResponse);
            }
            return new List<ProveedorDto>();
        }

        public async Task<ProveedorDto> GetProveedorByIdAsync(uint rncProveedor)
        {
            var response = await _httpClient.GetAsync($"api/proveedor/get/{rncProveedor}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProveedorDto>(jsonResponse);
            }
            return null;
        }

        public async Task<int> CreateProveedorAsync(ProveedorDto proveedorDto)
        {
            string json = JsonConvert.SerializeObject(proveedorDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/proveedor/add", content);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateProveedorAsync(ProveedorDto proveedorDto)
        {
            string json = JsonConvert.SerializeObject(proveedorDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/proveedor/update/{proveedorDto.RncProveedor}", content);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteProveedorAsync(uint rncProveedor)
        {
            var response = await _httpClient.DeleteAsync($"api/proveedor/delete/{rncProveedor}");
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        // Método CRUD para Usuario
        public async Task<UsuarioDto?> GetUsuarioByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/usuario/get/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UsuarioDto>(jsonResponse);
            }
            return null;
        }

        public async Task<List<UsuarioDto>> GetUsuariosListAsync()
        {
            var response = await _httpClient.GetAsync("api/usuario/list");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<UsuarioDto>>(jsonResponse);
            }
            return new List<UsuarioDto>();
        }

        public async Task<int> AddUsuarioAsync(UsuarioDto usuario)
        {
            string json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/usuario/add", content);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateUsuarioAsync(UsuarioDto usuario)
        {
            string json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/usuario/update", content);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteUsuarioAsync(string codigoOdocumento)
        {
            var response = await _httpClient.DeleteAsync($"api/usuario/delete/{codigoOdocumento}");
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> ToggleUsuarioCuentaAsync(string codigoOdocumento)
        {
            var response = await _httpClient.PutAsync($"api/usuario/toggle-state-cuenta/{codigoOdocumento}", null);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<CuentumDto?> GetCuentaByUsuarioCodigoOrDocumentoAsync(string codigoOdocumento)
        {
            var response = await _httpClient.GetAsync($"api/usuario/cuenta/{codigoOdocumento}");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CuentumDto>(jsonResponse);
            }
            return null;
        }


    }
}
