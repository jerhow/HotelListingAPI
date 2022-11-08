using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Data;

public class Hotel
{
    public int Id { get; set; } // EF knows to make this auto-incrementing

    public string Name { get; set; }

    public string Address { get; set; }

    public double Rating { get; set; }

    // Couple of things:
    // 1. You need this annotation to tell EF that this is a FK
    // 2. You could also write this like: ForeignKey("CountryId")
    // 2a. The way we have it provides a safeguard in that it will throw an error.
    //     If you just give it a string, it will generate the correspondng field based on *whatever*
    //     that string says. This way of doing it provides a binding of sorts, and keeps everyone honest.
    [ForeignKey(nameof(CountryId))]
    public int CountryId { get; set; }

    public Country Country { get; set; }
}
