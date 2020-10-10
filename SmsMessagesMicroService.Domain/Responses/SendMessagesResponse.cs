using System;
using System.Collections.Generic;
using System.Text;

namespace SmsMessagesMicroService.Domain.Responses
{
    public class SendMessageResponseModel
    {
        public bool SentToQueue { get; set; }
        public int MessageId { get; set; }
    }
}
