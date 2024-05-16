using Clinic.Application.UseCases.AuthService;
using Clinic.Application.UseCases.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Clinic.Application
{
    public static class ClinicApplicationDependencyInjection
    {
        public static IServiceCollection AddClinicApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddDistributedMemoryCache();

            services.AddSingleton<TelegramBotClient>(provider =>
            {
                var botToken = $"6492471980:AAFosOuFQ8-UDMWpuHVawVHWUE-1j_Y1phA";
                return new TelegramBotClient(botToken);
            });

            services.AddSingleton<IWriteToTelegramBotService,WriteToTelegramBotService>();

            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
