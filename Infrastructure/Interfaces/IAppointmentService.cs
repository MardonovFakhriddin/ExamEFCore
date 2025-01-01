using Domain.Dtos.AppointmentDtos;
using Domain.Dtos.BarberDtos;
using Domain.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IAppointmentService
{
    Task<Response<List<GetAppointmentDto>>> GetAllAsync();
    Task<Response<Appointment>> GetByIdAsync(int id);
    Task<Response<string>> CreateAsync(Appointment request);
    Task<Response<string>> UpdateAsync(Appointment request);
    Task<Response<string>> DeleteAsync(int id);
}