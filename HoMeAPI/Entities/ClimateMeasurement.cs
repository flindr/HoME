﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HoMeAPI.Models;

namespace HoMeAPI.Entities
{
    public class ClimateMeasurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public float Temperature { get; set; }
        [Required]
        public float Humidity { get; set; }
        public Location Location { get; set; }
        public DateTime Time { get; set; }
    }
}