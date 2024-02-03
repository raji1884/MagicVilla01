using MagicVilla_VillaAPI.models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicVilla_VillaAPI.data
{
    public class ApplicationDbContex : DbContext 
    {
        public ApplicationDbContex(DbContextOptions <ApplicationDbContex > options)
            : base(options) 
        {
        }

        public DbSet<Villamodel> villamodels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villamodel>().HasData(
                new Villamodel()
                {


                    Id = 1,
                    Name = "heart villa",
                    Details = "good",
                    ImageUrl = "",
                    occupancy = 5,
                    Rate = 690,
                    sqft = 520,
                    Amenity = ""


                },
             new Villamodel
             {
                 Id = 2,
                 Name = "modern villa",
                 Details = "good",
                 ImageUrl = "",
                 occupancy = 6,
                 Rate = 300,
                 sqft = 740,
                 Amenity = ""
             },
             new Villamodel
             {
                 Id = 3,
                 Name = "lovely villa",
                 Details = "good",
                 ImageUrl = "",
                 occupancy = 5,
                 Rate = 100,
                 sqft = 340,
                 Amenity = ""
             },
             new Villamodel
             {
                 Id = 4,
                 Name = "sweet villa",
                 Details = "good",
                 ImageUrl = "",
                 occupancy = 5,
                 Rate = 300,
                 sqft = 640,
                 Amenity = ""
             });
        }
    }
}
