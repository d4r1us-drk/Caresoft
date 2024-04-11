using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly CaresoftDbContext _dbContext;
        public ConsultaService(CaresoftDbContext _context)
        {
            _dbContext = _context;
        }

        public async Task<int> ActualizarConsulta(string consultaCodigo, string documentoPaciente, string documentoMedico, uint idConsultorio, string motivo, string comentarios, decimal costo)
        {
            Consulta dbConsulta = await _dbContext.Consultas.Where(e => e.ConsultaCodigo == consultaCodigo).FirstAsync();

            dbConsulta.DocumentoPaciente = documentoPaciente;
            dbConsulta.DocumentoMedico = documentoMedico;
            dbConsulta.IdConsultorio = idConsultorio;
            dbConsulta.Motivo = motivo;
            dbConsulta.Comentarios = comentarios;
            dbConsulta.Costo = costo;

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CrearConsulta(string consultaCodigo, string documentoPaciente, string documentoMedico, uint idConsultorio, string motivo, string comentarios, decimal costo, string estado)
        {
            Consulta newConsulta = new Consulta
            {
                ConsultaCodigo = consultaCodigo,
                DocumentoPaciente = documentoPaciente,
                DocumentoMedico = documentoMedico,
                IdConsultorio = idConsultorio,
                Motivo = motivo,
                Comentarios = comentarios,
                Costo = costo,
                Estado = estado
            };
            await _dbContext.Consultas.AddAsync(newConsulta);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DesrelacionarAfeccion(string consultaCodigo, uint idAfeccion)
        {
            Consulta result = await _dbContext.Consultas.Where(e => e.ConsultaCodigo == consultaCodigo).FirstAsync();
            result.IdAfeccions.Remove(result.IdAfeccions.First(e => e.IdAfeccion == idAfeccion));
            return await _dbContext.SaveChangesAsync();
        }

        public Task<int> DesrelacionarProducto(string consultaCodigo, int idProducto, int cantidad)
        {
            throw new NotImplementedException();
        }

        public Task<int> DesrelacionarServicio(string consultaCodigo, string servicioCodigo)
        {
            throw new NotImplementedException();
        }

        public Task<int> EliminarConsulta(string consultaCodigo)
        {
            throw new NotImplementedException();
        }

        public Task<List<Afeccion>> ListarAfecciones(string consultaCodigo)
        {
            throw new NotImplementedException();
        }

        public Task<List<Consulta>> ListarConsultas(string documentoPaciente, string documentoMedico, DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> ListarProductos(string consultaCodigo)
        {
            throw new NotImplementedException();
        }

        public Task<List<Servicio>> ListarServicios(string consultaCodigo)
        {
            throw new NotImplementedException();
        }

        public Task<int> RelacionarAfeccion(string consultaCodigo, int idAfeccion)
        {
            throw new NotImplementedException();
        }

        public Task<int> RelacionarProducto(string consultaCodigo, int idProducto, int cantidad)
        {
            throw new NotImplementedException();
        }

        public Task<int> RelacionarServicio(string consultaCodigo, string servicioCodigo)
        {
            throw new NotImplementedException();
        }
    }
