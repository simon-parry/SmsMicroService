using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SmsMessagesMicroService.Domain.Responses;

namespace SmsMessagesMicroService.Domain.Commands
{
    public class SendMessageCommand : IRequest<SendMessageResponseModel>
    {
        public string ContactNumber { get; set; }
        public string MessageContent { get; set; }
    }
}
