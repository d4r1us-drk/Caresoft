using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces;

public interface IConsultaService
{
    Task<int> CrearConsulta(string consultaCodigo, string documentoPaciente, string documentoMedico, int idConsultorio, string motivo, string comentarios, decimal costo, string estado);
    Task<int> ActualizarConsulta(string consultaCodigo, string documentoPaciente, string documentoMedico, int idConsultorio, string motivo, string comentarios, decimal costo);
    Task<int> EliminarConsulta(string consultaCodigo);
    Task<int> RelacionarServicio(string consultaCodigo, string servicioCodigo);
    Task<int> DesrelacionarServicio(string consultaCodigo, string servicioCodigo);
    Task<List<Servicio>> ListarServicios(string consultaCodigo);
    Task<int> RelacionarProducto(string consultaCodigo, int idProducto, int cantidad);
    Task<int> DesrelacionarProducto(string consultaCodigo, int idProducto, int cantidad);
    Task<List<Producto>> ListarProductos(string consultaCodigo);
    Task<int> RelacionarAfeccion(string consultaCodigo, int idAfeccion);
    Task<int> DesrelacionarAfeccion(string consultaCodigo, int idAfeccion);
    Task<List<Afeccion>> ListarAfecciones(string consultaCodigo);
    Task<List<Consulta>> ListarConsultas(string documentoPaciente, string documentoMedico, DateTime fechaInicio, DateTime fechaFin);
}