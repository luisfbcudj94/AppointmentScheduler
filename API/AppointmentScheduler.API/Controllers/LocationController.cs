using AppointmentScheduler.Application.DTOs;
using AppointmentScheduler.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> Get(Guid id)
        {
            var location = await _locationService.GetByIdAsync(id);
            if (location == null) return NotFound();
            return Ok(location);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetAll()
        {
            var locations = await _locationService.GetAllAsync();
            return Ok(locations);
        }
    }
}
