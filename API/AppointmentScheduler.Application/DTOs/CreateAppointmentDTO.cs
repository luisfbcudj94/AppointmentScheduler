﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Application.DTOs
{
    public class CreateAppointmentDTO
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Guid LocationId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ActivatedAt { get; set; }
    }
}
