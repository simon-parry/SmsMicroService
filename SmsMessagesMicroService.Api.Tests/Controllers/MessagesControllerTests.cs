using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SmsMessagesMicroService.Api.Controllers;
using SmsMessagesMicroService.Domain.Commands;
using SmsMessagesMicroService.Domain.Responses;
using SmsMessagesMicroService.Models.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace SmsMessagesMicroService.Api.Tests.Controllers
{
    public class MessagesControllerTests
    {
        private  Mock<IMediator> _mediatrMock;
        private MessagesController _instance;
        public MessagesControllerTests()
        {
            _mediatrMock = new Mock<IMediator>();
            _instance = new MessagesController(_mediatrMock.Object);
        }

        [Fact]
        public void TestSendMessage()
        {
            _mediatrMock
                .Setup(m => m.Send(It.IsAny<SendMessageCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new SendMessageResponseModel(){ MessageId = 1, SentToQueue = true});

            var result = _instance.SendMessage(It.IsAny<SendMessageCommand>());

            var okResult = result.Result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void TestSendMessageException()
        {
            _mediatrMock
                .Setup(m => m.Send(It.IsAny<SendMessageCommand>(), It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            Assert.ThrowsAsync<Exception>(() => _instance.SendMessage(It.IsAny<SendMessageCommand>()));
        }

        [Fact]
        public void TestGetAllMessages()
        {
           _mediatrMock
                .Setup(m => m.Send(It.IsAny<GetAllMessagesCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetAllMessagesResponse(){ SmsMessages = new List<SmsMessages>()
                    {
                        new SmsMessages()
                        {
                            MessageContent = "hello",
                            Result = 1,
                            SmsMessagesId = 1
                        },
                        new SmsMessages()
                        {
                            MessageContent = "hello 2",
                            Result = 1,
                            SmsMessagesId = 2
                        }
                    }
                }); 

            var result = _instance.GetAllMessages();


            var okResult = result.Result as OkObjectResult;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void TestGetAllMessagesException()
        {
            _mediatrMock
                .Setup(m => m.Send(It.IsAny<GetAllMessagesCommand>(), It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            Assert.ThrowsAsync<Exception>(() => _instance.GetAllMessages());
        }

        [Fact]
        public void TestGetMessagesById()
        {
            _mediatrMock
                .Setup(m => m.Send(It.IsAny<GetMessagesByIdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetMessagesByIdResponse()
                {
                    SmsMessage =
                        new SmsMessages()
                        {
                            MessageContent = "hello",
                            Result = 1,
                            SmsMessagesId = 1
                        }
                });

            var result = _instance.GetMessagesById(1);

            var okResult = result.Result as OkObjectResult;

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void TestGetMessagesByIdException()
        {
            _mediatrMock
                .Setup(m => m.Send(It.IsAny<GetMessagesByIdCommand>(), It.IsAny<CancellationToken>()))
                .Throws(new Exception());

            var result = _instance.GetMessagesById(1);

            Assert.ThrowsAsync<Exception>(() => _instance.GetMessagesById(1));
        }
    }
}
