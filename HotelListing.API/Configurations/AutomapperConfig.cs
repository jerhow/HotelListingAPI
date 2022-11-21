using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.DTO.Country;
using HotelListing.API.DTO.Hotel;
using MessagePack.Resolvers;

namespace HotelListing.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            // Create mappings between our data types (in both directions if we use ReverseMap)

            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, CountriesDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();
            
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
        }
    }
}
