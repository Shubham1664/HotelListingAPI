using AutoMapper;
using HotelListing.Data;
using HotelListing.Models.hotels;
using HotelListing.Models.User;
using WebApplication3.Data;
using WebApplication3.Models.Country;
using WebApplication3.Models.hotels;

namespace WebApplication3.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Country, CreateCountry>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<ApiUserDto, ApiUser>().ReverseMap();
        }
    }
}
