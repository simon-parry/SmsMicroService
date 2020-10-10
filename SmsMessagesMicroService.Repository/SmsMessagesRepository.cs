using SmsMessagesMicroService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmsMessagesMicroService.Repository
{
    public class SmsMessagesRepository : Repository<SmsMessages>, ISmsMessagesRepository
    {
        public SmsMessagesRepository(MessagesDbContext context) : base(context)
        {
        }

        public IEnumerable<SmsMessages> GetMessagesByDate(DateTime date)
        {
            return Context.SmsMessages.Where(x => x.DateAdded == DateTime.Today);
        }
    }
}
