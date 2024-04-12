using caresoft_core.Models;
using caresoft_core.Dto;
using caresoft_core.Utils;
using Microsoft.EntityFrameworkCore;
using caresoft_core.Services.Interfaces;

namespace caresoft_core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly LogHandler<UsuarioService> _logHandler = new();

        public UsuarioService(CaresoftDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioDto>> GetUsuariosListAsync()
        {
            try
            {
                var usuariosQuery = from usuario in _dbContext.Usuarios
                                    join perfilUsuario in _dbContext.PerfilUsuarios on usuario.DocumentoUsuario equals perfilUsuario.Documento
                                    select new UsuarioDto
                                    {
                                        UsuarioCodigo = usuario.UsuarioCodigo,
                                        UsuarioContra = usuario.UsuarioContra,
                                        Documento = perfilUsuario.Documento,
                                        TipoDocumento = perfilUsuario.TipoDocumento,
                                        NumLicenciaMedica = perfilUsuario.NumLicenciaMedica,
                                        Nombre = perfilUsuario.Nombre,
                                        Apellido = perfilUsuario.Apellido,
                                        Genero = perfilUsuario.Genero,
                                        FechaNacimiento = perfilUsuario.FechaNacimiento,
                                        Telefono = perfilUsuario.Telefono,
                                        Correo = perfilUsuario.Correo,
                                        Direccion = perfilUsuario.Direccion,
                                        Rol = perfilUsuario.Rol
                                    };
        
                var usuarios = await usuariosQuery.ToListAsync();
        
                _logHandler.LogInfo("Data retrieved successfully.");
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
                if (usuario == null || perfilUsuario == null)
                {
                    _logHandler.LogInfo("Usuario or PerfilUsuario object is null.");
                    return 0;
                }
        
                _dbContext.PerfilUsuarios.Add(perfilUsuario);
                _dbContext.Usuarios.Add(usuario);
        
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
                if (usuario == null || perfilUsuario == null)
                {
                    _logHandler.LogInfo("Usuario or PerfilUsuario object is null.");
                    return 0;
                }
        
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
                    else
                    {
                        _logHandler.LogInfo($"User with code or document '{codigoOdocumento}' not found.");
                        return 0;
                    }
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
                    else
                    {
                        _logHandler.LogInfo($"User with code or document '{codigoOdocumento}' not found.");
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
                throw;
            }
        }
    }
}
