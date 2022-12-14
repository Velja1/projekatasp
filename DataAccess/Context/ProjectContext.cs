using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-C3VBCB6;Initial Catalog=projekatasp;Integrated Security=True");
        }

        public DbSet<Types> Types { get; set; }
        public DbSet<Manufacters>  Manufacters { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Vessels> Vessels { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
