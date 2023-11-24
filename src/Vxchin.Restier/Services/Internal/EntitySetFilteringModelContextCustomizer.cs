using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.Restier.Core.Model;

namespace Vxchin.Restier.Services.Internal
{
    internal class EntitySetFilteringModelContextCustomizer : IModelContextCustomizer
    {
        private readonly EntitySetFilteringOptions _options;

        public EntitySetFilteringModelContextCustomizer(IOptions<EntitySetFilteringOptions> options)
        {
            _options = options.Value;
        }
        public void CustomizeModelContext(ModelContext context)
        {
            var resourceSetTypeMap = context.ResourceSetTypeMap;
            if (resourceSetTypeMap is null) return;
            FilterEntitySetTypes(_options.EntityTypeNames, resourceSetTypeMap);
        }

        private static void FilterEntitySetTypes(ICollection<string> entityTypeNames, IDictionary<string, Type> resourceSetTypeMap)
        {
            foreach (var typeMapKey in resourceSetTypeMap.Keys)
            {
                if (!entityTypeNames.Contains(typeMapKey))
                {
                    resourceSetTypeMap.Remove(typeMapKey);
                }
            }
        }
    }
}
