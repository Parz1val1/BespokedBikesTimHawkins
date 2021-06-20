using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Database.Repositories
{
    public class BaseRepository
    {
        protected BeSpokedDbContext Context { get; }

        protected BaseRepository(BeSpokedDbContext context)
        {
            this.Context = context;
        }
    }
}
