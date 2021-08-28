using Microsoft.OData.Edm;

namespace Vxchin.OData
{
    /// <summary>
    /// 一个工厂接口，用于创建 <see cref="IEdmModel"/> 对象。
    /// </summary>
    public interface IEdmModelFactory
    {
        /// <summary>
        /// 创建 <see cref="IEdmModel"/> 对象。
        /// </summary>
        /// <returns>创建的 <see cref="IEdmModel"/> 对象。</returns>
        IEdmModel CreateEdmModel();
    }
}