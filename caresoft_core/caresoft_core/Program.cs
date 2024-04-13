using caresoft_core.Services;
using caresoft_core.Services.Interfaces;
using caresoft_core.Context;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core
{
    public class Program
    {
        private readonly IConfiguration _configuration;

        public Program(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
            var connectionString = configuration.GetConnectionString("CaresoftDB");

            services.AddControllers();

            services.AddDbContext<CaresoftDbContext>(options =>
            {
                if (connectionString != null) options.UseMySQL(connectionString);
                else throw new ArgumentException("The connection string is null.");
            });

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IReservaServicioService, ReservaServicioService>();
            services.AddScoped<IConsultaService, ConsultaService>();
            services.AddScoped<IMetodoPagoService, MetodoPagoService>();
            services.AddScoped<IAseguradoraService, AseguradoraService>();
            services.AddScoped<IIngresoService, IngresoService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IAutorizacionService, AutorizacionService>();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
