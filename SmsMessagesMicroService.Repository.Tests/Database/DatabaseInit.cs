using SmsMessagesMicroService.Models.Models;
using System;
using System.Linq;

namespace SmsMessagesMicroService.Repository.Tests.Database
{
    public class DatabaseInit
    {
        public static void Initialize(MessagesDbContext context)
        {
            if (context.SmsMessages.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(MessagesDbContext context)
        {
            var messages = new[]
            {
                new SmsMessages
                {
                    SmsMessagesId =1,
                    MessageContent = "Test",
                    PhoneNumber = "07498676422",
                    DateAdded = DateTime.Now,
                    DateSent = DateTime.Now,
                    Result = 1
                },
                new SmsMessages
                {
                    SmsMessagesId = 2,
                    MessageContent = "Test 2",
                    PhoneNumber = "07498676422",
                    DateAdded = DateTime.Now,
                    DateSent = DateTime.Now,
                    Result = 1
                },
                new SmsMessages
                {
                    SmsMessagesId = 3,
                    MessageContent = "Test 3",
                    PhoneNumber = "07498676422",
                    DateAdded = DateTime.Now,
                    DateSent = DateTime.Now,
                    Result = 1
                }
            };

            context.SmsMessages.AddRange(messages);
            context.SaveChanges();
        }
    }
}
