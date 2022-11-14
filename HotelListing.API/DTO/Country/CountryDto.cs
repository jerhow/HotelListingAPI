using HotelListing.API.DTO.Hotel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.DTO.Country
{
    // An individual Country with relevant details
    public class CountryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        // NOTE: This is intentionally named 'Hotels' to match the field in the Country model, so that it:
        // 1. Makes sense semantically
        // 2. Can be picked up by the AutoMapper
        public List<HotelDto> Hotels { get; set; }
    }
}
