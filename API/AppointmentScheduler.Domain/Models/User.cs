﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Cedula { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
