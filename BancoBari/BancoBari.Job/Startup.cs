using BancoBari.Repository.Repository;
using BancoBari.Repository.Repository.Interfaces;
using BancoBari.Services.Services;
using BancoBari.Services.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BancoBari.Job
{
    public class Startup
    {
        private readonly IConfigurationRoot Configuration;

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }


    }
}
