using Domain.Dtos.BarberDtos;
using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BarberController(IBarberService barberService)
{
    [HttpGet]
    public async Task<Response<List<GetBarberDto>>> GetAllAsync()
    {
        var result = await barberService.GetAllAsync();
        return (result);
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Barber>> GetByIdAsync(int id)
    {
        var result = await barberService.GetByIdAsync(id);
        return (result);
    }

    [HttpPost]
    public async Task<Response<string>> CreateAsync(Barber request)
    {
        var result = await barberService.CreateAsync(request);
        return (result);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Barber request)
    {
        var result = await barberService.UpdateAsync(request);
        return (result);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var result = await barberService.DeleteAsync(id);
        return (result);
    }
}