using MediatR;
using SmsMessagesMicroService.Domain.Commands;
using SmsMessagesMicroService.Domain.Responses;
using SmsMessagesMicroService.MessageSender;
using SmsMessagesMicroService.MessageSender.QueueEntities;
using SmsMessagesMicroService.Models;
using SmsMessagesMicroService.Models.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmsMessagesMicroService.Domain.Handlers.CommandHandlers
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, SendMessageResponseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISendSmsMessage _sendSmsMessage;

        public SendMessageCommandHandler(IUnitOfWork unitOfWork, ISendSmsMessage sendSmsMessage)
        {
            _unitOfWork = unitOfWork;
            _sendSmsMessage = sendSmsMessage;
        }

        public async Task<SendMessageResponseModel> Handle(SendMessageCommand request,
            CancellationToken cancellationToken)
        {
            bool result = false;
            var msg = new SmsMessages
            {
                DateSent = DateTime.Now,
                DateAdded = DateTime.Now,
                MessageContent = request.MessageContent,
                PhoneNumber = request.ContactNumber,
                Result = 1,
                ResponseDate = DateTime.UtcNow
            };

            try
            {
                await _unitOfWork.SmsMessages.Add(msg);

                _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new SendMessageResponseModel
                {
                    SentToQueue = false,
                    MessageId = -1
                };
            }

            result = _sendSmsMessage.Send(new Sms { Message = request.MessageContent, PhoneNumber = request.ContactNumber, MessageId = msg.SmsMessagesId });

            return new SendMessageResponseModel
            {
                SentToQueue = result,
                MessageId = msg.SmsMessagesId
            };
        }
    }
}
