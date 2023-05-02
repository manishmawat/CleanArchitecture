using System;

namespace Application.CycleTrails.Queries
{
    public sealed record GetCycleTrailByIdQuery(Guid cycleTrailId) /*: IQuery<GetCycleTrailResponse>*/
    {
    }
}
