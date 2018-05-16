using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HoMeAPI.Models
{
    public abstract class BodyMeasurementDto
    {
        [Required(ErrorMessage = "Must be float/int.")]
        public float Weight { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public float BodyFat { get; set; }

        public float BodyWater { get; set; }

        public float Muscle { get; set; }

        public float Bmi { get; set; }

        public int Bmr { get; set; }
    }
}