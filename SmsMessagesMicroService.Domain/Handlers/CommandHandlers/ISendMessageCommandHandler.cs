using SmsMessagesMicroService.Domain.Commands;
using SmsMessagesMicroService.Domain.Responses;

namespace SmsMessagesMicroService.Domain.Handlers.CommandHandlers
{
    public interface ISendMessageCommandHandler
    {
        SendMessageResponseModel SendMessage(SendMessageCommand requestModel);
    }
}