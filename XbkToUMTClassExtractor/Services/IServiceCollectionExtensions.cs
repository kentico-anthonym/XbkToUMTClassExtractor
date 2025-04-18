using Microsoft.Extensions.DependencyInjection;
using XbkToUMTClassExtractor.Extractors;

namespace XbkToUMTClassExtractor.Services;

public static class IServiceCollectionExtensions
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<DataClassExtractor>();
        services.AddSingleton<ChannelExtractor>();
    }
}
