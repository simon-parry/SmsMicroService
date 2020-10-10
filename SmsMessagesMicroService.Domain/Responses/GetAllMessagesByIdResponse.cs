using System;
using System.Collections.Generic;
using System.Text;
using SmsMessagesMicroService.Models.Models;

namespace SmsMessagesMicroService.Domain.Responses
{
    public class GetMessagesByIdResponse
    {
        public SmsMessages SmsMessage { get; set; } = new SmsMessages();
    }
}
