using Moq;
using SmsMessagesMicroService.Domain.Commands;
using SmsMessagesMicroService.Domain.Handlers.CommandHandlers;
using SmsMessagesMicroService.MessageSender;
using SmsMessagesMicroService.MessageSender.QueueEntities;
using SmsMessagesMicroService.Models;
using SmsMessagesMicroService.Models.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SmsMessagesMicroService.Domain.Tests.Handlers.CommandHandlers
{
    public class SendMessageCommandHandlerTests
    {
        private readonly SendMessageCommandHandler _instance;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<ISendSmsMessage> _sendSmsMessage;
        private readonly SendMessageCommand _request;
        private readonly CancellationToken _cancellationToken;

        public SendMessageCommandHandlerTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _sendSmsMessage = new Mock<ISendSmsMessage>();

            _instance = new SendMessageCommandHandler(_unitOfWork.Object, _sendSmsMessage.Object);

            _request = new SendMessageCommand() { ContactNumber = "07496765345", MessageContent = "TestMessage"};

            _cancellationToken = CancellationToken.None;
        }
         
        [Fact]
        public void TestSendingMessageAndExceptionOccurs()
        {
            var result = _instance.Handle(_request, _cancellationToken);

            Assert.False(result.Result.SentToQueue);
            Assert.Equal(-1, result.Result.MessageId);
        }

        [Fact]
        public void TestSendingMessageSuccessfully()
        {
            var msg = new SmsMessages
            {
                DateSent = DateTime.Now,
                DateAdded = DateTime.Now,
                MessageContent = "TestMessage",
                PhoneNumber = "07496765345",
                Result = 1,
                ResponseDate = DateTime.UtcNow
            };

            _unitOfWork.Setup(x => x.SmsMessages.Add(msg)).Returns(Task.FromResult(msg));

            _sendSmsMessage.Setup(x => x.Send(It.IsAny<Sms>())).Returns(true);

            var result = _instance.Handle(_request, _cancellationToken);

            Assert.True(result.Result.SentToQueue);
        }

        [Fact]
        public void TestSendingMessageUnSuccessfully()
        {
            var msgResult = new SmsMessages
            {
                DateSent = DateTime.Now,
                DateAdded = DateTime.Now,
                MessageContent = "TestMessage",
                PhoneNumber = "07496765345",
                Result = 1,
                ResponseDate = DateTime.UtcNow,
                SmsMessagesId = 6
            };

            _unitOfWork.Setup(x => x.SmsMessages.Add(It.IsAny<SmsMessages>())).Returns(Task.FromResult(msgResult));

            _sendSmsMessage.Setup(x => x.Send(It.IsAny<Sms>())).Returns(false);

            var result = _instance.Handle(_request, _cancellationToken);

            Assert.False(result.Result.SentToQueue);
        }
    }
}
