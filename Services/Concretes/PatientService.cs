using API_Hospital.DataAccess.Abstracts;
using API_Hospital.Models;
using API_Hospital.Models.Dtos.Patient;
using API_Hospital.Models.Dtos.Patients;
using API_Hospital.Services.Abstracts;
using API_Hospital.Services.BusinessRules;
using API_Hospital.Services.ValidationRules;

namespace API_Hospital.Services.Concretes
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        private PatientBusinessRules _patientBusinessRules;

        public PatientService(IPatientRepository patientRepository, PatientBusinessRules patientBusinessRules)
        {
            _patientRepository = patientRepository;
            _patientBusinessRules = patientBusinessRules;
        }

        public void Add(PatientAddRequestDto dto)
        {
            PatientValidatorRules.PatientAddValidator(dto);
            Patient patient = ConvertToPatient(dto);
            _patientRepository.Add(patient);
        }

        public void Delete(int id)
        {
            Patient patient = _patientRepository.GetById(id);
            _patientRepository.Delete(patient);
        }

        public List<PatientResponseDto> GetAll()
        {
            List<Patient> patients = _patientRepository.GetAll();
            List<PatientResponseDto> responses = ConvertToResponseDtoList(patients);
            return responses;
        }

        public PatientResponseDto? GetById(int id)
        {
            Patient patient = _patientRepository.GetById(id);
            _patientBusinessRules.PatientNotFound(patient);
            PatientResponseDto response = ConvertToResponseDto(patient);
            return response;
        }

        public void Update(PatientUpdateRequestDto dto)
        {
            Patient patient = _patientRepository.GetById(dto.Id);
            if (patient != null)
            {
                patient.Name = dto.Name;
                patient.Surname = dto.Surname;
                patient.BirthDate = dto.BirthDate;

                _patientRepository.Update(patient);
            }
            else
            {
                throw new Exception("Hasta Bulunamadı.");
            }
        }

        private Patient ConvertToPatient(PatientAddRequestDto dto)
        {
            return new Patient
            {
                Name = dto.Name,
                Surname = dto.Surname,
                BirthDate = new DateTime(dto.BirthDate.Year, dto.BirthDate.Month, dto.BirthDate.Day),
            };
        }

        private PatientResponseDto ConvertToResponseDto(Patient patient)
        {
            return new PatientResponseDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Surname = patient.Surname,
                BirthDate = new DateTime(patient.BirthDate.Year, patient.BirthDate.Month, patient.BirthDate.Day),
            };
        }

        private List<PatientResponseDto> ConvertToResponseDtoList(List<Patient> patients)
        {
            return patients.Select(x => ConvertToResponseDto(x)).ToList();
        }
    }
}
