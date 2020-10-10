using Moq;
using SmsMessagesMicroService.Domain.Commands;
using SmsMessagesMicroService.Domain.Handlers.QueryHandlers;
using SmsMessagesMicroService.Models;
using SmsMessagesMicroService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SmsMessagesMicroService.Domain.Tests.Handlers.QueryHandlers
{
    public class GetAllMessagesQueryHandlerTests
    {
        private readonly GetAllMessagesQueryHandler _instance;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GetAllMessagesQueryHandlerTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _instance = new GetAllMessagesQueryHandler(_unitOfWork.Object);
        }

        [Fact]
        public void TestCanGettingAllMessagesAndExceptionOccurs()
        {
            var request = new GetAllMessagesCommand();
            var cancellationToken = CancellationToken.None;

            var result = _instance.Handle(request, cancellationToken);

            Assert.Empty(result.Result.SmsMessages);
        }

        [Fact]
        public void TestCanGettingAllMessages()
        {
            var request = new GetAllMessagesCommand();
            var cancellationToken = CancellationToken.None;

            IEnumerable<SmsMessages> messages = new List<SmsMessages>
            {
                new SmsMessages
                {
                    DateSent = DateTime.Now,
                    DateAdded = DateTime.Now,
                    MessageContent = "Test Message",
                    PhoneNumber = "0749638765",
                    Result = 1,
                    ResponseDate = DateTime.UtcNow,
                    SmsMessagesId = 1
                },
                new SmsMessages
                {
                    DateSent = DateTime.Now,
                    DateAdded = DateTime.Now,
                    MessageContent = "Test Message 2",
                    PhoneNumber = "0749638765",
                    Result = 1,
                    ResponseDate = DateTime.UtcNow,
                    SmsMessagesId = 2
                }
            };

            _unitOfWork.Setup(x => x.SmsMessages.GetAll()).Returns(Task.FromResult(messages));

            var result = _instance.Handle(request, cancellationToken);

            Assert.NotEmpty(result.Result.SmsMessages);
            Assert.Equal(2, result.Result.SmsMessages.Count);
            Assert.Equal("0749638765", result.Result.SmsMessages.First().PhoneNumber);
        }
    }
}
