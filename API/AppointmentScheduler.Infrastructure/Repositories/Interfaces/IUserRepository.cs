using AppointmentScheduler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> ValidateUser(string cedula);
        Task<User> GetUserById(Guid userId);
    }
}
