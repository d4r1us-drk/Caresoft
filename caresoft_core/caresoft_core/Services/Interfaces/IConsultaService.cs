using caresoft_core.Models;
using caresoft_core.Dto;

namespace caresoft_core.Services.Interfaces;

public interface IConsultaService
{
    Task<int> CrearConsulta(Consulta consulta);
    Task<int> ActualizarConsulta(ConsultaDto consulta);
    Task<int> EliminarConsulta(string consultaCodigo);
    Task<int> RelacionarServicio(string consultaCodigo, string servicioCodigo);
    Task<int> DesrelacionarServicio(string consultaCodigo, string servicioCodigo);
    Task<List<Servicio>> ListarServicios(string consultaCodigo);
    Task<int> RelacionarProducto(string consultaCodigo, uint idProducto, int cantidad);
    Task<int> DesrelacionarProducto(string consultaCodigo, uint idProducto, int cantidad);
    Task<List<Producto>> ListarProductos(string consultaCodigo);
    Task<int> RelacionarAfeccion(string consultaCodigo, uint idAfeccion);
    Task<int> DesrelacionarAfeccion(string consultaCodigo, uint idAfeccion);
    Task<List<Afeccion>> ListarAfecciones(string consultaCodigo);
    Task<List<Consulta>> ListarConsultas(string? documentoPaciente, string? documentoMedico, DateTime? fechaInicio, DateTime? fechaFin);
}
