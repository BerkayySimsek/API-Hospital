using API_Hospital.Models.Dtos.Hospital;
using API_Hospital.Models.Dtos.Hospitals;

namespace API_Hospital.Services.Abstracts;

public interface IHospitalService
{
    void Add(HospitalAddRequestDto dto);
    void Delete(string id);
    List<HospitalResponseDto> GetAll();
    HospitalResponseDto? GetById(string id);
    void Update(HospitalUpdateRequestDto dto);
}
