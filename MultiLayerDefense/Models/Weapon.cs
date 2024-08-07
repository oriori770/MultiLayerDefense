using System.ComponentModel.DataAnnotations;

namespace Multi_Layer_Defense.Models
{
    // Weapon model detailing the type and specifications of the enemy's weapon
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public WeaponType Type { get; set; }
        public int Speed { get; set; }
        public int EffectiveDistance { get; set; }
        [Required]
        public CounterMeasureType CounterMeasure { get; set; }
    }
}
