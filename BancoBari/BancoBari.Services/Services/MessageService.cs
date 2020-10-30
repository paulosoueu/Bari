using BancoBari.Repository.Repository.Interfaces;
using BancoBari.Services.Models;
using BancoBari.Services.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BancoBari.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task ProcessarMensagem()
        {
            var message = new MensagemModel();
            var json = JsonConvert.SerializeObject(message);
            await Task.Run(() => Console.WriteLine(json));
        }
    }
}
