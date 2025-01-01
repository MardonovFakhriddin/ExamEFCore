using Domain.Dtos.BarberDtos;
using Domain.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IBarberService
{
    Task<Response<List<GetBarberDto>>> GetAllAsync();
    Task<Response<Barber>> GetByIdAsync(int id);
    Task<Response<string>> CreateAsync(Barber barber);
    Task<Response<string>> UpdateAsync(Barber barber);
    Task<Response<string>> DeleteAsync(int id);
}