using Microsoft.Extensions.DependencyInjection;
using SmsMessagesMicroService.Models;
using SmsMessagesMicroService.Models.Models;
using SmsMessagesMicroService.Repository;

namespace SmsMessagesMicroService.Api.DependencyInjection
{
    public static class Database
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<ISmsMessagesRepository, SmsMessagesRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
