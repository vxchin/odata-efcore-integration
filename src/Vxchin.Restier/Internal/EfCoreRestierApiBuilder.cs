using Microsoft.Extensions.DependencyInjection;

namespace Vxchin.Restier.Internal
{
    internal class EfCoreRestierApiBuilder : IEfCoreRestierApiBuilder
    {
        public EfCoreRestierApiBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}