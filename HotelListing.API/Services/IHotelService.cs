using HotelListing.API.DTO.Hotel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelListing.API.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<GetHotelDto>> GetHotelsAsync();

        bool HotelExists(int id);
    }
}
