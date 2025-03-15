namespace API_Hospital.Models.Dtos.Patient;

public class PatientAddRequestDto
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime BirthDate { get; set; }
}
