namespace API_Hospital.Models.Dtos.Appointment;

public class AppointmentAddRequestDto
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
}
