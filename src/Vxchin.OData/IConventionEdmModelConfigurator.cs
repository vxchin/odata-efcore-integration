using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Vxchin.OData
{
    /// <summary>
    /// 一个接口，用于对 <see cref="ODataConventionModelBuilder"/> 进行一组配置。
    /// </summary>
    public interface IConventionEdmModelConfigurator
    {
        /// <summary>
        /// 用于配置 <see cref="ODataConventionModelBuilder"/> 的方法。
        /// </summary>
        /// <param name="builder">基于规则创建 <see cref="IEdmModel"/> 的构造器。</param>
        public void Configure(ODataConventionModelBuilder builder);
    }
}