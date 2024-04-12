using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces
{
    public interface IAutorizacionService
    {
        Task<Autorizacion?> GetAutorizacionById(uint idAutorizacion);
        Task<int> CrearAutorizacion(Autorizacion autorizacion);
        Task<int> ActualizarAutorizacion(Autorizacion autorizacion);
        Task<int> EliminarAutorizacion(uint idAutorizacion);
        Task<List<Autorizacion>> ListarAutorizaciones();
    }
}
