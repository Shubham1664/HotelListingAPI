using WebApplication3.Data;

namespace HotelListing.Contracts
{
    public interface ICountries: IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
