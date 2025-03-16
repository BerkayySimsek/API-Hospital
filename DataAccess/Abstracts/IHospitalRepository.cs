using API_Hospital.Models;

namespace API_Hospital.DataAccess.Abstracts;

public interface IHospitalRepository
{
    void Add(Hospital hospital);
    void Delete(Hospital hospital);
    Hospital? GetById(Guid id);
    List<Hospital>? GetAll();
    void Update(Hospital hospital);

}
