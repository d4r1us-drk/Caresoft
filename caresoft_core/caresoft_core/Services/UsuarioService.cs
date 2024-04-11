using caresoft_core.Models;
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
                var perfilUsuario = new PerfilUsuario
                {
                    Documento = usuario.Documento,
                    TipoDocumento = usuario.TipoDocumento,
                    NumLicenciaMedica = usuario.NumLicenciaMedica,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Genero = usuario.Genero,
                    FechaNacimiento = usuario.FechaNacimiento ?? DateTime.MinValue,
                    Telefono = usuario.Telefono,
                    Correo = usuario.Correo,
                    Direccion = usuario.Direccion,
                    Rol = usuario.Rol
                };

                var usuarioEntity = new Usuario
                {
                    UsuarioCodigo = usuario.UsuarioCodigo,
                    DocumentoUsuario = usuario.Documento,
                    UsuarioContra = usuario.UsuarioContra,
                    DocumentoUsuarioNavigation = perfilUsuario
                };

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
                // Check if at least one property is not null
                if (usuarioDto.UsuarioCodigo == null &&
                    usuarioDto.Documento == null &&
                    usuarioDto.UsuarioContra == null &&
                    usuarioDto.TipoDocumento == null &&
                    usuarioDto.NumLicenciaMedica == null &&
                    usuarioDto.Nombre == null &&
                    usuarioDto.Apellido == null &&
                    usuarioDto.Genero == null &&
                    usuarioDto.FechaNacimiento == null &&
                    usuarioDto.Telefono == null &&
                    usuarioDto.Correo == null &&
                    usuarioDto.Direccion == null &&
                    usuarioDto.Rol == null)
                {
                    throw new ArgumentException("At least one property must be non-null to update the user.");
                }
        
                var perfilUsuario = await _dbContext.PerfilUsuarios.FindAsync(usuarioDto.Documento);
                if (perfilUsuario != null)
                {
                    // Update only non-null properties
                    if (usuarioDto.TipoDocumento != null)
                        perfilUsuario.TipoDocumento = usuarioDto.TipoDocumento;
        
                    if (usuarioDto.Rol == "M" || usuarioDto.Rol == "E")
                        perfilUsuario.NumLicenciaMedica = usuarioDto.NumLicenciaMedica;
                    else
                        perfilUsuario.NumLicenciaMedica = null;
        
                    if (usuarioDto.Nombre != null)
                        perfilUsuario.Nombre = usuarioDto.Nombre;
        
                    if (usuarioDto.Apellido != null)
                        perfilUsuario.Apellido = usuarioDto.Apellido;
        
                    if (usuarioDto.Genero != null)
                        perfilUsuario.Genero = usuarioDto.Genero;
        
                    if (usuarioDto.FechaNacimiento != null)
                        perfilUsuario.FechaNacimiento = usuarioDto.FechaNacimiento ?? DateTime.MinValue;
        
                    if (usuarioDto.Telefono != null)
                        perfilUsuario.Telefono = usuarioDto.Telefono;
        
                    if (usuarioDto.Correo != null)
                        perfilUsuario.Correo = usuarioDto.Correo;
        
                    if (usuarioDto.Direccion != null)
                        perfilUsuario.Direccion = usuarioDto.Direccion;
        
                    if (usuarioDto.Rol != null)
                        perfilUsuario.Rol = usuarioDto.Rol;
        
                    _dbContext.PerfilUsuarios.Update(perfilUsuario);
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
                    string documento = await _dbContext.Usuarios
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
