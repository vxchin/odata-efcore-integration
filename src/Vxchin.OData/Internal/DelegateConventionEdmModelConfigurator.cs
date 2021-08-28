using System;
using Microsoft.OData.ModelBuilder;

namespace Vxchin.OData.Internal
{
    internal class DelegateConventionEdmModelConfigurator : IConventionEdmModelConfigurator
    {
        private readonly Action<ODataConventionModelBuilder> _configAction;

        public DelegateConventionEdmModelConfigurator(Action<ODataConventionModelBuilder> configAction)
        {
            _configAction = configAction ?? throw new ArgumentNullException(nameof(configAction));
        }
        public void Configure(ODataConventionModelBuilder builder)
        {
            _configAction.Invoke(builder);
        }
    }
}