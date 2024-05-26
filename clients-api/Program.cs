
using GC.BL;
using GC.DAL.EF;
using GC.Entites;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

namespace clients_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            Console.Out.WriteLine("Connection string : " + connectionString);
            Console.Out.WriteLine("Début configuration de l'injection de dépendances.");

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();

            // Désactivation des validations cors pour simplifier les tests
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                       builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("clients-api").EnableRetryOnFailure()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            builder.Services.AddScoped<IDepotClients, DepotClientsEF>();
            builder.Services.AddScoped<GestionClientsBL>();

            var app = builder.Build();

                 using (var scope = app.Services.CreateScope())
                 {
                     using (var context = scope.ServiceProvider.GetService<ApplicationDbContext>())
                     {
                         context!.Database.Migrate();
                     }
                 }

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseAuthorization();

            app.MapHealthChecks("/healthz/live", new HealthCheckOptions
            {
                Predicate = healthCheck => !healthCheck.Tags.Contains("db")
            });

            app.MapControllers();

            app.Run();
        }
    }
}
