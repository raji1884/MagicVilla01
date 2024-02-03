using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.models.DTO
{
    public class VillaUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength (30)]
        public string Name { get; set; }
        [Required]
        public int occupancy { get; set; }
        public int sqft { get; set; }
        [Required]
        public string Details { get; set; }
        public string Amenity { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
