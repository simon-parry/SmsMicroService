using System;

namespace SmsMessagesMicroService.Models.Models
{
    public class SmsMessages
    {
        public int SmsMessagesId { get; set; }
        public string PhoneNumber { get; set; }
        public string MessageContent { get; set; }
        public int Result { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime ResponseDate { get; set; }
    }
}
