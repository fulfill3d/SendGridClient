using Client.Interfaces;
using Client.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public static class DepInj
    {
        public static void RegisterSendGridClient(this IServiceCollection services,
            Action<SendGridOptions> configureSendGridOptions)
        {
            services.ConfigureServiceOptions<SendGridOptions>((_, opt) => configureSendGridOptions(opt));
            services.AddTransient<ISendGridClient, SendGridClient>();
        }

        private static void ConfigureServiceOptions<TOptions>(
            this IServiceCollection services,
            Action<IServiceProvider, TOptions> configure)
            where TOptions : class
        {
            services
                .AddOptions<TOptions>()
                .Configure<IServiceProvider>((options, resolver) => configure(resolver, options));
        }
    }
}