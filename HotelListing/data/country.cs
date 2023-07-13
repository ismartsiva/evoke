namespace HotelListing.data
{
    public class country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual IList<hotel> Hotels { get; set; }

    }
}
