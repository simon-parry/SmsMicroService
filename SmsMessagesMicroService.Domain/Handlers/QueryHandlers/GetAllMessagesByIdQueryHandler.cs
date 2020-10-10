using MediatR;
using SmsMessagesMicroService.Domain.Commands;
using SmsMessagesMicroService.Domain.Responses;
using SmsMessagesMicroService.Models;
using SmsMessagesMicroService.Models.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmsMessagesMicroService.Domain.Handlers.QueryHandlers
{
    public class GetMessagesByIdQueryHandler : IRequestHandler<GetMessagesByIdCommand, GetMessagesByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMessagesByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetMessagesByIdResponse> Handle(GetMessagesByIdCommand request, CancellationToken cancellationToken)
        {
            var orderDetails = new GetMessagesByIdResponse();

            try
            {
                var result = await _unitOfWork.SmsMessages.GetById(request.SmsMessageId);
                orderDetails.SmsMessage = result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                orderDetails.SmsMessage = new SmsMessages();
            }

            return orderDetails;
        }
    }
}
