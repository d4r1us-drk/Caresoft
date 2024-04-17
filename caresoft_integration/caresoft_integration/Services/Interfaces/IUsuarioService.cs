using caresoft_integration.Dto;
using caresoft_integration.Models;

namespace caresoft_integration.Services.Interfaces;

public interface IUsuarioService
{
    public Task<List<UsuarioDto>> GetUsuariosListAsync();
    public Task<int> AddUsuarioAsync(UsuarioDto usuarioDto);
    public Task<int> UpdateUsuarioAsync(UsuarioDto usuarioDto);
    public Task<int> DeleteUsuarioAsync(string codigoOdocumento);
    public Task<int> ToggleUsuarioCuentaAsync(string codigoOdocumento);
    public Task<UsuarioDto?> GetUsuarioByIdAsync(string id);
    public Task<CuentumDto?> GetCuentaByUsuarioCodigoOrDocumentoAsync(string codigoOdocumento);
}
