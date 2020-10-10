using Microsoft.Extensions.Options;
using Moq;
using RabbitMQ.Client;
using SmsMessagesMicroService.MessageSender.QueueEntities;
using Xunit;

namespace SmsMessagesMicroService.MessageSender.Tests
{
    public class SendSmsMessageTests
    {
        private readonly Mock<IOptions<RabbitMqConnectionData>> _rabbitMqOptions;
        private readonly Mock<IRabbitMqConnectionFactory> _connectionFactory;
        private SendSmsMessage _instance;

        public SendSmsMessageTests()
        {
            _rabbitMqOptions = new Mock<IOptions<RabbitMqConnectionData>>();
            _rabbitMqOptions.Setup(x => x.Value)
                .Returns(new RabbitMqConnectionData()
                {
                    Hostname = "localhost",
                    Port = 15267,
                    UserName = "admin",
                    Password = "admin",
                    QueueName = "MessagesQueue"
                });

            _connectionFactory = new Mock<IRabbitMqConnectionFactory>();
        }

        [Fact]
        public void TestSuccessfullyAddingMessageToQueue()
        {
            var connection = new Mock<IConnection>();
            var model = new Mock<IModel>();
            _instance = new SendSmsMessage(_rabbitMqOptions.Object, _connectionFactory.Object);
            _connectionFactory.Setup(x => x.CreateConnection()).Returns(connection.Object);
            connection.Setup(x => x.CreateModel()).Returns(model.Object);

            var result = _instance.Send(It.IsAny<Sms>());

            Assert.True(result);
        }

        [Fact]
        public void TestUnSuccessfullyAddingMessageToQueue()
        {
            _instance = new SendSmsMessage(_rabbitMqOptions.Object, _connectionFactory.Object);

            var result = _instance.Send(It.IsAny<Sms>());

            Assert.False(result);
        }
    }
}
