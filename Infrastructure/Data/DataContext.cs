using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) :DbContext(options)
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Barber> Barbers { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
           .HasOne(a => a.Barber)
           .WithMany(b => b.Appointments)
           .HasForeignKey(a => a.BarberId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appointment>()
           .HasOne(a => a.Service)
           .WithMany(s => s.Appointments)
           .HasForeignKey(a => a.ServiceId).OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}