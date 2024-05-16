
using Clinic.API.Middlewares;
using Clinic.Application;
using Clinic.Domain.Entities.Auth;
using Clinic.Infrastructure;
using Clinic.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Serilog;
using System.Text.Json.Serialization;

namespace Clinic.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddClinicInfrastructureDdependencyInjection(builder.Configuration);
            builder.Services.AddClinicApplicationDependencyInjection();

            builder.Services.AddRateLimiter(x =>
            {
                x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                x.AddTokenBucketLimiter("bucket", options =>
                {
                    options.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
                    options.TokenLimit = 5;
                    options.TokensPerPeriod = 20;
                    options.AutoReplenishment = true;
                });
            });

            builder.Services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<ClinincDbContext>()
               .AddDefaultTokenProviders();


            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            //builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            builder.Services.AddControllers();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseMiddleware<GlobalExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseRateLimiter();
            app.UseCors();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "User", "Doctor" };

                foreach (var role in roles)
                {
                    if (!roleManager.RoleExistsAsync(role).Result)
                    {
                        roleManager.CreateAsync(new IdentityRole(role)).Wait();
                    }
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string email = "admin@admin.com";
                string password = "Admin001!";

                if (userManager.FindByEmailAsync(email).Result == null)
                {
                    var user = new User()
                    {
                        Firsname = email,
                        Lastname = email,
                        UserName = email,
                        Email = email,
                        Role = "Admin",
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(user, password).Wait();

                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            app.Run();
        }
    }
}
