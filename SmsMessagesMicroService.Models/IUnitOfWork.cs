using SmsMessagesMicroService.Models.Models;
using System;

namespace SmsMessagesMicroService.Models
{
    public interface IUnitOfWork : IDisposable
    {
        ISmsMessagesRepository SmsMessages { get; }
        int Complete();
    }
}
