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
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> ValidateUser(string cedula)
        {
            var user = await _userRepository.ValidateUser(cedula);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
