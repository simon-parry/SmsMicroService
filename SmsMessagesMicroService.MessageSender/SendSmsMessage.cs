using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SmsMessagesMicroService.MessageSender.QueueEntities;
using System;
using System.Text;

namespace SmsMessagesMicroService.MessageSender
{
    public class SendSmsMessage : ISendSmsMessage
    {
        private readonly RabbitMqConnectionData _rabbitMqConnectionData;
        private readonly IRabbitMqConnectionFactory _factory;

        public SendSmsMessage(IOptions<RabbitMqConnectionData> rabbitMqConnectionData,
            IRabbitMqConnectionFactory factory)
        {
            _rabbitMqConnectionData = rabbitMqConnectionData.Value;
            _factory = factory;
        }

        public bool Send(Sms message)
        {
            try
            {
                using (var connection = _factory.CreateConnection())
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _rabbitMqConnectionData.QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var json = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "", routingKey: _rabbitMqConnectionData.QueueName, basicProperties: null, body: body);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}
