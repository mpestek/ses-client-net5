using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SESClient.EmailClient
{
    public static class Extensions
    {
        public static void AddEmailClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AWSSESConfig>(
                configuration.GetSection(AWSSESConfig.NAME));
            services.AddTransient<IEmailClient, AWSSESClient>();
        }
    }
}
