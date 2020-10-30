using System;

namespace BancoBari.Services.Models
{
    public class MensagemModel
    {
        public string mensagem { get { return "Hello World"; } }
        public string id { get { return "Bari Microservico"; } }
        public DateTime timeStamp { get { return DateTime.Now; } }
        public string idRequisicao { get { return new Random().Next().ToString(); } }
    }
}
