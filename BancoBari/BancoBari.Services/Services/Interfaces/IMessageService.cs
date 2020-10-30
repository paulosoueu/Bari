using System.Threading.Tasks;

namespace BancoBari.Services.Services.Interfaces
{
    public interface IMessageService
    {
        Task ProcessarMensagem();
    }
}