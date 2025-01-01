using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Appointment
{
    [Key] public int Id { get; set; }
    public int BarberId { get; set; }
    public Barber Barber { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    public DateTime AppointmentDate { get; set; } =DateTime.UtcNow;
    public TimeSpan StartTime { get; set; }
    [Required]
    public string ClientName { get; set; }
    [Required,Phone]
    public string ClientPhone { get; set; }
    public AppointmentStatus Status { get; set; }
    [MaxLength(200)]
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}