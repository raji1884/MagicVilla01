using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.models
{
    public class Villamodel

    { 

        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }
        [Required]
        [MaxLength]
        public string Name { get; set; }
        public int occupancy { get; set; }
        public int sqft { get; set; }
        public string Details { get; set; }
        public string Amenity { get; set; }
        public double Rate { get; set; }
        public string ImageUrl { get; set; }


    }
}
