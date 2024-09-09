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
    public class AppointmentRepository: IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;

        public AppointmentRepository(
            ApplicationDbContext context,
            IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _context.Appointments
                                .Include(a => a.Location)
                                .Include(u => u.User)
                                    .ThenInclude(r => r.Role)
                                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync(Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);

            var query = _context.Appointments
                .Include(a => a.Location)
                .Include(u => u.User)
                    .ThenInclude(r => r.Role)
                .AsQueryable();

            if (user.Role.Name != "Admin")
            {
                query = query.Where(a => a.UserId == userId);
            }

            return await query.ToListAsync();
        }


        public async Task CreateAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var appointment = await GetByIdAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
