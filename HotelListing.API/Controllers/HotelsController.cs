using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.DTO.Hotel;
using AutoMapper;
using HotelListing.API.Services;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;
        private readonly HotelService _service;

        public HotelsController(HotelListingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _service = new HotelService(_context);
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetHotelDto>>> GetHotels()
        {
            var hotels = await (from h in _context.Hotels
                                join c in _context.Countries
                                on h.CountryId equals c.Id
                                select new
                                {
                                    id = h.Id,
                                    name = h.Name,
                                    address = h.Address,
                                    rating = h.Rating,
                                    countryId = h.CountryId,
                                    countryName = c.Name
                                }).ToListAsync();

            return Ok(hotels);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetHotelDto>> GetHotel(int id)
        {
            GetHotelDto getHotelDto = new GetHotelDto();
            
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(id);
            
            getHotelDto.Id = hotel.Id;
            getHotelDto.Name = hotel.Name;
            getHotelDto.Address = hotel.Address;
            getHotelDto.Rating = hotel.Rating;
            getHotelDto.CountryId = hotel.CountryId;
            getHotelDto.CountryName = country.Name;

            return Ok(getHotelDto);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, UpdateHotelDto updateHotelDto)
        {
            if(updateHotelDto.Id != id)
            {
                return BadRequest();
            }

            if (!_service.HotelExists(id))
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if(hotel == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(updateHotelDto.CountryId);
            if(country == null)
            {
                return NotFound(new { Id = updateHotelDto.CountryId, error = "Invalid country id" });
            }

            _mapper.Map(updateHotelDto, hotel);

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto createHotelDto)
        {
            var hotel = _mapper.Map<Hotel>(createHotelDto);

            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
