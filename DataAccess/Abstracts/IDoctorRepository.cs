using API_Hospital.Models;

namespace API_Hospital.DataAccess.Abstracts;

public interface IDoctorRepository
{
    void Add(Doctor doctor);
    void Delete(Doctor doctor);
    Doctor? GetById(int id);
    List<Doctor>? GetAll();
    void Update(Doctor doctor);
}
