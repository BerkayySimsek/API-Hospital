using API_Hospital.Exceptions.Types;
using API_Hospital.Models.Dtos.Appointment;

namespace API_Hospital.Services.ValidationRules
{
    public class AppointmentValidationRules
    {
        public static void AppointmentAddValidator(AppointmentAddRequestDto dto)
        {
            List<string> errors = new List<string>();

            if (dto.PatientId == 0)
            {
                errors.Add("PatientId 0 olamaz");
            }
            if (dto.DoctorId == 0)
            {
                errors.Add("DoctorId 0 olamaz");
            }
            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }
    }
}
