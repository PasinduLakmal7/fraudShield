using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FraudShield.Observability;

namespace FraudShield.ServiceDefaults;

public static class Extensions
{
    public static IHostApplicationBuilder AddServiceDefaults(this IHostApplicationBuilder builder, string serviceName)
    {
        builder.AddAppObservability(serviceName);
        return builder;
    }
}

