using BancoBari.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BancoBari.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service;
        }


        public void getMessages()
        {

        }
    }
}