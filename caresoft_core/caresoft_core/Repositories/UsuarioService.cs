using caresoft_core.Entities;
using caresoft_core.Dto;
using MySql.Data.MySqlClient;

namespace caresoft_core.Repositories
{
    public class UsuarioService : IUsuarioService
    {
        private readonly CaresoftDbContext _dbContext;
        private readonly string _connectionString;
        private readonly LogHandler<UsuarioService> _logHandler = new LogHandler<UsuarioService>();

        public UsuarioService(CaresoftDbContext dbContext, string connectionString)
        {
            _dbContext = dbContext;
            _connectionString = connectionString;
        }

        public async Task<List<UsuarioDto>> GetUsuariosListAsync(string? documento, string? genero, DateTime? fechaNacimiento, string? rol)
        {
            var usuarios = new List<UsuarioDto>();

            try 
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand("spUsuarioListar", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@p_documento", documento);
                command.Parameters.AddWithValue("@p_genero", genero);
                command.Parameters.AddWithValue("@p_fechaNacimiento", fechaNacimiento);
                command.Parameters.AddWithValue("@p_rol", rol);

                using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var usuario = new UsuarioDto
                        {
                            UsuarioCodigo = reader["usuarioCodigo"].ToString(),
                            UsuarioContra = reader["usuarioContra"].ToString(),
                            Documento = reader["documento"].ToString(),
                            TipoDocumento = reader["tipoDocumento"].ToString(),
                            NumLicenciaMedica = reader["numLicenciaMedica"] != DBNull.Value ? Convert.ToUInt32(reader["numLicenciaMedica"]) : 0,
                            Nombre = reader["nombre"].ToString(),
                            Apellido = reader["apellido"].ToString(),
                            Genero = reader["genero"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]),
                            Telefono = reader["telefono"].ToString(),
                            Correo = reader["correo"].ToString(),
                            Direccion = reader["direccion"] != DBNull.Value ? reader["direccion"].ToString() : null,
                            Rol = reader["rol"].ToString()
                        };
                    
                        usuarios.Add(usuario);
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Ocurrio un error", ex);
            }

            return usuarios;
        }

        public async Task<int> AddUsuarioPacienteAsync(Usuario usuario, PerfilUsuario perfilUsuario)
        {
            try 
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand("spUsuarioCrearPaciente", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@p_documento", perfilUsuario.Documento);
                command.Parameters.AddWithValue("@p_tipoDocumento", perfilUsuario.TipoDocumento);
                command.Parameters.AddWithValue("@p_nombre", perfilUsuario.Nombre);
                command.Parameters.AddWithValue("@p_apellido", perfilUsuario.Apellido);
                command.Parameters.AddWithValue("@p_genero", perfilUsuario.Genero);
                command.Parameters.AddWithValue("@p_fechaNacimiento", perfilUsuario.FechaNacimiento);
                command.Parameters.AddWithValue("@p_telefono", perfilUsuario.Telefono);
                command.Parameters.AddWithValue("@p_correo", perfilUsuario.Correo);
                command.Parameters.AddWithValue("@p_direccion", perfilUsuario.Direccion);
                command.Parameters.AddWithValue("@p_usuarioCodigo", usuario.UsuarioCodigo);
                command.Parameters.AddWithValue("@p_usuarioContra", usuario.UsuarioContra);

                int result = await command.ExecuteNonQueryAsync();
                
                connection.Close();
                
                return result;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Ocurrio un error", ex);
                throw ex;
            }
        }

        public async Task<int> AddUsuarioPersonalAsync(Usuario usuario, PerfilUsuario perfilUsuario)
        {
            try 
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand("spUsuarioCrearPersonal", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@p_documento", perfilUsuario.Documento);
                command.Parameters.AddWithValue("@p_tipoDocumento", perfilUsuario.TipoDocumento);
                command.Parameters.AddWithValue("@p_nombre", perfilUsuario.Nombre);
                command.Parameters.AddWithValue("@p_apellido", perfilUsuario.Apellido);
                command.Parameters.AddWithValue("@p_genero", perfilUsuario.Genero);
                command.Parameters.AddWithValue("@p_fechaNacimiento", perfilUsuario.FechaNacimiento);
                command.Parameters.AddWithValue("@p_telefono", perfilUsuario.Telefono);
                command.Parameters.AddWithValue("@p_correo", perfilUsuario.Correo);
                command.Parameters.AddWithValue("@p_direccion", perfilUsuario.Direccion);
                command.Parameters.AddWithValue("@p_rol", perfilUsuario.Rol);
                command.Parameters.AddWithValue("@p_usuarioCodigo", usuario.UsuarioCodigo);
                command.Parameters.AddWithValue("@p_usuarioContra", usuario.UsuarioContra);

                int result = await command.ExecuteNonQueryAsync();
                
                connection.Close();
                
                return result;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Ocurrio un error", ex);
                throw ex;
            }
        }

