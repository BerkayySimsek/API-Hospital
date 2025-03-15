using API_Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Hospital.DataAccess.Contexts;

public class SqlDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"server= (localdb)\MSSQLLocalDB; Database= hospital_db; Trusted_connection=true");
    }
    public DbSet<Doctor>? Doctors { get; set; }
    public DbSet<Patient>? Patients { get; set; }
    public DbSet<Appointment>? Appointments { get; set; }
}
