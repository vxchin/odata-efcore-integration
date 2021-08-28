using System;
using Microsoft.OData.ModelBuilder;
using Vxchin.OData.Internal;

namespace Vxchin.OData
{
    public static class ConventionEdmModelFactoryConfigurationExtensions
    {
        /// <summary>
        /// 为工厂添加一个由 <see cref="Action{ODataConventionModelBuilder}"/> 表示的配置器。
        /// </summary>
        /// <param name="factory"><see cref="IConventionEdmModelFactory"/> 对象。</param>
        /// <param name="configAction">一个操作，用于配置 <see cref="ODataConventionModelBuilder"/> 对象。</param>
        /// <returns>用于链式调用的 <see cref="IConventionEdmModelFactory"/> 对象。</returns>
        public static IConventionEdmModelFactory Configure(
            this IConventionEdmModelFactory factory, Action<ODataConventionModelBuilder> configAction)
        {
            factory.Configure(new DelegateConventionEdmModelConfigurator(configAction));
            return factory;
        }
    }
}