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

        public async Task<List<UsuarioDto>> GetUsuariosListAsync(string? usuarioCodigo, string? documento, string? genero, DateTime? fechaNacimiento, string? rol)
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
        
                // Apply filters
                if (!string.IsNullOrEmpty(usuarioCodigo))
                    usuariosQuery = usuariosQuery.Where(u => u.UsuarioCodigo == usuarioCodigo);
        
                if (!string.IsNullOrEmpty(documento))
                    usuariosQuery = usuariosQuery.Where(u => u.Documento == documento);
        
                if (!string.IsNullOrEmpty(genero))
                    usuariosQuery = usuariosQuery.Where(u => u.Genero == genero);
        
                if (fechaNacimiento != null)
                    usuariosQuery = usuariosQuery.Where(u => u.FechaNacimiento == fechaNacimiento);
        
                if (!string.IsNullOrEmpty(rol))
                    usuariosQuery = usuariosQuery.Where(u => u.Rol == rol);
        
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

        public async Task<int> AddUsuarioAsync(UsuarioDto usuario)
        {
            try
            {
                var perfilUsuario = PerfilUsuario.FromDto(usuario);
                var usuarioEntity = Usuario.FromDto(usuario);
                usuarioEntity.DocumentoUsuarioNavigation = perfilUsuario;

                _dbContext.PerfilUsuarios.Add(perfilUsuario);
                _dbContext.Usuarios.Add(usuarioEntity);

                await _dbContext.SaveChangesAsync();

                _logHandler.LogInfo($"User with code '{usuario.UsuarioCodigo}' and document '{usuario.Documento}' was created successfully.");

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
                var usuario = await _dbContext.Usuarios.FindAsync(usuarioDto.UsuarioCodigo);
                var perfilUsuario = await _dbContext.PerfilUsuarios.FindAsync(usuarioDto.Documento);

                bool usuarioUpdated = false;
                bool perfilUsuarioUpdated = false;

                if (perfilUsuario != null && usuario != null)
                {
                    // Update only non-null properties
                    if (usuarioDto.UsuarioCodigo != null)
                    {
                        usuario.UsuarioCodigo = usuarioDto.UsuarioCodigo;
                        usuarioUpdated = true;
                    }

                    if (usuarioDto.UsuarioContra != null)
                    {
                        usuario.UsuarioContra = usuarioDto.UsuarioContra;
                        usuarioUpdated = true;
                    }

                    if (usuarioDto.Documento != null)
                    {
                        perfilUsuario.Documento = usuarioDto.Documento;
                        perfilUsuarioUpdated = true;
                    }

                    if (usuarioDto.TipoDocumento != null)
                    {
                        perfilUsuario.TipoDocumento = usuarioDto.TipoDocumento;
                        perfilUsuarioUpdated = true;
                    }
        
                    if (usuarioDto.Rol == "M" || usuarioDto.Rol == "E")
                    {
                        perfilUsuario.NumLicenciaMedica = usuarioDto.NumLicenciaMedica;
                        perfilUsuarioUpdated = true;
                    }
        
                    if (usuarioDto.Nombre != null)
                    {
                        perfilUsuario.Nombre = usuarioDto.Nombre;
                        perfilUsuarioUpdated = true;
                    }
        
                    if (usuarioDto.Apellido != null)
                    {
                        perfilUsuario.Apellido = usuarioDto.Apellido;
                        perfilUsuarioUpdated = true;
                    }

                    if (usuarioDto.Genero != null)
                    {
                        perfilUsuario.Genero = usuarioDto.Genero;
                        perfilUsuarioUpdated = true;
                    }
        
                    if (usuarioDto.FechaNacimiento != null)
                    {
                        perfilUsuario.FechaNacimiento = usuarioDto.FechaNacimiento;
                        perfilUsuarioUpdated = true;
                    }
        
                    if (usuarioDto.Telefono != null)
                    {
                        perfilUsuario.Telefono = usuarioDto.Telefono;
                        perfilUsuarioUpdated = true;
                    }
        
                    if (usuarioDto.Correo != null)
                    {
                        perfilUsuario.Correo = usuarioDto.Correo;
                        perfilUsuarioUpdated = true;
                    }
        
                    if (usuarioDto.Direccion != null)
                    {
                        perfilUsuario.Direccion = usuarioDto.Direccion;
                        perfilUsuarioUpdated = true;
                    }
        
                    if (usuarioDto.Rol != null)
                    {
                        perfilUsuario.Rol = usuarioDto.Rol;
                        perfilUsuarioUpdated = true;
                    }

                    if (perfilUsuarioUpdated)
                        _dbContext.PerfilUsuarios.Update(perfilUsuario);

                    if (usuarioUpdated)
                        _dbContext.Usuarios.Update(usuario);
        
                    return await _dbContext.SaveChangesAsync();
                }
                else
                {
                    _logHandler.LogInfo($"User with document '{usuarioDto.Documento}' not found.");
                    return 0;
                }
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
