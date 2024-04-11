using System.Data;
using caresoft_core.Models;
using caresoft_core.Services.Interfaces;
using caresoft_core.Utils;
using MySql.Data.MySqlClient;

namespace caresoft_core.Services;

public class ConsultaService : IConsultaService
{
  private CaresoftDbContext _dbContext;
  private readonly LogHandler<ConsultaService> _logHandler = new ();
  public ConsultaService(CaresoftDbContext dbContext)
  {
    _dbContext = dbContext;
    _connectionString = connectionString;
  }
  public async Task<int> CrearConsulta(string consultaCodigo, string documentoPaciente, string documentoMedico, int idConsultorio, string motivo, string comentarios, decimal costo, string estado)
  {
    var consulta = new Consulta
    {
      ConsultaCodigo = consultaCodigo,
      DocumentoPaciente = documentoPaciente,
      DocumentoMedico = documentoMedico,
      IdConsultorio = idConsultorio,
      Motivo = motivo,
      Comentarios = comentarios,
      Costo = costo,
      Estado = estado
    };
    _dbContext.Consultas.Add(consulta);
    try
    {
      return await _dbContext.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
      _logHandler.LogFatal("No se pudo crear la consulta", ex);
      throw;
    }
  }
  public async Task<int> ActualizarConsulta(string consultaCodigo, string documentoPaciente, string documentoMedico, int idConsultorio, string motivo, string comentarios, decimal costo)
  {
    var consulta = await _dbContext.Consultas.FindAsync(consultaCodigo);

    if (consulta == null)
    {
      return 0;
    }
    consulta.DocumentoPaciente = documentoPaciente;
    consulta.DocumentoMedico = documentoMedico;
    consulta.IdConsultorio = idConsultorio;
    consulta.Motivo = motivo;
    consulta.Comentarios = comentarios;
    consulta.Costo = costo;
    try
    {
      return await _dbContext.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
      _logHandler.LogFatal("No se pudo actualizar la consulta", ex);
      throw;
    }

  }
  public async Task<int> EliminarConsulta(string consultaCodigo)
  {
    var consulta = await _dbContext.Consultas.FindAsync(consultaCodigo);
    if (consulta == null)
    {
      return 0;
    }
    _dbContext.Consultas.Remove(consulta);
    try
    {
      return await _dbContext.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
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
      using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
      {

      }
      return dataTable;
    }

    catch (MySqlException ex)
    {
      _logHandler.LogFatal("No se pudo listar servicio de consulta", ex);
      throw;
    }
  }
  int RelacionarProducto(string consultaCodigo, int idProducto, int cantidad)
  {
    throw new NotImplementedException();
  }
  int DesrelacionarProducto(string consultaCodigo, int idProducto, int cantidad)
  {
    throw new NotImplementedException();
  }
  List<Producto> ListarProductos(string consultaCodigo)
  {

    throw new NotImplementedException();
  }
  int RelacionarAfeccion(string consultaCodigo, int idAfeccion)
  {

    throw new NotImplementedException();
  }
  int DesrelacionarAfeccion(string consultaCodigo, int idAfeccion)
  {
    throw new NotImplementedException();
  }
  List<Afeccion> ListarAfecciones(string consultaCodigo)
  {
    throw new NotImplementedException();
  }
  List<Consulta> ListarConsultas(string documentoPaciente, string documentoMedico, DateTime fechaInicio, DateTime fechaFin)
  {
    throw new NotImplementedException();

  }

}