using API_Hospital.DataAccess.Abstracts;
using API_Hospital.DataAccess.Concretes;
using API_Hospital.Models;
using API_Hospital.Models.Dtos.Appointment;
using API_Hospital.Models.Dtos.Appointments;
using API_Hospital.Services.Abstracts;

namespace API_Hospital.Services.Concretes;

public class AppointmentService : IAppointmentService
{
    IAppointmentRepository _appointmentRepository;
    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    public void Add(AppointmentAddRequestDto dto)
    {
        Appointment appointment = ConvertToAppointment(dto);
        _appointmentRepository.Add(appointment);
    }

    public void Delete(int id)
    {
        Appointment appointment = _appointmentRepository.GetById(id);
        _appointmentRepository.Delete(appointment);
    }

    public List<AppointmentResponseDto> GetAll()
    {
        List<Appointment> appointments=_appointmentRepository.GetAll();
        List<AppointmentResponseDto> response = ConvertToResponseDtoList(appointments);
        return response;
    }

    public AppointmentResponseDto? GetById(int id)
    {
        Appointment appointment = _appointmentRepository.GetById(id);
        AppointmentResponseDto dto = ConvertToResponseDto(appointment);
        return dto;
    }

    public void Update(AppointmentUpdateRequestDto dto)
    {
        Appointment appointment = _appointmentRepository.GetById(dto.Id);
        if (appointment!=null)
        {
            appointment.Id = dto.Id;
            appointment.PatientId = dto.PatientId;
            appointment.DoctorId = dto.DoctorId;
            appointment.AppointmentDate = dto.AppointmentDate;
            appointment.Notes = dto.Notes;

            _appointmentRepository.Update(appointment);
        }
    }

    private Appointment ConvertToAppointment(AppointmentAddRequestDto dto)
    {
        return new Appointment
        {
            PatientId = dto.PatientId,
            DoctorId = dto.DoctorId,
            AppointmentDate = dto.AppointmentDate,
            Notes = dto.Notes,
        };
    }
    private AppointmentResponseDto ConvertToResponseDto(Appointment appointment)
    {
        return new AppointmentResponseDto
        {
            Id = appointment.Id,
            PatientId = appointment.PatientId,
            PatientName = $"{appointment.Patient.Name} {appointment.Patient.Surname}",
            DoctorId = appointment.DoctorId,
            DoctorName = $"{appointment.Doctor.Name} {appointment.Doctor.Surname}",
            DoctorBranch = appointment.Doctor.Branch,
            AppointmentDate = appointment.AppointmentDate,
            Notes = appointment.Notes,
        };
    }
    private List<AppointmentResponseDto> ConvertToResponseDtoList(List<Appointment> appointments)
    {
        return appointments.Select(x => ConvertToResponseDto(x)).ToList();
    }
}
