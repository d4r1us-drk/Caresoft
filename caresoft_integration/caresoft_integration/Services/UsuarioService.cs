using caresoft_integration.Models;
using caresoft_integration.Dto;
using caresoft_integration.Context;
using caresoft_integration.Utils;
using Microsoft.EntityFrameworkCore;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace caresoft_integration.Services;

public class UsuarioService : IUsuarioService
{
    private readonly CaresoftDbContext _dbContext;
    private readonly CoreApiClient _coreApiClient;
    private readonly LogHandler<UsuarioService> _logHandler = new();

    public UsuarioService(CaresoftDbContext dbContext, CoreApiClient coreApiClient)
    {
        _dbContext = dbContext;
        _coreApiClient = coreApiClient;
    }

    public async Task<UsuarioDto?> GetUsuarioByIdAsync(string id)
    {
        try
        {
            return await _coreApiClient.GetUsuarioByIdAsync(id);
        }
        catch (Exception)
        {
            var usuario = await _dbContext.Usuarios
                .Where(u => u.UsuarioCodigo == id)
                .Include(u => u.DocumentoUsuarioNavigation)
                .FirstOrDefaultAsync();

            return usuario != null ? UsuarioDto.FromModel(usuario) : null;
        }
    }

    public async Task<List<UsuarioDto>> GetUsuariosListAsync()
    {
        try
        {
            return await _coreApiClient.GetUsuariosListAsync();
        }
        catch (Exception)
        {
            var usuarios = await _dbContext.Usuarios
                .Include(u => u.DocumentoUsuarioNavigation)
                .ToListAsync();

            return usuarios.ConvertAll(UsuarioDto.FromModel);
        }
    }

    public async Task<int> AddUsuarioAsync(UsuarioDto usuarioDto)
    {
        try
        {
            return await _coreApiClient.AddUsuarioAsync(usuarioDto);
        }
        catch (Exception)
        {
            var usuario = Usuario.FromDto(usuarioDto);
            var perfilUsuario = PerfilUsuario.FromDto(usuarioDto);

            _dbContext.Usuarios.Add(usuario);
            _dbContext.PerfilUsuarios.Add(perfilUsuario);

            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }

    public async Task<int> UpdateUsuarioAsync(UsuarioDto usuarioDto)
    {
        try
        {
            return await _coreApiClient.UpdateUsuarioAsync(usuarioDto);
        }
        catch (Exception)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(usuarioDto.UsuarioCodigo);
            if (usuario == null) return 0;

            _dbContext.Entry(usuario).CurrentValues.SetValues(usuarioDto);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }

    public async Task<int> DeleteUsuarioAsync(string codigoOdocumento)
    {
        try
        {
            return await _coreApiClient.DeleteUsuarioAsync(codigoOdocumento);
        }
        catch (Exception)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(codigoOdocumento);
            if (usuario == null) return 0;

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }

    public async Task<int> ToggleUsuarioCuentaAsync(string codigoOdocumento)
    {
        try
        {
            return await _coreApiClient.ToggleUsuarioCuentaAsync(codigoOdocumento);
        }
        catch (Exception)
        {
            // Example for toggling account state locally, specifics need real implementation
            var cuenta = await _dbContext.Cuenta.FindAsync(codigoOdocumento);
            if (cuenta == null) return 0;

            cuenta.Estado = cuenta.Estado == "A" ? "D" : "A";
            _dbContext.Update(cuenta);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }

    public async Task<CuentumDto?> GetCuentaByUsuarioCodigoOrDocumentoAsync(string codigoOdocumento)
    {
        try
        {
            return await _coreApiClient.GetCuentaByUsuarioCodigoOrDocumentoAsync(codigoOdocumento);
        }
        catch (Exception)
        {
            var cuenta = await _dbContext.Cuenta
                .Include(c => c.DocumentoUsuarioNavigation)
                .FirstOrDefaultAsync(c => c.DocumentoUsuario == codigoOdocumento);

            return cuenta != null ? CuentumDto.FromModel(cuenta) : null;
        }
    }
}
