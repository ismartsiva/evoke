using Microsoft.EntityFrameworkCore;

namespace HotelListing.data
{
    public class databaseContext : DbContext
    {
        public databaseContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<country> Countries { get; set; }
        DbSet<hotel> Hotels { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<country>().HasData(
                new country
                {
                    Id = 1,
                    Name = "India",
                    ShortName = "Ind",
                },
                new country
                {
                    Id = 2,
                    Name = "Andhra",
                    ShortName = "Ap",
                },
                new country
                {
                    Id = 3,
                    Name = "telangana",
                    ShortName = "ts",
                }
                );
            builder.Entity<hotel>().HasData(
                new hotel
                {
                    Id = 1,
                    Name = "sandal reso",
                    Address = "negril",
                    CountryId = 1,
                    rating = 4.5
                },
                new hotel
                {
                    Id = 2,
                    Name = "sandal reso",
                    Address = "negril",
                    CountryId = 2,
                    rating = 4
                },
                new hotel
                {
                    Id = 3,
                    Name = "garnda melli",
                    Address = "massia",
                    CountryId = 3,
                    rating = 4.4
                }
                );
        }
    }
}
