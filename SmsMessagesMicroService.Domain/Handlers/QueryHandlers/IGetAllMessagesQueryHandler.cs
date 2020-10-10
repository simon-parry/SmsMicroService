using SmsMessagesMicroService.Domain.Commands;
using SmsMessagesMicroService.Domain.Responses;

namespace SmsMessagesMicroService.Domain.Handlers.QueryHandlers
{ 
    public interface IGetAllMessagesQueryHandler
    {
        GetAllMessagesResponse GetAllMessages(GetAllMessagesCommand requestModel);
    }
}