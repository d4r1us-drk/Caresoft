using caresoft_integration.Services;
using caresoft_integration.Services.Interfaces;
using caresoft_integration.Context;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using caresoft_integration.Client;

namespace caresoft_integration;

public class Program(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        Configure(app, builder.Environment);

        app.Run();
    }

    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });


        var localConnectionString = configuration.GetConnectionString("LocalDB");
        //var connectionString = configuration.GetConnectionString("LocalDB");

        services.AddControllers();

        services.AddDbContext<CaresoftDbContext>(options =>
        {
            if (localConnectionString != null) options.UseMySQL(localConnectionString);
            else throw new ArgumentException("The connection string is null.");
        });

        services.AddHttpClient<CoreApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7038/"); // URL del API del core
        });

        // Registro de FallbackHttpClient
        services.AddScoped<FallbackHttpClient>(provider =>
        {
            var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
            var dbContext = provider.GetRequiredService<CaresoftDbContext>();
            var httpClient = httpClientFactory.CreateClient("CoreApiClient");
            return new FallbackHttpClient(httpClient, dbContext);
        });


        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IReservaServicioService, ReservaServicioService>();
        services.AddScoped<IConsultaService, ConsultaService>();
        services.AddScoped<IMetodoPagoService, MetodoPagoService>();
        services.AddScoped<ISalaService, SalaService>();
        services.AddScoped<ITipoServicioService, TipoServicioService>();
        services.AddScoped<IAseguradoraService, AseguradoraService>();
        services.AddScoped<IServicioService, ServicioService>();
        services.AddScoped<IIngresoService, IngresoService>();
        services.AddScoped<IProductoService, ProductoService>();
        services.AddScoped<IAutorizacionService, AutorizacionService>();
        services.AddScoped<IFacturaService, FacturaService>();
        services.AddScoped<ISucursalService, SucursalService>();
        services.AddScoped<IAfeccionService, AfeccionService>();
        services.AddScoped<IProveedorService, ProveedorService>();
        services.AddScoped<IPagoService, PagoService>();
        services.AddScoped<IConsultorioService, ConsultorioService>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void Configure(WebApplication app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowAll"); // Asegúrate de llamar a UseCors antes de UseRouting y UseEndpoints.

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}