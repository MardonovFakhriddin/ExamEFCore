using Domain.Dtos.ServiceDtos;
using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ServiceController(IServiceService serviceService)
{
    [HttpGet]
    public async Task<Response<List<GetServiceDto>>> GetAllAsync()
    {
        var result = await serviceService.GetAllAsync();
        return (result);
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Service>> GetByIdAsync(int id)
    {
        var result = await serviceService.GetByIdAsync(id);
        return (result);
    }

    [HttpPost]
    public async Task<Response<string>> CreateAsync(Service request)
    {
        var result = await serviceService.CreateAsync(request);
        return (result);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Service request)
    {
        var result = await serviceService.UpdateAsync(request);
        return (result);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var result = await serviceService.DeleteAsync(id);
        return (result);
    }
}