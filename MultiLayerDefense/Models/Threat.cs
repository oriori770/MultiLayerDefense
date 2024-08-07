using System.ComponentModel.DataAnnotations;

namespace Multi_Layer_Defense.Models
{
    // Threat model representing a potential security threat
    public class Threat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Origin { get; set; }
        // New property: Time when the threat was launched
        public DateTime LaunchTime { get; set; }
        // Foreign Key for Weapon
        public int WeaponId { get; set; }
        // Navigation property for Weapon
        public Weapon Weapon { get; set; }
        public Regions regions { get; set; }

    }
}
