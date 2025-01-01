using Domain.Dtos.ServiceDtos;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Dtos.BarberDtos;

public class GetBarberDto
{
    public int Id { get; set; }
    public string FirstName { get; set;}
    public string LastName { get; set;}
    public string PhoneNumber { get; set; }
    public int Experience { get; set; }
    public BarberStatus Status { get; set; }
    public string Specialization { get; set; }
    public List<GetServiceDto> Services { get; set; }
}