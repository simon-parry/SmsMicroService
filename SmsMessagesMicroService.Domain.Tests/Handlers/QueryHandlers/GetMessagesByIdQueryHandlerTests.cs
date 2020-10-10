using Moq;
using SmsMessagesMicroService.Domain.Commands;
using SmsMessagesMicroService.Domain.Handlers.QueryHandlers;
using SmsMessagesMicroService.Models;
using SmsMessagesMicroService.Models.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SmsMessagesMicroService.Domain.Tests.Handlers.QueryHandlers
{
    public class GetMessagesByIdQueryHandlerTests
    {
        private readonly GetMessagesByIdQueryHandler _instance;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GetMessagesByIdQueryHandlerTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _instance = new GetMessagesByIdQueryHandler(_unitOfWork.Object);
        }

        [Fact]
        public void TestCanGettingMessagesByIdAndExceptionOccurs()
        {
            var request = new GetMessagesByIdCommand(2);

            var cancellationToken = CancellationToken.None;

            var result = _instance.Handle(request, cancellationToken);

            Assert.Null(result.Result.SmsMessage.PhoneNumber);
            Assert.Null(result.Result.SmsMessage.MessageContent);
            Assert.Equal(0, result.Result.SmsMessage.SmsMessagesId);
            Assert.Equal(0, result.Result.SmsMessage.Result);
        }

        [Fact]
        public void TestCanGettingMessageById()
        {
            var request = new GetMessagesByIdCommand(2);
            var cancellationToken = CancellationToken.None;

            var message = 
                new SmsMessages
                {
                    DateSent = DateTime.Now,
                    DateAdded = DateTime.Now,
                    MessageContent = "Test Message",
                    PhoneNumber = "0749638765",
                    Result = 1,
                    ResponseDate = DateTime.UtcNow,
                    SmsMessagesId = 2
                };

            _unitOfWork.Setup(x => x.SmsMessages.GetById(2)).Returns(Task.FromResult(message));

            var result = _instance.Handle(request, cancellationToken);

            Assert.Equal("0749638765", result.Result.SmsMessage.PhoneNumber);
            Assert.Equal("Test Message", result.Result.SmsMessage.MessageContent);
            Assert.Equal(2, result.Result.SmsMessage.SmsMessagesId);
            Assert.Equal(1, result.Result.SmsMessage.Result);
        }
    }
}
