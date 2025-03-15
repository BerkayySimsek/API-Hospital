namespace API_Hospital.Models.Dtos.Appointment;

public class AppointmentResponseDto
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string? PatientName { get; set; }
    public int DoctorId { get; set; }
    public string? DoctorName { get; set; }
    public string? DoctorBranch { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
}