        public async Task<int> AddUsuarioMedicoAsync(Usuario usuario, PerfilUsuario perfilUsuario)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand("spUsuarioCrearPersonalMedico", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
    
                // Add parameters
                command.Parameters.AddWithValue("@p_documento", perfilUsuario.Documento);
                command.Parameters.AddWithValue("@p_tipoDocumento", perfilUsuario.TipoDocumento);
                command.Parameters.AddWithValue("@p_numLicenciaMedica", perfilUsuario.NumLicenciaMedica);
                command.Parameters.AddWithValue("@p_nombre", perfilUsuario.Nombre);
                command.Parameters.AddWithValue("@p_apellido", perfilUsuario.Apellido);
                command.Parameters.AddWithValue("@p_genero", perfilUsuario.Genero);
                command.Parameters.AddWithValue("@p_fechaNacimiento", perfilUsuario.FechaNacimiento);
                command.Parameters.AddWithValue("@p_telefono", perfilUsuario.Telefono);
                command.Parameters.AddWithValue("@p_correo", perfilUsuario.Correo);
                command.Parameters.AddWithValue("@p_direccion", perfilUsuario.Direccion);
                command.Parameters.AddWithValue("@p_rol", perfilUsuario.Rol);
                command.Parameters.AddWithValue("@p_usuarioCodigo", usuario.UsuarioCodigo);
                command.Parameters.AddWithValue("@p_usuarioContra", usuario.UsuarioContra);

                int result = await command.ExecuteNonQueryAsync();
                
                connection.Close();
                
                return result;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("No se pudo establecer la conexión con la base de datos.", ex);
                return 0; // or throw ex;
            }
        }
        
        public async Task<int> UpdateUsuarioAsync(Usuario usuario, PerfilUsuario perfilUsuario)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand("spUsuarioActualizarDatos", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
    
                // Add parameters
                command.Parameters.AddWithValue("@p_usuarioCodigo", usuario.UsuarioCodigo);
                command.Parameters.AddWithValue("@p_usuarioContra", usuario.UsuarioContra);
                command.Parameters.AddWithValue("@p_tipoDocumento", perfilUsuario.TipoDocumento);
                command.Parameters.AddWithValue("@p_documento", perfilUsuario.Documento);
                command.Parameters.AddWithValue("@p_tipoDocumento", perfilUsuario.TipoDocumento);
                command.Parameters.AddWithValue("@p_nombre", perfilUsuario.Nombre);
                command.Parameters.AddWithValue("@p_apellido", perfilUsuario.Apellido);
                command.Parameters.AddWithValue("@p_genero", perfilUsuario.Genero);
                command.Parameters.AddWithValue("@p_fechaNacimiento", perfilUsuario.FechaNacimiento);
                command.Parameters.AddWithValue("@p_telefono", perfilUsuario.Telefono);
                command.Parameters.AddWithValue("@p_correo", perfilUsuario.Correo);
                command.Parameters.AddWithValue("@p_direccion", perfilUsuario.Direccion);

                int result = await command.ExecuteNonQueryAsync();
                
                connection.Close();
                
                return result;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Ocurrio un error", ex);
                throw ex;
            }
        }
        
        public async Task<int> DeleteUsuarioAsync(string codigoOdocumento)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand("spUsuarioEliminar", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
    
                // Add parameters
                command.Parameters.AddWithValue("@p_documentoOUsuarioCodigo", codigoOdocumento);

                int result = await command.ExecuteNonQueryAsync();
                
                connection.Close();
                
                return result;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Ocurrio un error", ex);
                throw ex;
            }
        }
    }
}
