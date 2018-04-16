using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HoMeAPI.Models
{
    public class MeasurementDto
    {
        [Required(ErrorMessage = "Must be float/int.")]
        public float Temperature { get; set; }
        [Required (ErrorMessage = "Must be float/int.")]
        public float Humidity { get; set; }
        [EnumDataType(typeof(Location), ErrorMessage = "Has to be either 0 or 1") ]
        //[RegularExpression(@"Inside|Outside", ErrorMessage = "Has to be either 'inside' our 'outside'")]
        public Location Location { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}