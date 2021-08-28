using System.Collections.Generic;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Vxchin.OData.Internal
{
    internal class DefaultConventionEdmModelFactory : IConventionEdmModelFactory
    {
        private readonly IList<IConventionEdmModelConfigurator> _configurators;

        public DefaultConventionEdmModelFactory()
        {
            _configurators = new List<IConventionEdmModelConfigurator>();
        }

        public IEdmModel CreateEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            foreach (var configurator in _configurators)
            {
                configurator.Configure(builder);
            }
            return builder.GetEdmModel();
        }

        public IConventionEdmModelFactory Configure(IConventionEdmModelConfigurator configurator)
        {
            _configurators.Add(configurator);
            return this;
        }
    }
}