using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Vxchin.Restier
{
    /// <summary>
    /// 表示一个 Entity Framework Core Restier API 构建器。
    /// </summary>
    public interface IEfCoreRestierApiBuilder
    {
        /// <summary>
        /// 获取服务集合。
        /// </summary>
        public IServiceCollection Services { get; }
    }
}