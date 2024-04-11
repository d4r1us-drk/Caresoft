using caresoft_core.Services;
using caresoft_core.Services.Interfaces;
using caresoft_core.Models;
using Microsoft.EntityFrameworkCore;

namespace caresoft_core
{
    public class Program
    {
        public IConfiguration Configuration { get; }

        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
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
            // Get the connection string
            var connectionString = configuration.GetConnectionString("CaresoftDB");

            services.AddControllers();

            // Configure DbContext
            services.AddDbContext<CaresoftDbContext>(options =>
            {
                options.UseMySQL(connectionString);
            });
        
            // Pass the connection string to UsuarioService
            services.AddScoped<IUsuarioService>(provider => new UsuarioService(
                        provider.GetRequiredService<CaresoftDbContext>()));
            services.AddScoped<IReservaServicioService>(provider => new ReservaServicioService(
                        provider.GetRequiredService<CaresoftDbContext>()));
            services.AddScoped<IConsultaService>(provider => new ConsultaService(
            provider.GetRequiredService<CaresoftDbContext>()));
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
