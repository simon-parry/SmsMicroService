using SmsMessagesMicroService.Models;
using SmsMessagesMicroService.Models.Models;
using System;

namespace SmsMessagesMicroService.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MessagesDbContext _messagesDbContext;
        public ISmsMessagesRepository SmsMessages { get; }

        public UnitOfWork(MessagesDbContext messagesDbContext)
        {
            _messagesDbContext = messagesDbContext;
            SmsMessages = new SmsMessagesRepository(_messagesDbContext);
        }
        public int Complete()
        {
            return _messagesDbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _messagesDbContext.Dispose();
            }
        }
    }
}
