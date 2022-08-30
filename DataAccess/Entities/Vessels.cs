using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Vessels
    {
        public int ID { get; set; }
        [Required]
        public int Type_ID { get; set; }
        [Required]
        public int Manufacter_ID { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Width { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public string Length { get; set; }
    }
}
