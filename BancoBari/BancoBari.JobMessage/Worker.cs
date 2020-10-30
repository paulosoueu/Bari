using BancoBari.Services.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BancoBari.JobMessage
{
    public class Worker : BackgroundService
    {
        private readonly IMessageService _messageService;

        public Worker(IMessageService messageService)
        {
            _messageService = messageService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _messageService.ProcessarMensagem();
                    await Task.Delay(5000, stoppingToken);
                }
                catch (Exception e)
                {
                    await Task.Delay(5000, stoppingToken);
                }
            }
        }
    }
}
