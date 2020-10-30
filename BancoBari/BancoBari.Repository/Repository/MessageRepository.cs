using BancoBari.Repository.AWSRepository.Interface;
using BancoBari.Repository.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BancoBari.Repository.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IAwsRepository _awsRepository;

        public MessageRepository(IAwsRepository awsRepository)
        {
            _awsRepository = awsRepository;
        }

        public async Task SaveMessage(string message)
        {
            await _awsRepository.SetSQS(message);
        }

        public async Task<string> GetMessage()
        {
            var message = await _awsRepository.GetSqs();
            return message.Messages.FirstOrDefault().Body;
        }
    }
}
