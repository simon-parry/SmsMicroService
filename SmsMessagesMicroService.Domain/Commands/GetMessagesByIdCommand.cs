using MediatR;
using SmsMessagesMicroService.Domain.Responses;

namespace SmsMessagesMicroService.Domain.Commands
{
    public class GetMessagesByIdCommand : IRequest<GetMessagesByIdResponse>
    {
        public GetMessagesByIdCommand(int smsMessageId)
        {
            SmsMessageId = smsMessageId;
        }
        public int SmsMessageId { get; set; }
    }
}
