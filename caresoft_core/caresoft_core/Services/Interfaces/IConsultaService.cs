using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces;

public interface IConsultaService
{
    int CrearConsulta(string consultaCodigo, string documentoPaciente, string documentoMedico, int idConsultorio, string motivo, string comentarios, decimal costo, string estado);
    int ActualizarConsulta(string consultaCodigo, string documentoPaciente, string documentoMedico, int idConsultorio, string motivo, string comentarios, decimal costo);
    int EliminarConsulta(string consultaCodigo);
    int RelacionarServicio(string consultaCodigo, string servicioCodigo);
    int DesrelacionarServicio(string consultaCodigo, string servicioCodigo);
    List<Servicio> ListarServicios(string consultaCodigo);
    int RelacionarProducto(string consultaCodigo, int idProducto, int cantidad);
    int DesrelacionarProducto(string consultaCodigo, int idProducto, int cantidad);
    List<Producto> ListarProductos(string consultaCodigo);
    int RelacionarAfeccion(string consultaCodigo, int idAfeccion);
    int DesrelacionarAfeccion(string consultaCodigo, int idAfeccion);
    List<Afeccion> ListarAfecciones(string consultaCodigo);
    List<Consulta> ListarConsultas(string documentoPaciente, string documentoMedico, DateTime fechaInicio, DateTime fechaFin);
}