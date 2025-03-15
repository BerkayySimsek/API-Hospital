using API_Hospital.Models.Dtos.Appointment;

namespace API_Hospital.Services.Abstracts;

public interface IAppointmentService
{
    void Add(AppointmentAddRequestDto dto);
    void Delete(int id);
    List<AppointmentResponseDto> GetAll();
    AppointmentResponseDto? GetById(int id);
}
