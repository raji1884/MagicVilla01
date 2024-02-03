using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.models.DTO
{
    public class VillaCreatDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength (30)]
        public string Name { get; set; }    
        public int occupancy { get; set; }
        public int sqft { get; set; }
        public string Details { get; set; }
        public string Amenity { get; set; }
        public double Rate { get; set; }
        public string ImageUrl { get; set; }
    }
}
