using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using asp_presentacion.Data;

namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Comunicaciones
            services.AddScoped<IEstadosComunicacion, EstadosComunicacion>();
            services.AddScoped<IFabricantesComunicacion, FabricantesComunicacion>();
            services.AddScoped<IImagenesComunicacion, ImagenesComunicacion>();
            services.AddScoped<IProductosComunicacion, ProductosComunicacion>();
            services.AddScoped<IPublicacionesComunicacion, PublicacionesComunicacion>();
            services.AddScoped<ICategoriasComunicacion, CategoriasComunicacion>();
            // Presentaciones
            services.AddScoped<IEstadosPresentacion, EstadosPresentacion>();
            services.AddScoped<IFabricantesPresentacion, FabricantesPresentacion>();
            services.AddScoped<IImagenesPresentacion, ImagenesPresentacion>();
            services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
            services.AddScoped<IPublicacionesPresentacion, PublicacionesPresentacion>();
            services.AddScoped<ICategoriasPresentacion, CategoriasPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddDbContext<asp_presentacionContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("asp_presentacionContext")));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}