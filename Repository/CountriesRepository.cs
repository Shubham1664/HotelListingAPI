using HotelListing.Contracts;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;

namespace HotelListing.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountries
    {
        private readonly HotelDbContext _context;
        public CountriesRepository(HotelDbContext context) : base(context)
        {
            _context= context;
        }

        public async Task<Country> GetDetails(int id)
        {
           return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync();
        }
    }
}
