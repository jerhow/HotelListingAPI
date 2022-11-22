using HotelListing.API.Data;
using System.Linq;

namespace HotelListing.API.Services
{
    public class HotelService : IHotelService
    {
        private readonly HotelListingDbContext _context;

        public HotelService(HotelListingDbContext context)
        {
            _context = context;
        }

        public bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }
    }
}
