using System.Threading.Tasks;

namespace BancoBari.Repository.Repository.Interfaces
{
    public interface IMessageRepository
    {
        Task SaveMessage(string message);
        Task<string> GetMessage();
    }
}