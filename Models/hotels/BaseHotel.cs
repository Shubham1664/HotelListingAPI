using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Models.hotels
{
    public class BaseHotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
    }
}
