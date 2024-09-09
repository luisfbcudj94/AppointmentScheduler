using AppointmentScheduler.Application.DTOs;
using AppointmentScheduler.Application.Services.Interfaces;
using AppointmentScheduler.Domain.Models;
using AppointmentScheduler.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Application.Services
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentDTO> GetByIdAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            return _mapper.Map<AppointmentDTO>(appointment);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAsync(Guid userId)
        {
            var appointments = await _appointmentRepository.GetAllAsync(userId);
            return _mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
        }

        public async Task CreateAsync(CreateAppointmentDTO appointmentDto)
        {
            var now = DateTime.UtcNow;
            var maxDate = now.AddDays(3);

            var appointmentDate = appointmentDto.AppointmentDate;

            if (appointmentDate < now || appointmentDate > maxDate)
            {
                throw new ArgumentException($"Appointment date must be between {now:yyyy-MM-dd} and {maxDate:yyyy-MM-dd}.");
            }

            var hasFiveOrMore = await _appointmentRepository.HasFiveOrMoreAppointmentsOnSameDateAsync(appointmentDto.UserId, appointmentDate);
            if (hasFiveOrMore)
            {
                throw new ArgumentException("User already has 5 or more appointments on the same date.");
            }

            appointmentDto.Id = Guid.NewGuid();
            appointmentDto.IsActive = false;
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            await _appointmentRepository.CreateAsync(appointment);
        }


        public async Task UpdateAsync(AppointmentDTO appointmentDto)
        {
            var now = DateTime.UtcNow;
            var maxDate = now.AddDays(3);

            var appointmentDate = appointmentDto.AppointmentDate;

            if (appointmentDate < now || appointmentDate > maxDate)
            {
                throw new ArgumentException($"Appointment date must be between {now:yyyy-MM-dd} and {maxDate:yyyy-MM-dd}.");
            }

            var appointment = _mapper.Map<Appointment>(appointmentDto);
            await _appointmentRepository.UpdateAsync(appointment);
        }


        public async Task DeleteAsync(Guid id)
        {
            await _appointmentRepository.DeleteAsync(id);
        }

        public async Task<bool> ActivateAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                throw new ArgumentException("Appointment not found");
            }

            var now = DateTime.UtcNow;
            var fifteenMinutesBefore = appointment.AppointmentDate.AddMinutes(-15);

            if (now > fifteenMinutesBefore)
            {
                return false;
            }

            appointment.IsActive = true;
            await _appointmentRepository.UpdateAsync(appointment);
            return true;
        }
    }
}
