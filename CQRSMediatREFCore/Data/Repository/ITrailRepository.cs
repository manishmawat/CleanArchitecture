using CQRSMediatREFCore.Entities;

namespace CQRSMediatREFCore.Data.Repository
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
    }
}
