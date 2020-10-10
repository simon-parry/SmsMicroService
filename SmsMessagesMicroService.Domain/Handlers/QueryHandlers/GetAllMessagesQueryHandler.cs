using MediatR;
using SmsMessagesMicroService.Domain.Commands;
using SmsMessagesMicroService.Domain.Responses;
using SmsMessagesMicroService.Models;
using SmsMessagesMicroService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmsMessagesMicroService.Domain.Handlers.QueryHandlers
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesCommand, GetAllMessagesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllMessagesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllMessagesResponse> Handle(GetAllMessagesCommand request,
            CancellationToken cancellationToken)
        {
            var orderDetails = new GetAllMessagesResponse();

            try
            {
                var result = await _unitOfWork.SmsMessages.GetAll();
                orderDetails.SmsMessages = result.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                orderDetails.SmsMessages = new List<SmsMessages>();
            }

            return orderDetails;
        }
    }
}
