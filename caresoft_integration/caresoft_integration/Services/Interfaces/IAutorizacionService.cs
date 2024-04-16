using caresoft_integration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_integration.Services.Interfaces
{
    public interface IAutorizacionService
    {
        Task<int> CreateAutorizacionAsync(Autorizacion autorizacion, Aseguradora aseguradora);
        Task<Autorizacion> GetAutorizacionByIdAsync(uint id);
        Task<int> UpdateAutorizacionAsync(Autorizacion autorizacion, Aseguradora aseguradora);
        Task<int> DeleteAutorizacionAsync(uint id);
        Task<List<Autorizacion>> GetAllAutorizacionesAsync();
    }
}
