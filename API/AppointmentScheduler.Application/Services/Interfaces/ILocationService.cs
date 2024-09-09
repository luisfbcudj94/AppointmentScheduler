using AppointmentScheduler.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Application.Services.Interfaces
{
    public interface ILocationService
    {
        Task<LocationDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<LocationDTO>> GetAllAsync();
    }
}
