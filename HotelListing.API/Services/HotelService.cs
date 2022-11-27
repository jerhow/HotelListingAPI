using HotelListing.API.Data;
using HotelListing.API.DTO.Hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.API.Services
{
    public class HotelService : IHotelService
    {
        private readonly HotelListingDbContext _context;

        public HotelService(HotelListingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetHotelDto>> GetHotelsAsync()
        {
            // Fetch the data
            var hotels = await (from h in _context.Hotels
                                join c in _context.Countries
                                on h.CountryId equals c.Id
                                select new
                                {
                                    h.Id,
                                    h.Name,
                                    h.Address,
                                    h.Rating,
                                    h.CountryId,
                                    CountryName = c.Name
                                }).ToListAsync();

            // Explicitly cast to an enumerable of our DTO type
            IEnumerable<GetHotelDto> result;
            result = hotels.Select(s => new GetHotelDto()
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Rating = s.Rating,
                CountryId = s.CountryId,
                CountryName = s.CountryName
            });

            return result;
        }

        public bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }
    }
}
