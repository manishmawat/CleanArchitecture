using CQRSMediatREFCore.Entities;

namespace CQRSMediatREFCore.Repository
{
    public class FakeDataStore:IRepository
    {
        private readonly List<Trail> _trails;

        public FakeDataStore()
        {
            _trails = new();
        }

        public async Task<IEnumerable<Trail>> GetTrails()
        {
            return await Task.FromResult(_trails);
        }

        public async Task<Trail?> GetTrail(Guid id)
        {
            return await Task.FromResult(_trails.Where(x => x.Id == id)?.FirstOrDefault());
        }

        public Task<Guid> AddTrail(Trail trail)
        {
            if (trail.Id == default)
            {
                return Task.FromResult(default(Guid));
            }

            _trails.Add(trail);

            return Task.FromResult(trail.Id);

        }

        public Task<Trail> UpdateTrail(Trail trail)
        {
            var oldTrail = _trails.Where(x => x.Id == trail.Id)?.FirstOrDefault();
            if (oldTrail != null)
            {
                oldTrail.Distance=trail.Distance;
                oldTrail.Name=trail.Name;
            }

            return Task.FromResult(oldTrail!);
        }

        public Task<bool> DeleteTrail(Guid id)
        {
            return Task.FromResult(_trails.RemoveAll(x => x.Id == id)==0);
        }
    }
}
