using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces
{
    public interface IAutorizacionService
    {
        Task<Autorizacion?> GetAutorizacionById(uint idAutorizacion);
        Task<int> AddAutorizacion(Autorizacion autorizacion, int? idIngreso, string? consultaCodigo,
            string? facturaCodigo, string? servicioCodigo, int? idProducto);
        Task<int> UpdateAutorizacionAsync(Autorizacion autorizacion);
        Task<int> DeleteAutorizacionAsync(uint idAutorizacion);
        Task<List<Autorizacion>> GetAutorizaciones();
    }
}
