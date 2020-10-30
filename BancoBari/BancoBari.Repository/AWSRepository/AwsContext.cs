using Amazon.Runtime;
using Amazon.SQS;
using Microsoft.Extensions.Configuration;
using System;

namespace BancoBari.Repository.AWSRepository
{
    public class AwsContext
    {
        private AmazonSQSClient sqsClient;

        public AwsContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        public AmazonSQSClient SQSClient()
        {
            BasicAWSCredentials awsCred;

            if (sqsClient == null)
            {
                var config = new AmazonSQSConfig();
                config.RegionEndpoint = Amazon.RegionEndpoint.USEast1;
                config.Timeout = TimeSpan.FromSeconds(30);
                config.MaxErrorRetry = 3;
                awsCred = new BasicAWSCredentials(_configuration["Amazon:AccessKey"]
                    , _configuration["Amazon:SecretKey"]);
                sqsClient = new AmazonSQSClient(awsCred, config);
            }
            return sqsClient;
        }

    }
}
