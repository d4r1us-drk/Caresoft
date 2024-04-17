using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces;

public interface IAseguradoraService
{
    Task<int> CreateAseguradora(Aseguradora aseguradora);
    Task<List<Aseguradora>> GetAllAseguradoras();
    Task<Aseguradora?> GetAseguradoraById(uint id);
    Task<int> UpdateAseguradora(Aseguradora aseguradora);
    Task<int> DeleteAseguradora(uint id);

}
