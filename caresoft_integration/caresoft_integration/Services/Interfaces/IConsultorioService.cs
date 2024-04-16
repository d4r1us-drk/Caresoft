using caresoft_integration.Models;

namespace caresoft_integration.Services.Interfaces;

public interface IConsultorioService
{
    Task<IEnumerable<Consultorio>> GetConsultoriosAsync();
    Task<Consultorio> GetConsultorioByIdAsync(uint idConsultorio);
    Task<int> CreateConsultorioAsync(Consultorio consultorio);
    Task<int> UpdateConsultorioAsync(Consultorio consultorio);
    Task<int> DeleteConsultorioAsync(uint idConsultorio);
}