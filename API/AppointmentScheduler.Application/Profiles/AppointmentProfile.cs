using AppointmentScheduler.Application.DTOs;
using AppointmentScheduler.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Application.Profiles
{
    public class AppointmentProfile: Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentDTO>()
                .ReverseMap();

            CreateMap<Location, LocationDTO>()
                .ReverseMap();
        }
    }
}
