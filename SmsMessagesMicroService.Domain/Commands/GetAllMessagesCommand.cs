using MediatR;
using SmsMessagesMicroService.Domain.Responses;

namespace SmsMessagesMicroService.Domain.Commands
{
    public class GetAllMessagesCommand : IRequest<GetAllMessagesResponse>
    {
    }
}
