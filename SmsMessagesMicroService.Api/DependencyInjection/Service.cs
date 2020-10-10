using Microsoft.Extensions.DependencyInjection;
using SmsMessagesMicroService.MessageSender;

namespace SmsMessagesMicroService.Api.DependencyInjection
{
    public static class Services
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<ISendSmsMessage, SendSmsMessage>();
        }
    }
}
