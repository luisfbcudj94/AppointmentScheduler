using AppointmentScheduler.Domain.Models;
using AppointmentScheduler.Infrastructure.Data;
using AppointmentScheduler.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> ValidateUser(string cedula)
        {
            return await _context.Users
                                .Include(a => a.Role)
                                .FirstOrDefaultAsync(a => a.Cedula == cedula);
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _context.Users
                                .Include(a => a.Role)
                                .FirstOrDefaultAsync(a => a.Id == userId);
        }
    }
}
