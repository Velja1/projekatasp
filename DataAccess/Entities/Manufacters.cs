using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Manufacters
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Vessels> PostComments { get; set; } = new List<Vessels>();
    }
}
