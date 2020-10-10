using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace SmsMessagesMicroService.MessageSender
{
    public interface IRabbitMqConnectionFactory
    {
        IConnection CreateConnection();
    }
    public class RabbitMqConnection : IRabbitMqConnectionFactory
    {
        private readonly RabbitMqConnectionData _rabbitMqConnectionData;

        public RabbitMqConnection(IOptions<RabbitMqConnectionData> rabbitMqConnectionData)
        {
            _rabbitMqConnectionData = rabbitMqConnectionData.Value;
        }

        public IConnection CreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _rabbitMqConnectionData.Hostname,
                Port = _rabbitMqConnectionData.Port,
                UserName = _rabbitMqConnectionData.UserName,
                Password = _rabbitMqConnectionData.Password
            };

            return  factory.CreateConnection();
        }
    }
}
