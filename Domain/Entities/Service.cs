using Domain.Enums;

namespace Domain.Entities;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public decimal Price { get; set; }
    public ServiceCategory Category { get; set; }
    public bool IsActive { get; set; }
    public Barber Barber { get; set; }
    public List<Appointment> Appointments { get; set; }
}