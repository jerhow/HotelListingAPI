using HotelListing.API.Data;
using HotelListing.API.DTO.Country;
using System.Threading.Tasks;

namespace HotelListing.API.Services;

public interface ICountryService
{
    Task<CountryDto> GetCountry(int id);
}
