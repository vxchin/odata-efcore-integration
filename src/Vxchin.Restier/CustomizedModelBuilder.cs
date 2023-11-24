using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OData.Edm;
using Microsoft.Restier.Core.Model;
using Vxchin.Restier.Services;

namespace Vxchin.Restier
{
    public class CustomizedModelBuilder : IModelBuilder
    {
        private readonly ICollection<IModelContextCustomizer> _customizers;
        private IModelBuilder? InnerModelBuilder { get; set; }

        public CustomizedModelBuilder(IEnumerable<IModelContextCustomizer> customizers)
        {
            _customizers = customizers.ToList();
        }

        public IEdmModel GetModel(ModelContext context)
        {
            if (InnerModelBuilder is null)
                throw new InvalidOperationException($"{nameof(InnerModelBuilder)} should not be null.");
            var model = InnerModelBuilder.GetModel(context);
            foreach (var customizer in _customizers)
            {
                customizer.CustomizeModelContext(context);
            }

            return model;
        }
    }
}