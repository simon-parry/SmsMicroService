using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmsMessagesMicroService.Domain.Handlers.CommandHandlers;
using SmsMessagesMicroService.Domain.Handlers.QueryHandlers;
using System.Reflection;

namespace SmsMessagesMicroService.Api.DependencyInjection
{
    public static class Cqrs
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddMediatR(typeof(SendMessageCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllMessagesQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetMessagesByIdQueryHandler).GetTypeInfo().Assembly);
        }
    }
}
