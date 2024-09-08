﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Application.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int LocationId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ActivatedAt { get; set; }
    }
}
