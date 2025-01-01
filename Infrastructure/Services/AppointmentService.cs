using System.Net;
using Domain.Dtos;
using Domain.Dtos.AppointmentDtos;
using Domain.Dtos.ServiceDtos;
using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AppointmentService(DataContext context) : IAppointmentService
{
    public async Task<Response<List<GetAppointmentDto>>> GetAllAsync()
    {

        var appointments = await context.Appointments
             .ToListAsync();

        var appointmentDtos = appointments.Select(b => new GetAppointmentDto()
        {
            Id = b.Id,
            AppointmentDate = b.AppointmentDate,
            StartTime = b.StartTime,
            ClientName = b.ClientName,
            ClientPhone = b.ClientPhone,
            Status = b.Status,
            Comment = b.Comment,
        }).ToList();

        return new Response<List<GetAppointmentDto>>(appointmentDtos);
    }

    public async Task<Response<Appointment>> GetByIdAsync(int id)
    {
        var course = await context.Appointments.FirstOrDefaultAsync(g => g.Id == id);
        return course == null
            ? new Response<Appointment>(HttpStatusCode.NotFound, "Appointment not found")
            : new Response<Appointment>(course);
    }

    public async Task<Response<string>> CreateAsync(Appointment request)
    {
        var course = new Appointment()
        {
            AppointmentDate=request.AppointmentDate,
            StartTime=request.StartTime,
            ClientName=request.ClientName,
            ClientPhone=request.ClientPhone,
            Status=request.Status,
            Comment=request.Comment,
        };
        await context.Appointments.AddAsync(course);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Appointment not created")
            : new Response<string>("Appointment created successfully");
    }

    public async Task<Response<string>> UpdateAsync(Appointment request)
    {
        var existingAppointment = await context.Appointments.FirstOrDefaultAsync(g => g.Id == request.Id);

        if (existingAppointment == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Appointment not found");
        }

        existingAppointment.AppointmentDate = request.AppointmentDate;
        existingAppointment.StartTime = request.StartTime;
        existingAppointment.ClientName = request.ClientName;
        existingAppointment.ClientPhone = request.ClientPhone;
        existingAppointment.Status = request.Status;
        existingAppointment.Comment = request.Comment;

        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Appointment not updated")
            : new Response<string>("Appointment updated successfully");
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var existingAppointment = await context.Appointments.FirstOrDefaultAsync(g => g.Id == id);

        if (existingAppointment == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Appointment not found");
        }

        context.Remove(existingAppointment);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Appointment not deleted")
            : new Response<string>("Appointment deleted successfully");
    }
}