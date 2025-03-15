using API_Hospital.DataAccess.Abstracts;
using API_Hospital.DataAccess.Contexts;
using API_Hospital.Models;

namespace API_Hospital.DataAccess.Concretes;

public class PatientRepository : IPatientRepository
{
    private SqlDbContext _context;
    public PatientRepository(SqlDbContext context)
    {
        _context = context;
    }
    public void Add(Patient patient)
    {
        _context.Patients.Add(patient);
        _context.SaveChanges();
    }

    public void Delete(Patient patient)
    {
        _context.Patients.Remove(patient);
        _context.SaveChanges();
    }

    public List<Patient>? GetAll()
    {
        return _context.Patients.ToList();
    }

    public Patient? GetById(int id)
    {
        return _context.Patients.Find(id);
    }
}
