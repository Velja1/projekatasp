using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Types> Types { get; set; }
        public DbSet<Manufacters>  Manufacters { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Vessels> Vessels { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
