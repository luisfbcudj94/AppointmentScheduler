using AppointmentScheduler.Application.DTOs;
using AppointmentScheduler.Application.Services.Interfaces;
using AppointmentScheduler.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Application.Services
{
    public class LocationService: ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<LocationDTO> GetByIdAsync(Guid id)
        {
            var location = await _locationRepository.GetByIdAsync(id);
            return _mapper.Map<LocationDTO>(location);
        }

        public async Task<IEnumerable<LocationDTO>> GetAllAsync()
        {
            var locations = await _locationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LocationDTO>>(locations);
        }
    }
}
