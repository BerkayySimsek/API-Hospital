namespace API_Hospital.Models;

public class Appointment
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; } = new Doctor();
    public int PatientId { get; set; }
    public Patient? Patient { get; set; } = new Patient();
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }

}
