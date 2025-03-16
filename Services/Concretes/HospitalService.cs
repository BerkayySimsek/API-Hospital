using API_Hospital.DataAccess.Abstracts;
using API_Hospital.DataAccess.Concretes;
using API_Hospital.Models;
using API_Hospital.Models.Dtos.Hospital;
using API_Hospital.Models.Dtos.Hospitals;
using API_Hospital.Services.Abstracts;

namespace API_Hospital.Services.Concretes;

public class HospitalService : IHospitalService
{
    private IHospitalRepository _hospitalRepository;
    public HospitalService(IHospitalRepository hospitalRepository)
    {
        _hospitalRepository = hospitalRepository;
    }
    public void Add(HospitalAddRequestDto dto)
    {
        Hospital hospital = ConvertToHospital(dto);
        _hospitalRepository.Add(hospital);
    }

    public void Delete(string id)
    {
        Guid convertId = new Guid(id);
        Hospital hospital = _hospitalRepository.GetById(convertId);
        _hospitalRepository.Delete(hospital);
    }

    public List<HospitalResponseDto> GetAll()
    {
        List<Hospital> hospitals = _hospitalRepository.GetAll();
        List<HospitalResponseDto> responses = ConvertToResponseDtoList(hospitals);
        return responses;
    }

    public HospitalResponseDto? GetById(string id)
    {
        Guid convertId = new Guid(id);
        Hospital hospital = _hospitalRepository.GetById(convertId);
        HospitalResponseDto response = ConvertToResponseDto(hospital);
        return response;
    }

    public void Update(HospitalUpdateRequestDto dto)
    {
        Guid convertId = new Guid(dto.Id);
        Hospital hospital= _hospitalRepository.GetById(convertId);
        if (hospital != null)
        {
            hospital.Id = convertId;
            hospital.Name = dto.Name;
            hospital.City = dto.City;
            hospital.Address = dto.Address;

            _hospitalRepository.Update(hospital);
        }
        else
        {
            throw new Exception("Hastane Bulunamadı.");
        }
    }

    private Hospital ConvertToHospital(HospitalAddRequestDto dto)
    {
        return new Hospital
        {
            Name = dto.Name,
            City = dto.City,
            Address = dto.Address,
        };
    }
    private HospitalResponseDto ConvertToResponseDto(Hospital hospital)
    {
        return new HospitalResponseDto
        {
            Id = hospital.Id.ToString(),
            Name = hospital.Name,
            City = hospital.City,
            Address = hospital.Address,
        };
    }
    private List<HospitalResponseDto> ConvertToResponseDtoList(List<Hospital> hospitals)
    {
        return hospitals.Select(x => ConvertToResponseDto(x)).ToList();
    }
}
