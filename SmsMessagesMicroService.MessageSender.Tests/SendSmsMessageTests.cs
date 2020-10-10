using Microsoft.Extensions.Options;
using Moq;
using SmsMessagesMicroService.MessageSender.QueueEntities;
using Xunit;

namespace SmsMessagesMicroService.MessageSender.Tests
{
    public class SendSmsMessageTests
    {
        private readonly Mock<IOptions<RabbitMqConnection>> _rabbitMqOptions;
        private readonly SendSmsMessage _instance;

        public SendSmsMessageTests()
        {
            _rabbitMqOptions = new Mock<IOptions<RabbitMqConnection>>();

            _rabbitMqOptions.Setup(x => x.Value)
                .Returns(new RabbitMqConnection()
                {
                    Hostname = "localhost",
                    Port = 15267,
                    UserName = "admin",
                    Password = "admin",
                    QueueName = "MessagesQueue"
                });

            _instance = new SendSmsMessage(_rabbitMqOptions.Object);
        }

        [Fact]
        public void TestSuccessfullyAddingMessageToQueue()
        {

            var result = _instance.Send(It.IsAny<Sms>());

            Assert.True(result);
        }

        [Fact]
        public void TestUnSuccessfullyAddingMessageToQueue()
        {
            var result = _instance.Send(It.IsAny<Sms>());
            Assert.False(result);
        }
    }
}
