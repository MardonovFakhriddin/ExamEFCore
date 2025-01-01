using Domain.Dtos.AppointmentDtos;
using Domain.Dtos.ServiceDtos;
using Domain.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IServiceService
{
    Task<Response<List<GetServiceDto>>> GetAllAsync();
    Task<Response<Service>> GetByIdAsync(int id);
    Task<Response<string>> CreateAsync(Service request);
    Task<Response<string>> UpdateAsync(Service request);
    Task<Response<string>> DeleteAsync(int id);
}