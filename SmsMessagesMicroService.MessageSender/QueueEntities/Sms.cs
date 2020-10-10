using System;
using System.Collections.Generic;
using System.Text;

namespace SmsMessagesMicroService.MessageSender.QueueEntities
{
    public class Sms
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
    }
}
