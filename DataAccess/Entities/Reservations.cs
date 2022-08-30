using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Reservations
    {
        public int ID { get; set; }
        [Required]
        public int User_ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public Reservations Reservation { get; set; }
    }
}
