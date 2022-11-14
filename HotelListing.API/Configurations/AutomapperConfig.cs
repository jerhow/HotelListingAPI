using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.DTO.Country;
using MessagePack.Resolvers;

namespace HotelListing.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            // Create maps between our data types (in both directions if we use ReverseMap)
            CreateMap<Country, CreateCountryDto>().ReverseMap();
        }
    }
}
