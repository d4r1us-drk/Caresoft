using caresoft_integration.Dto;
using caresoft_integration.Models;
using caresoft_integration.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_integration.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly FallbackHttpClient _fallbackHttpClient;

        public UsuarioService(FallbackHttpClient fallbackHttpClient)
        {
            _fallbackHttpClient = fallbackHttpClient;
        }

        public async Task<List<UsuarioDto>> GetUsuariosListAsync()
        {
            return await _fallbackHttpClient.GetUsuariosListAsync();
        }

        public async Task<UsuarioDto?> GetUsuarioByIdAsync(string id)
        {
            return await _fallbackHttpClient.GetUsuarioByIdAsync(id);
        }

        public async Task<int> AddUsuarioAsync (UsuarioDto usuarioDto)
        {
            return await _fallbackHttpClient.AddUsuarioAsync(usuarioDto);
        }

        public async Task<int> UpdateUsuarioAsync(UsuarioDto usuarioDto)
        {
            return await _fallbackHttpClient.UpdateUsuarioAsync(usuarioDto);
        }

        public async Task<int> DeleteUsuarioAsync(string codigoOdocumento)
        {
            return await _fallbackHttpClient.DeleteUsuarioAsync(codigoOdocumento);
        }

        public async Task<int> ToggleUsuarioCuentaAsync(string codigoOdocumento)
        {
            return await _fallbackHttpClient.ToggleUsuarioCuentaAsync(codigoOdocumento);
        }

        public async Task<CuentumDto?> GetCuentaByUsuarioCodigoOrDocumentoAsync(string codigoOdocumento)
        {
            return await _fallbackHttpClient.GetCuentaByUsuarioCodigoOrDocumentoAsync(codigoOdocumento);
        }

    }
}
