using API_Hospital.DataAccess.Abstracts;
using API_Hospital.DataAccess.Contexts;
using API_Hospital.Models;

namespace API_Hospital.DataAccess.Concretes;

public class DoctorRepository : IDoctorRepository
{
    SqlDbContext _context;
    public DoctorRepository(SqlDbContext context)
    {
        _context = context;
    }
    public void Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
    }

    public void Delete(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
        _context.SaveChanges();
    }

    public List<Doctor>? GetAll()
    {
        return _context.Doctors.ToList();
    }

    public Doctor? GetById(int id)
    {
        return _context.Doctors.Find(id);
    }

    public void Update(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        _context.SaveChanges();
    }
}
