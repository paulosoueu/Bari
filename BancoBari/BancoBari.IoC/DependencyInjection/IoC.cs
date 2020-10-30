using BancoBari.Repository.AWSRepository;
using BancoBari.Repository.AWSRepository.Interface;
using BancoBari.Repository.Repository;
using BancoBari.Repository.Repository.Interfaces;
using BancoBari.Services.Services;
using BancoBari.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace BancoBari.CrossCutting.DependencyInjection
{
    public static class IoC
    {
        public static void ApplyServices(IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IAwsRepository, AwsRepository>();

            services.AddSingleton<AwsContext>();

            SerilogApplyService(services);
        }

        private static void SerilogApplyService(IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}
