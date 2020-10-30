using BancoBari.Services.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BancoBari.JobMessage
{
    public class Worker : BackgroundService
    {
        private readonly IMessageService _messageService;
        private readonly ILogger _logger;

        public Worker(IMessageService messageService, ILogger logger)
        {
            _messageService = messageService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.Information("Iniciando a aplicação");
                    await _messageService.ProcessarMensagem();
                    await Task.Delay(5000, stoppingToken);
                }
                catch (Exception e)
                {
                    _logger.Error("Erro: " + e.Message);
                    await Task.Delay(5000, stoppingToken);
                }
            }
        }
    }
}
