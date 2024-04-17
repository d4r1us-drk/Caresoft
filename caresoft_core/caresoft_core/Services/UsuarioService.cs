using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Context;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;
using caresoft_core.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace caresoft_core.Services;

public class UsuarioService(CaresoftDbContext dbContext) : IUsuarioService
{
    private readonly LogHandler<UsuarioService> _logHandler = new();

    public async Task<UsuarioDto?> GetUsuarioByIdAsync(string id)
    {
        try
        {
            var usuario = await dbContext.Usuarios.Where(e => e.UsuarioCodigo == id).Include(e => e.DocumentoUsuarioNavigation).FirstOrDefaultAsync();

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
            var usuarios = (await dbContext.Usuarios.Include(e => e.DocumentoUsuarioNavigation).ToListAsync())
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

    public async Task<int> AddUsuarioAsync(UsuarioDto usuarioDto)
    {
        try
        {
            var perfilUsuario = PerfilUsuario.FromDto(usuarioDto);
            var usuario = Usuario.FromDto(usuarioDto);

            var cuenta = new Cuentum
            {
                DocumentoUsuario = perfilUsuario.Documento,
                Balance = Decimal.Zero,
                DocumentoUsuarioNavigation = perfilUsuario,
                Estado = "A"
            };

            dbContext.PerfilUsuarios.Add(perfilUsuario);
            dbContext.Usuarios.Add(usuario);
            dbContext.Cuenta.Add(cuenta);

            await dbContext.SaveChangesAsync();

            _logHandler.LogInfo($"User with code '{usuario.UsuarioCodigo}' and document '{perfilUsuario.Documento}' was created successfully.");

            return 1;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Something went wrong.", ex);
            throw;
        }
    }

    public async Task<int> UpdateUsuarioAsync(UsuarioDto usuarioDto)
    {
        try
        {
            // Convert UsuarioDto to Usuario and PerfilUsuario entities
            var usuario = Usuario.FromDto(usuarioDto);
            var perfilUsuario = PerfilUsuario.FromDto(usuarioDto);

            // Update the PerfilUsuario entity in the database
            dbContext.PerfilUsuarios.Update(perfilUsuario);

            // Associate the updated perfilUsuario with the usuario
            usuario.DocumentoUsuarioNavigation = perfilUsuario;

            // Update the usuario entity in the database
            dbContext.Usuarios.Update(usuario);

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            // Return 1 to indicate successful update
            return 1;
        }
        catch (Exception ex)
        {
            // Log the error
            _logHandler.LogFatal("Error updating usuario.", ex);
            // Rethrow the exception to propagate it further
            throw;
        }
    }

    public async Task<int> ToggleUsuarioCuentaAsync(string codigoOdocumento)
    {
        try
        {
            // Check if the argument is a usuarioCodigo or documento
            bool isUsuarioCodigo = await dbContext.Usuarios.AnyAsync(u => u.UsuarioCodigo == codigoOdocumento);

            Cuentum? cuentaToUpdate;

            if (isUsuarioCodigo) // Assuming usuarioCodigo is shorter than a documento
            {
                // If it's a usuarioCodigo, get the corresponding documento
                var documento = await dbContext.Usuarios
                    .Where(u => u.UsuarioCodigo == codigoOdocumento)
                    .Select(u => u.DocumentoUsuario)
                    .FirstOrDefaultAsync();

                // Find the corresponding cuenta using documento
                cuentaToUpdate = await dbContext.Cuenta
                    .Include(c => c.DocumentoUsuarioNavigation)
                    .FirstOrDefaultAsync(c => c.DocumentoUsuarioNavigation.Documento == documento);
            }
            else
            {
                // If it's a documento, directly find the cuenta
                cuentaToUpdate = await dbContext.Cuenta
                    .Include(c => c.DocumentoUsuarioNavigation)
                    .FirstOrDefaultAsync(c => c.DocumentoUsuario == codigoOdocumento);
            }

            if (cuentaToUpdate != null)
            {
                // Update the Estado attribute to "D"
                cuentaToUpdate.Estado = "D";
                dbContext.Cuenta.Update(cuentaToUpdate);
                await dbContext.SaveChangesAsync();
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
            var user = await dbContext.Usuarios.
                Include(u => u.DocumentoUsuarioNavigation).
                FirstOrDefaultAsync(u => u.UsuarioCodigo == codigoOdocumento || u.DocumentoUsuario == codigoOdocumento);
            if(user != null)
             dbContext.Usuarios.Remove(user);
            return await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Something went wrong.", ex);
            throw;
        }
    }

    public async Task<CuentumDto?> GetCuentaByUsuarioCodigoOrDocumentoAsync(string codigoOdocumento)
    {
        try
        {
            // Check if the argument is a usuarioCodigo or documento
            bool isUsuarioCodigo = await dbContext.Usuarios.AnyAsync(u => u.UsuarioCodigo == codigoOdocumento);

            Cuentum? cuenta;

            if (isUsuarioCodigo) // Assuming usuarioCodigo is shorter than a documento
            {
                // If it's a usuarioCodigo, get the corresponding documento
                var documento = await dbContext.Usuarios
                    .Where(u => u.UsuarioCodigo == codigoOdocumento)
                    .Select(u => u.DocumentoUsuario)
                    .FirstOrDefaultAsync();

                // Find the corresponding cuenta using documento
                cuenta = await dbContext.Cuenta
                    .Include(c => c.DocumentoUsuarioNavigation)
                    .FirstOrDefaultAsync(c => c.DocumentoUsuarioNavigation.Documento == documento);
            }
            else
            {
                // If it's a documento, directly find the cuenta
                cuenta = await dbContext.Cuenta
                    .Include(c => c.DocumentoUsuarioNavigation)
                    .FirstOrDefaultAsync(c => c.DocumentoUsuario == codigoOdocumento);
            }

            if (cuenta != null)
            {
                return CuentumDto.FromModel(cuenta);
            }

            _logHandler.LogInfo($"Cuenta for user with code or document '{codigoOdocumento}' not found.");
            return null;
        }
        catch (Exception ex)
        {
            _logHandler.LogFatal("Something went wrong.", ex);
            throw;
        }
    }
}