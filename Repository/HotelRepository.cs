using HotelListing.Contracts;
using WebApplication3.Data;

namespace HotelListing.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IhotelsRepository
    {
        public HotelRepository(HotelDbContext context) : base(context)
        {
        }
    }
}
