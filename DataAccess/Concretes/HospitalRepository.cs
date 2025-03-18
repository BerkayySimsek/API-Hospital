using API_Hospital.DataAccess.Abstracts;
using API_Hospital.DataAccess.Contexts;
using API_Hospital.Models;

namespace API_Hospital.DataAccess.Concretes;

public class HospitalRepository : IHospitalRepository
{
    MongoDbContext _context;
    public HospitalRepository(MongoDbContext context)
    {
        _context = context;
    }
    public void Add(Hospital hospital)
    {
        _context.Hospitals.Add(hospital);
        _context.SaveChanges();
    }

    public void Delete(Hospital hospital)
    {
        _context.Hospitals.Remove(hospital);
        _context.SaveChanges();
    }

    public List<Hospital>? GetAll()
    {
        return _context.Hospitals.ToList();
    }

    public Hospital? GetById(Guid id)
    {
        return _context.Hospitals.Find(id);
    }

    public void Update(Hospital hospital)
    {
        _context.Hospitals.Update(hospital);
        _context.SaveChanges();
    }
}
