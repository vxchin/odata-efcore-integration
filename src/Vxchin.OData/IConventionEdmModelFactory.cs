using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Vxchin.OData
{
    /// <summary>
    /// 一个工厂接口，以可配置的方式使用 <see cref="ODataConventionModelBuilder"/>
    /// 创建 <see cref="IEdmModel"/> 对象。
    /// </summary>
    public interface IConventionEdmModelFactory : IEdmModelFactory
    {
        /// <summary>
        /// 为工厂添加一个 <see cref="IConventionEdmModelConfigurator"/> 对象表示的配置器。
        /// </summary>
        /// <param name="configurator">要添加到工厂中的配置器。</param>
        /// <returns>用于链式调用的 <see cref="IConventionEdmModelFactory"/> 对象。</returns>
        IConventionEdmModelFactory Configure(IConventionEdmModelConfigurator configurator);
    }
}