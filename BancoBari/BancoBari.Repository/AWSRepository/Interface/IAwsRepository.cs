using Amazon.SQS.Model;
using System.Threading.Tasks;

namespace BancoBari.Repository.AWSRepository.Interface
{
    public interface IAwsRepository
    {
        Task<ReceiveMessageResponse> GetSqs();
        Task<SendMessageResponse> SetSQS(string dados, int delay = 0);
    }
}