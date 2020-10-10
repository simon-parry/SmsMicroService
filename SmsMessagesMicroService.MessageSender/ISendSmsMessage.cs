using SmsMessagesMicroService.MessageSender.QueueEntities;

namespace SmsMessagesMicroService.MessageSender
{
    public interface ISendSmsMessage
    {
        bool Send(Sms message);
    }
}