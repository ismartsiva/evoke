using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.data
{
    public class hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public double rating { get; set; }

        [ForeignKey(nameof(country))]
        public int CountryId { get; set; }

        public country Country { get; set; }


    }
}
