using BancoBari.Repository.Repository.Interfaces;
using BancoBari.Services.Models;
using BancoBari.Services.Services.Interfaces;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Threading.Tasks;

namespace BancoBari.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;
        private readonly ILogger _logger;

        public MessageService(IMessageRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task ProcessarMensagem()
        {
            var message = new MensagemModel();
            var json = JsonConvert.SerializeObject(message);

            _logger.Information("Gravando a mensagem no SQS.");
            await _repository.SaveMessage(json);
            
            await Task.Run(() => Console.WriteLine(json));

            _logger.Information("Verificando mensagem na fila do SQS.");
            var messageAws = await GetMessageSQS();
            if (!string.IsNullOrEmpty(messageAws))
            {
                await Task.Run(() => Console.WriteLine(messageAws));
            }
        }

        private async Task<string> GetMessageSQS()
        {
            var retorno = await _repository.GetMessage();
            return retorno;
        }
    }
}
