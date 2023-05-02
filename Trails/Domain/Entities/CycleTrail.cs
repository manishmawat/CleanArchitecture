
using Trails.Domain.Primitives;

namespace Trails.Domain.Entities
{
    public sealed class CycleTrail:Entity
    {
        public CycleTrail(Guid id, string name, double distance) : base(id)
        {
            Name = name;
            Distance = distance;
        }

        public CycleTrail()
        {
            
        }

        public string Name { get; private set; }
        public double Distance { get; private set; }
    }
}
