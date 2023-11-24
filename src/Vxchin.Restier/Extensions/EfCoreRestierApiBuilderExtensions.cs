using System;
using Microsoft.Extensions.DependencyInjection;

namespace Vxchin.Restier
{
    public static class EfCoreRestierApiBuilderExtensions
    {
        public static IEfCoreRestierApiBuilder ConfigEntitySetFiltering(this IEfCoreRestierApiBuilder builder,
            Action<EntitySetFilteringOptions> configOptions)
        {
            builder.Services.Configure(configOptions);
            return builder;
        }
    }
}