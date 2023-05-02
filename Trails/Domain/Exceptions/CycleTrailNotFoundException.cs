using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public sealed class CycleTrailNotFoundException: NotFoundException
    {
        public CycleTrailNotFoundException(Guid cycleTrailId)
            :base($"The cycle trail with id: {cycleTrailId} is not found.")
        {
            
        }
    }
}
