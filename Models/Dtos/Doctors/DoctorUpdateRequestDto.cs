namespace API_Hospital.Models.Dtos.Doctors;

public class DoctorUpdateRequestDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Branch { get; set; }
}
