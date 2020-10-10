using SmsMessagesMicroService.Models.Models;
using System.Collections.Generic;

namespace SmsMessagesMicroService.Domain.Responses
{
    public class GetAllMessagesResponse
    {
        public List<SmsMessages> SmsMessages { get; set; } = new List<SmsMessages>();
    }
}
