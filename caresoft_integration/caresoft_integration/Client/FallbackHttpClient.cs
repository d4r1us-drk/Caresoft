using caresoft_integration.Context;
using Microsoft.EntityFrameworkCore;
using caresoft_integration.Dto;
using caresoft_integration.Models;
using Newtonsoft.Json;
using System.Text;
using caresoft_integration.CoreAPI;

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

    // Metodos CRUD Afeccion

    public async Task<int> CreateAfeccionAsync(caresoft_integration.Models.Afeccion afeccion)
    {
        try
        {
            int idAfeccionInt = checked((int)afeccion.IdAfeccion);
            await API.ApiAfeccionAddAsync(idAfeccionInt, afeccion.Nombre, afeccion.Descripcion, [], []);
            return 1;
        }
        catch (Exception)
        {
            _dbContext.Afeccions.Add(afeccion);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
    public async Task<List<caresoft_integration.Models.Afeccion>> GetAfeccionesAsync()
    {
        try
        {
            var afeccionesFromApi = await API.ApiAfeccionGetGetAsync();
            var afeccionesList = new List<caresoft_integration.Models.Afeccion>();

            foreach (var afeccionFromApi in afeccionesFromApi)
            {
                afeccionesList.Add(new caresoft_integration.Models.Afeccion()
                {
                    IdAfeccion = (uint)afeccionFromApi.IdAfeccion,
                    Nombre = afeccionFromApi.Nombre,
                    Descripcion = afeccionFromApi.Descripcion,
                });
            }

            return afeccionesList;
        }
        catch (Exception)
        {
            return await _dbContext.Afeccions.ToListAsync();
        }
    }
    public async Task<caresoft_integration.Models.Afeccion> GetAfeccionByIdAsync(int id)
    {
        try
        {
            var coreAfeccion = await API.ApiAfeccionGetGetAsync(id);

            var modelAfeccion = new caresoft_integration.Models.Afeccion
            {
                IdAfeccion = (uint)coreAfeccion.IdAfeccion,
                Nombre = coreAfeccion.Nombre,
                Descripcion = coreAfeccion.Descripcion
            };

            return modelAfeccion;
        }
        catch (ApiException ex)
        {
            return await _dbContext.Afeccions.FindAsync(id);
        }
    }
    public async Task<int> UpdateAfeccionAsync(caresoft_integration.Models.Afeccion afeccion)
    {
        try
        {
            int idAfeccionInt = checked((int)afeccion.IdAfeccion);

            await API.ApiAfeccionUpdateAsync(idAfeccionInt, afeccion.Nombre, afeccion.Descripcion, [], []);
            return 1;
        }
        catch (Exception)
        {
            _dbContext.Afeccions.Update(afeccion);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
    public async Task<int> DeleteAfeccionAsync(uint id)
    {
        try
        {
            await API.ApiAfeccionDeleteAsync((int)id);
            return 1;
        }
        catch (Exception)
        {
            var afeccion = await _dbContext.Afeccions.FindAsync(id);
            if (afeccion != null)
            {
                _dbContext.Afeccions.Remove(afeccion);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }

    // Metodos CRUD Aseguradora

    public async Task<int> CreateAseguradoraAsync(caresoft_integration.Models.Aseguradora aseguradora)
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

                var aseguradoras = aseguradorasApi.Select(a => new caresoft_integration.Models.Aseguradora
                {
                    IdAseguradora = (uint)a.IdAseguradora, 
                    Nombre = a.Nombre,
                    Direccion = a.Direccion,
                    Telefono = a.Telefono,
                    Correo = a.Correo
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
    public async Task<int> UpdateAseguradoraAsync(caresoft_integration.Models.Aseguradora aseguradora)
    {
        try
        {
            int idAseguradora = checked((int)aseguradora.IdAseguradora);
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
            Console.WriteLine("Error: El ID de la aseguradora excede el tamaño máximo permitido para un int.");
            return -1; 
        }
        catch (HttpRequestException)
        {
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
            if (aseguradora == null)
            {
                Console.WriteLine("No se encontró la aseguradora con ID: " + id);
                return 0;
            }
            _dbContext.Aseguradoras.Remove(aseguradora);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }

    // Metodos CRUD  Autorizacion

    public async Task<int> CreateAutorizacionAsync(caresoft_integration.Models.Autorizacion autorizacion, caresoft_integration.Models.Aseguradora aseguradora)
    {
        try
        {
            int idAutorizacion = checked((int)autorizacion.IdAutorizacion);
            int idAseguradora = checked((int)aseguradora.IdAseguradora);
            await API.ApiAutorizacionAddAsync(idAutorizacion, idAseguradora, autorizacion.Fecha, (double?)autorizacion.MontoAsegurado, null, null, null, null, null);
            return 1;
        }
        catch (Exception)
        {
            _dbContext.Autorizacions.Add(autorizacion);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
    public async Task<caresoft_integration.Models.Autorizacion> GetAutorizacionByIdAsync(uint id)
    {
        try
        {
            var autorizacionDto = await API.ApiAutorizacionGetGetAsync((int)id);
            if (autorizacionDto == null)
            {
                throw new KeyNotFoundException("Autorizacion not found with API.");
            }

            var autorizacion = new caresoft_integration.Models.Autorizacion
            {
                IdAutorizacion = (uint)autorizacionDto.IdAutorizacion,
            };

            return autorizacion;
        }
        catch (Exception)
        {
            var autorizacion = await _dbContext.Autorizacions.FindAsync(id);
            if (autorizacion == null)
            {
                throw new KeyNotFoundException("Autorizacion not found in local DB either.");
            }
            return autorizacion;
        }
    }
    public async Task<int> UpdateAutorizacionAsync(caresoft_integration.Models.Autorizacion autorizacion, caresoft_integration.Models.Aseguradora aseguradora)
    {
        try
        {
            int idAutorizacion = checked((int)autorizacion.IdAutorizacion);
            int idAseguradora = checked((int)aseguradora.IdAseguradora);

            await API.ApiAutorizacionUpdateAsync(idAutorizacion, idAseguradora, autorizacion.Fecha, (double?)autorizacion.MontoAsegurado);
            return 1;
        }
        catch (Exception)
        {
            _dbContext.Autorizacions.Update(autorizacion);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
    public async Task<int> DeleteAutorizacionAsync(uint id)
    {
        try
        {
            await API.ApiAutorizacionDeleteAsync((int)id);
            return 1;
        }
        catch (Exception)
        {
            var autorizacion = await _dbContext.Autorizacions.FindAsync(id);
            if (autorizacion != null)
            {
                _dbContext.Autorizacions.Remove(autorizacion);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
    public async Task<caresoft_integration.Models.Autorizacion> GetAutorizacionByIdAsync(int id)
    {
        try
        {
            // Make an API call to retrieve the Autorizacion by ID.
            var coreAutorizacion = await API.ApiAutorizacionGetGetAsync(id);

            // Map the API Autorizacion to the local Autorizacion model.
            var modelAutorizacion = new caresoft_integration.Models.Autorizacion
            {
                IdAutorizacion = (uint)coreAutorizacion.IdAutorizacion,
                IdAseguradora = (uint)coreAutorizacion.IdAseguradora, 
            };

            return modelAutorizacion;
        }
        catch (ApiException ex)
        {
            // If the API call fails, fallback to the local database.
            var autorizacion = await _dbContext.Autorizacions.FindAsync((uint)id);
            return autorizacion ?? throw new InvalidOperationException($"No autorizacion found with ID {id}.");
        }
    }
    public async Task<List<caresoft_integration.Dto.AutorizacionDto>> GetAllAutorizacionesAsync()
    {
        try
        {
            var autorizacionesFromApi = await API.ApiAutorizacionGetGetAsync();
            var autorizacionesDtoList = autorizacionesFromApi.Select(a => new caresoft_integration.Dto.AutorizacionDto
            {
                IdAutorizacion = (uint)a.IdAutorizacion,
                IdAseguradora = (uint)a.IdAseguradora, // Asumiendo que tienes un campo de ID de aseguradora.
                Fecha = a.FechaAutorizacion, // Asumiendo que tienes un campo de fecha.
                MontoAsegurado = (decimal)a.MontoAsegurado, // Asumiendo que tienes un campo para el monto de cobertura.
            }).ToList();

            return autorizacionesDtoList;
        }
        catch (Exception)
        {
            // Fallback a la base de datos local si la llamada al API falla.
            var autorizaciones = await _dbContext.Autorizacions.ToListAsync();
            return autorizaciones.Select(a => caresoft_integration.Dto.AutorizacionDto.FromAutorizacion(a)).ToList();
        }
    }

    // Métodos CRUD y adicionales para Usuario

    public async Task<List<caresoft_integration.Dto.UsuarioDto>> GetUsuariosListAsync()
    {
        try
        {
            var usuariosFromApi = await API.ApiUsuarioListAsync();
            var usuariosDtoList = usuariosFromApi.Select(apiDto => new caresoft_integration.Dto.UsuarioDto
            {
                UsuarioCodigo = apiDto.UsuarioCodigo,
                Documento = apiDto.Documento,
                UsuarioContra = apiDto.UsuarioContra,
                TipoDocumento = apiDto.TipoDocumento,
                NumLicenciaMedica = (uint?)apiDto.NumLicenciaMedica,
                Nombre = apiDto.Nombre,
                Apellido = apiDto.Apellido,
                Genero = apiDto.Genero,
                FechaNacimiento = apiDto.FechaNacimiento.UtcDateTime,
                Telefono = apiDto.Telefono,
                Correo = apiDto.Correo,
                Direccion = apiDto.Direccion,
                Rol = apiDto.Rol

               
            }).ToList();

            return usuariosDtoList;
        }
        catch (Exception)
        {
            // Recurso de respaldo a la base de datos local
            var usuarios = await _dbContext.Usuarios.ToListAsync();
            return usuarios.Select(u => caresoft_integration.Dto.UsuarioDto.FromModel(u)).ToList();
        }
    }

    public async Task<caresoft_integration.Dto.UsuarioDto?> GetUsuarioByIdAsync(string id)
    {
        try
        {
            var usuarioFromApi = await API.ApiUsuarioGetAsync(id);
            var usuarioDto = new caresoft_integration.Dto.UsuarioDto
            {
                UsuarioCodigo = usuarioFromApi.UsuarioCodigo,
                Documento = usuarioFromApi.Documento,
                UsuarioContra = usuarioFromApi.UsuarioContra,
                TipoDocumento = usuarioFromApi.TipoDocumento,
                NumLicenciaMedica = (uint?)usuarioFromApi.NumLicenciaMedica,
                Nombre = usuarioFromApi.Nombre,
                Apellido = usuarioFromApi.Apellido,
                Genero = usuarioFromApi.Genero,
                FechaNacimiento = usuarioFromApi.FechaNacimiento.UtcDateTime,
                Telefono = usuarioFromApi.Telefono,
                Correo = usuarioFromApi.Correo,
                Direccion = usuarioFromApi.Direccion,
                Rol = usuarioFromApi.Rol
            };

            return usuarioDto;
        }
        catch (Exception)
        {
            var usuario = await _dbContext.Usuarios
                .Include(u => u.DocumentoUsuarioNavigation)
                .FirstOrDefaultAsync(u => u.UsuarioCodigo == id);

            return usuario != null ? caresoft_integration.Dto.UsuarioDto.FromModel(usuario) : null;
        }
    }

    public async Task<int> AddUsuarioAsync(caresoft_integration.Dto.UsuarioDto usuarioDto)
    {
        try
        {
            await API.ApiUsuarioAddAsync(
                usuarioDto.UsuarioCodigo,
                usuarioDto.Documento,
                usuarioDto.UsuarioContra,
                usuarioDto.TipoDocumento,
                usuarioDto.NumLicenciaMedica.HasValue ? Convert.ToInt32(usuarioDto.NumLicenciaMedica.Value) : (int?)null,
                usuarioDto.Nombre,
                usuarioDto.Apellido,
                usuarioDto.Genero,
                usuarioDto.FechaNacimiento,
                usuarioDto.Telefono,
                usuarioDto.Correo,
                usuarioDto.Direccion,
                usuarioDto.Rol
            );
            return 1;
        }
        catch (Exception)
        {
            var usuario = caresoft_integration.Models.Usuario.FromDto(usuarioDto);
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }

    public async Task<int> UpdateUsuarioAsync(caresoft_integration.Dto.UsuarioDto usuarioDto)
    {
        try
        {
            await API.ApiUsuarioUpdateAsync(
                    usuarioDto.UsuarioCodigo,
                    usuarioDto.Documento,
                    usuarioDto.UsuarioContra,
                    usuarioDto.TipoDocumento,
                    usuarioDto.NumLicenciaMedica.HasValue ? Convert.ToInt32(usuarioDto.NumLicenciaMedica.Value) : (int?)null,
                    usuarioDto.Nombre,
                    usuarioDto.Apellido,
                    usuarioDto.Genero,
                    usuarioDto.FechaNacimiento,
                    usuarioDto.Telefono,
                    usuarioDto.Correo,
                    usuarioDto.Direccion,
                    usuarioDto.Rol
            );
            return 1;
        }
        catch (Exception)
        {
            var usuario = caresoft_integration.Models.Usuario.FromDto(usuarioDto);
            _dbContext.Usuarios.Update(usuario);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }

    public async Task<int> DeleteUsuarioAsync(string codigoOdocumento)
    {
        try
        {
            // Llamada a la API para eliminar un usuario
            await API.ApiUsuarioDeleteAsync(codigoOdocumento);
            return 1;
        }
        catch (Exception)
        {
            // Buscar y eliminar el usuario en la base de datos local
            var usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.UsuarioCodigo == codigoOdocumento || u.DocumentoUsuario == codigoOdocumento);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }

    public async Task<int> ToggleUsuarioCuentaAsync(string codigoOdocumento)
    {
        try
        {
            return await API.ApiUsuarioToggleStateCuentaAsync(codigoOdocumento);
        }
        catch (Exception)
        {
            var cuenta = await _dbContext.Cuenta
                .FirstOrDefaultAsync(c => c.DocumentoUsuario == codigoOdocumento);
            if (cuenta != null)
            {
                cuenta.Estado = cuenta.Estado == "A" ? "D" : "A";
                _dbContext.Cuenta.Update(cuenta);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }

    public async Task<caresoft_integration.Dto.CuentumDto?> GetCuentaByUsuarioCodigoOrDocumentoAsync(string codigoOdocumento)
    {
        try
        {
            var cuentaDto = await API.ApiUsuarioCuentaAsync(codigoOdocumento);
            return new caresoft_integration.Dto.CuentumDto
            {
                IdCuenta = (uint)cuentaDto.IdCuenta,
                Balance = (decimal)cuentaDto.Balance,
                Estado = cuentaDto.Estado
            };
        }
        catch (Exception)
        {
            var cuenta = await _dbContext.Cuenta
                .FirstOrDefaultAsync(c => c.DocumentoUsuario == codigoOdocumento);
            return cuenta != null ? caresoft_integration.Dto.CuentumDto.FromModel(cuenta) : null;
        }
    }



}
