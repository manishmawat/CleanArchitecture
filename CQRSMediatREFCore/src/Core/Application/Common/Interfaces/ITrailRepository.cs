using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Common.Interfaces
{
    public interface ITrailRepository
    {
        //Get
        Task<IEnumerable<Trail>> GetTrails();

        //Get 
        Task<Trail?> GetTrail(Guid id);

        //Post / Add new trail
        Task<Guid> AddTrail(Trail trail);

        //Patch / Update Trail
        Task<Trail> UpdateTrail(Trail trail);

        //Delete Trail

        Task<bool> DeleteTrail(Guid id);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
