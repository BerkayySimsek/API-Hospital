using API_Hospital.Exceptions.Types;
using API_Hospital.Models.Dtos.Patient;

namespace API_Hospital.Services.ValidationRules
{
    public class PatientValidatorRules
    {
        public static void PatientAddValidator(PatientAddRequestDto dto)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                errors.Add("Ad alanı boş geçilemez");
            }
            if (dto.Name.Length < 2)
            {
                errors.Add("Ad alanı minimum 2 karakter olmalıdır");
            }
            if (string.IsNullOrWhiteSpace(dto.Surname))
            {
                errors.Add("Soyad alanı boş geçilemez");
            }
            if (dto.Surname.Length < 2)
            {
                errors.Add("Soyad alanı minimum 2 karakter olmalıdır");
            }

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }
    }
}
