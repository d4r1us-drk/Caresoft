using caresoft_integration.Context;
using Microsoft.EntityFrameworkCore;
using caresoft_integration.Dto;
using caresoft_integration.Models;
using Newtonsoft.Json;
using System.Text;

public class FallbackHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly CaresoftDbContext _dbContext;
    private readonly caresoft_integration.CoreAPI.Client API;

    public FallbackHttpClient(HttpClient httpClient, CaresoftDbContext dbContext)
    {
        API = new caresoft_integration.CoreAPI.Client("https://localhost:7038/");
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7038/");
        _dbContext = dbContext;
    }


    // Metodos CRUD Aseguradora
    public async Task<int> CreateAseguradoraAsync(Aseguradora aseguradora)
    {
        try
        {
            return await API.ApiAseguradoraAddAsync((int)aseguradora.IdAseguradora, aseguradora.Nombre, aseguradora.Direccion, aseguradora.Telefono, aseguradora.Correo, []);
        }
        catch (HttpRequestException)
        {
            _dbContext.Aseguradoras.Add(aseguradora);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
    public async Task<List<caresoft_integration.Models.Aseguradora>> GetAseguradorasAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/aseguradora/get");
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var aseguradorasApi = JsonConvert.DeserializeObject<List<caresoft_integration.CoreAPI.Aseguradora>>(jsonResponse);

                // Map the API model to your application's model
                var aseguradoras = aseguradorasApi.Select(a => new caresoft_integration.Models.Aseguradora
                {
                    IdAseguradora = (uint)a.IdAseguradora, // Ensure type conversion here is appropriate
                    Nombre = a.Nombre,
                    Direccion = a.Direccion,
                    Telefono = a.Telefono,
                    Correo = a.Correo
                    // Map other fields as necessary
                }).ToList();

                return aseguradoras;
            }
            throw new HttpRequestException("Failed to retrieve data from core.");
        }
        catch (HttpRequestException)
        {
            return await _dbContext.Aseguradoras.ToListAsync();
        }
    }
    public async Task<int> UpdateAseguradoraAsync(Aseguradora aseguradora)
    {
        try
        {
            // Convertir uint a int de forma segura.
            int idAseguradora = checked((int)aseguradora.IdAseguradora);

            // Llamada al API sin incluir autorizaciones.
            return await API.ApiAseguradoraUpdateAsync(
                idAseguradora,
                aseguradora.Nombre,
                aseguradora.Direccion,
                aseguradora.Telefono,
                aseguradora.Correo,
                aseguradora.Autorizacions);

        }
        catch (OverflowException)
        {
            // Manejar el caso donde el uint es demasiado grande para convertirlo a int.
            Console.WriteLine("Error: El ID de la aseguradora excede el tamaño máximo permitido para un int.");
            return -1; // Podrías retornar un código de error específico.
        }
        catch (HttpRequestException)
        {
            // Fallback a la base de datos local si la llamada al API falla.
            var existingAseguradora = await _dbContext.Aseguradoras.FindAsync(aseguradora.IdAseguradora);
            if (existingAseguradora != null)
            {
                existingAseguradora.Nombre = aseguradora.Nombre;
                existingAseguradora.Direccion = aseguradora.Direccion;
                existingAseguradora.Telefono = aseguradora.Telefono;
                existingAseguradora.Correo = aseguradora.Correo;
                _dbContext.Aseguradoras.Update(existingAseguradora);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
    public async Task<int> DeleteAseguradoraAsync(uint id)
    {
        try
        {
            await API.ApiAseguradoraDeleteAsync((int)id);
            return 1; 
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
            var aseguradora = await _dbContext.Aseguradoras.FindAsync(id);
            if (aseguradora != null)
            {
                _dbContext.Aseguradoras.Remove(aseguradora);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0; 
        }
    }

}
