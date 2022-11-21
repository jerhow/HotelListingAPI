using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.DTO.Hotel
{
    public class UpdateHotelDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Range(1.0, 5.0)]
        public double? Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
