using Microsoft.Restier.Core.Model;

namespace Vxchin.Restier.Services
{
    public interface IModelContextCustomizer
    {
        void CustomizeModelContext(ModelContext context);
    }
}