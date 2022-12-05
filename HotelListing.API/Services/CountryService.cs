using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.DTO.Country;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelListing.API.Services;

public class CountryService : ICountryService
{
    private readonly HotelListingDbContext _context;
    private readonly IMapper _mapper;

    public CountryService(HotelListingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CountryDto> GetCountry(int id)
    {
        var country = await _context.Countries.Include(q => q.Hotels)
                                    .FirstOrDefaultAsync(q => q.Id == id);
        
        var countryDto = _mapper.Map<CountryDto>(country);

        return countryDto;
    }
}
