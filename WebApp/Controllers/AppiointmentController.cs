using Domain.Dtos.AppointmentDtos;
using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AppiointmentController(IAppointmentService appointmentService)
{
    [HttpGet]
    public async Task<Response<List<GetAppointmentDto>>> GetAllAsync()
    {
        var result = await appointmentService.GetAllAsync();
        return (result);
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Appointment>> GetByIdAsync(int id)
    {
        var result = await appointmentService.GetByIdAsync(id);
        return (result);
    }

    [HttpPost]
    public async Task<Response<string>> CreateAsync(Appointment appointment)
    {
        var result = await appointmentService.CreateAsync(appointment);
        return (result);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Appointment appointment)
    {
        var result = await appointmentService.UpdateAsync(appointment);
        return (result);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var result = await appointmentService.DeleteAsync(id);
        return (result);
    }
}
