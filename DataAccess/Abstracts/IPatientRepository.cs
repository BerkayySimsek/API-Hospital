using API_Hospital.Models;

namespace API_Hospital.DataAccess.Abstracts;

public interface IPatientRepository
{
    void Add(Patient patient);
    void Delete(Patient patient);
    Patient? GetById(int id);
    List<Patient>? GetAll();
}
