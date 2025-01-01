using System.Net;
using Domain.Dtos;
using Domain.Dtos.ServiceDtos;
using Domain.Dtos.ServiceDtos;
using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ServiceService(DataContext context) : IServiceService
{
    public async Task<Response<List<GetServiceDto>>> GetAllAsync()
    {

        var services = await context.Services
             .ToListAsync();

        var serviceDtos = services.Select(s => new GetServiceDto()
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Duration = s.Duration,
            Price = s.Price,
            Category = s.Category
        }).ToList();

        return new Response<List<GetServiceDto>>(serviceDtos);
    }

    public async Task<Response<Service>> GetByIdAsync(int id)
    {
        var course = await context.Services.FirstOrDefaultAsync(g => g.Id == id);
        return course == null
            ? new Response<Service>(HttpStatusCode.NotFound, "Service not found")
            : new Response<Service>(course);
    }

    public async Task<Response<string>> CreateAsync(Service request)
    {
        var course = new Service()
        {
           Name = request.Name,
           Description = request.Description,
           Duration = request.Duration,
           Price = request.Price,
           Category = request.Category,
           IsActive = request.IsActive,
           Appointments = request.Appointments,
        };
        await context.Services.AddAsync(course);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Service not created")
            : new Response<string>("Service created successfully");
    }

    public async Task<Response<string>> UpdateAsync(Service request)
    {
        var existingService = await context.Services.FirstOrDefaultAsync(g => g.Id == request.Id);

        if (existingService == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Service not found");
        }

        existingService.Name=request.Name;
        existingService.Description = request.Description;
        existingService.Duration = request.Duration;
        existingService.Price = request.Price;
        existingService.Category = request.Category;
        existingService.IsActive = request.IsActive;
        existingService.Appointments = request.Appointments;

        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Service not updated")
            : new Response<string>("Service updated successfully");
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var existingService = await context.Services.FirstOrDefaultAsync(g => g.Id == id);

        if (existingService == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Service not found");
        }

        context.Remove(existingService);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Service not deleted")
            : new Response<string>("Service deleted successfully");
    }
}