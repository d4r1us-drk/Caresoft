﻿using caresoft_core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_core.Services.Interfaces
{
    public interface ISalaService
    {
        Task<int> CreateSalaAsync(SalaDto salaDto);
        Task<List<SalaDto>> GetSalasAsync();
        Task<int> UpdateSalaEstadoAsync(uint numSala);
        Task<int> DeleteSalaAsync(uint numSala);
    }
}
