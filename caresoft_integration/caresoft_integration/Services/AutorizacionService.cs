using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Utils;
using caresoft_integration.Context;
using Microsoft.EntityFrameworkCore;

namespace caresoft_integration.Services;

public class AutorizacionService(CaresoftDbContext dbContext) : IAutorizacionService
{
    private readonly LogHandler<AutorizacionService> _logHandler = new();

    public async Task<Autorizacion?> GetAutorizacionById(uint idAutorizacion)
    {
        try
        {
            return await dbContext.Autorizacions.FindAsync(idAutorizacion);
        }
        catch(Exception ex)
        {
            _logHandler.LogError("Error al obtener autorizacion", ex);
            throw;
        }

    }

    public async Task<int> AddAutorizacion(Autorizacion autorizacion,
        int? idIngreso,
        string? consultaCodigo,
        string? facturaCodigo,
        string? servicioCodigo,
        int? idProducto)
    {
        try
        {
            if (AutorizacionExists(autorizacion.IdAutorizacion))
                throw new ArgumentException("La autorizacion existe");

            dbContext.Autorizacions.Add(autorizacion);
            await dbContext.SaveChangesAsync();

            if (idIngreso != null)
            {
                var ingreso = await dbContext.Ingresos.FindAsync(idIngreso);

                if (ingreso == null)
                    throw new ArgumentException("El ingreso provisto no existe");

                ingreso.IdAutorizacion = autorizacion.IdAutorizacion;
                dbContext.Entry(ingreso).State = EntityState.Modified;
            }

            if (!string.IsNullOrEmpty(consultaCodigo))
            {
                var consulta = await dbContext.Consulta.SingleOrDefaultAsync(c => c.ConsultaCodigo == consultaCodigo);

                if (consulta == null)
                    throw new ArgumentException("La consulta provist no existe");

                consulta.IdAutorizacion = autorizacion.IdAutorizacion;
                dbContext.Entry(consulta).State = EntityState.Modified;
            }

            if (!string.IsNullOrEmpty(servicioCodigo) && !string.IsNullOrEmpty(facturaCodigo))
            {
                var facturaServicio = await dbContext.FacturaServicios.SingleOrDefaultAsync(fs => fs.ServicioCodigo == servicioCodigo && fs.FacturaCodigo == facturaCodigo);

                if (facturaServicio == null)
                    throw new ArgumentException("El servicio facturado provisto no existe");

                facturaServicio.IdAutorizacion = autorizacion.IdAutorizacion;
                dbContext.Entry(facturaServicio).State = EntityState.Modified;
            }

            if (idProducto != null && !string.IsNullOrEmpty(facturaCodigo))
            {
                var facturaProducto = await dbContext.FacturaProductos.SingleOrDefaultAsync(fp => fp.IdProducto == idProducto && fp.FacturaCodigo == facturaCodigo);

                if (facturaProducto == null)
                    throw new ArgumentException("El producto facturado provisto no existe");

                facturaProducto.IdAutorizacion = autorizacion.IdAutorizacion;
                dbContext.Entry(facturaProducto).State = EntityState.Modified;
            }

            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogError("Error al crear autorizacion", ex);
            throw;
        }
    }

    public async Task<int> UpdateAutorizacionAsync(Autorizacion autorizacion)
    {
        dbContext.Entry(autorizacion).State = EntityState.Modified;

        try
        {
            await dbContext.SaveChangesAsync();
            return 1;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AutorizacionExists(autorizacion.IdAutorizacion))
            {
                return 0;
            }
            throw;
        }

    }

    public async Task<int> DeleteAutorizacionAsync(uint idAutorizacion)
    {
        try
        {
            var autorizacion = await dbContext.Autorizacions.FindAsync(idAutorizacion);
            if (autorizacion == null)
            {
                return 0;
            }

            dbContext.Autorizacions.Remove(autorizacion);
            await dbContext.SaveChangesAsync();

            return 1;
        }
        catch(Exception ex)
        {
            _logHandler.LogError("Error al eliminar autorizacion", ex);
            throw;
        }

    }

    public async Task<List<Autorizacion>> GetAutorizaciones()
    {
        try
        {
            return await dbContext.Autorizacions.ToListAsync();
        }
        catch(Exception ex)
        {
            _logHandler.LogError("Error al listar autorizaciones", ex);
            throw;
        }
    }

    private bool AutorizacionExists(uint id)
    {
        return dbContext.Autorizacions.Any(e => e.IdAutorizacion == id);
    }
}