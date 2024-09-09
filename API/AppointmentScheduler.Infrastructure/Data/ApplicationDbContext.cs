using AppointmentScheduler.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminRoleId = Guid.Parse("d06e27e5-8dcf-4a80-92e4-fc9d257ec0a1");
            var userRoleId = Guid.Parse("d85e26e5-7dcf-4a80-92e4-fc9d257ec0b2");

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = adminRoleId, Name = "Admin" },
                new Role { Id = userRoleId, Name = "User" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), Name = "Luis Alejandro Pérez Abril", Cedula = "1152466496", RoleId = userRoleId },
                new User { Id = Guid.NewGuid(), Name = "Jose Eugenio Rodriguez", Cedula = "9396795", RoleId = userRoleId },
                new User { Id = Guid.NewGuid(), Name = "Marta Alejandra Soacha", Cedula = "47438962", RoleId = userRoleId },
                new User { Id = Guid.NewGuid(), Name = "Elkin Dario Sanchez", Cedula = "987654321", RoleId = adminRoleId }
            ); ;
        }
    }
}
