using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly LogHandler<ConsultaService> _logHandler = new();
        public ConsultaService(CaresoftDbContext _context)
        {
            _dbContext = _context;
        }

        public async Task<int> ActualizarConsulta(ConsultaDto consulta)
        {
            try
            {
                Consulta result = await _dbContext.Consultas.Where(e => e.ConsultaCodigo == consulta.ConsultaCodigo).FirstAsync();
                if(consulta.DocumentoPaciente != null)
                {
                    result.DocumentoPaciente = consulta.DocumentoPaciente;
                }
                if(consulta.DocumentoMedico != null)
                {
                    result.DocumentoMedico = consulta.DocumentoMedico;
                }
                if(consulta.IdConsultorio != null )
                {
                    result.IdConsultorio = (uint)consulta.IdConsultorio;
                }
                if(consulta.Motivo != null)
                {
                    result.Motivo = consulta.Motivo;
                }
                if(consulta.Comentarios != null)
                {
                    result.Comentarios = consulta.Comentarios;
                }
                if(consulta.Costo != null)
                {
                    result.Costo = (uint)consulta.Costo;
                }
                if(consulta.Estado != null)
                {
                    result.Estado = consulta.Estado;
                }
                
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al actualizar consulta", ex);
                return 0;
            }
        }

        public async Task<int> CrearConsulta(Consulta newConsulta)
        {
            try
            {
                await _dbContext.Consultas.AddAsync(newConsulta);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al crear consulta", ex);
                return 0;
            }
        }

        public async Task<int> DesrelacionarAfeccion(string consultaCodigo, uint idAfeccion)
        {
            try
            {
                Consulta result = await _dbContext.Consultas.Where(e => e.ConsultaCodigo == consultaCodigo).FirstAsync();
                result.IdAfeccions.Remove(result.IdAfeccions.First(e => e.IdAfeccion == idAfeccion));
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al desrelacionar afección", ex);
                return 0;
            }
        }

        public async Task<int> DesrelacionarProducto(string consultaCodigo, uint idProducto, int cantidad)
        {
            try
            {
                Consulta result = await _dbContext.Consultas.Where(e => e.ConsultaCodigo == consultaCodigo).FirstAsync();
                bool removed = result.PrescripcionProductos.Remove(result.PrescripcionProductos.First(e => e.IdProducto == idProducto && e.Cantidad == cantidad));
                // Si no se removió nada, entonces no se encontró el producto
                // o la cantidad de productos prescritos de la consulta a eliminar
                // es menor a la cantidad a eliminar
                if (!removed)
                {
                    result.PrescripcionProductos.First(e => e.IdProducto == idProducto).Cantidad -= cantidad;
                }
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al desrelacionar producto", ex);
                return 0;
            }
        }

        public async Task<int> DesrelacionarServicio(string consultaCodigo, string servicioCodigo)
        {
            try
            {
                Consulta result = await _dbContext.Consultas.Where(e => e.ConsultaCodigo == consultaCodigo).FirstAsync();
                result.ServicioCodigos.Remove(result.ServicioCodigos.First(e => e.ServicioCodigo == servicioCodigo));
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al desrelacionar servicio", ex);
                return 0;
            }
        }

        public async Task<int> EliminarConsulta(string consultaCodigo)
        {
            try
            {
                _dbContext.Consultas.Remove(_dbContext.Consultas.First(e => e.ConsultaCodigo == consultaCodigo));
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al eliminar consulta", ex);
                return 0;
            }
        }

        public async Task<List<Afeccion>> ListarAfecciones(string consultaCodigo)
        {
            try
            {
                Consulta consulta = await _dbContext.Consultas.Where(e => e.ConsultaCodigo == consultaCodigo).Include(e => e.IdAfeccions).FirstAsync();
                return consulta.IdAfeccions.ToList();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al listar afecciones", ex);
                return new List<Afeccion>();
            }
        }

        public async Task<List<Consulta>> ListarConsultas(string? documentoPaciente, string? documentoMedico, DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                IQueryable<Consulta> query = _dbContext.Consultas;
                if (documentoPaciente != null)
                {
                    query = query.Where(e => e.DocumentoPaciente == documentoPaciente);
                }
                if (documentoMedico != null)
                {
                    query = query.Where(e => e.DocumentoMedico == documentoMedico);
                }
                if (fechaInicio != null)
                {
                    query = query.Where(e => e.Fecha >= fechaInicio);
                }
                if (fechaFin != null)
                {
                    query = query.Where(e => e.Fecha <= fechaFin);
                }
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al listar consultas", ex);
                return new List<Consulta>();
            }

        }

        public async Task<List<Producto>> ListarProductos(string consultaCodigo)
        {
            try
            {
                var prescripcionProductos = await _dbContext.Consultas
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

        public async Task<List<Servicio>> ListarServicios(string consultaCodigo)
        {
            try
            {
                List<Servicio> servicios = await _dbContext.Consultas
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

        public Task<int> RelacionarAfeccion(string consultaCodigo, uint idAfeccion)
        {
            try
            {
                _dbContext.Consultas.Where(e => e.ConsultaCodigo == consultaCodigo).First().IdAfeccions.Add(_dbContext.Afeccions.First(e => e.IdAfeccion == idAfeccion));
                return _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al relacionar afección", ex);
                return Task.FromResult(0);
            }
        }

        public Task<int> RelacionarProducto(string consultaCodigo, uint idProducto, int cantidad)
        {
            try
            {
                Consulta consulta = _dbContext.Consultas.Where(e => e.ConsultaCodigo == consultaCodigo).First();
                PrescripcionProducto prescripcionProducto = consulta.PrescripcionProductos.FirstOrDefault(e => e.IdProducto == idProducto);
                if (prescripcionProducto == null)
                {
                    consulta.PrescripcionProductos.Add(new PrescripcionProducto
                    {
                        IdProducto = idProducto,
                        Cantidad = cantidad
                    });
                }
                else
                {
                    prescripcionProducto.Cantidad += cantidad;
                }

                return _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al relacionar producto", ex);
                return Task.FromResult(0);
            }

        }

        public Task<int> RelacionarServicio(string consultaCodigo, string servicioCodigo)
        {
            try
            {
                _dbContext.Consultas
                    .Where(e => e.ConsultaCodigo == consultaCodigo)
                    .First()
                    .ServicioCodigos
                    .Add(_dbContext.Servicios.First(e => e.ServicioCodigo == servicioCodigo));
                return _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logHandler.LogError("Error al relacionar servicio", ex);
                return Task.FromResult(0);
            }
        }
    }
}