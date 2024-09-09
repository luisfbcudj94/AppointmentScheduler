using AppointmentScheduler.Application.DTOs;
using AppointmentScheduler.Application.Services.Interfaces;
using AppointmentScheduler.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduler.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDTO>> Get(Guid id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAll(
            [FromQuery] Guid userId)
        {
            var appointments = await _appointmentService.GetAllAsync(userId);
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDTO appointmentDto)
        {
            await _appointmentService.CreateAsync(appointmentDto);
            return CreatedAtAction(nameof(Get), new { id = appointmentDto.Id }, appointmentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AppointmentDTO appointmentDto)
        {
            if (id != appointmentDto.Id) return BadRequest();
            await _appointmentService.UpdateAsync(appointmentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _appointmentService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{appointmentId}/activate")]
        public async Task<IActionResult> Activate(Guid appointmentId)
        {
            try
            {
                var result = await _appointmentService.ActivateAsync(appointmentId);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Appointment cannot be activated. It is too late.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
