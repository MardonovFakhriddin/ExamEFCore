using Domain.Entities;
using Domain.Enums;

namespace Domain.Dtos.AppointmentDtos;

public class GetAppointmentDto
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public string ClientName { get; set; }
    public string ClientPhone { get; set; }
    public AppointmentStatus Status { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}