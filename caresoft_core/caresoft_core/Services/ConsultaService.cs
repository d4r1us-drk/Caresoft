using System.Data;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using MySql.Data.MySqlClient;

namespace caresoft_core.Services;

public class ConsultaService : IConsultaService
{
  private CaresoftDbContext _dbContext;
  private string _connectionString;
  private readonly LogHandler<ConsultaService> _logHandler = new LogHandler<ConsultaService>();

  public ConsultaService(CaresoftDbContext dbContext, string connectionString)
  {
    _dbContext = dbContext;
    _connectionString = connectionString;
  }
  public async Task<int> CrearConsulta(string consultaCodigo, string documentoPaciente, string documentoMedico, int idConsultorio, string motivo, string comentarios, decimal costo, string estado)
  {
    using MySqlConnection connection = new MySqlConnection(this._connectionString);
    MySqlCommand command = new("spConsultaCrear", connection)
    {
      CommandType = CommandType.StoredProcedure
    };

    // Agregar parámetros
    command.Parameters.AddWithValue("@p_consultaCodigo", consultaCodigo);
    command.Parameters.AddWithValue("@p_documentoPaciente", documentoPaciente);
    command.Parameters.AddWithValue("@p_documentoMedico", documentoMedico);
    command.Parameters.AddWithValue("@p_idConsultorio", idConsultorio);
    command.Parameters.AddWithValue("@p_motivo", motivo);
    command.Parameters.AddWithValue("@p_comentarios", comentarios);
    command.Parameters.AddWithValue("@p_costo", costo);
    command.Parameters.AddWithValue("@p_estado", estado);

    try
    {
      connection.Open();
      return await command.ExecuteNonQueryAsync();
    }
    catch (MySqlException ex)
    {
      // Manejo de excepciones
      _logHandler.LogFatal("No se pudo crear consulta", ex);
      throw;
    }
  }
  public async Task<int> ActualizarConsulta(string consultaCodigo, string documentoPaciente, string documentoMedico, int idConsultorio, string motivo, string comentarios, decimal costo)
  {
    using MySqlConnection connection = new MySqlConnection(_connectionString);
    MySqlCommand command = new("spConsultaActualizar", connection)
    {
      CommandType = CommandType.StoredProcedure
    };

    command.Parameters.AddWithValue("@p_consultaCodigo", consultaCodigo);
    command.Parameters.AddWithValue("@p_documentoPaciente", documentoPaciente);
    command.Parameters.AddWithValue("@p_documentoMedico", documentoMedico);
    command.Parameters.AddWithValue("@p_idConsultorio", idConsultorio);
    command.Parameters.AddWithValue("@p_motivo", motivo);
    command.Parameters.AddWithValue("@p_comentarios", comentarios);
    command.Parameters.AddWithValue("@p_costo", costo);

    try
    {
      connection.Open();
      return await command.ExecuteNonQueryAsync();
    }
    catch (MySqlException ex)
    {
      _logHandler.LogFatal("No se pudo actualizar la consulta", ex);
      throw;
    }
  }
  public async Task<int> EliminarConsulta(string consultaCodigo)
  {
    using MySqlConnection connection = new MySqlConnection(_connectionString);
    MySqlCommand command = new("spConsultaEliminar", connection)
    {
      CommandType = CommandType.StoredProcedure
    };

    command.Parameters.AddWithValue("@p_consultaCodigo", consultaCodigo);

    try
    {
      connection.Open();
      return await command.ExecuteNonQueryAsync();
    }
    catch (MySqlException ex)
    {
      _logHandler.LogFatal("No se pudo eliminar la consulta", ex);
      throw;
    }
  }
  public async Task<int> RelacionarServicio(string consultaCodigo, string servicioCodigo)
  {
    using MySqlConnection connection = new MySqlConnection(_connectionString);
    MySqlCommand command = new("spConsultaRelacionarServicio", connection)
    {
      CommandType = CommandType.StoredProcedure
    };

    command.Parameters.AddWithValue("@p_consultaCodigo", consultaCodigo);
    command.Parameters.AddWithValue("@p_servicioCodigo", servicioCodigo);

    try
    {
      connection.Open();
      return await command.ExecuteNonQueryAsync();
    }
    catch (MySqlException ex)
    {
      _logHandler.LogFatal("No se pudo relacionar servicio a consulta", ex);
      throw;
    }
  }
  public async Task<int> DesrelacionarServicio(string consultaCodigo, string servicioCodigo)
  {
    using MySqlConnection connection = new MySqlConnection(_connectionString);
    MySqlCommand command = new("spConsultaDesrelacionarServicio", connection)
    {
      CommandType = CommandType.StoredProcedure
    };

    command.Parameters.AddWithValue("@p_consultaCodigo", consultaCodigo);
    command.Parameters.AddWithValue("@p_servicioCodigo", servicioCodigo);

    try
    {
      connection.Open();
      return await command.ExecuteNonQueryAsync();
    }
    catch (MySqlException ex)
    {
      _logHandler.LogFatal("No se pudo desrelacionar servicio a consulta", ex);
      throw;
    }
  }
  public async Task<List<Servicio>> ListarServicios(string consultaCodigo)
  {
    List<Servicio> servicios = new();
    using MySqlConnection connection = new MySqlConnection(_connectionString);
    MySqlCommand command = new("spConsultaListarServicios", connection)
    {
      CommandType = CommandType.StoredProcedure
    };

    command.Parameters.AddWithValue("@p_consultaCodigo", consultaCodigo);

    try
    {
      connection.Open();
      using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync()){
        
      }
      return dataTable;
    }

    catch (MySqlException ex)
    {
      _logHandler.LogFatal("No se pudo listar servicio de consulta", ex);
      throw;
    }
  }

}