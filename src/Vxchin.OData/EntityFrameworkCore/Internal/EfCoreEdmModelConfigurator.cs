using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.OData.ModelBuilder;

namespace Vxchin.OData.EntityFrameworkCore.Internal
{
    internal class EfCoreEdmModelConfigurator : IConventionEdmModelConfigurator
    {
        private readonly IModel _model;

        public EfCoreEdmModelConfigurator(IModel model)
        {
            _model = model;
        }

        public void Configure(ODataConventionModelBuilder builder)
        {
            foreach (var entityType in _model.GetEntityTypes())
            {
                var primaryKey = entityType.FindPrimaryKey();
                if (primaryKey is null)
                {
                    builder.AddComplexType(entityType.ClrType);
                    continue;
                }

                var entityTypeConfiguration = builder.AddEntityType(entityType.ClrType);
                foreach (var keyProperty in primaryKey.Properties)
                    entityTypeConfiguration.HasKey(keyProperty.PropertyInfo);
                builder.AddEntitySet(entityType.ClrType.Name, entityTypeConfiguration);
            }
        }
    }
}