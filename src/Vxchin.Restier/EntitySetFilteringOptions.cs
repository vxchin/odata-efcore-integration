using System.Collections.Generic;

namespace Vxchin.Restier
{
    public class EntitySetFilteringOptions
    {
        public ICollection<string> EntityTypeNames { get; } = new List<string>();
    }
}