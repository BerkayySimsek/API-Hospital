using API_Hospital.DataAccess.Abstracts;
using API_Hospital.Models;
using API_Hospital.Models.Dtos.Doctors;
using API_Hospital.Services.Abstracts;
using API_Hospital.Services.BusinessRules;
using API_Hospital.Services.ValidationRules;

namespace API_Hospital.Services.Concretes;

public class DoctorService : IDoctorService
{
    private IDoctorRepository _doctorRepository;
    private DoctorBusinessRules _doctorBusinessRules;

    public DoctorService(IDoctorRepository doctorRepository, DoctorBusinessRules doctorBusinessRules)
    {
        _doctorRepository = doctorRepository;
        _doctorBusinessRules = doctorBusinessRules;
    }

    public void Add(DoctorAddRequestDto dto)
    {
        DoctorValidationRules.DoctorAddValidator(dto);
        Doctor doctor = ConvertToDoctor(dto);
        _doctorRepository.Add(doctor);
    }

    public void Delete(int id)
    {
        Doctor doctor = _doctorRepository.GetById(id);
        _doctorRepository.Delete(doctor);
    }

    public List<DoctorResponseDto> GetAll()
    {
        List<Doctor> doctors = _doctorRepository.GetAll();
        List<DoctorResponseDto> response = ConvertToResponseDtoList(doctors);
        return response;
    }

    public DoctorResponseDto? GetById(int id)
    {
        Doctor doctor = _doctorRepository.GetById(id);
        _doctorBusinessRules.DoctorNotFound(doctor);
        DoctorResponseDto response = ConvertToResponseDto(doctor);
        return response;
    }

    public void Update(DoctorUpdateRequestDto dto)
    {
        Doctor doctor = _doctorRepository.GetById(dto.Id);
        if (doctor != null)
        {
            doctor.Name = dto.Name;
            doctor.Surname = dto.Surname;
            doctor.Branch = dto.Branch;

            _doctorRepository.Update(doctor);
        }
        else
        {
            throw new Exception("Doktor Bulunamadı.");
        }
    }

    private Doctor ConvertToDoctor(DoctorAddRequestDto dto)
    {
        return new Doctor
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Branch = dto.Branch,
        };
    }
    private DoctorResponseDto ConvertToResponseDto(Doctor doctor)
    {
        return new DoctorResponseDto
        {
            Id = doctor.Id,
            Name = doctor.Name,
            Surname = doctor.Surname,
            Branch = doctor.Branch,
        };
    }
    private List<DoctorResponseDto> ConvertToResponseDtoList(List<Doctor> doctors)
    {
        return doctors.Select(x => ConvertToResponseDto(x)).ToList();
    }
}
