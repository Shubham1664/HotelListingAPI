using HotelListing.Contracts;
using WebApplication3.Data;

namespace HotelListing.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IhotelsRepository
    {
		private readonly HotelDbContext _context;
		public HotelRepository(HotelDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
