using caresoft_core.Models;
using caresoft_core.Utils;
using MySql.Data.MySqlClient;
using caresoft_core.Services.Interfaces;

namespace caresoft_core.Services
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
                _logHandler.LogInfo("Data retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
            }

            return usuarios;
        }

        public async Task<int> AddUsuarioPacienteAsync(UsuarioDto usuario)
        {
            try 
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand("spUsuarioCrearPaciente", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@p_documento", usuario.Documento);
                command.Parameters.AddWithValue("@p_tipoDocumento", usuario.TipoDocumento);
                command.Parameters.AddWithValue("@p_nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@p_apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@p_genero", usuario.Genero);
                command.Parameters.AddWithValue("@p_fechaNacimiento", usuario.FechaNacimiento);
                command.Parameters.AddWithValue("@p_telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@p_correo", usuario.Correo);
                command.Parameters.AddWithValue("@p_direccion", usuario.Direccion);
                command.Parameters.AddWithValue("@p_usuarioCodigo", usuario.UsuarioCodigo);
                command.Parameters.AddWithValue("@p_usuarioContra", usuario.UsuarioContra);

                int result = await command.ExecuteNonQueryAsync();
                
                connection.Close();

                _logHandler.LogInfo("User of type 'Paciente' was created successfully.");
                
                return result;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
                throw ex;
            }
        }

        public async Task<int> AddUsuarioPersonalAsync(UsuarioDto usuario)
        {
            try 
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand("spUsuarioCrearPersonal", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@p_documento", usuario.Documento);
                command.Parameters.AddWithValue("@p_tipoDocumento", usuario.TipoDocumento);
                command.Parameters.AddWithValue("@p_nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@p_apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@p_genero", usuario.Genero);
                command.Parameters.AddWithValue("@p_fechaNacimiento", usuario.FechaNacimiento);
                command.Parameters.AddWithValue("@p_telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@p_correo", usuario.Correo);
                command.Parameters.AddWithValue("@p_direccion", usuario.Direccion);
                command.Parameters.AddWithValue("@p_rol", usuario.Rol);
                command.Parameters.AddWithValue("@p_usuarioCodigo", usuario.UsuarioCodigo);
                command.Parameters.AddWithValue("@p_usuarioContra", usuario.UsuarioContra);

                int result = await command.ExecuteNonQueryAsync();
                
                connection.Close();

                _logHandler.LogInfo("User of type 'Personal' was created successfully.");
                
                return result;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
                throw ex;
            }
        }

        public async Task<int> AddUsuarioMedicoAsync(UsuarioDto usuario)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();

                MySqlCommand command = new MySqlCommand("spUsuarioCrearPersonalMedico", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
    
                // Add parameters
                command.Parameters.AddWithValue("@p_documento", usuario.Documento);
                command.Parameters.AddWithValue("@p_tipoDocumento", usuario.TipoDocumento);
                command.Parameters.AddWithValue("@p_numLicenciaMedica", usuario.NumLicenciaMedica);
                command.Parameters.AddWithValue("@p_nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@p_apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@p_genero", usuario.Genero);
                command.Parameters.AddWithValue("@p_fechaNacimiento", usuario.FechaNacimiento);
                command.Parameters.AddWithValue("@p_telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@p_correo", usuario.Correo);
                command.Parameters.AddWithValue("@p_direccion", usuario.Direccion);
                command.Parameters.AddWithValue("@p_rol", usuario.Rol);
                command.Parameters.AddWithValue("@p_usuarioCodigo", usuario.UsuarioCodigo);
                command.Parameters.AddWithValue("@p_usuarioContra", usuario.UsuarioContra);

                int result = await command.ExecuteNonQueryAsync();
                
                connection.Close();

                _logHandler.LogInfo("User of type 'Medico' was created successfully.");
                
                return result;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("No se pudo establecer la conexión con la base de datos.", ex);
                return 0; // or throw ex;
            }
        }
        
        public async Task<int> UpdateUsuarioAsync(UsuarioDto usuario)
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
                command.Parameters.AddWithValue("@p_tipoDocumento", usuario.TipoDocumento);
                command.Parameters.AddWithValue("@p_numLicenciaMedica", usuario.NumLicenciaMedica);
                command.Parameters.AddWithValue("@p_documento", usuario.Documento);
                command.Parameters.AddWithValue("@p_tipoDocumento", usuario.TipoDocumento);
                command.Parameters.AddWithValue("@p_nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@p_apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@p_genero", usuario.Genero);
                command.Parameters.AddWithValue("@p_fechaNacimiento", usuario.FechaNacimiento);
                command.Parameters.AddWithValue("@p_telefono", usuario.Telefono);
                command.Parameters.AddWithValue("@p_correo", usuario.Correo);
                command.Parameters.AddWithValue("@p_direccion", usuario.Direccion);
                command.Parameters.AddWithValue("@p_rol", usuario.Rol);

                int result = await command.ExecuteNonQueryAsync();
                
                connection.Close();

                _logHandler.LogInfo("User data was successfully updated.");
                
                return result;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
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

                _logHandler.LogInfo("User data was successfully deleted.");
                
                return result;
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Something went wrong.", ex);
                throw ex;
            }
        }
    }
}
