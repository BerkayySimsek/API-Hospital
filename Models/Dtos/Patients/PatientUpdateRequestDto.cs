namespace API_Hospital.Models.Dtos.Patients;

public class PatientUpdateRequestDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime BirthDate { get; set; }
}
