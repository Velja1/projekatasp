using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RoleID { get; set; }
        public ICollection<Reservations> PostComments { get; set; } = new List<Reservations>();
        public Roles Role { get; set; }
    }
}
