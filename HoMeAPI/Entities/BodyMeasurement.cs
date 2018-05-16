using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HoMeAPI.Models;

namespace HoMeAPI.Entities
{
    public class BodyMeasurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public float Weight { get; set; }

        public float BodyFat { get; set; }

        public float BodyWater { get; set; }

        public float Muscle { get; set; }

        public float Bmi { get; set; }

        public int Bmr { get; set; }
    }
}