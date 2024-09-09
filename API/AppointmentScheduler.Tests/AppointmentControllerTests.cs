using AppointmentScheduler.API.Controllers;
using AppointmentScheduler.Application.DTOs;
using AppointmentScheduler.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AppointmentScheduler.Tests
{
    public class AppointmentControllerTests
    {
        private readonly Mock<IAppointmentService> _mockAppointmentService;
        private readonly AppointmentController _controller;

        public AppointmentControllerTests()
        {
            _mockAppointmentService = new Mock<IAppointmentService>();
            _controller = new AppointmentController(_mockAppointmentService.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithAppointmentDto()
        {
            var appointmentId = Guid.NewGuid();
            var appointmentDto = new AppointmentDTO { Id = appointmentId };
            _mockAppointmentService.Setup(service => service.GetByIdAsync(appointmentId))
                                   .ReturnsAsync(appointmentDto);


            var result = await _controller.Get(appointmentId);

            var actionResult = Assert.IsAssignableFrom<ActionResult<AppointmentDTO>>(result);
            var okResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsAssignableFrom<AppointmentDTO>(okResult.Value);
            Assert.Equal(appointmentId, returnValue.Id);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithAppointmentList()
        {
            var userId = Guid.NewGuid();
            var appointments = new List<AppointmentDTO> { new AppointmentDTO { Id = Guid.NewGuid() } };
            _mockAppointmentService.Setup(service => service.GetAllAsync(userId))
                                   .ReturnsAsync(appointments);

            var result = await _controller.GetAll(userId);

            var actionResult = Assert.IsAssignableFrom<ActionResult<IEnumerable<AppointmentDTO>>>(result);
            var okResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsAssignableFrom<List<AppointmentDTO>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtActionResult()
        {
            var appointmentDto = new CreateAppointmentDTO { Id = Guid.NewGuid() };
            _mockAppointmentService.Setup(service => service.CreateAsync(appointmentDto))
                                   .Returns(Task.CompletedTask);

            var result = await _controller.Create(appointmentDto);

            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
            var createdResult = Assert.IsAssignableFrom<CreatedAtActionResult>(actionResult);
            Assert.Equal(nameof(AppointmentController.Get), createdResult.ActionName);
        }

        [Fact]
        public async Task Update_ReturnsNoContentResult()
        {
            var appointmentDto = new AppointmentDTO { Id = Guid.NewGuid() };
            _mockAppointmentService.Setup(service => service.UpdateAsync(appointmentDto))
                                   .Returns(Task.CompletedTask);

            var result = await _controller.Update(appointmentDto.Id, appointmentDto);

            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsAssignableFrom<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task Delete_ReturnsNoContentResult()
        {
            var appointmentId = Guid.NewGuid();
            _mockAppointmentService.Setup(service => service.DeleteAsync(appointmentId))
                                   .Returns(Task.CompletedTask);

            var result = await _controller.Delete(appointmentId);

            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsAssignableFrom<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task Activate_ReturnsNoContentResult_WhenSuccess()
        {
            var appointmentId = Guid.NewGuid();
            _mockAppointmentService.Setup(service => service.ActivateAsync(appointmentId))
                                   .ReturnsAsync(true);

            var result = await _controller.Activate(appointmentId);

            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsAssignableFrom<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task Activate_ReturnsBadRequest_WhenFailure()
        {
            var appointmentId = Guid.NewGuid();
            _mockAppointmentService.Setup(service => service.ActivateAsync(appointmentId))
                                   .ReturnsAsync(false);

            var result = await _controller.Activate(appointmentId);

            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
            var badRequestResult = Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult);
            Assert.Equal("Appointment cannot be activated. It is too late.", badRequestResult.Value);
        }
    }
}
