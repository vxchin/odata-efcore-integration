using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Restier.Core;
using Microsoft.Restier.Core.Model;
using Microsoft.Restier.Core.Submit;
using Microsoft.Restier.EntityFrameworkCore;
using Vxchin.Restier;
using Vxchin.Restier.Internal;
using Vxchin.Restier.Services;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class RestierServiceCollectionExtensions
    {
        /// <summary>
        /// 添加基于 Entity Framework Core 的 Restier 数据服务。
        /// </summary>
        /// <typeparam name="TDbContext"> </typeparam>
        /// <typeparam name="TEntityFrameworkApi"></typeparam>
        /// <param name="services"></param>
        /// <param name="configDbContext"></param>
        /// <returns></returns>
        public static IServiceCollection AddEfCoreRestierDataServices<TDbContext, TEntityFrameworkApi>(
            this IServiceCollection services, Action<DbContextOptionsBuilder> configDbContext,
            Action<IEfCoreRestierApiBuilder>? configRestierApi = null) where TDbContext : DbContext
            where TEntityFrameworkApi : EntityFrameworkApi<TDbContext>
        {
            return services.AddRestier(builder => builder
                .AddRestierApi<TEntityFrameworkApi>(routeServices =>
                {
                    routeServices.AddEFCoreProviderServices<TDbContext>((_, db) =>
                        configDbContext.Invoke(db));
                    routeServices.Scan(scan =>
                        scan.FromCallingAssembly()
                            .AddClasses(classes => classes.InNamespaceOf<IModelContextCustomizer>())
                            .AsImplementedInterfaces());
                    routeServices.AddChainedService<IModelBuilder, CustomizedModelBuilder>();
                    routeServices.AddChainedService<IChangeSetItemAuthorizer, CustomizedChangeSetItemAuthorizer>();
                    ApplyRestierApiConfig(routeServices, configRestierApi);
                })).Services;
        }

        private static void ApplyRestierApiConfig(IServiceCollection routeServices,
            Action<IEfCoreRestierApiBuilder>? configRestierApi)
        {
            var restierApiBuilder = new EfCoreRestierApiBuilder(routeServices);
            configRestierApi?.Invoke(restierApiBuilder);
        }
    }
}