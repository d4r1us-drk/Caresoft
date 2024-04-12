using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Context;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;
using caresoft_core.Services.Interfaces;

namespace caresoft_core.Services;

public class UsuarioService : IUsuarioService
{
    private readonly CaresoftDbContext _dbContext;
    private readonly LogHandler<UsuarioService> _logHandler = new();

    public UsuarioService(CaresoftDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UsuarioDto?> GetUsuarioByIdAsync(string id)
    {
        try
        {
            var usuario = await _dbContext.Usuarios.Where(e => e.UsuarioCodigo == id).Include(e => e.DocumentoUsuarioNavigation).FirstOrDefaultAsync();

            if (usuario == null) return null;

            return UsuarioDto.FromModel(usuario);
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Something went wrong.", ex);
            throw;
        }
    }

    public async Task<List<UsuarioDto>> GetUsuariosListAsync()
    {
        try
        {
            var usuarios = (await _dbContext.Usuarios.Include(e => e.DocumentoUsuarioNavigation).ToListAsync())
                .Select(e => UsuarioDto.FromModel(e))
                .ToList();

            return usuarios;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Something went wrong.", ex);
            return new List<UsuarioDto>();
        }
    }

    public async Task<int> AddUsuarioAsync(Usuario usuario, PerfilUsuario perfilUsuario)
    {
        try
        {
            var cuenta = new Cuentum
            {
                DocumentoUsuario = perfilUsuario.Documento,
                Balance = Decimal.Zero,
                DocumentoUsuarioNavigation = perfilUsuario,
                Estado = "A",
            };

            _dbContext.PerfilUsuarios.Add(perfilUsuario);
            _dbContext.Usuarios.Add(usuario);
            _dbContext.Cuenta.Add(cuenta);

            await _dbContext.SaveChangesAsync();

            _logHandler.LogInfo($"User with code '{usuario.UsuarioCodigo}' and document '{perfilUsuario.Documento}' was created successfully.");

            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Something went wrong.", ex);
            throw;
        }
    }

    public async Task<int> UpdateUsuarioAsync(Usuario usuario, PerfilUsuario perfilUsuario)
    {
        try
        {
            _dbContext.Usuarios.Update(usuario);
            _dbContext.PerfilUsuarios.Update(perfilUsuario);

            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Something went wrong.", ex);
            throw;
        }
    }

    public async Task<int> ToggleUsuarioCuentaAsync(string codigoOdocumento)
    {
        try
        {
            // Check if the argument is a usuarioCodigo or documento
            bool isUsuarioCodigo = await _dbContext.Usuarios.AnyAsync(u => u.UsuarioCodigo == codigoOdocumento);

            Cuentum? cuentaToUpdate;

            if (isUsuarioCodigo) // Assuming usuarioCodigo is shorter than a documento
            {
                // If it's a usuarioCodigo, get the corresponding documento
                var documento = await _dbContext.Usuarios
                    .Where(u => u.UsuarioCodigo == codigoOdocumento)
                    .Select(u => u.DocumentoUsuario)
                    .FirstOrDefaultAsync();

                // Find the corresponding cuenta using documento
                cuentaToUpdate = await _dbContext.Cuenta
                    .Include(c => c.DocumentoUsuarioNavigation)
                    .FirstOrDefaultAsync(c => c.DocumentoUsuarioNavigation.Documento == documento);
            }
            else
            {
                // If it's a documento, directly find the cuenta
                cuentaToUpdate = await _dbContext.Cuenta
                    .Include(c => c.DocumentoUsuarioNavigation)
                    .FirstOrDefaultAsync(c => c.DocumentoUsuario == codigoOdocumento);
            }

            if (cuentaToUpdate != null)
            {
                // Update the Estado attribute to "D"
                cuentaToUpdate.Estado = "D";
                _dbContext.Cuenta.Update(cuentaToUpdate);
                await _dbContext.SaveChangesAsync();
                _logHandler.LogInfo($"Estado attribute in Cuenta toggled successfully for {codigoOdocumento}.");
                return 1;
            }
            _logHandler.LogInfo($"Cuenta for user with code or document '{codigoOdocumento}' not found.");
            return 0;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Something went wrong.", ex);
            throw;
        }
    }

    public async Task<int> DeleteUsuarioAsync(string codigoOdocumento)
    {
        try
        {
            // Check if the argument is a usuarioCodigo or documento
            bool isUsuarioCodigo = await _dbContext.Usuarios.AnyAsync(u => u.UsuarioCodigo == codigoOdocumento);

            if (isUsuarioCodigo)
            {
                // If it's a usuarioCodigo, get the corresponding documento
                string? documento = await _dbContext.Usuarios
                    .Where(u => u.UsuarioCodigo == codigoOdocumento)
                    .Select(u => u.DocumentoUsuario)
                    .FirstOrDefaultAsync();

                // Remove the perfilUsuario associated with the documento
                var perfilUsuario = await _dbContext.PerfilUsuarios.FindAsync(documento);
                if (perfilUsuario != null)
                {
                    _dbContext.PerfilUsuarios.Remove(perfilUsuario);
                    await _dbContext.SaveChangesAsync();
                    _logHandler.LogInfo($"User with code or document '{codigoOdocumento}' was deleted.");
                    return 1;
                }
                _logHandler.LogInfo($"User with code or document '{codigoOdocumento}' not found.");
                return 0;
            }
            else
            {
                // If it's a documento, directly remove the perfilUsuario
                var perfilUsuario = await _dbContext.PerfilUsuarios.FindAsync(codigoOdocumento);
                if (perfilUsuario != null)
                {
                    _dbContext.PerfilUsuarios.Remove(perfilUsuario);
                    await _dbContext.SaveChangesAsync();
                    _logHandler.LogInfo($"User with code or document '{codigoOdocumento}' was deleted.");
                    return 1;
                }
                _logHandler.LogInfo($"User with code or document '{codigoOdocumento}' not found.");
                return 0;
            }
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Something went wrong.", ex);
            throw;
        }
    }
}