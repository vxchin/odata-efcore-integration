using Microsoft.AspNet.OData.Extensions;
using Microsoft.Restier.AspNetCore;
using Microsoft.Restier.Core;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public static class RestierApplicationBuilderExtensions
    {
        /// <summary>
        /// 启用 Restier 数据服务。该方法需在 UseEndpoints 前调用。
        /// </summary>
        public static IApplicationBuilder UseRestierDataServices<TEntityFrameworkApi>(this IApplicationBuilder app) where TEntityFrameworkApi : ApiBase
        {
            return app.UseMvc(route =>
            {
                route.Select().Expand().Filter().OrderBy().MaxTop(null).Count();
                route.MapRestier(restier => restier.MapApiRoute<TEntityFrameworkApi>("odata", "odata"));
            });
        }
    }
}
