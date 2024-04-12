using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;
using caresoft_core.Context;

namespace caresoft_core.Services;

public class ConsultaService(CaresoftDbContext context) : IConsultaService
{
    private readonly LogHandler<ConsultaService> _logHandler = new();

    public async Task<int> UpdateConsultaAsync(ConsultaDto consulta)
    {
        try
        {
            Consultum result = await context.Consulta.Where(e => e.ConsultaCodigo == consulta.ConsultaCodigo).FirstAsync();
            result.DocumentoPaciente = consulta.DocumentoPaciente;
            result.DocumentoMedico = consulta.DocumentoMedico;
            result.IdConsultorio = consulta.IdConsultorio;
            result.Motivo = consulta.Motivo;
            result.Comentarios = consulta.Comentarios;
            result.Costo = consulta.Costo;
            result.Estado = consulta.Estado;
            await context.SaveChangesAsync();
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
            Consultum consultum = Consultum.FromDto(newConsulta);
            await context.Consulta.AddAsync(consultum);
            await context.SaveChangesAsync();
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
            Consultum result = await context.Consulta.Where(e => e.ConsultaCodigo == consultaCodigo).FirstAsync();
            result.IdAfeccions.Remove(result.IdAfeccions.First(e => e.IdAfeccion == idAfeccion));
            await context.SaveChangesAsync();
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
            Consultum result = await context.Consulta.Where(e => e.ConsultaCodigo == consultaCodigo).FirstAsync();
            bool removed = result.PrescripcionProductos.Remove(result.PrescripcionProductos.First(e => e.IdProducto == idProducto && e.Cantidad == cantidad));
            // Si no se removió nada, entonces no se encontró el producto
            // o la cantidad de productos prescritos de la consulta a eliminar
            // es menor a la cantidad a eliminar
            if (!removed)
            {
                result.PrescripcionProductos.First(e => e.IdProducto == idProducto).Cantidad -= cantidad;
            }
            await context.SaveChangesAsync();
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
            Consultum result = await context.Consulta.Where(e => e.ConsultaCodigo == consultaCodigo).FirstAsync();
            result.ServicioCodigos.Remove(result.ServicioCodigos.First(e => e.ServicioCodigo == servicioCodigo));
            await context.SaveChangesAsync();
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
            context.Consulta.Remove(context.Consulta.First(e => e.ConsultaCodigo == consultaCodigo));
            await context.SaveChangesAsync();
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
            Consultum consultum = await context.Consulta.Where(e => e.ConsultaCodigo == consultaCodigo).Include(e => e.IdAfeccions).FirstAsync();
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
            return (await context.Consulta.ToListAsync()).Select(e => ConsultaDto.FromModel(e)).ToList();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al listar consultas", ex);
            return new List<ConsultaDto>();
        }

    }

    public async Task<List<Producto>> GetConsultaProductosAsync(string consultaCodigo)
    {
        try
        {
            var prescripcionProductos = await context.Consulta
                .Where(e => e.ConsultaCodigo == consultaCodigo)
                .Include(e => e.PrescripcionProductos)
                .SelectMany(e => e.PrescripcionProductos)
                .ToListAsync();
            return prescripcionProductos
                .Select(e => e.IdProductoNavigation)
                .ToList();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al listar productos", ex);
            return new List<Producto>();
        }
    }

    public async Task<List<Servicio>> GetConsultaServiciosAsync(string consultaCodigo)
    {
        try
        {
            List<Servicio> servicios = await context.Consulta
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
            context.Consulta.Where(e => e.ConsultaCodigo == consultaCodigo).First().IdAfeccions.Add(context.Afeccions.First(e => e.IdAfeccion == idAfeccion));
            return await context.SaveChangesAsync();
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
            Consultum consultum = context.Consulta.Where(e => e.ConsultaCodigo == consultaCodigo).First();
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

            return await context.SaveChangesAsync();
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
            context.Consulta
                .Where(e => e.ConsultaCodigo == consultaCodigo)
                .First()
                .ServicioCodigos
                .Add(context.Servicios.First(e => e.ServicioCodigo == servicioCodigo));
            return await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al relacionar servicio", ex);
            return await Task.FromResult(0);
        }
    }
}