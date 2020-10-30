using BancoBari.Repository.Repository;
using BancoBari.Repository.Repository.Interfaces;
using BancoBari.Services.Services;
using BancoBari.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BancoBari.CrossCutting.DependencyInjection
{
    public static class IoC
    {
        public static void ApplyServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}
