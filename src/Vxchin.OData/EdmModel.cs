using Microsoft.OData.Edm;
using Vxchin.OData.Internal;

namespace Vxchin.OData
{
    /// <summary>
    /// 用于创建 <see cref="IEdmModel"/> 对象的静态入口。
    /// </summary>
    public static class EdmModel
    {
        /// <summary>
        /// 创建一个基于规则的 <see cref="IEdmModel"/> 工厂。
        /// </summary>
        /// <returns>创建的 <see cref="IConventionEdmModelFactory"/> 工厂。</returns>
        public static IConventionEdmModelFactory CreateConventionFactory() => new DefaultConventionEdmModelFactory();
    }
}