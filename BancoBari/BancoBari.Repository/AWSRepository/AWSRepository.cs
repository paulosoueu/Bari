using Amazon.SQS;
using Amazon.SQS.Model;
using BancoBari.Repository.AWSRepository.Interface;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BancoBari.Repository.AWSRepository
{
    public class AwsRepository : IAwsRepository
    {
        private AwsContext _context { get; }
        private readonly IConfiguration _configuration;
        private readonly AmazonSQSClient _awsSQSClient;

        public AwsRepository(AwsContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _awsSQSClient = _context.SQSClient();
        }

        public async Task<ReceiveMessageResponse> GetSqs()
        {
            ReceiveMessageRequest receiveMessageRequest = new ReceiveMessageRequest();
            receiveMessageRequest.QueueUrl = _configuration["Amazon:SQS:UrlReceive"];
            receiveMessageRequest.MaxNumberOfMessages = 1;
            ReceiveMessageResponse resp = await _awsSQSClient.ReceiveMessageAsync(receiveMessageRequest);
            return resp;
        }

        public async Task<SendMessageResponse> SetSQS(string dados, int delay = 0)
        {
            SendMessageRequest sendRequest = new SendMessageRequest();
            sendRequest.QueueUrl = _configuration["Amazon:SQS:UrlSend"];
            sendRequest.MessageBody = dados;
            sendRequest.DelaySeconds = delay;
            var result = await _awsSQSClient.SendMessageAsync(sendRequest);
            return result;
        }

    }
}
