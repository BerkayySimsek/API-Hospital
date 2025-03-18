using API_Hospital.DataAccess.Abstracts;
using API_Hospital.DataAccess.Contexts;
using API_Hospital.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace API_Hospital.DataAccess.Concretes;

public class AppointmentRepository : IAppointmentRepository
{
    SqlDbContext _context;

    public AppointmentRepository(SqlDbContext context)
    {
        _context = context;
    }

    public void Add(Appointment appointment)
    {
        _context.Entry(appointment).State = EntityState.Added;
        _context.SaveChanges();
    }

    public void Delete(Appointment appointment)
    {
        _context.Appointments.Remove(appointment);
        _context.SaveChanges();
    }

    public List<Appointment>? GetAll()
    {
        List<Appointment> appointments = _context.Appointments.Include(x => x.Doctor).Include(y => y.Patient).ToList();
        return appointments;
    }

    public Appointment? GetById(int id)
    {
        Appointment? appointment = _context.Appointments.Include(x => x.Doctor).Include(y => y.Patient).SingleOrDefault(X => X.Id == id);
        return appointment;
    }

    public void Update(Appointment appointment)
    {
        _context.Update(appointment);
        _context.SaveChanges();
    }
}
