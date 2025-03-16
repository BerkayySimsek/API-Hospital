using API_Hospital.Models.Dtos.Patient;
using API_Hospital.Models.Dtos.Patients;
using MongoDB.Driver;

namespace API_Hospital.Services.Abstracts
{
    public interface IPatientService
    {
        void Add(PatientAddRequestDto dto);
        void Delete(int id);
        PatientResponseDto? GetById(int id);
        List<PatientResponseDto> GetAll();
        void Update(PatientUpdateRequestDto dto);

    }
}
