using API_Hospital.Models;
using API_Hospital.Models.Dtos.Doctors;
using API_Hospital.Models.Dtos.Patients;

namespace API_Hospital.Services.Abstracts;

public interface IDoctorService
{
    void Add(DoctorAddRequestDto dto);
    void Delete(int id);
    List<DoctorResponseDto> GetAll();
    DoctorResponseDto? GetById(int id);
    void Update(DoctorUpdateRequestDto dto);
}
