using AppointmentScheduler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Application.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Cedula { get; set; }
        public string Name { get; set; }
        public Guid RoleId { get; set; }
        public RoleDTO Role { get; set; }
    }
}
