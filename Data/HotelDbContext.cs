using HotelListing.Data;
using HotelListing.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data
{
    public class HotelDbContext: IdentityDbContext<ApiUser>
    {
        public HotelDbContext(DbContextOptions options): base(options) { }
        public DbSet<Hotel> Hotels { get; set; }    
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "India",
                    ShortName = "Ind"

                },
                new Country
                {
                    Id = 2,
                    Name = "America",
                    ShortName = "USA"
                }

                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id=1,
                    Name="raddison",
                    Address="New Delhi",
                    CountryId=1,
                    Rating=4.5
                },
                new Hotel
                {
                    Id=2,
                    Name="Hyatt",
                    Address="New York",
                    CountryId=2,
                    Rating = 4.8
                }
                );


        }


    }
}
