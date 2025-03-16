using API_Hospital.Models;

namespace API_Hospital.DataAccess.Abstracts;

public interface IAppointmentRepository
{
    void Add(Appointment appointment);
    void Delete(Appointment appointment);
    Appointment? GetById(int id);
    List<Appointment>? GetAll();
    void Update(Appointment appointment);

}
