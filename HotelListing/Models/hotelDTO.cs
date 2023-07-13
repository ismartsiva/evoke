using HotelListing.data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Models
{
    public class createhotelDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Hotel Name is Too long")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "Address Name is Too long")]
        public string Address { get; set; }
        [Required]
        [Range(1,5)]
        public double rating { get; set; }

        [Required]
        public int CountryId { get; set; }

    }
    public class hotelDTO : createhotelDTO
    {
        public int Id { get; set; }

        public CountryDTO Country { get; set; }


    }

}
