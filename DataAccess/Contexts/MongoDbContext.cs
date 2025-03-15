using API_Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Hospital.DataAccess.Contexts;

public class MongoDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMongoDB("mongodb://localhost:27017", "HospitalProject_hospital_db");
    }
    public DbSet<Hospital>? Hospitals{ get; set; }
}
