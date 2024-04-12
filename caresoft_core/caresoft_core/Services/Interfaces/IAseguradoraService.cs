﻿using caresoft_core.Models;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core.Services.Interfaces
{
    public interface IAseguradoraService
    {
        public  Task<List<Aseguradora>> GetAllAseguradoras();
        public Task<Aseguradora?> GetAseguradoraById(uint id);
        public Task<int> UpdateAseguradora(Aseguradora aseguradora);
        public Task<int> CreateAseguradora(Aseguradora aseguradora);
        public Task<int> DeleteAseguradora(uint id);

    }
}