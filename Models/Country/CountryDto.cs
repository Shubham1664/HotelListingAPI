using WebApplication3.Models.hotels;

namespace WebApplication3.Models.Country
{


    public class CountryDto: BaseCountryDto
    {
        public int Id { get; set; }
        
        public List<HotelDto> Hotels { get; set; }
    }

}
