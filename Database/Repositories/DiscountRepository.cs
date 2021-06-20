using BespokedBikesTimHawkins.Database.Models;

namespace BespokedBikesTimHawkins.Database.Repositories
{
    public class DiscountRepository : BaseRepository
    {
        public DiscountRepository(BeSpokedDbContext context)
            : base(context)
        {
        }
    }
}
