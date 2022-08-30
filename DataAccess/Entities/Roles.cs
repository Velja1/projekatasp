using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Roles
    {
        public int ID { get; set; }
        [Required]
        public int Name { get; set; }
        public ICollection<Roles> PostComments { get; set; } = new List<Roles>();

    }
}
