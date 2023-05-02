using Trails.Domain.Entities;

namespace Domain.Abstractions
{
    public interface ITrailRepository
    {
        void Insert(CycleTrail cycleTrail);
    }
}
