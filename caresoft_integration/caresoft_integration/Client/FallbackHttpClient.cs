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

    // Métodos CRUD y adicionales para ReservaServicio

    public async Task<List<caresoft_integration.Dto.ReservaServicioDto>> GetReservaServiciosListAsync()
    {
        try
        {
            var reservaServiciosFromApi = await API.ApiReservaServicioGetAsync();
            return reservaServiciosFromApi.Select(r => new caresoft_integration.Dto.ReservaServicioDto
            {
                IdReserva = (uint)r.IdReserva,
                DocumentoPaciente = r.DocumentoPaciente,
                DocumentoMedico = r.DocumentoMedico,
                ServicioCodigo = r.ServicioCodigo,
                FechaReservada = r.FechaReservada.DateTime, 
                Estado = r.Estado
            }).ToList();
        }
        catch (Exception)
        {
            var reservaServicios = await _dbContext.ReservaServicios.ToListAsync();
            return reservaServicios.Select(r => new caresoft_integration.Dto.ReservaServicioDto
            {
                IdReserva = r.IdReserva,
                DocumentoPaciente = r.DocumentoPaciente,
                DocumentoMedico = r.DocumentoMedico,
                ServicioCodigo = r.ServicioCodigo,
                FechaReservada = r.FechaReservada,
                Estado = r.Estado
            }).ToList();
        }
    }
    public async Task<int> AddReservaServicioAsync(caresoft_integration.Dto.ReservaServicioDto reservaServicioDto)
    {
        try
        {
            await API.ApiReservaServicioAddAsync(
                (int?)reservaServicioDto.IdReserva,
                reservaServicioDto.DocumentoPaciente,
                reservaServicioDto.DocumentoMedico,
                reservaServicioDto.ServicioCodigo,
                reservaServicioDto.FechaReservada,
                reservaServicioDto.Estado
            );
            return 1;
        }
        catch (Exception)
        {
            var reservaServicio = new caresoft_integration.Models.ReservaServicio
            {
                IdReserva = reservaServicioDto.IdReserva,
                DocumentoPaciente = reservaServicioDto.DocumentoPaciente,
                DocumentoMedico = reservaServicioDto.DocumentoMedico,
                ServicioCodigo = reservaServicioDto.ServicioCodigo,
                FechaReservada = reservaServicioDto.FechaReservada,
                Estado = reservaServicioDto.Estado
            };
            _dbContext.ReservaServicios.Add(reservaServicio);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
    public async Task<int> UpdateReservaServicioAsync(caresoft_integration.Dto.ReservaServicioDto reservaServicioDto)
    {
        try
        {
            await API.ApiReservaServicioUpdateAsync(
                (int?)reservaServicioDto.IdReserva,
                reservaServicioDto.DocumentoPaciente,
                reservaServicioDto.DocumentoMedico,
                reservaServicioDto.ServicioCodigo,
                reservaServicioDto.FechaReservada,
                reservaServicioDto.Estado
            );
            return 1;
        }
        catch (Exception)
        {
            var reservaServicio = new caresoft_integration.Models.ReservaServicio
            {
                IdReserva = reservaServicioDto.IdReserva,
                DocumentoPaciente = reservaServicioDto.DocumentoPaciente,
                DocumentoMedico = reservaServicioDto.DocumentoMedico,
                ServicioCodigo = reservaServicioDto.ServicioCodigo,
                FechaReservada = reservaServicioDto.FechaReservada,
                Estado = reservaServicioDto.Estado
            };
            _dbContext.ReservaServicios.Update(reservaServicio);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
    public async Task<int> ToggleEstadoReservaServicioAsync(int idReserva)
    {
        try
        {
            await API.ApiReservaServicioToggleStateAsync(idReserva);
            return 1;
        }
        catch (Exception)
        {
            var reservaServicio = await _dbContext.ReservaServicios.FindAsync(idReserva);
            if (reservaServicio != null)
            {
                reservaServicio.Estado = reservaServicio.Estado == "P" ? "R" : "P";
                _dbContext.ReservaServicios.Update(reservaServicio);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
    public async Task<int> DeleteReservaServicioAsync(int idReserva)
    {
        try
        {
            await API.ApiReservaServicioDeleteAsync(idReserva);
            return 1;
        }
        catch (Exception)
        {
            var reservaServicio = await _dbContext.ReservaServicios.FindAsync(idReserva);
            if (reservaServicio != null)
            {
                _dbContext.ReservaServicios.Remove(reservaServicio);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }


    // Metodos CRUD y adicionales para Factura

    public async Task<int> AddFacturaAsync(caresoft_integration.Dto.FacturaDto facturaDto)
    {
        try
        {
            return await API.ApiFacturaAddAsync(
                facturaDto.FacturaCodigo,
                (int?)facturaDto.IdCuenta,
                facturaDto.ConsultaCodigo,
                (int?)facturaDto.IdIngreso,
                (int?)facturaDto.IdSucursal,
                facturaDto.DocumentoCajero,
                (double?)facturaDto.MontoSubtotal,
                (double?)facturaDto.MontoTotal,
                facturaDto.Fecha.ToUniversalTime()
            );
        }
        catch (Exception)
        {
            var factura = new caresoft_integration.Models.Factura
            {
                FacturaCodigo = facturaDto.FacturaCodigo,
                IdCuenta = facturaDto.IdCuenta,
                ConsultaCodigo = facturaDto.ConsultaCodigo,
                IdIngreso = facturaDto.IdIngreso,
                IdSucursal = facturaDto.IdSucursal,
                DocumentoCajero = facturaDto.DocumentoCajero,
                MontoSubtotal = facturaDto.MontoSubtotal,
                MontoTotal = facturaDto.MontoTotal,
                Fecha = facturaDto.Fecha
            };

            _dbContext.Facturas.Add(factura);
            await _dbContext.SaveChangesAsync();
            return 1; 
        }
    }
    public async Task<int> UpdateFacturaAsync(caresoft_integration.Dto.FacturaDto facturaDto)
    {
        try
        {
            return await API.ApiFacturaUpdateAsync(
                facturaDto.FacturaCodigo,
                (int?)facturaDto.IdCuenta,
                facturaDto.ConsultaCodigo,
                (int?)facturaDto.IdIngreso,
                (int?)facturaDto.IdSucursal,
                facturaDto.DocumentoCajero,
                (double?)facturaDto.MontoSubtotal,
                (double?)facturaDto.MontoTotal,
                facturaDto.Fecha.ToUniversalTime()
            );
        }
        catch (Exception)
        {
            var existingFactura = _dbContext.Facturas.FirstOrDefault(f => f.FacturaCodigo == facturaDto.FacturaCodigo);
            if (existingFactura != null)
            {
                // Mapeo de propiedades de FacturaDto a Factura
                existingFactura.IdCuenta = facturaDto.IdCuenta;
                existingFactura.ConsultaCodigo = facturaDto.ConsultaCodigo;
                existingFactura.IdIngreso = facturaDto.IdIngreso;
                existingFactura.IdSucursal = facturaDto.IdSucursal;
                existingFactura.DocumentoCajero = facturaDto.DocumentoCajero;
                existingFactura.MontoSubtotal = facturaDto.MontoSubtotal;
                existingFactura.MontoTotal = facturaDto.MontoTotal;
                existingFactura.Fecha = facturaDto.Fecha;

                _dbContext.Update(existingFactura);
                await _dbContext.SaveChangesAsync();
            }
            return 1;
        }
    }
    public async Task<int> DeleteFacturaAsync(string facturaCodigo)
    {
        try
        {
            return await API.ApiFacturaDeleteAsync(facturaCodigo);
        }
        catch (Exception)
        {
            var facturaToDelete = _dbContext.Facturas.FirstOrDefault(f => f.FacturaCodigo == facturaCodigo);
            if (facturaToDelete != null)
            {
                _dbContext.Facturas.Remove(facturaToDelete);
                await _dbContext.SaveChangesAsync();
            }
            return 1;
        }
    }
    public async Task<List<caresoft_integration.Dto.FacturaDto>> GetFacturasAsync()
    {
        try
        {
            var facturasFromApi = await API.ApiFacturaGetAsync();
            return facturasFromApi.Select(f => new caresoft_integration.Dto.FacturaDto
            {
                FacturaCodigo = f.FacturaCodigo,
                IdCuenta = (uint)f.IdCuenta,
                ConsultaCodigo = f.ConsultaCodigo,
                IdIngreso = (uint?)f.IdIngreso, 
                IdSucursal = (uint)f.IdSucursal, 
                DocumentoCajero = f.DocumentoCajero,
                MontoSubtotal = (decimal)f.MontoSubtotal,
                MontoTotal = (decimal)f.MontoTotal,
                Fecha = f.Fecha.UtcDateTime
            }).ToList();
        }
        catch (Exception)
        {
            var facturas = await _dbContext.Facturas.ToListAsync();
            return facturas.Select(f => new caresoft_integration.Dto.FacturaDto
            {
                FacturaCodigo = f.FacturaCodigo,
                IdCuenta = f.IdCuenta,
                ConsultaCodigo = f.ConsultaCodigo,
                IdIngreso = f.IdIngreso,
                IdSucursal = f.IdSucursal,
                DocumentoCajero = f.DocumentoCajero,
                MontoSubtotal = f.MontoSubtotal,
                MontoTotal = f.MontoTotal,
                Fecha = f.Fecha
            }).ToList();
        }
    }
    public async Task<int> AddFacturaServicioAsync(FacturaServicioDto facturaServicioDto)
    {
        try
        {
            return await API.ApiFacturaAddFacturaServicioAsync(
                facturaServicioDto.FacturaCodigo,
                facturaServicioDto.ServicioCodigo,
                (int?)facturaServicioDto.IdAutorizacion,
                facturaServicioDto.Resultados,
                (double?)facturaServicioDto.Costo
            );
        }
        catch (Exception)
        {
            var facturaServicio = new caresoft_integration.Models.FacturaServicio
            {
                FacturaCodigo = facturaServicioDto.FacturaCodigo,
                ServicioCodigo = facturaServicioDto.ServicioCodigo,
                IdAutorizacion = facturaServicioDto.IdAutorizacion, 
                Resultados = facturaServicioDto.Resultados,
                Costo = (decimal)facturaServicioDto.Costo 
            };

            _dbContext.FacturaServicios.Add(facturaServicio);
            await _dbContext.SaveChangesAsync();
            return 1; 
        }
    }
    public async Task<int> DeleteFacturaServicioAsync(string facturaCodigo, string servicioCodigo)
    {
        try
        {
            return await API.ApiFacturaDeleteFacturaServicioAsync(facturaCodigo, servicioCodigo);
        }
        catch (Exception)
        {
            var facturaServicio = await _dbContext.FacturaServicios
                .FindAsync(facturaCodigo, servicioCodigo);
            if (facturaServicio != null)
            {
                _dbContext.FacturaServicios.Remove(facturaServicio);
                await _dbContext.SaveChangesAsync();
            }
            return 1; 
        }
    }
    public async Task<List<caresoft_integration.Dto.ServicioDto>> GetFacturaServiciosAsync(string facturaCodigo)
    {
        try
        {
            var serviciosFromApi = await API.ApiFacturaGetFacturaServiciosAsync(facturaCodigo);
            return serviciosFromApi.Select(s => new caresoft_integration.Dto.ServicioDto
            {
                ServicioCodigo = s.ServicioCodigo,
                IdTipoServicio = (uint)s.IdTipoServicio,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion,
                Costo = (decimal)s.Costo
            }).ToList();
        }
        catch (Exception)
        {
            var servicios = await _dbContext.Servicios
                .Where(s => s.FacturaServicios.Any(f => f.FacturaCodigo == facturaCodigo)).ToListAsync();
            return servicios.Select(s => new caresoft_integration.Dto.ServicioDto
            {
                ServicioCodigo = s.ServicioCodigo,
                IdTipoServicio = s.IdTipoServicio,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion,
                Costo = s.Costo
            }).ToList();
        }
    }
    public async Task<int> AddFacturaProductoAsync(caresoft_integration.Dto.FacturaProductoDto facturaProductoDto)
    {
        try
        {
            return await API.ApiFacturaAddFacturaProductoAsync(
                facturaProductoDto.FacturaCodigo,
                (int?)facturaProductoDto.IdProducto,
                (int?)facturaProductoDto.IdAutorizacion,
                facturaProductoDto.Resultados,
                (double?)facturaProductoDto.Costo
            );
        }
        catch (Exception)
        {
            var facturaProducto = new caresoft_integration.Models.FacturaProducto
            {
                FacturaCodigo = facturaProductoDto.FacturaCodigo,
                IdProducto = facturaProductoDto.IdProducto,
                IdAutorizacion = facturaProductoDto.IdAutorizacion,
                Resultados = facturaProductoDto.Resultados,
                Costo = facturaProductoDto.Costo
            };

            _dbContext.FacturaProductos.Add(facturaProducto);
            await _dbContext.SaveChangesAsync();
            return 1; 
        }
    }
    public async Task<int> DeleteFacturaProductoAsync(string facturaCodigo, uint idProducto)
    {
        try
        {
            return await API.ApiFacturaDeleteFacturaProductoAsync(facturaCodigo, (int)idProducto);
        }
        catch (Exception)
        {
            var facturaProducto = await _dbContext.FacturaProductos
                .FindAsync(facturaCodigo, idProducto);
            if (facturaProducto != null)
            {
                _dbContext.FacturaProductos.Remove(facturaProducto);
                await _dbContext.SaveChangesAsync();
            }
            return 1; 
        }
    }
    public async Task<List<caresoft_integration.Dto.FacturaProductoDto>> GetFacturaProductosAsync(string facturaCodigo)
    {
        try
        {
            var facturaProductosFromApi = await API.ApiFacturaGetFacturaProductosAsync(facturaCodigo);
            return facturaProductosFromApi.Select(fp => new caresoft_integration.Dto.FacturaProductoDto
            {
                FacturaCodigo = fp.FacturaCodigo,
                IdProducto = (uint)fp.IdProducto,
                IdAutorizacion = (uint?)fp.IdAutorizacion,
                Resultados = fp.Resultados,
                Costo = (decimal)fp.Costo
            }).ToList();
        }
        catch (Exception)
        {
            var facturaProductos = await _dbContext.FacturaProductos
                .Where(fp => fp.FacturaCodigo == facturaCodigo).ToListAsync();
            return facturaProductos.Select(fp => new caresoft_integration.Dto.FacturaProductoDto
            {
                FacturaCodigo = fp.FacturaCodigo,
                IdProducto = fp.IdProducto,
                IdAutorizacion = fp.IdAutorizacion,
                Resultados = fp.Resultados,
                Costo = fp.Costo
            }).ToList();
        }
    }
    public async Task<int> AddFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago)
    {
        try
        {
            return await API.ApiFacturaAddFacturaMetodoPagoAsync(facturaCodigo, (int)idMetodoPago);
        }
        catch (Exception)
        {
            var factura = await _dbContext.Facturas
                            .Include(f => f.IdMetodoPagos) 
                            .FirstOrDefaultAsync(f => f.FacturaCodigo == facturaCodigo);

            if (factura != null)
            {
                var metodoPago = await _dbContext.MetodoPagos.FindAsync(idMetodoPago);
                if (metodoPago == null)
                {
                    metodoPago = new caresoft_integration.Models.MetodoPago
                    {
                        IdMetodoPago = idMetodoPago,
                    };
                    _dbContext.MetodoPagos.Add(metodoPago);
                    await _dbContext.SaveChangesAsync();  
                }
                factura.IdMetodoPagos.Add(metodoPago);
                await _dbContext.SaveChangesAsync();
                return 1;  
            }
            else
            {
                return 0;  
            }
        }
    }
    public async Task<int> DeleteFacturaMetodoPagoAsync(string facturaCodigo, uint idMetodoPago)
    {
        try
        {
            return await API.ApiFacturaDeleteFacturaMetodoPagoAsync(facturaCodigo, (int)idMetodoPago);
        }
        catch (Exception)
        {
            var factura = await _dbContext.Facturas
                .Include(f => f.IdMetodoPagos)
                .FirstOrDefaultAsync(f => f.FacturaCodigo == facturaCodigo);
            if (factura != null)
            {
                var metodoPago = factura.IdMetodoPagos.FirstOrDefault(mp => mp.IdMetodoPago == idMetodoPago);
                if (metodoPago != null)
                {
                    factura.IdMetodoPagos.Remove(metodoPago);
                    await _dbContext.SaveChangesAsync();
                }
            }
            return 1; 
        }
    }
    public async Task<List<caresoft_integration.Dto.MetodoPagoDto>> GetMetodoPagosAsync(string facturaCodigo)
    {
        try
        {
            var metodoPagosFromApi = await API.ApiFacturaGetMetodoPagosAsync(facturaCodigo);
            return metodoPagosFromApi.Select(mp => new caresoft_integration.Dto.MetodoPagoDto
            {
                IdMetodoPago = (uint)mp.IdMetodoPago,
                Nombre = mp.Nombre
            }).ToList();
        }
        catch (Exception)
        {
            var factura = await _dbContext.Facturas
                .Include(f => f.IdMetodoPagos)
                .FirstOrDefaultAsync(f => f.FacturaCodigo == facturaCodigo);
            if (factura != null)
            {
                return factura.IdMetodoPagos.Select(mp => new caresoft_integration.Dto.MetodoPagoDto
                {
                    IdMetodoPago = (uint)mp.IdMetodoPago,
                    Nombre = mp.Nombre
                }).ToList();
            }
            return new List<caresoft_integration.Dto.MetodoPagoDto>();
        }
    }

}
