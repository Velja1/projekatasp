using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Types
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Vessels> PostComments { get; set; } = new List<Vessels>();
    }
}
