using AppointmentScheduler.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Application.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDTO> GetByIdAsync(int id);
        Task<IEnumerable<AppointmentDTO>> GetAllAsync();
        Task CreateAsync(AppointmentDTO appointmentDto);
        Task UpdateAsync(AppointmentDTO appointmentDto);
        Task DeleteAsync(int id);
    }
}
