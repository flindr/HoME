using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoMeAPI.Models
{
    public class Measurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public float Temperature { get; set; }
        [Required]
        public float Humdidity { get; set; }
        //public Location Location { get; set; }
    }
}