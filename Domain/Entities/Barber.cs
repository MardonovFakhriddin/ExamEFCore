using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class Barber
{
    [Key]
    public int  Id { get; set; }
    [Required,MaxLength(50)]
    public string FirstName { get; set;}
    [Required,MaxLength(50)]
    public string LastName { get; set;}
    [Required,Phone]
    public string PhoneNumber { get; set; }
    public int Experience { get; set; }
    public BarberStatus Status { get; set; }
    [MaxLength(100)]
    public string Specialization { get; set; }
    public List<Service> Services { get; set; }
    public List<Appointment> Appointments { get; set; }
}