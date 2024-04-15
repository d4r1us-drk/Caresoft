using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;
using caresoft_core.Context;

namespace caresoft_core.Services;

public class ConsultaService(CaresoftDbContext _dbContext) : IConsultaService
{
    private readonly LogHandler<ConsultaService> _logHandler = new();

    public async Task<int> UpdateConsultaAsync(ConsultaDto consulta)
    {
        try
        {
            var result = await _dbContext.Consulta.Where(e => e.ConsultaCodigo == consulta.ConsultaCodigo).FirstAsync();
            result.DocumentoPaciente = consulta.DocumentoPaciente;
            result.DocumentoMedico = consulta.DocumentoMedico;
            result.IdConsultorio = consulta.IdConsultorio;
            result.Motivo = consulta.Motivo;
            result.Comentarios = consulta.Comentarios;
            result.Costo = consulta.Costo;
            result.Estado = consulta.Estado;
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al actualizar consulta", ex);
            return 0;
        }
    }

    public async Task<int> AddConsultaAsync(ConsultaDto newConsulta)
    {
        try
        {
            var consultum = Consultum.FromDto(newConsulta);
            await _dbContext.Consulta.AddAsync(consultum);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al crear consulta", ex);
            return 0 ;
        }
    }

    public async Task<int> RemoveConsultaAfeccionAsync(string consultaCodigo, uint idAfeccion)
    {
        try
        {
            var result = await _dbContext.Consulta.Where(e => e.ConsultaCodigo == consultaCodigo)
                .Include(consultum => consultum.IdAfeccions).FirstAsync();
            result.IdAfeccions.Remove(result.IdAfeccions.First(e => e.IdAfeccion == idAfeccion));
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al desrelacionar afección", ex);
            return 0;
        }
    }

    public async Task<int> RemoveConsultaProductoAsync(string consultaCodigo, uint idProducto, int cantidad)
    {
        try
        {
            var result = await _dbContext.Consulta.Where(e => e.ConsultaCodigo == consultaCodigo)
                .Include(consultum => consultum.PrescripcionProductos).FirstAsync();
            var removed = result.PrescripcionProductos.Remove(result.PrescripcionProductos.First(e => e.IdProducto == idProducto && e.Cantidad == cantidad));
            // Si no se removió nada, entonces no se encontró el producto
            // o la cantidad de productos prescritos de la consulta a eliminar
            // es menor a la cantidad a eliminar
            if (!removed)
            {
                result.PrescripcionProductos.First(e => e.IdProducto == idProducto).Cantidad -= cantidad;
            }
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al desrelacionar producto", ex);
            return 0;
        }
    }

    public async Task<int> RemoveConsultaServicioAsync(string consultaCodigo, string servicioCodigo)
    {
        try
        {
            var result = await _dbContext.Consulta.Where(e => e.ConsultaCodigo == consultaCodigo)
                .Include(consultum => consultum.ServicioCodigos).FirstAsync();
            result.ServicioCodigos.Remove(result.ServicioCodigos.First(e => e.ServicioCodigo == servicioCodigo));
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al desrelacionar servicio", ex);
            return 0;
        }
    }

    public async Task<int> RemoveConsultaAsync(string consultaCodigo)
    {
        try
        {
            _dbContext.Consulta.Remove(_dbContext.Consulta.First(e => e.ConsultaCodigo == consultaCodigo));
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al eliminar consulta", ex);
            return 0;
        }
    }

    public async Task<List<Afeccion>> GetConsultaAfeccionesAsync(string consultaCodigo)
    {
        try
        {
            var consultum = await _dbContext.Consulta.Where(e => e.ConsultaCodigo == consultaCodigo).Include(e => e.IdAfeccions).FirstAsync();
            return consultum.IdAfeccions.ToList();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al listar afecciones", ex);
            return new List<Afeccion>();
        }
    }

    public async Task<List<ConsultaDto>> GetConsultasAsync()
    {
        try
        {
            return (await _dbContext.Consulta.ToListAsync()).Select(e => ConsultaDto.FromModel(e)).ToList();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al listar consultas", ex);
            return new List<ConsultaDto>();
        }

    }

    public async Task<List<ProductoDto>> GetConsultaProductosAsync(string consultaCodigo)
    {
        try
        {
            var prescripcionProductos = await _dbContext.Consulta
                .Where(e => e.ConsultaCodigo == consultaCodigo)
                .Include(e => e.PrescripcionProductos)
                .SelectMany(e => e.PrescripcionProductos)
                .ToListAsync();

            // Map Producto to ProductoDto
            var productosDto = prescripcionProductos
                .Select(e => ProductoDto.FromModel(e.IdProductoNavigation))
                .ToList();

            return productosDto;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al listar productos", ex);
            return new List<ProductoDto>();
        }
    }

    public async Task<List<Servicio>> GetConsultaServiciosAsync(string consultaCodigo)
    {
        try
        {
            List<Servicio> servicios = await _dbContext.Consulta
                .Where(e => e.ConsultaCodigo == consultaCodigo)
                .Include(e => e.ServicioCodigos)
                .SelectMany(e => e.ServicioCodigos)
                .ToListAsync();
            return servicios;
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al listar servicios", ex);
            return new List<Servicio>();
        }
    }

    public async Task<int> AddConsultaAfeccionAsync(string consultaCodigo, uint idAfeccion)
    {
        try
        {
            _dbContext.Consulta.First(e => e.ConsultaCodigo == consultaCodigo).IdAfeccions.Add(_dbContext.Afeccions.First(e => e.IdAfeccion == idAfeccion));
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al relacionar afección", ex);
            return await Task.FromResult(0);
        }
    }

    public async Task<int> AddConsultaProductoAsync(string consultaCodigo, uint idProducto, int cantidad)
    {
        try
        {
            Consultum consultum = _dbContext.Consulta.Include(consultum => consultum.PrescripcionProductos).First(e => e.ConsultaCodigo == consultaCodigo);
            PrescripcionProducto? prescripcionProducto = consultum.PrescripcionProductos.FirstOrDefault(e => e.IdProducto == idProducto);
            if (prescripcionProducto == null)
            {
                consultum.PrescripcionProductos.Add(new PrescripcionProducto
                {
                    IdProducto = idProducto,
                    Cantidad = cantidad
                });
            }
            else
            {
                prescripcionProducto.Cantidad += cantidad;
            }

            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al relacionar producto", ex);
            return await Task.FromResult(0);
        }

    }

    public async Task<int> AddConsultaServicioAsync(string consultaCodigo, string servicioCodigo)
    {
        try
        {
            _dbContext.Consulta
                .First(e => e.ConsultaCodigo == consultaCodigo)
                .ServicioCodigos
                .Add(_dbContext.Servicios.First(e => e.ServicioCodigo == servicioCodigo));
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al relacionar servicio", ex);
            return await Task.FromResult(0);
        }
    }
}