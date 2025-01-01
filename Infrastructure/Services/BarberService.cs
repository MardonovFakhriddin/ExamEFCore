using System.Net;
using Domain.Dtos;
using Domain.Dtos.BarberDtos;
using Domain.Dtos.ServiceDtos;
using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BarberService(DataContext context) : IBarberService
{
    public async Task<Response<List<GetBarberDto>>> GetAllAsync()
    {

        var barbers = await context.Barbers
            .Include(c=>c.Services)
             .ToListAsync();

        var barberDtos = barbers.Select(b => new GetBarberDto()
        {
            Id = b.Id,
            FirstName = b.FirstName,
            LastName = b.LastName,
            PhoneNumber = b.PhoneNumber,
            Experience = b.Experience,
            Status = b.Status,
            Specialization = b.Specialization,
            Services = b.Services.Select(s => new GetServiceDto()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Duration = s.Duration,
                Price = s.Price,
                Category = s.Category,
                IsActive = s.IsActive
            }).ToList()
        }).ToList();

        return new Response<List<GetBarberDto>>(barberDtos);
    }

    public async Task<Response<Barber>> GetByIdAsync(int id)
    {
        var course = await context.Barbers.FirstOrDefaultAsync(g => g.Id == id);
        return course == null
            ? new Response<Barber>(HttpStatusCode.NotFound, "Barber not found")
            : new Response<Barber>(course);
    }

    public async Task<Response<string>> CreateAsync(Barber request)
    {
        var course = new Barber()
        {
           FirstName = request.FirstName,
           LastName = request.LastName,
           PhoneNumber = request.PhoneNumber,
           Experience = request.Experience,
           Status = request.Status,
           Specialization = request.Specialization
        };
        await context.Barbers.AddAsync(course);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Barber not created")
            : new Response<string>("Barber created successfully");
    }

    public async Task<Response<string>> UpdateAsync(Barber request)
    {
        var existingBarber = await context.Barbers.FirstOrDefaultAsync(g => g.Id == request.Id);

        if (existingBarber == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Barber not found");
        }

        existingBarber.FirstName = request.FirstName;
        existingBarber.LastName = request.LastName;
        existingBarber.PhoneNumber = request.PhoneNumber;
        existingBarber.Experience = request.Experience;
        existingBarber.Status = request.Status;
        existingBarber.Specialization = request.Specialization;

        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Barber not updated")
            : new Response<string>("Barber updated successfully");
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var existingBarber = await context.Barbers.FirstOrDefaultAsync(g => g.Id == id);

        if (existingBarber == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Barber not found");
        }

        context.Remove(existingBarber);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Barber not deleted")
            : new Response<string>("Barber deleted successfully");
    }
}